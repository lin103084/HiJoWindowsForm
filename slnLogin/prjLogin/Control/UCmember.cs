using prjLogin.Frm;
using prjLogin.Properties;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
//using Microsoft.VisualBasic;

namespace prjLogin.Control
{
    public partial class UCmember : UserControl
    {
        string ConnectionString = Settings.Default.PCR7FriendshipConnectionString;
        
        public UCmember()
        {
            InitializeComponent();

            //UC  + Tabcontrol  設置
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.MinimumSize = new Size(300, 200);
            this.Dock = DockStyle.Fill;
            this.uitabControlMember.Dock = DockStyle.Fill;

            this.AutoScroll = true;                                          //滾動開啟
            this.uidataGridViewMember.ReadOnly = true;//DataGridView只能讀取

        
            //-------------------- 會員管理 --------------------
            loadDate();      //載入日期
            loadActive();   //載入帳號使用狀態
            loadVerified();//載入帳號驗證狀態
            loadRole();      //載入權限類別
            loadCities();   // 載入縣市
            loadData();     //載入當前篩選
            AddDetailButton();  // 新增「查看詳細」按鈕

            //-------------------- 興趣管理 --------------------
            loadTreeView();

            // 建立右鍵選單
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            // 選單項目 - 新增類別
            ToolStripMenuItem addCategory = new ToolStripMenuItem("新增類別");
            addCategory.Click += butAddCategory_Click;
            contextMenu.Items.Add(addCategory);

            // 選單項目 - 新增興趣
            ToolStripMenuItem addInterest = new ToolStripMenuItem("新增興趣");
            addInterest.Click += butAddInterest_Click;
            contextMenu.Items.Add(addInterest);

            // 選單項目 - 刪除
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("刪除");
            deleteItem.Click += butDeleteInterest_Click;
            contextMenu.Items.Add(deleteItem);

            
            // 選單項目 - 收合開關
            ToolStripMenuItem  butSwitch = new ToolStripMenuItem("收合開關");
            butSwitch.Click += butSwitch_Click;
            contextMenu.Items.Add(butSwitch);

            // 將 ContextMenuStrip 附加到 TreeView
            uitreeViewInterests.ContextMenuStrip = contextMenu;



        }







        //==================== PG1 會員管理 ====================
        //創建DataGridView 詳細按鈕
        private void AddDetailButton()
        {
            if (uidataGridViewMember.Columns["DetailButton"] == null) // 確保不重複添加
            {
                DataGridViewButtonColumn detailButton = new DataGridViewButtonColumn();
                detailButton.Name = "DetailButton";
                detailButton.HeaderText = "詳情";
                detailButton.Text = "詳情/編輯";
                detailButton.UseColumnTextForButtonValue = true;
                uidataGridViewMember.Columns.Add(detailButton);
            }
        }
        //DataGridView詳細資料按鈕
        private void uidataGridViewMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (uidataGridViewMember.Columns[e.ColumnIndex].Name == "DetailButton") // 確保點擊的是DetailButton
            {
                string userId = uidataGridViewMember.Rows[e.RowIndex].Cells["ID"].Value.ToString(); // 取得會員 ID
                FrmMemberDetail detailForm = new FrmMemberDetail(userId);
                detailForm.ShowDialog();
            }
            
        }

