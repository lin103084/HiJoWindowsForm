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
    public partial class FrmInsertEventType : Form
    {
        string ConnectionString = Settings.Default.PCR7FriendshipConnectionString;
        public FrmInsertEventType()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newEventType = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(newEventType))
            {
                MessageBox.Show("請輸入活動分類名稱！");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO [dbo].[EventTypes] (eventType) VALUES (@EventType)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EventType", newEventType);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("新增成功！");
                this.DialogResult = DialogResult.OK; // 設定 DialogResult 讓主視窗知道要刷新
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失敗：" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

