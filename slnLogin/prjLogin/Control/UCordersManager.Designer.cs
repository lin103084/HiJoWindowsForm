namespace slnFriendshipBackEnd.UserControls
{
    partial class UCordersManager
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
            this.tabControlOrders = new System.Windows.Forms.TabControl();
            this.tabOrderStatusPaymentTypes = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddPaymentType = new System.Windows.Forms.Button();
            this.btnAddOrderStatus = new System.Windows.Forms.Button();
            this.dataGridViewPaymentTypes = new System.Windows.Forms.DataGridView();
            this.dataGridViewOrderStatuses = new System.Windows.Forms.DataGridView();
            this.tabOrders = new System.Windows.Forms.TabPage();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.dtpOrderDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpOrderDateStart = new System.Windows.Forms.DateTimePicker();
            this.comboBoxPaymentType = new System.Windows.Forms.ComboBox();
            this.comboBoxOrderStatus = new System.Windows.Forms.ComboBox();
            this.comboBoxBatch = new System.Windows.Forms.ComboBox();
            this.comboBoxEvent = new System.Windows.Forms.ComboBox();
            this.txtTotalPriceMax = new System.Windows.Forms.TextBox();
            this.txtTotalPriceMin = new System.Windows.Forms.TextBox();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.txtMemberIDOrName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.tabControlOrders.SuspendLayout();
            this.tabOrderStatusPaymentTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPaymentTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderStatuses)).BeginInit();
            this.tabOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlOrders
            // 
            this.tabControlOrders.Controls.Add(this.tabOrderStatusPaymentTypes);
            this.tabControlOrders.Controls.Add(this.tabOrders);
            this.tabControlOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlOrders.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlOrders.Location = new System.Drawing.Point(0, 0);
            this.tabControlOrders.Margin = new System.Windows.Forms.Padding(2);
            this.tabControlOrders.Name = "tabControlOrders";
            this.tabControlOrders.SelectedIndex = 0;
            this.tabControlOrders.Size = new System.Drawing.Size(916, 614);
            this.tabControlOrders.TabIndex = 0;
            this.tabControlOrders.SelectedIndexChanged += new System.EventHandler(this.tabControlOrders_SelectedIndexChanged);
            // 
            // tabOrderStatusPaymentTypes
            // 
            this.tabOrderStatusPaymentTypes.AutoScroll = true;
            this.tabOrderStatusPaymentTypes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(224)))), ((int)(((byte)(188)))));
            this.tabOrderStatusPaymentTypes.Controls.Add(this.label2);
            this.tabOrderStatusPaymentTypes.Controls.Add(this.label1);
            this.tabOrderStatusPaymentTypes.Controls.Add(this.btnAddPaymentType);
            this.tabOrderStatusPaymentTypes.Controls.Add(this.btnAddOrderStatus);
            this.tabOrderStatusPaymentTypes.Controls.Add(this.dataGridViewPaymentTypes);
            this.tabOrderStatusPaymentTypes.Controls.Add(this.dataGridViewOrderStatuses);
            this.tabOrderStatusPaymentTypes.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabOrderStatusPaymentTypes.Location = new System.Drawing.Point(4, 28);
            this.tabOrderStatusPaymentTypes.Margin = new System.Windows.Forms.Padding(2);
            this.tabOrderStatusPaymentTypes.Name = "tabOrderStatusPaymentTypes";
            this.tabOrderStatusPaymentTypes.Padding = new System.Windows.Forms.Padding(2);
            this.tabOrderStatusPaymentTypes.Size = new System.Drawing.Size(908, 582);
            this.tabOrderStatusPaymentTypes.TabIndex = 0;
            this.tabOrderStatusPaymentTypes.Text = "訂單狀態 / 付款方式";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(450, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "付款方式列表     ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "訂單狀態列表     ";
            // 
            // btnAddPaymentType
            // 
            this.btnAddPaymentType.Location = new System.Drawing.Point(740, 51);
            this.btnAddPaymentType.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddPaymentType.Name = "btnAddPaymentType";
            this.btnAddPaymentType.Size = new System.Drawing.Size(38, 37);
            this.btnAddPaymentType.TabIndex = 1;
            this.btnAddPaymentType.Text = "+";
            this.btnAddPaymentType.UseVisualStyleBackColor = true;
            this.btnAddPaymentType.Click += new System.EventHandler(this.btnAddPaymentType_Click);
            // 
            // btnAddOrderStatus
            // 
            this.btnAddOrderStatus.Location = new System.Drawing.Point(336, 51);
            this.btnAddOrderStatus.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddOrderStatus.Name = "btnAddOrderStatus";
            this.btnAddOrderStatus.Size = new System.Drawing.Size(38, 37);
            this.btnAddOrderStatus.TabIndex = 1;
            this.btnAddOrderStatus.Text = "+";
            this.btnAddOrderStatus.UseVisualStyleBackColor = true;
            this.btnAddOrderStatus.Click += new System.EventHandler(this.btnAddOrderStatus_Click);
            // 
            // dataGridViewPaymentTypes
            // 
            this.dataGridViewPaymentTypes.AllowUserToAddRows = false;
            this.dataGridViewPaymentTypes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridViewPaymentTypes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPaymentTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewPaymentTypes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(224)))), ((int)(((byte)(188)))));
            this.dataGridViewPaymentTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPaymentTypes.Location = new System.Drawing.Point(454, 104);
            this.dataGridViewPaymentTypes.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewPaymentTypes.Name = "dataGridViewPaymentTypes";
            this.dataGridViewPaymentTypes.RowHeadersWidth = 51;
            this.dataGridViewPaymentTypes.RowTemplate.Height = 27;
            this.dataGridViewPaymentTypes.Size = new System.Drawing.Size(323, 222);
            this.dataGridViewPaymentTypes.TabIndex = 0;
            this.dataGridViewPaymentTypes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPaymentTypes_CellContentClick);
            // 
            // dataGridViewOrderStatuses
            // 
            this.dataGridViewOrderStatuses.AllowUserToAddRows = false;
            this.dataGridViewOrderStatuses.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridViewOrderStatuses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewOrderStatuses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewOrderStatuses.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(224)))), ((int)(((byte)(188)))));
            this.dataGridViewOrderStatuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderStatuses.Location = new System.Drawing.Point(51, 104);
            this.dataGridViewOrderStatuses.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewOrderStatuses.Name = "dataGridViewOrderStatuses";
            this.dataGridViewOrderStatuses.RowHeadersWidth = 51;
            this.dataGridViewOrderStatuses.RowTemplate.Height = 27;
            this.dataGridViewOrderStatuses.Size = new System.Drawing.Size(322, 222);
            this.dataGridViewOrderStatuses.TabIndex = 0;
            this.dataGridViewOrderStatuses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrderStatuses_CellContentClick);
            // 
            // tabOrders
            // 
            this.tabOrders.AutoScroll = true;
            this.tabOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(224)))), ((int)(((byte)(188)))));
            this.tabOrders.Controls.Add(this.btnSearch);
            this.tabOrders.Controls.Add(this.btnAddOrder);
            this.tabOrders.Controls.Add(this.dtpOrderDateEnd);
            this.tabOrders.Controls.Add(this.dtpOrderDateStart);
            this.tabOrders.Controls.Add(this.comboBoxPaymentType);
            this.tabOrders.Controls.Add(this.comboBoxOrderStatus);
            this.tabOrders.Controls.Add(this.comboBoxBatch);
            this.tabOrders.Controls.Add(this.comboBoxEvent);
            this.tabOrders.Controls.Add(this.txtTotalPriceMax);
            this.tabOrders.Controls.Add(this.txtTotalPriceMin);
            this.tabOrders.Controls.Add(this.txtOrderID);
            this.tabOrders.Controls.Add(this.txtMemberIDOrName);
            this.tabOrders.Controls.Add(this.label7);
            this.tabOrders.Controls.Add(this.label6);
            this.tabOrders.Controls.Add(this.label9);
            this.tabOrders.Controls.Add(this.label13);
            this.tabOrders.Controls.Add(this.label12);
            this.tabOrders.Controls.Add(this.label11);
            this.tabOrders.Controls.Add(this.label8);
            this.tabOrders.Controls.Add(this.label10);
            this.tabOrders.Controls.Add(this.label5);
            this.tabOrders.Controls.Add(this.label4);
            this.tabOrders.Controls.Add(this.label3);
            this.tabOrders.Controls.Add(this.dataGridViewOrders);
            this.tabOrders.Location = new System.Drawing.Point(4, 28);
            this.tabOrders.Margin = new System.Windows.Forms.Padding(2);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.Padding = new System.Windows.Forms.Padding(2);
            this.tabOrders.Size = new System.Drawing.Size(908, 582);
            this.tabOrders.TabIndex = 1;
            this.tabOrders.Text = "訂單";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(408, 218);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(82, 40);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "搜尋";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(837, 240);
            this.btnAddOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(42, 34);
            this.btnAddOrder.TabIndex = 8;
            this.btnAddOrder.Text = "+";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // dtpOrderDateEnd
            // 
            this.dtpOrderDateEnd.Location = new System.Drawing.Point(728, 133);
            this.dtpOrderDateEnd.Margin = new System.Windows.Forms.Padding(2);
            this.dtpOrderDateEnd.Name = "dtpOrderDateEnd";
            this.dtpOrderDateEnd.Size = new System.Drawing.Size(151, 26);
            this.dtpOrderDateEnd.TabIndex = 7;
            // 
            // dtpOrderDateStart
            // 
            this.dtpOrderDateStart.Location = new System.Drawing.Point(527, 133);
            this.dtpOrderDateStart.Margin = new System.Windows.Forms.Padding(2);
            this.dtpOrderDateStart.Name = "dtpOrderDateStart";
            this.dtpOrderDateStart.Size = new System.Drawing.Size(151, 26);
            this.dtpOrderDateStart.TabIndex = 7;
            // 
            // comboBoxPaymentType
            // 
            this.comboBoxPaymentType.FormattingEnabled = true;
            this.comboBoxPaymentType.Location = new System.Drawing.Point(143, 169);
            this.comboBoxPaymentType.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxPaymentType.Name = "comboBoxPaymentType";
            this.comboBoxPaymentType.Size = new System.Drawing.Size(216, 27);
            this.comboBoxPaymentType.TabIndex = 6;
            this.comboBoxPaymentType.SelectedIndexChanged += new System.EventHandler(this.comboBoxPaymentType_SelectedIndexChanged);
            // 
            // comboBoxOrderStatus
            // 
            this.comboBoxOrderStatus.FormattingEnabled = true;
            this.comboBoxOrderStatus.Location = new System.Drawing.Point(143, 133);
            this.comboBoxOrderStatus.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxOrderStatus.Name = "comboBoxOrderStatus";
            this.comboBoxOrderStatus.Size = new System.Drawing.Size(216, 27);
            this.comboBoxOrderStatus.TabIndex = 6;
            this.comboBoxOrderStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrderStatus_SelectedIndexChanged);
            // 
            // comboBoxBatch
            // 
            this.comboBoxBatch.FormattingEnabled = true;
            this.comboBoxBatch.Location = new System.Drawing.Point(496, 96);
            this.comboBoxBatch.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxBatch.Name = "comboBoxBatch";
            this.comboBoxBatch.Size = new System.Drawing.Size(232, 27);
            this.comboBoxBatch.TabIndex = 6;
            this.comboBoxBatch.SelectedIndexChanged += new System.EventHandler(this.comboBoxBatch_SelectedIndexChanged);
            // 
            // comboBoxEvent
            // 
            this.comboBoxEvent.FormattingEnabled = true;
            this.comboBoxEvent.Location = new System.Drawing.Point(116, 96);
            this.comboBoxEvent.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxEvent.Name = "comboBoxEvent";
            this.comboBoxEvent.Size = new System.Drawing.Size(243, 27);
            this.comboBoxEvent.TabIndex = 6;
            this.comboBoxEvent.SelectedIndexChanged += new System.EventHandler(this.comboBoxEvent_SelectedIndexChanged);
            // 
            // txtTotalPriceMax
            // 
            this.txtTotalPriceMax.Location = new System.Drawing.Point(637, 169);
            this.txtTotalPriceMax.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalPriceMax.Name = "txtTotalPriceMax";
            this.txtTotalPriceMax.Size = new System.Drawing.Size(91, 26);
            this.txtTotalPriceMax.TabIndex = 5;
            // 
            // txtTotalPriceMin
            // 
            this.txtTotalPriceMin.Location = new System.Drawing.Point(496, 169);
            this.txtTotalPriceMin.Margin = new System.Windows.Forms.Padding(2);
            this.txtTotalPriceMin.Name = "txtTotalPriceMin";
            this.txtTotalPriceMin.Size = new System.Drawing.Size(91, 26);
            this.txtTotalPriceMin.TabIndex = 5;
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(478, 59);
            this.txtOrderID.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(125, 26);
            this.txtOrderID.TabIndex = 5;
            // 
            // txtMemberIDOrName
            // 
            this.txtMemberIDOrName.Location = new System.Drawing.Point(235, 60);
            this.txtMemberIDOrName.Margin = new System.Windows.Forms.Padding(2);
            this.txtMemberIDOrName.Name = "txtMemberIDOrName";
            this.txtMemberIDOrName.Size = new System.Drawing.Size(125, 26);
            this.txtMemberIDOrName.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(405, 135);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 19);
            this.label7.TabIndex = 4;
            this.label7.Text = "訂單成立日期：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(405, 62);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "訂單ID：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 135);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 19);
            this.label9.TabIndex = 4;
            this.label9.Text = "訂單狀態：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(689, 135);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 19);
            this.label13.TabIndex = 4;
            this.label13.Text = "～";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(598, 171);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 19);
            this.label12.TabIndex = 4;
            this.label12.Text = "～";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(405, 171);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 19);
            this.label11.TabIndex = 4;
            this.label11.Text = "訂單金額：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 171);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 19);
            this.label8.TabIndex = 4;
            this.label8.Text = "付款方式：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(405, 98);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 19);
            this.label10.TabIndex = 4;
            this.label10.Text = "活動梯次：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 98);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "活動：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "會員 ID / 會員姓名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "訂單列表";
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.AllowUserToAddRows = false;
            this.dataGridViewOrders.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridViewOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewOrders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(224)))), ((int)(((byte)(188)))));
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(56, 278);
            this.dataGridViewOrders.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.ReadOnly = true;
            this.dataGridViewOrders.RowHeadersWidth = 51;
            this.dataGridViewOrders.RowTemplate.Height = 27;
            this.dataGridViewOrders.Size = new System.Drawing.Size(822, 291);
            this.dataGridViewOrders.TabIndex = 0;
            this.dataGridViewOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrders_CellContentClick);
            // 
            // UCordersManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlOrders);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCordersManager";
            this.Size = new System.Drawing.Size(916, 614);
            this.tabControlOrders.ResumeLayout(false);
            this.tabOrderStatusPaymentTypes.ResumeLayout(false);
            this.tabOrderStatusPaymentTypes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPaymentTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderStatuses)).EndInit();
            this.tabOrders.ResumeLayout(false);
            this.tabOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlOrders;
        private System.Windows.Forms.TabPage tabOrderStatusPaymentTypes;
        private System.Windows.Forms.TabPage tabOrders;
        private System.Windows.Forms.DataGridView dataGridViewOrderStatuses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddPaymentType;
        private System.Windows.Forms.Button btnAddOrderStatus;
        private System.Windows.Forms.DataGridView dataGridViewPaymentTypes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.TextBox txtMemberIDOrName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxPaymentType;
        private System.Windows.Forms.ComboBox comboBoxOrderStatus;
        private System.Windows.Forms.ComboBox comboBoxEvent;
        private System.Windows.Forms.TextBox txtTotalPriceMax;
        private System.Windows.Forms.TextBox txtTotalPriceMin;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.DateTimePicker dtpOrderDateEnd;
        private System.Windows.Forms.DateTimePicker dtpOrderDateStart;
        private System.Windows.Forms.ComboBox comboBoxBatch;
        private System.Windows.Forms.Label label13;
    }
}
