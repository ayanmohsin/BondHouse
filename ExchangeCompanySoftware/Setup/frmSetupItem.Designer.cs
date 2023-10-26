namespace ExchangeCompanySoftware
{
    partial class frmSetupItem
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
            this.label16 = new System.Windows.Forms.Label();
            this.dtDate = new ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker();
            this.dochkisMain = new ExchangeCompanySoftware.Custom_Controls.cstCheckBox();
            this.dochkLocked = new ExchangeCompanySoftware.Custom_Controls.cstCheckBox();
            this.donumOpeningBalance = new ExchangeCompanySoftware.cstNumericupDown();
            this.donumMaximumRate = new ExchangeCompanySoftware.cstNumericupDown();
            this.donumMinimumRate = new ExchangeCompanySoftware.cstNumericupDown();
            this.ditxtItemName = new ExchangeCompanySoftware.cstTextBox();
            this.ditxtShortName = new ExchangeCompanySoftware.cstTextBox();
            this.ditxtItemCode = new ExchangeCompanySoftware.cstTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.donumUnit = new ExchangeCompanySoftware.cstTextBox();
            this.PnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donumOpeningBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumMaximumRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumMinimumRate)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.Transparent;
            this.PnlMain.Controls.Add(this.donumUnit);
            this.PnlMain.Controls.Add(this.label16);
            this.PnlMain.Controls.Add(this.dtDate);
            this.PnlMain.Controls.Add(this.dochkisMain);
            this.PnlMain.Controls.Add(this.dochkLocked);
            this.PnlMain.Controls.Add(this.donumOpeningBalance);
            this.PnlMain.Controls.Add(this.donumMaximumRate);
            this.PnlMain.Controls.Add(this.donumMinimumRate);
            this.PnlMain.Controls.Add(this.ditxtItemName);
            this.PnlMain.Controls.Add(this.ditxtShortName);
            this.PnlMain.Controls.Add(this.ditxtItemCode);
            this.PnlMain.Controls.Add(this.label6);
            this.PnlMain.Controls.Add(this.label5);
            this.PnlMain.Controls.Add(this.label4);
            this.PnlMain.Controls.Add(this.label3);
            this.PnlMain.Controls.Add(this.label2);
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Location = new System.Drawing.Point(1, -1);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(547, 97);
            this.PnlMain.TabIndex = 32;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(276, 6);
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
            this.dtDate.Location = new System.Drawing.Point(342, 3);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(103, 20);
            this.dtDate.TabIndex = 819;
            this.dtDate.Tag = "TransDate";
            // 
            // dochkisMain
            // 
            this.dochkisMain.AutoSize = true;
            this.dochkisMain.DataField = null;
            this.dochkisMain.Location = new System.Drawing.Point(474, 31);
            this.dochkisMain.Name = "dochkisMain";
            this.dochkisMain.Size = new System.Drawing.Size(49, 17);
            this.dochkisMain.TabIndex = 6;
            this.dochkisMain.Tag = "isMain";
            this.dochkisMain.Text = "Main";
            this.dochkisMain.UseVisualStyleBackColor = true;
            // 
            // dochkLocked
            // 
            this.dochkLocked.AutoSize = true;
            this.dochkLocked.DataField = null;
            this.dochkLocked.Location = new System.Drawing.Point(474, 8);
            this.dochkLocked.Name = "dochkLocked";
            this.dochkLocked.Size = new System.Drawing.Size(62, 17);
            this.dochkLocked.TabIndex = 5;
            this.dochkLocked.Tag = "Locked";
            this.dochkLocked.Text = "Locked";
            this.dochkLocked.UseVisualStyleBackColor = true;
            // 
            // donumOpeningBalance
            // 
            this.donumOpeningBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.donumOpeningBalance.DataField = null;
            this.donumOpeningBalance.DecimalPlaces = 4;
            this.donumOpeningBalance.Location = new System.Drawing.Point(109, 166);
            this.donumOpeningBalance.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.donumOpeningBalance.Name = "donumOpeningBalance";
            this.donumOpeningBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.donumOpeningBalance.Size = new System.Drawing.Size(100, 20);
            this.donumOpeningBalance.TabIndex = 4;
            this.donumOpeningBalance.Tag = "OpeningBalance";
            this.donumOpeningBalance.Visible = false;
            // 
            // donumMaximumRate
            // 
            this.donumMaximumRate.BackColor = System.Drawing.Color.White;
            this.donumMaximumRate.DataField = null;
            this.donumMaximumRate.DecimalPlaces = 4;
            this.donumMaximumRate.Location = new System.Drawing.Point(359, 64);
            this.donumMaximumRate.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.donumMaximumRate.Name = "donumMaximumRate";
            this.donumMaximumRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.donumMaximumRate.Size = new System.Drawing.Size(86, 20);
            this.donumMaximumRate.TabIndex = 3;
            this.donumMaximumRate.Tag = "MaximumRate";
            // 
            // donumMinimumRate
            // 
            this.donumMinimumRate.BackColor = System.Drawing.Color.White;
            this.donumMinimumRate.DataField = null;
            this.donumMinimumRate.DecimalPlaces = 4;
            this.donumMinimumRate.Location = new System.Drawing.Point(231, 66);
            this.donumMinimumRate.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.donumMinimumRate.Name = "donumMinimumRate";
            this.donumMinimumRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.donumMinimumRate.Size = new System.Drawing.Size(75, 20);
            this.donumMinimumRate.TabIndex = 2;
            this.donumMinimumRate.Tag = "MinimumRate";
            // 
            // ditxtItemName
            // 
            this.ditxtItemName.BackColor = System.Drawing.Color.White;
            this.ditxtItemName.DataField = null;
            this.ditxtItemName.Location = new System.Drawing.Point(109, 38);
            this.ditxtItemName.Name = "ditxtItemName";
            this.ditxtItemName.Size = new System.Drawing.Size(336, 20);
            this.ditxtItemName.TabIndex = 0;
            this.ditxtItemName.Tag = "ItemName";
            // 
            // ditxtShortName
            // 
            this.ditxtShortName.BackColor = System.Drawing.Color.White;
            this.ditxtShortName.DataField = null;
            this.ditxtShortName.Location = new System.Drawing.Point(109, 66);
            this.ditxtShortName.Name = "ditxtShortName";
            this.ditxtShortName.Size = new System.Drawing.Size(60, 20);
            this.ditxtShortName.TabIndex = 1;
            this.ditxtShortName.Tag = "ShortName";
            // 
            // ditxtItemCode
            // 
            this.ditxtItemCode.BackColor = System.Drawing.Color.White;
            this.ditxtItemCode.DataField = null;
            this.ditxtItemCode.Location = new System.Drawing.Point(109, 8);
            this.ditxtItemCode.Name = "ditxtItemCode";
            this.ditxtItemCode.Size = new System.Drawing.Size(100, 20);
            this.ditxtItemCode.TabIndex = 7;
            this.ditxtItemCode.Tag = "ItemCode";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Opening Balance";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(309, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Max Rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Min Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Item Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Short Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Code";
            // 
            // donumUnit
            // 
            this.donumUnit.BackColor = System.Drawing.Color.White;
            this.donumUnit.DataField = null;
            this.donumUnit.Location = new System.Drawing.Point(451, 63);
            this.donumUnit.Name = "donumUnit";
            this.donumUnit.Size = new System.Drawing.Size(60, 20);
            this.donumUnit.TabIndex = 821;
            this.donumUnit.Tag = "Unit";
            // 
            // frmSetupItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 316);
            this.Controls.Add(this.PnlMain);
            this.Name = "frmSetupItem";
            this.Text = "s";
            this.Load += new System.EventHandler(this.frmSetupItem_Load);
            this.Activated += new System.EventHandler(this.frmSetupItem_Activated);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.PnlMain, 0);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donumOpeningBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumMaximumRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donumMinimumRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private cstTextBox ditxtItemName;
        private cstTextBox ditxtShortName;
        private cstTextBox ditxtItemCode;
        private cstNumericupDown donumOpeningBalance;
        private cstNumericupDown donumMaximumRate;
        private cstNumericupDown donumMinimumRate;
        private ExchangeCompanySoftware.Custom_Controls.cstCheckBox dochkLocked;
        private ExchangeCompanySoftware.Custom_Controls.cstCheckBox dochkisMain;
        private System.Windows.Forms.Label label16;
        public ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtDate;
        private cstTextBox donumUnit;
    }
}