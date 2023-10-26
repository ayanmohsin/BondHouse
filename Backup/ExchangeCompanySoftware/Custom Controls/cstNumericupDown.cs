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
    public partial class cstNumericupDown : NumericUpDown
    {

        public cstNumericupDown()
        {
            InitializeComponent();
        }

        public string DataField { get; set; }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void cstNumericupDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void cstNumericupDown_Enter(object sender, EventArgs e)
        {
            this.Select(0, this.ToString().Length);
        }

        private void cstNumericupDown_MouseClick(object sender, MouseEventArgs e)
        {
            this.Select(0, this.ToString().Length);
        }
    }
}
