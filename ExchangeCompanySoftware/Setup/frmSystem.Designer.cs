namespace ExchangeCompanySoftware
{
    partial class frmSystem
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
            this.Type = new System.Windows.Forms.Label();
            this.cmdFetch = new System.Windows.Forms.Button();
            this.dtbMaster1 = new System.Windows.Forms.DataGridView();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cboType = new ExchangeCompanySoftware.cstComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtbMaster1)).BeginInit();
            this.SuspendLayout();
            // 
            // Type
            // 
            this.Type.AutoSize = true;
            this.Type.Location = new System.Drawing.Point(12, 67);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(31, 13);
            this.Type.TabIndex = 701;
            this.Type.Text = "Type";
            // 
            // cmdFetch
            // 
            this.cmdFetch.Location = new System.Drawing.Point(190, 62);
            this.cmdFetch.Name = "cmdFetch";
            this.cmdFetch.Size = new System.Drawing.Size(75, 23);
            this.cmdFetch.TabIndex = 702;
            this.cmdFetch.Text = "Fetch";
            this.cmdFetch.UseVisualStyleBackColor = true;
            this.cmdFetch.Click += new System.EventHandler(this.cmdFetch_Click);
            // 
            // dtbMaster1
            // 
            this.dtbMaster1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbMaster1.Location = new System.Drawing.Point(15, 91);
            this.dtbMaster1.Name = "dtbMaster1";
            this.dtbMaster1.Size = new System.Drawing.Size(318, 176);
            this.dtbMaster1.TabIndex = 703;
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(258, 273);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(75, 23);
            this.cmdUpdate.TabIndex = 704;
            this.cmdUpdate.Text = "Update";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cboType
            // 
            this.cboType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.cboType.DataField = null;
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(53, 64);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(121, 21);
            this.cboType.TabIndex = 1;
            // 
            // frmSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 314);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.dtbMaster1);
            this.Controls.Add(this.cmdFetch);
            this.Controls.Add(this.Type);
            this.Controls.Add(this.cboType);
            this.Name = "frmSystem";
            this.Text = "frmSystem";
            this.Load += new System.EventHandler(this.frmSystem_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.cboType, 0);
            this.Controls.SetChildIndex(this.Type, 0);
            this.Controls.SetChildIndex(this.cmdFetch, 0);
            this.Controls.SetChildIndex(this.dtbMaster1, 0);
            this.Controls.SetChildIndex(this.cmdUpdate, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtbMaster1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private cstComboBox cboType;
        private System.Windows.Forms.Label Type;
        private System.Windows.Forms.Button cmdFetch;
        private System.Windows.Forms.DataGridView dtbMaster1;
        private System.Windows.Forms.Button cmdUpdate;
    }
}