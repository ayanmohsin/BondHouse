namespace ExchangeCompanySoftware
{
    partial class frmCustomers
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
            this.docboAccount = new ExchangeCompanySoftware.cstComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtDate = new ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker();
            this.docboBranch = new ExchangeCompanySoftware.cstComboBox();
            this.lblBranch = new System.Windows.Forms.Label();
            this.dochkBranch = new ExchangeCompanySoftware.Custom_Controls.cstCheckBox();
            this.dicboCustomerType = new ExchangeCompanySoftware.cstComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dotxtAddress = new ExchangeCompanySoftware.cstTextBox();
            this.dotxtFax = new ExchangeCompanySoftware.cstTextBox();
            this.dotxtPhone = new ExchangeCompanySoftware.cstTextBox();
            this.ditxtNAME = new ExchangeCompanySoftware.cstTextBox();
            this.ditxtCode = new ExchangeCompanySoftware.cstTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.Transparent;
            this.PnlMain.Controls.Add(this.docboAccount);
            this.PnlMain.Controls.Add(this.label7);
            this.PnlMain.Controls.Add(this.label16);
            this.PnlMain.Controls.Add(this.dtDate);
            this.PnlMain.Controls.Add(this.docboBranch);
            this.PnlMain.Controls.Add(this.lblBranch);
            this.PnlMain.Controls.Add(this.dochkBranch);
            this.PnlMain.Controls.Add(this.dicboCustomerType);
            this.PnlMain.Controls.Add(this.label6);
            this.PnlMain.Controls.Add(this.dotxtAddress);
            this.PnlMain.Controls.Add(this.dotxtFax);
            this.PnlMain.Controls.Add(this.dotxtPhone);
            this.PnlMain.Controls.Add(this.ditxtNAME);
            this.PnlMain.Controls.Add(this.ditxtCode);
            this.PnlMain.Controls.Add(this.label5);
            this.PnlMain.Controls.Add(this.label4);
            this.PnlMain.Controls.Add(this.label3);
            this.PnlMain.Controls.Add(this.label2);
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Location = new System.Drawing.Point(1, 1);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(423, 201);
            this.PnlMain.TabIndex = 701;
            this.PnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlMain_Paint);
            // 
            // docboAccount
            // 
            this.docboAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.docboAccount.DataField = null;
            this.docboAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.docboAccount.FormattingEnabled = true;
            this.docboAccount.Location = new System.Drawing.Point(156, 174);
            this.docboAccount.Name = "docboAccount";
            this.docboAccount.Size = new System.Drawing.Size(230, 21);
            this.docboAccount.TabIndex = 821;
            this.docboAccount.Tag = "AccountNo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(103, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 822;
            this.label7.Text = "Account";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(217, 16);
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
            this.dtDate.Location = new System.Drawing.Point(283, 13);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(97, 20);
            this.dtDate.TabIndex = 819;
            this.dtDate.Tag = "TransDate";
            // 
            // docboBranch
            // 
            this.docboBranch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.docboBranch.DataField = null;
            this.docboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.docboBranch.FormattingEnabled = true;
            this.docboBranch.Location = new System.Drawing.Point(156, 150);
            this.docboBranch.Name = "docboBranch";
            this.docboBranch.Size = new System.Drawing.Size(230, 21);
            this.docboBranch.TabIndex = 6;
            this.docboBranch.Tag = "BranchCodeTag";
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(103, 155);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(41, 13);
            this.lblBranch.TabIndex = 724;
            this.lblBranch.Text = "Branch";
            // 
            // dochkBranch
            // 
            this.dochkBranch.AutoSize = true;
            this.dochkBranch.DataField = null;
            this.dochkBranch.Location = new System.Drawing.Point(24, 154);
            this.dochkBranch.Name = "dochkBranch";
            this.dochkBranch.Size = new System.Drawing.Size(67, 17);
            this.dochkBranch.TabIndex = 5;
            this.dochkBranch.Tag = "isBranch";
            this.dochkBranch.Text = "isBranch";
            this.dochkBranch.UseVisualStyleBackColor = true;
            this.dochkBranch.CheckedChanged += new System.EventHandler(this.cstBranch_CheckedChanged);
            // 
            // dicboCustomerType
            // 
            this.dicboCustomerType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.dicboCustomerType.DataField = null;
            this.dicboCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicboCustomerType.FormattingEnabled = true;
            this.dicboCustomerType.Location = new System.Drawing.Point(106, 57);
            this.dicboCustomerType.Name = "dicboCustomerType";
            this.dicboCustomerType.Size = new System.Drawing.Size(274, 21);
            this.dicboCustomerType.TabIndex = 1;
            this.dicboCustomerType.Tag = "CustomerType";
            this.dicboCustomerType.Validated += new System.EventHandler(this.dicboCustomerType_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 721;
            this.label6.Text = "Customer Type";
            // 
            // dotxtAddress
            // 
            this.dotxtAddress.BackColor = System.Drawing.Color.White;
            this.dotxtAddress.DataField = null;
            this.dotxtAddress.Location = new System.Drawing.Point(106, 124);
            this.dotxtAddress.Name = "dotxtAddress";
            this.dotxtAddress.Size = new System.Drawing.Size(274, 20);
            this.dotxtAddress.TabIndex = 4;
            this.dotxtAddress.Tag = "Address";
            // 
            // dotxtFax
            // 
            this.dotxtFax.BackColor = System.Drawing.Color.White;
            this.dotxtFax.DataField = null;
            this.dotxtFax.Location = new System.Drawing.Point(106, 102);
            this.dotxtFax.Name = "dotxtFax";
            this.dotxtFax.Size = new System.Drawing.Size(113, 20);
            this.dotxtFax.TabIndex = 3;
            this.dotxtFax.Tag = "Fax";
            // 
            // dotxtPhone
            // 
            this.dotxtPhone.BackColor = System.Drawing.Color.White;
            this.dotxtPhone.DataField = null;
            this.dotxtPhone.Location = new System.Drawing.Point(106, 80);
            this.dotxtPhone.Name = "dotxtPhone";
            this.dotxtPhone.Size = new System.Drawing.Size(113, 20);
            this.dotxtPhone.TabIndex = 2;
            this.dotxtPhone.Tag = "Phone";
            // 
            // ditxtNAME
            // 
            this.ditxtNAME.BackColor = System.Drawing.Color.White;
            this.ditxtNAME.DataField = null;
            this.ditxtNAME.Location = new System.Drawing.Point(106, 35);
            this.ditxtNAME.Name = "ditxtNAME";
            this.ditxtNAME.Size = new System.Drawing.Size(274, 20);
            this.ditxtNAME.TabIndex = 0;
            this.ditxtNAME.Tag = "CustName";
            // 
            // ditxtCode
            // 
            this.ditxtCode.BackColor = System.Drawing.Color.White;
            this.ditxtCode.DataField = null;
            this.ditxtCode.Location = new System.Drawing.Point(106, 13);
            this.ditxtCode.Name = "ditxtCode";
            this.ditxtCode.Size = new System.Drawing.Size(100, 20);
            this.ditxtCode.TabIndex = 716;
            this.ditxtCode.Tag = "CustCode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 715;
            this.label5.Text = "Fax";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 714;
            this.label4.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 713;
            this.label3.Text = "Phone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 712;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 711;
            this.label1.Text = "Code";
            // 
            // frmCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 418);
            this.Controls.Add(this.PnlMain);
            this.Name = "frmCustomers";
            this.Text = "frmCustomers";
            this.Load += new System.EventHandler(this.frmCustomers_Load);
            this.Activated += new System.EventHandler(this.frmCustomers_Activated);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.PnlMain, 0);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private cstTextBox dotxtAddress;
        private cstTextBox dotxtFax;
        private cstTextBox dotxtPhone;
        private cstTextBox ditxtNAME;
        private cstTextBox ditxtCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private cstComboBox dicboCustomerType;
        private ExchangeCompanySoftware.Custom_Controls.cstCheckBox dochkBranch;
        private cstComboBox docboBranch;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Label label16;
        public ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtDate;
        private cstComboBox docboAccount;
        private System.Windows.Forms.Label label7;

    }
}