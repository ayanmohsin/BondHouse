namespace ExchangeCompanySoftware
{
    partial class frmSBP
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
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.pnlMain2 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.label2 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.pnlMain1 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.pnlMain2.SuspendLayout();
            this.pnlMain1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(292, 108);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(118, 36);
            this.cmdClose.TabIndex = 715;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Location = new System.Drawing.Point(165, 108);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(121, 36);
            this.cmdGenerate.TabIndex = 714;
            this.cmdGenerate.Text = "Preview";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // pnlMain2
            // 
            this.pnlMain2.BeginColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMain2.Controls.Add(this.label2);
            this.pnlMain2.Controls.Add(this.dtToDate);
            this.pnlMain2.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlMain2.Location = new System.Drawing.Point(212, 39);
            this.pnlMain2.Name = "pnlMain2";
            this.pnlMain2.Size = new System.Drawing.Size(198, 28);
            this.pnlMain2.TabIndex = 711;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(5, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 705;
            this.label2.Text = "To Date";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd/MMM/yyyy";
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(77, 3);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(108, 20);
            this.dtToDate.TabIndex = 704;
            // 
            // pnlMain1
            // 
            this.pnlMain1.BeginColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMain1.Controls.Add(this.label1);
            this.pnlMain1.Controls.Add(this.dtFromDate);
            this.pnlMain1.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlMain1.Location = new System.Drawing.Point(8, 39);
            this.pnlMain1.Name = "pnlMain1";
            this.pnlMain1.Size = new System.Drawing.Size(198, 28);
            this.pnlMain1.TabIndex = 710;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 705;
            this.label1.Text = "From Date";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd/MMM/yyyy";
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(77, 3);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(108, 20);
            this.dtFromDate.TabIndex = 704;
            // 
            // frmSBP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 156);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdGenerate);
            this.Controls.Add(this.pnlMain2);
            this.Controls.Add(this.pnlMain1);
            this.Name = "frmSBP";
            this.Text = "frmSBP";
            this.Load += new System.EventHandler(this.frmstaofsalefcyInterBankMkt_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.pnlMain1, 0);
            this.Controls.SetChildIndex(this.pnlMain2, 0);
            this.Controls.SetChildIndex(this.cmdGenerate, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.pnlMain2.ResumeLayout(false);
            this.pnlMain2.PerformLayout();
            this.pnlMain1.ResumeLayout(false);
            this.pnlMain1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdGenerate;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFromDate;
    }
}