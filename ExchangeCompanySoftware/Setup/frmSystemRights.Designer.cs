namespace ExchangeCompanySoftware
{
    partial class frmSystemRights
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
            this.PnlMain = new System.Windows.Forms.Panel();
            this.pnlMain7 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.label36 = new System.Windows.Forms.Label();
            this.pnlMain1 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.label21 = new System.Windows.Forms.Label();
            this.cstLocked = new ExchangeCompanySoftware.Custom_Controls.cstCheckBox();
            this.cmdFetch = new System.Windows.Forms.Button();
            this.dicboBranch = new ExchangeCompanySoftware.cstComboBox();
            this.dicboPassword = new ExchangeCompanySoftware.cstTextBox();
            this.dotxtConfirmPassword = new ExchangeCompanySoftware.cstTextBox();
            this.ditxtUser = new ExchangeCompanySoftware.cstTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtbdetail1 = new System.Windows.Forms.DataGridView();
            this.chkSelectAll = new ExchangeCompanySoftware.Custom_Controls.cstCheckBox();
            this.dtbButton = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).BeginInit();
            this.PnlMain.SuspendLayout();
            this.pnlMain7.SuspendLayout();
            this.pnlMain1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtbdetail1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbButton)).BeginInit();
            this.SuspendLayout();
            // 
            // dtbDetail
            // 
            this.dtbDetail.AllowUserToAddRows = false;
            this.dtbDetail.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtbDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbDetail.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtbDetail.Location = new System.Drawing.Point(2, 153);
            this.dtbDetail.Name = "dtbDetail";
            this.dtbDetail.Size = new System.Drawing.Size(345, 157);
            this.dtbDetail.TabIndex = 710;
            this.dtbDetail.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtbDetail_RowEnter);
            this.dtbDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtbDetail_CellContentClick_1);
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.Transparent;
            this.PnlMain.Controls.Add(this.pnlMain7);
            this.PnlMain.Controls.Add(this.pnlMain1);
            this.PnlMain.Controls.Add(this.cstLocked);
            this.PnlMain.Controls.Add(this.cmdFetch);
            this.PnlMain.Controls.Add(this.dicboBranch);
            this.PnlMain.Controls.Add(this.dicboPassword);
            this.PnlMain.Controls.Add(this.dotxtConfirmPassword);
            this.PnlMain.Controls.Add(this.ditxtUser);
            this.PnlMain.Controls.Add(this.label4);
            this.PnlMain.Controls.Add(this.label3);
            this.PnlMain.Controls.Add(this.label2);
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Location = new System.Drawing.Point(1, -1);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(522, 153);
            this.PnlMain.TabIndex = 711;
            // 
            // pnlMain7
            // 
            this.pnlMain7.BeginColor = System.Drawing.Color.Maroon;
            this.pnlMain7.Controls.Add(this.label36);
            this.pnlMain7.EndColor = System.Drawing.Color.Red;
            this.pnlMain7.Location = new System.Drawing.Point(3, 134);
            this.pnlMain7.Name = "pnlMain7";
            this.pnlMain7.Size = new System.Drawing.Size(518, 18);
            this.pnlMain7.TabIndex = 813;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label36.Location = new System.Drawing.Point(5, 2);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(107, 13);
            this.label36.TabIndex = 0;
            this.label36.Text = "Detail Information";
            // 
            // pnlMain1
            // 
            this.pnlMain1.BeginColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMain1.Controls.Add(this.label21);
            this.pnlMain1.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlMain1.Location = new System.Drawing.Point(3, 3);
            this.pnlMain1.Name = "pnlMain1";
            this.pnlMain1.Size = new System.Drawing.Size(518, 18);
            this.pnlMain1.TabIndex = 812;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label21.Location = new System.Drawing.Point(5, 2);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(112, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Master Information";
            // 
            // cstLocked
            // 
            this.cstLocked.AutoSize = true;
            this.cstLocked.DataField = null;
            this.cstLocked.Location = new System.Drawing.Point(428, 31);
            this.cstLocked.Name = "cstLocked";
            this.cstLocked.Size = new System.Drawing.Size(62, 17);
            this.cstLocked.TabIndex = 719;
            this.cstLocked.Tag = "Locked";
            this.cstLocked.Text = "Locked";
            this.cstLocked.UseVisualStyleBackColor = true;
            // 
            // cmdFetch
            // 
            this.cmdFetch.Location = new System.Drawing.Point(415, 83);
            this.cmdFetch.Name = "cmdFetch";
            this.cmdFetch.Size = new System.Drawing.Size(75, 23);
            this.cmdFetch.TabIndex = 718;
            this.cmdFetch.Text = "Fetch";
            this.cmdFetch.UseVisualStyleBackColor = true;
            // 
            // dicboBranch
            // 
            this.dicboBranch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.dicboBranch.DataField = null;
            this.dicboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicboBranch.FormattingEnabled = true;
            this.dicboBranch.Location = new System.Drawing.Point(138, 111);
            this.dicboBranch.Name = "dicboBranch";
            this.dicboBranch.Size = new System.Drawing.Size(352, 21);
            this.dicboBranch.TabIndex = 717;
            this.dicboBranch.Tag = "BranchCode";
            // 
            // dicboPassword
            // 
            this.dicboPassword.BackColor = System.Drawing.Color.White;
            this.dicboPassword.DataField = null;
            this.dicboPassword.Location = new System.Drawing.Point(138, 57);
            this.dicboPassword.Name = "dicboPassword";
            this.dicboPassword.Size = new System.Drawing.Size(100, 20);
            this.dicboPassword.TabIndex = 716;
            this.dicboPassword.Tag = "Password";
            // 
            // dotxtConfirmPassword
            // 
            this.dotxtConfirmPassword.BackColor = System.Drawing.Color.White;
            this.dotxtConfirmPassword.DataField = null;
            this.dotxtConfirmPassword.Location = new System.Drawing.Point(138, 85);
            this.dotxtConfirmPassword.Name = "dotxtConfirmPassword";
            this.dotxtConfirmPassword.Size = new System.Drawing.Size(100, 20);
            this.dotxtConfirmPassword.TabIndex = 715;
            // 
            // ditxtUser
            // 
            this.ditxtUser.BackColor = System.Drawing.Color.White;
            this.ditxtUser.DataField = null;
            this.ditxtUser.Location = new System.Drawing.Point(138, 29);
            this.ditxtUser.Name = "ditxtUser";
            this.ditxtUser.Size = new System.Drawing.Size(100, 20);
            this.ditxtUser.TabIndex = 714;
            this.ditxtUser.Tag = "UserId";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 713;
            this.label4.Text = "Branch";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 712;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 711;
            this.label2.Text = "Confirm Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 710;
            this.label1.Text = "User Id";
            // 
            // dtbdetail1
            // 
            this.dtbdetail1.AllowUserToAddRows = false;
            this.dtbdetail1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbdetail1.Location = new System.Drawing.Point(11, 175);
            this.dtbdetail1.Name = "dtbdetail1";
            this.dtbdetail1.ReadOnly = true;
            this.dtbdetail1.Size = new System.Drawing.Size(506, 78);
            this.dtbdetail1.TabIndex = 719;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.BackColor = System.Drawing.Color.Transparent;
            this.chkSelectAll.DataField = null;
            this.chkSelectAll.Location = new System.Drawing.Point(9, 318);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(73, 17);
            this.chkSelectAll.TabIndex = 720;
            this.chkSelectAll.Text = "Select  All";
            this.chkSelectAll.UseVisualStyleBackColor = false;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.cstCheckBox1_CheckedChanged);
            // 
            // dtbButton
            // 
            this.dtbButton.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtbButton.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbButton.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtbButton.Location = new System.Drawing.Point(345, 153);
            this.dtbButton.Name = "dtbButton";
            this.dtbButton.Size = new System.Drawing.Size(178, 157);
            this.dtbButton.TabIndex = 721;
            this.dtbButton.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtbButton_CellContentClick);
            // 
            // frmSystemRights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 554);
            this.Controls.Add(this.dtbButton);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.dtbDetail);
            this.Controls.Add(this.dtbdetail1);
            this.Name = "frmSystemRights";
            this.Text = "frmSystemRights";
            this.Load += new System.EventHandler(this.frmSystemRights_Load);
            this.Activated += new System.EventHandler(this.frmSystemRights_Activated);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.dtbdetail1, 0);
            this.Controls.SetChildIndex(this.dtbDetail, 0);
            this.Controls.SetChildIndex(this.PnlMain, 0);
            this.Controls.SetChildIndex(this.chkSelectAll, 0);
            this.Controls.SetChildIndex(this.dtbButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).EndInit();
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.pnlMain7.ResumeLayout(false);
            this.pnlMain7.PerformLayout();
            this.pnlMain1.ResumeLayout(false);
            this.pnlMain1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtbdetail1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtbDetail;
        private System.Windows.Forms.Panel PnlMain;
        private cstComboBox dicboBranch;
        private cstTextBox dicboPassword;
        private cstTextBox dotxtConfirmPassword;
        private cstTextBox ditxtUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdFetch;
        private System.Windows.Forms.DataGridView dtbdetail1;
        private ExchangeCompanySoftware.Custom_Controls.cstCheckBox cstLocked;
        private ExchangeCompanySoftware.Custom_Controls.cstCheckBox chkSelectAll;
        private System.Windows.Forms.DataGridView dtbButton;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain7;
        private System.Windows.Forms.Label label36;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain1;
        private System.Windows.Forms.Label label21;
    }
}