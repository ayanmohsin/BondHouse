namespace ExchangeCompanySoftware
{
    partial class frmBarCode
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
            this.button1 = new System.Windows.Forms.Button();
            this.dtbDetail = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBarCode = new ExchangeCompanySoftware.cstTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dotxtItemNAme = new ExchangeCompanySoftware.cstTextBox();
            this.dotxtSName = new ExchangeCompanySoftware.cstTextBox();
            this.dotxtCode = new ExchangeCompanySoftware.cstTextBox();
            this.dotxtQty = new ExchangeCompanySoftware.cstTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ditxtBarCodeFrom = new ExchangeCompanySoftware.cstTextBox();
            this.ditxtBarCodeTo = new ExchangeCompanySoftware.cstTextBox();
            this.btnRange = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddToGrid = new System.Windows.Forms.Button();
            this.docboCategory = new ExchangeCompanySoftware.cstComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtSaleRate = new ExchangeCompanySoftware.cstTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(609, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtbDetail
            // 
            this.dtbDetail.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.NavajoWhite;
            this.dtbDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtbDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtbDetail.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(202)))), ((int)(((byte)(233)))));
            this.dtbDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbDetail.Location = new System.Drawing.Point(0, 126);
            this.dtbDetail.Name = "dtbDetail";
            this.dtbDetail.Size = new System.Drawing.Size(707, 411);
            this.dtbDetail.TabIndex = 703;
            this.dtbDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtbDetail_CellEndEdit);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(9, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 907;
            this.label11.Text = "BarCode";
            // 
            // txtBarCode
            // 
            this.txtBarCode.BackColor = System.Drawing.Color.Snow;
            this.txtBarCode.DataField = null;
            this.txtBarCode.Location = new System.Drawing.Point(12, 21);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(140, 20);
            this.txtBarCode.TabIndex = 906;
            this.txtBarCode.Tag = "Remarks";
            this.txtBarCode.Validated += new System.EventHandler(this.txtBarCode_Validated);
            this.txtBarCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtBarCode_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(155, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 909;
            this.label1.Text = "ItemName";
            // 
            // dotxtItemNAme
            // 
            this.dotxtItemNAme.BackColor = System.Drawing.Color.Snow;
            this.dotxtItemNAme.DataField = null;
            this.dotxtItemNAme.Location = new System.Drawing.Point(158, 21);
            this.dotxtItemNAme.Name = "dotxtItemNAme";
            this.dotxtItemNAme.Size = new System.Drawing.Size(210, 20);
            this.dotxtItemNAme.TabIndex = 908;
            this.dotxtItemNAme.Tag = "Remarks";
            this.dotxtItemNAme.TextChanged += new System.EventHandler(this.cstTextBox1_TextChanged);
            this.dotxtItemNAme.Validated += new System.EventHandler(this.dotxtItemNAme_Validated);
            // 
            // dotxtSName
            // 
            this.dotxtSName.BackColor = System.Drawing.Color.Snow;
            this.dotxtSName.DataField = null;
            this.dotxtSName.Location = new System.Drawing.Point(374, 21);
            this.dotxtSName.Name = "dotxtSName";
            this.dotxtSName.Size = new System.Drawing.Size(87, 20);
            this.dotxtSName.TabIndex = 910;
            this.dotxtSName.Tag = "Remarks";
            this.dotxtSName.Validated += new System.EventHandler(this.dotxtSName_Validated);
            // 
            // dotxtCode
            // 
            this.dotxtCode.BackColor = System.Drawing.Color.Snow;
            this.dotxtCode.DataField = null;
            this.dotxtCode.Location = new System.Drawing.Point(467, 21);
            this.dotxtCode.Name = "dotxtCode";
            this.dotxtCode.Size = new System.Drawing.Size(87, 20);
            this.dotxtCode.TabIndex = 911;
            this.dotxtCode.Tag = "Remarks";
            // 
            // dotxtQty
            // 
            this.dotxtQty.BackColor = System.Drawing.Color.Snow;
            this.dotxtQty.DataField = null;
            this.dotxtQty.Location = new System.Drawing.Point(560, 21);
            this.dotxtQty.Name = "dotxtQty";
            this.dotxtQty.Size = new System.Drawing.Size(87, 20);
            this.dotxtQty.TabIndex = 912;
            this.dotxtQty.Tag = "Remarks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(374, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 913;
            this.label2.Text = "Short Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(464, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 914;
            this.label3.Text = "Code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(557, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 915;
            this.label4.Text = "No of BarCode";
            // 
            // ditxtBarCodeFrom
            // 
            this.ditxtBarCodeFrom.BackColor = System.Drawing.Color.Snow;
            this.ditxtBarCodeFrom.DataField = null;
            this.ditxtBarCodeFrom.Location = new System.Drawing.Point(222, 58);
            this.ditxtBarCodeFrom.Name = "ditxtBarCodeFrom";
            this.ditxtBarCodeFrom.Size = new System.Drawing.Size(140, 20);
            this.ditxtBarCodeFrom.TabIndex = 917;
            this.ditxtBarCodeFrom.Tag = "Remarks";
            // 
            // ditxtBarCodeTo
            // 
            this.ditxtBarCodeTo.BackColor = System.Drawing.Color.Snow;
            this.ditxtBarCodeTo.DataField = null;
            this.ditxtBarCodeTo.Location = new System.Drawing.Point(377, 58);
            this.ditxtBarCodeTo.Name = "ditxtBarCodeTo";
            this.ditxtBarCodeTo.Size = new System.Drawing.Size(140, 20);
            this.ditxtBarCodeTo.TabIndex = 918;
            this.ditxtBarCodeTo.Tag = "Remarks";
            // 
            // btnRange
            // 
            this.btnRange.Location = new System.Drawing.Point(523, 55);
            this.btnRange.Name = "btnRange";
            this.btnRange.Size = new System.Drawing.Size(87, 21);
            this.btnRange.TabIndex = 919;
            this.btnRange.Text = "Add";
            this.btnRange.UseVisualStyleBackColor = true;
            this.btnRange.Click += new System.EventHandler(this.btnRange_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(222, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 920;
            this.label6.Text = "BarCode From";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(375, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 921;
            this.label7.Text = "BarCode To";
            // 
            // btnAddToGrid
            // 
            this.btnAddToGrid.Location = new System.Drawing.Point(653, 20);
            this.btnAddToGrid.Name = "btnAddToGrid";
            this.btnAddToGrid.Size = new System.Drawing.Size(43, 21);
            this.btnAddToGrid.TabIndex = 922;
            this.btnAddToGrid.Text = "Add";
            this.btnAddToGrid.UseVisualStyleBackColor = true;
            this.btnAddToGrid.Click += new System.EventHandler(this.btnAddToGrid_Click);
            // 
            // docboCategory
            // 
            this.docboCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(219)))), ((int)(((byte)(201)))));
            this.docboCategory.DataField = null;
            this.docboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.docboCategory.FormattingEnabled = true;
            this.docboCategory.Location = new System.Drawing.Point(11, 59);
            this.docboCategory.Name = "docboCategory";
            this.docboCategory.Size = new System.Drawing.Size(158, 21);
            this.docboCategory.TabIndex = 923;
            this.docboCategory.Tag = "CategoryCode";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Location = new System.Drawing.Point(13, 44);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(55, 13);
            this.label24.TabIndex = 924;
            this.label24.Text = "Category :";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(175, 58);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(43, 21);
            this.btnAdd.TabIndex = 925;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.BackColor = System.Drawing.Color.Transparent;
            this.lblQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(396, 94);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(25, 25);
            this.lblQty.TabIndex = 926;
            this.lblQty.Text = "0";
            // 
            // txtSaleRate
            // 
            this.txtSaleRate.BackColor = System.Drawing.Color.Snow;
            this.txtSaleRate.DataField = null;
            this.txtSaleRate.Location = new System.Drawing.Point(616, 55);
            this.txtSaleRate.Name = "txtSaleRate";
            this.txtSaleRate.Size = new System.Drawing.Size(87, 20);
            this.txtSaleRate.TabIndex = 928;
            this.txtSaleRate.Tag = "Remarks";
            // 
            // frmBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 534);
            this.Controls.Add(this.txtSaleRate);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.docboCategory);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.btnAddToGrid);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnRange);
            this.Controls.Add(this.ditxtBarCodeTo);
            this.Controls.Add(this.ditxtBarCodeFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dotxtQty);
            this.Controls.Add(this.dotxtCode);
            this.Controls.Add(this.dotxtSName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dotxtItemNAme);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.dtbDetail);
            this.Controls.Add(this.button1);
            this.Name = "frmBarCode";
            this.Text = "ds";
            this.Load += new System.EventHandler(this.frmBarCode_Load);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.dtbDetail, 0);
            this.Controls.SetChildIndex(this.txtBarCode, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.dotxtItemNAme, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dotxtSName, 0);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.dotxtCode, 0);
            this.Controls.SetChildIndex(this.dotxtQty, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.ditxtBarCodeFrom, 0);
            this.Controls.SetChildIndex(this.ditxtBarCodeTo, 0);
            this.Controls.SetChildIndex(this.btnRange, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.btnAddToGrid, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.docboCategory, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.lblQty, 0);
            this.Controls.SetChildIndex(this.txtSaleRate, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dtbDetail;
        private System.Windows.Forms.Label label11;
        private cstTextBox txtBarCode;
        private System.Windows.Forms.Label label1;
        private cstTextBox dotxtItemNAme;
        private cstTextBox dotxtSName;
        private cstTextBox dotxtCode;
        private cstTextBox dotxtQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private cstTextBox ditxtBarCodeFrom;
        private cstTextBox ditxtBarCodeTo;
        private System.Windows.Forms.Button btnRange;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddToGrid;
        private cstComboBox docboCategory;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblQty;
        private cstTextBox txtSaleRate;
    }
}