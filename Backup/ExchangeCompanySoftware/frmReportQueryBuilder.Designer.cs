namespace ExchangeCompanySoftware
{
    partial class frmReportQueryBuilder
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlMain4 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.dtbDetail = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chkLines = new ExchangeCompanySoftware.Custom_Controls.cstCheckBox();
            this.chkLandscape = new ExchangeCompanySoftware.Custom_Controls.cstCheckBox();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlMain5 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.dtbGroup = new System.Windows.Forms.DataGridView();
            this.dtbOrder = new System.Windows.Forms.DataGridView();
            this.dtbSupress = new System.Windows.Forms.DataGridView();
            this.dtbSummerized = new System.Windows.Forms.DataGridView();
            this.pnlMain1 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.label21 = new System.Windows.Forms.Label();
            this.pnlMain7 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.label36 = new System.Windows.Forms.Label();
            this.pnlMain2 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.label15 = new System.Windows.Forms.Label();
            this.pnlMain3 = new ExchangeCompanySoftware.Custom_Controls.PnlMain();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlMain4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.pnlMain5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtbGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbSupress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbSummerized)).BeginInit();
            this.pnlMain1.SuspendLayout();
            this.pnlMain7.SuspendLayout();
            this.pnlMain2.SuspendLayout();
            this.pnlMain3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(877, 410);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlMain4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(869, 384);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Query";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlMain4
            // 
            this.pnlMain4.BeginColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMain4.Controls.Add(this.button2);
            this.pnlMain4.Controls.Add(this.button1);
            this.pnlMain4.Controls.Add(this.button3);
            this.pnlMain4.Controls.Add(this.cmdCancel);
            this.pnlMain4.Controls.Add(this.dtbDetail);
            this.pnlMain4.Controls.Add(this.btnRefresh);
            this.pnlMain4.Controls.Add(this.chkLines);
            this.pnlMain4.Controls.Add(this.chkLandscape);
            this.pnlMain4.Controls.Add(this.cmdGenerate);
            this.pnlMain4.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlMain4.Location = new System.Drawing.Point(0, 0);
            this.pnlMain4.Name = "pnlMain4";
            this.pnlMain4.Size = new System.Drawing.Size(873, 420);
            this.pnlMain4.TabIndex = 816;
            // 
            // button1
            // 
            //this.button1.BackgroundImage = global::ExchangeCompanySoftware.Resource1.pdf_icon;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(709, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 80);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::ExchangeCompanySoftware.Resource1.print;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(605, 190);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 80);
            this.button3.TabIndex = 10;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackgroundImage = global::ExchangeCompanySoftware.Resource1.close;
            this.cmdCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdCancel.Location = new System.Drawing.Point(605, 276);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(98, 80);
            this.cmdCancel.TabIndex = 6;
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // dtbDetail
            // 
            this.dtbDetail.AllowUserToAddRows = false;
            this.dtbDetail.AllowUserToDeleteRows = false;
            this.dtbDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtbDetail.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.dtbDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbDetail.Location = new System.Drawing.Point(3, 3);
            this.dtbDetail.Name = "dtbDetail";
            this.dtbDetail.RowHeadersVisible = false;
            this.dtbDetail.ShowCellErrors = false;
            this.dtbDetail.ShowRowErrors = false;
            this.dtbDetail.Size = new System.Drawing.Size(596, 376);
            this.dtbDetail.TabIndex = 8;
            this.dtbDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtbDetail_CellEndEdit);
            this.dtbDetail.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtbDetail_CellPainting);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::ExchangeCompanySoftware.Resource1.refresh_New;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Location = new System.Drawing.Point(605, 104);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(98, 80);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chkLines
            // 
            this.chkLines.AutoSize = true;
            this.chkLines.DataField = null;
            this.chkLines.Location = new System.Drawing.Point(733, 339);
            this.chkLines.Name = "chkLines";
            this.chkLines.Size = new System.Drawing.Size(51, 17);
            this.chkLines.TabIndex = 9;
            this.chkLines.Text = "Lines";
            this.chkLines.UseVisualStyleBackColor = true;
            // 
            // chkLandscape
            // 
            this.chkLandscape.AutoSize = true;
            this.chkLandscape.DataField = null;
            this.chkLandscape.Location = new System.Drawing.Point(733, 316);
            this.chkLandscape.Name = "chkLandscape";
            this.chkLandscape.Size = new System.Drawing.Size(79, 17);
            this.chkLandscape.TabIndex = 10;
            this.chkLandscape.Text = "Landscape";
            this.chkLandscape.UseVisualStyleBackColor = true;
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.BackgroundImage = global::ExchangeCompanySoftware.Resource1.Preview_icon;
            this.cmdGenerate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdGenerate.Location = new System.Drawing.Point(605, 18);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(98, 80);
            this.cmdGenerate.TabIndex = 5;
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pnlMain5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(869, 384);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Option";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlMain5
            // 
            this.pnlMain5.BeginColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMain5.Controls.Add(this.dtbGroup);
            this.pnlMain5.Controls.Add(this.dtbOrder);
            this.pnlMain5.Controls.Add(this.dtbSupress);
            this.pnlMain5.Controls.Add(this.dtbSummerized);
            this.pnlMain5.Controls.Add(this.pnlMain1);
            this.pnlMain5.Controls.Add(this.pnlMain7);
            this.pnlMain5.Controls.Add(this.pnlMain2);
            this.pnlMain5.Controls.Add(this.pnlMain3);
            this.pnlMain5.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlMain5.Location = new System.Drawing.Point(-4, 0);
            this.pnlMain5.Name = "pnlMain5";
            this.pnlMain5.Size = new System.Drawing.Size(873, 416);
            this.pnlMain5.TabIndex = 822;
            // 
            // dtbGroup
            // 
            this.dtbGroup.AllowUserToAddRows = false;
            this.dtbGroup.AllowUserToDeleteRows = false;
            this.dtbGroup.AllowUserToOrderColumns = true;
            this.dtbGroup.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dtbGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbGroup.Location = new System.Drawing.Point(4, 19);
            this.dtbGroup.Name = "dtbGroup";
            this.dtbGroup.RowHeadersVisible = false;
            this.dtbGroup.Size = new System.Drawing.Size(199, 364);
            this.dtbGroup.TabIndex = 0;
            // 
            // dtbOrder
            // 
            this.dtbOrder.AllowUserToAddRows = false;
            this.dtbOrder.AllowUserToDeleteRows = false;
            this.dtbOrder.AllowUserToOrderColumns = true;
            this.dtbOrder.BackgroundColor = System.Drawing.Color.Pink;
            this.dtbOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbOrder.Location = new System.Drawing.Point(204, 19);
            this.dtbOrder.Name = "dtbOrder";
            this.dtbOrder.RowHeadersVisible = false;
            this.dtbOrder.Size = new System.Drawing.Size(196, 364);
            this.dtbOrder.TabIndex = 818;
            // 
            // dtbSupress
            // 
            this.dtbSupress.AllowUserToAddRows = false;
            this.dtbSupress.AllowUserToDeleteRows = false;
            this.dtbSupress.AllowUserToOrderColumns = true;
            this.dtbSupress.BackgroundColor = System.Drawing.Color.Moccasin;
            this.dtbSupress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbSupress.Location = new System.Drawing.Point(401, 19);
            this.dtbSupress.Name = "dtbSupress";
            this.dtbSupress.RowHeadersVisible = false;
            this.dtbSupress.Size = new System.Drawing.Size(192, 364);
            this.dtbSupress.TabIndex = 819;
            this.dtbSupress.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtbSupress_CellEndEdit);
            this.dtbSupress.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtbSupress_CellContentClick);
            // 
            // dtbSummerized
            // 
            this.dtbSummerized.AllowUserToAddRows = false;
            this.dtbSummerized.AllowUserToDeleteRows = false;
            this.dtbSummerized.AllowUserToOrderColumns = true;
            this.dtbSummerized.BackgroundColor = System.Drawing.Color.Plum;
            this.dtbSummerized.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbSummerized.Location = new System.Drawing.Point(594, 19);
            this.dtbSummerized.Name = "dtbSummerized";
            this.dtbSummerized.RowHeadersVisible = false;
            this.dtbSummerized.Size = new System.Drawing.Size(274, 363);
            this.dtbSummerized.TabIndex = 821;
            this.dtbSummerized.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtbSummerized_CellValueChanged);
            this.dtbSummerized.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtbSummerized_CellContentClick);
            // 
            // pnlMain1
            // 
            this.pnlMain1.BeginColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMain1.Controls.Add(this.label21);
            this.pnlMain1.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlMain1.Location = new System.Drawing.Point(4, 1);
            this.pnlMain1.Name = "pnlMain1";
            this.pnlMain1.Size = new System.Drawing.Size(199, 18);
            this.pnlMain1.TabIndex = 815;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label21.Location = new System.Drawing.Point(5, 2);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Grouping";
            // 
            // pnlMain7
            // 
            this.pnlMain7.BeginColor = System.Drawing.Color.Maroon;
            this.pnlMain7.Controls.Add(this.label36);
            this.pnlMain7.EndColor = System.Drawing.Color.Red;
            this.pnlMain7.Location = new System.Drawing.Point(203, 1);
            this.pnlMain7.Name = "pnlMain7";
            this.pnlMain7.Size = new System.Drawing.Size(197, 18);
            this.pnlMain7.TabIndex = 816;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label36.Location = new System.Drawing.Point(5, 2);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(47, 13);
            this.label36.TabIndex = 0;
            this.label36.Text = "Sorting";
            // 
            // pnlMain2
            // 
            this.pnlMain2.BeginColor = System.Drawing.Color.Orange;
            this.pnlMain2.Controls.Add(this.label15);
            this.pnlMain2.EndColor = System.Drawing.Color.NavajoWhite;
            this.pnlMain2.Location = new System.Drawing.Point(401, 1);
            this.pnlMain2.Name = "pnlMain2";
            this.pnlMain2.Size = new System.Drawing.Size(192, 18);
            this.pnlMain2.TabIndex = 817;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(5, 2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Supress";
            // 
            // pnlMain3
            // 
            this.pnlMain3.BeginColor = System.Drawing.Color.Indigo;
            this.pnlMain3.Controls.Add(this.label1);
            this.pnlMain3.EndColor = System.Drawing.Color.Plum;
            this.pnlMain3.Location = new System.Drawing.Point(594, 1);
            this.pnlMain3.Name = "pnlMain3";
            this.pnlMain3.Size = new System.Drawing.Size(274, 18);
            this.pnlMain3.TabIndex = 820;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Summerized";
            // 
            // button2
            // 
           // this.button2.BackgroundImage = global::ExchangeCompanySoftware.Resource1._17515027041682025196;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(709, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 80);
            this.button2.TabIndex = 12;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmReportQueryBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(875, 410);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmReportQueryBuilder";
            this.Text = "GVGFGGG";
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pnlMain4.ResumeLayout(false);
            this.pnlMain4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtbDetail)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.pnlMain5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtbGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbSupress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtbSummerized)).EndInit();
            this.pnlMain1.ResumeLayout(false);
            this.pnlMain1.PerformLayout();
            this.pnlMain7.ResumeLayout(false);
            this.pnlMain7.PerformLayout();
            this.pnlMain2.ResumeLayout(false);
            this.pnlMain2.PerformLayout();
            this.pnlMain3.ResumeLayout(false);
            this.pnlMain3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dtbDetail;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dtbGroup;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain1;
        private System.Windows.Forms.Label label21;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain7;
        private System.Windows.Forms.Label label36;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dtbSupress;
        private System.Windows.Forms.DataGridView dtbOrder;
        private System.Windows.Forms.DataGridView dtbSummerized;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain3;
        private System.Windows.Forms.Label label1;
        private ExchangeCompanySoftware.Custom_Controls.cstCheckBox chkLandscape;
        private ExchangeCompanySoftware.Custom_Controls.cstCheckBox chkLines;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button button3;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain4;
        private ExchangeCompanySoftware.Custom_Controls.PnlMain pnlMain5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}