namespace prjLogin.Control
{
    partial class UCmember
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.uibutAddMember = new Sunny.UI.UIButton();
            this.uibutClear = new Sunny.UI.UIButton();
            this.uibutSearch = new Sunny.UI.UIButton();
            this.uidateTimePickerStart = new Sunny.UI.UIDatePicker();
            this.uidateTimePickerEnd = new Sunny.UI.UIDatePicker();
            this.uicomboBoxDistrict = new Sunny.UI.UIComboBox();
            this.uicomboBoxActive = new Sunny.UI.UIComboBox();
            this.uicomboBoxVerified = new Sunny.UI.UIComboBox();
            this.uicomboBoxRole = new Sunny.UI.UIComboBox();
            this.uicomboBoxCities = new Sunny.UI.UIComboBox();
            this.uitextBoxEmail = new Sunny.UI.UITextBox();
            this.uitextBoxUserName = new Sunny.UI.UITextBox();
            this.uiLabelBirthdayEnd = new Sunny.UI.UILabel();
            this.uitextBoxID = new Sunny.UI.UITextBox();
            this.uiLabelDistrict = new Sunny.UI.UILabel();
            this.uiLabelBirthdayStart = new Sunny.UI.UILabel();
            this.uiLabelActive = new Sunny.UI.UILabel();
            this.uiLabelCities = new Sunny.UI.UILabel();
            this.uiLabelRole = new Sunny.UI.UILabel();
            this.uiLabelEmail = new Sunny.UI.UILabel();
            this.uiLabelVerified = new Sunny.UI.UILabel();
            this.uiLabelUserName = new Sunny.UI.UILabel();
            this.uiLabelID = new Sunny.UI.UILabel();
            this.uidataGridViewMember = new Sunny.UI.UIDataGridView();
            this.uiSplitContainer1 = new Sunny.UI.UISplitContainer();
            this.uitreeViewInterests = new Sunny.UI.UITreeView();
            this.flowLayoutPanelMembers = new System.Windows.Forms.FlowLayoutPanel();
            this.but = new System.Windows.Forms.Button();
            this.butAddCategory = new System.Windows.Forms.Button();
            this.butAddInterest = new System.Windows.Forms.Button();
            this.butDeleteInterest = new System.Windows.Forms.Button();
            this.uitabControlMember = new Sunny.UI.UITabControl();
            this.tabPageMembers = new System.Windows.Forms.TabPage();
            this.tabPageInterest = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uidataGridViewMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer1)).BeginInit();
            this.uiSplitContainer1.Panel1.SuspendLayout();
            this.uiSplitContainer1.Panel2.SuspendLayout();
            this.uiSplitContainer1.SuspendLayout();
            this.uitabControlMember.SuspendLayout();
            this.tabPageMembers.SuspendLayout();
            this.tabPageInterest.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.uibutAddMember);
            this.splitContainer1.Panel1.Controls.Add(this.uibutClear);
            this.splitContainer1.Panel1.Controls.Add(this.uibutSearch);
            this.splitContainer1.Panel1.Controls.Add(this.uidateTimePickerStart);
            this.splitContainer1.Panel1.Controls.Add(this.uidateTimePickerEnd);
            this.splitContainer1.Panel1.Controls.Add(this.uicomboBoxDistrict);
            this.splitContainer1.Panel1.Controls.Add(this.uicomboBoxActive);
            this.splitContainer1.Panel1.Controls.Add(this.uicomboBoxVerified);
            this.splitContainer1.Panel1.Controls.Add(this.uicomboBoxRole);
            this.splitContainer1.Panel1.Controls.Add(this.uicomboBoxCities);
            this.splitContainer1.Panel1.Controls.Add(this.uitextBoxEmail);
            this.splitContainer1.Panel1.Controls.Add(this.uitextBoxUserName);
            this.splitContainer1.Panel1.Controls.Add(this.uiLabelBirthdayEnd);
            this.splitContainer1.Panel1.Controls.Add(this.uitextBoxID);
            this.splitContainer1.Panel1.Controls.Add(this.uiLabelDistrict);
            this.splitContainer1.Panel1.Controls.Add(this.uiLabelBirthdayStart);
            this.splitContainer1.Panel1.Controls.Add(this.uiLabelActive);
            this.splitContainer1.Panel1.Controls.Add(this.uiLabelCities);
            this.splitContainer1.Panel1.Controls.Add(this.uiLabelRole);
            this.splitContainer1.Panel1.Controls.Add(this.uiLabelEmail);
            this.splitContainer1.Panel1.Controls.Add(this.uiLabelVerified);
            this.splitContainer1.Panel1.Controls.Add(this.uiLabelUserName);
            this.splitContainer1.Panel1.Controls.Add(this.uiLabelID);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.uidataGridViewMember);
            this.splitContainer1.Size = new System.Drawing.Size(808, 622);
            this.splitContainer1.SplitterDistance = 189;
            this.splitContainer1.TabIndex = 1;
            // 
            // uibutAddMember
            // 
            this.uibutAddMember.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uibutAddMember.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.uibutAddMember.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.uibutAddMember.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uibutAddMember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.uibutAddMember.ForePressColor = System.Drawing.Color.Red;
            this.uibutAddMember.Location = new System.Drawing.Point(503, 118);
            this.uibutAddMember.MinimumSize = new System.Drawing.Size(1, 1);
            this.uibutAddMember.Name = "uibutAddMember";
            this.uibutAddMember.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.uibutAddMember.RectSelectedColor = System.Drawing.Color.Lime;
            this.uibutAddMember.RectSize = 2;
            this.uibutAddMember.Size = new System.Drawing.Size(100, 35);
            this.uibutAddMember.TabIndex = 28;
            this.uibutAddMember.Text = "新增會員";
            this.uibutAddMember.TipsFont = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uibutAddMember.Click += new System.EventHandler(this.uibutAddMember_Click);
            // 
            // uibutClear
            // 
            this.uibutClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uibutClear.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.uibutClear.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.uibutClear.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uibutClear.ForePressColor = System.Drawing.Color.Red;
            this.uibutClear.Location = new System.Drawing.Point(503, 46);
            this.uibutClear.MinimumSize = new System.Drawing.Size(1, 1);
            this.uibutClear.Name = "uibutClear";
            this.uibutClear.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.uibutClear.RectSelectedColor = System.Drawing.Color.Lime;
            this.uibutClear.RectSize = 2;
            this.uibutClear.Size = new System.Drawing.Size(100, 35);
            this.uibutClear.TabIndex = 27;
            this.uibutClear.Text = "清空";
            this.uibutClear.TipsFont = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uibutClear.Click += new System.EventHandler(this.uibutClear_Click);
            // 
            // uibutSearch
            // 
            this.uibutSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uibutSearch.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.uibutSearch.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.uibutSearch.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uibutSearch.ForePressColor = System.Drawing.Color.Red;
            this.uibutSearch.Location = new System.Drawing.Point(503, 5);
            this.uibutSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.uibutSearch.Name = "uibutSearch";
            this.uibutSearch.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.uibutSearch.RectSelectedColor = System.Drawing.Color.Lime;
            this.uibutSearch.RectSize = 2;
            this.uibutSearch.Size = new System.Drawing.Size(100, 35);
            this.uibutSearch.TabIndex = 26;
            this.uibutSearch.Text = "搜尋";
            this.uibutSearch.TipsFont = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uibutSearch.Click += new System.EventHandler(this.uibutSearch_Click);
            // 
            // uidateTimePickerStart
            // 
            this.uidateTimePickerStart.FillColor = System.Drawing.Color.White;
            this.uidateTimePickerStart.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uidateTimePickerStart.Location = new System.Drawing.Point(90, 125);
            this.uidateTimePickerStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uidateTimePickerStart.MaxLength = 10;
            this.uidateTimePickerStart.MinimumSize = new System.Drawing.Size(63, 0);
            this.uidateTimePickerStart.Name = "uidateTimePickerStart";
            this.uidateTimePickerStart.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uidateTimePickerStart.Size = new System.Drawing.Size(150, 29);
            this.uidateTimePickerStart.SymbolDropDown = 61555;
            this.uidateTimePickerStart.SymbolNormal = 61555;
            this.uidateTimePickerStart.SymbolSize = 24;
            this.uidateTimePickerStart.TabIndex = 25;
            this.uidateTimePickerStart.Text = "2025-03-20";
            this.uidateTimePickerStart.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uidateTimePickerStart.Value = new System.DateTime(2025, 3, 20, 10, 24, 25, 11);
            this.uidateTimePickerStart.Watermark = "";
            // 
            // uidateTimePickerEnd
            // 
            this.uidateTimePickerEnd.FillColor = System.Drawing.Color.White;
            this.uidateTimePickerEnd.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uidateTimePickerEnd.Location = new System.Drawing.Point(328, 125);
            this.uidateTimePickerEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uidateTimePickerEnd.MaxLength = 10;
            this.uidateTimePickerEnd.MinimumSize = new System.Drawing.Size(63, 0);
            this.uidateTimePickerEnd.Name = "uidateTimePickerEnd";
            this.uidateTimePickerEnd.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uidateTimePickerEnd.Size = new System.Drawing.Size(150, 29);
            this.uidateTimePickerEnd.SymbolDropDown = 61555;
            this.uidateTimePickerEnd.SymbolNormal = 61555;
            this.uidateTimePickerEnd.SymbolSize = 24;
            this.uidateTimePickerEnd.TabIndex = 24;
            this.uidateTimePickerEnd.Text = "2025-03-20";
            this.uidateTimePickerEnd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uidateTimePickerEnd.Value = new System.DateTime(2025, 3, 20, 10, 24, 25, 11);
            this.uidateTimePickerEnd.Watermark = "";
            // 
            // uicomboBoxDistrict
            // 
            this.uicomboBoxDistrict.DataSource = null;
            this.uicomboBoxDistrict.FillColor = System.Drawing.Color.White;
            this.uicomboBoxDistrict.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uicomboBoxDistrict.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.uicomboBoxDistrict.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uicomboBoxDistrict.Location = new System.Drawing.Point(328, 95);
            this.uicomboBoxDistrict.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uicomboBoxDistrict.MinimumSize = new System.Drawing.Size(63, 0);
            this.uicomboBoxDistrict.Name = "uicomboBoxDistrict";
            this.uicomboBoxDistrict.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uicomboBoxDistrict.Size = new System.Drawing.Size(150, 29);
            this.uicomboBoxDistrict.SymbolSize = 24;
            this.uicomboBoxDistrict.TabIndex = 22;
            this.uicomboBoxDistrict.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uicomboBoxDistrict.Watermark = "";
            // 
            // uicomboBoxActive
            // 
            this.uicomboBoxActive.DataSource = null;
            this.uicomboBoxActive.FillColor = System.Drawing.Color.White;
            this.uicomboBoxActive.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uicomboBoxActive.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.uicomboBoxActive.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uicomboBoxActive.Location = new System.Drawing.Point(328, 65);
            this.uicomboBoxActive.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uicomboBoxActive.MinimumSize = new System.Drawing.Size(63, 0);
            this.uicomboBoxActive.Name = "uicomboBoxActive";
            this.uicomboBoxActive.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uicomboBoxActive.Size = new System.Drawing.Size(150, 29);
            this.uicomboBoxActive.SymbolSize = 24;
            this.uicomboBoxActive.TabIndex = 21;
            this.uicomboBoxActive.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uicomboBoxActive.Watermark = "";
            // 
            // uicomboBoxVerified
            // 
            this.uicomboBoxVerified.DataSource = null;
            this.uicomboBoxVerified.FillColor = System.Drawing.Color.White;
            this.uicomboBoxVerified.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uicomboBoxVerified.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.uicomboBoxVerified.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uicomboBoxVerified.Location = new System.Drawing.Point(328, 5);
            this.uicomboBoxVerified.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uicomboBoxVerified.MinimumSize = new System.Drawing.Size(63, 0);
            this.uicomboBoxVerified.Name = "uicomboBoxVerified";
            this.uicomboBoxVerified.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uicomboBoxVerified.Size = new System.Drawing.Size(150, 29);
            this.uicomboBoxVerified.SymbolSize = 24;
            this.uicomboBoxVerified.TabIndex = 21;
            this.uicomboBoxVerified.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uicomboBoxVerified.Watermark = "";
            // 
            // uicomboBoxRole
            // 
            this.uicomboBoxRole.DataSource = null;
            this.uicomboBoxRole.FillColor = System.Drawing.Color.White;
            this.uicomboBoxRole.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uicomboBoxRole.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.uicomboBoxRole.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uicomboBoxRole.Location = new System.Drawing.Point(328, 35);
            this.uicomboBoxRole.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uicomboBoxRole.MinimumSize = new System.Drawing.Size(63, 0);
            this.uicomboBoxRole.Name = "uicomboBoxRole";
            this.uicomboBoxRole.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uicomboBoxRole.Size = new System.Drawing.Size(150, 29);
            this.uicomboBoxRole.SymbolSize = 24;
            this.uicomboBoxRole.TabIndex = 21;
            this.uicomboBoxRole.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uicomboBoxRole.Watermark = "";
            // 
            // uicomboBoxCities
            // 
            this.uicomboBoxCities.DataSource = null;
            this.uicomboBoxCities.FillColor = System.Drawing.Color.White;
            this.uicomboBoxCities.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uicomboBoxCities.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.uicomboBoxCities.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uicomboBoxCities.Location = new System.Drawing.Point(90, 95);
            this.uicomboBoxCities.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uicomboBoxCities.MinimumSize = new System.Drawing.Size(63, 0);
            this.uicomboBoxCities.Name = "uicomboBoxCities";
            this.uicomboBoxCities.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uicomboBoxCities.Size = new System.Drawing.Size(150, 29);
            this.uicomboBoxCities.SymbolSize = 24;
            this.uicomboBoxCities.TabIndex = 20;
            this.uicomboBoxCities.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uicomboBoxCities.Watermark = "";
            this.uicomboBoxCities.SelectedIndexChanged += new System.EventHandler(this.uicomboBoxCities_SelectedIndexChanged);
            // 
            // uitextBoxEmail
            // 
            this.uitextBoxEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uitextBoxEmail.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uitextBoxEmail.Location = new System.Drawing.Point(90, 65);
            this.uitextBoxEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uitextBoxEmail.MinimumSize = new System.Drawing.Size(1, 16);
            this.uitextBoxEmail.Name = "uitextBoxEmail";
            this.uitextBoxEmail.Padding = new System.Windows.Forms.Padding(5);
            this.uitextBoxEmail.ShowText = false;
            this.uitextBoxEmail.Size = new System.Drawing.Size(150, 29);
            this.uitextBoxEmail.TabIndex = 6;
            this.uitextBoxEmail.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uitextBoxEmail.Watermark = "";
            // 
            // uitextBoxUserName
            // 
            this.uitextBoxUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uitextBoxUserName.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uitextBoxUserName.Location = new System.Drawing.Point(90, 35);
            this.uitextBoxUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uitextBoxUserName.MinimumSize = new System.Drawing.Size(1, 16);
            this.uitextBoxUserName.Name = "uitextBoxUserName";
            this.uitextBoxUserName.Padding = new System.Windows.Forms.Padding(5);
            this.uitextBoxUserName.ShowText = false;
            this.uitextBoxUserName.Size = new System.Drawing.Size(150, 29);
            this.uitextBoxUserName.TabIndex = 6;
            this.uitextBoxUserName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uitextBoxUserName.Watermark = "";
            // 
            // uiLabelBirthdayEnd
            // 
            this.uiLabelBirthdayEnd.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiLabelBirthdayEnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabelBirthdayEnd.Location = new System.Drawing.Point(247, 130);
            this.uiLabelBirthdayEnd.Name = "uiLabelBirthdayEnd";
            this.uiLabelBirthdayEnd.Size = new System.Drawing.Size(88, 23);
            this.uiLabelBirthdayEnd.TabIndex = 7;
            this.uiLabelBirthdayEnd.Text = "Birth-E:";
            // 
            // uitextBoxID
            // 
            this.uitextBoxID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uitextBoxID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uitextBoxID.Location = new System.Drawing.Point(90, 5);
            this.uitextBoxID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uitextBoxID.MinimumSize = new System.Drawing.Size(1, 16);
            this.uitextBoxID.Name = "uitextBoxID";
            this.uitextBoxID.Padding = new System.Windows.Forms.Padding(5);
            this.uitextBoxID.ShowText = false;
            this.uitextBoxID.Size = new System.Drawing.Size(150, 29);
            this.uitextBoxID.TabIndex = 6;
            this.uitextBoxID.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uitextBoxID.Watermark = "";
            // 
            // uiLabelDistrict
            // 
            this.uiLabelDistrict.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiLabelDistrict.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabelDistrict.Location = new System.Drawing.Point(247, 100);
            this.uiLabelDistrict.Name = "uiLabelDistrict";
            this.uiLabelDistrict.Size = new System.Drawing.Size(88, 23);
            this.uiLabelDistrict.TabIndex = 8;
            this.uiLabelDistrict.Text = "地區:";
            // 
            // uiLabelBirthdayStart
            // 
            this.uiLabelBirthdayStart.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiLabelBirthdayStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabelBirthdayStart.Location = new System.Drawing.Point(9, 130);
            this.uiLabelBirthdayStart.Name = "uiLabelBirthdayStart";
            this.uiLabelBirthdayStart.Size = new System.Drawing.Size(88, 23);
            this.uiLabelBirthdayStart.TabIndex = 5;
            this.uiLabelBirthdayStart.Text = "Birth-S:";
            // 
            // uiLabelActive
            // 
            this.uiLabelActive.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiLabelActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabelActive.Location = new System.Drawing.Point(247, 70);
            this.uiLabelActive.Name = "uiLabelActive";
            this.uiLabelActive.Size = new System.Drawing.Size(88, 23);
            this.uiLabelActive.TabIndex = 9;
            this.uiLabelActive.Text = "帳戶狀態:";
            // 
            // uiLabelCities
            // 
            this.uiLabelCities.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiLabelCities.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabelCities.Location = new System.Drawing.Point(9, 100);
            this.uiLabelCities.Name = "uiLabelCities";
            this.uiLabelCities.Size = new System.Drawing.Size(88, 23);
            this.uiLabelCities.TabIndex = 5;
            this.uiLabelCities.Text = "縣市:";
            // 
            // uiLabelRole
            // 
            this.uiLabelRole.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiLabelRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabelRole.Location = new System.Drawing.Point(247, 40);
            this.uiLabelRole.Name = "uiLabelRole";
            this.uiLabelRole.Size = new System.Drawing.Size(88, 23);
            this.uiLabelRole.TabIndex = 10;
            this.uiLabelRole.Text = "權限類別:";
            // 
            // uiLabelEmail
            // 
            this.uiLabelEmail.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiLabelEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabelEmail.Location = new System.Drawing.Point(9, 70);
            this.uiLabelEmail.Name = "uiLabelEmail";
            this.uiLabelEmail.Size = new System.Drawing.Size(88, 23);
            this.uiLabelEmail.TabIndex = 5;
            this.uiLabelEmail.Text = "Email:";
            // 
            // uiLabelVerified
            // 
            this.uiLabelVerified.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiLabelVerified.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabelVerified.Location = new System.Drawing.Point(247, 10);
            this.uiLabelVerified.Name = "uiLabelVerified";
            this.uiLabelVerified.Size = new System.Drawing.Size(88, 23);
            this.uiLabelVerified.TabIndex = 11;
            this.uiLabelVerified.Text = "驗證狀態:";
            // 
            // uiLabelUserName
            // 
            this.uiLabelUserName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiLabelUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabelUserName.Location = new System.Drawing.Point(9, 40);
            this.uiLabelUserName.Name = "uiLabelUserName";
            this.uiLabelUserName.Size = new System.Drawing.Size(88, 23);
            this.uiLabelUserName.TabIndex = 5;
            this.uiLabelUserName.Text = "名稱:";
            // 
            // uiLabelID
            // 
            this.uiLabelID.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiLabelID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabelID.Location = new System.Drawing.Point(9, 10);
            this.uiLabelID.Name = "uiLabelID";
            this.uiLabelID.Size = new System.Drawing.Size(88, 23);
            this.uiLabelID.TabIndex = 5;
            this.uiLabelID.Text = "ID:";
            // 
            // uidataGridViewMember
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uidataGridViewMember.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.uidataGridViewMember.BackgroundColor = System.Drawing.Color.White;
            this.uidataGridViewMember.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uidataGridViewMember.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.uidataGridViewMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uidataGridViewMember.DefaultCellStyle = dataGridViewCellStyle8;
            this.uidataGridViewMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uidataGridViewMember.EnableHeadersVisualStyles = false;
            this.uidataGridViewMember.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uidataGridViewMember.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uidataGridViewMember.Location = new System.Drawing.Point(0, 0);
            this.uidataGridViewMember.Name = "uidataGridViewMember";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uidataGridViewMember.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uidataGridViewMember.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.uidataGridViewMember.RowTemplate.Height = 24;
            this.uidataGridViewMember.SelectedIndex = -1;
            this.uidataGridViewMember.Size = new System.Drawing.Size(804, 425);
            this.uidataGridViewMember.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uidataGridViewMember.TabIndex = 1;
            this.uidataGridViewMember.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uidataGridViewMember_CellClick);
            // 
            // uiSplitContainer1
            // 
            this.uiSplitContainer1.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.uiSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSplitContainer1.HandleColor = System.Drawing.Color.HotPink;
            this.uiSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.uiSplitContainer1.MinimumSize = new System.Drawing.Size(20, 20);
            this.uiSplitContainer1.Name = "uiSplitContainer1";
            // 
            // uiSplitContainer1.Panel1
            // 
            this.uiSplitContainer1.Panel1.Controls.Add(this.uitreeViewInterests);
            // 
            // uiSplitContainer1.Panel2
            // 
            this.uiSplitContainer1.Panel2.Controls.Add(this.flowLayoutPanelMembers);
            this.uiSplitContainer1.Panel2.Controls.Add(this.but);
            this.uiSplitContainer1.Panel2.Controls.Add(this.butAddCategory);
            this.uiSplitContainer1.Panel2.Controls.Add(this.butAddInterest);
            this.uiSplitContainer1.Panel2.Controls.Add(this.butDeleteInterest);
            this.uiSplitContainer1.Size = new System.Drawing.Size(808, 622);
            this.uiSplitContainer1.SplitterDistance = 172;
            this.uiSplitContainer1.SplitterWidth = 11;
            this.uiSplitContainer1.TabIndex = 4;
            // 
            // uitreeViewInterests
            // 
            this.uitreeViewInterests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uitreeViewInterests.FillColor = System.Drawing.Color.White;
            this.uitreeViewInterests.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uitreeViewInterests.Location = new System.Drawing.Point(0, 0);
            this.uitreeViewInterests.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uitreeViewInterests.MinimumSize = new System.Drawing.Size(1, 1);
            this.uitreeViewInterests.Name = "uitreeViewInterests";
            this.uitreeViewInterests.ScrollBarStyleInherited = false;
            this.uitreeViewInterests.ShowText = false;
            this.uitreeViewInterests.Size = new System.Drawing.Size(172, 622);
            this.uitreeViewInterests.TabIndex = 3;
            this.uitreeViewInterests.Text = "uiTreeView1";
            this.uitreeViewInterests.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uitreeViewInterests.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.uitreeViewInterests_AfterSelect);
            // 
            // flowLayoutPanelMembers
            // 
            this.flowLayoutPanelMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMembers.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMembers.Name = "flowLayoutPanelMembers";
            this.flowLayoutPanelMembers.Size = new System.Drawing.Size(625, 622);
            this.flowLayoutPanelMembers.TabIndex = 4;
            // 
            // but
            // 
            this.but.Location = new System.Drawing.Point(576, 592);
            this.but.Name = "but";
            this.but.Size = new System.Drawing.Size(27, 21);
            this.but.TabIndex = 2;
            this.but.Text = "全部收合";
            this.but.UseVisualStyleBackColor = true;
            this.but.Click += new System.EventHandler(this.butSwitch_Click);
            // 
            // butAddCategory
            // 
            this.butAddCategory.Location = new System.Drawing.Point(576, 592);
            this.butAddCategory.Name = "butAddCategory";
            this.butAddCategory.Size = new System.Drawing.Size(23, 24);
            this.butAddCategory.TabIndex = 1;
            this.butAddCategory.Text = "新增類別";
            this.butAddCategory.UseVisualStyleBackColor = true;
            this.butAddCategory.Click += new System.EventHandler(this.butAddCategory_Click);
            // 
            // butAddInterest
            // 
            this.butAddInterest.Location = new System.Drawing.Point(576, 592);
            this.butAddInterest.Name = "butAddInterest";
            this.butAddInterest.Size = new System.Drawing.Size(23, 24);
            this.butAddInterest.TabIndex = 2;
            this.butAddInterest.Text = "新增興趣";
            this.butAddInterest.UseVisualStyleBackColor = true;
            this.butAddInterest.Click += new System.EventHandler(this.butAddInterest_Click);
            // 
            // butDeleteInterest
            // 
            this.butDeleteInterest.Location = new System.Drawing.Point(576, 592);
            this.butDeleteInterest.Name = "butDeleteInterest";
            this.butDeleteInterest.Size = new System.Drawing.Size(23, 24);
            this.butDeleteInterest.TabIndex = 2;
            this.butDeleteInterest.Text = "刪除興趣";
            this.butDeleteInterest.UseVisualStyleBackColor = true;
            this.butDeleteInterest.Click += new System.EventHandler(this.butDeleteInterest_Click);
            // 
            // uitabControlMember
            // 
            this.uitabControlMember.Controls.Add(this.tabPageMembers);
            this.uitabControlMember.Controls.Add(this.tabPageInterest);
            this.uitabControlMember.Cursor = System.Windows.Forms.Cursors.Default;
            this.uitabControlMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uitabControlMember.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uitabControlMember.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(224)))), ((int)(((byte)(188)))));
            this.uitabControlMember.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uitabControlMember.ItemSize = new System.Drawing.Size(150, 40);
            this.uitabControlMember.Location = new System.Drawing.Point(0, 0);
            this.uitabControlMember.MainPage = "";
            this.uitabControlMember.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uitabControlMember.Name = "uitabControlMember";
            this.uitabControlMember.SelectedIndex = 0;
            this.uitabControlMember.Size = new System.Drawing.Size(808, 662);
            this.uitabControlMember.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uitabControlMember.TabBackColor = System.Drawing.Color.Gray;
            this.uitabControlMember.TabIndex = 2;
            this.uitabControlMember.TabSelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.uitabControlMember.TabSelectedHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.uitabControlMember.TipsFont = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            // 
            // tabPageMembers
            // 
            this.tabPageMembers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(224)))), ((int)(((byte)(188)))));
            this.tabPageMembers.Controls.Add(this.splitContainer1);
            this.tabPageMembers.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPageMembers.Location = new System.Drawing.Point(0, 40);
            this.tabPageMembers.Name = "tabPageMembers";
            this.tabPageMembers.Size = new System.Drawing.Size(808, 622);
            this.tabPageMembers.TabIndex = 0;
            this.tabPageMembers.Text = "會員";
            // 
            // tabPageInterest
            // 
            this.tabPageInterest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(224)))), ((int)(((byte)(188)))));
            this.tabPageInterest.Controls.Add(this.uiSplitContainer1);
            this.tabPageInterest.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPageInterest.Location = new System.Drawing.Point(0, 40);
            this.tabPageInterest.Name = "tabPageInterest";
            this.tabPageInterest.Size = new System.Drawing.Size(808, 622);
            this.tabPageInterest.TabIndex = 1;
            this.tabPageInterest.Text = "興趣";
            // 
            // UCmember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uitabControlMember);
            this.Name = "UCmember";
            this.Size = new System.Drawing.Size(808, 662);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uidataGridViewMember)).EndInit();
            this.uiSplitContainer1.Panel1.ResumeLayout(false);
            this.uiSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer1)).EndInit();
            this.uiSplitContainer1.ResumeLayout(false);
            this.uitabControlMember.ResumeLayout(false);
            this.tabPageMembers.ResumeLayout(false);
            this.tabPageInterest.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button butAddInterest;
        private System.Windows.Forms.Button butAddCategory;
        private System.Windows.Forms.Button butDeleteInterest;
        private Sunny.UI.UITreeView uitreeViewInterests;
        private Sunny.UI.UISplitContainer uiSplitContainer1;
        private System.Windows.Forms.Button but;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMembers;
        private Sunny.UI.UIDataGridView uidataGridViewMember;
        private Sunny.UI.UITabControl uitabControlMember;
        private System.Windows.Forms.TabPage tabPageMembers;
        private System.Windows.Forms.TabPage tabPageInterest;
        private Sunny.UI.UILabel uiLabelID;
        private Sunny.UI.UITextBox uitextBoxID;
        private Sunny.UI.UITextBox uitextBoxEmail;
        private Sunny.UI.UITextBox uitextBoxUserName;
        private Sunny.UI.UILabel uiLabelBirthdayStart;
        private Sunny.UI.UILabel uiLabelCities;
        private Sunny.UI.UILabel uiLabelEmail;
        private Sunny.UI.UILabel uiLabelUserName;
        private Sunny.UI.UILabel uiLabelBirthdayEnd;
        private Sunny.UI.UILabel uiLabelDistrict;
        private Sunny.UI.UILabel uiLabelActive;
        private Sunny.UI.UILabel uiLabelRole;
        private Sunny.UI.UILabel uiLabelVerified;
        private Sunny.UI.UIComboBox uicomboBoxDistrict;
        private Sunny.UI.UIComboBox uicomboBoxActive;
        private Sunny.UI.UIComboBox uicomboBoxVerified;
        private Sunny.UI.UIComboBox uicomboBoxRole;
        private Sunny.UI.UIComboBox uicomboBoxCities;
        private Sunny.UI.UIDatePicker uidateTimePickerStart;
        private Sunny.UI.UIDatePicker uidateTimePickerEnd;
        private Sunny.UI.UIButton uibutSearch;
        private Sunny.UI.UIButton uibutAddMember;
        private Sunny.UI.UIButton uibutClear;
    }
}
