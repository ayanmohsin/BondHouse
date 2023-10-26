namespace ExchangeCompanySoftware
{
    partial class frmSetupLocation
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
            this.label2 = new System.Windows.Forms.Label();
            this.dotxtRemarks = new ExchangeCompanySoftware.cstTextBox();
            this.ditxtDescription = new ExchangeCompanySoftware.cstTextBox();
            this.ditxtLocationCode = new ExchangeCompanySoftware.cstTextBox();
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
            this.PnlMain.Controls.Add(this.label2);
            this.PnlMain.Controls.Add(this.dotxtRemarks);
            this.PnlMain.Controls.Add(this.ditxtDescription);
            this.PnlMain.Controls.Add(this.ditxtLocationCode);
            this.PnlMain.Controls.Add(this.label3);
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Location = new System.Drawing.Point(2, 1);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(547, 94);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Remarks :";
            // 
            // dotxtRemarks
            // 
            this.dotxtRemarks.BackColor = System.Drawing.Color.White;
            this.dotxtRemarks.DataField = null;
            this.dotxtRemarks.Location = new System.Drawing.Point(109, 64);
            this.dotxtRemarks.Name = "dotxtRemarks";
            this.dotxtRemarks.Size = new System.Drawing.Size(283, 20);
            this.dotxtRemarks.TabIndex = 1;
            this.dotxtRemarks.Tag = "Remarks";
            // 
            // ditxtDescription
            // 
            this.ditxtDescription.BackColor = System.Drawing.Color.White;
            this.ditxtDescription.DataField = null;
            this.ditxtDescription.Location = new System.Drawing.Point(109, 38);
            this.ditxtDescription.Name = "ditxtDescription";
            this.ditxtDescription.Size = new System.Drawing.Size(283, 20);
            this.ditxtDescription.TabIndex = 0;
            this.ditxtDescription.Tag = "LocationName";
            // 
            // ditxtLocationCode
            // 
            this.ditxtLocationCode.BackColor = System.Drawing.Color.White;
            this.ditxtLocationCode.DataField = null;
            this.ditxtLocationCode.Location = new System.Drawing.Point(109, 8);
            this.ditxtLocationCode.Name = "ditxtLocationCode";
            this.ditxtLocationCode.Size = new System.Drawing.Size(100, 20);
            this.ditxtLocationCode.TabIndex = 7;
            this.ditxtLocationCode.Tag = "LocationCode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Location Code :";
            // 
            // frmSetupLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 312);
            this.Controls.Add(this.PnlMain);
            this.Name = "frmSetupLocation";
            this.Text = "s";
            this.Load += new System.EventHandler(this.frmSetupItem_Load);
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
        private cstTextBox ditxtDescription;
        private cstTextBox ditxtLocationCode;
        private System.Windows.Forms.Label label2;
        private cstTextBox dotxtRemarks;
        private System.Windows.Forms.Label label16;
        public ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtDate;
    }
}