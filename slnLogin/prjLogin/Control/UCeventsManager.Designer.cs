namespace slnFriendshipBackEnd.UserControls
{
    partial class UCeventsManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAddEventType = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEventTypes = new System.Windows.Forms.TabPage();
            this.dataGridViewEventTypes = new System.Windows.Forms.DataGridView();
            this.tabEvents = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.btnEventsSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewEvents = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tabBatches = new System.Windows.Forms.TabPage();
            this.comboBoxBatchEventName = new System.Windows.Forms.ComboBox();
            this.btnBatchSearch = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerBatchEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBatchStart = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAddBatch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewBatchList = new System.Windows.Forms.DataGridView();
            this.fsDataSet1 = new slnFriendshipBackEnd.fsDataSet();
            this.tableAdapterManager = new slnFriendshipBackEnd.fsDataSetTableAdapters.TableAdapterManager();
            this.tabControl1.SuspendLayout();
            this.tabEventTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventTypes)).BeginInit();
            this.tabEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).BeginInit();
            this.tabBatches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBatchList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddEventType
            // 
            this.btnAddEventType.Location = new System.Drawing.Point(467, 69);
            this.btnAddEventType.Name = "btnAddEventType";
            this.btnAddEventType.Size = new System.Drawing.Size(55, 44);
            this.btnAddEventType.TabIndex = 1;
            this.btnAddEventType.Text = "+";
            this.btnAddEventType.UseVisualStyleBackColor = true;
            this.btnAddEventType.Click += new System.EventHandler(this.btnAddEventType_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "活動分類列表";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabEventTypes);
            this.tabControl1.Controls.Add(this.tabEvents);
            this.tabControl1.Controls.Add(this.tabBatches);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(96, 40);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1020, 587);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabEventTypes
            // 
            this.tabEventTypes.AutoScroll = true;
            this.tabEventTypes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(224)))), ((int)(((byte)(188)))));
            this.tabEventTypes.Controls.Add(this.dataGridViewEventTypes);
            this.tabEventTypes.Controls.Add(this.label1);
            this.tabEventTypes.Controls.Add(this.btnAddEventType);
            this.tabEventTypes.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabEventTypes.Location = new System.Drawing.Point(4, 44);
            this.tabEventTypes.Name = "tabEventTypes";
            this.tabEventTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabEventTypes.Size = new System.Drawing.Size(1012, 539);
            this.tabEventTypes.TabIndex = 0;
            this.tabEventTypes.Text = "活動分類";
            // 
            // dataGridViewEventTypes
            // 
            this.dataGridViewEventTypes.AllowUserToAddRows = false;
            this.dataGridViewEventTypes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridViewEventTypes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEventTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewEventTypes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewEventTypes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(224)))), ((int)(((byte)(188)))));
            this.dataGridViewEventTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEventTypes.Location = new System.Drawing.Point(43, 138);
            this.dataGridViewEventTypes.Name = "dataGridViewEventTypes";
            this.dataGridViewEventTypes.ReadOnly = true;
            this.dataGridViewEventTypes.RowHeadersWidth = 51;
            this.dataGridViewEventTypes.RowTemplate.Height = 24;
            this.dataGridViewEventTypes.Size = new System.Drawing.Size(479, 330);
            this.dataGridViewEventTypes.TabIndex = 3;
            this.dataGridViewEventTypes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEventTypes_CellContentClick);
            // 
            // tabEvents
            // 
            this.tabEvents.AutoScroll = true;
            this.tabEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(224)))), ((int)(((byte)(188)))));
            this.tabEvents.Controls.Add(this.comboBox1);
            this.tabEvents.Controls.Add(this.comboBox2);
            this.tabEvents.Controls.Add(this.txtEventName);
            this.tabEvents.Controls.Add(this.btnEventsSearch);
            this.tabEvents.Controls.Add(this.label5);
            this.tabEvents.Controls.Add(this.label4);
            this.tabEvents.Controls.Add(this.label3);
            this.tabEvents.Controls.Add(this.dataGridViewEvents);
            this.tabEvents.Controls.Add(this.label2);
            this.tabEvents.Controls.Add(this.btnAddEvent);
            this.tabEvents.Controls.Add(this.label6);
            this.tabEvents.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabEvents.Location = new System.Drawing.Point(4, 44);
            this.tabEvents.Name = "tabEvents";
            this.tabEvents.Padding = new System.Windows.Forms.Padding(3);
            this.tabEvents.Size = new System.Drawing.Size(1012, 539);
            this.tabEvents.TabIndex = 1;
            this.tabEvents.Text = "活動";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(150, 343);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 27);
            this.comboBox1.TabIndex = 6;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(150, 287);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(154, 27);
            this.comboBox2.TabIndex = 6;
            // 
            // txtEventName
            // 
            this.txtEventName.Location = new System.Drawing.Point(150, 123);
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.Size = new System.Drawing.Size(154, 26);
            this.txtEventName.TabIndex = 8;
            // 
            // btnEventsSearch
            // 
            this.btnEventsSearch.Location = new System.Drawing.Point(221, 166);
            this.btnEventsSearch.Name = "btnEventsSearch";
            this.btnEventsSearch.Size = new System.Drawing.Size(83, 37);
            this.btnEventsSearch.TabIndex = 11;
            this.btnEventsSearch.Text = "搜尋";
            this.btnEventsSearch.UseVisualStyleBackColor = true;
            this.btnEventsSearch.Click += new System.EventHandler(this.btnEventsSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "活動名稱：     ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 346);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "地區：     ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "活動類型：     ";
            // 
            // dataGridViewEvents
            // 
            this.dataGridViewEvents.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridViewEvents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewEvents.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(224)))), ((int)(((byte)(188)))));
            this.dataGridViewEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEvents.Location = new System.Drawing.Point(348, 123);
            this.dataGridViewEvents.Name = "dataGridViewEvents";
            this.dataGridViewEvents.ReadOnly = true;
            this.dataGridViewEvents.RowHeadersWidth = 51;
            this.dataGridViewEvents.RowTemplate.Height = 24;
            this.dataGridViewEvents.Size = new System.Drawing.Size(594, 348);
            this.dataGridViewEvents.TabIndex = 5;
            this.dataGridViewEvents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEvents_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "活動列表     ";
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(887, 73);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(55, 44);
            this.btnAddEvent.TabIndex = 3;
            this.btnAddEvent.Text = "+";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(450, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "-------------------------------------------------";
            // 
            // tabBatches
            // 
            this.tabBatches.AutoScroll = true;
            this.tabBatches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(224)))), ((int)(((byte)(188)))));
            this.tabBatches.Controls.Add(this.comboBoxBatchEventName);
            this.tabBatches.Controls.Add(this.btnBatchSearch);
            this.tabBatches.Controls.Add(this.label10);
            this.tabBatches.Controls.Add(this.dateTimePickerBatchEnd);
            this.tabBatches.Controls.Add(this.dateTimePickerBatchStart);
            this.tabBatches.Controls.Add(this.label8);
            this.tabBatches.Controls.Add(this.label9);
            this.tabBatches.Controls.Add(this.btnAddBatch);
            this.tabBatches.Controls.Add(this.label7);
            this.tabBatches.Controls.Add(this.dataGridViewBatchList);
            this.tabBatches.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabBatches.Location = new System.Drawing.Point(4, 44);
            this.tabBatches.Name = "tabBatches";
            this.tabBatches.Size = new System.Drawing.Size(1012, 539);
            this.tabBatches.TabIndex = 2;
            this.tabBatches.Text = "活動梯次";
            // 
            // comboBoxBatchEventName
            // 
            this.comboBoxBatchEventName.FormattingEnabled = true;
            this.comboBoxBatchEventName.Location = new System.Drawing.Point(119, 137);
            this.comboBoxBatchEventName.Name = "comboBoxBatchEventName";
            this.comboBoxBatchEventName.Size = new System.Drawing.Size(232, 27);
            this.comboBoxBatchEventName.TabIndex = 9;
            // 
            // btnBatchSearch
            // 
            this.btnBatchSearch.Location = new System.Drawing.Point(119, 391);
            this.btnBatchSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnBatchSearch.Name = "btnBatchSearch";
            this.btnBatchSearch.Size = new System.Drawing.Size(74, 34);
            this.btnBatchSearch.TabIndex = 15;
            this.btnBatchSearch.Text = "搜尋";
            this.btnBatchSearch.UseVisualStyleBackColor = true;
            this.btnBatchSearch.Click += new System.EventHandler(this.btnBatchSearch_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(182, 265);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 19);
            this.label10.TabIndex = 14;
            this.label10.Text = "｜";
            // 
            // dateTimePickerBatchEnd
            // 
            this.dateTimePickerBatchEnd.Location = new System.Drawing.Point(119, 298);
            this.dateTimePickerBatchEnd.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerBatchEnd.Name = "dateTimePickerBatchEnd";
            this.dateTimePickerBatchEnd.Size = new System.Drawing.Size(156, 26);
            this.dateTimePickerBatchEnd.TabIndex = 13;
            // 
            // dateTimePickerBatchStart
            // 
            this.dateTimePickerBatchStart.Location = new System.Drawing.Point(119, 226);
            this.dateTimePickerBatchStart.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerBatchStart.Name = "dateTimePickerBatchStart";
            this.dateTimePickerBatchStart.Size = new System.Drawing.Size(156, 26);
            this.dateTimePickerBatchStart.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 19);
            this.label8.TabIndex = 10;
            this.label8.Text = "活動日期：     ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 19);
            this.label9.TabIndex = 11;
            this.label9.Text = "活動名稱：     ";
            // 
            // btnAddBatch
            // 
            this.btnAddBatch.Location = new System.Drawing.Point(940, 52);
            this.btnAddBatch.Name = "btnAddBatch";
            this.btnAddBatch.Size = new System.Drawing.Size(55, 44);
            this.btnAddBatch.TabIndex = 8;
            this.btnAddBatch.Text = "+";
            this.btnAddBatch.UseVisualStyleBackColor = true;
            this.btnAddBatch.Click += new System.EventHandler(this.btnAddBatch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(275, 32);
            this.label7.TabIndex = 5;
            this.label7.Text = "活動梯次列表     ";
            // 
            // dataGridViewBatchList
            // 
            this.dataGridViewBatchList.AllowUserToAddRows = false;
            this.dataGridViewBatchList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridViewBatchList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewBatchList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewBatchList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(224)))), ((int)(((byte)(188)))));
            this.dataGridViewBatchList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBatchList.Location = new System.Drawing.Point(356, 110);
            this.dataGridViewBatchList.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewBatchList.Name = "dataGridViewBatchList";
            this.dataGridViewBatchList.ReadOnly = true;
            this.dataGridViewBatchList.RowHeadersWidth = 51;
            this.dataGridViewBatchList.RowTemplate.Height = 27;
            this.dataGridViewBatchList.Size = new System.Drawing.Size(639, 386);
            this.dataGridViewBatchList.TabIndex = 0;
            this.dataGridViewBatchList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBatchList_CellContentClick);
            // 
            // fsDataSet1
            // 
            this.fsDataSet1.DataSetName = "fsDataSet";
            this.fsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BatchesTableAdapter = null;
            this.tableAdapterManager.chatMessagesTableAdapter = null;
            this.tableAdapterManager.citiesTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.districtsTableAdapter = null;
            this.tableAdapterManager.EventPhotosTableAdapter = null;
            this.tableAdapterManager.EventsTableAdapter = null;
            this.tableAdapterManager.EventTypesTableAdapter = null;
            this.tableAdapterManager.interestCategoriesTableAdapter = null;
            this.tableAdapterManager.interestsTableAdapter = null;
            this.tableAdapterManager.matchesTableAdapter = null;
            this.tableAdapterManager.memberInterestsTableAdapter = null;
            this.tableAdapterManager.memberPreferencesTableAdapter = null;
            this.tableAdapterManager.memberRolesTableAdapter = null;
            this.tableAdapterManager.membersTableAdapter = null;
            this.tableAdapterManager.OrdersTableAdapter = null;
            this.tableAdapterManager.OrderStatusesTableAdapter = null;
            this.tableAdapterManager.PaymentTypesTableAdapter = null;
            this.tableAdapterManager.permissionsTableAdapter = null;
            this.tableAdapterManager.rolePermissionsTableAdapter = null;
            this.tableAdapterManager.rolesTableAdapter = null;
            this.tableAdapterManager.swipesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = slnFriendshipBackEnd.fsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.vipMembersTableAdapter = null;
            // 
            // UCeventsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(450, 320);
            this.Name = "UCeventsManager";
            this.Size = new System.Drawing.Size(1020, 587);
            this.tabControl1.ResumeLayout(false);
            this.tabEventTypes.ResumeLayout(false);
            this.tabEventTypes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEventTypes)).EndInit();
            this.tabEvents.ResumeLayout(false);
            this.tabEvents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).EndInit();
            this.tabBatches.ResumeLayout(false);
            this.tabBatches.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBatchList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fsDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddEventType;
        private System.Windows.Forms.Label label1;
        private fsDataSet fsDataSet1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEventTypes;
        private System.Windows.Forms.TabPage tabEvents;
        private System.Windows.Forms.TabPage tabBatches;
        private fsDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView dataGridViewEventTypes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.DataGridView dataGridViewEvents;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEventsSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewBatchList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePickerBatchEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerBatchStart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxBatchEventName;
        private System.Windows.Forms.Button btnAddBatch;
        private System.Windows.Forms.Button btnBatchSearch;
    }
}
