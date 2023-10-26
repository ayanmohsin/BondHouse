namespace ExchangeCompanySoftware
{
    partial class frmReports
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
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.dtbDetail = new System.Windows.Forms.DataGridView();
            this.SelectionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Query = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Caption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Btn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Man = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.dtDate = new ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Location = new System.Drawing.Point(374, 277);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(75, 23);
            this.cmdGenerate.TabIndex = 5;
            this.cmdGenerate.Text = "Privew";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // dtbDetail
            // 
            this.dtbDetail.AllowUserToAddRows = false;
            this.dtbDetail.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dtbDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectionColumn,
            this.Query,
            this.Caption,
            this.FieldCaption,
            this.Btn,
            this.Man,
            this.clmnDataType});
            this.dtbDetail.Location = new System.Drawing.Point(1, 2);
            this.dtbDetail.Name = "dtbDetail";
            this.dtbDetail.Size = new System.Drawing.Size(529, 269);
            this.dtbDetail.TabIndex = 7;
            this.dtbDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtbDetail_CellContentClick);
            // 
            // SelectionColumn
            // 
            this.SelectionColumn.HeaderText = "";
            this.SelectionColumn.Name = "SelectionColumn";
            this.SelectionColumn.Width = 5;
            // 
            // Query
            // 
            this.Query.HeaderText = "Query";
            this.Query.Name = "Query";
            this.Query.Width = 5;
            // 
            // Caption
            // 
            this.Caption.HeaderText = "Caption";
            this.Caption.Name = "Caption";
            // 
            // FieldCaption
            // 
            this.FieldCaption.HeaderText = "Criteria";
            this.FieldCaption.Name = "FieldCaption";
            // 
            // Btn
            // 
            this.Btn.HeaderText = "";
            this.Btn.Name = "Btn";
            this.Btn.Width = 20;
            // 
            // Man
            // 
            this.Man.HeaderText = "Man";
            this.Man.Name = "Man";
            this.Man.Width = 5;
            // 
            // clmnDataType
            // 
            this.clmnDataType.HeaderText = "Column1";
            this.clmnDataType.Name = "clmnDataType";
            this.clmnDataType.Width = 5;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(455, 277);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 6;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd/MMM/yyyy";
            this.dtDate.DataField = null;
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(154, 24);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(151, 20);
            this.dtDate.TabIndex = 8;
            this.dtDate.Visible = false;
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 303);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.dtbDetail);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdGenerate);
            this.Name = "frmReports";
            this.Text = "frmReports";
            this.Load += new System.EventHandler(this.frmReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.DataGridView dtbDetail;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Query;
        private System.Windows.Forms.DataGridViewTextBoxColumn Caption;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldCaption;
        private System.Windows.Forms.DataGridViewButtonColumn Btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Man;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDataType;
        private ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtDate;
    }
}