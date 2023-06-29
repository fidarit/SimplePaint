using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePaint
{
    internal class EllipseTool : Tool
    {
        public EllipseTool(ZoomPictureBox pictureBox) : base(pictureBox)
        {

        }

        protected override void OnMouseUp(Graphics g)
        {
            g.DrawEllipse(pen, GetRectangle());
        }
        protected override void Paint(Graphics g)
        {
            g.DrawEllipse(pen, GetRectangle());
        }
    }
}
