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
    public partial class FrmEditEventType : Form
    {
        private int eventTypeID;
        string ConnectionString = Settings.Default.PCR7FriendshipConnectionString;

        public FrmEditEventType(int eventTypeID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.eventTypeID = eventTypeID;
            LoadEventTypeData();
        }

        private void LoadEventTypeData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT eventType FROM [dbo].[EventTypes] WHERE eventTypeID = @EventTypeID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EventTypeID", eventTypeID);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        textBox1.Text = result.ToString();
                    }
                    else
                    {
                        MessageBox.Show("找不到此活動分類資料！");
                        this.Close(); // 找不到資料就關閉視窗
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入活動分類失敗：" + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE [dbo].[EventTypes] SET eventType = @NewEventType WHERE eventTypeID = @EventTypeID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NewEventType", textBox1.Text);
                    cmd.Parameters.AddWithValue("@EventTypeID", eventTypeID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("活動類型已更新！");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("更新失敗，請確認資料！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新活動分類失敗：" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
    
