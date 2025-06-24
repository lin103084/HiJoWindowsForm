using prjLogin.Class;
using prjLogin.Control;
using slnFriendshipBackEnd.match;
using slnFriendshipBackEnd.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjLogin
{
    public partial class FrmBackendPage : Form
    {
        public string UserName { get; set; } // ✅ 使用屬性

        public FrmBackendPage()//string _userName)
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; //執行視窗預設置中
            this.WindowState = FormWindowState.Maximized;




            //================按鈕測試================
            button2.FlatStyle = FlatStyle.Flat;  // 設定為扁平樣式
            button2.FlatAppearance.BorderSize = 0;  // 移除邊框
            button2.BackColor = Color.Transparent;  // 設定背景透明
            button2.ForeColor = Color.Black;  // 設定文字顏色，確保可見
            button2.TabStop = false;  // 避免按鍵焦點影響
            button2.Text = "";
            button2.FlatAppearance.MouseOverBackColor = button2.BackColor;  // 設定滑鼠懸停時顏色與原本相同
            button2.FlatAppearance.MouseDownBackColor = button2.BackColor;  // 設定點擊時顏色不變


            button6.FlatStyle = FlatStyle.Flat;  // 設定為扁平樣式
            button6.FlatAppearance.BorderSize = 0;  // 移除邊框
            button6.BackColor = Color.Transparent;  // 設定背景透明
            button6.ForeColor = Color.Black;  // 設定文字顏色，確保可見
            button6.TabStop = false;  // 避免按鍵焦點影響
            button6.Text = "";
            button6.FlatAppearance.MouseOverBackColor = button6.BackColor;  // 設定滑鼠懸停時顏色與原本相同
            button6.FlatAppearance.MouseDownBackColor = button6.BackColor;  // 設定點擊時顏色不變


            button9.FlatStyle = FlatStyle.Flat;  // 設定為扁平樣式
            button9.FlatAppearance.BorderSize = 0;  // 移除邊框
            button9.BackColor = Color.Transparent;  // 設定背景透明
            button9.ForeColor = Color.Black;  // 設定文字顏色，確保可見
            button9.TabStop = false;  // 避免按鍵焦點影響
            button9.Text = "";
            button9.FlatAppearance.MouseOverBackColor = button9.BackColor;  // 設定滑鼠懸停時顏色與原本相同
            button9.FlatAppearance.MouseDownBackColor = button9.BackColor;  // 設定點擊時顏色不變


            //================按鈕測試================

        }
        private void FrmBackendPage_Load(object sender, EventArgs e)
        {
            //登入者名稱 + 防呆
            if (!string.IsNullOrEmpty(UserName))
            {
                string upperCaseUserName = (UserName ?? string.Empty).Trim().ToUpper();

                this.labelUserName.Text = $"您好! {upperCaseUserName} ";
            }
        }


        //回首頁
        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            // 先清空分割畫面右下角的splitContainer2.Panel2
            this.splitContainer2.Panel2.Controls.Clear();
            // 設定panelHome的Dock為Fill
            this.panelHome.Dock = DockStyle.Fill;
            // 將panelHome加入分割畫面右下角的splitContainer2.Panel2
            this.splitContainer2.Panel2.Controls.Add(this.panelHome);
        }
        private void butMembers_Click(object sender, EventArgs e)
        {
            // 確保 splitContainer2.Panel2 內沒有殘留控制項
            this.splitContainer2.Panel2.Controls.Clear();

            // 創建 UCmember 控制項
            UCmember ucmembers = new UCmember();

            // 確保控制項填滿 Panel2
            ucmembers.Dock = DockStyle.Fill;

            //// 將 UCmember 加入 Panel2
            this.splitContainer2.Panel2.Controls.Add(ucmembers);


        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            // 先清空分割畫面右下角的splitContainer2.Panel2
            this.splitContainer2.Panel2.Controls.Clear();
            // 新增一個自訂控制項em，並設Dock為Fill
            UCeventsManager em = new UCeventsManager();
            em.Dock = DockStyle.Fill;
            // 將em加入splitContainer2.Panel2
            this.splitContainer2.Panel2.Controls.Add(em);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            // 先清空分割畫面右下角的splitContainer2.Panel2
            this.splitContainer2.Panel2.Controls.Clear();
            // 新增一個自訂控制項em，並設Dock為Fill
            UCordersManager om = new UCordersManager();
            om.Dock = DockStyle.Fill;
            // 將em加入splitContainer2.Panel2
            this.splitContainer2.Panel2.Controls.Add(om);
        }

        private void btnSwipe_Click(object sender, EventArgs e)
        {





            // 先清空分割畫面右下角的splitContainer2.Panel2
            this.splitContainer2.Panel2.Controls.Clear();
            // 新增一個自訂控制項sw，並設Dock為Fill
            UcSwipes sw = new UcSwipes();
            sw.Dock = DockStyle.Fill;
            // 將em加入splitContainer2.Panel2
            this.splitContainer2.Panel2.Controls.Add(sw);





        }

        private void butMembers_MouseMove(object sender, MouseEventArgs e)
        {
            ButtonMouseMove(butMembers);
        }

        private void ButtonMouseMove(Button B)
        {
            B.FlatStyle = FlatStyle.Flat;
            B.FlatAppearance.BorderSize = 5;  // 設定邊框粗細
            B.FlatAppearance.BorderColor = Color.LightSteelBlue;  // 設定邊框顏色
        }

        private void butMembers_MouseLeave(object sender, EventArgs e)
        {
            ButtonMouseLeave(butMembers);

        }

        private void ButtonMouseLeave(Button B)
        {
            B.FlatStyle = FlatStyle.Flat;
            B.FlatAppearance.BorderSize = 0;  // 設定邊框粗細
        }

        private void btnEvents_MouseMove(object sender, MouseEventArgs e)
        {
            ButtonMouseMove(btnEvents);
        }

        private void btnEvents_MouseLeave(object sender, EventArgs e)
        {
            ButtonMouseLeave(btnEvents);
        }

        private void btnOrders_MouseMove(object sender, MouseEventArgs e)
        {
            ButtonMouseMove(btnOrders);
        }

        private void btnOrders_MouseLeave(object sender, EventArgs e)
        {
            ButtonMouseLeave(btnOrders);
        }

        private void btnSwipe_MouseMove(object sender, MouseEventArgs e)
        {
            ButtonMouseMove(btnSwipe);
        }

        private void btnSwipe_MouseLeave(object sender, EventArgs e)
        {
            ButtonMouseLeave(btnSwipe);
        }

        private void uibtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要登出嗎？", "登出確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 關閉後台視窗
                this.Close();
            }
        }
    }
}
