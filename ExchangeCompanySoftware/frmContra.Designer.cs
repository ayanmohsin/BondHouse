namespace ExchangeCompanySoftware
{
    partial class frmContra
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
            this.dicboAccount = new ExchangeCompanySoftware.cstComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cstComboBox1 = new ExchangeCompanySoftware.cstComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.docboNarration = new ExchangeCompanySoftware.cstTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dinumAmount = new ExchangeCompanySoftware.cstNumericupDown();
            this.label5 = new System.Windows.Forms.Label();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dinumAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.Transparent;
            this.PnlMain.Controls.Add(this.dinumAmount);
            this.PnlMain.Controls.Add(this.label5);
            this.PnlMain.Controls.Add(this.docboNarration);
            this.PnlMain.Controls.Add(this.label4);
            this.PnlMain.Controls.Add(this.cstComboBox1);
            this.PnlMain.Controls.Add(this.label3);
            this.PnlMain.Controls.Add(this.dicboAccount);
            this.PnlMain.Controls.Add(this.label2);
            this.PnlMain.Controls.Add(this.label16);
            this.PnlMain.Controls.Add(this.dtDate);
            this.PnlMain.Location = new System.Drawing.Point(2, 5);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(541, 216);
            this.PnlMain.TabIndex = 32;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(229, 29);
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
            this.dtDate.Location = new System.Drawing.Point(295, 26);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(97, 20);
            this.dtDate.TabIndex = 819;
            this.dtDate.Tag = "TransDate";
            // 
            // dicboAccount
            // 
            this.dicboAccount.BackColor = System.Drawing.Color.PaleTurquoise;
            this.dicboAccount.DataField = null;
            this.dicboAccount.FormattingEnabled = true;
            this.dicboAccount.Location = new System.Drawing.Point(129, 54);
            this.dicboAccount.Name = "dicboAccount";
            this.dicboAccount.Size = new System.Drawing.Size(263, 21);
            this.dicboAccount.TabIndex = 822;
            this.dicboAccount.Tag = "AccountNo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 821;
            this.label2.Text = "Debit";
            // 
            // cstComboBox1
            // 
            this.cstComboBox1.BackColor = System.Drawing.Color.LightSalmon;
            this.cstComboBox1.DataField = null;
            this.cstComboBox1.FormattingEnabled = true;
            this.cstComboBox1.Location = new System.Drawing.Point(129, 81);
            this.cstComboBox1.Name = "cstComboBox1";
            this.cstComboBox1.Size = new System.Drawing.Size(263, 21);
            this.cstComboBox1.TabIndex = 824;
            this.cstComboBox1.Tag = "AccountNo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 823;
            this.label3.Text = "Credit";
            // 
            // docboNarration
            // 
            this.docboNarration.BackColor = System.Drawing.Color.NavajoWhite;
            this.docboNarration.DataField = null;
            this.docboNarration.Location = new System.Drawing.Point(129, 108);
            this.docboNarration.Multiline = true;
            this.docboNarration.Name = "docboNarration";
            this.docboNarration.Size = new System.Drawing.Size(402, 53);
            this.docboNarration.TabIndex = 826;
            this.docboNarration.Tag = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 825;
            this.label4.Text = "Narration";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dinumAmount
            // 
            this.dinumAmount.BackColor = System.Drawing.Color.NavajoWhite;
            this.dinumAmount.DataField = null;
            this.dinumAmount.DecimalPlaces = 4;
            this.dinumAmount.Location = new System.Drawing.Point(129, 168);
            this.dinumAmount.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.dinumAmount.Name = "dinumAmount";
            this.dinumAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dinumAmount.Size = new System.Drawing.Size(120, 20);
            this.dinumAmount.TabIndex = 828;
            this.dinumAmount.Tag = "Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 827;
            this.label5.Text = "Amount";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmContra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 456);
            this.Controls.Add(this.PnlMain);
            this.Name = "frmContra";
            this.Text = "s";
            this.Load += new System.EventHandler(this.frmSetupItem_Load);
            this.Activated += new System.EventHandler(this.frmPurpose_Activated);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.PnlMain, 0);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dinumAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Label label16;
        public ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtDate;
        private cstComboBox cstComboBox1;
        private System.Windows.Forms.Label label3;
        private cstComboBox dicboAccount;
        private System.Windows.Forms.Label label2;
        private cstTextBox docboNarration;
        private System.Windows.Forms.Label label4;
        private cstNumericupDown dinumAmount;
        private System.Windows.Forms.Label label5;
    }
}