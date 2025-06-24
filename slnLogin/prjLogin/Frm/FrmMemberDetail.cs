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
    public partial class FrmMemberDetail : Form
    {
        string ConnectionString = Settings.Default.PCR7FriendshipConnectionString;

        private string _userId { get; set; }
        public FrmMemberDetail(string userId)
        {
            this._userId = userId;

            if (string.IsNullOrEmpty(_userId))
            {
                MessageBox.Show("用戶 ID 錯誤，請重新登入！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            InitializeComponent();
            loadMemberDetails();         //載入會員資料
            loadInterestCategories();   //載入興趣類別
            loadUserInterests();           // 載入已存興趣


            this.StartPosition = FormStartPosition.CenterScreen;            //預設置中
            // 預設鎖住 點選編輯才能開
            this.textBoxUserName.Enabled = false;    //名稱
            this.textBoxEmail.Enabled = false;              //email
            this.comboBoxSex.Enabled = false;           //Sex 
            this.textBoxBirthday.Enabled = false;        //birthday
            this.comboBoxCities.Enabled = false;        //City
            this.comboBoxDistrict.Enabled = false;     //District
            this.checkBoxActive.Enabled = false;        //帳號狀態
            this.checkBoxVerified.Enabled = false;      //是否驗證

            this.butDeleteAcount.Enabled = false;    // but刪除帳號
            this.butUpdate.Enabled = false;                //but更新
            this.butChangAvatar.Enabled = false;     //but變更頭貼
            this.butAddInterest.Enabled = false;        //加入興趣
            this.butSaveInteresting.Enabled = false;//儲存興趣
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
                comboBoxCities.DisplayMember = "cityName";
                comboBoxCities.ValueMember = "cityID";
                comboBoxCities.DataSource = dt;
                comboBoxCities.SelectedIndex = -1; // 預設不選擇
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
                comboBoxDistrict.DisplayMember = "districtName";
                comboBoxDistrict.ValueMember = "districtID";
                comboBoxDistrict.DataSource = dt;
                comboBoxDistrict.SelectedIndex = -1; // 預設不選擇
            }
        }
        //載入地區 > 根據選擇的縣市
        private void comboBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCities.SelectedValue != null)
            {
                int cityID = Convert.ToInt32(comboBoxCities.SelectedValue);
                loadDistricts(cityID);
            }
        }
        //點選載入城市
        private void comboBoxCities_MouseDown(object sender, MouseEventArgs e)
        {
            loadCities();
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

                comboBoxSex.DisplayMember = "Sex";
                comboBoxSex.ValueMember = "SexID";
                comboBoxSex.DataSource = dt;
            }
        }      
        //點選載入性別
        private void comboBoxSex_MouseDown(object sender, MouseEventArgs e)
        {
            loadSex();
        }
        //載入用戶資料
        private void loadMemberDetails()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
                SELECT 
                            m.userName, 
                            m.email, 
                            m.sex, 
                            m.birthday, 
                            m.isActive, 
                            m.isVerified, 
                            m.avatarPath,
                            c.cityID, 
                            c.cityName, 
                            d.districtID, 
                            d.districtName
                FROM
                            Members m
                LEFT JOIN 
                            Cities c ON m.cityID = c.cityID
                LEFT JOIN 
                            Districts d ON m.districtID = d.districtID
                WHERE 
                            m.ID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", _userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // 設定基本資訊
                        textBoxUserName.Text = reader["userName"].ToString();
                        textBoxEmail.Text = reader["email"].ToString();
                        comboBoxSex.Text = reader["sex"].ToString();
                        textBoxBirthday.Text = Convert.ToDateTime(reader["birthday"]).ToString("yyyy-MM-dd");

                        // 設定帳號狀態
                        checkBoxActive.Checked = Convert.ToBoolean(reader["isActive"]);
                        checkBoxVerified.Checked = Convert.ToBoolean(reader["isVerified"]);

                        // 獲取 `avatarPath`
                        string avatarPath = reader["avatarPath"].ToString();
                        // 設定完整圖片路徑，假設 `avatarPath` 是相對路徑
                        //string projectRoot = AppDomain.CurrentDomain.BaseDirectory;                   
                        string fullImagePath = Path.Combine("..", "..", avatarPath);
                        //MessageBox.Show($"{avatarPath}\n{projectRoot}\n{ fullImagePath}");

                        // 確保圖片存在
                        if (File.Exists(fullImagePath))
                        {
                            pictureBoxAvatar.Image = Image.FromFile(fullImagePath);
                        }
                        else
                        {
                            // 如果圖片不存在，顯示預設圖片
                            pictureBoxAvatar.Image = Image.FromFile(Path.Combine("..", "..", "Picture/avatar/defalt.jpg"));
                        }

                        // 設定 ComboBox 的選擇
                        int cityID = reader["cityID"] != DBNull.Value ? Convert.ToInt32(reader["cityID"]) : -1;
                        int districtID = reader["districtID"] != DBNull.Value ? Convert.ToInt32(reader["districtID"]) : -1;

                        // 載入縣市列表
                        loadCities();

                        if (cityID != -1)
                        {
                            comboBoxCities.SelectedValue = cityID;
                            loadDistricts(cityID);  // 先載入該縣市的區域
                        }

                        if (districtID != -1)
                        {
                            comboBoxDistrict.SelectedValue = districtID;
                        }
                    }
                }
            }
        }
        //載入興趣類別
        private void loadInterestCategories()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
                SELECT 
                                id, name 
                FROM 
                            InterestCategories 
                ORDER BY 
                            name";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0) // 確保有資料
                {
                    uiComboBoxCategories.DisplayMember = "name";
                    uiComboBoxCategories.ValueMember = "id";
                    uiComboBoxCategories.DataSource = dt;
                    uiComboBoxCategories.SelectedIndex = 0; // 預設選擇第一個分類
                }
            }
        }
        //載入興趣分類
        private void loadInterestsByCategory(int categoryID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
                SELECT 
                            id, name 
                FROM 
                            Interests 
                WHERE 
                            categoryID = @categoryID 
                ORDER BY 
                            name";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@categoryID", categoryID);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                checkedListBoxInterests.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    string name = row["name"].ToString();
                    checkedListBoxInterests.Items.Add(new KeyValuePair<int, string>(id, name), false);
                }
            }
        }
        //根據分類載入興趣
        private void uiComboBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uiComboBoxCategories.SelectedValue != null)
            {
                int categoryID = Convert.ToInt32(uiComboBoxCategories.SelectedValue);
                loadInterestsByCategory(categoryID);
            }
        }
        // 載入使用者興趣
        private void loadUserInterests()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
                SELECT 
                            i.id, 
                            i.name 
                FROM 
                            MemberInterests mi
                JOIN 
                        Interests i 
                ON 
                        mi.interestID = i.id
                WHERE 
                            mi.memberID = @memberID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@memberID", _userId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    FlowLayoutPanelSelected.Controls.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        int interestID = Convert.ToInt32(row["id"]);
                        string interestName = row["name"].ToString();
                        addInterestTag(interestID, interestName);
                    }
                }
            }
        }
        // 檢查興趣是否已存在
        private bool checkInterestSelected(int interestID)
        {
            foreach (System.Windows.Forms.Control control in FlowLayoutPanelSelected.Controls)
            {             
                if (control.Tag is int id && id == interestID)
                {
                    return true; // 這個興趣已存在，不應該重複添加
                }
            }
            return false;
        }
        // 興趣Label標籤
        private void addInterestTag(int interestID, string interestName)
        {
            Label label = new Label
            {
                Text = $"{interestName} ❌",
                Tag = interestID,
                AutoSize = true,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(4),
                Cursor = Cursors.Hand
            };            
            FlowLayoutPanelSelected.Controls.Add(label);      // 個別添加進去
            label.Click += (s, e) => removeInterestTag(label); // 個別綁定刪除事件
        }
        // Remove 
        private void removeInterestTag(Label label)
        {
            int interestID = (int)label.Tag; // 取得標籤的興趣 ID

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string query = @"
                DELETE FROM 
                                MemberInterests 
                WHERE 
                            memberID = @memberID 
                            AND 
                            interestID = @interestID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@memberID", _userId);
                    cmd.Parameters.AddWithValue("@interestID", interestID);
                    int rowsResult = cmd.ExecuteNonQuery();

                    if (rowsResult > 0)
                    {
                        FlowLayoutPanelSelected.Controls.Remove(label); // 從 UI 移除**
                        MessageBox.Show($"興趣已刪除: {label.Text}", "刪除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"刪除失敗，可能該興趣已不存在於資料庫。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        //加入已選擇的興趣
        private void butAddInterest_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBoxInterests.CheckedItems) // 獲取所有被勾選的興趣
            {
                if (item is KeyValuePair<int, string> selectedInterest) // 轉換成 KeyValuePair
                {
                    int interestID = selectedInterest.Key; // 取得 ID
                    string interestName = selectedInterest.Value; // 取得名稱

                    // 確保不重複添加
                    if (!checkInterestSelected(interestID))
                    {
                        addInterestTag(interestID, interestName);
                    }
                }
            }
        }
        // 興趣儲存
        private void butSaveInteresting_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                foreach (System.Windows.Forms.Control control in FlowLayoutPanelSelected.Controls)
                {
                    if (!int.TryParse(control.Tag.ToString(), out int interestID))
                    {
                        MessageBox.Show("錯誤：興趣 ID 格式錯誤！");
                        continue;
                    }

                    // 檢查是否已經存在
                    string checkQuery = @"
                    SELECT 
                                COUNT(*) 
                    FROM 
                                MemberInterests 
                    WHERE 
                                memberID = @memberID 
                                AND 
                                interestID = @interestID";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@memberID", _userId);
                        checkCmd.Parameters.AddWithValue("@interestID", interestID);
                        int CheckCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (CheckCount > 0) //已存在就不需要存入
                        {
                            continue;
                        }
                    }

                    //新增到資料庫
                    string insertQuery = @"
                    INSERT INTO 
                                MemberInterests (memberID, interestID) 
                    VALUES 
                                (@memberID, @interestID)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@memberID", _userId);
                        cmd.Parameters.AddWithValue("@interestID", interestID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("興趣已成功儲存！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // 編輯 / 鎖定
        private void butEdit_Click(object sender, EventArgs e)
        {
            this.textBoxUserName.Enabled = !this.textBoxUserName.Enabled;    //名稱
            this.textBoxEmail.Enabled = !this.textBoxEmail.Enabled;              //email
            this.comboBoxSex.Enabled = !this.comboBoxSex.Enabled;           //Sex 
            this.textBoxBirthday.Enabled = !this.textBoxBirthday.Enabled;        //birthday
            this.comboBoxCities.Enabled = !this.comboBoxCities.Enabled;        //City
            this.comboBoxDistrict.Enabled = !this.comboBoxDistrict.Enabled;      //District
            this.checkBoxActive.Enabled = !this.checkBoxActive.Enabled;        //帳號狀態
            this.checkBoxVerified.Enabled = !this.checkBoxVerified.Enabled;      //是否驗證

            this.butDeleteAcount.Enabled = !this.butDeleteAcount.Enabled;    // but刪除帳號
            this.butUpdate.Enabled = !this.butUpdate.Enabled;                //but更新
            this.butChangAvatar.Enabled = !this.butChangAvatar.Enabled;     //but變更頭貼
            this.butAddInterest.Enabled = !this.butAddInterest.Enabled;        //加入興趣
            this.butSaveInteresting.Enabled = !this.butSaveInteresting.Enabled;//儲存興趣
        }
    
        //更新資料
        private void butUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
                UPDATE 
                                Members 
                SET 
                                userName = @userName, 
                                email = @Email, 
                                sex = @Sex, 
                                birthday = @Birthday,
                                cityID = @CityID, 
                                districtID = @DistrictID, 
                                isActive = @IsActive, 
                                isVerified = @IsVerified
                WHERE 
                                 ID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", _userId);
                    cmd.Parameters.AddWithValue("@userName", textBoxUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Sex", comboBoxSex.Text.Trim());

                    // 防止格式錯誤
                    DateTime birthday;
                    if (!DateTime.TryParse(textBoxBirthday.Text, out birthday))
                    {
                        MessageBox.Show("請輸入有效的生日日期！");
                        return;
                    }
                    cmd.Parameters.AddWithValue("@Birthday", birthday);

                    // 確保 CityID & DistrictID 不為 NULL
                    int selectedCityID = comboBoxCities.SelectedValue != null ? Convert.ToInt32(comboBoxCities.SelectedValue) : 0;
                    int selectedDistrictID = comboBoxDistrict.SelectedValue != null ? Convert.ToInt32(comboBoxDistrict.SelectedValue) : 0;

                    cmd.Parameters.AddWithValue("@CityID", selectedCityID);
                    cmd.Parameters.AddWithValue("@DistrictID", selectedDistrictID);
                    cmd.Parameters.AddWithValue("@IsActive", checkBoxActive.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@IsVerified", checkBoxVerified.Checked ? 1 : 0);

                    int rowsResult = cmd.ExecuteNonQuery();
                    if (rowsResult > 0)
                    {
                        MessageBox.Show("會員資料更新成功！");
                    }
                    else
                    {
                        MessageBox.Show("更新失敗！");
                    }
                }
            }
        }
        //刪除用戶
        private void butDeleteAcount_Click(object sender, EventArgs e)
        {

            // 確認是否要刪除帳號
            DialogResult result = MessageBox.Show(
                "確定要刪除此會員嗎？此操作無法復原！",
                "刪除確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            // 如果使用者選擇 "No"，則取消刪除
            if (result == DialogResult.No)
            {
                return;
            }


            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
                DELETE FROM 
                            Members 
                WHERE 
                            ID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", _userId);
                    int rowsResult = cmd.ExecuteNonQuery();
                    if (rowsResult > 0)
                    {
                        MessageBox.Show("會員資料已成功刪除！");
                    }
                    else
                    {
                        MessageBox.Show("刪除失敗！");
                    }
                }
            }
        }

        //變更圖片路徑到DB
        private void updateAvatarPathInDatabase(string avatarPath)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
                UPDATE 
                                Members 
                SET 
                                avatarPath = @AvatarPath
                WHERE 
                                 ID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", _userId);
                    cmd.Parameters.AddWithValue("@AvatarPath", avatarPath);

                    int rowsResult = cmd.ExecuteNonQuery();
                    if (rowsResult > 0)
                    {
                        MessageBox.Show("頭像更新成功！");
                    }
                    else
                    {
                        MessageBox.Show("更新失敗！");
                    }
                }
            }
        }

        //變更圖片
        private void butChangAvatar_Click(object sender, EventArgs e)
        {
            // 1. 打開檔案選擇器，讓用戶選擇圖片
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "選擇頭像圖片",
                Filter = "圖片檔案 (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 2. 獲取選擇的檔案路徑
                string selectedFilePath = openFileDialog.FileName;

                // 3. 確保 `Picture/avatar` 資料夾存在
                string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
                string avatarFolderPath = Path.Combine(projectRoot, "Picture", "avatar");
                Directory.CreateDirectory(avatarFolderPath);

                // 4. 產生新的檔名，避免重複 (使用 GUID)
                string newFileName = $"avatar_{Guid.NewGuid().ToString("N")}{Path.GetExtension(selectedFilePath)}";
                string newFilePath = Path.Combine(avatarFolderPath, newFileName);

                // 5. 複製圖片到 `Picture/avatar` 目錄
                File.Copy(selectedFilePath, newFilePath, true);

                // 6. 更新 UI 顯示新圖片
                pictureBoxAvatar.Image = Image.FromFile(newFilePath);

                // 7. 更新 SQL 資料庫，存相對路徑
                string relativePath = Path.Combine("Picture", "avatar", newFileName);
                updateAvatarPathInDatabase(relativePath);
            }
        }


    }
}
