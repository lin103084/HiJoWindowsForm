using prjLogin.Properties;
//using slnFriendshipBackEnd.Properties;
//using slnFriendshipBackEnd.UserControls;
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

namespace slnFriendshipBackEnd.Forms
{
    public enum FormMode
    {
        Add,    // 新增模式
        View,   // 檢視 / 修改模式
        Edit,   // 編輯模式
        Delete  // 刪除模式
    }

    public partial class FrmEventDetails : Form
    {
        string ConnectionString = Settings.Default.PCR7FriendshipConnectionString;
        private FormMode currentMode; // 目前模式
        private int eventID; // 儲存要編輯或刪除的活動 ID
        public FrmEventDetails(FormMode mode, int? eventID = null)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.currentMode = mode;
            this.eventID = eventID ?? 0;

            LoadEventTypes();
            LoadCities();

            InitializeForm();
        }

        private void LoadCities()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT cityID, cityName FROM [dbo].[cities]";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    comboBoxCity.DataSource = dataTable;
                    comboBoxCity.DisplayMember = "cityName"; // 顯示城市名稱
                    comboBoxCity.ValueMember = "cityID";     // 設定 `ValueMember`
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入地區失敗：" + ex.Message);
            }
        }

        private void LoadEventTypes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT eventTypeID, eventType FROM [dbo].[EventTypes]";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    comboBoxType.DataSource = dataTable;
                    comboBoxType.DisplayMember = "eventType";  // 顯示活動類型名稱
                    comboBoxType.ValueMember = "eventTypeID";  // 設定 `ValueMember`
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入活動類型失敗：" + ex.Message);
            }
        }

        private void InitializeForm()
        {
            switch (currentMode)
            {
                case FormMode.Add:
                    this.Text = "新增活動";
                    btnAdd.Visible = true;
                    btnCancel.Visible = true;
                    btnEdit.Visible = false;
                    btnSave.Visible = false;
                    btnDelete.Visible = false;
                    LockFields(false);
                    btnUploadCover.Enabled = true; // 允許上傳封面
                    btnUploadOther.Enabled = true; // 允許上傳其他照片
                    btnDeleteCover.Visible = true;  // 按鈕顯示但不可點
                    btnDeleteCover.Enabled = false;
                    break;

                case FormMode.View:
                    this.Text = "檢視 / 修改活動";
                    btnAdd.Visible = false;
                    btnCancel.Visible = true;
                    btnEdit.Visible = true;
                    btnSave.Visible = false;
                    btnDelete.Visible = false;
                    LoadEventData();
                    LockFields(true);
                    btnUploadCover.Enabled = false; // 禁止上傳封面
                    btnUploadOther.Enabled = false; // 禁止上傳其他照片
                    btnDeleteCover.Visible = false; // 隱藏刪除封面照片按鈕
                    break;

                case FormMode.Edit:
                    this.Text = "編輯活動";
                    btnAdd.Visible = false;
                    btnCancel.Visible = true;
                    btnEdit.Visible = false;
                    btnSave.Visible = true;
                    btnDelete.Visible = false;
                    LockFields(false);
                    btnUploadCover.Enabled = true; // 允許修改封面
                    btnUploadOther.Enabled = true; // 允許修改其他照片
                    btnDeleteCover.Visible = true; // 顯示刪除封面照片按鈕
                    btnDeleteCover.Enabled = pictureBox1.Image != null;

                    // 進入編輯模式時，補上 `X` 按鈕
                    foreach (Control control in flowLayoutPanel1.Controls)
                    {
                        if (control is Panel photoPanel)
                        {
                            PictureBox picBox = photoPanel.Controls.OfType<PictureBox>().FirstOrDefault();
                            if (picBox != null && !photoPanel.Controls.OfType<Button>().Any()) // 確保沒有按鈕才新增
                            {
                                string photoPath = picBox.Tag.ToString();
                                Button btnDeletePhoto = CreateDeleteButton(photoPath);
                                photoPanel.Controls.Add(btnDeletePhoto);
                                btnDeletePhoto.BringToFront();  // 確保按鈕在最上層
                            }
                        }
                    }
                    break;

                case FormMode.Delete:
                    this.Text = "刪除活動";
                    btnAdd.Visible = false;
                    btnCancel.Visible = true;
                    btnEdit.Visible = false;
                    btnSave.Visible = false;
                    btnDelete.Visible = true;
                    LoadEventData();
                    LockFields(true);
                    btnUploadCover.Enabled = false; // 禁止上傳封面
                    btnUploadOther.Enabled = false; // 禁止上傳其他照片
                    btnDeleteCover.Visible = false; // 隱藏刪除封面照片按鈕
                    break;

                default:
                    btnDeleteCover.Enabled = false; // 其他模式不允許刪除封面
                    break;
            }
        }

        private void LoadEventData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // 1️.讀取活動基本資料
                    string query = @"
                SELECT e.[name], e.[description], e.[eventTypeID], e.[cityID], 
                       e.[address], e.[latitude], e.[longitude]
                FROM [dbo].[Events] e
                WHERE e.eventID = @EventID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EventID", eventID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        textBoxName.Text = reader["name"].ToString();
                        textBoxDescription.Text = reader["description"].ToString();
                        textBoxAddress.Text = reader["address"].ToString();
                        textBoxLatitude.Text = reader["latitude"].ToString();
                        textBoxLongitude.Text = reader["longitude"].ToString();

                        // 設定 ComboBox 選擇對應的類型與城市
                        comboBoxType.SelectedValue = Convert.ToInt32(reader["eventTypeID"]);
                        comboBoxCity.SelectedValue = Convert.ToInt32(reader["cityID"]);
                    }
                    reader.Close();

                    // 2️.讀取封面圖片
                    query = "SELECT photo FROM [dbo].[EventPhotos] WHERE eventID = @EventID AND isCover = 1";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EventID", eventID);
                    object coverPhoto = cmd.ExecuteScalar();

                    if (coverPhoto != null)
                    {
                        string coverPhotoPath = GetAbsolutePath(coverPhoto.ToString());
                        if (File.Exists(coverPhotoPath))
                        {
                            pictureBox1.Image = Image.FromFile(coverPhotoPath);
                            pictureBox1.Tag = coverPhoto.ToString(); // 相對路徑
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }

                    // 3️.讀取其他圖片
                    query = "SELECT photo FROM [dbo].[EventPhotos] WHERE eventID = @EventID AND isCover = 0";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EventID", eventID);
                    SqlDataReader photoReader = cmd.ExecuteReader();

                    flowLayoutPanel1.Controls.Clear(); // 清除flowLayoutPanel1
                    while (photoReader.Read())
                    {
                        string photoPath = photoReader["photo"].ToString();
                        string absolutePath = GetAbsolutePath(photoPath);
                        if (File.Exists(absolutePath))
                        {
                            AddPhotoToFlowPanel(photoPath, true);
                        }
                    }
                    photoReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入活動資料失敗：" + ex.Message);
            }
        }

        private void DeletePhotoButton_Click(object sender, EventArgs e)
        {
            Button deleteButton = sender as Button;
            string photoPath = deleteButton.Tag.ToString();

            DialogResult result = MessageBox.Show("確定要刪除此照片嗎？", "確認刪除", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM [dbo].[EventPhotos] WHERE eventID = @EventID AND photo = @PhotoPath";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@EventID", eventID);
                        cmd.Parameters.AddWithValue("@PhotoPath", photoPath);
                        cmd.ExecuteNonQuery();
                    }

                    // 同步從 UI 刪除
                    Panel parentPanel = deleteButton.Parent as Panel;
                    if (parentPanel != null)
                    {
                        flowLayoutPanel1.Controls.Remove(parentPanel);
                        parentPanel.Dispose();  // 釋放資源
                    }

                    MessageBox.Show("照片已刪除");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("刪除照片失敗：" + ex.Message);
                }
            }
        }

        private void btnDeleteCover_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Tag == null)
            {
                MessageBox.Show("目前沒有封面照片可刪除！");
                return;
            }

            DialogResult result = MessageBox.Show("確定要刪除此封面照片嗎？", "確認刪除", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM [dbo].[EventPhotos] WHERE eventID = @EventID AND isCover = 1";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@EventID", eventID);
                        cmd.ExecuteNonQuery();

                        // 清空 UI 顯示
                        pictureBox1.Image = null;
                        pictureBox1.Tag = null;
                        btnDeleteCover.Enabled = false; // 反灰刪除封面按鈕

                        MessageBox.Show("封面照片已刪除");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("刪除封面照片失敗：" + ex.Message);
                }
            }
        }


        private void LockFields(bool lockFields)
        {
            textBoxName.ReadOnly = lockFields;
            textBoxDescription.ReadOnly = lockFields;
            textBoxAddress.ReadOnly = lockFields;
            textBoxLatitude.ReadOnly = lockFields;
            textBoxLongitude.ReadOnly = lockFields;
            comboBoxType.Enabled = !lockFields;
            comboBoxCity.Enabled = !lockFields;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction(); // 用Transaction交易包起新增活動+新增活動照片兩個動作

                    try
                    {
                        // 1️.新增活動基本資料
                        string query = "INSERT INTO [dbo].[Events] ([name], [description], [eventTypeID], [cityID], [address], [latitude], [longitude]) " +
                                       "OUTPUT INSERTED.eventID VALUES (@Name, @Description, @TypeID, @CityID, @Address, @Latitude, @Longitude)";

                        SqlCommand cmd = new SqlCommand(query, conn, transaction);
                        cmd.Parameters.AddWithValue("@Name", textBoxName.Text);
                        cmd.Parameters.AddWithValue("@Description", textBoxDescription.Text);
                        cmd.Parameters.AddWithValue("@TypeID", comboBoxType.SelectedValue);
                        cmd.Parameters.AddWithValue("@CityID", comboBoxCity.SelectedValue);
                        cmd.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                        cmd.Parameters.AddWithValue("@Latitude", Convert.ToDouble(textBoxLatitude.Text));
                        cmd.Parameters.AddWithValue("@Longitude", Convert.ToDouble(textBoxLongitude.Text));

                        int newEventID = (int)cmd.ExecuteScalar(); // 取得新活動的 eventID

                        // 2️.儲存封面圖片（如果有）
                        if (pictureBox1.Tag != null)
                        {
                            string coverPhotoPath = SaveImageAndGetRelativePath(pictureBox1.Tag.ToString());
                            query = "INSERT INTO [dbo].[EventPhotos] (eventID, photo, isCover) VALUES (@EventID, @PhotoPath, 1)";
                            cmd = new SqlCommand(query, conn, transaction);
                            cmd.Parameters.AddWithValue("@EventID", newEventID);
                            cmd.Parameters.AddWithValue("@PhotoPath", coverPhotoPath);
                            cmd.ExecuteNonQuery();
                        }

                        // 3️.儲存其他照片
                        foreach (Control control in flowLayoutPanel1.Controls)
                        {
                            if (control is Panel panel)
                            {
                                PictureBox picBox = panel.Controls.OfType<PictureBox>().FirstOrDefault();
                                if (picBox != null && picBox.Tag != null)
                                {
                                    string photoPath = SaveImageAndGetRelativePath(picBox.Tag.ToString());

                                    query = "INSERT INTO [dbo].[EventPhotos] (eventID, photo, isCover) VALUES (@EventID, @PhotoPath, 0)";
                                    cmd = new SqlCommand(query, conn, transaction);
                                    cmd.Parameters.AddWithValue("@EventID", newEventID);
                                    cmd.Parameters.AddWithValue("@PhotoPath", photoPath);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("活動已新增");

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("新增失敗：" + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增失敗：" + ex.Message);
            }
        }        

        private void btnEdit_Click(object sender, EventArgs e)
        {
            currentMode = FormMode.Edit;
            InitializeForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // 1️.更新活動基本資料
                        string query = @"
                    UPDATE [dbo].[Events] 
                    SET [name] = @Name, [description] = @Description, 
                        [eventTypeID] = @TypeID, [cityID] = @CityID, 
                        [address] = @Address, [latitude] = @Latitude, [longitude] = @Longitude 
                    WHERE eventID = @EventID";

                        SqlCommand cmd = new SqlCommand(query, conn, transaction);
                        cmd.Parameters.AddWithValue("@EventID", eventID);
                        cmd.Parameters.AddWithValue("@Name", textBoxName.Text);
                        cmd.Parameters.AddWithValue("@Description", textBoxDescription.Text);
                        cmd.Parameters.AddWithValue("@TypeID", comboBoxType.SelectedValue);
                        cmd.Parameters.AddWithValue("@CityID", comboBoxCity.SelectedValue);
                        cmd.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                        cmd.Parameters.AddWithValue("@Latitude", Convert.ToDouble(textBoxLatitude.Text));
                        cmd.Parameters.AddWithValue("@Longitude", Convert.ToDouble(textBoxLongitude.Text));
                        cmd.ExecuteNonQuery();

                        // 2️.儲存封面圖片（如果有變更）
                        if (pictureBox1.Tag != null)
                        {
                            string newCoverPath = pictureBox1.Tag.ToString();

                            // 確認是否已經存在
                            query = "SELECT COUNT(*) FROM [dbo].[EventPhotos] WHERE eventID = @EventID AND isCover = 1";
                            cmd = new SqlCommand(query, conn, transaction);
                            cmd.Parameters.AddWithValue("@EventID", eventID);
                            int coverCount = (int)cmd.ExecuteScalar();

                            if (coverCount == 0) // 如果資料庫內沒有封面，才插入
                            {
                                query = "INSERT INTO [dbo].[EventPhotos] (eventID, photo, isCover) VALUES (@EventID, @PhotoPath, 1)";
                                cmd = new SqlCommand(query, conn, transaction);
                                cmd.Parameters.AddWithValue("@EventID", eventID);
                                cmd.Parameters.AddWithValue("@PhotoPath", newCoverPath);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 3️.儲存「新的」其他照片
                        foreach (Control control in flowLayoutPanel1.Controls)
                        {
                            if (control is Panel panel)
                            {
                                PictureBox picBox = panel.Controls.OfType<PictureBox>().FirstOrDefault();
                                if (picBox != null && picBox.Tag != null)
                                {
                                    string photoPath = picBox.Tag.ToString();

                                    // 確認是否已存在
                                    query = "SELECT COUNT(*) FROM [dbo].[EventPhotos] WHERE eventID = @EventID AND photo = @PhotoPath";
                                    cmd = new SqlCommand(query, conn, transaction);
                                    cmd.Parameters.AddWithValue("@EventID", eventID);
                                    cmd.Parameters.AddWithValue("@PhotoPath", photoPath);
                                    int count = (int)cmd.ExecuteScalar();

                                    if (count == 0) // 只存新的
                                    {
                                        query = "INSERT INTO [dbo].[EventPhotos] (eventID, photo, isCover) VALUES (@EventID, @PhotoPath, 0)";
                                        cmd = new SqlCommand(query, conn, transaction);
                                        cmd.Parameters.AddWithValue("@EventID", eventID);
                                        cmd.Parameters.AddWithValue("@PhotoPath", photoPath);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("活動已更新");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("更新失敗：" + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新失敗：" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要刪除此活動嗎？", "確認刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();

                        // 檢查是否有對應的活動梯次
                        string checkBatchQuery = "SELECT COUNT(*) FROM [dbo].[Batches] WHERE eventID = @EventID";
                        SqlCommand checkBatchCmd = new SqlCommand(checkBatchQuery, conn);
                        checkBatchCmd.Parameters.AddWithValue("@EventID", eventID);
                        int batchCount = (int)checkBatchCmd.ExecuteScalar();

                        if (batchCount > 0) // 如果活動仍有對應梯次，禁止刪除
                        {
                            MessageBox.Show("無法刪除該活動，因為仍有對應的活動梯次。", "刪除失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        // 用交易包刪除的兩個動作（先刪活動照片再刪活動，才不會有FK錯誤）
                        SqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            // 先刪除活動的所有照片
                            string deletePhotosQuery = "DELETE FROM [dbo].[EventPhotos] WHERE eventID = @EventID";
                            SqlCommand deletePhotosCmd = new SqlCommand(deletePhotosQuery, conn, transaction);
                            deletePhotosCmd.Parameters.AddWithValue("@EventID", eventID);
                            deletePhotosCmd.ExecuteNonQuery();

                            // 再刪除活動
                            string deleteEventQuery = "DELETE FROM [dbo].[Events] WHERE eventID = @EventID";
                            SqlCommand deleteEventCmd = new SqlCommand(deleteEventQuery, conn, transaction);
                            deleteEventCmd.Parameters.AddWithValue("@EventID", eventID);
                            deleteEventCmd.ExecuteNonQuery();

                            transaction.Commit();
                            MessageBox.Show("活動已成功刪除。", "刪除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("刪除失敗：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("刪除失敗：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUploadCover_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "圖片檔案 (*.jpg; *.png; *.jpeg)|*.jpg;*.png;*.jpeg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string newCoverPath = SaveImageAndGetRelativePath(ofd.FileName);

                    // 檢查是否已有舊封面
                    if (pictureBox1.Tag != null)
                    {
                        string oldCoverPath = pictureBox1.Tag.ToString();

                        // 將舊封面轉為一般照片（isCover = 0）
                        using (SqlConnection conn = new SqlConnection(ConnectionString))
                        {
                            conn.Open();
                            string query = "UPDATE [dbo].[EventPhotos] SET isCover = 0 WHERE eventID = @EventID AND photo = @OldPhoto";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@EventID", eventID);
                            cmd.Parameters.AddWithValue("@OldPhoto", oldCoverPath);
                            cmd.ExecuteNonQuery();
                        }

                        // 將舊封面加入 FlowLayoutPanel
                        AddPhotoToFlowPanel(oldCoverPath, true);
                    }

                    // 更新封面 UI
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                    pictureBox1.Tag = newCoverPath;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    btnDeleteCover.Enabled = true;
                }
            }
        }

        private void btnUploadOther_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "圖片檔案 (*.jpg; *.png; *.jpeg)|*.jpg;*.png;*.jpeg";
                ofd.Multiselect = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string filePath in ofd.FileNames)
                    {
                        string relativePath = SaveImageAndGetRelativePath(filePath);
                        AddPhotoToFlowPanel(relativePath, true);
                    }
                }
            }
        }

        private void AddPhotoToFlowPanel(string photoPath, bool allowDelete)
        {
            Panel photoPanel = new Panel
            {
                Size = new Size(130, 130),
                Margin = new Padding(5),
                BackColor = Color.LightGray
            };

            PictureBox picBox = new PictureBox
            {
                Image = Image.FromFile(photoPath),
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = 120,
                Height = 120,
                Tag = photoPath,
                Location = new Point(5, 5)
            };

            photoPanel.Controls.Add(picBox);

            // 只有在「新增模式」或「編輯模式」才會顯示X刪除按鈕
            if ((currentMode == FormMode.Add || currentMode == FormMode.Edit) && allowDelete)
            {
                Button btnDeletePhoto = CreateDeleteButton(photoPath);
                photoPanel.Controls.Add(btnDeletePhoto);
                btnDeletePhoto.BringToFront();
            }

            flowLayoutPanel1.Controls.Add(photoPanel);
        }

        private Button CreateDeleteButton(string photoPath)
        {
            Button btnDeletePhoto = new Button
            {
                Text = "X",
                Tag = photoPath,
                Size = new Size(25, 25),
                BackColor = Color.Red,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnDeletePhoto.FlatAppearance.BorderSize = 0;
            btnDeletePhoto.Click += DeletePhotoButton_Click;

            // 確保 `X` 按鈕在 Panel 右上角
            btnDeletePhoto.Location = new Point(130 - btnDeletePhoto.Width - 5, 5);
            btnDeletePhoto.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            return btnDeletePhoto;
        }

        private string SaveImageAndGetRelativePath(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                return null;

            string relativeFolder = "Images/Events/"; // 相對路徑
            string projectPath = AppDomain.CurrentDomain.BaseDirectory; // 應用程式的根目錄
            string saveDirectory = Path.Combine(projectPath, relativeFolder);

            // 確保資料夾存在
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }

            // 取得檔案名稱（包含副檔名）
            string fileName = Path.GetFileName(imagePath);
            string savePath = Path.Combine(saveDirectory, fileName); // 完整存放路徑

            // 確保檔案不重複存入
            if (!File.Exists(savePath))
            {
                File.Copy(imagePath, savePath);
            }

            // 回傳相對路徑（存入資料庫）
            return Path.Combine(relativeFolder, fileName).Replace("\\", "/"); // 確保統一使用 `/`
        }

        private string GetAbsolutePath(string relativePath)
        {
            if (string.IsNullOrEmpty(relativePath)) return null;

            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(projectPath, relativePath).Replace("\\", "/");
        }
    }
}
