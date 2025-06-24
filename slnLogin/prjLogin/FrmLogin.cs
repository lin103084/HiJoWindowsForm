using MaterialSkin;
using MaterialSkin.Controls;
using prjLogin.Class;
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
    public partial class FrmLogin : Form    
    {
        private CsendEmail csendEmail = new CsendEmail(); // 初始化發送郵件的類別
        private CuserService cuserService = new CuserService(); // 初始化用戶服務
        private string createVerificationCode;  // 產生的驗證碼
//        private string createVerificationCode = "123456";  // 產生的驗證碼
        private string userName = null;

        public FrmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//執行視窗預設置中
            this.Width = 600;                                                                 // 設定視窗寬度
            this.Height = 450;                                                               // 設定視窗高度
            this.FormBorderStyle = FormBorderStyle.FixedDialog; //鎖定視窗大小
            
            //Label 背景透明
            uiLabelEmail.BackColor = Color.Transparent;
            uiLabelPassWord.BackColor = Color.Transparent;
            uiLabelVerificationCode.BackColor = Color.Transparent;
            uiLabelExit.BackColor = Color.Transparent;

            // 設定 KeyPreview 為 true，讓表單能夠接收鍵盤事件
            this.KeyPreview = true;            
            this.KeyDown += Login_KeyDown;  // 設定 KeyDown 事件

            //Login預設是無法點選
            uibutLogin.Enabled = false;

            // 移除標題列
            this.FormBorderStyle = FormBorderStyle.None; 

        }

        //預設使用
        private void uiLabelEmail_Click(object sender, EventArgs e)
        {
            this.uiTextBoxEmail.Text = "ispanfriendshipt1@gmail.com";
            this.uiTextBoxPassWord.Text = "bq2Zs6QEs2";
        }
        private void uiLabelPassWord_Click(object sender, EventArgs e)
        {
            this.uiTextBoxEmail.Text = "ispanfriendship@gmail.com";
            this.uiTextBoxPassWord.Text = "mI18cnGx0o";
        }



        // Delegate 鍵盤觸發
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (uiTextBoxVerificationCode.Focused)  // 當焦點在驗證碼輸入框時，觸發登入按鈕
                {
                    uibutLogin.PerformClick();  // 修改為您的按鈕名稱
                }
                else if (uiTextBoxEmail.Focused || uiTextBoxPassWord.Focused)  // 當焦點在帳號或密碼輸入框時，觸發發送驗證碼按鈕
                {
                    uibutVerificationCode.PerformClick();  // 修改為您的按鈕名稱
                }
            }
        }
        // 發送驗證碼 + 驗證帳號密碼
        private void uibutVerificationCode_Click(object sender, EventArgs e)
        {
            string accountEmail = uiTextBoxEmail.Text.Trim(); // 取得使用者輸入的Email
            string password = uiTextBoxPassWord.Text.Trim(); // 取得使用者輸入的密碼

            // 檢查帳號與密碼不為空值
            if (string.IsNullOrEmpty(accountEmail) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("帳號與密碼不得為空值!");
                return;
            }

            // 驗證帳號與密碼是否有效
            if (!cuserService.checkUser(accountEmail, password))
            {
                MessageBox.Show("無效登入! 請確認帳號或者密碼是否正確!");
                return;
            }

            // 產生驗證碼
            createVerificationCode = cuserService.createRandomVerificationCode();

            // 擴充功能 未來
            //刪除舊的驗證碼
            
            // 發送驗證碼到該用戶的 Email
            csendEmail.sendEmailVerificationCode(accountEmail, createVerificationCode);
            MessageBox.Show("驗證碼已發送到您的 Email！");
                        
            uibutLogin.Enabled = true;                            //Login更改為可以點選
            uiTextBoxEmail.Enabled = false;                  // 帳號不可更改輸入
            uiTextBoxPassWord.Enabled = false;          // 密碼不可更改輸入
        }
        //忘記密碼
        private void uibutForgetPassWord_Click(object sender, EventArgs e)
        {
            string accountEmail = uiTextBoxEmail.Text.Trim(); // 取得使用者輸入的帳號(Email)

            // 檢查 Email 是否為空
            if (string.IsNullOrEmpty(accountEmail))
            {
                MessageBox.Show("請輸入您的帳號 (Email)！");
                return;
            }

            // 檢查 Email 是否存在於資料庫        
            if (!cuserService.checkEmail(accountEmail))
            {
                MessageBox.Show("此 Email 尚未註冊！");
                return;
            }

            // 產生一組新的隨機密碼
            string newRandomPassword = cuserService.createRandomPassWord();
            // 更新資料庫中的密碼
            bool updateSuccess = cuserService.updateUserPassWord(accountEmail, newRandomPassword);

            if (!updateSuccess)
            {
                MessageBox.Show("密碼更新失敗，請稍後再試！");
                return;
            }
            // 發送新密碼到該 Email
            string emailContent = $"您的新密碼為：{newRandomPassword}\n" +
                $"請使用此密碼登入，並儘快修改您的密碼！";
            csendEmail.sendEmailForgetPassword(accountEmail, emailContent);
            MessageBox.Show("新的密碼已發送到您的 Email，請檢查您的信箱！");

            // 清空輸入欄位，防止再次誤點
            uiTextBoxPassWord.Text = "";
            uiTextBoxVerificationCode.Text = "";
        }
        // 檢查驗證碼並登入
        private void uibutLogin_Click(object sender, EventArgs e)
        {
            //string enteredCode = uiTextBoxVerificationCode.Text.Trim();  // 取得使用者輸入的驗證碼

            //if(userName is null) 
            //{
            //    userName = cuserService.getUser(uiTextBoxEmail.Text);
            //    //MessageBox.Show(userName);
            //}

            //if (enteredCode == createVerificationCode)
            //{
            //    MessageBox.Show("登入成功！");

            //    //關閉輸入相關 與按鈕
            //    this.uibutVerificationCode.Enabled = false;
            //    this.uibutForgetPassWord.Enabled=false;
            //    this.uiTextBoxVerificationCode.Enabled = false;


            //    this.Hide(); // 隱藏登入頁面，而不是關閉
            //    FrmBackendPage backendPage = new FrmBackendPage();
            //    backendPage.UserName = userName;
            //    backendPage.FormClosed += (s, args) => this.Show(); // 當後台頁面關閉時，顯示登入頁面
            //    backendPage.Show();
            //}
            //else
            //{
            //    MessageBox.Show("驗證碼錯誤，請重新輸入！");
            //}

            string enteredCode = uiTextBoxVerificationCode.Text.Trim();

            if (userName is null)
            {
                userName = cuserService.getUser(uiTextBoxEmail.Text);
            }

            if (enteredCode == createVerificationCode)
            {
                MessageBox.Show("登入成功！");

                // 關閉登入相關 UI 控件
                this.uibutVerificationCode.Enabled = false;
                this.uibutForgetPassWord.Enabled = false;
                this.uiTextBoxVerificationCode.Enabled = false;

                // 隱藏登入畫面
                this.Hide();

                // 創建後台頁面
                FrmBackendPage backendPage = new FrmBackendPage();
                backendPage.UserName = userName;
                backendPage.FormClosed += (s, args) =>
                {
                    // **當後台視窗關閉時，顯示登入頁面**
                    this.Show();
                    // **清除登入資訊**
                    uibutReset_Click(null, null);
                };

                backendPage.Show();
            }
            else
            {
                MessageBox.Show("驗證碼錯誤，請重新輸入！");
            }
        }

        //關閉程式
        private void uiLabelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //重置輸入
        private void uibutReset_Click(object sender, EventArgs e)
        {

            this.uiTextBoxEmail.Text = "";
            this.uiTextBoxPassWord.Text = "";
            this.uiTextBoxVerificationCode.Text = "";
            this.uiTextBoxEmail.Enabled = true;
            this.uiTextBoxPassWord.Enabled = true;

            this.uibutVerificationCode.Enabled = true;
            this.uibutForgetPassWord.Enabled = true;
            this.uiTextBoxVerificationCode.Enabled = true;

            userName = null;  // 清除記錄的用戶名
            createVerificationCode = null;  // 清除驗證碼
        }

  
    }
}
