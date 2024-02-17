using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace SimplePaint.Layers
{
    public class ImageLayer : LayerBasic
    {
        private Image image;

        public float Zoom { get; private set; }
        public Rectangle Rectangle { get; private set; }
        public override Image SourceImage => image;

        public ImageLayer(Canvas ownCanvas, Image image) : base(ownCanvas)
        {
            this.image = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(this.image))
            {
                g.CompositingMode = CompositingMode.SourceCopy;
                g.DrawImage(image, 0, 0, image.Width, image.Height);
            }

            var yZoom = (float)ownCanvas.Height / image.Height;
            var xZoom = (float)ownCanvas.Width / image.Width;
            Zoom = Math.Min(xZoom, yZoom);

            Rectangle = new Rectangle(0, 0, (int)Math.Round(image.Size.Width * Zoom), (int)Math.Round(image.Height * Zoom));
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
    }
}
