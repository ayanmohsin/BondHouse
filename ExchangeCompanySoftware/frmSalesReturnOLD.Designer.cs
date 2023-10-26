namespace ExchangeCompanySoftware
{
    partial class frmSalesReturnOLD
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtbDetail = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ditxtVoucherNo = new ExchangeCompanySoftware.cstTextBox();
            this.dtDate = new ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.PnlMain = new System.Windows.Forms.Panel();
            this.pnlMain3 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.label8 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.donumOtherCharges = new ExchangeCompanySoftware.cstNumericupDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dotxtNetAmount = new ExchangeCompanySoftware.cstNumericupDown();
            this.dotxtGrossAmount = new ExchangeCompanySoftware.cstNumericupDown();
            this.pnlMain7 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.label36 = new System.Windows.Forms.Label();
            this.pnlMain1 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.label21 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dotxtRemarks = new ExchangeCompanySoftware.cstTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dicbopaymentMode = new ExchangeCompanySoftware.cstComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).BeginInit();
            this.PnlMain.SuspendLayout();
            this.pnlMain3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donumOtherCharges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dotxtNetAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dotxtGrossAmount)).BeginInit();
            this.pnlMain7.SuspendLayout();
            this.pnlMain1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtbDetail
            // 
            this.dtbDetail.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.NavajoWhite;
            this.dtbDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtbDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtbDetail.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(202)))), ((int)(((byte)(233)))));
            this.dtbDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbDetail.Location = new System.Drawing.Point(3, 126);
            this.dtbDetail.Name = "dtbDetail";
            this.dtbDetail.Size = new System.Drawing.Size(1111, 121);
            this.dtbDetail.TabIndex = 6;
            this.dtbDetail.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtbDetail_CellPainting);
            this.dtbDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtbDetail_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(429, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Invoice No";
            this.label2.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "Voucher No";
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
            this.label16.Location = new System.Drawing.Point(15, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 816;
            this.label16.Text = "Trans Date";
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.Transparent;
            this.PnlMain.Controls.Add(this.pnlMain3);
            this.PnlMain.Controls.Add(this.label26);
            this.PnlMain.Controls.Add(this.donumOtherCharges);
            this.PnlMain.Controls.Add(this.label3);
            this.PnlMain.Controls.Add(this.label5);
            this.PnlMain.Controls.Add(this.dotxtNetAmount);
            this.PnlMain.Controls.Add(this.dotxtGrossAmount);
            this.PnlMain.Controls.Add(this.pnlMain7);
            this.PnlMain.Controls.Add(this.dtbDetail);
            this.PnlMain.Controls.Add(this.pnlMain1);
            this.PnlMain.Controls.Add(this.label7);
            this.PnlMain.Controls.Add(this.dotxtRemarks);
            this.PnlMain.Controls.Add(this.label17);
            this.PnlMain.Controls.Add(this.dicbopaymentMode);
            this.PnlMain.Controls.Add(this.label16);
            this.PnlMain.Controls.Add(this.dtDate);
            this.PnlMain.Controls.Add(this.ditxtVoucherNo);
            this.PnlMain.Controls.Add(this.label12);
            this.PnlMain.Location = new System.Drawing.Point(3, 3);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(1113, 352);
            this.PnlMain.TabIndex = 99;
            this.PnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlMain_Paint);
            // 
            // pnlMain3
            // 
            this.pnlMain3.BeginColor = System.Drawing.Color.Maroon;
            this.pnlMain3.Controls.Add(this.label8);
            this.pnlMain3.EndColor = System.Drawing.Color.Red;
            this.pnlMain3.Location = new System.Drawing.Point(908, 248);
            this.pnlMain3.Name = "pnlMain3";
            this.pnlMain3.Size = new System.Drawing.Size(202, 18);
            this.pnlMain3.TabIndex = 895;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(50, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Total Caculations";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Location = new System.Drawing.Point(916, 298);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(75, 13);
            this.label26.TabIndex = 891;
            this.label26.Text = "Other Charges";
            // 
            // donumOtherCharges
            // 
            this.donumOtherCharges.DataField = null;
            this.donumOtherCharges.DecimalPlaces = 4;
            this.donumOtherCharges.Location = new System.Drawing.Point(1007, 296);
            this.donumOtherCharges.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.donumOtherCharges.Name = "donumOtherCharges";
            this.donumOtherCharges.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.donumOtherCharges.Size = new System.Drawing.Size(103, 20);
            this.donumOtherCharges.TabIndex = 890;
            this.donumOtherCharges.Tag = "OtherCharges";
            this.donumOtherCharges.Validated += new System.EventHandler(this.donumOtherCharges_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(916, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 877;
            this.label3.Text = "Net Amount";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(916, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 874;
            this.label5.Text = "Gross Amount";
            // 
            // dotxtNetAmount
            // 
            this.dotxtNetAmount.DataField = null;
            this.dotxtNetAmount.DecimalPlaces = 4;
            this.dotxtNetAmount.Location = new System.Drawing.Point(1007, 322);
            this.dotxtNetAmount.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.dotxtNetAmount.Name = "dotxtNetAmount";
            this.dotxtNetAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dotxtNetAmount.Size = new System.Drawing.Size(103, 20);
            this.dotxtNetAmount.TabIndex = 873;
            this.dotxtNetAmount.ValueChanged += new System.EventHandler(this.dotxtNetAmount_ValueChanged);
            // 
            // dotxtGrossAmount
            // 
            this.dotxtGrossAmount.DataField = null;
            this.dotxtGrossAmount.DecimalPlaces = 4;
            this.dotxtGrossAmount.Location = new System.Drawing.Point(1007, 270);
            this.dotxtGrossAmount.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.dotxtGrossAmount.Name = "dotxtGrossAmount";
            this.dotxtGrossAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dotxtGrossAmount.Size = new System.Drawing.Size(103, 20);
            this.dotxtGrossAmount.TabIndex = 870;
            // 
            // pnlMain7
            // 
            this.pnlMain7.BeginColor = System.Drawing.Color.Maroon;
            this.pnlMain7.Controls.Add(this.label36);
            this.pnlMain7.EndColor = System.Drawing.Color.Red;
            this.pnlMain7.Location = new System.Drawing.Point(3, 107);
            this.pnlMain7.Name = "pnlMain7";
            this.pnlMain7.Size = new System.Drawing.Size(1111, 18);
            this.pnlMain7.TabIndex = 815;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.White;
            this.label36.Location = new System.Drawing.Point(5, 2);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(107, 13);
            this.label36.TabIndex = 0;
            this.label36.Text = "Detail Information";
            // 
            // pnlMain1
            // 
            this.pnlMain1.BeginColor = System.Drawing.Color.Navy;
            this.pnlMain1.Controls.Add(this.label21);
            this.pnlMain1.EndColor = System.Drawing.Color.LightSteelBlue;
            this.pnlMain1.Location = new System.Drawing.Point(3, 3);
            this.pnlMain1.Name = "pnlMain1";
            this.pnlMain1.Size = new System.Drawing.Size(1111, 18);
            this.pnlMain1.TabIndex = 814;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(5, 2);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(112, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Master Information";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 820;
            this.label7.Text = "Remarks";
            // 
            // dotxtRemarks
            // 
            this.dotxtRemarks.BackColor = System.Drawing.Color.Snow;
            this.dotxtRemarks.DataField = null;
            this.dotxtRemarks.Location = new System.Drawing.Point(117, 81);
            this.dotxtRemarks.Name = "dotxtRemarks";
            this.dotxtRemarks.Size = new System.Drawing.Size(675, 20);
            this.dotxtRemarks.TabIndex = 5;
            this.dotxtRemarks.Tag = "Remarks";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(222, 58);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 13);
            this.label17.TabIndex = 818;
            this.label17.Text = "Payment Mode";
            // 
            // dicbopaymentMode
            // 
            this.dicbopaymentMode.BackColor = System.Drawing.Color.Snow;
            this.dicbopaymentMode.DataField = "TransType";
            this.dicbopaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicbopaymentMode.FormattingEnabled = true;
            this.dicbopaymentMode.Location = new System.Drawing.Point(306, 55);
            this.dicbopaymentMode.Name = "dicbopaymentMode";
            this.dicbopaymentMode.Size = new System.Drawing.Size(289, 21);
            this.dicbopaymentMode.TabIndex = 817;
            this.dicbopaymentMode.Tag = "PaymentMode";
            // 
            // frmSalesReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 574);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.label2);
            this.Name = "frmSalesReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "S";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Activated += new System.EventHandler(this.frmTradingVoucher_Activated);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmTradingVoucher_KeyPress);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.PnlMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).EndInit();
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.pnlMain3.ResumeLayout(false);
            this.pnlMain3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donumOtherCharges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dotxtNetAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dotxtGrossAmount)).EndInit();
            this.pnlMain7.ResumeLayout(false);
            this.pnlMain7.PerformLayout();
            this.pnlMain1.ResumeLayout(false);
            this.pnlMain1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtbDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private cstTextBox ditxtVoucherNo;
        public ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel PnlMain;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label36;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain7;
        private System.Windows.Forms.Label label17;
        private cstComboBox dicbopaymentMode;
        private cstTextBox dotxtRemarks;
        private System.Windows.Forms.Label label7;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label26;
        private cstNumericupDown donumOtherCharges;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private cstNumericupDown dotxtNetAmount;
        private cstNumericupDown dotxtGrossAmount;
    }
}

