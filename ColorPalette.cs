using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimplePaint
{
    public class ColorPalette : Control
    {
        private int paletteWidth = 256;
        private int paletteHeight = 256;
        private int colorBoxSize = 20;

        private int selectedX = -1;
        private int selectedY = -1;
        private float selectedBrightness = 0.5f;
        public Color selectedColor = Color.Transparent;

        public event EventHandler<ColorSelectedEventArgs> ColorSelected;

        public ColorPalette()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            paletteWidth = ClientSize.Width - colorBoxSize - 10;
            paletteHeight = ClientSize.Height - colorBoxSize;

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                for (int x = 0; x < paletteWidth; x++)
                {
                    for (int y = 0; y < paletteHeight; y++)
                    {
                        brush.Color = GetColor(x, y, selectedBrightness);
                        g.FillRectangle(brush, x, y, 1, 1);
                    }
                }
            }

            Rectangle colorRect = new Rectangle(0, paletteHeight + 5, paletteWidth, colorBoxSize);
            using (SolidBrush brush = new SolidBrush(selectedColor))
            {
                g.FillRectangle(brush, colorRect);
            }

            if (selectedX != -1 && selectedY != -1)
            {
                Rectangle ringRect = new Rectangle(selectedX - 5, selectedY - 5, 10, 10);
                g.DrawEllipse(Pens.Black, ringRect);
            }

            Rectangle brightnessSliderRect = new Rectangle(paletteWidth + 5, 1, colorBoxSize, paletteHeight);

            using (LinearGradientBrush gradientBrush = new LinearGradientBrush(brightnessSliderRect, Color.White, Color.Black, LinearGradientMode.Vertical))
            {
                g.FillRectangle(gradientBrush, brightnessSliderRect);
            }
            g.FillRectangle(Brushes.White, brightnessSliderRect.X + (int)(selectedBrightness * paletteWidth), brightnessSliderRect.Y, 3, colorBoxSize);
            g.FillRectangle(Brushes.Black, brightnessSliderRect.X, brightnessSliderRect.Y + (int)((1 - selectedBrightness) * paletteHeight), colorBoxSize, 3);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                OnMouseDown(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.X < paletteWidth && e.Y < paletteHeight)
            {
                selectedX = e.X;
                selectedY = e.Y;

                selectedColor = GetColor(selectedX, selectedY, selectedBrightness);
                ColorSelected?.Invoke(this, new ColorSelectedEventArgs(selectedColor));
            }
            else if (e.X >= paletteWidth + 5 && e.X < paletteWidth + 5 + colorBoxSize &&
                     e.Y >= 5 && e.Y < paletteHeight + 5)
            {
                selectedBrightness = 1f - (float)(e.Y - 5) / paletteHeight;
                selectedColor = GetColor(selectedX, selectedY, selectedBrightness);
                ColorSelected?.Invoke(this, new ColorSelectedEventArgs(selectedColor));
            }

            Invalidate();
        }

        public void SetColor(Color color)
        {
            if (selectedColor == color)
                return;

            HSLFromColor(color, out float hue, out float saturation, out float luminosity);

            selectedX = (int)(hue * paletteWidth);
            selectedY = (int)(saturation * paletteHeight);
            selectedBrightness = luminosity;
            selectedColor = color;
            Invalidate();
        }

        private Color GetColor(float x, float y, float brightness)
        {
            float hue = x / paletteWidth;
            float saturation = y / paletteHeight;

            Color color = ColorFromHSL(hue, saturation, brightness);
            return Color.FromArgb(color.R, color.G, color.B);
        }

        private Color ColorFromHSL(float hue, float saturation, float luminosity)
        {
            if (saturation == 0)
            {
                int value = (int)(luminosity * 255);
                return Color.FromArgb(value, value, value);
            }
            else
            {
                float q = luminosity < 0.5f 
                    ? luminosity * (1 + saturation) 
                    : luminosity + saturation - luminosity * saturation;
                float p = 2 * luminosity - q;
                float[] rgb = new float[3] { hue + 1 / 3f, hue, hue - 1 / 3f };

                for (int i = 0; i < 3; i++)
                {
                    if (rgb[i] < 0)
                        rgb[i] += 1;
                    if (rgb[i] > 1)
                        rgb[i] -= 1;

                    if (6 * rgb[i] < 1)
                        rgb[i] = p + (q - p) * 6 * rgb[i];
                    else if (2 * rgb[i] < 1)
                        rgb[i] = q;
                    else if (3 * rgb[i] < 2)
                        rgb[i] = p + (q - p) * 6 * (2 / 3f - rgb[i]);
                    else
                        rgb[i] = p;
                }

                int red = (int)(rgb[0] * 255);
                int green = (int)(rgb[1] * 255);
                int blue = (int)(rgb[2] * 255);

                return Color.FromArgb(red, green, blue);
            }
        }

        private void HSLFromColor(Color color, out float hue, out float saturation, out float luminosity)
        {
            float r = color.R / 255f;
            float g = color.G / 255f;
            float b = color.B / 255f;

            float max = Math.Max(r, Math.Max(g, b));
            float min = Math.Min(r, Math.Min(g, b));

            if (max == min)
                hue = 0f;
            else if (max == r)
                hue = ((g - b) / (max - min) + 6) % 6 / 6f;
            else if (max == g)
                hue = ((b - r) / (max - min) + 2) / 6f;
            else
                hue = ((r - g) / (max - min) + 4) / 6f;

            luminosity = (max + min) / 2f;

            if (luminosity == 0 || max == min)
                saturation = 0f;
            else if (luminosity <= 0.5f)
                saturation = (max - min) / (2 * luminosity);
            else
                saturation = (max - min) / (2 - 2 * luminosity);
        }
    }

    public class ColorSelectedEventArgs : EventArgs
    {
        public Color SelectedColor { get; private set; }

        public ColorSelectedEventArgs(Color color)
        {
            SelectedColor = color;
        }
    }
}
