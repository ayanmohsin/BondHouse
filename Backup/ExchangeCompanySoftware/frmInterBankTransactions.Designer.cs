namespace ExchangeCompanySoftware
{
    partial class frmInterBankTransactions
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblusdAmount = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.c = new System.Windows.Forms.Panel();
            this.numEXRAtes = new ExchangeCompanySoftware.cstNumericupDown();
            this.donumMinRate = new ExchangeCompanySoftware.cstNumericupDown();
            this.donumAverage = new ExchangeCompanySoftware.cstNumericupDown();
            this.donumMax = new ExchangeCompanySoftware.cstNumericupDown();
            this.donumStock = new ExchangeCompanySoftware.cstNumericupDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.PnlMain = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.dtDealDate = new ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker();
            this.dicboVoucherType = new ExchangeCompanySoftware.cstComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtDate = new ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker();
            this.pnlMain1 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.label21 = new System.Windows.Forms.Label();
            this.dicboTransType = new ExchangeCompanySoftware.cstComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dotxtRemarks = new ExchangeCompanySoftware.cstTextBox();
            this.dicboParty = new ExchangeCompanySoftware.cstComboBox();
            this.dinumConversionRate = new ExchangeCompanySoftware.cstNumericupDown();
            this.dicboCurrency = new ExchangeCompanySoftware.cstComboBox();
            this.dicboPaymentMode = new ExchangeCompanySoftware.cstComboBox();
            this.ditxtBillMemo = new ExchangeCompanySoftware.cstTextBox();
            this.ditxtTransNo = new ExchangeCompanySoftware.cstTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtbDetail = new System.Windows.Forms.DataGridView();
            this.pnlMain2 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlMain7 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.label36 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.c.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEXRAtes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumMinRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumStock)).BeginInit();
            this.PnlMain.SuspendLayout();
            this.pnlMain1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dinumConversionRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).BeginInit();
            this.pnlMain2.SuspendLayout();
            this.pnlMain7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblusdAmount);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.lblTotalAmount);
            this.panel1.Location = new System.Drawing.Point(2, 331);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 30);
            this.panel1.TabIndex = 728;
            // 
            // lblusdAmount
            // 
            this.lblusdAmount.AutoSize = true;
            this.lblusdAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusdAmount.Location = new System.Drawing.Point(674, 7);
            this.lblusdAmount.Name = "lblusdAmount";
            this.lblusdAmount.Size = new System.Drawing.Size(16, 16);
            this.lblusdAmount.TabIndex = 728;
            this.lblusdAmount.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(195, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 18);
            this.label15.TabIndex = 729;
            this.label15.Text = "Total Amount";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(450, 7);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(16, 16);
            this.lblTotalAmount.TabIndex = 727;
            this.lblTotalAmount.Text = "0";
            // 
            // c
            // 
            this.c.BackColor = System.Drawing.Color.Transparent;
            this.c.Controls.Add(this.numEXRAtes);
            this.c.Controls.Add(this.donumMinRate);
            this.c.Controls.Add(this.donumAverage);
            this.c.Controls.Add(this.donumMax);
            this.c.Controls.Add(this.donumStock);
            this.c.Controls.Add(this.label11);
            this.c.Controls.Add(this.label10);
            this.c.Controls.Add(this.label12);
            this.c.Controls.Add(this.label13);
            this.c.Controls.Add(this.label14);
            this.c.Enabled = false;
            this.c.Location = new System.Drawing.Point(601, 20);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(223, 137);
            this.c.TabIndex = 727;
            // 
            // numEXRAtes
            // 
            this.numEXRAtes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.numEXRAtes.DataField = null;
            this.numEXRAtes.DecimalPlaces = 4;
            this.numEXRAtes.Location = new System.Drawing.Point(107, 113);
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
            this.donumMinRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.donumMinRate.DataField = null;
            this.donumMinRate.DecimalPlaces = 4;
            this.donumMinRate.Location = new System.Drawing.Point(107, 42);
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
            this.donumAverage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.donumAverage.DataField = null;
            this.donumAverage.DecimalPlaces = 4;
            this.donumAverage.Location = new System.Drawing.Point(107, 88);
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
            this.donumMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.donumMax.DataField = null;
            this.donumMax.DecimalPlaces = 4;
            this.donumMax.Location = new System.Drawing.Point(107, 65);
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
            this.donumStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.donumStock.DataField = null;
            this.donumStock.DecimalPlaces = 4;
            this.donumStock.Location = new System.Drawing.Point(107, 19);
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
            this.label11.Location = new System.Drawing.Point(6, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "Minimum";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 58;
            this.label10.Text = "Average";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 57;
            this.label12.Text = "Maximum";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 13);
            this.label13.TabIndex = 59;
            this.label13.Text = "Equilent US$ Rate";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 55;
            this.label14.Text = "Stock";
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.Transparent;
            this.PnlMain.Controls.Add(this.label18);
            this.PnlMain.Controls.Add(this.dtDealDate);
            this.PnlMain.Controls.Add(this.dicboVoucherType);
            this.PnlMain.Controls.Add(this.label17);
            this.PnlMain.Controls.Add(this.label16);
            this.PnlMain.Controls.Add(this.dtDate);
            this.PnlMain.Controls.Add(this.pnlMain1);
            this.PnlMain.Controls.Add(this.dicboTransType);
            this.PnlMain.Controls.Add(this.label3);
            this.PnlMain.Controls.Add(this.dotxtRemarks);
            this.PnlMain.Controls.Add(this.dicboParty);
            this.PnlMain.Controls.Add(this.dinumConversionRate);
            this.PnlMain.Controls.Add(this.dicboCurrency);
            this.PnlMain.Controls.Add(this.dicboPaymentMode);
            this.PnlMain.Controls.Add(this.ditxtBillMemo);
            this.PnlMain.Controls.Add(this.ditxtTransNo);
            this.PnlMain.Controls.Add(this.label9);
            this.PnlMain.Controls.Add(this.label8);
            this.PnlMain.Controls.Add(this.label7);
            this.PnlMain.Controls.Add(this.label6);
            this.PnlMain.Controls.Add(this.label4);
            this.PnlMain.Controls.Add(this.label2);
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Location = new System.Drawing.Point(2, -1);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(598, 158);
            this.PnlMain.TabIndex = 726;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(447, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 13);
            this.label18.TabIndex = 879;
            this.label18.Text = "Deal Date";
            // 
            // dtDealDate
            // 
            this.dtDealDate.CustomFormat = "dd/MMM/yyyy";
            this.dtDealDate.DataField = null;
            this.dtDealDate.Enabled = false;
            this.dtDealDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDealDate.Location = new System.Drawing.Point(503, 29);
            this.dtDealDate.Name = "dtDealDate";
            this.dtDealDate.Size = new System.Drawing.Size(89, 20);
            this.dtDealDate.TabIndex = 0;
            this.dtDealDate.Tag = "DealDate";
            this.dtDealDate.Validated += new System.EventHandler(this.cstDateTimePicker1_Validated);
            // 
            // dicboVoucherType
            // 
            this.dicboVoucherType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.dicboVoucherType.DataField = null;
            this.dicboVoucherType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicboVoucherType.FormattingEnabled = true;
            this.dicboVoucherType.Location = new System.Drawing.Point(288, 83);
            this.dicboVoucherType.Name = "dicboVoucherType";
            this.dicboVoucherType.Size = new System.Drawing.Size(304, 21);
            this.dicboVoucherType.TabIndex = 5;
            this.dicboVoucherType.Tag = "VoucherType";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(208, 86);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 13);
            this.label17.TabIndex = 875;
            this.label17.Text = "Voucher Type";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(285, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 873;
            this.label16.Text = "Trans Date";
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd/MMM/yyyy";
            this.dtDate.DataField = null;
            this.dtDate.Enabled = false;
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(348, 29);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(97, 20);
            this.dtDate.TabIndex = 872;
            this.dtDate.Tag = "TransDate";
            // 
            // pnlMain1
            // 
            this.pnlMain1.BeginColor = System.Drawing.Color.Navy;
            this.pnlMain1.Controls.Add(this.label21);
            this.pnlMain1.EndColor = System.Drawing.Color.LightSteelBlue;
            this.pnlMain1.Location = new System.Drawing.Point(4, 5);
            this.pnlMain1.Name = "pnlMain1";
            this.pnlMain1.Size = new System.Drawing.Size(592, 18);
            this.pnlMain1.TabIndex = 815;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label21.Location = new System.Drawing.Point(5, 2);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(112, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Master Information";
            // 
            // dicboTransType
            // 
            this.dicboTransType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.dicboTransType.DataField = null;
            this.dicboTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicboTransType.FormattingEnabled = true;
            this.dicboTransType.Location = new System.Drawing.Point(71, 55);
            this.dicboTransType.Name = "dicboTransType";
            this.dicboTransType.Size = new System.Drawing.Size(121, 21);
            this.dicboTransType.TabIndex = 0;
            this.dicboTransType.Tag = "TransType";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 735;
            this.label3.Text = "Trans Type";
            // 
            // dotxtRemarks
            // 
            this.dotxtRemarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.dotxtRemarks.DataField = null;
            this.dotxtRemarks.Location = new System.Drawing.Point(71, 132);
            this.dotxtRemarks.Name = "dotxtRemarks";
            this.dotxtRemarks.Size = new System.Drawing.Size(521, 20);
            this.dotxtRemarks.TabIndex = 6;
            this.dotxtRemarks.Tag = "Remarks";
            this.dotxtRemarks.Validating += new System.ComponentModel.CancelEventHandler(this.cstTextBox3_Validating);
            // 
            // dicboParty
            // 
            this.dicboParty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.dicboParty.DataField = null;
            this.dicboParty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicboParty.FormattingEnabled = true;
            this.dicboParty.Location = new System.Drawing.Point(71, 108);
            this.dicboParty.Name = "dicboParty";
            this.dicboParty.Size = new System.Drawing.Size(358, 21);
            this.dicboParty.TabIndex = 4;
            this.dicboParty.Tag = "PartyCode";
            // 
            // dinumConversionRate
            // 
            this.dinumConversionRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.dinumConversionRate.DataField = null;
            this.dinumConversionRate.DecimalPlaces = 4;
            this.dinumConversionRate.Location = new System.Drawing.Point(472, 109);
            this.dinumConversionRate.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.dinumConversionRate.Name = "dinumConversionRate";
            this.dinumConversionRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dinumConversionRate.Size = new System.Drawing.Size(120, 20);
            this.dinumConversionRate.TabIndex = 3;
            this.dinumConversionRate.Tag = "Rate";
            this.dinumConversionRate.ValueChanged += new System.EventHandler(this.dinumConversionRate_ValueChanged);
            // 
            // dicboCurrency
            // 
            this.dicboCurrency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.dicboCurrency.DataField = null;
            this.dicboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicboCurrency.FormattingEnabled = true;
            this.dicboCurrency.Location = new System.Drawing.Point(71, 81);
            this.dicboCurrency.Name = "dicboCurrency";
            this.dicboCurrency.Size = new System.Drawing.Size(121, 21);
            this.dicboCurrency.TabIndex = 2;
            this.dicboCurrency.Tag = "ItemCode";
            // 
            // dicboPaymentMode
            // 
            this.dicboPaymentMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.dicboPaymentMode.DataField = null;
            this.dicboPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicboPaymentMode.FormattingEnabled = true;
            this.dicboPaymentMode.Location = new System.Drawing.Point(288, 58);
            this.dicboPaymentMode.Name = "dicboPaymentMode";
            this.dicboPaymentMode.Size = new System.Drawing.Size(304, 21);
            this.dicboPaymentMode.TabIndex = 1;
            this.dicboPaymentMode.Tag = "AccountNo";
            this.dicboPaymentMode.SelectedIndexChanged += new System.EventHandler(this.dicboPaymentMode_SelectedIndexChanged);
            this.dicboPaymentMode.Validated += new System.EventHandler(this.dicboPaymentMode_Validated);
            // 
            // ditxtBillMemo
            // 
            this.ditxtBillMemo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.ditxtBillMemo.DataField = null;
            this.ditxtBillMemo.Location = new System.Drawing.Point(216, 29);
            this.ditxtBillMemo.Name = "ditxtBillMemo";
            this.ditxtBillMemo.Size = new System.Drawing.Size(66, 20);
            this.ditxtBillMemo.TabIndex = 729;
            this.ditxtBillMemo.Tag = "BillNo";
            // 
            // ditxtTransNo
            // 
            this.ditxtTransNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.ditxtTransNo.DataField = null;
            this.ditxtTransNo.Location = new System.Drawing.Point(72, 29);
            this.ditxtTransNo.Name = "ditxtTransNo";
            this.ditxtTransNo.Size = new System.Drawing.Size(73, 20);
            this.ditxtTransNo.TabIndex = 728;
            this.ditxtTransNo.Tag = "TransNo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 727;
            this.label9.Text = "Currency";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(435, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 726;
            this.label8.Text = "Rate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 725;
            this.label7.Text = "Party";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 724;
            this.label6.Text = "Remarks";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 723;
            this.label4.Text = "Bill Memo #";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 722;
            this.label2.Text = "Payment Mode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 721;
            this.label1.Text = "Trans.#.";
            // 
            // dtbDetail
            // 
            this.dtbDetail.AllowUserToAddRows = false;
            this.dtbDetail.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(202)))), ((int)(((byte)(233)))));
            this.dtbDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbDetail.Location = new System.Drawing.Point(2, 179);
            this.dtbDetail.Name = "dtbDetail";
            this.dtbDetail.Size = new System.Drawing.Size(821, 150);
            this.dtbDetail.TabIndex = 725;
            // 
            // pnlMain2
            // 
            this.pnlMain2.BeginColor = System.Drawing.Color.Orange;
            this.pnlMain2.Controls.Add(this.label5);
            this.pnlMain2.EndColor = System.Drawing.Color.NavajoWhite;
            this.pnlMain2.Location = new System.Drawing.Point(600, 3);
            this.pnlMain2.Name = "pnlMain2";
            this.pnlMain2.Size = new System.Drawing.Size(224, 18);
            this.pnlMain2.TabIndex = 817;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(5, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Currency Information";
            // 
            // pnlMain7
            // 
            this.pnlMain7.BeginColor = System.Drawing.Color.Maroon;
            this.pnlMain7.Controls.Add(this.label36);
            this.pnlMain7.EndColor = System.Drawing.Color.Red;
            this.pnlMain7.Location = new System.Drawing.Point(3, 160);
            this.pnlMain7.Name = "pnlMain7";
            this.pnlMain7.Size = new System.Drawing.Size(820, 18);
            this.pnlMain7.TabIndex = 818;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label36.Location = new System.Drawing.Point(5, 2);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(107, 13);
            this.label36.TabIndex = 0;
            this.label36.Text = "Detail Information";
            // 
            // frmInterBankTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 576);
            this.Controls.Add(this.pnlMain7);
            this.Controls.Add(this.pnlMain2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.c);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.dtbDetail);
            this.Name = "frmInterBankTransactions";
            this.Text = "9";
            this.Load += new System.EventHandler(this.frmTransExport_Load);
            this.Activated += new System.EventHandler(this.frmInterBankTransactions_Activated);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.dtbDetail, 0);
            this.Controls.SetChildIndex(this.PnlMain, 0);
            this.Controls.SetChildIndex(this.c, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlMain2, 0);
            this.Controls.SetChildIndex(this.pnlMain7, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.c.ResumeLayout(false);
            this.c.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEXRAtes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumMinRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumStock)).EndInit();
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.pnlMain1.ResumeLayout(false);
            this.pnlMain1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dinumConversionRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).EndInit();
            this.pnlMain2.ResumeLayout(false);
            this.pnlMain2.PerformLayout();
            this.pnlMain7.ResumeLayout(false);
            this.pnlMain7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblusdAmount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Panel c;
        private cstNumericupDown numEXRAtes;
        private cstNumericupDown donumMinRate;
        private cstNumericupDown donumAverage;
        private cstNumericupDown donumMax;
        private cstNumericupDown donumStock;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel PnlMain;
        private cstComboBox dicboTransType;
        private System.Windows.Forms.Label label3;
        private cstTextBox dotxtRemarks;
        private cstComboBox dicboParty;
        private cstNumericupDown dinumConversionRate;
        private cstComboBox dicboCurrency;
        private cstComboBox dicboPaymentMode;
        private cstTextBox ditxtBillMemo;
        private cstTextBox ditxtTransNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtbDetail;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain1;
        private System.Windows.Forms.Label label21;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain2;
        private System.Windows.Forms.Label label5;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain7;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label16;
        public ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtDate;
        private cstComboBox dicboVoucherType;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        public ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtDealDate;

    }
}