using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ExchangeCompanySoftware
{
    public partial class cstTextBox : TextBox
    {
        public cstTextBox()
        {
            InitializeComponent();
            this.BackColor = Color.White;      
        }
        public string DataField { get; set; }
        protected override void OnPaint(PaintEventArgs pe)
        {
                 
        }
        private void cstTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void cstTextBox_Enter(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void cstTextBox_Leave(object sender, EventArgs e)
        {
            this.BackColor = Color.NavajoWhite;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
    }
}
