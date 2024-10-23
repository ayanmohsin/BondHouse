namespace ExchangeCompanySoftware
{
    partial class frmMonthEnd
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
            this.btnGenerateProcess = new System.Windows.Forms.Button();
            this.dttoDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ditxtRemarks = new ExchangeCompanySoftware.cstTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenerateProcess
            // 
            this.btnGenerateProcess.Location = new System.Drawing.Point(7, 79);
            this.btnGenerateProcess.Name = "btnGenerateProcess";
            this.btnGenerateProcess.Size = new System.Drawing.Size(350, 42);
            this.btnGenerateProcess.TabIndex = 705;
            this.btnGenerateProcess.Text = "Monthly Closing Process";
            this.btnGenerateProcess.UseVisualStyleBackColor = true;
            this.btnGenerateProcess.Click += new System.EventHandler(this.btnGenerateProcess_Click);
            // 
            // dttoDate
            // 
            this.dttoDate.CustomFormat = "dd/MMM/yyyy";
            this.dttoDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dttoDate.Location = new System.Drawing.Point(67, 13);
            this.dttoDate.Name = "dttoDate";
            this.dttoDate.Size = new System.Drawing.Size(108, 20);
            this.dttoDate.TabIndex = 704;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(31, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 703;
            this.label2.Text = "Date";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ditxtRemarks
            // 
            this.ditxtRemarks.BackColor = System.Drawing.Color.White;
            this.ditxtRemarks.DataField = null;
            this.ditxtRemarks.Location = new System.Drawing.Point(67, 39);
            this.ditxtRemarks.Multiline = true;
            this.ditxtRemarks.Name = "ditxtRemarks";
            this.ditxtRemarks.Size = new System.Drawing.Size(286, 31);
            this.ditxtRemarks.TabIndex = 706;
            this.ditxtRemarks.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(14, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 707;
            this.label1.Text = "Remarks";
            // 
            // frmMonthEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(365, 149);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ditxtRemarks);
            this.Controls.Add(this.btnGenerateProcess);
            this.Controls.Add(this.dttoDate);
            this.Controls.Add(this.label2);
            this.Name = "frmMonthEnd";
            this.Text = "Monthly Closing";
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dttoDate, 0);
            this.Controls.SetChildIndex(this.btnGenerateProcess, 0);
            this.Controls.SetChildIndex(this.ditxtRemarks, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateProcess;
        private System.Windows.Forms.DateTimePicker dttoDate;
        private System.Windows.Forms.Label label2;
        private cstTextBox ditxtRemarks;
        private System.Windows.Forms.Label label1;
    }
}
