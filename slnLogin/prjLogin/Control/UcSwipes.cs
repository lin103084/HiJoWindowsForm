using prjLogin.fsDataSetTableAdapters;
using prjLogin.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slnFriendshipBackEnd.match
{
    public partial class UcSwipes : UserControl
    {
        
        private string connectionString = Settings.Default.PCR7FriendshipConnectionString; // 你的資料庫連線字串
        
        swipesTableAdapter swipes1TableAdapter1 = new swipesTableAdapter();
        
       
        public UcSwipes()
        {
            InitializeComponent();
            //建構子 程式開啟自動寫入資料
            swipLoadData();
            loadswipestocombox1();
           //固定使用者控制項位置
            this.Dock = DockStyle.Fill;
            this.swipTextBox3.TextChanged += TextBoxFilterChanged;
            this.swipTextBox4.TextChanged += TextBoxFilterChanged;
            this.swipTextBox3.TextChanged += SwipTextBox3_TextChanged;
            this.AutoScroll = true;
            // 綁定 TextBox 事件
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.MinimumSize = new Size(300, 200);
            
            
            this.swipDataGridview1.EnableHeadersVisualStyles = false; // 需關閉預設樣式
            this.swipDataGridview1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue; // 設定背景顏色
        }


        private void swipLoadData()
        {
           

            string query = @"
            SELECT 
            s.ID, 
            s.swiperID, 
            m1.userName AS swiperName, 
            s.targetID, 
            m2.userName AS targetName, 
            s.swipesAction, 
            s.creaTime
            FROM swipes s
            LEFT JOIN members m1 ON s.swiperID = m1.ID
            LEFT JOIN members m2 ON s.targetID = m2.ID
            ORDER BY s.ID ASC;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // 設定 DataGridView 資料來源
                this.swipDataGridview1.DataSource = dt;
                //調整欄位寬度
                this.swipDataGridview1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //欄位置中
                this.swipDataGridview1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.swipDataGridview1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // 確保顯示順序
                this.swipDataGridview1.Columns["ID"].DisplayIndex = 0;           // **ID 在最前面**
                this.swipDataGridview1.Columns["swiperID"].DisplayIndex = 1;
                this.swipDataGridview1.Columns["swiperName"].DisplayIndex = 2;   // **swiper 名稱**
                this.swipDataGridview1.Columns["targetID"].DisplayIndex = 3;
                this.swipDataGridview1.Columns["targetName"].DisplayIndex = 4;   // **target 名稱**
                this.swipDataGridview1.Columns["swipesAction"].DisplayIndex = 5;
                this.swipDataGridview1.Columns["creaTime"].DisplayIndex = 6;
                // 修改 DataGridView 欄位標題3/18
                this.swipDataGridview1.Columns["ID"].HeaderText = "滑動編號";
                this.swipDataGridview1.Columns["swiperID"].HeaderText = "滑動者 ID";
                this.swipDataGridview1.Columns["swiperName"].HeaderText = "滑動者名稱";
                this.swipDataGridview1.Columns["targetID"].HeaderText = "被滑動者 ID";
                this.swipDataGridview1.Columns["targetName"].HeaderText = "被滑動者名稱";
                this.swipDataGridview1.Columns["swipesAction"].HeaderText = "滑動狀態";
                this.swipDataGridview1.Columns["creaTime"].HeaderText = "建立時間";
               
            }
           

        }
        
        private void swipButton4_Click(object sender, EventArgs e)
        {
            swipLoadData();
            swipAnchor1();
        }
        private void swipAnchor1()
        {
            //將更新後的資料綁定在事件結束欄位
            this.swipDataGridview1.FirstDisplayedScrollingRowIndex = swipDataGridview1.Rows.Count - 1;
            this.swipDataGridview1.CurrentCell = swipDataGridview1.Rows[swipDataGridview1.Rows.Count - 1].Cells[0];
        }

        private void swipTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void loadswipestocombox1()
        {
            SqlConnection conn = new SqlConnection(Settings.Default.PCR7FriendshipConnectionString);
            conn.Open();
            //string query = "select distinct swipesAction from swipes"; 
            string query = @"
                SELECT DISTINCT m.actionID, m.actionName 
                FROM swipes s
                JOIN matchType m ON s.swipesAction = m.actionID";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable swipComBoxTable = new DataTable();

            adapter.Fill(swipComBoxTable);

            //  塞進combo box綁定資料到 ComboBox
            this.swipComboBox1.DataSource = swipComBoxTable;
            this.swipComboBox1.DisplayMember = "actionName"; // 顯示 matchType.actionName (e.g., dislike, like, superlike)
            this.swipComboBox1.ValueMember = "actionID";     // 儲存 actionID (e.g., 0, 1, 2)
            this.swipComboBox1.SelectedIndex = 0;           // 預設不選取任何項目
            // 顯示 ComboBox 的名稱與值

        }

        private void swipComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }



        private void swipButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int swipUserID1 = int.Parse(this.swipTextBox1.Text);
                int swipUserID2 = int.Parse(this.swipTextBox2.Text);

                // 取得選擇的 actionID
                int swiAction = Convert.ToInt32(swipComboBox1.SelectedValue);

                DateTime todayNow = DateTime.Now;

                // 插入資料
                this.swipes1TableAdapter1.Insert(swipUserID1, swipUserID2, swiAction, todayNow);

                // 成功插入後，顯示訊息
                MessageBox.Show("新增成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("請輸入正確的數字格式！\n" + ex.Message, "格式錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("資料庫錯誤！\n" + ex.Message, "SQL 錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生未知錯誤！\n" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 資料重新顯示
            swipLoadData();
            swipAnchor1();
        }



        private void swipButton2_Click(object sender, EventArgs e)
        {
            if (this.swipDataGridview1.CurrentRow != null) // 確保有選取行
            {
                try
                {
                    // 取得當前選取的行
                    DataGridViewRow selectedRow = swipDataGridview1.CurrentRow;

                    // 檢查是否修改了 swiperName 或 targetName 欄位
                    if (swipDataGridview1.CurrentCell.ColumnIndex == selectedRow.Cells["swiperName"].ColumnIndex ||
                        swipDataGridview1.CurrentCell.ColumnIndex == selectedRow.Cells["targetName"].ColumnIndex)
                    {
                        MessageBox.Show("無法直接修改 swiperName 或 targetName！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        swipLoadData(); // 重新載入資料，取消變更
                        return; // 直接返回，避免執行後續的更新程式
                    }

                    // 取得需要更新的資料
                    int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                    int swiperID = Convert.ToInt32(selectedRow.Cells["swiperID"].Value);
                    int targetID = Convert.ToInt32(selectedRow.Cells["targetID"].Value);
                    int swipesAction = Convert.ToInt32(selectedRow.Cells["swipesAction"].Value);

                    // 更新資料庫
                    bool success = UpdateRowInDatabase(id, swiperID, targetID, swipesAction);

                    if (success)
                    {
                        MessageBox.Show("更新成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        swipLoadData(); //  重新載入 DataGridView，確保資料同步
                    }
                    else
                    {
                        MessageBox.Show("更新失敗，請檢查資料", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("更新時發生錯誤！\n" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("請選擇要更新的資料列！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            swipAnchor1(); // 維持滾動位置


        }
        private bool UpdateRowInDatabase(int id, int swiperID, int targetID, int swipesAction)
        {
            string connectionString = Settings.Default.PCR7FriendshipConnectionString  ; // 資料庫連線字串
            string query = @"
        UPDATE swipes 
        SET swiperID = @swiperID, targetID = @targetID, swipesAction = @swipesAction
        WHERE ID = @ID";  //  確保更新 ID 對應的資料

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@swiperID", swiperID);
                    cmd.Parameters.AddWithValue("@targetID", targetID);
                    cmd.Parameters.AddWithValue("@swipesAction", swipesAction);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    return rowsAffected > 0;  //  回傳是否成功更新
                }
            }

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // 確保點擊的是刪除按鈕，而不是其他欄位
            if (e.RowIndex >= 0 && swipDataGridview1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                // 取得該列的 ID
                int id = Convert.ToInt32(swipDataGridview1.Rows[e.RowIndex].Cells["ID"].Value);

                // 確認刪除
                DialogResult result = MessageBox.Show("確定要刪除這筆資料嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // 刪除資料庫資料
                    this.swipDeleteRowFromDatabase(id);

                    // 從 DataGridView 移除該列
                    this.swipDataGridview1.Rows.RemoveAt(e.RowIndex);
                }
            }

        }

        private void swipDeleteRowFromDatabase(int id)
        {
            //string connectionString = Settings.Default.PCR7FriendshipConnectionString; // 資料庫連線字串

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM swipes WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        private void TextBoxFilterChanged(object sender, EventArgs e)
        {
            // 取得當前輸入的 swiperID 和 targetID
            string swiperID = swipTextBox3.Text.Trim();
            string targetID = swipTextBox4.Text.Trim();

            // 創建篩選條件
            string filter = "";

            if (!string.IsNullOrEmpty(swiperID))
            {
                filter += $"swiperID = {swiperID}";
            }
            if (!string.IsNullOrEmpty(targetID))
            {
                if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                filter += $"targetID = {targetID}";
            }

            // 進行篩選
            (this.swipDataGridview1.DataSource as DataTable).DefaultView.RowFilter = filter;

            // 當 TextBox 清空時恢復所有資料
            if (string.IsNullOrEmpty(swiperID) && string.IsNullOrEmpty(targetID))
            {
                (this.swipDataGridview1.DataSource as DataTable).DefaultView.RowFilter = "";
            }
        }
        private void SwipTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(swipTextBox3.Text, out int swiperID))
            {
                LoadUserImage(swiperID);
            }
            else
            {
                swipPictureBox1.Image = null; // 如果輸入不是數字，就清空圖片
            }
        }

        private void LoadUserImage(int swiperID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT avatarPath FROM members WHERE ID = @swiperID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@swiperID", swiperID);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            string avatarPath = result.ToString();
                            string fullImagePath = Path.Combine("..", "..", avatarPath);

                            if (File.Exists(fullImagePath))
                            {
                                swipPictureBox1.Image = Image.FromFile(fullImagePath);
                            }
                            else
                            {
                                swipPictureBox1.Image = null;
                                MessageBox.Show("找不到圖片路徑: " + fullImagePath, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            swipPictureBox1.Image = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入圖片失敗: " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

    }
}