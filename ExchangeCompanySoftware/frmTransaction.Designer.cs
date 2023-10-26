namespace ExchangeCompanySoftware
{
    partial class frmTransaction
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlMain = new System.Windows.Forms.Panel();
            this.lblCrime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dotxtRemarks = new ExchangeCompanySoftware.cstTextBox();
            this.cmdCompleteSale = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.dicbopaymentMode = new ExchangeCompanySoftware.cstComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dtDate = new ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker();
            this.dotxtAddress = new ExchangeCompanySoftware.cstTextBox();
            this.dotxtTokenNo = new ExchangeCompanySoftware.cstTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.docboCustName = new ExchangeCompanySoftware.cstComboBox();
            this.ditxtVoucherNo = new ExchangeCompanySoftware.cstTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dotxtCustomerName = new ExchangeCompanySoftware.cstTextBox();
            this.dicboCustomerType = new ExchangeCompanySoftware.cstComboBox();
            this.dicboTransaction = new ExchangeCompanySoftware.cstComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dotxtCnicNo = new ExchangeCompanySoftware.cstTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblusdAmount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.dtbDetail = new System.Windows.Forms.DataGridView();
            this.PnlMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.BackColor = System.Drawing.Color.Transparent;
            this.PnlMain.Controls.Add(this.lblCrime);
            this.PnlMain.Controls.Add(this.label7);
            this.PnlMain.Controls.Add(this.dotxtRemarks);
            this.PnlMain.Controls.Add(this.cmdCompleteSale);
            this.PnlMain.Controls.Add(this.label17);
            this.PnlMain.Controls.Add(this.dicbopaymentMode);
            this.PnlMain.Controls.Add(this.label16);
            this.PnlMain.Controls.Add(this.dtDate);
            this.PnlMain.Controls.Add(this.dotxtAddress);
            this.PnlMain.Controls.Add(this.dotxtTokenNo);
            this.PnlMain.Controls.Add(this.label13);
            this.PnlMain.Controls.Add(this.docboCustName);
            this.PnlMain.Controls.Add(this.ditxtVoucherNo);
            this.PnlMain.Controls.Add(this.label12);
            this.PnlMain.Controls.Add(this.dotxtCustomerName);
            this.PnlMain.Controls.Add(this.dicboCustomerType);
            this.PnlMain.Controls.Add(this.dicboTransaction);
            this.PnlMain.Controls.Add(this.label6);
            this.PnlMain.Controls.Add(this.label5);
            this.PnlMain.Controls.Add(this.label4);
            this.PnlMain.Controls.Add(this.label3);
            this.PnlMain.Controls.Add(this.label2);
            this.PnlMain.Controls.Add(this.label1);
            this.PnlMain.Controls.Add(this.dotxtCnicNo);
            this.PnlMain.Location = new System.Drawing.Point(12, 3);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(852, 161);
            this.PnlMain.TabIndex = 100;
            // 
            // lblCrime
            // 
            this.lblCrime.AutoSize = true;
            this.lblCrime.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrime.ForeColor = System.Drawing.Color.Red;
            this.lblCrime.Location = new System.Drawing.Point(760, 171);
            this.lblCrime.Name = "lblCrime";
            this.lblCrime.Size = new System.Drawing.Size(71, 16);
            this.lblCrime.TabIndex = 821;
            this.lblCrime.Text = "Crime List";
            this.lblCrime.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(791, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 820;
            this.label7.Text = "Remarks";
            this.label7.Visible = false;
            // 
            // dotxtRemarks
            // 
            this.dotxtRemarks.BackColor = System.Drawing.Color.Snow;
            this.dotxtRemarks.DataField = null;
            this.dotxtRemarks.Location = new System.Drawing.Point(829, 125);
            this.dotxtRemarks.Name = "dotxtRemarks";
            this.dotxtRemarks.Size = new System.Drawing.Size(11, 20);
            this.dotxtRemarks.TabIndex = 5;
            this.dotxtRemarks.Tag = "Remarks";
            this.dotxtRemarks.Visible = false;
            // 
            // cmdCompleteSale
            // 
            this.cmdCompleteSale.Location = new System.Drawing.Point(730, 97);
            this.cmdCompleteSale.Name = "cmdCompleteSale";
            this.cmdCompleteSale.Size = new System.Drawing.Size(115, 23);
            this.cmdCompleteSale.TabIndex = 60;
            this.cmdCompleteSale.Text = "Complete Sale";
            this.cmdCompleteSale.UseVisualStyleBackColor = true;
            this.cmdCompleteSale.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 117);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 13);
            this.label17.TabIndex = 818;
            this.label17.Text = "Account";
            // 
            // dicbopaymentMode
            // 
            this.dicbopaymentMode.BackColor = System.Drawing.Color.Snow;
            this.dicbopaymentMode.DataField = "TransType";
            this.dicbopaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicbopaymentMode.FormattingEnabled = true;
            this.dicbopaymentMode.Location = new System.Drawing.Point(117, 109);
            this.dicbopaymentMode.Name = "dicbopaymentMode";
            this.dicbopaymentMode.Size = new System.Drawing.Size(207, 21);
            this.dicbopaymentMode.TabIndex = 817;
            this.dicbopaymentMode.Tag = "PaymentMode";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 816;
            this.label16.Text = "Trans Date";
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd/MMM/yyyy";
            this.dtDate.DataField = null;
            this.dtDate.Enabled = false;
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(117, 29);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(106, 20);
            this.dtDate.TabIndex = 815;
            this.dtDate.Tag = "TransDate";
            // 
            // dotxtAddress
            // 
            this.dotxtAddress.BackColor = System.Drawing.Color.Snow;
            this.dotxtAddress.DataField = null;
            this.dotxtAddress.Location = new System.Drawing.Point(778, 163);
            this.dotxtAddress.Name = "dotxtAddress";
            this.dotxtAddress.Size = new System.Drawing.Size(39, 20);
            this.dotxtAddress.TabIndex = 3;
            this.dotxtAddress.Tag = "Address";
            this.dotxtAddress.Visible = false;
            // 
            // dotxtTokenNo
            // 
            this.dotxtTokenNo.BackColor = System.Drawing.Color.Snow;
            this.dotxtTokenNo.DataField = "VoucherNo";
            this.dotxtTokenNo.Enabled = false;
            this.dotxtTokenNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dotxtTokenNo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.dotxtTokenNo.Location = new System.Drawing.Point(769, 167);
            this.dotxtTokenNo.Name = "dotxtTokenNo";
            this.dotxtTokenNo.Size = new System.Drawing.Size(80, 49);
            this.dotxtTokenNo.TabIndex = 58;
            this.dotxtTokenNo.Tag = "TokenNo";
            this.dotxtTokenNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dotxtTokenNo.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(787, 151);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 59;
            this.label13.Text = "Token";
            this.label13.Visible = false;
            // 
            // docboCustName
            // 
            this.docboCustName.BackColor = System.Drawing.Color.Snow;
            this.docboCustName.DataField = "CustomerType";
            this.docboCustName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.docboCustName.FormattingEnabled = true;
            this.docboCustName.Location = new System.Drawing.Point(635, 232);
            this.docboCustName.Name = "docboCustName";
            this.docboCustName.Size = new System.Drawing.Size(205, 21);
            this.docboCustName.TabIndex = 54;
            this.docboCustName.Tag = "";
            // 
            // ditxtVoucherNo
            // 
            this.ditxtVoucherNo.BackColor = System.Drawing.Color.Snow;
            this.ditxtVoucherNo.DataField = "VoucherNo";
            this.ditxtVoucherNo.Enabled = false;
            this.ditxtVoucherNo.Location = new System.Drawing.Point(116, 55);
            this.ditxtVoucherNo.Name = "ditxtVoucherNo";
            this.ditxtVoucherNo.Size = new System.Drawing.Size(100, 20);
            this.ditxtVoucherNo.TabIndex = 0;
            this.ditxtVoucherNo.Tag = "VoucherNo";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "Trans No";
            // 
            // dotxtCustomerName
            // 
            this.dotxtCustomerName.BackColor = System.Drawing.Color.Snow;
            this.dotxtCustomerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dotxtCustomerName.DataField = "CustomerName";
            this.dotxtCustomerName.Location = new System.Drawing.Point(117, 83);
            this.dotxtCustomerName.Name = "dotxtCustomerName";
            this.dotxtCustomerName.Size = new System.Drawing.Size(456, 20);
            this.dotxtCustomerName.TabIndex = 2;
            this.dotxtCustomerName.Tag = "CustomerName";
            // 
            // dicboCustomerType
            // 
            this.dicboCustomerType.BackColor = System.Drawing.Color.Snow;
            this.dicboCustomerType.DataField = "CustomerType";
            this.dicboCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicboCustomerType.FormattingEnabled = true;
            this.dicboCustomerType.Location = new System.Drawing.Point(465, 52);
            this.dicboCustomerType.Name = "dicboCustomerType";
            this.dicboCustomerType.Size = new System.Drawing.Size(206, 21);
            this.dicboCustomerType.TabIndex = 1;
            this.dicboCustomerType.Tag = "CustomerType";
            // 
            // dicboTransaction
            // 
            this.dicboTransaction.BackColor = System.Drawing.Color.Snow;
            this.dicboTransaction.DataField = "TransType";
            this.dicboTransaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dicboTransaction.FormattingEnabled = true;
            this.dicboTransaction.Location = new System.Drawing.Point(291, 54);
            this.dicboTransaction.Name = "dicboTransaction";
            this.dicboTransaction.Size = new System.Drawing.Size(134, 21);
            this.dicboTransaction.TabIndex = 0;
            this.dicboTransaction.Tag = "TransType";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(562, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "CNIC No /Passport";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(674, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Address";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Customer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(787, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Invoice No";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Transaction";
            // 
            // dotxtCnicNo
            // 
            this.dotxtCnicNo.BackColor = System.Drawing.Color.Snow;
            this.dotxtCnicNo.DataField = null;
            this.dotxtCnicNo.Location = new System.Drawing.Point(666, 182);
            this.dotxtCnicNo.Name = "dotxtCnicNo";
            this.dotxtCnicNo.Size = new System.Drawing.Size(163, 20);
            this.dotxtCnicNo.TabIndex = 4;
            this.dotxtCnicNo.Tag = "CNICNO";
            this.dotxtCnicNo.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblusdAmount);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.lblTotalAmount);
            this.panel1.Location = new System.Drawing.Point(9, 359);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 23);
            this.panel1.TabIndex = 704;
            // 
            // lblusdAmount
            // 
            this.lblusdAmount.AutoSize = true;
            this.lblusdAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusdAmount.Location = new System.Drawing.Point(746, 2);
            this.lblusdAmount.Name = "lblusdAmount";
            this.lblusdAmount.Size = new System.Drawing.Size(19, 20);
            this.lblusdAmount.TabIndex = 59;
            this.lblusdAmount.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(451, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 20);
            this.label14.TabIndex = 60;
            this.label14.Text = "Total Amount";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(631, 2);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(19, 20);
            this.lblTotalAmount.TabIndex = 58;
            this.lblTotalAmount.Text = "0";
            // 
            // dtbDetail
            // 
            this.dtbDetail.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtbDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtbDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtbDetail.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtbDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbDetail.Location = new System.Drawing.Point(12, 170);
            this.dtbDetail.Name = "dtbDetail";
            this.dtbDetail.Size = new System.Drawing.Size(852, 184);
            this.dtbDetail.TabIndex = 703;
            // 
            // frmTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 614);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtbDetail);
            this.Controls.Add(this.PnlMain);
            this.Name = "frmTransaction";
            this.Text = "frmTransaction";
            this.Controls.SetChildIndex(this.PnlMain, 0);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.dtbDetail, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.PnlMain.ResumeLayout(false);
            this.PnlMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Label lblCrime;
        private System.Windows.Forms.Label label7;
        private cstTextBox dotxtRemarks;
        private System.Windows.Forms.Button cmdCompleteSale;
        private System.Windows.Forms.Label label17;
        private cstComboBox dicbopaymentMode;
        private System.Windows.Forms.Label label16;
        public ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtDate;
        private cstTextBox dotxtAddress;
        private cstTextBox dotxtTokenNo;
        private System.Windows.Forms.Label label13;
        private cstComboBox docboCustName;
        private cstTextBox ditxtVoucherNo;
        private System.Windows.Forms.Label label12;
        private cstTextBox dotxtCustomerName;
        private cstComboBox dicboCustomerType;
        private cstComboBox dicboTransaction;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private cstTextBox dotxtCnicNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblusdAmount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.DataGridView dtbDetail;
    }
}