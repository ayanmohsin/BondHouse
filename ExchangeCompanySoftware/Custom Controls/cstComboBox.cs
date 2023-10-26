using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExchangeCompanySoftware
{
    public partial class cstComboBox : ComboBox
    {
        public cstComboBox()
        {
            InitializeComponent();
            this.BackColor = Color.NavajoWhite;
        }
        public string DataField { get; set; }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void cstComboBox_KeyPress(object sender, KeyPressEventArgs  e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void cstComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
         
        }

        private void cstComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            

        }
    }
}
