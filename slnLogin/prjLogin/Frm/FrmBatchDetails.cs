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

namespace slnFriendshipBackEnd.Forms
{
    public partial class FrmBatchDetails : Form
    {
        string ConnectionString = Settings.Default.PCR7FriendshipConnectionString;
        private FormMode mode;
        private int batchID; // 儲存目前操作的 Batch ID
        private FormMode _formMode;
        private int? _batchID; // null 表示新增
        private bool _isEditing = false;

        public event Action BatchUpdated; // 定義事件

        public FrmBatchDetails(FormMode mode, int batchID = -1)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.mode = mode;
            this._formMode = mode;
            this.batchID = batchID;

            if (mode == FormMode.View || mode == FormMode.Edit || mode == FormMode.Delete)
            {
                LoadBatchDetails();
            }

            this.Load += FrmBatchDetails_Load;
        }

        private void FrmBatchDetails_Load(object sender, EventArgs e)
        {
            LoadEventNames();
            ConfigureFormMode();

            dTPRegistrationStart.Format = DateTimePickerFormat.Custom;
            dTPRegistrationStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            dTPRegistrationEnd.Format = DateTimePickerFormat.Custom;
            dTPRegistrationEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            dateTimePickerEventStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerEventStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";

            dateTimePickerEventEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerEventEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";

        }

