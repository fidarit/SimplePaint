using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePaint
{
    public class ImageLayer : LayerBasic
    {
        private Image image;

        public Rectangle Rectangle { get; private set; }

        public ImageLayer(Canvas ownCanvas, Image image) : base(ownCanvas)
        {
            this.image = image;

            var yZoom = (float)ownCanvas.Height / image.Height;
            var xZoom = (float)ownCanvas.Width / image.Width;
            var zoom = Math.Min(xZoom, yZoom);

            Rectangle = new Rectangle(Point.Empty, (image.Size * zoom).ToSize());
            Render();
        }

        public override void Render()
        {
            using (Graphics graphics = Graphics.FromImage(ResultImage))
            {
                graphics.Clear(Color.Transparent);
                graphics.DrawImage(image, Rectangle);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            image.Dispose();
        }
    }
}
