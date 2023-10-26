namespace ExchangeCompanySoftware
{
    partial class frmTCSetup
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
            this.dicboDenomination = new ExchangeCompanySoftware.cstComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dicboCurrency = new ExchangeCompanySoftware.cstComboBox();
            this.dicboParty = new ExchangeCompanySoftware.cstComboBox();
            this.ditxtDescription = new ExchangeCompanySoftware.cstTextBox();
            this.ditxtTCSymbol = new ExchangeCompanySoftware.cstTextBox();
            this.ditxtTCCode = new ExchangeCompanySoftware.cstTextBox();
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
            this.PnlMain.Controls.Add(this.dicboDenomination);
            this.PnlMain.Controls.Add(this.label6);
            this.PnlMain.Controls.Add(this.dicboCurrency);
            this.PnlMain.Controls.Add(this.dicboParty);
            this.PnlMain.Controls.Add(this.ditxtDescription);
            this.PnlMain.Controls.Add(this.ditxtTCSymbol);
            this.PnlMain.Controls.Add(this.ditxtTCCode);
            this.PnlMain.Controls.Add(this.label5);
            this.PnlMain.Controls.Add(this.label4);
            this.PnlMain.Controls.Add(this.label3);
            this.PnlMain.Controls.Add(this.label2);
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Location = new System.Drawing.Point(1, 48);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(543, 184);
            this.PnlMain.TabIndex = 0;
            this.PnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlMain_Paint);
            // 
            // dicboDenomination
            // 
            this.dicboDenomination.DataField = null;
            this.dicboDenomination.FormattingEnabled = true;
            this.dicboDenomination.Location = new System.Drawing.Point(106, 158);
            this.dicboDenomination.Name = "dicboDenomination";
            this.dicboDenomination.Size = new System.Drawing.Size(100, 21);
            this.dicboDenomination.TabIndex = 16;
            this.dicboDenomination.Tag = "Denomination";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Denomination";
            // 
            // dicboCurrency
            // 
            this.dicboCurrency.DataField = null;
            this.dicboCurrency.FormattingEnabled = true;
            this.dicboCurrency.Location = new System.Drawing.Point(106, 131);
            this.dicboCurrency.Name = "dicboCurrency";
            this.dicboCurrency.Size = new System.Drawing.Size(100, 21);
            this.dicboCurrency.TabIndex = 14;
            this.dicboCurrency.Tag = "ItemCode";
            // 
            // dicboParty
            // 
            this.dicboParty.DataField = null;
            this.dicboParty.FormattingEnabled = true;
            this.dicboParty.Location = new System.Drawing.Point(106, 104);
            this.dicboParty.Name = "dicboParty";
            this.dicboParty.Size = new System.Drawing.Size(218, 21);
            this.dicboParty.TabIndex = 13;
            this.dicboParty.Tag = "PartyCode";
            // 
            // ditxtDescription
            // 
            this.ditxtDescription.DataField = null;
            this.ditxtDescription.Location = new System.Drawing.Point(106, 75);
            this.ditxtDescription.Name = "ditxtDescription";
            this.ditxtDescription.Size = new System.Drawing.Size(218, 20);
            this.ditxtDescription.TabIndex = 12;
            this.ditxtDescription.Tag = "TCDescription";
            // 
            // ditxtTCSymbol
            // 
            this.ditxtTCSymbol.DataField = null;
            this.ditxtTCSymbol.Location = new System.Drawing.Point(106, 43);
            this.ditxtTCSymbol.Name = "ditxtTCSymbol";
            this.ditxtTCSymbol.Size = new System.Drawing.Size(100, 20);
            this.ditxtTCSymbol.TabIndex = 11;
            this.ditxtTCSymbol.Tag = "TCSymbol";
            // 
            // ditxtTCCode
            // 
            this.ditxtTCCode.DataField = null;
            this.ditxtTCCode.Location = new System.Drawing.Point(106, 11);
            this.ditxtTCCode.Name = "ditxtTCCode";
            this.ditxtTCCode.Size = new System.Drawing.Size(100, 20);
            this.ditxtTCCode.TabIndex = 10;
            this.ditxtTCCode.Tag = "TCCode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "TC Symbol";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Party";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Currency";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "TC Code";
            // 
            // frmTCSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 451);
            this.Controls.Add(this.PnlMain);
            this.Name = "frmTCSetup";
            this.Text = "frmTCSetup";
            this.Load += new System.EventHandler(this.frmTCSetup_Load);
            this.Controls.SetChildIndex(this.PnlMain, 0);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private cstTextBox ditxtDescription;
        private cstTextBox ditxtTCSymbol;
        private cstTextBox ditxtTCCode;
        private cstComboBox dicboParty;
        private cstComboBox dicboCurrency;
        private cstComboBox dicboDenomination;
        private System.Windows.Forms.Label label6;

    }
}