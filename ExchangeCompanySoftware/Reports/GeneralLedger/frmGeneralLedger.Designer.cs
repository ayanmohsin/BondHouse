namespace ExchangeCompanySoftware
{
    partial class frmGeneralLedger
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
            this.pnlMain1 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.pnlMain2 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.label2 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.pnlMain3 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.dicboAccounts = new ExchangeCompanySoftware.cstComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlMain4 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.dicboTypfoGL = new ExchangeCompanySoftware.cstComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.btnBL = new System.Windows.Forms.Button();
            this.pnlMain1.SuspendLayout();
            this.pnlMain2.SuspendLayout();
            this.pnlMain3.SuspendLayout();
            this.pnlMain4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain1
            // 
            this.pnlMain1.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain1.BeginColor = System.Drawing.Color.Transparent;
            this.pnlMain1.Controls.Add(this.label1);
            this.pnlMain1.Controls.Add(this.dtFromDate);
            this.pnlMain1.EndColor = System.Drawing.Color.Transparent;
            this.pnlMain1.Location = new System.Drawing.Point(14, 12);
            this.pnlMain1.Name = "pnlMain1";
            this.pnlMain1.Size = new System.Drawing.Size(198, 28);
            this.pnlMain1.TabIndex = 703;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
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
            // pnlMain2
            // 
            this.pnlMain2.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain2.BeginColor = System.Drawing.Color.Transparent;
            this.pnlMain2.Controls.Add(this.label2);
            this.pnlMain2.Controls.Add(this.dtToDate);
            this.pnlMain2.EndColor = System.Drawing.Color.Transparent;
            this.pnlMain2.Location = new System.Drawing.Point(218, 12);
            this.pnlMain2.Name = "pnlMain2";
            this.pnlMain2.Size = new System.Drawing.Size(198, 28);
            this.pnlMain2.TabIndex = 704;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(5, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
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
            // pnlMain3
            // 
            this.pnlMain3.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain3.BeginColor = System.Drawing.Color.Transparent;
            this.pnlMain3.Controls.Add(this.dicboAccounts);
            this.pnlMain3.Controls.Add(this.label3);
            this.pnlMain3.EndColor = System.Drawing.Color.Transparent;
            this.pnlMain3.Location = new System.Drawing.Point(14, 72);
            this.pnlMain3.Name = "pnlMain3";
            this.pnlMain3.Size = new System.Drawing.Size(402, 28);
            this.pnlMain3.TabIndex = 705;
            // 
            // dicboAccounts
            // 
            this.dicboAccounts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.dicboAccounts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.dicboAccounts.BackColor = System.Drawing.Color.NavajoWhite;
            this.dicboAccounts.DataField = null;
            this.dicboAccounts.FormattingEnabled = true;
            this.dicboAccounts.Location = new System.Drawing.Point(77, 3);
            this.dicboAccounts.Name = "dicboAccounts";
            this.dicboAccounts.Size = new System.Drawing.Size(312, 21);
            this.dicboAccounts.TabIndex = 706;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(5, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 705;
            this.label3.Text = "Account";
            // 
            // pnlMain4
            // 
            this.pnlMain4.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain4.BeginColor = System.Drawing.Color.Transparent;
            this.pnlMain4.Controls.Add(this.dicboTypfoGL);
            this.pnlMain4.Controls.Add(this.label4);
            this.pnlMain4.EndColor = System.Drawing.Color.Transparent;
            this.pnlMain4.Location = new System.Drawing.Point(14, 133);
            this.pnlMain4.Name = "pnlMain4";
            this.pnlMain4.Size = new System.Drawing.Size(402, 28);
            this.pnlMain4.TabIndex = 706;
            // 
            // dicboTypfoGL
            // 
            this.dicboTypfoGL.BackColor = System.Drawing.Color.NavajoWhite;
            this.dicboTypfoGL.DataField = null;
            this.dicboTypfoGL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicboTypfoGL.FormattingEnabled = true;
            this.dicboTypfoGL.Items.AddRange(new object[] {
            "Local",
            "FC",
            "Both"});
            this.dicboTypfoGL.Location = new System.Drawing.Point(77, 4);
            this.dicboTypfoGL.Name = "dicboTypfoGL";
            this.dicboTypfoGL.Size = new System.Drawing.Size(312, 21);
            this.dicboTypfoGL.TabIndex = 706;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(5, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 705;
            this.label4.Text = "Type of GL";
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Location = new System.Drawing.Point(422, 9);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(121, 76);
            this.cmdGenerate.TabIndex = 707;
            this.cmdGenerate.Text = "Preview GL";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(422, 133);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(118, 36);
            this.cmdClose.TabIndex = 708;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            // 
            // btnBL
            // 
            this.btnBL.Location = new System.Drawing.Point(422, 91);
            this.btnBL.Name = "btnBL";
            this.btnBL.Size = new System.Drawing.Size(121, 36);
            this.btnBL.TabIndex = 710;
            this.btnBL.Text = "Balance Sheet";
            this.btnBL.UseVisualStyleBackColor = true;
            this.btnBL.Click += new System.EventHandler(this.btnBL_Click);
            // 
            // frmGeneralLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 180);
            this.Controls.Add(this.btnBL);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdGenerate);
            this.Controls.Add(this.pnlMain4);
            this.Controls.Add(this.pnlMain3);
            this.Controls.Add(this.pnlMain2);
            this.Controls.Add(this.pnlMain1);
            this.Name = "frmGeneralLedger";
            this.Text = "frmGeneralLedger";
            this.Load += new System.EventHandler(this.frmGeneralLedger_Load);
            this.Controls.SetChildIndex(this.pnlMain1, 0);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.pnlMain2, 0);
            this.Controls.SetChildIndex(this.pnlMain3, 0);
            this.Controls.SetChildIndex(this.pnlMain4, 0);
            this.Controls.SetChildIndex(this.cmdGenerate, 0);
            this.Controls.SetChildIndex(this.cmdClose, 0);
            this.Controls.SetChildIndex(this.btnBL, 0);
            this.pnlMain1.ResumeLayout(false);
            this.pnlMain1.PerformLayout();
            this.pnlMain2.ResumeLayout(false);
            this.pnlMain2.PerformLayout();
            this.pnlMain3.ResumeLayout(false);
            this.pnlMain3.PerformLayout();
            this.pnlMain4.ResumeLayout(false);
            this.pnlMain4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain3;
        private System.Windows.Forms.Label label3;
        private cstComboBox dicboAccounts;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain4;
        private cstComboBox dicboTypfoGL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button btnBL;
    }
}