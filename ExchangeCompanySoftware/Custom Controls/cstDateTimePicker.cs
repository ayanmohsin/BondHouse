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
    public partial class cstDateTimePicker : DateTimePicker
    {
        public cstDateTimePicker()
        {
            InitializeComponent();
        }
        public string DataField { get; set; }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
