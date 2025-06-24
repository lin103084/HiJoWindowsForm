namespace prjLogin
{
    partial class FrmLogin
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.uibutLogin = new Sunny.UI.UIButton();
            this.uibutForgetPassWord = new Sunny.UI.UIButton();
            this.uiTextBoxEmail = new Sunny.UI.UITextBox();
            this.uiLabelEmail = new Sunny.UI.UILabel();
            this.uiTextBoxPassWord = new Sunny.UI.UITextBox();
            this.uiLabelPassWord = new Sunny.UI.UILabel();
            this.uiTextBoxVerificationCode = new Sunny.UI.UITextBox();
            this.uiLabelVerificationCode = new Sunny.UI.UILabel();
            this.uibutVerificationCode = new Sunny.UI.UIButton();
            this.uiLabelExit = new Sunny.UI.UILabel();
            this.uibutReset = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // uibutLogin
            // 
            this.uibutLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uibutLogin.FillColor = System.Drawing.Color.Blue;
            this.uibutLogin.FillColorGradient = true;
            this.uibutLogin.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.uibutLogin.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.uibutLogin.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uibutLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.uibutLogin.ForePressColor = System.Drawing.Color.Red;
            this.uibutLogin.Location = new System.Drawing.Point(322, 274);
            this.uibutLogin.MinimumSize = new System.Drawing.Size(1, 1);
            this.uibutLogin.Name = "uibutLogin";
            this.uibutLogin.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.uibutLogin.RectSelectedColor = System.Drawing.Color.Lime;
            this.uibutLogin.RectSize = 2;
            this.uibutLogin.Size = new System.Drawing.Size(110, 35);
            this.uibutLogin.TabIndex = 30;
            this.uibutLogin.Text = "登入";
            this.uibutLogin.TipsFont = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uibutLogin.Click += new System.EventHandler(this.uibutLogin_Click);
            // 
            // uibutForgetPassWord
            // 
            this.uibutForgetPassWord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uibutForgetPassWord.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.uibutForgetPassWord.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.uibutForgetPassWord.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.uibutForgetPassWord.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uibutForgetPassWord.ForeColor = System.Drawing.Color.Red;
            this.uibutForgetPassWord.ForePressColor = System.Drawing.Color.Red;
            this.uibutForgetPassWord.Location = new System.Drawing.Point(381, 315);
            this.uibutForgetPassWord.MinimumSize = new System.Drawing.Size(1, 1);
            this.uibutForgetPassWord.Name = "uibutForgetPassWord";
            this.uibutForgetPassWord.RectHoverColor = System.Drawing.Color.Yellow;
            this.uibutForgetPassWord.RectSelectedColor = System.Drawing.Color.Lime;
            this.uibutForgetPassWord.RectSize = 2;
            this.uibutForgetPassWord.Size = new System.Drawing.Size(53, 35);
            this.uibutForgetPassWord.TabIndex = 29;
            this.uibutForgetPassWord.Text = "忘記密碼";
            this.uibutForgetPassWord.TipsFont = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uibutForgetPassWord.Click += new System.EventHandler(this.uibutForgetPassWord_Click);
            // 
            // uiTextBoxEmail
            // 
            this.uiTextBoxEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxEmail.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uiTextBoxEmail.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiTextBoxEmail.Location = new System.Drawing.Point(190, 150);
            this.uiTextBoxEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxEmail.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxEmail.Name = "uiTextBoxEmail";
            this.uiTextBoxEmail.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBoxEmail.Radius = 25;
            this.uiTextBoxEmail.RectColor = System.Drawing.Color.Yellow;
            this.uiTextBoxEmail.RectDisableColor = System.Drawing.Color.White;
            this.uiTextBoxEmail.ShowText = false;
            this.uiTextBoxEmail.Size = new System.Drawing.Size(242, 29);
            this.uiTextBoxEmail.SymbolColor = System.Drawing.Color.Blue;
            this.uiTextBoxEmail.TabIndex = 32;
            this.uiTextBoxEmail.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBoxEmail.Watermark = "";
            // 
            // uiLabelEmail
            // 
            this.uiLabelEmail.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabelEmail.ForeColor = System.Drawing.Color.Red;
            this.uiLabelEmail.Location = new System.Drawing.Point(89, 150);
            this.uiLabelEmail.Name = "uiLabelEmail";
            this.uiLabelEmail.Size = new System.Drawing.Size(94, 23);
            this.uiLabelEmail.TabIndex = 31;
            this.uiLabelEmail.Text = "Email";
            this.uiLabelEmail.Click += new System.EventHandler(this.uiLabelEmail_Click);
            // 
            // uiTextBoxPassWord
            // 
            this.uiTextBoxPassWord.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxPassWord.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uiTextBoxPassWord.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiTextBoxPassWord.Location = new System.Drawing.Point(190, 190);
            this.uiTextBoxPassWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxPassWord.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxPassWord.Name = "uiTextBoxPassWord";
            this.uiTextBoxPassWord.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBoxPassWord.PasswordChar = '*';
            this.uiTextBoxPassWord.Radius = 25;
            this.uiTextBoxPassWord.RectColor = System.Drawing.Color.Yellow;
            this.uiTextBoxPassWord.RectDisableColor = System.Drawing.Color.White;
            this.uiTextBoxPassWord.ShowText = false;
            this.uiTextBoxPassWord.Size = new System.Drawing.Size(242, 29);
            this.uiTextBoxPassWord.SymbolColor = System.Drawing.Color.Blue;
            this.uiTextBoxPassWord.TabIndex = 34;
            this.uiTextBoxPassWord.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBoxPassWord.Watermark = "";
            // 
            // uiLabelPassWord
            // 
            this.uiLabelPassWord.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabelPassWord.ForeColor = System.Drawing.Color.Red;
            this.uiLabelPassWord.Location = new System.Drawing.Point(89, 190);
            this.uiLabelPassWord.Name = "uiLabelPassWord";
            this.uiLabelPassWord.Size = new System.Drawing.Size(94, 23);
            this.uiLabelPassWord.TabIndex = 33;
            this.uiLabelPassWord.Text = "PassWord:";
            this.uiLabelPassWord.Click += new System.EventHandler(this.uiLabelPassWord_Click);
            // 
            // uiTextBoxVerificationCode
            // 
            this.uiTextBoxVerificationCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxVerificationCode.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uiTextBoxVerificationCode.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiTextBoxVerificationCode.Location = new System.Drawing.Point(190, 230);
            this.uiTextBoxVerificationCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxVerificationCode.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxVerificationCode.Name = "uiTextBoxVerificationCode";
            this.uiTextBoxVerificationCode.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBoxVerificationCode.Radius = 25;
            this.uiTextBoxVerificationCode.RectColor = System.Drawing.Color.Yellow;
            this.uiTextBoxVerificationCode.RectDisableColor = System.Drawing.Color.White;
            this.uiTextBoxVerificationCode.ShowText = false;
            this.uiTextBoxVerificationCode.Size = new System.Drawing.Size(242, 29);
            this.uiTextBoxVerificationCode.SymbolColor = System.Drawing.Color.Blue;
            this.uiTextBoxVerificationCode.TabIndex = 34;
            this.uiTextBoxVerificationCode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBoxVerificationCode.Watermark = "";
            // 
            // uiLabelVerificationCode
            // 
            this.uiLabelVerificationCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabelVerificationCode.ForeColor = System.Drawing.Color.Red;
            this.uiLabelVerificationCode.Location = new System.Drawing.Point(89, 230);
            this.uiLabelVerificationCode.Name = "uiLabelVerificationCode";
            this.uiLabelVerificationCode.Size = new System.Drawing.Size(94, 23);
            this.uiLabelVerificationCode.TabIndex = 33;
            this.uiLabelVerificationCode.Text = "驗證碼";
            // 
            // uibutVerificationCode
            // 
            this.uibutVerificationCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uibutVerificationCode.FillColor = System.Drawing.Color.Blue;
            this.uibutVerificationCode.FillColorGradient = true;
            this.uibutVerificationCode.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.uibutVerificationCode.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.uibutVerificationCode.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uibutVerificationCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.uibutVerificationCode.ForePressColor = System.Drawing.Color.Red;
            this.uibutVerificationCode.Location = new System.Drawing.Point(190, 274);
            this.uibutVerificationCode.MinimumSize = new System.Drawing.Size(1, 1);
            this.uibutVerificationCode.Name = "uibutVerificationCode";
            this.uibutVerificationCode.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.uibutVerificationCode.RectSelectedColor = System.Drawing.Color.Lime;
            this.uibutVerificationCode.RectSize = 2;
            this.uibutVerificationCode.Size = new System.Drawing.Size(110, 35);
            this.uibutVerificationCode.TabIndex = 35;
            this.uibutVerificationCode.Text = "發送驗證碼";
            this.uibutVerificationCode.TipsFont = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uibutVerificationCode.Click += new System.EventHandler(this.uibutVerificationCode_Click);
            // 
            // uiLabelExit
            // 
            this.uiLabelExit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabelExit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uiLabelExit.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiLabelExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabelExit.Location = new System.Drawing.Point(515, 3);
            this.uiLabelExit.Margin = new System.Windows.Forms.Padding(5);
            this.uiLabelExit.Name = "uiLabelExit";
            this.uiLabelExit.Size = new System.Drawing.Size(64, 23);
            this.uiLabelExit.TabIndex = 36;
            this.uiLabelExit.Text = "X 關閉";
            this.uiLabelExit.Click += new System.EventHandler(this.uiLabelExit_Click);
            // 
            // uibutReset
            // 
            this.uibutReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uibutReset.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.uibutReset.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.uibutReset.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.uibutReset.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uibutReset.ForeColor = System.Drawing.Color.Red;
            this.uibutReset.ForePressColor = System.Drawing.Color.Red;
            this.uibutReset.Location = new System.Drawing.Point(322, 315);
            this.uibutReset.MinimumSize = new System.Drawing.Size(1, 1);
            this.uibutReset.Name = "uibutReset";
            this.uibutReset.RectHoverColor = System.Drawing.Color.Yellow;
            this.uibutReset.RectSelectedColor = System.Drawing.Color.Lime;
            this.uibutReset.RectSize = 2;
            this.uibutReset.Size = new System.Drawing.Size(53, 35);
            this.uibutReset.TabIndex = 37;
            this.uibutReset.Text = "重置輸入";
            this.uibutReset.TipsFont = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uibutReset.Click += new System.EventHandler(this.uibutReset_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.uiLabelExit);
            this.Controls.Add(this.uibutVerificationCode);
            this.Controls.Add(this.uiTextBoxVerificationCode);
            this.Controls.Add(this.uiLabelVerificationCode);
            this.Controls.Add(this.uiTextBoxPassWord);
            this.Controls.Add(this.uiLabelPassWord);
            this.Controls.Add(this.uiTextBoxEmail);
            this.Controls.Add(this.uiLabelEmail);
            this.Controls.Add(this.uibutLogin);
            this.Controls.Add(this.uibutForgetPassWord);
            this.Controls.Add(this.uibutReset);
            this.DoubleBuffered = true;
            this.Name = "FrmLogin";
            this.Text = "Login";
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIButton uibutLogin;
        private Sunny.UI.UIButton uibutForgetPassWord;
        private Sunny.UI.UITextBox uiTextBoxEmail;
        private Sunny.UI.UILabel uiLabelEmail;
        private Sunny.UI.UITextBox uiTextBoxPassWord;
        private Sunny.UI.UILabel uiLabelPassWord;
        private Sunny.UI.UITextBox uiTextBoxVerificationCode;
        private Sunny.UI.UILabel uiLabelVerificationCode;
        private Sunny.UI.UIButton uibutVerificationCode;
        private Sunny.UI.UILabel uiLabelExit;
        private Sunny.UI.UIButton uibutReset;
    }
}

