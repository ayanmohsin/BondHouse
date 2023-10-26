namespace ExchangeCompanySoftware
{
    partial class frmTradingVoucher
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdCompleteSale = new System.Windows.Forms.Button();
            this.dtbDetail = new System.Windows.Forms.DataGridView();
            this.dotxtCnicNo = new ExchangeCompanySoftware.cstTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dicboTransaction = new ExchangeCompanySoftware.cstComboBox();
            this.dicboCustomerType = new ExchangeCompanySoftware.cstComboBox();
            this.dotxtCustomerName = new ExchangeCompanySoftware.cstTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ditxtVoucherNo = new ExchangeCompanySoftware.cstTextBox();
            this.docboCustName = new ExchangeCompanySoftware.cstComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dotxtTokenNo = new ExchangeCompanySoftware.cstTextBox();
            this.dotxtAddress = new ExchangeCompanySoftware.cstTextBox();
            this.dtDate = new ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.PnlMain = new System.Windows.Forms.Panel();
            this.lblCrime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dotxtRemarks = new ExchangeCompanySoftware.cstTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dicbopaymentMode = new ExchangeCompanySoftware.cstComboBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblusdAmount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.donumStockV = new ExchangeCompanySoftware.cstNumericupDown();
            this.numEXRAtes = new ExchangeCompanySoftware.cstNumericupDown();
            this.donumMinRate = new ExchangeCompanySoftware.cstNumericupDown();
            this.donumAverage = new ExchangeCompanySoftware.cstNumericupDown();
            this.donumMax = new ExchangeCompanySoftware.cstNumericupDown();
            this.donumStock = new ExchangeCompanySoftware.cstNumericupDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).BeginInit();
            this.PnlMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.c.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donumStockV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEXRAtes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumMinRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumStock)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCompleteSale
            // 
            this.cmdCompleteSale.Location = new System.Drawing.Point(12, 136);
            this.cmdCompleteSale.Name = "cmdCompleteSale";
            this.cmdCompleteSale.Size = new System.Drawing.Size(115, 23);
            this.cmdCompleteSale.TabIndex = 60;
            this.cmdCompleteSale.Text = "Complete Sale";
            this.cmdCompleteSale.UseVisualStyleBackColor = true;
            this.cmdCompleteSale.Visible = false;
            this.cmdCompleteSale.Click += new System.EventHandler(this.cmdCompleteSale_Click);
            // 
            // dtbDetail
            // 
            this.dtbDetail.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtbDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtbDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtbDetail.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtbDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbDetail.Location = new System.Drawing.Point(6, 163);
            this.dtbDetail.Name = "dtbDetail";
            this.dtbDetail.Size = new System.Drawing.Size(852, 184);
            this.dtbDetail.TabIndex = 6;
            this.dtbDetail.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtbDetail_CellPainting);
            this.dtbDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtbDetail_CellContentClick);
            // 
            // dotxtCnicNo
            // 
            this.dotxtCnicNo.BackColor = System.Drawing.Color.Snow;
            this.dotxtCnicNo.DataField = null;
            this.dotxtCnicNo.Location = new System.Drawing.Point(666, 182);
            this.dotxtCnicNo.Name = "dotxtCnicNo";
            this.dotxtCnicNo.Size = new System.Drawing.Size(163, 20);
            this.dotxtCnicNo.TabIndex = 4;
            this.dotxtCnicNo.Tag = "CNICNO";
            this.dotxtCnicNo.Visible = false;
            this.dotxtCnicNo.TextChanged += new System.EventHandler(this.dotxtCnicNo_TextChanged);
            this.dotxtCnicNo.Validated += new System.EventHandler(this.dotxtCnicNo_Validated_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Transaction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(787, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Invoice No";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Customer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(674, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Address";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(562, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "CNIC No /Passport";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(330, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Type";
            // 
            // dicboTransaction
            // 
            this.dicboTransaction.BackColor = System.Drawing.Color.Snow;
            this.dicboTransaction.DataField = "TransType";
            this.dicboTransaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicboTransaction.FormattingEnabled = true;
            this.dicboTransaction.Location = new System.Drawing.Point(291, 54);
            this.dicboTransaction.Name = "dicboTransaction";
            this.dicboTransaction.Size = new System.Drawing.Size(134, 21);
            this.dicboTransaction.TabIndex = 0;
            this.dicboTransaction.Tag = "TransType";
            this.dicboTransaction.SelectedIndexChanged += new System.EventHandler(this.dicboTransaction_SelectedIndexChanged);
            this.dicboTransaction.Validated += new System.EventHandler(this.cboTransaction_Validated);
            // 
            // dicboCustomerType
            // 
            this.dicboCustomerType.BackColor = System.Drawing.Color.Snow;
            this.dicboCustomerType.DataField = "CustomerType";
            this.dicboCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicboCustomerType.FormattingEnabled = true;
            this.dicboCustomerType.Location = new System.Drawing.Point(367, 109);
            this.dicboCustomerType.Name = "dicboCustomerType";
            this.dicboCustomerType.Size = new System.Drawing.Size(206, 21);
            this.dicboCustomerType.TabIndex = 1;
            this.dicboCustomerType.Tag = "CustomerType";
            this.dicboCustomerType.SelectedIndexChanged += new System.EventHandler(this.dicboCustomerType_SelectedIndexChanged);
            this.dicboCustomerType.Validated += new System.EventHandler(this.dicboCustomerType_Validated);
            // 
            // dotxtCustomerName
            // 
            this.dotxtCustomerName.BackColor = System.Drawing.Color.Snow;
            this.dotxtCustomerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dotxtCustomerName.DataField = "CustomerName";
            this.dotxtCustomerName.Location = new System.Drawing.Point(117, 83);
            this.dotxtCustomerName.Name = "dotxtCustomerName";
            this.dotxtCustomerName.Size = new System.Drawing.Size(456, 20);
            this.dotxtCustomerName.TabIndex = 2;
            this.dotxtCustomerName.Tag = "CustomerName";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "Trans No";
            // 
            // ditxtVoucherNo
            // 
            this.ditxtVoucherNo.BackColor = System.Drawing.Color.Snow;
            this.ditxtVoucherNo.DataField = "VoucherNo";
            this.ditxtVoucherNo.Enabled = false;
            this.ditxtVoucherNo.Location = new System.Drawing.Point(116, 55);
            this.ditxtVoucherNo.Name = "ditxtVoucherNo";
            this.ditxtVoucherNo.Size = new System.Drawing.Size(100, 20);
            this.ditxtVoucherNo.TabIndex = 0;
            this.ditxtVoucherNo.Tag = "VoucherNo";
            this.ditxtVoucherNo.TextChanged += new System.EventHandler(this.ditxtVoucherNo_TextChanged);
            // 
            // docboCustName
            // 
            this.docboCustName.BackColor = System.Drawing.Color.Snow;
            this.docboCustName.DataField = "CustomerType";
            this.docboCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.docboCustName.FormattingEnabled = true;
            this.docboCustName.Location = new System.Drawing.Point(635, 232);
            this.docboCustName.Name = "docboCustName";
            this.docboCustName.Size = new System.Drawing.Size(205, 21);
            this.docboCustName.TabIndex = 54;
            this.docboCustName.Tag = "";
            this.docboCustName.Validated += new System.EventHandler(this.docboCustName_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(787, 151);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 59;
            this.label13.Text = "Token";
            this.label13.Visible = false;
            // 
            // dotxtTokenNo
            // 
            this.dotxtTokenNo.BackColor = System.Drawing.Color.Snow;
            this.dotxtTokenNo.DataField = "VoucherNo";
            this.dotxtTokenNo.Enabled = false;
            this.dotxtTokenNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dotxtTokenNo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.dotxtTokenNo.Location = new System.Drawing.Point(769, 167);
            this.dotxtTokenNo.Name = "dotxtTokenNo";
            this.dotxtTokenNo.Size = new System.Drawing.Size(80, 49);
            this.dotxtTokenNo.TabIndex = 58;
            this.dotxtTokenNo.Tag = "TokenNo";
            this.dotxtTokenNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dotxtTokenNo.Visible = false;
            // 
            // dotxtAddress
            // 
            this.dotxtAddress.BackColor = System.Drawing.Color.Snow;
            this.dotxtAddress.DataField = null;
            this.dotxtAddress.Location = new System.Drawing.Point(778, 163);
            this.dotxtAddress.Name = "dotxtAddress";
            this.dotxtAddress.Size = new System.Drawing.Size(39, 20);
            this.dotxtAddress.TabIndex = 3;
            this.dotxtAddress.Tag = "Address";
            this.dotxtAddress.Visible = false;
            this.dotxtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.dotxtAddress_Validating);
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd/MMM/yyyy";
            this.dtDate.DataField = null;
            this.dtDate.Enabled = false;
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(117, 29);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(106, 20);
            this.dtDate.TabIndex = 815;
            this.dtDate.Tag = "TransDate";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 816;
            this.label16.Text = "Trans Date";
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.Transparent;
            this.PnlMain.Controls.Add(this.lblCrime);
            this.PnlMain.Controls.Add(this.label7);
            this.PnlMain.Controls.Add(this.dotxtRemarks);
            this.PnlMain.Controls.Add(this.label17);
            this.PnlMain.Controls.Add(this.dicbopaymentMode);
            this.PnlMain.Controls.Add(this.label16);
            this.PnlMain.Controls.Add(this.dtDate);
            this.PnlMain.Controls.Add(this.dotxtAddress);
            this.PnlMain.Controls.Add(this.dotxtTokenNo);
            this.PnlMain.Controls.Add(this.label13);
            this.PnlMain.Controls.Add(this.docboCustName);
            this.PnlMain.Controls.Add(this.ditxtVoucherNo);
            this.PnlMain.Controls.Add(this.label12);
            this.PnlMain.Controls.Add(this.dotxtCustomerName);
            this.PnlMain.Controls.Add(this.dicboCustomerType);
            this.PnlMain.Controls.Add(this.dicboTransaction);
            this.PnlMain.Controls.Add(this.label6);
            this.PnlMain.Controls.Add(this.label5);
            this.PnlMain.Controls.Add(this.label4);
            this.PnlMain.Controls.Add(this.label3);
            this.PnlMain.Controls.Add(this.label2);
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Controls.Add(this.dotxtCnicNo);
            this.PnlMain.Location = new System.Drawing.Point(3, 1);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(576, 161);
            this.PnlMain.TabIndex = 99;
            this.PnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlMain_Paint);
            // 
            // lblCrime
            // 
            this.lblCrime.AutoSize = true;
            this.lblCrime.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrime.ForeColor = System.Drawing.Color.Red;
            this.lblCrime.Location = new System.Drawing.Point(760, 171);
            this.lblCrime.Name = "lblCrime";
            this.lblCrime.Size = new System.Drawing.Size(71, 16);
            this.lblCrime.TabIndex = 821;
            this.lblCrime.Text = "Crime List";
            this.lblCrime.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(397, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 820;
            this.label7.Text = "Remarks";
            this.label7.Visible = false;
            // 
            // dotxtRemarks
            // 
            this.dotxtRemarks.BackColor = System.Drawing.Color.Snow;
            this.dotxtRemarks.DataField = null;
            this.dotxtRemarks.Location = new System.Drawing.Point(452, 133);
            this.dotxtRemarks.Name = "dotxtRemarks";
            this.dotxtRemarks.Size = new System.Drawing.Size(11, 20);
            this.dotxtRemarks.TabIndex = 5;
            this.dotxtRemarks.Tag = "Remarks";
            this.dotxtRemarks.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 117);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 13);
            this.label17.TabIndex = 818;
            this.label17.Text = "Account";
            // 
            // dicbopaymentMode
            // 
            this.dicbopaymentMode.BackColor = System.Drawing.Color.Snow;
            this.dicbopaymentMode.DataField = "TransType";
            this.dicbopaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicbopaymentMode.FormattingEnabled = true;
            this.dicbopaymentMode.Location = new System.Drawing.Point(117, 109);
            this.dicbopaymentMode.Name = "dicbopaymentMode";
            this.dicbopaymentMode.Size = new System.Drawing.Size(207, 21);
            this.dicbopaymentMode.TabIndex = 817;
            this.dicbopaymentMode.Tag = "PaymentMode";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(631, 2);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(19, 20);
            this.lblTotalAmount.TabIndex = 58;
            this.lblTotalAmount.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(451, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 20);
            this.label14.TabIndex = 60;
            this.label14.Text = "Total Amount";
            // 
            // lblusdAmount
            // 
            this.lblusdAmount.AutoSize = true;
            this.lblusdAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusdAmount.Location = new System.Drawing.Point(746, 2);
            this.lblusdAmount.Name = "lblusdAmount";
            this.lblusdAmount.Size = new System.Drawing.Size(19, 20);
            this.lblusdAmount.TabIndex = 59;
            this.lblusdAmount.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblusdAmount);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.lblTotalAmount);
            this.panel1.Location = new System.Drawing.Point(3, 352);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 23);
            this.panel1.TabIndex = 701;
            // 
            // c
            // 
            this.c.BackColor = System.Drawing.Color.Transparent;
            this.c.Controls.Add(this.label20);
            this.c.Controls.Add(this.label19);
            this.c.Controls.Add(this.donumStockV);
            this.c.Controls.Add(this.cmdCompleteSale);
            this.c.Controls.Add(this.numEXRAtes);
            this.c.Controls.Add(this.donumMinRate);
            this.c.Controls.Add(this.donumAverage);
            this.c.Controls.Add(this.donumMax);
            this.c.Controls.Add(this.donumStock);
            this.c.Controls.Add(this.label11);
            this.c.Controls.Add(this.label10);
            this.c.Controls.Add(this.label9);
            this.c.Controls.Add(this.label8);
            this.c.Enabled = false;
            this.c.Location = new System.Drawing.Point(582, 0);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(273, 158);
            this.c.TabIndex = 703;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(187, 23);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 13);
            this.label20.TabIndex = 62;
            this.label20.Text = "IN VAULT";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(75, 23);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 13);
            this.label19.TabIndex = 61;
            this.label19.Text = "IN HAND";
            // 
            // donumStockV
            // 
            this.donumStockV.BackColor = System.Drawing.Color.Snow;
            this.donumStockV.DataField = null;
            this.donumStockV.DecimalPlaces = 4;
            this.donumStockV.Location = new System.Drawing.Point(47, 37);
            this.donumStockV.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.donumStockV.Name = "donumStockV";
            this.donumStockV.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.donumStockV.Size = new System.Drawing.Size(103, 20);
            this.donumStockV.TabIndex = 60;
            // 
            // numEXRAtes
            // 
            this.numEXRAtes.BackColor = System.Drawing.Color.Snow;
            this.numEXRAtes.DataField = null;
            this.numEXRAtes.DecimalPlaces = 4;
            this.numEXRAtes.Location = new System.Drawing.Point(47, 117);
            this.numEXRAtes.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numEXRAtes.Name = "numEXRAtes";
            this.numEXRAtes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numEXRAtes.Size = new System.Drawing.Size(103, 20);
            this.numEXRAtes.TabIndex = 19;
            // 
            // donumMinRate
            // 
            this.donumMinRate.BackColor = System.Drawing.Color.Snow;
            this.donumMinRate.DataField = null;
            this.donumMinRate.DecimalPlaces = 4;
            this.donumMinRate.Location = new System.Drawing.Point(47, 76);
            this.donumMinRate.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.donumMinRate.Name = "donumMinRate";
            this.donumMinRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.donumMinRate.Size = new System.Drawing.Size(103, 20);
            this.donumMinRate.TabIndex = 18;
            // 
            // donumAverage
            // 
            this.donumAverage.BackColor = System.Drawing.Color.Snow;
            this.donumAverage.DataField = null;
            this.donumAverage.DecimalPlaces = 4;
            this.donumAverage.Location = new System.Drawing.Point(156, 117);
            this.donumAverage.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.donumAverage.Name = "donumAverage";
            this.donumAverage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.donumAverage.Size = new System.Drawing.Size(103, 20);
            this.donumAverage.TabIndex = 17;
            // 
            // donumMax
            // 
            this.donumMax.BackColor = System.Drawing.Color.Snow;
            this.donumMax.DataField = null;
            this.donumMax.DecimalPlaces = 4;
            this.donumMax.Location = new System.Drawing.Point(156, 76);
            this.donumMax.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.donumMax.Name = "donumMax";
            this.donumMax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.donumMax.Size = new System.Drawing.Size(103, 20);
            this.donumMax.TabIndex = 16;
            // 
            // donumStock
            // 
            this.donumStock.BackColor = System.Drawing.Color.Snow;
            this.donumStock.DataField = null;
            this.donumStock.DecimalPlaces = 4;
            this.donumStock.Location = new System.Drawing.Point(156, 37);
            this.donumStock.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.donumStock.Name = "donumStock";
            this.donumStock.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.donumStock.Size = new System.Drawing.Size(103, 20);
            this.donumStock.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(75, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "Minimum";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(187, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 58;
            this.label10.Text = "Average";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(187, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 57;
            this.label9.Text = "Maximum";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 59;
            this.label8.Text = "Equilent US$ Rate";
            // 
            // frmTradingVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 591);
            this.Controls.Add(this.c);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtbDetail);
            this.Name = "frmTradingVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "S";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Activated += new System.EventHandler(this.frmTradingVoucher_Activated);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmTradingVoucher_KeyPress);
            this.Controls.SetChildIndex(this.dtbDetail, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.PnlMain, 0);
            this.Controls.SetChildIndex(this.c, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).EndInit();
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.c.ResumeLayout(false);
            this.c.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donumStockV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEXRAtes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumMinRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCompleteSale;
        private System.Windows.Forms.DataGridView dtbDetail;
        private cstTextBox dotxtCnicNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private cstComboBox dicboTransaction;
        private cstComboBox dicboCustomerType;
        private cstTextBox dotxtCustomerName;
        private System.Windows.Forms.Label label12;
        private cstTextBox ditxtVoucherNo;
        private cstComboBox docboCustName;
        private System.Windows.Forms.Label label13;
        private cstTextBox dotxtTokenNo;
        private cstTextBox dotxtAddress;
        public ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblusdAmount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label17;
        private cstComboBox dicbopaymentMode;
        private System.Windows.Forms.Label label7;
        private cstTextBox dotxtRemarks;
        private System.Windows.Forms.Label lblCrime;
        private System.Windows.Forms.Panel c;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private cstNumericupDown donumStockV;
        private cstNumericupDown numEXRAtes;
        private cstNumericupDown donumMinRate;
        private cstNumericupDown donumAverage;
        private cstNumericupDown donumMax;
        private cstNumericupDown donumStock;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}

