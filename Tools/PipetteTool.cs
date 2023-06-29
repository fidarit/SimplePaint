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
            int x = Math.Clamp(newPoint.X, 0, pictureBox.Width);
            int y = Math.Clamp(newPoint.Y, 0, pictureBox.Height);

            Color pickedColor = pictureBox.Image.GetPixel(x, y);
            Form1.Instance.SetColor(pickedColor);
        }
    }
}
