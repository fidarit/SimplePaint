using SimplePaint.Controls;

namespace SimplePaint
{
    internal class FillTool : Tool
    {
        public FillTool(ZoomPictureBox pictureBox) : base(pictureBox)
        {

        }

        private bool CompareColors(Color a, Color b)
        {
            return a.R == b.R
                && a.G == b.G
                && a.B == b.B
                && a.A == b.A;
        }

        protected override void OnMouseUp(Graphics g)
        {
            int x = newPoint.X, y = newPoint.Y;
            int Width = TargetImage.Width, Height = TargetImage.Height;

            Color newColor = MainForm.Instance.ActiveColor;
            Color oldColor = TargetImage.GetPixel(x, y);
            if (CompareColors(newColor, oldColor))
                return;

            Stack<Point> pixels = new Stack<Point>();

            AddPoint(x, y);

            while (pixels.Count > 0)
            {
                Point point = pixels.Pop();
                x = point.X;
                y = point.Y;

                if (!CompareColors(TargetImage.GetPixel(x, y), oldColor))
                    continue;

                TargetImage.SetPixel(x, y, newColor);

                AddPoint(x - 1, y);
                AddPoint(x + 1, y);
                AddPoint(x, y - 1);
                AddPoint(x, y + 1);
            }

            void AddPoint(int X, int Y)
            {
                if (X < 0 || Y < 0 || X >= Width || Y >= Height)
                    return;

                pixels.Push(new Point(X, Y));
            }
        }
    }
}
