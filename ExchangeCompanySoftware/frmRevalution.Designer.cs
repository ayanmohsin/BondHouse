namespace ExchangeCompanySoftware
{
    partial class frmRevalution
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
            this.label16 = new System.Windows.Forms.Label();
            this.dtDate = new ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker();
            this.ditxtTransNo = new ExchangeCompanySoftware.cstTextBox();
            this.dotxtRemarks = new ExchangeCompanySoftware.cstTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain7 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.label36 = new System.Windows.Forms.Label();
            this.pnlMain1 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.label21 = new System.Windows.Forms.Label();
            this.pnlMain2 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalPL = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).BeginInit();
            this.PnlMain.SuspendLayout();
            this.pnlMain7.SuspendLayout();
            this.pnlMain1.SuspendLayout();
            this.pnlMain2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtbDetail
            // 
            this.dtbDetail.AllowUserToAddRows = false;
            this.dtbDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtbDetail.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(202)))), ((int)(((byte)(233)))));
            this.dtbDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbDetail.Location = new System.Drawing.Point(3, 125);
            this.dtbDetail.Name = "dtbDetail";
            this.dtbDetail.Size = new System.Drawing.Size(618, 250);
            this.dtbDetail.TabIndex = 703;
            this.dtbDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtbDetail_CellEndEdit);
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.Transparent;
            this.PnlMain.Controls.Add(this.label16);
            this.PnlMain.Controls.Add(this.dtDate);
            this.PnlMain.Controls.Add(this.ditxtTransNo);
            this.PnlMain.Controls.Add(this.dotxtRemarks);
            this.PnlMain.Controls.Add(this.label2);
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Location = new System.Drawing.Point(0, 20);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(621, 69);
            this.PnlMain.TabIndex = 704;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(199, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 873;
            this.label16.Text = "Trans Date";
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd/MMM/yyyy";
            this.dtDate.DataField = null;
            this.dtDate.Enabled = false;
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(269, 10);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(97, 20);
            this.dtDate.TabIndex = 872;
            this.dtDate.Tag = "TransDate";
            // 
            // ditxtTransNo
            // 
            this.ditxtTransNo.BackColor = System.Drawing.Color.White;
            this.ditxtTransNo.DataField = null;
            this.ditxtTransNo.Location = new System.Drawing.Point(74, 11);
            this.ditxtTransNo.Name = "ditxtTransNo";
            this.ditxtTransNo.Size = new System.Drawing.Size(117, 20);
            this.ditxtTransNo.TabIndex = 3;
            this.ditxtTransNo.Tag = "TransNo";
            // 
            // dotxtRemarks
            // 
            this.dotxtRemarks.BackColor = System.Drawing.Color.White;
            this.dotxtRemarks.DataField = null;
            this.dotxtRemarks.Location = new System.Drawing.Point(74, 37);
            this.dotxtRemarks.Name = "dotxtRemarks";
            this.dotxtRemarks.Size = new System.Drawing.Size(535, 20);
            this.dotxtRemarks.TabIndex = 2;
            this.dotxtRemarks.Tag = "Remarks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Remarks :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trans No :";
            // 
            // pnlMain7
            // 
            this.pnlMain7.BeginColor = System.Drawing.Color.Maroon;
            this.pnlMain7.Controls.Add(this.label36);
            this.pnlMain7.EndColor = System.Drawing.Color.Red;
            this.pnlMain7.Location = new System.Drawing.Point(3, 106);
            this.pnlMain7.Name = "pnlMain7";
            this.pnlMain7.Size = new System.Drawing.Size(618, 18);
            this.pnlMain7.TabIndex = 813;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
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
            this.pnlMain1.BeginColor = System.Drawing.Color.Navy;
            this.pnlMain1.Controls.Add(this.label21);
            this.pnlMain1.EndColor = System.Drawing.Color.LightSteelBlue;
            this.pnlMain1.Location = new System.Drawing.Point(1, -1);
            this.pnlMain1.Name = "pnlMain1";
            this.pnlMain1.Size = new System.Drawing.Size(620, 21);
            this.pnlMain1.TabIndex = 812;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label21.Location = new System.Drawing.Point(5, 2);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(112, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Master Information";
            // 
            // pnlMain2
            // 
            this.pnlMain2.BeginColor = System.Drawing.Color.Orange;
            this.pnlMain2.Controls.Add(this.lblTotalAmount);
            this.pnlMain2.Controls.Add(this.lblTotalPL);
            this.pnlMain2.Controls.Add(this.label5);
            this.pnlMain2.Controls.Add(this.label4);
            this.pnlMain2.EndColor = System.Drawing.Color.NavajoWhite;
            this.pnlMain2.Location = new System.Drawing.Point(406, 375);
            this.pnlMain2.Name = "pnlMain2";
            this.pnlMain2.Size = new System.Drawing.Size(215, 46);
            this.pnlMain2.TabIndex = 814;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(131, 23);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(17, 18);
            this.lblTotalAmount.TabIndex = 713;
            this.lblTotalAmount.Text = "0";
            // 
            // lblTotalPL
            // 
            this.lblTotalPL.AutoSize = true;
            this.lblTotalPL.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPL.Location = new System.Drawing.Point(131, 3);
            this.lblTotalPL.Name = "lblTotalPL";
            this.lblTotalPL.Size = new System.Drawing.Size(17, 18);
            this.lblTotalPL.TabIndex = 712;
            this.lblTotalPL.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 18);
            this.label5.TabIndex = 711;
            this.label5.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 18);
            this.label4.TabIndex = 710;
            this.label4.Text = "Profit";
            // 
            // frmRevalution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 644);
            this.Controls.Add(this.pnlMain7);
            this.Controls.Add(this.pnlMain1);
            this.Controls.Add(this.PnlMain);
            this.Controls.Add(this.dtbDetail);
            this.Controls.Add(this.pnlMain2);
            this.Name = "frmRevalution";
            this.Text = "frmRevalution";
            this.Load += new System.EventHandler(this.frmRevalution_Load);
            this.Activated += new System.EventHandler(this.frmRevalution_Activated);
            this.Controls.SetChildIndex(this.pnlMain2, 0);
            this.Controls.SetChildIndex(this.dtbDetail, 0);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.PnlMain, 0);
            this.Controls.SetChildIndex(this.pnlMain1, 0);
            this.Controls.SetChildIndex(this.pnlMain7, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).EndInit();
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.pnlMain7.ResumeLayout(false);
            this.pnlMain7.PerformLayout();
            this.pnlMain1.ResumeLayout(false);
            this.pnlMain1.PerformLayout();
            this.pnlMain2.ResumeLayout(false);
            this.pnlMain2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtbDetail;
        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private cstTextBox ditxtTransNo;
        private cstTextBox dotxtRemarks;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain7;
        private System.Windows.Forms.Label label36;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain1;
        private System.Windows.Forms.Label label21;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain2;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalPL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label16;
        public ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtDate;
    }
}