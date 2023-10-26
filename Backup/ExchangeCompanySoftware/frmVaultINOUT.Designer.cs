namespace ExchangeCompanySoftware
{
    partial class frmVaultINOUT
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
            this.donumCashinHand = new ExchangeCompanySoftware.cstNumericupDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtDate = new ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker();
            this.ditxtTransNo = new ExchangeCompanySoftware.cstTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ditxtRemarks = new ExchangeCompanySoftware.cstTextBox();
            this.grpVault = new System.Windows.Forms.GroupBox();
            this.rdoOut = new System.Windows.Forms.RadioButton();
            this.rdoIn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dtbDetail = new System.Windows.Forms.DataGridView();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donumCashinHand)).BeginInit();
            this.grpVault.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.Transparent;
            this.PnlMain.Controls.Add(this.donumCashinHand);
            this.PnlMain.Controls.Add(this.label3);
            this.PnlMain.Controls.Add(this.label16);
            this.PnlMain.Controls.Add(this.dtDate);
            this.PnlMain.Controls.Add(this.ditxtTransNo);
            this.PnlMain.Controls.Add(this.label2);
            this.PnlMain.Controls.Add(this.ditxtRemarks);
            this.PnlMain.Controls.Add(this.grpVault);
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Location = new System.Drawing.Point(0, 1);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(765, 68);
            this.PnlMain.TabIndex = 703;
            // 
            // donumCashinHand
            // 
            this.donumCashinHand.DataField = null;
            this.donumCashinHand.DecimalPlaces = 4;
            this.donumCashinHand.Location = new System.Drawing.Point(492, 13);
            this.donumCashinHand.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.donumCashinHand.Name = "donumCashinHand";
            this.donumCashinHand.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.donumCashinHand.Size = new System.Drawing.Size(161, 20);
            this.donumCashinHand.TabIndex = 875;
            this.donumCashinHand.Tag = "CashinHand";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 874;
            this.label3.Text = "Cash in Hand :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(228, 16);
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
            this.dtDate.Location = new System.Drawing.Point(298, 13);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(97, 20);
            this.dtDate.TabIndex = 872;
            this.dtDate.Tag = "TransDate";
            // 
            // ditxtTransNo
            // 
            this.ditxtTransNo.BackColor = System.Drawing.Color.White;
            this.ditxtTransNo.DataField = null;
            this.ditxtTransNo.Location = new System.Drawing.Point(81, 14);
            this.ditxtTransNo.Name = "ditxtTransNo";
            this.ditxtTransNo.Size = new System.Drawing.Size(125, 20);
            this.ditxtTransNo.TabIndex = 707;
            this.ditxtTransNo.Tag = "TransNo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 706;
            this.label2.Text = "Remarks :";
            // 
            // ditxtRemarks
            // 
            this.ditxtRemarks.BackColor = System.Drawing.Color.White;
            this.ditxtRemarks.DataField = null;
            this.ditxtRemarks.Location = new System.Drawing.Point(81, 40);
            this.ditxtRemarks.Name = "ditxtRemarks";
            this.ditxtRemarks.Size = new System.Drawing.Size(572, 20);
            this.ditxtRemarks.TabIndex = 705;
            this.ditxtRemarks.Tag = "Remarks";
            // 
            // grpVault
            // 
            this.grpVault.Controls.Add(this.rdoOut);
            this.grpVault.Controls.Add(this.rdoIn);
            this.grpVault.Location = new System.Drawing.Point(662, 3);
            this.grpVault.Name = "grpVault";
            this.grpVault.Size = new System.Drawing.Size(100, 31);
            this.grpVault.TabIndex = 2;
            this.grpVault.TabStop = false;
            this.grpVault.Text = "Vault";
            // 
            // rdoOut
            // 
            this.rdoOut.AutoSize = true;
            this.rdoOut.Location = new System.Drawing.Point(43, 13);
            this.rdoOut.Name = "rdoOut";
            this.rdoOut.Size = new System.Drawing.Size(42, 17);
            this.rdoOut.TabIndex = 1;
            this.rdoOut.TabStop = true;
            this.rdoOut.Text = "Out";
            this.rdoOut.UseVisualStyleBackColor = true;
            this.rdoOut.CheckedChanged += new System.EventHandler(this.rdoOut_CheckedChanged);
            // 
            // rdoIn
            // 
            this.rdoIn.AutoSize = true;
            this.rdoIn.Location = new System.Drawing.Point(6, 13);
            this.rdoIn.Name = "rdoIn";
            this.rdoIn.Size = new System.Drawing.Size(36, 17);
            this.rdoIn.TabIndex = 0;
            this.rdoIn.TabStop = true;
            this.rdoIn.Text = "IN";
            this.rdoIn.UseVisualStyleBackColor = true;
            this.rdoIn.CheckedChanged += new System.EventHandler(this.rdoIn_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trans No :";
            // 
            // dtbDetail
            // 
            this.dtbDetail.AllowUserToAddRows = false;
            this.dtbDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtbDetail.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtbDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbDetail.Location = new System.Drawing.Point(2, 79);
            this.dtbDetail.Name = "dtbDetail";
            this.dtbDetail.Size = new System.Drawing.Size(763, 282);
            this.dtbDetail.TabIndex = 704;
            this.dtbDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtbDetail_CellEndEdit);
            // 
            // frmVaultINOUT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 746);
            this.Controls.Add(this.dtbDetail);
            this.Controls.Add(this.PnlMain);
            this.Name = "frmVaultINOUT";
            this.Text = "frmVaultINOUT";
            this.Load += new System.EventHandler(this.frmVaultINOUT_Load);
            this.Activated += new System.EventHandler(this.frmVaultINOUT_Activated);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.PnlMain, 0);
            this.Controls.SetChildIndex(this.dtbDetail, 0);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donumCashinHand)).EndInit();
            this.grpVault.ResumeLayout(false);
            this.grpVault.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpVault;
        private System.Windows.Forms.RadioButton rdoOut;
        private System.Windows.Forms.RadioButton rdoIn;
        private System.Windows.Forms.DataGridView dtbDetail;
        private System.Windows.Forms.Label label2;
        private cstTextBox ditxtRemarks;
        private cstTextBox ditxtTransNo;
        private System.Windows.Forms.Label label16;
        public ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtDate;
        private cstNumericupDown donumCashinHand;
        private System.Windows.Forms.Label label3;
    }
}