namespace ExchangeCompanySoftware
{
    partial class cstNumericupDown
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cstNumericupDown
            // 
            this.DecimalPlaces = 4;
            this.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cstNumericupDown_MouseClick);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cstNumericupDown_KeyPress);
            this.Enter += new System.EventHandler(this.cstNumericupDown_Enter);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
