namespace ExchangeCompanySoftware
{
    partial class frmRemitenceBlotter
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCredit = new System.Windows.Forms.Label();
            this.lblDebit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtTransDate = new ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker();
            this.dtbTB = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.dtFrom = new ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker();
            this.lblNoofTrans = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtbTB)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCredit
            // 
            this.lblCredit.AutoSize = true;
            this.lblCredit.BackColor = System.Drawing.Color.Transparent;
            this.lblCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredit.Location = new System.Drawing.Point(488, 555);
            this.lblCredit.Name = "lblCredit";
            this.lblCredit.Size = new System.Drawing.Size(19, 20);
            this.lblCredit.TabIndex = 709;
            this.lblCredit.Text = "0";
            // 
            // lblDebit
            // 
            this.lblDebit.AutoSize = true;
            this.lblDebit.BackColor = System.Drawing.Color.Transparent;
            this.lblDebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebit.Location = new System.Drawing.Point(359, 555);
            this.lblDebit.Name = "lblDebit";
            this.lblDebit.Size = new System.Drawing.Size(19, 20);
            this.lblDebit.TabIndex = 708;
            this.lblDebit.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(111, 556);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 707;
            this.label1.Text = "TOTAL";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(622, 1);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(70, 32);
            this.btnRefresh.TabIndex = 712;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 711;
            this.label2.Text = "Date As on :";
            // 
            // dtTransDate
            // 
            this.dtTransDate.CustomFormat = "dd/MMM/yyyy";
            this.dtTransDate.DataField = null;
            this.dtTransDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTransDate.Location = new System.Drawing.Point(76, 10);
            this.dtTransDate.Name = "dtTransDate";
            this.dtTransDate.Size = new System.Drawing.Size(124, 20);
            this.dtTransDate.TabIndex = 710;
            // 
            // dtbTB
            // 
            this.dtbTB.AllowUserToAddRows = false;
            this.dtbTB.AllowUserToDeleteRows = false;
            this.dtbTB.AllowUserToOrderColumns = true;
            this.dtbTB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtbTB.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dtbTB.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dtbTB.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtbTB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtbTB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.BlueViolet;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtbTB.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtbTB.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtbTB.GridColor = System.Drawing.Color.Black;
            this.dtbTB.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dtbTB.Location = new System.Drawing.Point(0, 40);
            this.dtbTB.Name = "dtbTB";
            this.dtbTB.ReadOnly = true;
            this.dtbTB.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtbTB.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtbTB.RowHeadersVisible = false;
            this.dtbTB.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtbTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtbTB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtbTB.Size = new System.Drawing.Size(706, 513);
            this.dtbTB.TabIndex = 713;
            this.dtbTB.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtbTB_CellPainting);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(492, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 32);
            this.button1.TabIndex = 714;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "dd/MMM/yyyy";
            this.dtFrom.DataField = null;
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(206, 9);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(124, 20);
            this.dtFrom.TabIndex = 716;
            // 
            // lblNoofTrans
            // 
            this.lblNoofTrans.AutoSize = true;
            this.lblNoofTrans.BackColor = System.Drawing.Color.Transparent;
            this.lblNoofTrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoofTrans.Location = new System.Drawing.Point(631, 555);
            this.lblNoofTrans.Name = "lblNoofTrans";
            this.lblNoofTrans.Size = new System.Drawing.Size(19, 20);
            this.lblNoofTrans.TabIndex = 717;
            this.lblNoofTrans.Text = "0";
            // 
            // frmRemitenceBlotter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 579);
            this.Controls.Add(this.lblNoofTrans);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtbTB);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtTransDate);
            this.Controls.Add(this.lblCredit);
            this.Controls.Add(this.lblDebit);
            this.Controls.Add(this.label1);
            this.Name = "frmRemitenceBlotter";
            this.Text = "frmRemitenceBlotter";
            this.Load += new System.EventHandler(this.frmRemitenceBlotter_Load);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblDebit, 0);
            this.Controls.SetChildIndex(this.lblCredit, 0);
            this.Controls.SetChildIndex(this.dtTransDate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnRefresh, 0);
            this.Controls.SetChildIndex(this.dtbTB, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.dtFrom, 0);
            this.Controls.SetChildIndex(this.lblNoofTrans, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dtbTB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCredit;
        private System.Windows.Forms.Label lblDebit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label2;
        private ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtTransDate;
        public System.Windows.Forms.DataGridView dtbTB;
        private System.Windows.Forms.Button button1;
        private ExchangeCompanySoftware.Custom_Controls.cstDateTimePicker dtFrom;
        private System.Windows.Forms.Label lblNoofTrans;
    }
}