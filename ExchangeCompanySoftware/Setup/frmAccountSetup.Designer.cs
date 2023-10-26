namespace ExchangeCompanySoftware
{
    partial class frmAccountSetup
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
            this.docboBranch = new ExchangeCompanySoftware.cstComboBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.chkBranch = new ExchangeCompanySoftware.Custom_Controls.cstCheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dtDate = new ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker();
            this.dicboCurrency = new ExchangeCompanySoftware.cstComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.grp = new System.Windows.Forms.GroupBox();
            this.rdoBank = new System.Windows.Forms.RadioButton();
            this.rdoCash = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.docboNature = new ExchangeCompanySoftware.cstComboBox();
            this.cstCheckBox1 = new ExchangeCompanySoftware.Custom_Controls.cstCheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.docboOpening = new ExchangeCompanySoftware.cstNumericupDown();
            this.ditxtAccountNo = new ExchangeCompanySoftware.cstTextBox();
            this.chkLocked = new ExchangeCompanySoftware.Custom_Controls.cstCheckBox();
            this.tvAccount = new System.Windows.Forms.TreeView();
            this.docboHeader = new ExchangeCompanySoftware.cstComboBox();
            this.ditxtTitle = new ExchangeCompanySoftware.cstTextBox();
            this.dotxtAddress = new ExchangeCompanySoftware.cstTextBox();
            this.dotxtPhoneNo = new ExchangeCompanySoftware.cstTextBox();
            this.docboCity = new ExchangeCompanySoftware.cstComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PnlMain.SuspendLayout();
            this.grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docboOpening)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.Transparent;
            this.PnlMain.Controls.Add(this.docboBranch);
            this.PnlMain.Controls.Add(this.lblBranch);
            this.PnlMain.Controls.Add(this.chkBranch);
            this.PnlMain.Controls.Add(this.label16);
            this.PnlMain.Controls.Add(this.dtDate);
            this.PnlMain.Controls.Add(this.dicboCurrency);
            this.PnlMain.Controls.Add(this.label10);
            this.PnlMain.Controls.Add(this.grp);
            this.PnlMain.Controls.Add(this.label8);
            this.PnlMain.Controls.Add(this.docboNature);
            this.PnlMain.Controls.Add(this.cstCheckBox1);
            this.PnlMain.Controls.Add(this.label7);
            this.PnlMain.Controls.Add(this.docboOpening);
            this.PnlMain.Controls.Add(this.ditxtAccountNo);
            this.PnlMain.Controls.Add(this.chkLocked);
            this.PnlMain.Controls.Add(this.tvAccount);
            this.PnlMain.Controls.Add(this.docboHeader);
            this.PnlMain.Controls.Add(this.ditxtTitle);
            this.PnlMain.Controls.Add(this.dotxtAddress);
            this.PnlMain.Controls.Add(this.dotxtPhoneNo);
            this.PnlMain.Controls.Add(this.docboCity);
            this.PnlMain.Controls.Add(this.label6);
            this.PnlMain.Controls.Add(this.label5);
            this.PnlMain.Controls.Add(this.label4);
            this.PnlMain.Controls.Add(this.label3);
            this.PnlMain.Controls.Add(this.label2);
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Location = new System.Drawing.Point(2, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(622, 239);
            this.PnlMain.TabIndex = 35;
            this.PnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlMain_Paint);
            // 
            // docboBranch
            // 
            this.docboBranch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.docboBranch.DataField = null;
            this.docboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.docboBranch.FormattingEnabled = true;
            this.docboBranch.Location = new System.Drawing.Point(647, 394);
            this.docboBranch.Name = "docboBranch";
            this.docboBranch.Size = new System.Drawing.Size(10, 21);
            this.docboBranch.TabIndex = 820;
            this.docboBranch.Tag = "BranchCodeTag";
            this.docboBranch.Visible = false;
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(644, 378);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(41, 13);
            this.lblBranch.TabIndex = 821;
            this.lblBranch.Text = "Branch";
            this.lblBranch.Visible = false;
            // 
            // chkBranch
            // 
            this.chkBranch.AutoSize = true;
            this.chkBranch.DataField = null;
            this.chkBranch.Location = new System.Drawing.Point(553, 396);
            this.chkBranch.Name = "chkBranch";
            this.chkBranch.Size = new System.Drawing.Size(70, 17);
            this.chkBranch.TabIndex = 819;
            this.chkBranch.Tag = "isBranch";
            this.chkBranch.Text = "is Branch";
            this.chkBranch.UseVisualStyleBackColor = true;
            this.chkBranch.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(270, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 818;
            this.label16.Text = "Trans Date";
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd/MMM/yyyy";
            this.dtDate.DataField = null;
            this.dtDate.Enabled = false;
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(370, 13);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(107, 20);
            this.dtDate.TabIndex = 817;
            this.dtDate.Tag = "TransDate";
            // 
            // dicboCurrency
            // 
            this.dicboCurrency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.dicboCurrency.DataField = null;
            this.dicboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicboCurrency.FormattingEnabled = true;
            this.dicboCurrency.Location = new System.Drawing.Point(370, 115);
            this.dicboCurrency.Name = "dicboCurrency";
            this.dicboCurrency.Size = new System.Drawing.Size(121, 21);
            this.dicboCurrency.TabIndex = 3;
            this.dicboCurrency.Tag = "CurrencyCode";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(275, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 789;
            this.label10.Text = "Currency";
            // 
            // grp
            // 
            this.grp.Controls.Add(this.rdoBank);
            this.grp.Controls.Add(this.rdoCash);
            this.grp.Location = new System.Drawing.Point(468, 175);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(142, 31);
            this.grp.TabIndex = 23;
            this.grp.TabStop = false;
            // 
            // rdoBank
            // 
            this.rdoBank.AutoSize = true;
            this.rdoBank.Location = new System.Drawing.Point(65, 11);
            this.rdoBank.Name = "rdoBank";
            this.rdoBank.Size = new System.Drawing.Size(50, 17);
            this.rdoBank.TabIndex = 11;
            this.rdoBank.TabStop = true;
            this.rdoBank.Tag = "BankCash";
            this.rdoBank.Text = "Bank";
            this.rdoBank.UseVisualStyleBackColor = true;
            // 
            // rdoCash
            // 
            this.rdoCash.AutoSize = true;
            this.rdoCash.Location = new System.Drawing.Point(10, 11);
            this.rdoCash.Name = "rdoCash";
            this.rdoCash.Size = new System.Drawing.Size(49, 17);
            this.rdoCash.TabIndex = 10;
            this.rdoCash.TabStop = true;
            this.rdoCash.Tag = "BankCash";
            this.rdoCash.Text = "Cash";
            this.rdoCash.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(275, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Nature";
            // 
            // docboNature
            // 
            this.docboNature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.docboNature.DataField = null;
            this.docboNature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.docboNature.FormattingEnabled = true;
            this.docboNature.Location = new System.Drawing.Point(370, 148);
            this.docboNature.Name = "docboNature";
            this.docboNature.Size = new System.Drawing.Size(121, 21);
            this.docboNature.TabIndex = 5;
            this.docboNature.Tag = "NatureCode";
            // 
            // cstCheckBox1
            // 
            this.cstCheckBox1.AutoSize = true;
            this.cstCheckBox1.DataField = null;
            this.cstCheckBox1.Location = new System.Drawing.Point(356, 186);
            this.cstCheckBox1.Name = "cstCheckBox1";
            this.cstCheckBox1.Size = new System.Drawing.Size(90, 17);
            this.cstCheckBox1.TabIndex = 8;
            this.cstCheckBox1.Tag = "isTransactional";
            this.cstCheckBox1.Text = "Transactional";
            this.cstCheckBox1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(549, 348);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Opening Balance";
            this.label7.Visible = false;
            // 
            // docboOpening
            // 
            this.docboOpening.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.docboOpening.DataField = null;
            this.docboOpening.DecimalPlaces = 4;
            this.docboOpening.Location = new System.Drawing.Point(647, 342);
            this.docboOpening.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.docboOpening.Name = "docboOpening";
            this.docboOpening.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.docboOpening.Size = new System.Drawing.Size(10, 20);
            this.docboOpening.TabIndex = 7;
            this.docboOpening.Tag = "OpeningBalance";
            this.docboOpening.Visible = false;
            // 
            // ditxtAccountNo
            // 
            this.ditxtAccountNo.BackColor = System.Drawing.Color.White;
            this.ditxtAccountNo.DataField = null;
            this.ditxtAccountNo.Location = new System.Drawing.Point(370, 36);
            this.ditxtAccountNo.Name = "ditxtAccountNo";
            this.ditxtAccountNo.Size = new System.Drawing.Size(239, 20);
            this.ditxtAccountNo.TabIndex = 16;
            this.ditxtAccountNo.Tag = "AccountNo";
            // 
            // chkLocked
            // 
            this.chkLocked.AutoSize = true;
            this.chkLocked.DataField = null;
            this.chkLocked.Location = new System.Drawing.Point(279, 187);
            this.chkLocked.Name = "chkLocked";
            this.chkLocked.Size = new System.Drawing.Size(62, 17);
            this.chkLocked.TabIndex = 9;
            this.chkLocked.Tag = "Locked";
            this.chkLocked.Text = "Locked";
            this.chkLocked.UseVisualStyleBackColor = true;
            // 
            // tvAccount
            // 
            this.tvAccount.Location = new System.Drawing.Point(5, 3);
            this.tvAccount.Name = "tvAccount";
            this.tvAccount.Size = new System.Drawing.Size(259, 227);
            this.tvAccount.TabIndex = 13;
            this.tvAccount.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvAccount_AfterSelect);
            // 
            // docboHeader
            // 
            this.docboHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.docboHeader.DataField = null;
            this.docboHeader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.docboHeader.FormattingEnabled = true;
            this.docboHeader.Location = new System.Drawing.Point(370, 62);
            this.docboHeader.Name = "docboHeader";
            this.docboHeader.Size = new System.Drawing.Size(239, 21);
            this.docboHeader.TabIndex = 0;
            this.docboHeader.Tag = "HeaderCode";
            // 
            // ditxtTitle
            // 
            this.ditxtTitle.BackColor = System.Drawing.Color.White;
            this.ditxtTitle.DataField = null;
            this.ditxtTitle.Location = new System.Drawing.Point(370, 89);
            this.ditxtTitle.Name = "ditxtTitle";
            this.ditxtTitle.Size = new System.Drawing.Size(239, 20);
            this.ditxtTitle.TabIndex = 1;
            this.ditxtTitle.Tag = "Title";
            // 
            // dotxtAddress
            // 
            this.dotxtAddress.BackColor = System.Drawing.Color.White;
            this.dotxtAddress.DataField = null;
            this.dotxtAddress.Location = new System.Drawing.Point(647, 234);
            this.dotxtAddress.Name = "dotxtAddress";
            this.dotxtAddress.Size = new System.Drawing.Size(10, 20);
            this.dotxtAddress.TabIndex = 2;
            this.dotxtAddress.Tag = "Address";
            this.dotxtAddress.Visible = false;
            // 
            // dotxtPhoneNo
            // 
            this.dotxtPhoneNo.BackColor = System.Drawing.Color.White;
            this.dotxtPhoneNo.DataField = null;
            this.dotxtPhoneNo.Location = new System.Drawing.Point(647, 321);
            this.dotxtPhoneNo.Name = "dotxtPhoneNo";
            this.dotxtPhoneNo.Size = new System.Drawing.Size(10, 20);
            this.dotxtPhoneNo.TabIndex = 6;
            this.dotxtPhoneNo.Tag = "PhoneNo";
            this.dotxtPhoneNo.Visible = false;
            // 
            // docboCity
            // 
            this.docboCity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.docboCity.DataField = null;
            this.docboCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.docboCity.FormattingEnabled = true;
            this.docboCity.Location = new System.Drawing.Point(647, 277);
            this.docboCity.Name = "docboCity";
            this.docboCity.Size = new System.Drawing.Size(10, 21);
            this.docboCity.TabIndex = 4;
            this.docboCity.Tag = "CityCode";
            this.docboCity.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(552, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Phone";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Header";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(552, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "City";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(552, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Address";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account No";
            // 
            // frmAccountSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 487);
            this.Controls.Add(this.PnlMain);
            this.Name = "frmAccountSetup";
            this.Text = "frmAccountSetup";
            this.Deactivate += new System.EventHandler(this.frmAccountSetup_Deactivate);
            this.Load += new System.EventHandler(this.frmAccountSetup_Load);
            this.Activated += new System.EventHandler(this.frmAccountSetup_Activated);
            this.Controls.SetChildIndex(this.PnlMain, 0);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docboOpening)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private cstComboBox docboHeader;
        private cstTextBox ditxtTitle;
        private cstTextBox dotxtAddress;
        private cstTextBox dotxtPhoneNo;
        private cstComboBox docboCity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tvAccount;
        private ExchangeCompanySoftware.Custom_Controls.cstCheckBox chkLocked;
        private cstTextBox ditxtAccountNo;
        private System.Windows.Forms.Label label7;
        private cstNumericupDown docboOpening;
        private ExchangeCompanySoftware.Custom_Controls.cstCheckBox cstCheckBox1;
        private System.Windows.Forms.Label label8;
        private cstComboBox docboNature;
        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.RadioButton rdoBank;
        private System.Windows.Forms.RadioButton rdoCash;
        private cstComboBox dicboCurrency;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        public ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtDate;
        private cstComboBox docboBranch;
        private System.Windows.Forms.Label lblBranch;
        private ExchangeCompanySoftware.Custom_Controls.cstCheckBox chkBranch;
    }
}