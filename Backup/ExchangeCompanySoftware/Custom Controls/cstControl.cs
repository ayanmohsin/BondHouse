using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExchangeCompanySoftware.Custom_Controls
{
    public partial class cstControl : Control
    {
        public cstControl()
        {
            InitializeComponent();
        }
        public string DataField { get; set; }
        public string SelectedText { get; set; }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
