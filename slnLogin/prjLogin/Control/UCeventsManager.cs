using prjLogin.Properties;
using slnFriendshipBackEnd.Forms;
//using slnFriendshipBackEnd.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace slnFriendshipBackEnd.UserControls
{
    public partial class UCeventsManager : UserControl
    {
        string ConnectionString = Settings.Default.PCR7FriendshipConnectionString;
        public UCeventsManager()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;


            loadEventsList();
            loadCities();
            loadEventTypes();
            LoadBatchEventNames(); // 載入活動名稱
            SetDefaultBatchDateRange(); // 先設定日期範圍
            LoadEventBatches(); // 再載入活動梯次

            this.comboBox1.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            this.comboBox2.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);

        }

        private void SetDefaultBatchDateRange()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT MIN(eventStartDate) AS EarliestStartDate, 
                       MAX(eventEndDate) AS LatestEndDate
                FROM Batches";

                    SqlCommand command = new SqlCommand(query, conn);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // 讀取資料庫中最早的開始日期和最晚的結束日期
                        if (reader["EarliestStartDate"] != DBNull.Value)
                        {
                            dateTimePickerBatchStart.Value = Convert.ToDateTime(reader["EarliestStartDate"]);
                        }
                        if (reader["LatestEndDate"] != DBNull.Value)
                        {
                            dateTimePickerBatchEnd.Value = Convert.ToDateTime(reader["LatestEndDate"]);
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("設定預設日期範圍失敗：" + ex.Message);
            }
        }

        private void LoadBatchEventNames()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT DISTINCT e.name FROM Events e JOIN Batches b ON e.eventID = b.eventID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    comboBoxBatchEventName.Items.Clear();
                    comboBoxBatchEventName.Items.Add("All"); // 預設加入 "All" 選項

                    foreach (DataRow row in dataTable.Rows)
                    {
                        comboBoxBatchEventName.Items.Add(row["name"].ToString());
                    }

                    comboBoxBatchEventName.SelectedIndex = 0; // 預設選擇 "All"
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入活動名稱失敗：" + ex.Message);
            }
        }

        // 載入活動梯次
        private void LoadEventBatches(string eventName = "All", DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    b.batchID AS '活動梯次ID', 
                    e.name AS '活動名稱', 
                    FORMAT(b.eventStartDate, 'yyyy/M/dd tt hh:mm', 'zh-TW') AS '活動開始日期',
                    b.quota AS '活動名額'
                FROM Batches b
                JOIN Events e ON b.eventID = e.eventID
                WHERE 1=1";

                    List<SqlParameter> parameters = new List<SqlParameter>();

                    if (eventName != "All")
                    {
                        query += " AND e.name = @EventName";
                        parameters.Add(new SqlParameter("@EventName", eventName));
                    }

                    if (startDate.HasValue && endDate.HasValue)
                    {
                        query += " AND b.eventStartDate >= @StartDate AND b.eventEndDate <= @EndDate";
                        parameters.Add(new SqlParameter("@StartDate", startDate.Value));
                        parameters.Add(new SqlParameter("@EndDate", endDate.Value));
                    }

                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddRange(parameters.ToArray());

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridViewBatchList.DataSource = dataTable;

                    // 增加「檢視/編輯」和「刪除」按鈕
                    AddBatchActionButtons();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入活動梯次失敗：" + ex.Message);
            }
        }

        private void AddBatchActionButtons()
        {
            // 確保不會重複加入按鈕列
            if (dataGridViewBatchList.Columns["Edit"] == null)
            {
                DataGridViewLinkColumn editColumn = new DataGridViewLinkColumn
                {
                    Name = "Edit",
                    HeaderText = "",
                    Text = "檢視 / 編輯",
                    UseColumnTextForLinkValue = true
                };
                dataGridViewBatchList.Columns.Add(editColumn);
            }

            if (dataGridViewBatchList.Columns["Delete"] == null)
            {
                DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "刪除",
                    Text = "－",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewBatchList.Columns.Add(deleteColumn);
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                return;
            }

            if (comboBox1.Text == "All" && comboBox2.Text == "All")
            {
                loadEventsList();
            }
            else
            {
                LoadFilteredEventsList();
            }
        }

        private void LoadFilteredEventsList()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;

                    string query = "SELECT e.[eventID], e.[name], et.[eventType], c.[cityName] " +
                                   "FROM [dbo].[Events] e " +
                                   "JOIN [dbo].[EventTypes] et ON e.[eventTypeID] = et.eventTypeID " +
                                   "JOIN [dbo].[cities] c ON e.cityID = c.cityID ";

                    List<string> filters = new List<string>();

                    if (comboBox1.SelectedItem != null && comboBox1.Text != "All")
                    {
                        filters.Add("c.[cityName] = @CityName");
                        command.Parameters.AddWithValue("@CityName", comboBox1.Text);
                    }

                    if (comboBox2.SelectedItem != null && comboBox2.Text != "All")
                    {
                        filters.Add("et.[eventType] = @EventType");
                        command.Parameters.AddWithValue("@EventType", comboBox2.Text);
                    }

                    if (filters.Count > 0)
                    {
                        query += " WHERE " + string.Join(" AND ", filters);
                    }

                    command.CommandText = query;

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // 修改欄位名稱
                    dataTable.Columns[0].ColumnName = "活動ID";
                    dataTable.Columns[1].ColumnName = "活動名稱";
                    dataTable.Columns[2].ColumnName = "活動分類";
                    dataTable.Columns[3].ColumnName = "地區";

                    UpdateDataGridView(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("篩選失敗：" + ex.Message);
            }
        }

        private void UpdateDataGridView(DataTable dataTable)
        {
            dataGridViewEvents.DataSource = null;
            dataGridViewEvents.Columns.Clear();

            dataGridViewEvents.DataSource = dataTable; // 重新綁定新的 DataSource

            // 加入「檢視 / 編輯」與「刪除」按鈕
            if (dataGridViewEvents.Columns["ModifyColumn"] == null)
            {
                DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn();
                linkColumn.HeaderText = " ";
                linkColumn.Name = "ModifyColumn";
                linkColumn.Text = "檢視 / 編輯";
                linkColumn.UseColumnTextForLinkValue = true;
                dataGridViewEvents.Columns.Add(linkColumn);
            }

            if (dataGridViewEvents.Columns["DeleteColumn"] == null)
            {
                DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
                deleteColumn.HeaderText = "刪除";
                deleteColumn.Name = "DeleteColumn";
                deleteColumn.Text = "－";
                deleteColumn.UseColumnTextForButtonValue = true;
                dataGridViewEvents.Columns.Add(deleteColumn);
            }

            // 確保固定欄位順序
            dataGridViewEvents.Columns["活動ID"].DisplayIndex = 0;
            dataGridViewEvents.Columns["活動名稱"].DisplayIndex = 1;
            dataGridViewEvents.Columns["活動分類"].DisplayIndex = 2;
            dataGridViewEvents.Columns["地區"].DisplayIndex = 3;
            dataGridViewEvents.Columns["ModifyColumn"].DisplayIndex = dataGridViewEvents.Columns.Count - 2;
            dataGridViewEvents.Columns["DeleteColumn"].DisplayIndex = dataGridViewEvents.Columns.Count - 1;
        }

        private void loadEventTypes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // 查詢 EventTypes 的所有資料
                    string query = "SELECT eventTypeID AS '活動類型ID', eventType AS '活動類型' FROM [dbo].[EventTypes]";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // 更新 DataGridView
                    dataGridViewEventTypes.DataSource = null; // 先清空
                    dataGridViewEventTypes.Columns.Clear();
                    dataGridViewEventTypes.DataSource = dataTable;

                    // 加入「修改」和「刪除」按鈕
                    AddEventTypeActionButtons();

                    // 更新 comboBox2（確保下拉選單內的資料也更新）
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add("All"); // 加入 "All" 選項

                    foreach (DataRow row in dataTable.Rows)
                    {
                        comboBox2.Items.Add(row["活動類型"].ToString());
                    }

                    comboBox2.SelectedIndex = 0; // 預設選擇 "All"
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入活動分類失敗：" + ex.Message);
            }
        }

        private void AddEventTypeActionButtons()
        {
            // 確保不會重複加入按鈕列
            if (dataGridViewEventTypes.Columns["ModifyColumn"] == null)
            {
                DataGridViewLinkColumn modifyColumn = new DataGridViewLinkColumn
                {
                    Name = "ModifyColumn",
                    HeaderText = "",
                    Text = "修改",
                    UseColumnTextForLinkValue = true
                };
                dataGridViewEventTypes.Columns.Add(modifyColumn);
            }

            if (dataGridViewEventTypes.Columns["DeleteColumn"] == null)
            {
                DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                {
                    Name = "DeleteColumn",
                    HeaderText = "刪除",
                    Text = "－",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewEventTypes.Columns.Add(deleteColumn);
            }
        }

        public void loadCities()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT cityID, cityName FROM [dbo].[cities]";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // 確保有 "All" 作為第一個選項
                    DataRow allRow = dataTable.NewRow();
                    allRow["cityID"] = DBNull.Value; // 讓 "All" 沒有實際的 ID
                    allRow["cityName"] = "All";
                    dataTable.Rows.InsertAt(allRow, 0);

                    comboBox1.DataSource = dataTable;
                    comboBox1.DisplayMember = "cityName"; // 顯示城市名稱
                    comboBox1.ValueMember = "cityID";     // 設定 `ValueMember`
                    comboBox1.SelectedIndex = 0; // 預設選擇 "All"
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入地區失敗：" + ex.Message);
            }
        }

        private void loadEventsList()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT e.[eventID], e.[name], et.[eventType], c.[cityName] " +
                                          "FROM [dbo].[Events] e " +
                                          "JOIN [dbo].[EventTypes] et ON e.[eventTypeID] = et.eventTypeID " +
                                          "JOIN [dbo].[cities] c ON e.cityID = c.cityID";
                    command.Connection = conn;

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // 修改欄位名稱
                    dataTable.Columns[0].ColumnName = "活動ID";
                    dataTable.Columns[1].ColumnName = "活動名稱";
                    dataTable.Columns[2].ColumnName = "活動分類";
                    dataTable.Columns[3].ColumnName = "地區";

                    // 更新 DataGridView 並確保欄位順序
                    UpdateDataGridView(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }      

        private void btnEventsSearch_Click(object sender, EventArgs e)
        {
            LoadSearchResults();
        }

        private void LoadSearchResults()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;

                    // 取得使用者輸入的關鍵字
                    string keyword = txtEventName.Text.Trim();

                    // SQL 查詢 (模糊搜尋活動名稱)
                    string query = "SELECT e.[eventID], e.[name], et.[eventType], c.[cityName] " +
                                   "FROM [dbo].[Events] e " +
                                   "JOIN [dbo].[EventTypes] et ON e.[eventTypeID] = et.eventTypeID " +
                                   "JOIN [dbo].[cities] c ON e.cityID = c.cityID " +
                                   "WHERE e.[name] LIKE @Keyword";

                    command.CommandText = query;
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // 修改欄位名稱
                    dataTable.Columns[0].ColumnName = "活動ID";
                    dataTable.Columns[1].ColumnName = "活動名稱";
                    dataTable.Columns[2].ColumnName = "活動分類";
                    dataTable.Columns[3].ColumnName = "地區";

                    UpdateDataGridView(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            FrmEventDetails form = new FrmEventDetails(FormMode.Add);

            // 直接設定 `Owner` 為 `Form1`
            form.Owner = this.FindForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                loadEventsList(); // 重新載入活動列表
            }
        }

        private void dataGridViewEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewEvents.Columns["ModifyColumn"].Index)
            {
                int eventID = Convert.ToInt32(dataGridViewEvents.Rows[e.RowIndex].Cells["活動ID"].Value);
                FrmEventDetails form = new FrmEventDetails(FormMode.View, eventID);
                // 檢視 / 修改視窗按下【確定】後重新載入
                if (form.ShowDialog() == DialogResult.OK)
                {
                    loadEventsList(); // 重新載入活動列表
                    LoadBatchEventNames(); // 重新載入活動梯次頁籤的活動名稱的combobox
                }
            }

            if (e.ColumnIndex == dataGridViewEvents.Columns["DeleteColumn"].Index)
            {
                int eventID = Convert.ToInt32(dataGridViewEvents.Rows[e.RowIndex].Cells["活動ID"].Value);
                FrmEventDetails form = new FrmEventDetails(FormMode.Delete, eventID);
                // 刪除視窗按下【確定】後重新載入
                if (form.ShowDialog() == DialogResult.OK)
                {
                    loadEventsList();
                    LoadBatchEventNames();
                }
            }
        }

        private void btnBatchSearch_Click(object sender, EventArgs e)
        {
            string selectedEvent = comboBoxBatchEventName.SelectedItem.ToString();
            DateTime? startDate = dateTimePickerBatchStart.Value;
            DateTime? endDate = dateTimePickerBatchEnd.Value;

            // 若未選擇日期範圍，則設為 `null`
            if (startDate > endDate)
            {
                MessageBox.Show("起始日期不能大於結束日期！");
                return;
            }

            LoadEventBatches(selectedEvent, startDate, endDate);
        }

        private void dataGridViewBatchList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 取得點擊的行數
            int rowIndex = e.RowIndex;

            if (rowIndex < 0)
            {
                return; // 避免點擊到表頭出錯
            }

            // 取得活動梯次 ID
            int batchID = Convert.ToInt32(dataGridViewBatchList.Rows[rowIndex].Cells["活動梯次ID"].Value);

            // **檢視 / 編輯模式**
            if (e.ColumnIndex == dataGridViewBatchList.Columns["Edit"].Index)
            {
                FrmBatchDetails batchForm = new FrmBatchDetails(FormMode.View, batchID); // 確保傳遞 View 模式
                // 訂閱事件，確保更新
                batchForm.BatchUpdated += () =>
                {
                    LoadBatchEventNames(); // 重新載入活動梯次頁籤中活動名稱的Combobox
                    SetDefaultBatchDateRange(); // 重設預設的日期範圍
                };

                batchForm.Owner = this.FindForm();

                if (batchForm.ShowDialog() == DialogResult.OK)
                {
                    LoadEventBatches(); // 重新載入 DataGridView
                }
            }

            // **刪除模式**
            if (e.ColumnIndex == dataGridViewBatchList.Columns["Delete"].Index)
            {
                FrmBatchDetails batchForm = new FrmBatchDetails(FormMode.Delete, batchID);
                batchForm.BatchUpdated += () =>
                {
                    LoadBatchEventNames();
                    SetDefaultBatchDateRange();
                };

                batchForm.Owner = this.FindForm();

                if (batchForm.ShowDialog() == DialogResult.OK)
                {
                    LoadEventBatches(); // 重新載入 DataGridView
                }
            }
        }

        private void btnAddBatch_Click(object sender, EventArgs e)
        {
            // 創建 FrmBatchDetails 視窗，使用「新增模式」
            FrmBatchDetails batchForm = new FrmBatchDetails(FormMode.Add);

            batchForm.BatchUpdated += () =>
            {
                LoadBatchEventNames();
                SetDefaultBatchDateRange();
            };

            // 設定視窗的擁有者，避免開啟多個視窗
            batchForm.Owner = this.FindForm();

            // 顯示視窗
            if (batchForm.ShowDialog() == DialogResult.OK)
            {
                // 如果 DialogResult.OK，則重新載入 DataGridView
                LoadEventBatches();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void ReloadData()
        {
            if (tabControl1.SelectedTab == tabEvents)
            {
                loadEventsList();
            }
            else if (tabControl1.SelectedTab == tabBatches)
            {
                LoadBatchEventNames(); // 確保活動梯次頁籤中的活動名稱 ComboBox 會更新
                LoadEventBatches();
            }
        }

        private void dataGridViewEventTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // 避免點擊到表頭列錯誤

            // 取得選取的 `eventTypeID`
            int eventTypeID = Convert.ToInt32(dataGridViewEventTypes.Rows[e.RowIndex].Cells["活動類型ID"].Value);

            //「修改」按鈕被點擊
            if (e.ColumnIndex == dataGridViewEventTypes.Columns["ModifyColumn"].Index)
            {
                using (FrmEditEventType editForm = new FrmEditEventType(eventTypeID))
                {
                    // 確保使用者按下「確定」後才重新載入
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        loadEventTypes();
                    }
                }
            }

            //「刪除」按鈕被點擊
            if (e.ColumnIndex == dataGridViewEventTypes.Columns["DeleteColumn"].Index)
            {
                DialogResult confirm = MessageBox.Show("確定要刪除此活動分類嗎？", "確認刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(ConnectionString))
                        {
                            conn.Open();
                            string deleteQuery = "DELETE FROM [dbo].[EventTypes] WHERE eventTypeID = @EventTypeID";
                            SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                            cmd.Parameters.AddWithValue("@EventTypeID", eventTypeID);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("活動分類已刪除！");
                        loadEventTypes(); // 重新載入
                    }
                    catch (SqlException ex) when (ex.Number == 547) // 547 = 外鍵衝突
                    {
                        MessageBox.Show("無法刪除，因為該分類仍有活動關聯！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("刪除失敗：" + ex.Message);
                    }
                }
            }
        }

        private void btnAddEventType_Click(object sender, EventArgs e)
        {
            FrmInsertEventType insertForm = new FrmInsertEventType();

            if (insertForm.ShowDialog() == DialogResult.OK)
            {
                loadEventTypes(); // 重新載入活動分類列表
            }
        }
    }
}
