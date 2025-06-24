using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace prjLogin.Class
{
    internal class CsendEmail
    {
        // SMTP 配置 (請填入你的 Gmail 和 應用程式密碼)
        private string smtpServer = "smtp.gmail.com";
        private string smtpUser = "ispanfriendship@gmail.com";  // 發信人 Email
        private string smtpPassword = "xxxxxxxxx"; // **應用程式密碼**
        private int smtpPort = 587;

 

        // 發送 Email驗證
        public void sendEmailVerificationCode(string toEmail, string verificationCode)
        {
            try
            {
                using (var mail = new MailMessage())
                using (var smtpClient = new SmtpClient(smtpServer))
                {
                    mail.From = new MailAddress(smtpUser);
                    mail.To.Add(toEmail);
                    mail.Subject = "<FrendShip>驗證碼";
                    mail.Body = $"您的驗證碼是：{verificationCode}，請於5分鐘內完成輸入。";
                    mail.IsBodyHtml = false;  // 設定為純文字

                    smtpClient.Port = smtpPort;
                    smtpClient.Credentials = new NetworkCredential(smtpUser, smtpPassword);
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(mail); // 發送郵件

                    MessageBox.Show($"已成功發送驗證碼至 {toEmail}！", "發送成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"郵件發送失敗：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //補發密碼
        public void sendEmailForgetPassword(string toEmail, string emailContent)
        {
            try
            {
                using (var mail = new MailMessage())
                using (var smtpClient = new SmtpClient(smtpServer))
                {
                    mail.From = new MailAddress(smtpUser);
                    mail.To.Add(toEmail);
                    mail.Subject = "<FrendShip>補發密碼";
                    mail.Body = $"您的補發的密碼是：{emailContent}，請於5分鐘內完成輸入。";
                    mail.IsBodyHtml = false;  // 設定為純文字

                    smtpClient.Port = smtpPort;
                    smtpClient.Credentials = new NetworkCredential(smtpUser, smtpPassword);
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(mail); // 發送郵件

                    MessageBox.Show($"已成功發送補發密碼至 {toEmail}！", "發送成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"郵件發送失敗：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //創建帳號 發送密碼
        public void sendEmailCreateUser(string toEmail, string emailContent) 
        {
            try
            {
                using (var mail = new MailMessage())
                using (var smtpClient = new SmtpClient(smtpServer))
                {
                    mail.From = new MailAddress(smtpUser);
                    mail.To.Add(toEmail);
                    mail.Subject = "<FrendShip>帳號創建成功!";
                    mail.Body = $"您的密碼是：{emailContent}，請使用該密碼登入，並更改密碼。";
                    mail.IsBodyHtml = false;  // 設定為純文字

                    smtpClient.Port = smtpPort;
                    smtpClient.Credentials = new NetworkCredential(smtpUser, smtpPassword);
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(mail); // 發送郵件

                    MessageBox.Show($"已成功發送密碼至 {toEmail}！", "發送成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"郵件發送失敗：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
