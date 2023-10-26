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
            ((System.ComponentModel.ISupportInitialize)(this.dinumAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
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
            this.PnlMain.Location = new System.Drawing.Point(1, 60);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(546, 150);
            this.PnlMain.TabIndex = 35;
            // 
            // ditxtVoucherNo
            // 
            this.ditxtVoucherNo.DataField = null;
            this.ditxtVoucherNo.Location = new System.Drawing.Point(124, 13);
            this.ditxtVoucherNo.Name = "ditxtVoucherNo";
            this.ditxtVoucherNo.Size = new System.Drawing.Size(121, 20);
            this.ditxtVoucherNo.TabIndex = 9;
            this.ditxtVoucherNo.Tag = "VoucherNo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Voucher No";
            // 
            // docboNarration
            // 
            this.docboNarration.DataField = null;
            this.docboNarration.Location = new System.Drawing.Point(125, 125);
            this.docboNarration.Name = "docboNarration";
            this.docboNarration.Size = new System.Drawing.Size(401, 20);
            this.docboNarration.TabIndex = 7;
            this.docboNarration.Tag = "Description";
            // 
            // dinumAmount
            // 
            this.dinumAmount.DataField = null;
            this.dinumAmount.DecimalPlaces = 4;
            this.dinumAmount.Location = new System.Drawing.Point(125, 96);
            this.dinumAmount.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.dinumAmount.Name = "dinumAmount";
            this.dinumAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dinumAmount.Size = new System.Drawing.Size(120, 20);
            this.dinumAmount.TabIndex = 6;
            this.dinumAmount.Tag = "Amount";
            // 
            // dicboAccount
            // 
            this.dicboAccount.DataField = null;
            this.dicboAccount.FormattingEnabled = true;
            this.dicboAccount.Location = new System.Drawing.Point(124, 71);
            this.dicboAccount.Name = "dicboAccount";
            this.dicboAccount.Size = new System.Drawing.Size(182, 21);
            this.dicboAccount.TabIndex = 5;
            this.dicboAccount.Tag = "AccountNo";
            // 
            // dicboTransactionType
            // 
            this.dicboTransactionType.DataField = null;
            this.dicboTransactionType.FormattingEnabled = true;
            this.dicboTransactionType.Location = new System.Drawing.Point(124, 44);
            this.dicboTransactionType.Name = "dicboTransactionType";
            this.dicboTransactionType.Size = new System.Drawing.Size(182, 21);
            this.dicboTransactionType.TabIndex = 4;
            this.dicboTransactionType.Tag = "TransCode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Transaction Type";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Narration";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Amount";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 74);
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
            this.Controls.SetChildIndex(this.PnlMain, 0);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
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
    }
}