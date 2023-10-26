namespace ExchangeCompanySoftware
{
    partial class frmSetupSettelment
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
            this.dicboPartyType = new ExchangeCompanySoftware.cstComboBox();
            this.diCboLocation = new ExchangeCompanySoftware.cstComboBox();
            this.dotxtRemarks = new ExchangeCompanySoftware.cstTextBox();
            this.ditxtShortName = new ExchangeCompanySoftware.cstTextBox();
            this.ditxtName = new ExchangeCompanySoftware.cstTextBox();
            this.ditxtSettelmentCode = new ExchangeCompanySoftware.cstTextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.PnlMain.Controls.Add(this.label16);
            this.PnlMain.Controls.Add(this.dtDate);
            this.PnlMain.Controls.Add(this.dicboPartyType);
            this.PnlMain.Controls.Add(this.diCboLocation);
            this.PnlMain.Controls.Add(this.dotxtRemarks);
            this.PnlMain.Controls.Add(this.ditxtShortName);
            this.PnlMain.Controls.Add(this.ditxtName);
            this.PnlMain.Controls.Add(this.ditxtSettelmentCode);
            this.PnlMain.Controls.Add(this.label6);
            this.PnlMain.Controls.Add(this.label5);
            this.PnlMain.Controls.Add(this.label4);
            this.PnlMain.Controls.Add(this.label3);
            this.PnlMain.Controls.Add(this.label2);
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Location = new System.Drawing.Point(23, 26);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(652, 152);
            this.PnlMain.TabIndex = 702;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(255, 17);
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
            this.dtDate.Location = new System.Drawing.Point(344, 13);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(121, 20);
            this.dtDate.TabIndex = 819;
            this.dtDate.Tag = "TransDate";
            // 
            // dicboPartyType
            // 
            this.dicboPartyType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.dicboPartyType.DataField = null;
            this.dicboPartyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicboPartyType.FormattingEnabled = true;
            this.dicboPartyType.Location = new System.Drawing.Point(344, 73);
            this.dicboPartyType.Name = "dicboPartyType";
            this.dicboPartyType.Size = new System.Drawing.Size(121, 21);
            this.dicboPartyType.TabIndex = 11;
            // 
            // diCboLocation
            // 
            this.diCboLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.diCboLocation.DataField = null;
            this.diCboLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.diCboLocation.FormattingEnabled = true;
            this.diCboLocation.Location = new System.Drawing.Point(123, 76);
            this.diCboLocation.Name = "diCboLocation";
            this.diCboLocation.Size = new System.Drawing.Size(121, 21);
            this.diCboLocation.TabIndex = 10;
            // 
            // dotxtRemarks
            // 
            this.dotxtRemarks.BackColor = System.Drawing.Color.White;
            this.dotxtRemarks.DataField = null;
            this.dotxtRemarks.Location = new System.Drawing.Point(123, 106);
            this.dotxtRemarks.Name = "dotxtRemarks";
            this.dotxtRemarks.Size = new System.Drawing.Size(342, 20);
            this.dotxtRemarks.TabIndex = 9;
            // 
            // ditxtShortName
            // 
            this.ditxtShortName.BackColor = System.Drawing.Color.White;
            this.ditxtShortName.DataField = null;
            this.ditxtShortName.Location = new System.Drawing.Point(344, 42);
            this.ditxtShortName.Name = "ditxtShortName";
            this.ditxtShortName.Size = new System.Drawing.Size(121, 20);
            this.ditxtShortName.TabIndex = 8;
            // 
            // ditxtName
            // 
            this.ditxtName.BackColor = System.Drawing.Color.White;
            this.ditxtName.DataField = null;
            this.ditxtName.Location = new System.Drawing.Point(123, 46);
            this.ditxtName.Name = "ditxtName";
            this.ditxtName.Size = new System.Drawing.Size(121, 20);
            this.ditxtName.TabIndex = 7;
            // 
            // ditxtSettelmentCode
            // 
            this.ditxtSettelmentCode.BackColor = System.Drawing.Color.White;
            this.ditxtSettelmentCode.DataField = null;
            this.ditxtSettelmentCode.Location = new System.Drawing.Point(123, 20);
            this.ditxtSettelmentCode.Name = "ditxtSettelmentCode";
            this.ditxtSettelmentCode.Size = new System.Drawing.Size(121, 20);
            this.ditxtSettelmentCode.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Remarks :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Party Type :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Location :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Short Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code :";
            // 
            // frmSetupSettelment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 513);
            this.Controls.Add(this.PnlMain);
            this.Name = "frmSetupSettelment";
            this.Text = "frmSetupSettelment";
            this.Load += new System.EventHandler(this.frmSetupSettelment_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.PnlMain, 0);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private cstTextBox ditxtSettelmentCode;
        private cstComboBox dicboPartyType;
        private cstComboBox diCboLocation;
        private cstTextBox dotxtRemarks;
        private cstTextBox ditxtShortName;
        private cstTextBox ditxtName;
        private System.Windows.Forms.Label label16;
        public ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtDate;
    }
}