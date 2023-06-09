using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayersIDK
{
    public class ImageLayer : Layer
    {
        private Image image;

        public ImageLayer(Canvas ownCanvas, Image image) : base(ownCanvas)
        {
            this.image = image;
            Rectangle = new Rectangle(Point.Empty, image.Size);
        }

        public override Bitmap Draw()
        {
            return new Bitmap(image);
        }
    }
}
