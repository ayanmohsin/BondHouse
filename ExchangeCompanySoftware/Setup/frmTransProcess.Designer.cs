namespace ExchangeCompanySoftware
{
    partial class frmTransProcess
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
            this.label2 = new System.Windows.Forms.Label();
            this.dttoDate = new System.Windows.Forms.DateTimePicker();
            this.btnGenerateProcess = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(80, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dttoDate
            // 
            this.dttoDate.CustomFormat = "dd/MMM/yyyy";
            this.dttoDate.Enabled = false;
            this.dttoDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dttoDate.Location = new System.Drawing.Point(138, 54);
            this.dttoDate.Name = "dttoDate";
            this.dttoDate.Size = new System.Drawing.Size(108, 20);
            this.dttoDate.TabIndex = 3;
            // 
            // btnGenerateProcess
            // 
            this.btnGenerateProcess.Location = new System.Drawing.Point(8, 100);
            this.btnGenerateProcess.Name = "btnGenerateProcess";
            this.btnGenerateProcess.Size = new System.Drawing.Size(350, 42);
            this.btnGenerateProcess.TabIndex = 4;
            this.btnGenerateProcess.Text = "Generate Process";
            this.btnGenerateProcess.UseVisualStyleBackColor = true;
            this.btnGenerateProcess.Click += new System.EventHandler(this.btnGenerateProcess_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(55, 32);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(260, 16);
            this.progressBar1.TabIndex = 703;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 704;
            this.label1.Text = "label1";
            // 
            // frmTransProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 149);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnGenerateProcess);
            this.Controls.Add(this.dttoDate);
            this.Controls.Add(this.label2);
            this.Name = "frmTransProcess";
            this.Text = "Transaction Process";
            this.Load += new System.EventHandler(this.frmTransProcess_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dttoDate, 0);
            this.Controls.SetChildIndex(this.btnGenerateProcess, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dttoDate;
        private System.Windows.Forms.Button btnGenerateProcess;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
    }
}