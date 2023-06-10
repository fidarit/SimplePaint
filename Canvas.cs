using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        public Size Size => new Size(Width, Height);
        public IReadOnlyList<LayerBasic> Layers => layers;

        public readonly Bitmap ResultImage;

        public int SelectedLayerIndex = -1;

        private Bitmap preparedBackground;
        private readonly List<LayerBasic> layers = new List<LayerBasic>();

        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;
            ResultImage = CreateNewBitmap();

            RenderBackground();
            Render();
        }

        public void AddLayer(LayerBasic layer)
        {
            layers.Add(layer);
        }

        public void RemoveLayer(int index)
        {
            layers[index].Dispose();
            layers.RemoveAt(index);
        }

        public LayerBasic GetLayerToDraw()
        {
            if (Layers.Count == 0)
            {
                SelectedLayerIndex = 0;
                return new Layer(this);
            }

            if (SelectedLayerIndex < 0 || SelectedLayerIndex >= Layers.Count)
                SelectedLayerIndex = 0;

            LayerBasic result = Layers[SelectedLayerIndex];
            if (result is not Layer)
            {
                result = new Layer(this);
                SelectedLayerIndex = Layers.Count - 1;
            }

            return result;
        }

        public Bitmap CreateNewBitmap()
        {
            return new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
        }

        public Bitmap Render(bool force = false)
        {
            if(force)
            {
                foreach (var layer in Layers)
                    layer.Render();
            }

            using (Graphics graphics = Graphics.FromImage(ResultImage))
            {
                graphics.DrawImage(preparedBackground, 0, 0);

                foreach (var layer in Layers)
                {
                    if(layer.IsEnabled)
                        graphics.DrawImage(layer.ResultImage, 0, 0);
                }
            }

            return ResultImage;
        }
        
        public Bitmap FinalRender()
        {
            foreach (var layer in Layers)
                layer.Render();

            using (Graphics graphics = Graphics.FromImage(ResultImage))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.Clear(Color.Transparent);

                foreach (var layer in Layers)
                {
                    if(layer.IsEnabled)
                        graphics.DrawImage(layer.ResultImage, 0, 0);
                }
            }

            return ResultImage;
        }

        private void RenderBackground()
        {
            preparedBackground = CreateNewBitmap();
            int cellSize = 8;

            using (Graphics graphics = Graphics.FromImage(preparedBackground))
            using (var brushWhite = new SolidBrush(Color.White))
            using (var brushLightGray = new SolidBrush(Color.LightGray))
            {
                for (int y = 0; y < Height; y += cellSize)
                {
                    for (int x = 0; x < Width; x += cellSize)
                    {
                        Brush brush = (x / cellSize + y / cellSize) % 2 == 0 ? brushWhite : brushLightGray;

                        graphics.FillRectangle(brush, x, y, cellSize, cellSize);
                    }
                }
            }
        }
    }
}
