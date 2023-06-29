using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePaint
{
    internal class LineTool : Tool
    {
        public LineTool(ZoomPictureBox pictureBox) : base(pictureBox)
        {

        }
        protected override void OnMouseUp(Graphics g)
        {
            g.DrawLine(pen, startPoint, newPoint);
        }
        protected override void Paint(Graphics g)
        {
            g.DrawLine(pen, startPoint, newPoint);
        }
    }
}
