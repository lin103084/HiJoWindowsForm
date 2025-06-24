namespace slnFriendshipBackEnd.match
{
    partial class UcSwipes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.swipButton1 = new System.Windows.Forms.Button();
            this.swipTextBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.swipTextBox2 = new System.Windows.Forms.TextBox();
            this.swipButton2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.swipButton4 = new System.Windows.Forms.Button();
            this.swipDataGridview1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.swipComboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.swipPictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.swipTextBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.swipTextBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.swipDataGridview1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swipPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // swipButton1
            // 
            this.swipButton1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.swipButton1.Location = new System.Drawing.Point(860, 458);
            this.swipButton1.Name = "swipButton1";
            this.swipButton1.Size = new System.Drawing.Size(97, 36);
            this.swipButton1.TabIndex = 13;
            this.swipButton1.Text = "新增(滑動)";
            this.swipButton1.UseVisualStyleBackColor = true;
            this.swipButton1.Click += new System.EventHandler(this.swipButton1_Click);
            // 
            // swipTextBox1
            // 
            this.swipTextBox1.Location = new System.Drawing.Point(467, 98);
            this.swipTextBox1.Name = "swipTextBox1";
            this.swipTextBox1.Size = new System.Drawing.Size(135, 22);
            this.swipTextBox1.TabIndex = 14;
            this.swipTextBox1.TextChanged += new System.EventHandler(this.swipTextBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(366, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "滑動者ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(625, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "被滑動者ID:";
            // 
            // swipTextBox2
            // 
            this.swipTextBox2.Location = new System.Drawing.Point(726, 100);
            this.swipTextBox2.Name = "swipTextBox2";
            this.swipTextBox2.Size = new System.Drawing.Size(135, 22);
            this.swipTextBox2.TabIndex = 17;
            // 
            // swipButton2
            // 
            this.swipButton2.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.swipButton2.Location = new System.Drawing.Point(713, 458);
            this.swipButton2.Name = "swipButton2";
            this.swipButton2.Size = new System.Drawing.Size(97, 36);
            this.swipButton2.TabIndex = 19;
            this.swipButton2.Text = "修改";
            this.swipButton2.UseVisualStyleBackColor = true;
            this.swipButton2.Click += new System.EventHandler(this.swipButton2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(366, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "配對狀態:";
            // 
            // swipButton4
            // 
            this.swipButton4.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Bold);
            this.swipButton4.Location = new System.Drawing.Point(557, 458);
            this.swipButton4.Name = "swipButton4";
            this.swipButton4.Size = new System.Drawing.Size(115, 36);
            this.swipButton4.TabIndex = 23;
            this.swipButton4.Text = "重新整理";
            this.swipButton4.UseVisualStyleBackColor = true;
            this.swipButton4.Click += new System.EventHandler(this.swipButton4_Click);
            // 
            // swipDataGridview1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.swipDataGridview1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.swipDataGridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.swipDataGridview1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.swipDataGridview1.Location = new System.Drawing.Point(370, 220);
            this.swipDataGridview1.Name = "swipDataGridview1";
            this.swipDataGridview1.RowTemplate.Height = 30;
            this.swipDataGridview1.Size = new System.Drawing.Size(587, 216);
            this.swipDataGridview1.TabIndex = 26;
            this.swipDataGridview1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "刪除";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Text = "-";
            this.Column1.UseColumnTextForButtonValue = true;
            // 
            // swipComboBox1
            // 
            this.swipComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.swipComboBox1.FormattingEnabled = true;
            this.swipComboBox1.Location = new System.Drawing.Point(467, 143);
            this.swipComboBox1.Name = "swipComboBox1";
            this.swipComboBox1.Size = new System.Drawing.Size(135, 20);
            this.swipComboBox1.TabIndex = 29;
            this.swipComboBox1.SelectedIndexChanged += new System.EventHandler(this.swipComboBox1_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(75, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 35;
            this.label8.Text = "會員照片:";
            // 
            // swipPictureBox1
            // 
            this.swipPictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.swipPictureBox1.Location = new System.Drawing.Point(78, 225);
            this.swipPictureBox1.Name = "swipPictureBox1";
            this.swipPictureBox1.Size = new System.Drawing.Size(232, 204);
            this.swipPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.swipPictureBox1.TabIndex = 38;
            this.swipPictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(74, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "被滑動者ID:";
            // 
            // swipTextBox3
            // 
            this.swipTextBox3.Location = new System.Drawing.Point(175, 113);
            this.swipTextBox3.Name = "swipTextBox3";
            this.swipTextBox3.Size = new System.Drawing.Size(135, 22);
            this.swipTextBox3.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(74, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 40;
            this.label4.Text = "滑動者ID:";
            // 
            // swipTextBox4
            // 
            this.swipTextBox4.Location = new System.Drawing.Point(175, 148);
            this.swipTextBox4.Name = "swipTextBox4";
            this.swipTextBox4.Size = new System.Drawing.Size(135, 22);
            this.swipTextBox4.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(74, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 43;
            this.label6.Text = "查詢";
            // 
            // UcSwipes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(224)))), ((int)(((byte)(188)))));
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.swipTextBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.swipTextBox4);
            this.Controls.Add(this.swipPictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.swipComboBox1);
            this.Controls.Add(this.swipDataGridview1);
            this.Controls.Add(this.swipButton4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.swipButton2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.swipTextBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.swipTextBox1);
            this.Controls.Add(this.swipButton1);
            this.Name = "UcSwipes";
            this.Size = new System.Drawing.Size(1001, 613);
            ((System.ComponentModel.ISupportInitialize)(this.swipDataGridview1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swipPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button swipButton1;
        private System.Windows.Forms.TextBox swipTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox swipTextBox2;
        private System.Windows.Forms.Button swipButton2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button swipButton4;
        private System.Windows.Forms.DataGridView swipDataGridview1;
        private System.Windows.Forms.ComboBox swipComboBox1;
        //private fsDataSetTableAdapters.swipes1TableAdapter swipes1TableAdapter1;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox swipPictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox swipTextBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox swipTextBox4;
        private System.Windows.Forms.Label label6;
    }
}
