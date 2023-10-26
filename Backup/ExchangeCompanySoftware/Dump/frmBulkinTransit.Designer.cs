namespace ExchangeCompanySoftware
{
    partial class frmBulkinTransit
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
            this.dtbDetail = new System.Windows.Forms.DataGridView();
            this.PnlMain = new System.Windows.Forms.Panel();
            this.cmdCompleteSale = new System.Windows.Forms.Button();
            this.dicboTransType = new ExchangeCompanySoftware.cstComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cstTextBox3 = new ExchangeCompanySoftware.cstTextBox();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblusdAmount = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).BeginInit();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dinumConversionRate)).BeginInit();
            this.c.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEXRAtes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumMinRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumStock)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtbDetail
            // 
            this.dtbDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbDetail.Location = new System.Drawing.Point(-2, 197);
            this.dtbDetail.Name = "dtbDetail";
            this.dtbDetail.Size = new System.Drawing.Size(821, 150);
            this.dtbDetail.TabIndex = 721;
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.Transparent;
            this.PnlMain.Controls.Add(this.cmdCompleteSale);
            this.PnlMain.Controls.Add(this.dicboTransType);
            this.PnlMain.Controls.Add(this.label3);
            this.PnlMain.Controls.Add(this.cstTextBox3);
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
            this.PnlMain.Location = new System.Drawing.Point(1, 60);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(547, 136);
            this.PnlMain.TabIndex = 722;
            // 
            // cmdCompleteSale
            // 
            this.cmdCompleteSale.Location = new System.Drawing.Point(441, 87);
            this.cmdCompleteSale.Name = "cmdCompleteSale";
            this.cmdCompleteSale.Size = new System.Drawing.Size(103, 23);
            this.cmdCompleteSale.TabIndex = 739;
            this.cmdCompleteSale.Text = "Complete";
            this.cmdCompleteSale.UseVisualStyleBackColor = true;
            this.cmdCompleteSale.Click += new System.EventHandler(this.cmdCompleteSale_Click);
            // 
            // dicboTransType
            // 
            this.dicboTransType.BackColor = System.Drawing.Color.NavajoWhite;
            this.dicboTransType.DataField = null;
            this.dicboTransType.FormattingEnabled = true;
            this.dicboTransType.Location = new System.Drawing.Point(88, 36);
            this.dicboTransType.Name = "dicboTransType";
            this.dicboTransType.Size = new System.Drawing.Size(121, 21);
            this.dicboTransType.TabIndex = 0;
            this.dicboTransType.Tag = "TransType";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 735;
            this.label3.Text = "Trans Type";
            // 
            // cstTextBox3
            // 
            this.cstTextBox3.BackColor = System.Drawing.Color.NavajoWhite;
            this.cstTextBox3.DataField = null;
            this.cstTextBox3.Location = new System.Drawing.Point(88, 113);
            this.cstTextBox3.Name = "cstTextBox3";
            this.cstTextBox3.Size = new System.Drawing.Size(444, 20);
            this.cstTextBox3.TabIndex = 5;
            this.cstTextBox3.Tag = "Remarks";
            // 
            // dicboParty
            // 
            this.dicboParty.BackColor = System.Drawing.Color.NavajoWhite;
            this.dicboParty.DataField = null;
            this.dicboParty.FormattingEnabled = true;
            this.dicboParty.Location = new System.Drawing.Point(88, 89);
            this.dicboParty.Name = "dicboParty";
            this.dicboParty.Size = new System.Drawing.Size(338, 21);
            this.dicboParty.TabIndex = 4;
            this.dicboParty.Tag = "PartyCode";
            // 
            // dinumConversionRate
            // 
            this.dinumConversionRate.BackColor = System.Drawing.Color.NavajoWhite;
            this.dinumConversionRate.DataField = null;
            this.dinumConversionRate.DecimalPlaces = 4;
            this.dinumConversionRate.Location = new System.Drawing.Point(305, 65);
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
            // 
            // dicboCurrency
            // 
            this.dicboCurrency.BackColor = System.Drawing.Color.NavajoWhite;
            this.dicboCurrency.DataField = null;
            this.dicboCurrency.FormattingEnabled = true;
            this.dicboCurrency.Location = new System.Drawing.Point(88, 62);
            this.dicboCurrency.Name = "dicboCurrency";
            this.dicboCurrency.Size = new System.Drawing.Size(121, 21);
            this.dicboCurrency.TabIndex = 2;
            this.dicboCurrency.Tag = "ItemCode";
            // 
            // dicboPaymentMode
            // 
            this.dicboPaymentMode.BackColor = System.Drawing.Color.NavajoWhite;
            this.dicboPaymentMode.DataField = null;
            this.dicboPaymentMode.FormattingEnabled = true;
            this.dicboPaymentMode.Location = new System.Drawing.Point(305, 39);
            this.dicboPaymentMode.Name = "dicboPaymentMode";
            this.dicboPaymentMode.Size = new System.Drawing.Size(121, 21);
            this.dicboPaymentMode.TabIndex = 1;
            this.dicboPaymentMode.Tag = "PaymentMode";
            // 
            // ditxtBillMemo
            // 
            this.ditxtBillMemo.BackColor = System.Drawing.Color.NavajoWhite;
            this.ditxtBillMemo.DataField = null;
            this.ditxtBillMemo.Location = new System.Drawing.Point(305, 13);
            this.ditxtBillMemo.Name = "ditxtBillMemo";
            this.ditxtBillMemo.Size = new System.Drawing.Size(73, 20);
            this.ditxtBillMemo.TabIndex = 729;
            this.ditxtBillMemo.Tag = "BillNo";
            // 
            // ditxtTransNo
            // 
            this.ditxtTransNo.BackColor = System.Drawing.Color.NavajoWhite;
            this.ditxtTransNo.DataField = null;
            this.ditxtTransNo.Location = new System.Drawing.Point(89, 10);
            this.ditxtTransNo.Name = "ditxtTransNo";
            this.ditxtTransNo.Size = new System.Drawing.Size(73, 20);
            this.ditxtTransNo.TabIndex = 728;
            this.ditxtTransNo.Tag = "TransNo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 727;
            this.label9.Text = "Currency";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(216, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 726;
            this.label8.Text = "Rate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 725;
            this.label7.Text = "Party";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 724;
            this.label6.Text = "Remarks";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 723;
            this.label4.Text = "Bill Memo #";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 722;
            this.label2.Text = "Payment Mode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 721;
            this.label1.Text = "Trans.#.";
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
            this.c.Location = new System.Drawing.Point(552, 60);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(267, 136);
            this.c.TabIndex = 723;
            // 
            // numEXRAtes
            // 
            this.numEXRAtes.BackColor = System.Drawing.Color.NavajoWhite;
            this.numEXRAtes.DataField = null;
            this.numEXRAtes.DecimalPlaces = 4;
            this.numEXRAtes.Location = new System.Drawing.Point(132, 113);
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
            this.donumMinRate.BackColor = System.Drawing.Color.NavajoWhite;
            this.donumMinRate.DataField = null;
            this.donumMinRate.DecimalPlaces = 4;
            this.donumMinRate.Location = new System.Drawing.Point(132, 42);
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
            this.donumAverage.BackColor = System.Drawing.Color.NavajoWhite;
            this.donumAverage.DataField = null;
            this.donumAverage.DecimalPlaces = 4;
            this.donumAverage.Location = new System.Drawing.Point(132, 88);
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
            this.donumMax.BackColor = System.Drawing.Color.NavajoWhite;
            this.donumMax.DataField = null;
            this.donumMax.DecimalPlaces = 4;
            this.donumMax.Location = new System.Drawing.Point(132, 65);
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
            this.donumStock.BackColor = System.Drawing.Color.NavajoWhite;
            this.donumStock.DataField = null;
            this.donumStock.DecimalPlaces = 4;
            this.donumStock.Location = new System.Drawing.Point(132, 19);
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
            this.label11.Location = new System.Drawing.Point(31, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "Minimum";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 58;
            this.label10.Text = "Average";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 57;
            this.label12.Text = "Maximum";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(31, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 13);
            this.label13.TabIndex = 59;
            this.label13.Text = "Equilent US$ Rate";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(31, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 55;
            this.label14.Text = "Stock";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblusdAmount);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.lblTotalAmount);
            this.panel1.Location = new System.Drawing.Point(1, 347);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 30);
            this.panel1.TabIndex = 724;
            // 
            // lblusdAmount
            // 
            this.lblusdAmount.AutoSize = true;
            this.lblusdAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusdAmount.Location = new System.Drawing.Point(565, 3);
            this.lblusdAmount.Name = "lblusdAmount";
            this.lblusdAmount.Size = new System.Drawing.Size(21, 24);
            this.lblusdAmount.TabIndex = 728;
            this.lblusdAmount.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(270, 2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(134, 24);
            this.label15.TabIndex = 729;
            this.label15.Text = "Total Amount";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(450, 2);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(21, 24);
            this.lblTotalAmount.TabIndex = 727;
            this.lblTotalAmount.Text = "0";
            // 
            // frmBulkinTransit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 594);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.c);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.dtbDetail);
            this.Name = "frmBulkinTransit";
            this.Text = "frmBulkinTransit";
            this.Load += new System.EventHandler(this.frmBulkinTransit_Load);
            this.Controls.SetChildIndex(this.dtbDetail, 0);
            this.Controls.SetChildIndex(this.PnlMain, 0);
            this.Controls.SetChildIndex(this.c, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).EndInit();
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dinumConversionRate)).EndInit();
            this.c.ResumeLayout(false);
            this.c.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEXRAtes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumMinRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumStock)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtbDetail;
        private System.Windows.Forms.Panel PnlMain;
        private cstComboBox dicboTransType;
        private System.Windows.Forms.Label label3;
        private cstTextBox cstTextBox3;
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
        private System.Windows.Forms.Button cmdCompleteSale;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblusdAmount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTotalAmount;
    }
}