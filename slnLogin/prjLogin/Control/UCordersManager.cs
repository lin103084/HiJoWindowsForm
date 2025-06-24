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
using prjLogin.Properties;
using slnFriendshipBackEnd.Forms;
//using slnFriendshipBackEnd.Properties;

namespace slnFriendshipBackEnd.UserControls
{
    public partial class UCordersManager : UserControl
    {
        string ConnectionString = Settings.Default.PCR7FriendshipConnectionString;
        public UCordersManager()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            LoadOrderStatuses();
            LoadPaymentTypes();

            LoadOrders();
            LoadFilterOptions();
        }

        private void LoadOrders()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // SQL 查詢，透過 JOIN 取得訂單資訊
                    string query = @"
                SELECT 
                    o.orderID AS '訂單 ID',
                    o.memberID AS '會員 ID',
                    m.userName AS '會員名稱',
                    r.Name AS '會員等級',  -- 新增會員等級
                    e.name AS '活動名稱',
                    b.eventStartDate AS '活動開始日期',
                    o.orderDate AS '訂單成立時間',
                    p.paymentType AS '付款方式',
                    o.totalPrice AS '訂單金額',
                    os.orderStatus AS '訂單狀態'
                FROM Orders o
                JOIN Members m ON o.memberID = m.ID
                JOIN memberRoles mr ON m.ID = mr.memberID  -- 取得會員角色
                JOIN roles r ON mr.roleID = r.ID              -- 取得會員等級
                JOIN Batches b ON o.batchID = b.batchID
                JOIN Events e ON b.eventID = e.eventID
                JOIN PaymentTypes p ON o.paymentTypeID = p.paymentTypeID
                JOIN OrderStatuses os ON o.orderStatusID = os.orderStatusID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // 設定 DataGridView 資料來源
                    dataGridViewOrders.DataSource = dataTable;

                    // 確保不重複加入「修改」與「刪除」按鈕
                    if (dataGridViewOrders.Columns["Edit"] == null)
                    {
                        DataGridViewLinkColumn editColumn = new DataGridViewLinkColumn
                        {
                            Name = "Edit",
                            HeaderText = "",
                            Text = "檢視 / 修改",
                            UseColumnTextForLinkValue = true
                        };
                        dataGridViewOrders.Columns.Add(editColumn);
                    }

