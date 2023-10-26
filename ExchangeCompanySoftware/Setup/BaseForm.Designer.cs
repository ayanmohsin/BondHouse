namespace ExchangeCompanySoftware
{
    partial class BaseForm
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
            this.dtbMaster = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ContMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorizedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Unauthorized = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.authorized = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Delete = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.History = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dtbHistory = new System.Windows.Forms.DataGridView();
            this.txtStatus = new ExchangeCompanySoftware.cstTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtbMaster)).BeginInit();
            this.ContMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtbHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dtbMaster
            // 
            this.dtbMaster.AllowUserToAddRows = false;
            this.dtbMaster.AllowUserToDeleteRows = false;
            this.dtbMaster.AllowUserToOrderColumns = true;
            this.dtbMaster.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.dtbMaster.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dtbMaster.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtbMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtbMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtbMaster.ColumnHeadersVisible = false;
            this.dtbMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select});
            this.dtbMaster.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtbMaster.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtbMaster.GridColor = System.Drawing.Color.Black;
            this.dtbMaster.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dtbMaster.Location = new System.Drawing.Point(0, 491);
            this.dtbMaster.Name = "dtbMaster";
            this.dtbMaster.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtbMaster.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtbMaster.RowHeadersVisible = false;
            this.dtbMaster.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtbMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtbMaster.Size = new System.Drawing.Size(548, 194);
            this.dtbMaster.TabIndex = 31;
            this.dtbMaster.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtbMaster_RowEnter);
            this.dtbMaster.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dtbMaster_MouseClick);
            this.dtbMaster.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dtbMaster_MouseDoubleClick);
            this.dtbMaster.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtbMaster_RowHeaderMouseDoubleClick);
            this.dtbMaster.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtbMaster_CurrentCellDirtyStateChanged);
            this.dtbMaster.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtbMaster_DataError);
            this.dtbMaster.DataSourceChanged += new System.EventHandler(this.dtbMaster_DataSourceChanged);
            this.dtbMaster.SelectionChanged += new System.EventHandler(this.dtbMaster_SelectionChanged);
            this.dtbMaster.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dtbMaster_RowStateChanged);
            this.dtbMaster.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtbMaster_CellContentClick);
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.Width = 25;
            // 
            // ContMenu
            // 
            this.ContMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.unToolStripMenuItem,
            this.authorizedToolStripMenuItem});
            this.ContMenu.Name = "ContMenu";
            this.ContMenu.Size = new System.Drawing.Size(135, 92);
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.selectToolStripMenuItem.Text = "Select";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // unToolStripMenuItem
            // 
            this.unToolStripMenuItem.Name = "unToolStripMenuItem";
            this.unToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.unToolStripMenuItem.Text = "Un-Select All";
            this.unToolStripMenuItem.Click += new System.EventHandler(this.unToolStripMenuItem_Click);
            // 
            // authorizedToolStripMenuItem
            // 
            this.authorizedToolStripMenuItem.Name = "authorizedToolStripMenuItem";
            this.authorizedToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.authorizedToolStripMenuItem.Text = "Authorized";
            this.authorizedToolStripMenuItem.Click += new System.EventHandler(this.authorizedToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Unauthorized,
            this.toolStripStatusLabel1,
            this.authorized,
            this.toolStripStatusLabel3,
            this.Delete,
            this.toolStripStatusLabel2,
            this.History,
            this.toolStripStatusLabel5});
            this.statusStrip1.Location = new System.Drawing.Point(0, 469);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(548, 22);
            this.statusStrip1.TabIndex = 200;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Unauthorized
            // 
            this.Unauthorized.BackColor = System.Drawing.Color.White;
            this.Unauthorized.ForeColor = System.Drawing.Color.Black;
            this.Unauthorized.Name = "Unauthorized";
            this.Unauthorized.Size = new System.Drawing.Size(19, 17);
            this.Unauthorized.Text = "    ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(112, 17);
            this.toolStripStatusLabel1.Text = "Un Authorized Record";
            // 
            // authorized
            // 
            this.authorized.ActiveLinkColor = System.Drawing.Color.Blue;
            this.authorized.BackColor = System.Drawing.Color.White;
            this.authorized.ForeColor = System.Drawing.Color.Black;
            this.authorized.Name = "authorized";
            this.authorized.Size = new System.Drawing.Size(19, 17);
            this.authorized.Text = "    ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(96, 17);
            this.toolStripStatusLabel3.Text = "Authorized Record";
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.White;
            this.Delete.ForeColor = System.Drawing.Color.Black;
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(19, 17);
            this.Delete.Tag = "    ";
            this.Delete.Text = "    ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(81, 17);
            this.toolStripStatusLabel2.Text = "Deleted Record";
            // 
            // History
            // 
            this.History.BackColor = System.Drawing.Color.White;
            this.History.ForeColor = System.Drawing.Color.Black;
            this.History.Name = "History";
            this.History.Size = new System.Drawing.Size(19, 17);
            this.History.Text = "    ";
            this.History.Click += new System.EventHandler(this.toolStripStatusLabel4_Click);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(41, 17);
            this.toolStripStatusLabel5.Text = "History";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dtbHistory
            // 
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGoldenrod;
            this.dtbHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtbHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(84)))), ((int)(((byte)(150)))));
            this.dtbHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtbHistory.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtbHistory.Location = new System.Drawing.Point(0, 605);
            this.dtbHistory.Name = "dtbHistory";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Orange;
            this.dtbHistory.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtbHistory.Size = new System.Drawing.Size(548, 80);
            this.dtbHistory.TabIndex = 701;
            this.dtbHistory.Visible = false;
            this.dtbHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtbHistory_CellContentClick);
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.White;
            this.txtStatus.DataField = null;
            this.txtStatus.Location = new System.Drawing.Point(492, -1);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(56, 20);
            this.txtStatus.TabIndex = 702;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(548, 685);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dtbHistory);
            this.Controls.Add(this.dtbMaster);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "BaseForm";
            this.Tag = "s";
            this.Text = "W";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.RegionChanged += new System.EventHandler(this.BaseForm_RegionChanged);
            this.Enter += new System.EventHandler(this.BaseForm_Enter);
            this.Leave += new System.EventHandler(this.BaseForm_Leave);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BaseForm_KeyPress);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.BaseForm_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.dtbMaster)).EndInit();
            this.ContMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtbHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dtbMaster;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.ContextMenuStrip ContMenu;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authorizedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel Unauthorized;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel authorized;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel Delete;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel History;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dtbHistory;
        public cstTextBox txtStatus;
        public System.Windows.Forms.StatusStrip statusStrip1;
    }
}