namespace prjLogin.Frm
{
    partial class FrmMemberDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxBirthday = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxVerified = new System.Windows.Forms.CheckBox();
            this.butDeleteAcount = new System.Windows.Forms.Button();
            this.butUpdate = new System.Windows.Forms.Button();
            this.comboBoxCities = new System.Windows.Forms.ComboBox();
            this.comboBoxDistrict = new System.Windows.Forms.ComboBox();
            this.comboBoxSex = new System.Windows.Forms.ComboBox();
            this.butChangAvatar = new System.Windows.Forms.Button();
            this.uiComboBoxCategories = new Sunny.UI.UIComboBox();
            this.checkedListBoxInterests = new System.Windows.Forms.CheckedListBox();
            this.FlowLayoutPanelSelected = new System.Windows.Forms.FlowLayoutPanel();
            this.butAddInterest = new System.Windows.Forms.Button();
            this.butSaveInteresting = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Khaki;
            this.button1.Location = new System.Drawing.Point(107, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(299, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "啟用 / 編輯";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "名稱:";
            // 
            // pictureBoxAvatar
            // 
            this.pictureBoxAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBoxAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxAvatar.Location = new System.Drawing.Point(107, 12);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAvatar.TabIndex = 2;
            this.pictureBoxAvatar.TabStop = false;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(144, 330);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(100, 22);
            this.textBoxUserName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(307, 330);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(100, 22);
            this.textBoxEmail.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "性別:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 359);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "生日:";
            // 
            // textBoxBirthday
            // 
            this.textBoxBirthday.Location = new System.Drawing.Point(307, 356);
            this.textBoxBirthday.Name = "textBoxBirthday";
            this.textBoxBirthday.Size = new System.Drawing.Size(100, 22);
            this.textBoxBirthday.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 386);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "居住縣市:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 386);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "地區:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(81, 412);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "帳號狀態:";
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Location = new System.Drawing.Point(143, 410);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(93, 16);
            this.checkBoxActive.TabIndex = 4;
            this.checkBoxActive.Text = "啟用 / 未啟用";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(245, 412);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "驗證狀態:";
            // 
            // checkBoxVerified
            // 
            this.checkBoxVerified.AutoSize = true;
            this.checkBoxVerified.Location = new System.Drawing.Point(307, 409);
            this.checkBoxVerified.Name = "checkBoxVerified";
            this.checkBoxVerified.Size = new System.Drawing.Size(117, 16);
            this.checkBoxVerified.TabIndex = 4;
            this.checkBoxVerified.Text = "    已驗證 / 未驗證";
            this.checkBoxVerified.UseVisualStyleBackColor = true;
            // 
            // butDeleteAcount
            // 
            this.butDeleteAcount.BackColor = System.Drawing.Color.RosyBrown;
            this.butDeleteAcount.Location = new System.Drawing.Point(206, 499);
            this.butDeleteAcount.Name = "butDeleteAcount";
            this.butDeleteAcount.Size = new System.Drawing.Size(100, 50);
            this.butDeleteAcount.TabIndex = 0;
            this.butDeleteAcount.Text = "刪除帳號";
            this.butDeleteAcount.UseVisualStyleBackColor = false;
            this.butDeleteAcount.Click += new System.EventHandler(this.butDeleteAcount_Click);
            // 
            // butUpdate
            // 
            this.butUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butUpdate.Location = new System.Drawing.Point(106, 499);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(99, 50);
            this.butUpdate.TabIndex = 0;
            this.butUpdate.Text = "更新";
            this.butUpdate.UseVisualStyleBackColor = false;
            this.butUpdate.Click += new System.EventHandler(this.butUpdate_Click);
            // 
            // comboBoxCities
            // 
            this.comboBoxCities.FormattingEnabled = true;
            this.comboBoxCities.Location = new System.Drawing.Point(143, 383);
            this.comboBoxCities.Name = "comboBoxCities";
            this.comboBoxCities.Size = new System.Drawing.Size(101, 20);
            this.comboBoxCities.TabIndex = 5;
            this.comboBoxCities.SelectedIndexChanged += new System.EventHandler(this.comboBoxCities_SelectedIndexChanged);
            this.comboBoxCities.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBoxCities_MouseDown);
            // 
            // comboBoxDistrict
            // 
            this.comboBoxDistrict.FormattingEnabled = true;
            this.comboBoxDistrict.Location = new System.Drawing.Point(307, 383);
            this.comboBoxDistrict.Name = "comboBoxDistrict";
            this.comboBoxDistrict.Size = new System.Drawing.Size(101, 20);
            this.comboBoxDistrict.TabIndex = 5;
            // 
            // comboBoxSex
            // 
            this.comboBoxSex.FormattingEnabled = true;
            this.comboBoxSex.Location = new System.Drawing.Point(143, 356);
            this.comboBoxSex.Name = "comboBoxSex";
            this.comboBoxSex.Size = new System.Drawing.Size(101, 20);
            this.comboBoxSex.TabIndex = 5;
            this.comboBoxSex.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBoxSex_MouseDown);
            // 
            // butChangAvatar
            // 
            this.butChangAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butChangAvatar.Location = new System.Drawing.Point(308, 499);
            this.butChangAvatar.Name = "butChangAvatar";
            this.butChangAvatar.Size = new System.Drawing.Size(98, 50);
            this.butChangAvatar.TabIndex = 0;
            this.butChangAvatar.Text = "變更頭貼";
            this.butChangAvatar.UseVisualStyleBackColor = false;
            this.butChangAvatar.Click += new System.EventHandler(this.butChangAvatar_Click);
            // 
            // uiComboBoxCategories
            // 
            this.uiComboBoxCategories.DataSource = null;
            this.uiComboBoxCategories.FillColor = System.Drawing.Color.White;
            this.uiComboBoxCategories.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiComboBoxCategories.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.uiComboBoxCategories.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiComboBoxCategories.Location = new System.Drawing.Point(423, 14);
            this.uiComboBoxCategories.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBoxCategories.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBoxCategories.Name = "uiComboBoxCategories";
            this.uiComboBoxCategories.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBoxCategories.Size = new System.Drawing.Size(150, 29);
            this.uiComboBoxCategories.SymbolSize = 24;
            this.uiComboBoxCategories.TabIndex = 6;
            this.uiComboBoxCategories.Text = "uicomboBoxCategories";
            this.uiComboBoxCategories.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBoxCategories.Watermark = "";
            this.uiComboBoxCategories.SelectedIndexChanged += new System.EventHandler(this.uiComboBoxCategories_SelectedIndexChanged);
            // 
            // checkedListBoxInterests
            // 
            this.checkedListBoxInterests.FormattingEnabled = true;
            this.checkedListBoxInterests.Location = new System.Drawing.Point(424, 51);
            this.checkedListBoxInterests.Name = "checkedListBoxInterests";
            this.checkedListBoxInterests.Size = new System.Drawing.Size(150, 497);
            this.checkedListBoxInterests.TabIndex = 7;
            // 
            // FlowLayoutPanelSelected
            // 
            this.FlowLayoutPanelSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlowLayoutPanelSelected.Location = new System.Drawing.Point(580, 14);
            this.FlowLayoutPanelSelected.Name = "FlowLayoutPanelSelected";
            this.FlowLayoutPanelSelected.Size = new System.Drawing.Size(223, 478);
            this.FlowLayoutPanelSelected.TabIndex = 11;
            // 
            // butAddInterest
            // 
            this.butAddInterest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butAddInterest.Location = new System.Drawing.Point(580, 498);
            this.butAddInterest.Name = "butAddInterest";
            this.butAddInterest.Size = new System.Drawing.Size(98, 50);
            this.butAddInterest.TabIndex = 12;
            this.butAddInterest.Text = "添加興趣";
            this.butAddInterest.UseVisualStyleBackColor = false;
            this.butAddInterest.Click += new System.EventHandler(this.butAddInterest_Click);
            // 
            // butSaveInteresting
            // 
            this.butSaveInteresting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.butSaveInteresting.Location = new System.Drawing.Point(705, 498);
            this.butSaveInteresting.Name = "butSaveInteresting";
            this.butSaveInteresting.Size = new System.Drawing.Size(98, 50);
            this.butSaveInteresting.TabIndex = 12;
            this.butSaveInteresting.Text = "儲存興趣";
            this.butSaveInteresting.UseVisualStyleBackColor = false;
            this.butSaveInteresting.Click += new System.EventHandler(this.butSaveInteresting_Click);
            // 
            // FrmMemberDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.butSaveInteresting);
            this.Controls.Add(this.butAddInterest);
            this.Controls.Add(this.FlowLayoutPanelSelected);
            this.Controls.Add(this.checkedListBoxInterests);
            this.Controls.Add(this.uiComboBoxCategories);
            this.Controls.Add(this.comboBoxDistrict);
            this.Controls.Add(this.comboBoxSex);
            this.Controls.Add(this.comboBoxCities);
            this.Controls.Add(this.checkBoxVerified);
            this.Controls.Add(this.checkBoxActive);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxBirthday);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBoxAvatar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butDeleteAcount);
            this.Controls.Add(this.butChangAvatar);
            this.Controls.Add(this.butUpdate);
            this.Controls.Add(this.button1);
            this.Name = "FrmMemberDetail";
            this.Text = "FrmMemberDetail";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxBirthday;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxVerified;
        private System.Windows.Forms.Button butDeleteAcount;
        private System.Windows.Forms.Button butUpdate;
        private System.Windows.Forms.ComboBox comboBoxCities;
        private System.Windows.Forms.ComboBox comboBoxDistrict;
        private System.Windows.Forms.ComboBox comboBoxSex;
        private System.Windows.Forms.Button butChangAvatar;
        private Sunny.UI.UIComboBox uiComboBoxCategories;
        private System.Windows.Forms.CheckedListBox checkedListBoxInterests;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelSelected;
        private System.Windows.Forms.Button butAddInterest;
        private System.Windows.Forms.Button butSaveInteresting;
    }
}