                    if (dataGridViewOrders.Columns["Delete"] == null)
                    {
                        DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                        {
                            Name = "Delete",
                            HeaderText = "刪除",
                            Text = "－",
                            UseColumnTextForButtonValue = true
                        };
                        dataGridViewOrders.Columns.Add(deleteColumn);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入訂單列表失敗：" + ex.Message);
            }
        }

        private void LoadPaymentTypes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM PaymentTypes"; // 讀取 PaymentTypes 資料表
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // 設定 DataGridView 資料來源
                    dataGridViewPaymentTypes.DataSource = dataTable;

                    // 修改標題欄位名稱
                    dataGridViewPaymentTypes.Columns["paymentTypeID"].HeaderText = "付款方式 ID";
                    dataGridViewPaymentTypes.Columns["paymentType"].HeaderText = "付款方式";

                    // 確保不重複加入「修改」與「刪除」按鈕
                    if (dataGridViewPaymentTypes.Columns["Edit"] == null)
                    {
                        DataGridViewLinkColumn editColumn = new DataGridViewLinkColumn
                        {
                            Name = "Edit",
                            HeaderText = "",
                            Text = "修改",
                            UseColumnTextForLinkValue = true
                        };
                        dataGridViewPaymentTypes.Columns.Add(editColumn);
                    }

                    if (dataGridViewPaymentTypes.Columns["Delete"] == null)
                    {
                        DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                        {
                            Name = "Delete",
                            HeaderText = "刪除",
                            Text = "－",
                            UseColumnTextForButtonValue = true
                        };
                        dataGridViewPaymentTypes.Columns.Add(deleteColumn);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入付款方式列表失敗：" + ex.Message);
            }
        }

        private void LoadOrderStatuses()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM OrderStatuses"; // 讀取 OrderStatuses 資料表
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // 設定 DataGridView 資料來源
                    dataGridViewOrderStatuses.DataSource = dataTable;

                    // 修改標題欄位名稱
                    dataGridViewOrderStatuses.Columns["orderStatusID"].HeaderText = "訂單狀態 ID";
                    dataGridViewOrderStatuses.Columns["orderStatus"].HeaderText = "訂單狀態";

                    // 確保不重複加入「修改」與「刪除」按鈕
                    if (dataGridViewOrderStatuses.Columns["Edit"] == null)
                    {
                        DataGridViewLinkColumn editColumn = new DataGridViewLinkColumn
                        {
                            Name = "Edit",
                            HeaderText = "",
                            Text = "修改",
                            UseColumnTextForLinkValue = true
                        };
                        dataGridViewOrderStatuses.Columns.Add(editColumn);
                    }

                    if (dataGridViewOrderStatuses.Columns["Delete"] == null)
                    {
                        DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                        {
                            Name = "Delete",
                            HeaderText = "刪除",
                            Text = "－",
                            UseColumnTextForButtonValue = true
                        };
                        dataGridViewOrderStatuses.Columns.Add(deleteColumn);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入訂單狀態列表失敗：" + ex.Message);
            }
        }

        private void btnAddOrderStatus_Click(object sender, EventArgs e)
        {
            FrmOrderStatus form = new FrmOrderStatus(LoadOrderStatuses);
            form.Text = "新增一個訂單狀態";
            form.ShowDialog();
        }

        private void btnAddPaymentType_Click(object sender, EventArgs e)
        {
            FrmPaymentTypes form = new FrmPaymentTypes(LoadPaymentTypes);
            form.Text = "新增一個付款方式";
            form.ShowDialog();
        }

        private void dataGridViewOrderStatuses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewOrderStatuses.Columns["Edit"].Index)
            {
                int orderStatusID = Convert.ToInt32(dataGridViewOrderStatuses.Rows[e.RowIndex].Cells["orderStatusID"].Value);
                string orderStatus = dataGridViewOrderStatuses.Rows[e.RowIndex].Cells["orderStatus"].Value.ToString();

                FrmOrderStatus form = new FrmOrderStatus(LoadOrderStatuses, orderStatusID, orderStatus);
                form.Text = "修改訂單狀態名稱";
                form.ShowDialog();
            }
            else if (e.ColumnIndex == dataGridViewOrderStatuses.Columns["Delete"].Index)
            {
                int orderStatusID = Convert.ToInt32(dataGridViewOrderStatuses.Rows[e.RowIndex].Cells["orderStatusID"].Value);

                // 確認刪除
                var result = MessageBox.Show("確定要刪除此訂單狀態嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(ConnectionString))
                        {
                            conn.Open();
                            string query = "DELETE FROM OrderStatuses WHERE orderStatusID = @OrderStatusID";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@OrderStatusID", orderStatusID);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("刪除成功！");
                        LoadOrderStatuses(); // 重新載入 DataGridView
                    }
                    catch (SqlException ex) when (ex.Number == 547) // FK關聯錯誤
                    {
                        MessageBox.Show("無法刪除，因為有訂單正在使用此訂單狀態，如需刪除此訂單狀態，請先修改其所屬訂單之訂單狀態。");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("刪除失敗：" + ex.Message);
                    }
                }
            }
        }

        private void dataGridViewPaymentTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewPaymentTypes.Columns["Edit"].Index)
            {
                int paymentTypeID = Convert.ToInt32(dataGridViewPaymentTypes.Rows[e.RowIndex].Cells["paymentTypeID"].Value);
                string paymentType = dataGridViewPaymentTypes.Rows[e.RowIndex].Cells["paymentType"].Value.ToString();

                FrmPaymentTypes form = new FrmPaymentTypes(LoadPaymentTypes, paymentTypeID, paymentType);
                form.Text = "修改付款方式名稱";
                form.ShowDialog();
            }
            else if (e.ColumnIndex == dataGridViewPaymentTypes.Columns["Delete"].Index)
            {
                int paymentTypeID = Convert.ToInt32(dataGridViewPaymentTypes.Rows[e.RowIndex].Cells["paymentTypeID"].Value);

                // 確認刪除
                var result = MessageBox.Show("確定要刪除此付款方式嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(ConnectionString))
                        {
                            conn.Open();
                            string query = "DELETE FROM PaymentTypes WHERE paymentTypeID = @PaymentTypeID";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@PaymentTypeID", paymentTypeID);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("刪除成功！");
                        LoadPaymentTypes(); // 重新載入 DataGridView
                    }
                    catch (SqlException ex) when (ex.Number == 547) // FK關聯錯誤
                    {
                        MessageBox.Show("無法刪除，因為有訂單正在使用此付款方式，如需刪除此付款方式，請先修改其所屬訂單的付款方式。");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("刪除失敗：" + ex.Message);
                    }
                }
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            FrmOrderDetails form = new FrmOrderDetails(); // 不傳入orderID
            form.Text = "模擬前台新增訂單";

            if (form.ShowDialog() == DialogResult.OK)
            {
                ClearFilters(); // 清空搜尋條件
                LoadOrders(); // 重新載入 DataGridView
            }
        }

        private void dataGridViewOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewOrders.Columns["Edit"].Index)
            {
                int orderID = Convert.ToInt32(dataGridViewOrders.Rows[e.RowIndex].Cells["訂單 ID"].Value);

                FrmOrderDetails form = new FrmOrderDetails(orderID, false); // 檢視模式
                form.Text = "檢視 / 修改 訂單";

                if (form.ShowDialog() == DialogResult.OK) // 當視窗關閉後，執行清空篩選條件
                {
                    ClearFilters(); // 清空搜尋條件
                    LoadOrders();   // 重新載入訂單
                }
            }
            else if (e.ColumnIndex == dataGridViewOrders.Columns["Delete"].Index)
            {
                int orderID = Convert.ToInt32(dataGridViewOrders.Rows[e.RowIndex].Cells["訂單 ID"].Value);

                FrmOrderDetails form = new FrmOrderDetails(orderID, false, true); // 進入刪除模式
                form.Text = "刪除訂單";

                if (form.ShowDialog() == DialogResult.OK) // 當視窗關閉後，執行清空篩選條件
                {
                    ClearFilters(); // 清空搜尋條件
                    LoadOrders();   // 重新載入訂單
                }
            }
        }

        private void ClearFilters()
        {
            txtOrderID.Clear();
            txtMemberIDOrName.Clear();
            comboBoxEvent.SelectedIndex = -1;
            comboBoxBatch.SelectedIndex = -1;
            comboBoxOrderStatus.SelectedIndex = -1;
            comboBoxPaymentType.SelectedIndex = -1;
            txtTotalPriceMin.Clear();
            txtTotalPriceMax.Clear();

            // 設定訂單日期範圍為資料庫最早 ~ 最晚
            SetOrderDateRange();
        }

        // 設定訂單日期範圍為資料庫最早 ~ 最晚
        private void SetOrderDateRange()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string dateQuery = "SELECT MIN(orderDate) AS EarliestDate, MAX(orderDate) AS LatestDate FROM Orders";
                SqlCommand dateCmd = new SqlCommand(dateQuery, conn);
                SqlDataReader dateReader = dateCmd.ExecuteReader();

                if (dateReader.Read())
                {
                    if (dateReader["EarliestDate"] != DBNull.Value && dateReader["LatestDate"] != DBNull.Value)
                    {
                        dtpOrderDateStart.Value = Convert.ToDateTime(dateReader["EarliestDate"]);
                        dtpOrderDateEnd.Value = Convert.ToDateTime(dateReader["LatestDate"]);
                    }
                }
                dateReader.Close();
            }
        }

        private void LoadFilterOptions()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                // 查詢訂單最早 & 最晚成立時間
                string dateQuery = "SELECT MIN(orderDate) AS EarliestDate, MAX(orderDate) AS LatestDate FROM Orders";
                SqlCommand dateCmd = new SqlCommand(dateQuery, conn);
                SqlDataReader dateReader = dateCmd.ExecuteReader();

                if (dateReader.Read())
                {
                    if (dateReader["EarliestDate"] != DBNull.Value && dateReader["LatestDate"] != DBNull.Value)
                    {
                        dtpOrderDateStart.Value = Convert.ToDateTime(dateReader["EarliestDate"]);
                        dtpOrderDateEnd.Value = Convert.ToDateTime(dateReader["LatestDate"]);
                    }
                }
                dateReader.Close();

                // 載入活動 (Events)
                string eventQuery = "SELECT eventID, name FROM Events";
                SqlDataAdapter eventAdapter = new SqlDataAdapter(eventQuery, conn);
                DataTable eventTable = new DataTable();
                eventAdapter.Fill(eventTable);
                comboBoxEvent.DataSource = eventTable;
                comboBoxEvent.DisplayMember = "name";
                comboBoxEvent.ValueMember = "eventID";
                comboBoxEvent.SelectedIndex = -1;

                // 載入訂單狀態 (OrderStatuses)
                string statusQuery = "SELECT orderStatusID, orderStatus FROM OrderStatuses";
                SqlDataAdapter statusAdapter = new SqlDataAdapter(statusQuery, conn);
                DataTable statusTable = new DataTable();
                statusAdapter.Fill(statusTable);
                comboBoxOrderStatus.DataSource = statusTable;
                comboBoxOrderStatus.DisplayMember = "orderStatus";
                comboBoxOrderStatus.ValueMember = "orderStatusID";
                comboBoxOrderStatus.SelectedIndex = -1;

                // 載入付款方式 (PaymentTypes)
                string paymentQuery = "SELECT paymentTypeID, paymentType FROM PaymentTypes";
                SqlDataAdapter paymentAdapter = new SqlDataAdapter(paymentQuery, conn);
                DataTable paymentTable = new DataTable();
                paymentAdapter.Fill(paymentTable);
                comboBoxPaymentType.DataSource = paymentTable;
                comboBoxPaymentType.DisplayMember = "paymentType";
                comboBoxPaymentType.ValueMember = "paymentTypeID";
                comboBoxPaymentType.SelectedIndex = -1;
            }
        }

        private void comboBoxEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEvent.Text == "")
            {
                comboBoxEvent.SelectedIndex = -1;
            }

            if (comboBoxEvent.SelectedValue != null && int.TryParse(comboBoxEvent.SelectedValue.ToString(), out int eventID))
            {
                LoadBatches(eventID);
            }
        }

        private void LoadBatches(int eventID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT batchID, eventStartDate FROM Batches WHERE eventID = @eventID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@eventID", eventID);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count == 0)
                {
                    // 無對應活動梯次時，顯示警告並清空 ComboBox
                    comboBoxBatch.DataSource = null;
                    comboBoxBatch.Enabled = false;
                    MessageBox.Show("該活動沒有對應的活動梯次！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    comboBoxBatch.DataSource = dataTable;
                    comboBoxBatch.DisplayMember = "eventStartDate";
                    comboBoxBatch.ValueMember = "batchID";
                    comboBoxBatch.Enabled = true;
                    comboBoxBatch.SelectedIndex = -1; // 預設不選擇
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                // 建立查詢條件 (WHERE)
                List<string> conditions = new List<string>();

                // 訂單ID
                if (!string.IsNullOrWhiteSpace(txtOrderID.Text))
                {
                    conditions.Add("o.orderID = @OrderID");
                }

                // 會員ID 或 會員名稱
                if (!string.IsNullOrWhiteSpace(txtMemberIDOrName.Text))
                {
                    if (txtMemberIDOrName.Text.All(char.IsDigit)) // 輸入為純數字 -> 視為查詢會員ID（精準比對）
                    {
                        conditions.Add("o.memberID = @MemberID");
                    }
                    else // 輸入含有其他字元 -> 視為查詢會員名稱（模糊搜尋）
                    {
                        conditions.Add("m.userName LIKE @MemberName");
                    }
                }

                // 活動
                if (comboBoxEvent.SelectedIndex != -1)
                {
                    conditions.Add("e.eventID = @EventID");
                }

                // 活動梯次
                if (comboBoxBatch.SelectedIndex != -1)
                {
                    conditions.Add("b.batchID = @BatchID");
                }

                // 訂單狀態
                if (comboBoxOrderStatus.SelectedIndex != -1)
                {
                    conditions.Add("os.orderStatusID = @OrderStatusID");
                }

                // 付款方式
                if (comboBoxPaymentType.SelectedIndex != -1)
                {
                    conditions.Add("p.paymentTypeID = @PaymentTypeID");
                }

                // 訂單成立日期範圍
                conditions.Add("o.orderDate BETWEEN @StartDate AND @EndDate");

                // 訂單金額範圍
                if (!string.IsNullOrWhiteSpace(txtTotalPriceMin.Text) && !string.IsNullOrWhiteSpace(txtTotalPriceMax.Text))
                {
                    conditions.Add("o.totalPrice BETWEEN @MinPrice AND @MaxPrice");
                }

                // 組合查詢條件成SQL語法
                string query = @"
        SELECT 
            o.orderID AS '訂單 ID',
            o.memberID AS '會員 ID',
            m.userName AS '會員名稱',
            r.Name AS '會員等級',
            e.name AS '活動名稱',
            b.eventStartDate AS '活動開始日期',
            o.orderDate AS '訂單成立時間',
            p.paymentType AS '付款方式',
            o.totalPrice AS '訂單金額',
            os.orderStatus AS '訂單狀態'
        FROM Orders o
        JOIN Members m ON o.memberID = m.ID
        JOIN memberRoles mr ON m.ID = mr.memberID
        JOIN roles r ON mr.roleID = r.ID
        JOIN Batches b ON o.batchID = b.batchID
        JOIN Events e ON b.eventID = e.eventID
        JOIN PaymentTypes p ON o.paymentTypeID = p.paymentTypeID
        JOIN OrderStatuses os ON o.orderStatusID = os.orderStatusID
        " + (conditions.Count > 0 ? " WHERE " + string.Join(" AND ", conditions) : "");

                SqlCommand cmd = new SqlCommand(query, conn);

                // 設定參數
                if (!string.IsNullOrWhiteSpace(txtOrderID.Text))
                {
                    cmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text);
                }
                if (!string.IsNullOrWhiteSpace(txtMemberIDOrName.Text))
                {
                    if (txtMemberIDOrName.Text.All(char.IsDigit))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", txtMemberIDOrName.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MemberName", "%" + txtMemberIDOrName.Text + "%");
                    }
                }
                if (comboBoxEvent.SelectedIndex != -1)
                {
                    cmd.Parameters.AddWithValue("@EventID", comboBoxEvent.SelectedValue);
                }
                if (comboBoxBatch.SelectedIndex != -1)
                {
                    cmd.Parameters.AddWithValue("@BatchID", comboBoxBatch.SelectedValue);
                }
                if (comboBoxOrderStatus.SelectedIndex != -1)
                {
                    cmd.Parameters.AddWithValue("@OrderStatusID", comboBoxOrderStatus.SelectedValue);
                }
                if (comboBoxPaymentType.SelectedIndex != -1)
                {
                    cmd.Parameters.AddWithValue("@PaymentTypeID", comboBoxPaymentType.SelectedValue);
                }
                cmd.Parameters.AddWithValue("@StartDate", dtpOrderDateStart.Value);
                cmd.Parameters.AddWithValue("@EndDate", dtpOrderDateEnd.Value);

                if (!string.IsNullOrWhiteSpace(txtTotalPriceMin.Text) && !string.IsNullOrWhiteSpace(txtTotalPriceMax.Text))
                {
                    cmd.Parameters.AddWithValue("@MinPrice", decimal.Parse(txtTotalPriceMin.Text));
                    cmd.Parameters.AddWithValue("@MaxPrice", decimal.Parse(txtTotalPriceMax.Text));
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // 根據搜尋條件更新 DataGridView
                dataGridViewOrders.DataSource = dataTable;

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("未找到符合條件的訂單", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void comboBoxBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBatch.Text == "")
            {
                comboBoxBatch.SelectedIndex = -1;
            }
        }

        private void comboBoxOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOrderStatus.Text == "")
            {
                comboBoxOrderStatus.SelectedIndex = -1;
            }
        }

        private void comboBoxPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPaymentType.Text == "")
            {
                comboBoxPaymentType.SelectedIndex = -1;
            }
        }

        // 【訂單管理】中不同的頁籤切換，刷新資料
        private void tabControlOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadOrdersData();
        }

        private void ReloadOrdersData()
        {
            if (tabControlOrders.SelectedTab == null)
                return; // 防止 `SelectedTab` 為 null

            if (tabControlOrders.SelectedTab == tabOrderStatusPaymentTypes)
            {
                LoadOrderStatuses();// 重新載入「訂單狀態」
                LoadPaymentTypes(); // 重新載入「付款方式」            
            }
            else if (tabControlOrders.SelectedTab == tabOrders)
            {
                LoadOrders(); // 重新載入「訂單列表」
                ReloadComboBoxes();　// 重新搜尋條件的ComboBoxes（訂單狀態、付款方式）
            }
        }

        private void ReloadComboBoxes()
        {
            // 重新載入 訂單狀態(OrderStatus)
    using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT orderStatusID, orderStatus FROM OrderStatuses";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                comboBoxOrderStatus.DataSource = null; // 先清除原本的 DataSource
                comboBoxOrderStatus.DataSource = dataTable;
                comboBoxOrderStatus.DisplayMember = "orderStatus";
                comboBoxOrderStatus.ValueMember = "orderStatusID";
                comboBoxOrderStatus.SelectedIndex = -1; // 預設不選擇
            }

            // 重新載入 付款方式 (PaymentType)
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT paymentTypeID, paymentType FROM PaymentTypes";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                comboBoxPaymentType.DataSource = null; // 先清除原本的 DataSource
                comboBoxPaymentType.DataSource = dataTable;
                comboBoxPaymentType.DisplayMember = "paymentType";
                comboBoxPaymentType.ValueMember = "paymentTypeID";
                comboBoxPaymentType.SelectedIndex = -1; // 預設不選擇
            }
        }
    }
}
