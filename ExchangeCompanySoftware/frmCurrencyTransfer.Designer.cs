namespace ExchangeCompanySoftware
{
    partial class frmCurrencyTransfer
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
            this.label5 = new System.Windows.Forms.Label();
            this.dotxtReportTransNo = new ExchangeCompanySoftware.cstTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dtDate = new ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker();
            this.dicboVoucherType = new ExchangeCompanySoftware.cstComboBox();
            this.dicboParty = new ExchangeCompanySoftware.cstComboBox();
            this.dotxtRemarks = new ExchangeCompanySoftware.cstTextBox();
            this.ditxtTransNo = new ExchangeCompanySoftware.cstTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtbDetail = new System.Windows.Forms.DataGridView();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.Transparent;
            this.PnlMain.Controls.Add(this.label5);
            this.PnlMain.Controls.Add(this.dotxtReportTransNo);
            this.PnlMain.Controls.Add(this.label16);
            this.PnlMain.Controls.Add(this.dtDate);
            this.PnlMain.Controls.Add(this.dicboVoucherType);
            this.PnlMain.Controls.Add(this.dicboParty);
            this.PnlMain.Controls.Add(this.dotxtRemarks);
            this.PnlMain.Controls.Add(this.ditxtTransNo);
            this.PnlMain.Controls.Add(this.label8);
            this.PnlMain.Controls.Add(this.label7);
            this.PnlMain.Controls.Add(this.label6);
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Location = new System.Drawing.Point(4, 3);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(710, 89);
            this.PnlMain.TabIndex = 702;
            this.PnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(497, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 822;
            this.label5.Text = "Report Voucher";
            // 
            // dotxtReportTransNo
            // 
            this.dotxtReportTransNo.BackColor = System.Drawing.Color.Snow;
            this.dotxtReportTransNo.DataField = "ReportTransNo";
            this.dotxtReportTransNo.Enabled = false;
            this.dotxtReportTransNo.Location = new System.Drawing.Point(585, 35);
            this.dotxtReportTransNo.Name = "dotxtReportTransNo";
            this.dotxtReportTransNo.Size = new System.Drawing.Size(115, 20);
            this.dotxtReportTransNo.TabIndex = 821;
            this.dotxtReportTransNo.Tag = "ReportTransNo";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(497, 11);
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
            this.dtDate.Location = new System.Drawing.Point(585, 11);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(97, 20);
            this.dtDate.TabIndex = 819;
            this.dtDate.Tag = "TransDate";
            // 
            // dicboVoucherType
            // 
            this.dicboVoucherType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.dicboVoucherType.DataField = null;
            this.dicboVoucherType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicboVoucherType.FormattingEnabled = true;
            this.dicboVoucherType.Location = new System.Drawing.Point(274, 7);
            this.dicboVoucherType.Name = "dicboVoucherType";
            this.dicboVoucherType.Size = new System.Drawing.Size(131, 21);
            this.dicboVoucherType.TabIndex = 0;
            this.dicboVoucherType.Tag = "VoucherType";
            // 
            // dicboParty
            // 
            this.dicboParty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.dicboParty.DataField = null;
            this.dicboParty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicboParty.FormattingEnabled = true;
            this.dicboParty.Location = new System.Drawing.Point(88, 38);
            this.dicboParty.Name = "dicboParty";
            this.dicboParty.Size = new System.Drawing.Size(317, 21);
            this.dicboParty.TabIndex = 1;
            this.dicboParty.Tag = "PartyCode";
            // 
            // dotxtRemarks
            // 
            this.dotxtRemarks.BackColor = System.Drawing.Color.White;
            this.dotxtRemarks.DataField = null;
            this.dotxtRemarks.Location = new System.Drawing.Point(88, 66);
            this.dotxtRemarks.Name = "dotxtRemarks";
            this.dotxtRemarks.Size = new System.Drawing.Size(317, 20);
            this.dotxtRemarks.TabIndex = 2;
            this.dotxtRemarks.Tag = "Remarks";
            this.dotxtRemarks.Validating += new System.ComponentModel.CancelEventHandler(this.dotxtRemarks_Validating);
            // 
            // ditxtTransNo
            // 
            this.ditxtTransNo.BackColor = System.Drawing.Color.White;
            this.ditxtTransNo.DataField = null;
            this.ditxtTransNo.Location = new System.Drawing.Point(88, 8);
            this.ditxtTransNo.Name = "ditxtTransNo";
            this.ditxtTransNo.Size = new System.Drawing.Size(100, 20);
            this.ditxtTransNo.TabIndex = 718;
            this.ditxtTransNo.Tag = "TransNo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(15, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 717;
            this.label8.Text = "Party";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(194, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 716;
            this.label7.Text = "Voucher Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(15, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 715;
            this.label6.Text = "Remarks";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 714;
            this.label1.Text = "Trans No";
            // 
            // dtbDetail
            // 
            this.dtbDetail.AllowUserToAddRows = false;
            this.dtbDetail.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtbDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbDetail.Location = new System.Drawing.Point(4, 95);
            this.dtbDetail.Name = "dtbDetail";
            this.dtbDetail.Size = new System.Drawing.Size(710, 145);
            this.dtbDetail.TabIndex = 751;
            this.dtbDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtbDetail_KeyDown_1);
            // 
            // frmCurrencyTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 459);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.dtbDetail);
            this.Name = "frmCurrencyTransfer";
            this.Text = "frmCurrencyTransfer";
            this.Load += new System.EventHandler(this.frmCurrencyTransfer_Load);
            this.Activated += new System.EventHandler(this.frmCurrencyTransfer_Activated);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.dtbDetail, 0);
            this.Controls.SetChildIndex(this.PnlMain, 0);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private cstComboBox dicboVoucherType;
        private cstComboBox dicboParty;
        private cstTextBox dotxtRemarks;
        private cstTextBox ditxtTransNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtbDetail;
        private System.Windows.Forms.Label label16;
        public ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtDate;
        private System.Windows.Forms.Label label5;
        private cstTextBox dotxtReportTransNo;

    }
}