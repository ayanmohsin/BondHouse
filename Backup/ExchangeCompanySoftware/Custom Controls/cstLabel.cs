using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ExchangeCompanySoftware.Custom_Controls
{
    public partial class cstLabel : Label
    {
        private Color cLeft;
        private Color cRight;

        public Color BeginColor
        {
            get
            {
                return cLeft;
            }
            set
            {
                cLeft = value;
            }
        }
        public Color EndColor
        {
            get
            {
                return cRight;
            }
            set
            {
                cRight = value;
            }
        }

        public cstLabel()
        {
            InitializeComponent();

            cLeft = SystemColors.ActiveCaption;
            cRight = SystemColors.Control;

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            //base.OnPaint(pe);
            // declare linear gradient brush for fill background of label
            LinearGradientBrush GBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(this.Width, 0), cLeft, cRight);
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            // Fill with gradient 
            pe.Graphics.FillRectangle(GBrush, rect);

            // draw text on label
            SolidBrush drawBrush = new SolidBrush(this.ForeColor);
            StringFormat sf = new StringFormat();
            // align with center
            sf.Alignment = StringAlignment.Center;
            // set rectangle bound text
            RectangleF rectF = new
            RectangleF(0, this.Height / 2 - Font.Height / 2, this.Width, this.Height);
            // output string
            pe.Graphics.DrawString(this.Text, this.Font, drawBrush, rectF, sf);

        }
    }
}