        // 載入活動名稱下拉選單
        private void LoadEventNames()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT eventID, name FROM Events";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    comboBoxEventName.DataSource = dataTable;
                    comboBoxEventName.DisplayMember = "name";
                    comboBoxEventName.ValueMember = "eventID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入活動名稱失敗：" + ex.Message);
            }
        }

        // 設定表單模式 (檢視、編輯、新增、刪除)
        private void ConfigureFormMode()
        {
            switch (_formMode)
            {
                case FormMode.Add:
                    Text = "新增活動梯次";
                    EnableEditing(true);
                    btnSave.Visible = false;
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                    btnAdd.Visible = true;
                    break;

                case FormMode.View:
                    Text = "檢視活動梯次";
                    EnableEditing(false);
                    btnSave.Visible = false;
                    btnEdit.Visible = true;
                    btnDelete.Visible = false;
                    btnAdd.Visible = false;
                    LoadBatchDetails();
                    break;

                case FormMode.Edit:
                    Text = "編輯活動梯次";
                    EnableEditing(true);
                    btnSave.Visible = true;
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                    btnAdd.Visible = false;
                    LoadBatchDetails();
                    break;

                case FormMode.Delete:
                    Text = "刪除活動梯次";
                    EnableEditing(false);
                    btnSave.Visible = false;
                    btnEdit.Visible = false;
                    btnDelete.Visible = true;
                    btnAdd.Visible = false;
                    LoadBatchDetails();
                    break;
            }
        }

        // 設定是否允許編輯
        private void EnableEditing(bool enable)
        {
            comboBoxEventName.Enabled = enable;
            txtOPrice.ReadOnly = !enable;
            txtDPrice.ReadOnly = !enable;
            txtDInfo.ReadOnly = !enable;
            numQuota.Enabled = enable;
            dateTimePickerEventStart.Enabled = enable;
            dateTimePickerEventEnd.Enabled = enable;
            dTPRegistrationStart.Enabled = enable;
            dTPRegistrationEnd.Enabled = enable;

            // 確保"檢視模式"不能點擊下拉選單
            if (!enable)
            {
                comboBoxEventName.DropDownStyle = ComboBoxStyle.Simple; // 不能打開下拉選單
            }
            else
            {
                comboBoxEventName.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        // 讀取活動梯次資料
        private void LoadBatchDetails()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Batches WHERE batchID = @BatchID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BatchID", batchID);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    comboBoxEventName.SelectedValue = reader["eventID"];
                    txtOPrice.Text = reader["originalPrice"].ToString();
                    txtDPrice.Text = reader["discountPrice"].ToString();
                    txtDInfo.Text = reader["discountInformation"].ToString();
                    numQuota.Value = Convert.ToDecimal(reader["quota"]);
                    dateTimePickerEventStart.Value = Convert.ToDateTime(reader["eventStartDate"]);
                    dateTimePickerEventEnd.Value = Convert.ToDateTime(reader["eventEndDate"]);
                    dTPRegistrationStart.Value = Convert.ToDateTime(reader["registrationStartDate"]);
                    dTPRegistrationEnd.Value = Convert.ToDateTime(reader["registrationEndDate"]);
                }
            }
        }

        // 儲存活動梯次 (新增或修改)
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                UPDATE Batches 
                SET eventID = @EventID, originalPrice = @OPrice, 
                    discountPrice = @DPrice, discountInformation = @DInfo, quota = @Quota, 
                    eventStartDate = @EventStart, eventEndDate = @EventEnd, 
                    registrationStartDate = @RegStart, registrationEndDate = @RegEnd
                WHERE batchID = @BatchID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BatchID", batchID);
                    cmd.Parameters.AddWithValue("@EventID", comboBoxEventName.SelectedValue);
                    cmd.Parameters.AddWithValue("@OPrice", txtOPrice.Text);
                    cmd.Parameters.AddWithValue("@DPrice", string.IsNullOrWhiteSpace(txtDPrice.Text) ? (object)DBNull.Value : txtDPrice.Text);
                    cmd.Parameters.AddWithValue("@DInfo", string.IsNullOrWhiteSpace(txtDInfo.Text) ? (object)DBNull.Value : txtDInfo.Text);
                    cmd.Parameters.AddWithValue("@Quota", Convert.ToInt32(numQuota.Value));
                    cmd.Parameters.AddWithValue("@EventStart", dateTimePickerEventStart.Value);
                    cmd.Parameters.AddWithValue("@EventEnd", dateTimePickerEventEnd.Value);
                    cmd.Parameters.AddWithValue("@RegStart", dTPRegistrationStart.Value);
                    cmd.Parameters.AddWithValue("@RegEnd", dTPRegistrationEnd.Value);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("更新成功！");
                BatchUpdated?.Invoke(); // 觸發事件通知 `UCeventsManager`
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新失敗：" + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                INSERT INTO Batches (eventID, originalPrice, discountPrice, discountInformation, quota, eventStartDate, eventEndDate, registrationStartDate, registrationEndDate)
                VALUES (@EventID, @OPrice, @DPrice, @DInfo, @Quota, @EventStart, @EventEnd, @RegStart, @RegEnd)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EventID", comboBoxEventName.SelectedValue);
                    cmd.Parameters.AddWithValue("@OPrice", txtOPrice.Text);
                    cmd.Parameters.AddWithValue("@DPrice", string.IsNullOrWhiteSpace(txtDPrice.Text) ? (object)DBNull.Value : txtDPrice.Text);
                    cmd.Parameters.AddWithValue("@DInfo", string.IsNullOrWhiteSpace(txtDInfo.Text) ? (object)DBNull.Value : txtDInfo.Text);
                    cmd.Parameters.AddWithValue("@Quota", Convert.ToInt32(numQuota.Value));
                    cmd.Parameters.AddWithValue("@EventStart", dateTimePickerEventStart.Value);
                    cmd.Parameters.AddWithValue("@EventEnd", dateTimePickerEventEnd.Value);
                    cmd.Parameters.AddWithValue("@RegStart", dTPRegistrationStart.Value);
                    cmd.Parameters.AddWithValue("@RegEnd", dTPRegistrationEnd.Value);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("新增成功！");
                }
                BatchUpdated?.Invoke(); // 觸發事件通知 `UCeventsManager`
                // 設定 DialogResult，讓 `UCeventsManager` 知道要刷新 DataGridView
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失敗：" + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _formMode = FormMode.Edit;
            ConfigureFormMode();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("確定要刪除此活動梯次嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Batches WHERE batchID = @BatchID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BatchID", batchID);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("刪除成功！");
                BatchUpdated?.Invoke(); // 觸發事件通知 `UCeventsManager`
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex) when (ex.Number == 547) // FK關聯錯誤
            {
                MessageBox.Show("無法刪除，該活動梯次已關聯其他資料。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("刪除失敗：" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