        //載入日期
        private void loadDate()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
                SELECT 
                            MAX(birthday) AS MaxBirthday, 
                            MIN(birthday) AS MinBirthday 
                FROM 
                           members;";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // 確保不為 DBNull
                    if (reader["MinBirthday"] != DBNull.Value && reader["MaxBirthday"] != DBNull.Value)
                    {
                        DateTime minDate = Convert.ToDateTime(reader["MinBirthday"]);
                        DateTime maxDate = Convert.ToDateTime(reader["MaxBirthday"]);

                        // 設定 DateTimePicker 的值
                        uidateTimePickerStart.Value = minDate;
                        uidateTimePickerEnd.Value = maxDate;

                        // 設定 DateTimePicker 的範圍，防止超出區間
                        uidateTimePickerStart.MinDate = minDate;
                        uidateTimePickerStart.MaxDate = maxDate;
                        uidateTimePickerEnd.MinDate = minDate;
                        uidateTimePickerEnd.MaxDate = maxDate;
                        //uiDatePicker1.MaxDate
                    }
                }
                reader.Close();
            }

        }
        //載入帳號使用狀態
        private void loadActive()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
                SELECT 
                             DISTINCT isActive, 
                CASE 
                              WHEN isActive = 1 THEN '啟用' 
                                                                    ELSE '停用' 
                END 
                              AS isActiveText
                FROM 
                            members;";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                uicomboBoxActive.DisplayMember = "isActiveText"; // 顯示 "正常" 或 "失效"
                uicomboBoxActive.ValueMember = "isActive"; // 儲存 0 或 1
                uicomboBoxActive.DataSource = dt;
                uicomboBoxActive.SelectedIndex = -1; // 預設不選擇
            }
        }
        //載入帳號驗證狀態
        private void loadVerified()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = @"
                 SELECT 
                            DISTINCT 
                            isVerified, 
                            CASE 
                                    WHEN isVerified = 1 THEN '已驗證' 
                                                                            ELSE '未驗證' 
                            END 
                                    AS isVerifiedText
                 FROM 
                            members;";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                uicomboBoxVerified.DisplayMember = "isVerifiedText"; // 顯示 "正常" 或 "失效"
                uicomboBoxVerified.ValueMember = "isVerified"; // 儲存 0 或 1
                uicomboBoxVerified.DataSource = dt;
                uicomboBoxVerified.SelectedIndex = -1; // 預設不選擇
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
                
                uicomboBoxRole.DisplayMember = "roleName"; // 顯示角色名稱
                uicomboBoxRole.ValueMember = "roleID";     // 內部儲存 roleID
                uicomboBoxRole.DataSource = dt;            // 綁定 DataTable
                uicomboBoxRole.SelectedIndex = -1;         // 預設不選擇
            }
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

                uicomboBoxCities.DisplayMember = "cityName";
                uicomboBoxCities.ValueMember = "cityID";
                uicomboBoxCities.DataSource = dt;
                uicomboBoxCities.SelectedIndex = -1; // 預設不選擇
            }
        }
        // 載入地區 
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
                
                uicomboBoxDistrict.DisplayMember = "districtName";
                uicomboBoxDistrict.ValueMember = "districtID";
                uicomboBoxDistrict.DataSource = dt;
                uicomboBoxDistrict.SelectedIndex = -1; // 預設不選擇
            }
        }
        // 根據縣市，變更該地區選項
        private void uicomboBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uicomboBoxCities.SelectedValue != null)
            {
                int citiesID = Convert.ToInt32(uicomboBoxCities.SelectedValue);
                loadDistricts(citiesID);
            }
        }
        // 呈現結果到DataGridView
        private void loadData()
        {
            DataSet dataSet = new DataSet();
            BindingSource bindingSource = new BindingSource();

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConnectionString;
                    conn.Open();

                    // 建立 SQL 查詢
                    string query = @"
                    SELECT 
                                r.Name as '權限類',
                                m.ID  as 'ID',
                                m.userName as '名稱',
                                m.email,
                                m.sex as '性別',
                                m.birthday as '生日',
                                c.cityName as '縣市',
                                d.districtName as '地區',
                                m.isActive as '帳號狀態',
                                m.isVerified as '驗證狀態'
                    FROM
                                Roles r
                    JOIN
                                MemberRoles mr ON r.ID = mr.roleID
                    JOIN
                                Members m ON mr.memberID = m.ID
                    LEFT JOIN
                                Cities c ON m.cityID = c.cityID
                    LEFT JOIN 
                                Districts d ON m.districtID = d.districtID
                    WHERE 
                                1=1"; // 1=1 讓後續條件可動態添加

                    // 建立 SQL 參數
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    //當ID不為空就添加
                    if (!string.IsNullOrEmpty(uitextBoxID.Text.Trim()))
                    {
                        query += " AND m.ID = @ID";
                        cmd.Parameters.AddWithValue("@ID", uitextBoxID.Text.Trim());
                    }
                    //當UserName不為空就添加
                    if (!string.IsNullOrEmpty(uitextBoxUserName.Text.Trim()))
                    {
                        query += " AND m.userName LIKE @UserName";
                        cmd.Parameters.AddWithValue("@UserName", "%" + uitextBoxUserName.Text.Trim() + "%");
                    }
                    //當Email不為空就添加
                    if (!string.IsNullOrEmpty(uitextBoxEmail.Text.Trim()))
                    {
                        query += " AND m.email LIKE @Email";
                        cmd.Parameters.AddWithValue("@Email", "%" + uitextBoxEmail.Text.Trim() + "%");
                    }
                    //當CityID不為空就添加
                    if (uicomboBoxCities.SelectedValue != null)
                    {
                        query += " AND m.cityID = @CityID";
                        cmd.Parameters.AddWithValue("@CityID", uicomboBoxCities.SelectedValue);
                    }
                    //當DistrictID不為空就添加
                    if (uicomboBoxDistrict.SelectedValue != null)
                    {
                        query += " AND m.districtID = @DistrictID";
                        cmd.Parameters.AddWithValue("@DistrictID", uicomboBoxDistrict.SelectedValue);
                    }
                    //帳號使用狀態
                    if (uicomboBoxActive.SelectedValue != null)
                    {
                        query += " AND m.isActive = @isActive";
                        cmd.Parameters.AddWithValue("@isActive", uicomboBoxActive.SelectedValue);
                    }
                    //帳號是否驗證
                    if (uicomboBoxVerified.SelectedValue != null)
                    {
                        query += " AND m.isVerified = @isVerified";
                        cmd.Parameters.AddWithValue("@isVerified", uicomboBoxVerified.SelectedValue);
                    }
                    //當角色權限
                    if (uicomboBoxRole.SelectedValue != null)
                    {
                        query += " AND  r.ID = @rolesID";
                        cmd.Parameters.AddWithValue("@rolesID", uicomboBoxRole.SelectedValue);
                    }
                    //查詢在日期內
                    query += " AND birthday >= @uidateTimePickerStart AND birthday <= @uidateTimePickerEnd";

                    //確保只取日期，避免時間影響 SQL 查詢：
                    cmd.Parameters.AddWithValue("@uidateTimePickerStart", uidateTimePickerStart.Value.Date);
                    cmd.Parameters.AddWithValue("@uidateTimePickerEnd", uidateTimePickerEnd.Value.Date.AddDays(1).AddTicks(-1));

                    //query += " ORDER BY r.Name, m.userName";
                    query += " ORDER BY m.ID;";

                    cmd.CommandText = query;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.Fill(dataSet);

                    // 綁定 DataGridView
                    bindingSource.DataSource = dataSet.Tables[0];
                    uidataGridViewMember.DataSource = bindingSource;
                    uidataGridViewMember.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;                      
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"錯誤 : {ex.Message}");
            }
        }
        // 搜尋
        private void uibutSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }
        //清空
        private void uibutClear_Click(object sender, EventArgs e)
        {
            this.uitextBoxID.Text = "";
            this.uitextBoxUserName.Text = "";
            this.uitextBoxEmail.Text = "";

            this.uicomboBoxVerified.SelectedIndex = -1;
            this.uicomboBoxRole.SelectedIndex = -1;
            this.uicomboBoxActive.SelectedIndex = -1;
            this.uicomboBoxCities.SelectedIndex = -1;
            this.uicomboBoxDistrict.SelectedIndex = -1;

        }
        //新增會員
        private void uibutAddMember_Click(object sender, EventArgs e)
        {
            new FrmAddMember().Show();
        }


        //==================== PG2 興趣管理 ====================

        //讀取Treeview
        private void loadTreeView()
        {
            // 清空 TreeView
            uitreeViewInterests.Nodes.Clear();

            // 建立 Dictionary 來快速查找 Category 節點
            Dictionary<int, TreeNode> categoryNodes = new Dictionary<int, TreeNode>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                // 取得所有類別
                string categoryQuery = @"
                SELECT 
                            id, 
                            name 
                FROM 
                            InterestCategories 
                ORDER BY 
                            name";
                using (SqlCommand categoryCmd = new SqlCommand(categoryQuery, conn))
                using (SqlDataReader categoryReader = categoryCmd.ExecuteReader())
                {
                    while (categoryReader.Read())
                    {
                        int categoryID = categoryReader["id"] != DBNull.Value ? Convert.ToInt32(categoryReader["id"]) : 0;
                        string categoryName = categoryReader["name"].ToString();

                        TreeNode categoryNode = new TreeNode(categoryName)
                        {
                            Tag = categoryID // 存類別 ID
                        };
                        uitreeViewInterests.Nodes.Add(categoryNode);

                        // 加入 Dictionary 方便快速查找
                        categoryNodes[categoryID] = categoryNode;
                    }
                }

                // 取得所有興趣
                string interestQuery = @"
                SELECT 
                            id, 
                            name, 
                            categoryID 
                FROM 
                            Interests 
                ORDER BY 
                            name";
                using (SqlCommand interestCmd = new SqlCommand(interestQuery, conn))
                using (SqlDataReader interestReader = interestCmd.ExecuteReader())
                {
                    while (interestReader.Read())
                    {
                        int interestID = interestReader["id"] != DBNull.Value ? Convert.ToInt32(interestReader["id"]) : 0;
                        string interestName = interestReader["name"].ToString();
                        int categoryID = interestReader["categoryID"] != DBNull.Value ? Convert.ToInt32(interestReader["categoryID"]) : 0;

                        // 確保該類別存在
                        if (categoryNodes.TryGetValue(categoryID, out TreeNode categoryNode))
                        {
                            TreeNode interestNode = new TreeNode(interestName)
                            {
                                Tag = interestID // 存興趣 ID
                            };
                            categoryNode.Nodes.Add(interestNode);
                        }
                    }
                }
            }

            uitreeViewInterests.ExpandAll(); // 展開所有節點
            
        }
        //增加興趣類別
        private void butAddCategory_Click(object sender, EventArgs e)
        {
            string categoryName = Microsoft.VisualBasic.Interaction.InputBox("請輸入類別名稱:", "新增類別", "");
            //string input = Interaction.InputBox("請輸入類別名稱:", "新增類別", "");
            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO InterestCategories (name) VALUES (@name)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", categoryName);
                        cmd.ExecuteNonQuery();
                    }
                }

                loadTreeView(); // 重新載入
            }
        }
        //增加該類別的興趣
        private void butAddInterest_Click(object sender, EventArgs e)
        {
            if (uitreeViewInterests.SelectedNode == null || uitreeViewInterests.SelectedNode.Parent != null)
            {
                MessageBox.Show("請先選擇一個類別！");
                return;
            }

            string interestName = Microsoft.VisualBasic.Interaction.InputBox("請輸入興趣名稱:", "新增興趣", "");

            if (!string.IsNullOrWhiteSpace(interestName))
            {
                int categoryID = (int)uitreeViewInterests.SelectedNode.Tag;

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                    INSERT INTO 
                                 Interests (name, categoryID) 
                    VALUES 
                                (@name, @categoryID)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", interestName);
                        cmd.Parameters.AddWithValue("@categoryID", categoryID);
                        cmd.ExecuteNonQuery();
                    }
                }

                loadTreeView(); // 重新載入
            }

        }
        //刪除Node
        private void DeleteSelectedNode()
        {
            if (uitreeViewInterests.SelectedNode == null)
            {
                MessageBox.Show("請先選擇要刪除的項目！");
                return;
            }

            int selectedID = (int)uitreeViewInterests.SelectedNode.Tag;
            bool isCategory = uitreeViewInterests.SelectedNode.Parent == null;

            DialogResult result = MessageBox.Show($"確定要刪除 \"{uitreeViewInterests.SelectedNode.Text}\" 嗎？", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return; // 如果選擇 "否"，就取消刪除
            }

            string query = isCategory
                ? @"DELETE FROM 
                                    InterestCategories 
                         WHERE 
                                     id = @id"
                : @"DELETE FROM 
                                    Interests 
                        WHERE 
                                    id = @id";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", selectedID);
                    cmd.ExecuteNonQuery();
                }
            }

            uitreeViewInterests.SelectedNode.Remove(); // 從 TreeView 移除節點
        }
        //刪除Node按鈕
        private void butDeleteInterest_Click(object sender, EventArgs e)
        {
            DeleteSelectedNode();
        }








        //收合開關
        private bool isExpanded = true; // 狀態記錄是否已展
        private void switchTreeView()
        {
            if (isExpanded)
            {
                uitreeViewInterests.CollapseAll(); // 收合所有節點
                isExpanded = false;
            }
            else
            {
                uitreeViewInterests.ExpandAll(); // 展開所有節點
                isExpanded = true;
            }
        }
        //收合按鈕
        private void butSwitch_Click(object sender, EventArgs e)
        {
            switchTreeView();
        }


        private void uitreeViewInterests_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null)
            {
                // 這裡假設 "細部興趣" 的節點不會有子節點，類別會有
                if (e.Node.Parent != null) // 確保這是興趣，而不是興趣類別
                {
                    int interestId = Convert.ToInt32(e.Node.Tag); // 取得選擇的興趣 ID
                    loadMembersByInterest(interestId); // 載入該興趣的會員
                }
            }
        }

        private void loadMembersByInterest(int interestId)
        {

            // 清空右側顯示的會員列表
            flowLayoutPanelMembers.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string query = @"
                SELECT  TOP 50
                            m.ID, 
                            m.userName, 
                            m.avatarPath 
                FROM 
                            members m
                JOIN 
                            memberInterests mi 
                ON 
                            m.ID = mi.memberID
                WHERE 
                            mi.interestID = @interestID
                GROUP BY 
                            m.ID, 
                            m.userName, 
                            m.avatarPath
                ORDER BY 
                             NEWID()";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@interestID", interestId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int memberId = Convert.ToInt32(reader["ID"]);
                    string userName = reader["userName"].ToString();
                    string avatarPath = reader["avatarPath"] != DBNull.Value ? reader["avatarPath"].ToString() : "default.png";

                    AddMemberCard(memberId, userName, avatarPath);
                }
            }
        }

        private void AddMemberCard(int memberId, string userName, string avatarPath)
        {
            // 創建 Panel 作為會員卡片
            Panel memberCard = new Panel
            {
                Width = 120,
                Height = 160,
                BorderStyle = BorderStyle.Fixed3D,
                Margin = new Padding(10),
                Tag = memberId // 設定會員 ID
            };

            // 創建 PictureBox 放會員頭貼
            PictureBox picture = new PictureBox
            {
                Width = 100,
                Height = 100,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = LoadImage(avatarPath),
                Cursor = Cursors.Hand
            };

            // **讓 PictureBox 水平置中**
            picture.Left = (memberCard.Width - picture.Width) / 2;
            picture.Top = 10; // 預留一些空間

            // 創建 Label 顯示會員名稱
            Label lblName = new Label
            {
                Text = userName,
                AutoSize = false,
                Width = memberCard.Width,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom
            };

            // 加入點擊事件 (可以做更多操作)
            picture.Click += (s, e) => MessageBox.Show($"會員 ID：{memberId}\n名稱：{userName}");

            // **手動調整 PictureBox 的對齊方式**
            picture.Anchor = AnchorStyles.Top;
            lblName.Anchor = AnchorStyles.Bottom;

            // **使用 TableLayoutPanel 來確保 PictureBox 和 Label 居中**
            TableLayoutPanel layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 80)); // 80% 高度給 PictureBox
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 20)); // 20% 高度給 Label

            layout.Controls.Add(picture, 0, 0);
            layout.Controls.Add(lblName, 0, 1);

            // 加入到 Panel
            memberCard.Controls.Add(layout);

            // 加入到 FlowLayoutPanel
            flowLayoutPanelMembers.Controls.Add(memberCard);
        }

        private Image LoadImage(string avatarPath)
        {
            // 獲取專案的根目錄
            string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));

            // 設定頭像圖片的完整路徑
            string fullPath = Path.Combine(projectRoot, avatarPath);

            // 確保圖片存在，否則載入預設頭像
            string defaultAvatarPath = Path.Combine(projectRoot, "Picture", "avatar", "avatar4.png");

            return File.Exists(fullPath) ? Image.FromFile(fullPath) : Image.FromFile(defaultAvatarPath);
        }

        
    }
}