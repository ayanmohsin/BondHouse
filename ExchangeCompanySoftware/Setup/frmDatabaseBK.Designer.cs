namespace ExchangeCompanySoftware
{
    partial class frmDatabaseBK
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
            this.btnDbBK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDbBK
            // 
            this.btnDbBK.Location = new System.Drawing.Point(3, 47);
            this.btnDbBK.Name = "btnDbBK";
            this.btnDbBK.Size = new System.Drawing.Size(350, 42);
            this.btnDbBK.TabIndex = 706;
            this.btnDbBK.Text = "Database BackUp";
            this.btnDbBK.UseVisualStyleBackColor = true;
            this.btnDbBK.Click += new System.EventHandler(this.btnDbBK_Click);
            // 
            // frmDatabaseBK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(365, 149);
            this.Controls.Add(this.btnDbBK);
            this.Name = "frmDatabaseBK";
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.btnDbBK, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDbBK;
    }
}
