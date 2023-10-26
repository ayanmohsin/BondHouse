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
    public partial class cstTreeView : Control
    {
        public cstTreeView()
        {
            InitializeComponent();
        }
        public string FormName{ get; set; }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
