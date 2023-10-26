namespace ExchangeCompanySoftware
{
    partial class frmTransPaymentRec
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
            this.donumBalance = new ExchangeCompanySoftware.cstNumericupDown();
            this.label16 = new System.Windows.Forms.Label();
            this.dtDate = new ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker();
            this.ditxtVoucherNo = new ExchangeCompanySoftware.cstTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.docboNarration = new ExchangeCompanySoftware.cstTextBox();
            this.dinumAmount = new ExchangeCompanySoftware.cstNumericupDown();
            this.dicboAccount = new ExchangeCompanySoftware.cstComboBox();
            this.dicboTransactionType = new ExchangeCompanySoftware.cstComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donumBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dinumAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.Transparent;
            this.PnlMain.Controls.Add(this.donumBalance);
            this.PnlMain.Controls.Add(this.label16);
            this.PnlMain.Controls.Add(this.dtDate);
            this.PnlMain.Controls.Add(this.ditxtVoucherNo);
            this.PnlMain.Controls.Add(this.label5);
            this.PnlMain.Controls.Add(this.docboNarration);
            this.PnlMain.Controls.Add(this.dinumAmount);
            this.PnlMain.Controls.Add(this.dicboAccount);
            this.PnlMain.Controls.Add(this.dicboTransactionType);
            this.PnlMain.Controls.Add(this.label4);
            this.PnlMain.Controls.Add(this.label3);
            this.PnlMain.Controls.Add(this.label2);
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Location = new System.Drawing.Point(1, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(546, 237);
            this.PnlMain.TabIndex = 35;
            // 
            // donumBalance
            // 
            this.donumBalance.BackColor = System.Drawing.Color.NavajoWhite;
            this.donumBalance.DataField = null;
            this.donumBalance.DecimalPlaces = 4;
            this.donumBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donumBalance.Location = new System.Drawing.Point(324, 137);
            this.donumBalance.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.donumBalance.Name = "donumBalance";
            this.donumBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.donumBalance.Size = new System.Drawing.Size(181, 29);
            this.donumBalance.TabIndex = 819;
            this.donumBalance.Tag = "";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 818;
            this.label16.Text = "Trans Date";
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd/MMM/yyyy";
            this.dtDate.DataField = null;
            this.dtDate.Enabled = false;
            this.dtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(124, 12);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(146, 26);
            this.dtDate.TabIndex = 817;
            this.dtDate.Tag = "TransDate";
            // 
            // ditxtVoucherNo
            // 
            this.ditxtVoucherNo.BackColor = System.Drawing.Color.NavajoWhite;
            this.ditxtVoucherNo.DataField = null;
            this.ditxtVoucherNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ditxtVoucherNo.Location = new System.Drawing.Point(124, 44);
            this.ditxtVoucherNo.Name = "ditxtVoucherNo";
            this.ditxtVoucherNo.Size = new System.Drawing.Size(239, 26);
            this.ditxtVoucherNo.TabIndex = 9;
            this.ditxtVoucherNo.Tag = "VoucherNo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Voucher No";
            // 
            // docboNarration
            // 
            this.docboNarration.BackColor = System.Drawing.Color.NavajoWhite;
            this.docboNarration.DataField = null;
            this.docboNarration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.docboNarration.Location = new System.Drawing.Point(124, 169);
            this.docboNarration.Multiline = true;
            this.docboNarration.Name = "docboNarration";
            this.docboNarration.Size = new System.Drawing.Size(381, 65);
            this.docboNarration.TabIndex = 7;
            this.docboNarration.Tag = "Description";
            this.docboNarration.Validated += new System.EventHandler(this.docboNarration_Validated);
            // 
            // dinumAmount
            // 
            this.dinumAmount.BackColor = System.Drawing.Color.NavajoWhite;
            this.dinumAmount.DataField = null;
            this.dinumAmount.DecimalPlaces = 4;
            this.dinumAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dinumAmount.Location = new System.Drawing.Point(124, 137);
            this.dinumAmount.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.dinumAmount.Name = "dinumAmount";
            this.dinumAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dinumAmount.Size = new System.Drawing.Size(194, 26);
            this.dinumAmount.TabIndex = 6;
            this.dinumAmount.Tag = "Amount";
            // 
            // dicboAccount
            // 
            this.dicboAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.dicboAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.dicboAccount.BackColor = System.Drawing.Color.NavajoWhite;
            this.dicboAccount.DataField = null;
            this.dicboAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dicboAccount.FormattingEnabled = true;
            this.dicboAccount.Location = new System.Drawing.Point(124, 105);
            this.dicboAccount.Name = "dicboAccount";
            this.dicboAccount.Size = new System.Drawing.Size(381, 28);
            this.dicboAccount.TabIndex = 5;
            this.dicboAccount.Tag = "AccountNo";
            this.dicboAccount.SelectedIndexChanged += new System.EventHandler(this.dicboAccount_SelectedIndexChanged);
            this.dicboAccount.Validated += new System.EventHandler(this.dicboAccount_Validated);
            // 
            // dicboTransactionType
            // 
            this.dicboTransactionType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.dicboTransactionType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.dicboTransactionType.BackColor = System.Drawing.Color.NavajoWhite;
            this.dicboTransactionType.DataField = null;
            this.dicboTransactionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dicboTransactionType.FormattingEnabled = true;
            this.dicboTransactionType.Location = new System.Drawing.Point(124, 73);
            this.dicboTransactionType.Name = "dicboTransactionType";
            this.dicboTransactionType.Size = new System.Drawing.Size(381, 28);
            this.dicboTransactionType.TabIndex = 4;
            this.dicboTransactionType.Tag = "TransCode";
            this.dicboTransactionType.SelectedIndexChanged += new System.EventHandler(this.dicboTransactionType_SelectedIndexChanged);
            this.dicboTransactionType.SelectedValueChanged += new System.EventHandler(this.dicboTransactionType_SelectedValueChanged);
            this.dicboTransactionType.Validated += new System.EventHandler(this.dicboTransactionType_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Transaction Type";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Narration";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Amount";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account";
            // 
            // frmTransPaymentRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 451);
            this.Controls.Add(this.PnlMain);
            this.Name = "frmTransPaymentRec";
            this.Text = "s";
            this.Load += new System.EventHandler(this.frmTransPaymentRec_Load);
            this.Activated += new System.EventHandler(this.frmTransPaymentRec_Activated);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmTransPaymentRec_KeyPress);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.PnlMain, 0);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donumBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dinumAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private cstComboBox dicboTransactionType;
        private cstComboBox dicboAccount;
        private cstTextBox docboNarration;
        private cstNumericupDown dinumAmount;
        private cstTextBox ditxtVoucherNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label16;
        public ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtDate;
        private cstNumericupDown donumBalance;
    }
}