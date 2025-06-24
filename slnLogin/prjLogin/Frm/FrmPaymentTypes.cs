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
    public partial class FrmPaymentTypes : Form
    {
        string ConnectionString = Settings.Default.PCR7FriendshipConnectionString;
        private int? paymentTypeID = null; // 若為 null 代表新增模式
        private Action refreshDataGrid; // 用來回呼 DataGridView 更新

        public FrmPaymentTypes(Action refreshDataGrid, int? paymentTypeID = null, string paymentType = "")
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.paymentTypeID = paymentTypeID;
            this.refreshDataGrid = refreshDataGrid;

            if (paymentTypeID.HasValue)
            {
                txtPaymentType.Text = paymentType;
                btnAdd.Visible = false; // 修改模式隱藏「新增」
            }
            else
            {
                btnSave.Visible = false; // 新增模式隱藏「儲存」
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO PaymentTypes (paymentType) VALUES (@PaymentType)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PaymentType", txtPaymentType.Text.Trim());
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("新增成功！");
                refreshDataGrid.Invoke(); // 呼叫刷新 DataGridView
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失敗：" + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE PaymentTypes SET paymentType = @PaymentType WHERE paymentTypeID = @PaymentTypeID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PaymentType", txtPaymentType.Text.Trim());
                    cmd.Parameters.AddWithValue("@PaymentTypeID", paymentTypeID);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("更新成功！");
                refreshDataGrid.Invoke(); // 呼叫刷新 DataGridView
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新失敗：" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
