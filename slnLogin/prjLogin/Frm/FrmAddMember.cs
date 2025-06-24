using prjLogin.Class;
using prjLogin.Properties;
using Sunny.UI;
using System;
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

namespace prjLogin.Frm
{
    public partial class FrmAddMember : Form
    {
        string ConnectionString = Settings.Default.PCR7FriendshipConnectionString;

        CuserService cuserService = new CuserService();
        CsendEmail csendEmail= new CsendEmail();
        public FrmAddMember()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            loadCities();    //載入城市
            loadSex();        //載入性別
            loadRole();      //載入權限類別
        }


        // 載入縣市 
        private void loadCities()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
                SELECT 
                            cityID, 
                            cityName 
                FROM 
                                Cities 
                ORDER BY 
                                cityName";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                //標記顯示 ComboBox城市 
                //外面顯示  "城市名"     "標記ID"
                uiComboBoxCities.DisplayMember = "cityName";
                uiComboBoxCities.ValueMember = "cityID";
                uiComboBoxCities.DataSource = dt;
                uiComboBoxCities.SelectedIndex = -1; // 預設不選擇
            }
        }
        //載入地區
        private void loadDistricts(int parentCityID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string query = @"
                SELECT 
                                districtID, 
                                districtName 
                FROM 
                                districts 
                WHERE 
                                parentCityID = @citiesID 
                ORDER BY 
                                districtName";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@citiesID", parentCityID);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                //標記顯示 ComboBox地區 
                //外面顯示  "地區名"     "標記ID"
                uiComboBoxDistrict.DisplayMember = "districtName";
                uiComboBoxDistrict.ValueMember = "districtID";
                uiComboBoxDistrict.DataSource = dt;
                uiComboBoxDistrict.SelectedIndex = -1; // 預設不選擇
            }
        }
        //載入地區根據縣市選擇
        private void uiComboBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uiComboBoxCities.SelectedValue != null)
            {
                int cityID = Convert.ToInt32(uiComboBoxCities.SelectedValue);
                loadDistricts(cityID);
            }
        }
        //載入性別
        private void loadSex()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
                SELECT
                            DISTINCT Sex,
                    CASE
	                        WHEN SEX = 'M' THEN 1 ELSE 2
                    END 
                            AS SexID
                    FROM 
                            members;";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                uicomboBoxSex.DisplayMember = "Sex";
                uicomboBoxSex.ValueMember = "SexID";
                uicomboBoxSex.DataSource = dt;
            }
        }

        //載入權限類別
        private void loadRole()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
                SELECT 
                            ID AS roleID, 
                            name AS roleName 
                FROM 
                            roles
                ORDER BY 
                            ID";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // 綁定 uiComboBoxRole
                uiComboBoxRole.DisplayMember = "roleName"; // 顯示角色名稱
                uiComboBoxRole.ValueMember = "roleID";     // 內部儲存 roleID
                uiComboBoxRole.DataSource = dt;            // 綁定 DataTable
                uiComboBoxRole.SelectedIndex = -1;         // 預設不選擇

            }
        }

        //新增會員
         private void uibutAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.uitextBoxEmail.Text) 
                || string.IsNullOrEmpty(this.uitextBoxUserName.Text)
                || string.IsNullOrEmpty(this.uicomboBoxSex.Text)
                || this.uiComboBoxCities.SelectedValue == null
                || this.uiComboBoxDistrict.SelectedValue == null
                ||this.uiComboBoxRole.SelectedValue == null
                ) 
            {                
                MessageBox.Show("請填寫所有必填欄位!");
                return;
            }

            // Email / Name / Sex / birthday
            string accountEmail = this.uitextBoxEmail.Text.Trim();
            string username = this.uitextBoxUserName.Text.Trim();
            string sex = uicomboBoxSex.Text.Trim();
            string birthday = uidateTimePickerBirthday.Value.ToString("yyyy-MM-dd") ;

            //  取得縣市 與 地區的 ID
            int cityID = Convert.ToInt32(uiComboBoxCities.SelectedValue);
            int districtID = Convert.ToInt32(uiComboBoxDistrict.SelectedValue);
            int roleID = Convert.ToInt32(uiComboBoxRole.SelectedValue);

            //檢查AccountEmail是否已存在
            if (cuserService.checkEmail(accountEmail)) 
            {
                MessageBox.Show("此Email已註冊使用過，請更換!");
                return;
            }

            //產生隨機密碼
            string randomPassWord = cuserService.createRandomPassWord();
            string passWordSalt = "";
            bool createUserResult = cuserService.createUser(accountEmail,randomPassWord, passWordSalt, username, sex,birthday, cityID,districtID);

            //賦予角色權限
            bool addMemberRoleResult  = cuserService.addMemberRole(accountEmail, roleID);            

            if (createUserResult && addMemberRoleResult)
            {
                csendEmail.sendEmailCreateUser(accountEmail, randomPassWord);
                MessageBox.Show($"會員註冊成功!");
            }
            else
            {
                MessageBox.Show($"會員註冊失敗!");
            }
        }

       

        //TODO
        //變更圖片路徑到DB
        private void updateAvatarPathInDatabase(string avatarPath)
        {
            //using (SqlConnection conn = new SqlConnection(ConnectionString))
            //{
            //    conn.Open();
            //    string query = @"
            //    UPDATE 
            //                    Members 
            //    SET 
            //                    avatarPath = @AvatarPath
            //    WHERE 
            //                     ID = @ID";

            //    using (SqlCommand cmd = new SqlCommand(query, conn))
            //    {
            //        cmd.Parameters.AddWithValue("@ID", _userId);
            //        cmd.Parameters.AddWithValue("@AvatarPath", avatarPath);

            //        int rowsResult = cmd.ExecuteNonQuery();
            //        if (rowsResult > 0)
            //        {
            //            MessageBox.Show("頭像更新成功！");
            //        }
            //        else
            //        {
            //            MessageBox.Show("更新失敗！");
            //        }
            //    }
            //}
        }
        
        //變更圖片
        //private void butChangAvatar_Click(object sender, EventArgs e)
        //{
        //    // 1. 打開檔案選擇器，讓用戶選擇圖片
        //    OpenFileDialog openFileDialog = new OpenFileDialog
        //    {
        //        Title = "選擇頭像圖片",
        //        Filter = "圖片檔案 (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"
        //    };

        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        // 2. 獲取選擇的檔案路徑
        //        string selectedFilePath = openFileDialog.FileName;

        //        // 3. 確保 `Picture/avatar` 資料夾存在
        //        string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
        //        string avatarFolderPath = Path.Combine(projectRoot, "Picture", "avatar");
        //        Directory.CreateDirectory(avatarFolderPath);

        //        // 4. 產生新的檔名，避免重複 (使用 GUID)
        //        string newFileName = $"avatar_{Guid.NewGuid().ToString("N")}{Path.GetExtension(selectedFilePath)}";
        //        string newFilePath = Path.Combine(avatarFolderPath, newFileName);

        //        // 5. 複製圖片到 `Picture/avatar` 目錄
        //        File.Copy(selectedFilePath, newFilePath, true);

        //        // 6. 更新 UI 顯示新圖片
        //        //pictureBoxAvatar.Image = Image.FromFile(newFilePath);

        //        // 7. 更新 SQL 資料庫，存相對路徑
        //        string relativePath = Path.Combine("Picture", "avatar", newFileName);
        //        updateAvatarPathInDatabase(relativePath);
        //    }
        //}

    }
}
