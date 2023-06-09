using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayersIDK
{
    public class Canvas
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Bitmap ResultImage { get; protected set; }

        public Size Size => new Size(Width, Height);

        public readonly List<Layer> Layers = new List<Layer>();

        public int SelectedLayerIndex = -1;

        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Bitmap CreateNewBitmap()
        {
            return new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
        }

        public Bitmap Render(bool force = false)
        {
            ResultImage = CreateNewBitmap();

            if(force)
            {
                foreach (var layer in Layers)
                    layer.Render();
            }

            using (Graphics graphics = Graphics.FromImage(ResultImage))
            {
                foreach (var layer in Layers)
                {
                    if(layer.IsEnabled)
                        graphics.DrawImage(layer.ResultImage, 0, 0);
                }
            }

            return ResultImage;
        }
    }
}
