namespace ExchangeCompanySoftware
{
    partial class frmCurrencyPosition
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.dataTable2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new ExchangeCompanySoftware.DataSet1();
            this.fieldTitle = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldItemName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldQuantity = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldAvgRate = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldAmount = new DevExpress.XtraPivotGrid.PivotGridField();
            this.dtSystemDate = new ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtbCurrency = new System.Windows.Forms.DataGridView();
            this.Currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtbBranch = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Branch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCashinHand = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Appearance.Cell.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pivotGridControl1.Appearance.Cell.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.Cell.Options.UseFont = true;
            this.pivotGridControl1.Appearance.Cell.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.ColumnHeaderArea.BackColor = System.Drawing.Color.Transparent;
            this.pivotGridControl1.Appearance.ColumnHeaderArea.BackColor2 = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.ColumnHeaderArea.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pivotGridControl1.Appearance.ColumnHeaderArea.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.ColumnHeaderArea.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pivotGridControl1.Appearance.ColumnHeaderArea.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.ColumnHeaderArea.Options.UseFont = true;
            this.pivotGridControl1.Appearance.ColumnHeaderArea.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pivotGridControl1.Appearance.CustomTotalCell.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.CustomTotalCell.Options.UseFont = true;
            this.pivotGridControl1.Appearance.CustomTotalCell.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.DataHeaderArea.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pivotGridControl1.Appearance.DataHeaderArea.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.DataHeaderArea.Options.UseFont = true;
            this.pivotGridControl1.Appearance.DataHeaderArea.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.Empty.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pivotGridControl1.Appearance.Empty.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.Empty.Options.UseFont = true;
            this.pivotGridControl1.Appearance.Empty.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.ExpandButton.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pivotGridControl1.Appearance.ExpandButton.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.ExpandButton.Options.UseFont = true;
            this.pivotGridControl1.Appearance.ExpandButton.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.FieldHeader.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pivotGridControl1.Appearance.FieldHeader.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.FieldHeader.Options.UseFont = true;
            this.pivotGridControl1.Appearance.FieldHeader.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.FieldValue.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.FieldValue.BackColor2 = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.FieldValue.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pivotGridControl1.Appearance.FieldValue.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.FieldValue.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.FieldValue.Options.UseFont = true;
            this.pivotGridControl1.Appearance.FieldValue.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.FieldValueGrandTotal.BackColor = System.Drawing.Color.Blue;
            this.pivotGridControl1.Appearance.FieldValueGrandTotal.BackColor2 = System.Drawing.Color.MidnightBlue;
            this.pivotGridControl1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pivotGridControl1.Appearance.FieldValueGrandTotal.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.FieldValueGrandTotal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pivotGridControl1.Appearance.FieldValueGrandTotal.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.FieldValueGrandTotal.Options.UseFont = true;
            this.pivotGridControl1.Appearance.FieldValueGrandTotal.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.FieldValueTotal.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.FieldValueTotal.BackColor2 = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pivotGridControl1.Appearance.FieldValueTotal.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.FieldValueTotal.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.FieldValueTotal.Options.UseFont = true;
            this.pivotGridControl1.Appearance.FieldValueTotal.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.FilterHeaderArea.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.FilterHeaderArea.BackColor2 = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.FilterHeaderArea.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.FilterHeaderArea.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pivotGridControl1.Appearance.FilterHeaderArea.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.FilterHeaderArea.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.FilterSeparator.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.FilterSeparator.BackColor2 = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.FilterSeparator.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.FilterSeparator.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.FilterSeparator.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.GrandTotalCell.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.GrandTotalCell.BackColor2 = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.GrandTotalCell.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.GrandTotalCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pivotGridControl1.Appearance.GrandTotalCell.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.GrandTotalCell.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.HeaderArea.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.HeaderArea.BackColor2 = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.HeaderArea.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pivotGridControl1.Appearance.HeaderArea.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.HeaderArea.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pivotGridControl1.Appearance.HeaderArea.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.HeaderArea.Options.UseFont = true;
            this.pivotGridControl1.Appearance.HeaderArea.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.HeaderFilterButton.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.HeaderFilterButton.BackColor2 = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.HeaderFilterButton.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pivotGridControl1.Appearance.HeaderFilterButton.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.HeaderFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pivotGridControl1.Appearance.HeaderFilterButton.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.HeaderFilterButton.Options.UseFont = true;
            this.pivotGridControl1.Appearance.HeaderFilterButton.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.HeaderFilterButtonActive.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.HeaderFilterButtonActive.BackColor2 = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.HeaderFilterButtonActive.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pivotGridControl1.Appearance.HeaderFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.HeaderFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pivotGridControl1.Appearance.HeaderFilterButtonActive.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.HeaderFilterButtonActive.Options.UseFont = true;
            this.pivotGridControl1.Appearance.HeaderFilterButtonActive.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.HeaderGroupLine.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.HeaderGroupLine.BackColor2 = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.HeaderGroupLine.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pivotGridControl1.Appearance.HeaderGroupLine.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.HeaderGroupLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pivotGridControl1.Appearance.HeaderGroupLine.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.HeaderGroupLine.Options.UseFont = true;
            this.pivotGridControl1.Appearance.HeaderGroupLine.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.Lines.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.Lines.BackColor2 = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.Lines.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pivotGridControl1.Appearance.Lines.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.Lines.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.Lines.Options.UseFont = true;
            this.pivotGridControl1.Appearance.Lines.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.PrefilterPanel.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.PrefilterPanel.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.RowHeaderArea.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.RowHeaderArea.BackColor2 = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.RowHeaderArea.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pivotGridControl1.Appearance.RowHeaderArea.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.RowHeaderArea.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pivotGridControl1.Appearance.RowHeaderArea.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.RowHeaderArea.Options.UseFont = true;
            this.pivotGridControl1.Appearance.RowHeaderArea.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.SelectedCell.BackColor = System.Drawing.Color.OldLace;
            this.pivotGridControl1.Appearance.SelectedCell.BackColor2 = System.Drawing.Color.Orchid;
            this.pivotGridControl1.Appearance.SelectedCell.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pivotGridControl1.Appearance.SelectedCell.ForeColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Appearance.SelectedCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pivotGridControl1.Appearance.SelectedCell.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.SelectedCell.Options.UseFont = true;
            this.pivotGridControl1.Appearance.SelectedCell.Options.UseForeColor = true;
            this.pivotGridControl1.Appearance.TotalCell.BackColor = System.Drawing.Color.MidnightBlue;
            this.pivotGridControl1.Appearance.TotalCell.BackColor2 = System.Drawing.Color.DodgerBlue;
            this.pivotGridControl1.Appearance.TotalCell.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pivotGridControl1.Appearance.TotalCell.ForeColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.TotalCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pivotGridControl1.Appearance.TotalCell.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.TotalCell.Options.UseFont = true;
            this.pivotGridControl1.Appearance.TotalCell.Options.UseForeColor = true;
            this.pivotGridControl1.AppearancePrint.FieldHeader.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pivotGridControl1.AppearancePrint.FieldHeader.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            this.pivotGridControl1.AppearancePrint.FieldHeader.Options.UseBackColor = true;
            this.pivotGridControl1.AppearancePrint.FieldValueGrandTotal.BackColor = System.Drawing.Color.NavajoWhite;
            this.pivotGridControl1.AppearancePrint.FieldValueGrandTotal.Options.UseBackColor = true;
            this.pivotGridControl1.AppearancePrint.FieldValueTotal.BackColor = System.Drawing.Color.NavajoWhite;
            this.pivotGridControl1.AppearancePrint.FieldValueTotal.Options.UseBackColor = true;
            this.pivotGridControl1.AppearancePrint.FilterSeparator.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pivotGridControl1.AppearancePrint.FilterSeparator.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            this.pivotGridControl1.AppearancePrint.FilterSeparator.Options.UseBackColor = true;
            this.pivotGridControl1.AppearancePrint.HeaderGroupLine.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pivotGridControl1.AppearancePrint.HeaderGroupLine.Options.UseBackColor = true;
            this.pivotGridControl1.BackColor = System.Drawing.Color.Black;
            this.pivotGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pivotGridControl1.DataSource = this.dataTable2BindingSource;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldTitle,
            this.fieldItemName,
            this.fieldQuantity,
            this.fieldAvgRate,
            this.fieldAmount});
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 53);
            this.pivotGridControl1.LookAndFeel.SkinName = "Blue";
            this.pivotGridControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.pivotGridControl1.LookAndFeel.UseWindowsXPTheme = true;
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsPrint.UsePrintAppearance = true;
            this.pivotGridControl1.Size = new System.Drawing.Size(1028, 446);
            this.pivotGridControl1.TabIndex = 826;
            this.pivotGridControl1.Click += new System.EventHandler(this.pivotGridControl1_Click);
            this.pivotGridControl1.FieldAreaChanged += new DevExpress.XtraPivotGrid.PivotFieldEventHandler(this.pivotGridControl1_FieldAreaChanged);
            this.pivotGridControl1.CustomDrawCell += new DevExpress.XtraPivotGrid.PivotCustomDrawCellEventHandler(this.pivotGridControl1_CustomDrawCell);
            this.pivotGridControl1.TextChanged += new System.EventHandler(this.pivotGridControl1_TextChanged);
            this.pivotGridControl1.FieldValueDisplayText += new DevExpress.XtraPivotGrid.PivotFieldDisplayTextEventHandler(this.pivotGridControl1_FieldValueDisplayText);
            this.pivotGridControl1.DataSourceChanged += new System.EventHandler(this.pivotGridControl1_DataSourceChanged);
            this.pivotGridControl1.CustomSummary += new DevExpress.XtraPivotGrid.PivotGridCustomSummaryEventHandler(this.pivotGridControl1_CustomSummary);
            // 
            // dataTable2BindingSource
            // 
            this.dataTable2BindingSource.DataMember = "DataTable2";
            this.dataTable2BindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fieldTitle
            // 
            this.fieldTitle.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldTitle.AreaIndex = 0;
            this.fieldTitle.Caption = "Title";
            this.fieldTitle.FieldName = "Title";
            this.fieldTitle.Name = "fieldTitle";
            this.fieldTitle.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
            this.fieldTitle.Width = 150;
            // 
            // fieldItemName
            // 
            this.fieldItemName.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            this.fieldItemName.AreaIndex = 0;
            this.fieldItemName.Caption = "ItemName";
            this.fieldItemName.FieldName = "ItemName";
            this.fieldItemName.Name = "fieldItemName";
            // 
            // fieldQuantity
            // 
            this.fieldQuantity.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldQuantity.AreaIndex = 0;
            this.fieldQuantity.Caption = "Quantity";
            this.fieldQuantity.CellFormat.FormatString = "{0:#,0.0000;(#,#);-}";
            this.fieldQuantity.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldQuantity.FieldName = "Quantity";
            this.fieldQuantity.Name = "fieldQuantity";
            this.fieldQuantity.Width = 141;
            // 
            // fieldAvgRate
            // 
            this.fieldAvgRate.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldAvgRate.AreaIndex = 1;
            this.fieldAvgRate.Caption = "AvgRate";
            this.fieldAvgRate.CellFormat.FormatString = "{0:#,0.0000;(#,#);-}";
            this.fieldAvgRate.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldAvgRate.FieldName = "AvgRate";
            this.fieldAvgRate.Name = "fieldAvgRate";
            this.fieldAvgRate.Width = 151;
            // 
            // fieldAmount
            // 
            this.fieldAmount.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldAmount.AreaIndex = 2;
            this.fieldAmount.Caption = "Amount";
            this.fieldAmount.CellFormat.FormatString = "{0:#,0.00;(#,#);-}";
            this.fieldAmount.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldAmount.FieldName = "Amount";
            this.fieldAmount.Name = "fieldAmount";
            this.fieldAmount.Width = 171;
            // 
            // dtSystemDate
            // 
            this.dtSystemDate.CustomFormat = "dd/MMM/yyyy";
            this.dtSystemDate.DataField = null;
            this.dtSystemDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSystemDate.Location = new System.Drawing.Point(94, 3);
            this.dtSystemDate.Name = "dtSystemDate";
            this.dtSystemDate.Size = new System.Drawing.Size(106, 20);
            this.dtSystemDate.TabIndex = 828;
            this.dtSystemDate.ValueChanged += new System.EventHandler(this.dtSystemDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(19, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 829;
            this.label2.Text = "Date As On";
            // 
            // dtbCurrency
            // 
            this.dtbCurrency.AllowUserToAddRows = false;
            this.dtbCurrency.AllowUserToDeleteRows = false;
            this.dtbCurrency.AllowUserToOrderColumns = true;
            this.dtbCurrency.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtbCurrency.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dtbCurrency.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtbCurrency.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtbCurrency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbCurrency.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Currency,
            this.Quantity,
            this.Rate,
            this.Amount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtbCurrency.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtbCurrency.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtbCurrency.GridColor = System.Drawing.Color.Black;
            this.dtbCurrency.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dtbCurrency.Location = new System.Drawing.Point(716, 505);
            this.dtbCurrency.Name = "dtbCurrency";
            this.dtbCurrency.ReadOnly = true;
            this.dtbCurrency.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtbCurrency.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtbCurrency.RowHeadersVisible = false;
            this.dtbCurrency.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtbCurrency.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtbCurrency.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtbCurrency.Size = new System.Drawing.Size(69, 32);
            this.dtbCurrency.TabIndex = 830;
            this.dtbCurrency.Visible = false;
            this.dtbCurrency.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtbCurrency_CellPainting);
            // 
            // Currency
            // 
            this.Currency.HeaderText = "Currency";
            this.Currency.Name = "Currency";
            this.Currency.ReadOnly = true;
            this.Currency.Width = 300;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // dtbBranch
            // 
            this.dtbBranch.AllowUserToAddRows = false;
            this.dtbBranch.AllowUserToDeleteRows = false;
            this.dtbBranch.AllowUserToOrderColumns = true;
            this.dtbBranch.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtbBranch.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dtbBranch.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtbBranch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtbBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbBranch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.Branch,
            this.BranchCode});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtbBranch.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtbBranch.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtbBranch.GridColor = System.Drawing.Color.Black;
            this.dtbBranch.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dtbBranch.Location = new System.Drawing.Point(806, 33);
            this.dtbBranch.Name = "dtbBranch";
            this.dtbBranch.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtbBranch.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtbBranch.RowHeadersVisible = false;
            this.dtbBranch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtbBranch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtbBranch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtbBranch.Size = new System.Drawing.Size(210, 133);
            this.dtbBranch.TabIndex = 831;
            this.dtbBranch.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtbBranch_CurrentCellDirtyStateChanged);
            this.dtbBranch.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtbBranch_CellContentClick);
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.Width = 50;
            // 
            // Branch
            // 
            this.Branch.HeaderText = "Branch";
            this.Branch.Name = "Branch";
            this.Branch.ReadOnly = true;
            this.Branch.Width = 300;
            // 
            // BranchCode
            // 
            this.BranchCode.HeaderText = "BranchCode";
            this.BranchCode.Name = "BranchCode";
            this.BranchCode.ReadOnly = true;
            this.BranchCode.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = global::ExchangeCompanySoftware.Resource1.print;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Location = new System.Drawing.Point(931, -1);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(71, 54);
            this.btnPrint.TabIndex = 834;
            this.btnPrint.Text = "button1";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::ExchangeCompanySoftware.Resource1.refresh_New;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Location = new System.Drawing.Point(856, -1);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(68, 54);
            this.btnRefresh.TabIndex = 835;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblCashinHand
            // 
            this.lblCashinHand.AutoSize = true;
            this.lblCashinHand.BackColor = System.Drawing.Color.Transparent;
            this.lblCashinHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashinHand.ForeColor = System.Drawing.Color.White;
            this.lblCashinHand.Location = new System.Drawing.Point(625, 513);
            this.lblCashinHand.Name = "lblCashinHand";
            this.lblCashinHand.Size = new System.Drawing.Size(17, 17);
            this.lblCashinHand.TabIndex = 837;
            this.lblCashinHand.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(458, 513);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 836;
            this.label1.Text = "Cash";
            // 
            // frmCurrencyPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.lblCashinHand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.pivotGridControl1);
            this.Controls.Add(this.dtbBranch);
            this.Controls.Add(this.dtbCurrency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtSystemDate);
            this.Name = "frmCurrencyPosition";
            this.Text = "frmCurrencyPosition";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCurrencyPosition_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.dtSystemDate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dtbCurrency, 0);
            this.Controls.SetChildIndex(this.dtbBranch, 0);
            this.Controls.SetChildIndex(this.pivotGridControl1, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            this.Controls.SetChildIndex(this.btnRefresh, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblCashinHand, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtSystemDate;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView dtbCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn Currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        public System.Windows.Forms.DataGridView dtbBranch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Branch;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchCode;
        private System.Windows.Forms.BindingSource dataTable2BindingSource;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private System.Windows.Forms.Button btnPrint;
        private DevExpress.XtraPivotGrid.PivotGridField fieldItemName;
        private DevExpress.XtraPivotGrid.PivotGridField fieldTitle;
        private DevExpress.XtraPivotGrid.PivotGridField fieldQuantity;
        private DevExpress.XtraPivotGrid.PivotGridField fieldAvgRate;
        private DevExpress.XtraPivotGrid.PivotGridField fieldAmount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblCashinHand;
        private System.Windows.Forms.Label label1;

    }
}