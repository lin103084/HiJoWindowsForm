using prjLogin.Properties;
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

namespace slnFriendshipBackEnd.Forms
{
    public partial class FrmOrderDetails : Form
    {
        string ConnectionString = Settings.Default.PCR7FriendshipConnectionString;
        private int _orderID;
        private bool _isEditingStatus; // 是否允許修改訂單狀態
        private bool _isDeleting;
        private Timer memberSearchTimer;

        public FrmOrderDetails()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeMemberSearchTimer(); // 初始化計時器
            _orderID = -1; // 表示新增模式
            ConfigureForNewOrder();

            LoadEvents();
            LoadPaymentTypes();
            LoadOrderStatuses();
        }

        private void MemberSearchTimer_Tick(object sender, EventArgs e)
        {
            memberSearchTimer.Stop(); // 停止 Timer，避免重複執行

            if (memberSearchTimer.Tag.ToString() == "ID")
            {
                if (int.TryParse(txtMemberID.Text, out int memberID))
                {
                    LoadMemberData(memberID);
                }
            }
            else if (memberSearchTimer.Tag.ToString() == "Name")
            {
                LoadMemberDataByName(txtMemberName.Text);
            }
        }

        private void LoadMemberDataByName(string memberName)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT m.ID, r.Name FROM Members m JOIN memberRoles mr ON m.ID = mr.memberID JOIN roles r ON mr.roleID = r.ID WHERE m.userName = @userName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userName", memberName);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtMemberID.Text = reader["ID"].ToString();
                    txtMemberRole.Text = reader["Name"].ToString();
                }
                else
                {
                    // 先檢查是否已經是空的，避免 MessageBox.Show() 觸發兩次
                    if (!string.IsNullOrEmpty(txtMemberID.Text) || !string.IsNullOrEmpty(txtMemberName.Text))
                    {
                        txtMemberID.Clear();
                        txtMemberName.Clear();
                        txtMemberRole.Clear();
                        MessageBox.Show("無此會員，請重新輸入！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ConfigureForNewOrder()
        {
            txtOrderID.Text = "(系統自動生成)";
            txtOrderID.ReadOnly = true;
            txtMemberID.ReadOnly = false;
            txtMemberName.ReadOnly = false;
            txtMemberRole.ReadOnly = true;

            comboBoxEvent.Enabled = true;
            comboBoxBatch.Enabled = true;

            dtpOrderDateTime.Format = DateTimePickerFormat.Custom;
            dtpOrderDateTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpOrderDateTime.Enabled = false;

            comboBoxPaymentType.Enabled = true;
            txtTotalPrice.ReadOnly = false;

            comboBoxOrderStatus.Enabled = true;  // 讓訂單狀態可編輯

            btnUpdateOrderStatus.Visible = false;
            btnModifyOrderStatus.Visible = false;
            btnDelete.Visible = false;
            btnAddOrder.Visible = true;
        }

        public FrmOrderDetails(int orderID, bool isEditingStatus = false, bool isDeleting = false)
        {
            InitializeComponent();
            InitializeMemberSearchTimer(); // 初始化計時器
            _orderID = orderID;
            _isEditingStatus = isEditingStatus;
            _isDeleting = isDeleting;

            LoadOrderDetails();

            if (_isDeleting)
            {
                ConfigureForDeleteMode(); // 進入刪除模式
            }
            else
            {
                ConfigureFormMode(); // 檢視或修改模式
            }
        }


        private void InitializeMemberSearchTimer()
        {
            memberSearchTimer = new Timer();
            memberSearchTimer.Interval = 1000; // 1秒延遲搜尋
            memberSearchTimer.Tick += MemberSearchTimer_Tick;
        }

        private void ConfigureFormMode()
        {
            if (!_isEditingStatus) // 檢視模式
            {
                txtOrderID.ReadOnly = true;
                txtMemberID.ReadOnly = true;
                txtMemberName.ReadOnly = true;
                txtMemberRole.ReadOnly = true;

                comboBoxEvent.Enabled = false;
                comboBoxBatch.Enabled = false;
                dtpOrderDateTime.Format = DateTimePickerFormat.Custom;
                dtpOrderDateTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                dtpOrderDateTime.Enabled = false;
                comboBoxPaymentType.Enabled = false;
                txtTotalPrice.ReadOnly = true;
                comboBoxOrderStatus.Enabled = false;

                btnUpdateOrderStatus.Visible = false;
                btnModifyOrderStatus.Visible = true;  // 顯示「修改訂單狀態」按鈕
                btnDelete.Visible = false;
                btnAddOrder.Visible = false;
            }
            else // 允許修改訂單狀態
            {
                comboBoxOrderStatus.Enabled = true; // 只有訂單狀態可以編輯
                btnUpdateOrderStatus.Visible = true;
                btnModifyOrderStatus.Visible = false;
            }
        }

        private void ConfigureForDeleteMode()
        {
            txtOrderID.ReadOnly = true;
            txtMemberID.ReadOnly = true;
            txtMemberName.ReadOnly = true;
            txtMemberRole.ReadOnly = true;
            txtTotalPrice.ReadOnly = true;

            comboBoxEvent.Enabled = false;
            comboBoxBatch.Enabled = false;
            dtpOrderDateTime.Format = DateTimePickerFormat.Custom;
            dtpOrderDateTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpOrderDateTime.Enabled = false;
            comboBoxPaymentType.Enabled = false;
            comboBoxOrderStatus.Enabled = false;

            // 只顯示「刪除」與「取消」按鈕
            btnDelete.Visible = true;
            btnCancel.Visible = true;

            btnModifyOrderStatus.Visible = false;
            btnUpdateOrderStatus.Visible = false;
            btnAddOrder.Visible = false;
        }

        private void LoadOrderDetails()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
            SELECT o.orderID, o.memberID, m.userName, r.Name AS memberRole,
                   e.eventID, e.name AS eventName, b.batchID, b.eventStartDate, 
                   o.orderDate, p.paymentTypeID, p.paymentType, 
                   o.totalPrice, os.orderStatusID, os.orderStatus
            FROM Orders o
            JOIN Members m ON o.memberID = m.ID
            JOIN memberRoles mr ON m.ID = mr.memberID
            JOIN roles r ON mr.roleID = r.ID
            JOIN Batches b ON o.batchID = b.batchID
            JOIN Events e ON b.eventID = e.eventID
            JOIN PaymentTypes p ON o.paymentTypeID = p.paymentTypeID
            JOIN OrderStatuses os ON o.orderStatusID = os.orderStatusID
            WHERE o.orderID = @OrderID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OrderID", _orderID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtOrderID.Text = reader["orderID"].ToString();
                        txtMemberID.Text = reader["memberID"].ToString();
                        txtMemberName.Text = reader["userName"].ToString();
                        txtMemberRole.Text = reader["memberRole"].ToString();

                        dtpOrderDateTime.Value = Convert.ToDateTime(reader["orderDate"]);
                        txtTotalPrice.Text = reader["totalPrice"].ToString();

                        // 先載入 ComboBox DataSource
                        LoadEvents();
                        LoadPaymentTypes();
                        LoadOrderStatuses();

                        // 設定 ComboBox 的選擇值（確保 DataSource 已經載入）
                        comboBoxEvent.SelectedValue = reader["eventID"];
                        LoadBatches(Convert.ToInt32(reader["eventID"]));
                        comboBoxBatch.SelectedValue = reader["batchID"];
                        comboBoxPaymentType.SelectedValue = reader["paymentTypeID"];
                        comboBoxOrderStatus.SelectedValue = reader["orderStatusID"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入訂單失敗：" + ex.Message);
            }
        }

        private void btnModifyOrderStatus_Click(object sender, EventArgs e)
        {
            _isEditingStatus = true;
            ConfigureFormMode(); // 允許修改訂單狀態
        }

        private void btnUpdateOrderStatus_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE Orders SET orderStatusID = (SELECT orderStatusID FROM OrderStatuses WHERE orderStatus = @OrderStatus) WHERE orderID = @OrderID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OrderStatus", comboBoxOrderStatus.Text);
                    cmd.Parameters.AddWithValue("@OrderID", _orderID);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("訂單狀態更新成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新失敗：" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("確定要刪除此訂單嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Orders WHERE orderID = @OrderID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@OrderID", _orderID);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("訂單刪除成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (SqlException ex) when (ex.Number == 547) // FK關聯錯誤
                {
                    MessageBox.Show("無法刪除，該訂單已關聯其他資料。如需刪除，請先修改相關資料。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("刪除失敗：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtMemberID_TextChanged(object sender, EventArgs e)
        {
            memberSearchTimer.Stop(); // 先停止 Timer（避免多次觸發）
            memberSearchTimer.Tag = "ID"; // 設定 Tag，表明查詢的是 ID
            memberSearchTimer.Start(); // 重新啟動計時器
        }

        private void LoadMemberData(int memberID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT userName, r.Name FROM Members m JOIN memberRoles mr ON m.ID = mr.memberID JOIN roles r ON mr.roleID = r.ID WHERE m.ID = @memberID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@memberID", memberID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtMemberName.Text = reader["userName"].ToString();
                    txtMemberRole.Text = reader["Name"].ToString();
                }
                else
                {
                    // 先檢查是否已經是空的，避免 MessageBox.Show() 觸發兩次
                    if (!string.IsNullOrEmpty(txtMemberID.Text) || !string.IsNullOrEmpty(txtMemberName.Text))
                    {
                        txtMemberID.Clear();
                        txtMemberName.Clear();
                        txtMemberRole.Clear();
                        MessageBox.Show("無此會員，請重新輸入！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtMemberName_TextChanged(object sender, EventArgs e)
        {
            memberSearchTimer.Stop(); // 先停止 Timer
            memberSearchTimer.Tag = "Name"; // 設定 Tag，表明查詢的是名稱
            memberSearchTimer.Start(); // 重新啟動計時器
        }

        private void LoadEvents()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT eventID, name FROM Events";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                comboBoxEvent.DataSource = dataTable;
                comboBoxEvent.DisplayMember = "name";   // 顯示活動名稱
                comboBoxEvent.ValueMember = "eventID";  // 確保 eventID 被綁定
            }
        }

        private void comboBoxEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEvent.SelectedValue != null)
            {
                if (comboBoxEvent.SelectedValue is DataRowView rowView)
                {
                    int eventID;
                    if (int.TryParse(rowView["eventID"].ToString(), out eventID))
                    {
                        LoadBatches(eventID);
                    }
                    else
                    {
                        MessageBox.Show("無法轉換 EventID，請檢查資料來源！");
                    }
                }
                else
                {
                    int eventID;
                    if (int.TryParse(comboBoxEvent.SelectedValue.ToString(), out eventID))
                    {
                        LoadBatches(eventID);
                    }
                    else
                    {
                        MessageBox.Show("無法轉換 EventID，請檢查資料來源！");
                    }
                }
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
                    // 清空梯次並跳出對話方塊
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
                }
            }
        }

        private void LoadPaymentTypes()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT paymentTypeID, paymentType FROM PaymentTypes";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                comboBoxPaymentType.DataSource = dataTable;
                comboBoxPaymentType.DisplayMember = "paymentType";
                comboBoxPaymentType.ValueMember = "paymentTypeID";
            }
        }

        private void LoadOrderStatuses()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT orderStatusID, orderStatus FROM OrderStatuses";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                comboBoxOrderStatus.DataSource = dataTable;
                comboBoxOrderStatus.DisplayMember = "orderStatus";
                comboBoxOrderStatus.ValueMember = "orderStatusID";
            }
        }

        private void comboBoxBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBatch.SelectedValue != null)
            {
                int batchID;

                // 確保 SelectedValue 不是 DataRowView
                if (comboBoxBatch.SelectedValue is DataRowView rowView)
                {
                    if (int.TryParse(rowView["batchID"].ToString(), out batchID))
                    {
                        LoadBatchPrice(batchID);
                    }
                    else
                    {
                        MessageBox.Show("無法轉換 batchID，請檢查資料來源！");
                    }
                }
                else
                {
                    if (int.TryParse(comboBoxBatch.SelectedValue.ToString(), out batchID))
                    {
                        LoadBatchPrice(batchID);
                    }
                    else
                    {
                        MessageBox.Show("無法轉換 batchID，請檢查資料來源！");
                    }
                }
            }
        }

        private void LoadBatchPrice(int batchID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT originalPrice FROM Batches WHERE batchID = @batchID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@batchID", batchID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtTotalPrice.Text = reader["originalPrice"].ToString();
                }
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            // 確保所有欄位都已填寫
            if (string.IsNullOrWhiteSpace(txtMemberID.Text) ||
                string.IsNullOrWhiteSpace(comboBoxEvent.Text) ||
                string.IsNullOrWhiteSpace(comboBoxBatch.Text) ||
                string.IsNullOrWhiteSpace(comboBoxPaymentType.Text) ||
                string.IsNullOrWhiteSpace(txtTotalPrice.Text) ||
                string.IsNullOrWhiteSpace(comboBoxOrderStatus.Text))
            {
                MessageBox.Show("請填寫所有欄位！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string query = @"
                INSERT INTO Orders (memberID, batchID, orderDate, paymentTypeID, totalPrice, orderStatusID)
                VALUES (@MemberID, @BatchID, GETDATE(), @PaymentTypeID, @TotalPrice, @OrderStatusID)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MemberID", int.Parse(txtMemberID.Text));
                    cmd.Parameters.AddWithValue("@BatchID", int.Parse(comboBoxBatch.SelectedValue.ToString()));
                    cmd.Parameters.AddWithValue("@PaymentTypeID", int.Parse(comboBoxPaymentType.SelectedValue.ToString()));
                    cmd.Parameters.AddWithValue("@TotalPrice", decimal.Parse(txtTotalPrice.Text));
                    cmd.Parameters.AddWithValue("@OrderStatusID", int.Parse(comboBoxOrderStatus.SelectedValue.ToString()));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("訂單新增成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("新增失敗，請稍後再試！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失敗：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
