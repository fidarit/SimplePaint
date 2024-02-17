using SimplePaint.Models.Layers;
using System.Collections.Concurrent;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace SimplePaint.Models
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

            if (SelectedLayerIndex != index)
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
            if (result?.IsEnabled == true && result is Layer)
                return result;

            return new Layer(this);
        }

        public Bitmap CreateNewBitmap()
        {
            return new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
        }

        public Bitmap Render(bool force = false)
        {
            if (force)
                GetSelectedLayer()?.Render();

            var bitmaps = new List<Bitmap> { preparedBackground };

            foreach (var layer in Layers)
            {
                if (layer.IsEnabled)
                    bitmaps.Add(layer.ResultImage);
            }

            return MergeBitmaps(bitmaps);
        }

        private Bitmap MergeBitmaps(List<Bitmap> bitmaps)
        {
            for (int i = 0; i < bitmaps.Count; i++)
                bitmaps[i] = (Bitmap)bitmaps[i].Clone();

            while (bitmaps.Count > 1)
            {
                var mergedBitmaps = new ConcurrentDictionary<int, Bitmap>();

                Parallel.For(0, bitmaps.Count / 2, i =>
                {
                    mergedBitmaps[i] = MergeTwoBitmaps(bitmaps[i * 2], bitmaps[i * 2 + 1]);
                });

                if (bitmaps.Count % 2 != 0)
                    mergedBitmaps[bitmaps.Count / 2] = bitmaps.Last();

                bitmaps = mergedBitmaps.Values.ToList();
            }

            return bitmaps.First();
        }

        private Bitmap MergeTwoBitmaps(Bitmap bitmap1, Bitmap bitmap2)
        {
            Bitmap mergedBitmap = (Bitmap)bitmap1.Clone();

            using (Graphics graphics = Graphics.FromImage(mergedBitmap))
            {
                graphics.DrawImageUnscaled(bitmap2, 0, 0);
            }

            bitmap1.Dispose();
            bitmap2.Dispose();

            return mergedBitmap;
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
                    if (layer.IsEnabled)
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
