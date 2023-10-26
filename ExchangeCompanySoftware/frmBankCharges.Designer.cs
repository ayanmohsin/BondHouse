namespace ExchangeCompanySoftware
{
    partial class frmBankCharges
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
            this.PnlMain = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.dtDate = new ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker();
            this.pnlMain1 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.label21 = new System.Windows.Forms.Label();
            this.dicboChargesType = new ExchangeCompanySoftware.cstComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dinumEqAmount = new ExchangeCompanySoftware.cstNumericupDown();
            this.dinumAmount = new ExchangeCompanySoftware.cstNumericupDown();
            this.dinumRate = new ExchangeCompanySoftware.cstNumericupDown();
            this.dotxtRemarks = new ExchangeCompanySoftware.cstTextBox();
            this.dicboCurrency = new ExchangeCompanySoftware.cstComboBox();
            this.dicboBank = new ExchangeCompanySoftware.cstComboBox();
            this.ditxtTransno = new ExchangeCompanySoftware.cstTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PnlMain.SuspendLayout();
            this.pnlMain1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dinumEqAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dinumAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dinumRate)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.Transparent;
            this.PnlMain.Controls.Add(this.label16);
            this.PnlMain.Controls.Add(this.dtDate);
            this.PnlMain.Controls.Add(this.pnlMain1);
            this.PnlMain.Controls.Add(this.dicboChargesType);
            this.PnlMain.Controls.Add(this.label5);
            this.PnlMain.Controls.Add(this.dinumEqAmount);
            this.PnlMain.Controls.Add(this.dinumAmount);
            this.PnlMain.Controls.Add(this.dinumRate);
            this.PnlMain.Controls.Add(this.dotxtRemarks);
            this.PnlMain.Controls.Add(this.dicboCurrency);
            this.PnlMain.Controls.Add(this.dicboBank);
            this.PnlMain.Controls.Add(this.ditxtTransno);
            this.PnlMain.Controls.Add(this.label10);
            this.PnlMain.Controls.Add(this.label9);
            this.PnlMain.Controls.Add(this.label7);
            this.PnlMain.Controls.Add(this.label6);
            this.PnlMain.Controls.Add(this.label4);
            this.PnlMain.Controls.Add(this.label3);
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Location = new System.Drawing.Point(4, -1);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(598, 190);
            this.PnlMain.TabIndex = 702;
            this.PnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlMain_Paint);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(410, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 820;
            this.label16.Text = "Trans Date";
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd/MMM/yyyy";
            this.dtDate.DataField = null;
            this.dtDate.Enabled = false;
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(476, 25);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(97, 20);
            this.dtDate.TabIndex = 819;
            this.dtDate.Tag = "TransDate";
            // 
            // pnlMain1
            // 
            this.pnlMain1.BeginColor = System.Drawing.Color.Navy;
            this.pnlMain1.Controls.Add(this.label21);
            this.pnlMain1.EndColor = System.Drawing.Color.LightSteelBlue;
            this.pnlMain1.Location = new System.Drawing.Point(2, 5);
            this.pnlMain1.Name = "pnlMain1";
            this.pnlMain1.Size = new System.Drawing.Size(593, 18);
            this.pnlMain1.TabIndex = 815;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label21.Location = new System.Drawing.Point(5, 2);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(118, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "General Information";
            // 
            // dicboChargesType
            // 
            this.dicboChargesType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.dicboChargesType.DataField = null;
            this.dicboChargesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicboChargesType.FormattingEnabled = true;
            this.dicboChargesType.Location = new System.Drawing.Point(92, 110);
            this.dicboChargesType.Name = "dicboChargesType";
            this.dicboChargesType.Size = new System.Drawing.Size(308, 21);
            this.dicboChargesType.TabIndex = 0;
            this.dicboChargesType.Tag = "ChargesType";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 740;
            this.label5.Text = "Charges Type :";
            // 
            // dinumEqAmount
            // 
            this.dinumEqAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.dinumEqAmount.DataField = null;
            this.dinumEqAmount.DecimalPlaces = 4;
            this.dinumEqAmount.Location = new System.Drawing.Point(481, 83);
            this.dinumEqAmount.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.dinumEqAmount.Name = "dinumEqAmount";
            this.dinumEqAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dinumEqAmount.Size = new System.Drawing.Size(92, 20);
            this.dinumEqAmount.TabIndex = 739;
            this.dinumEqAmount.Tag = "EqAmount";
            // 
            // dinumAmount
            // 
            this.dinumAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.dinumAmount.DataField = null;
            this.dinumAmount.DecimalPlaces = 4;
            this.dinumAmount.Location = new System.Drawing.Point(280, 84);
            this.dinumAmount.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.dinumAmount.Name = "dinumAmount";
            this.dinumAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dinumAmount.Size = new System.Drawing.Size(120, 20);
            this.dinumAmount.TabIndex = 4;
            this.dinumAmount.Tag = "Amount";
            this.dinumAmount.Validated += new System.EventHandler(this.dinumAmount_Validated);
            // 
            // dinumRate
            // 
            this.dinumRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.dinumRate.DataField = null;
            this.dinumRate.DecimalPlaces = 4;
            this.dinumRate.Location = new System.Drawing.Point(481, 57);
            this.dinumRate.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.dinumRate.Name = "dinumRate";
            this.dinumRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dinumRate.Size = new System.Drawing.Size(92, 20);
            this.dinumRate.TabIndex = 3;
            this.dinumRate.Tag = "Rate";
            this.dinumRate.Validated += new System.EventHandler(this.dinumRate_Validated);
            // 
            // dotxtRemarks
            // 
            this.dotxtRemarks.BackColor = System.Drawing.Color.White;
            this.dotxtRemarks.DataField = null;
            this.dotxtRemarks.Location = new System.Drawing.Point(92, 143);
            this.dotxtRemarks.Name = "dotxtRemarks";
            this.dotxtRemarks.Size = new System.Drawing.Size(481, 20);
            this.dotxtRemarks.TabIndex = 5;
            this.dotxtRemarks.Tag = "Remarks";
            // 
            // dicboCurrency
            // 
            this.dicboCurrency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.dicboCurrency.DataField = null;
            this.dicboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicboCurrency.FormattingEnabled = true;
            this.dicboCurrency.Location = new System.Drawing.Point(91, 83);
            this.dicboCurrency.Name = "dicboCurrency";
            this.dicboCurrency.Size = new System.Drawing.Size(121, 21);
            this.dicboCurrency.TabIndex = 2;
            this.dicboCurrency.Tag = "CurrencyCode";
            // 
            // dicboBank
            // 
            this.dicboBank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.dicboBank.DataField = null;
            this.dicboBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicboBank.FormattingEnabled = true;
            this.dicboBank.Location = new System.Drawing.Point(91, 56);
            this.dicboBank.Name = "dicboBank";
            this.dicboBank.Size = new System.Drawing.Size(309, 21);
            this.dicboBank.TabIndex = 1;
            this.dicboBank.Tag = "AccountNo";
            this.dicboBank.SelectedIndexChanged += new System.EventHandler(this.dicboBank_SelectedIndexChanged);
            this.dicboBank.Validated += new System.EventHandler(this.dicboBank_Validated);
            // 
            // ditxtTransno
            // 
            this.ditxtTransno.BackColor = System.Drawing.Color.White;
            this.ditxtTransno.DataField = null;
            this.ditxtTransno.Location = new System.Drawing.Point(92, 30);
            this.ditxtTransno.Name = "ditxtTransno";
            this.ditxtTransno.Size = new System.Drawing.Size(100, 20);
            this.ditxtTransno.TabIndex = 732;
            this.ditxtTransno.Tag = "TransNo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(406, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 731;
            this.label10.Text = "Eq Amount :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(228, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 730;
            this.label9.Text = "Amount :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 729;
            this.label7.Text = "Bank :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 728;
            this.label6.Text = "Remarks :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(406, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 727;
            this.label4.Text = "Rate :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 726;
            this.label3.Text = "Currency :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 724;
            this.label1.Text = "Trans # :";
            // 
            // frmBankCharges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 408);
            this.Controls.Add(this.PnlMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmBankCharges";
            this.Text = "frmBankCharges";
            this.Load += new System.EventHandler(this.frmBankCharges_Load);
            this.Activated += new System.EventHandler(this.frmBankCharges_Activated);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.PnlMain, 0);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.pnlMain1.ResumeLayout(false);
            this.pnlMain1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dinumEqAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dinumAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dinumRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private cstNumericupDown dinumEqAmount;
        private cstNumericupDown dinumAmount;
        private cstNumericupDown dinumRate;
        private cstTextBox dotxtRemarks;
        private cstComboBox dicboCurrency;
        private cstComboBox dicboBank;
        private cstTextBox ditxtTransno;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private cstComboBox dicboChargesType;
        private System.Windows.Forms.Label label5;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label16;
        public ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtDate;

    }
}