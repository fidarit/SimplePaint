using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayersIDK
{
    public class Canvas
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Size Size => new Size(Width, Height);

        public readonly List<Layer> Layers = new List<Layer>();

        public int SelectedLayerIndex = -1;

        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Bitmap Draw()
        {
            Bitmap result = new Bitmap(Width, Height);

            using (Graphics graphics = Graphics.FromImage(result))
            {
                foreach (var layer in Layers)
                {
                    if(layer.IsEnabled)
                    {
                        var layerBitmap = layer.Draw();
                        graphics.DrawImage(layerBitmap, layer.Rectangle);
                    }
                }
            }

            return result;
        }
    }
}
