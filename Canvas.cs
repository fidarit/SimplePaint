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
        public int SelectedLayerIndex { get; private set; } = -1;

        public Size Size => new Size(Width, Height);
        public IReadOnlyList<LayerBasic> Layers => layers;

        public readonly Bitmap ResultImage;

        public Action<int> SelectedLayerChanged;

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
            SelectLayer(layers.Count - 1);
        }

        public void RemoveLayer(int index)
        {
            layers[index].Dispose();
            layers.RemoveAt(index);
            SelectLayer(index);
        }

        public void SelectLayer(int index)
        {
            if (index >= layers.Count || index < 0)
                index = layers.Count - 1;

            if(SelectedLayerIndex != index)
            {
                SelectedLayerIndex = index;
                SelectedLayerChanged?.Invoke(index);
            }
        }

        public LayerBasic GetSelectedLayer()
        {
            if (SelectedLayerIndex >= 0 && SelectedLayerIndex < Layers.Count)
                return Layers[SelectedLayerIndex];
            else
                return null;
        }

        public LayerBasic GetLayerToDraw()
        {
            LayerBasic result = GetSelectedLayer();
            if (result == null || result is not Layer)
                result = new Layer(this);

            return result;
        }

        public Bitmap CreateNewBitmap()
        {
            return new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
        }

        public Bitmap Render(bool force = false)
        {
            if(force)
                GetSelectedLayer()?.Render();

            using (Graphics graphics = Graphics.FromImage(ResultImage))
            {
                graphics.DrawImageUnscaled(preparedBackground, 0, 0);

                foreach (var layer in Layers)
                {
                    if (layer.IsEnabled)
                        graphics.DrawImageUnscaled(layer.ResultImage, 0, 0);
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
                        graphics.DrawImageUnscaled(layer.ResultImage, 0, 0);
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
