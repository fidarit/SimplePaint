using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayersIDK
{
    public class Layer
    {
        private readonly Canvas ownCanvas;

        public string Name = "Слой";
        public bool IsEnabled = true;

        public Rectangle Rectangle { get; protected set; }


        public Layer(Canvas ownCanvas)
        {
            this.ownCanvas = ownCanvas;
            if (!ownCanvas.Layers.Contains(this))
                ownCanvas.Layers.Add(this);

            Rectangle = new Rectangle(Point.Empty, ownCanvas.Size);
        }

        public virtual Bitmap Draw()
        {
            return new Bitmap(Rectangle.Width, Rectangle.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
    }
}
