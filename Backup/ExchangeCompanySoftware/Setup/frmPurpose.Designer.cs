namespace ExchangeCompanySoftware
{
    partial class frmPurpose
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
            this.ditxtItemName = new ExchangeCompanySoftware.cstTextBox();
            this.ditxtItemCode = new ExchangeCompanySoftware.cstTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.Transparent;
            this.PnlMain.Controls.Add(this.label16);
            this.PnlMain.Controls.Add(this.dtDate);
            this.PnlMain.Controls.Add(this.ditxtItemName);
            this.PnlMain.Controls.Add(this.ditxtItemCode);
            this.PnlMain.Controls.Add(this.label3);
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Location = new System.Drawing.Point(2, 1);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(547, 78);
            this.PnlMain.TabIndex = 32;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(229, 10);
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
            this.dtDate.Location = new System.Drawing.Point(295, 7);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(97, 20);
            this.dtDate.TabIndex = 819;
            this.dtDate.Tag = "TransDate";
            // 
            // ditxtItemName
            // 
            this.ditxtItemName.BackColor = System.Drawing.Color.White;
            this.ditxtItemName.DataField = null;
            this.ditxtItemName.Location = new System.Drawing.Point(109, 38);
            this.ditxtItemName.Name = "ditxtItemName";
            this.ditxtItemName.Size = new System.Drawing.Size(283, 20);
            this.ditxtItemName.TabIndex = 0;
            this.ditxtItemName.Tag = "Purpose";
            // 
            // ditxtItemCode
            // 
            this.ditxtItemCode.BackColor = System.Drawing.Color.White;
            this.ditxtItemCode.DataField = null;
            this.ditxtItemCode.Location = new System.Drawing.Point(109, 8);
            this.ditxtItemCode.Name = "ditxtItemCode";
            this.ditxtItemCode.Size = new System.Drawing.Size(100, 20);
            this.ditxtItemCode.TabIndex = 7;
            this.ditxtItemCode.Tag = "PurposeCode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Purpose Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Purpose Code";
            // 
            // frmPurpose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 298);
            this.Controls.Add(this.PnlMain);
            this.Name = "frmPurpose";
            this.Text = "s";
            this.Load += new System.EventHandler(this.frmSetupItem_Load);
            this.Activated += new System.EventHandler(this.frmPurpose_Activated);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.PnlMain, 0);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private cstTextBox ditxtItemName;
        private cstTextBox ditxtItemCode;
        private System.Windows.Forms.Label label16;
        public ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtDate;
    }
}