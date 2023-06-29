using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePaint
{
    internal class PipetteTool : Tool
    {
        public PipetteTool(ZoomPictureBox pictureBox) : base(pictureBox)
        {

        }

        protected override void OnMouseUp(Graphics g)
        {
            Color pickedColor = pictureBox.Image.GetPixel(newPoint.X, newPoint.Y);
            Form1.Instance.ActiveColor = pickedColor;
        }
    }
}
