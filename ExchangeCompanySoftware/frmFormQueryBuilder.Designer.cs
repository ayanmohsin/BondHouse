namespace ExchangeCompanySoftware
{
    partial class frmFormQueryBuilder
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
            this.dtbDetail = new System.Windows.Forms.DataGridView();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmdGenerate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dtbDetail
            // 
            this.dtbDetail.AllowUserToAddRows = false;
            this.dtbDetail.AllowUserToDeleteRows = false;
            this.dtbDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtbDetail.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.dtbDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbDetail.Location = new System.Drawing.Point(-1, 1);
            this.dtbDetail.Name = "dtbDetail";
            this.dtbDetail.RowHeadersVisible = false;
            this.dtbDetail.Size = new System.Drawing.Size(596, 333);
            this.dtbDetail.TabIndex = 9;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = global::ExchangeCompanySoftware.Resource1.close;
            this.cmdCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdCancel.Location = new System.Drawing.Point(212, 337);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(98, 80);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::ExchangeCompanySoftware.Resource1.refresh_New;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Location = new System.Drawing.Point(108, 337);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(98, 80);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.BackgroundImage = global::ExchangeCompanySoftware.Resource1.Preview_icon;
            this.cmdGenerate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdGenerate.Location = new System.Drawing.Point(4, 337);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(98, 80);
            this.cmdGenerate.TabIndex = 10;
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // frmFormQueryBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 418);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmdGenerate);
            this.Controls.Add(this.dtbDetail);
            this.Name = "frmFormQueryBuilder";
            this.Text = "frmFormQueryBuilder";
            this.Load += new System.EventHandler(this.frmFormQueryBuilder_Load);
            this.Controls.SetChildIndex(this.dtbDetail, 0);
            this.Controls.SetChildIndex(this.cmdGenerate, 0);
            this.Controls.SetChildIndex(this.btnRefresh, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtbDetail;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button cmdGenerate;
    }
}