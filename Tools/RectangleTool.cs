using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SimplePaint.Controls;

namespace SimplePaint
{
    internal class RectangleTool : Tool
    {
        public RectangleTool(ZoomPictureBox pictureBox) : base(pictureBox)
        {
        }

        protected override void OnMouseUp(Graphics g)
        {
            g.DrawRectangle(pen, GetRectangle());
        }

        protected override void Paint(Graphics g)
        {
            g.DrawRectangle(pen, GetRectangle());
        }
    }
}
