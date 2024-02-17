using SimplePaint.Controls;
using System.Drawing.Drawing2D;

namespace SimplePaint.Tools
{
    internal class RoundedRectangleTool : Tool
    {
        public RoundedRectangleTool(ZoomPictureBox pictureBox) : base(pictureBox)
        {

        }

        protected override void OnMouseUp(Graphics g)
        {
            DrawRoundedRectangle(g, pen, GetRectangle());
        }
        protected override void Paint(Graphics g)
        {
            DrawRoundedRectangle(g, pen, GetRectangle());
        }

        public void DrawRoundedRectangle(Graphics graphics, Pen pen, Rectangle rectangle)
        {
            float minSize = Math.Max(0.5f, Math.Min(rectangle.Width, rectangle.Height));
            float radius = Math.Min(0.5f * minSize, 2f * (float)Math.Sqrt(minSize));
            float diameter = 2 * radius;

            if (radius > 0.5f)
            {
                using (GraphicsPath path = new GraphicsPath(FillMode.Winding))
                {
                    path.AddArc(rectangle.Left, rectangle.Top, diameter, diameter, 180, 90); //левый верхний угол
                    path.AddArc(rectangle.Right - diameter, rectangle.Top, diameter, diameter, 270, 90); //правый верхний угол
                    path.AddArc(rectangle.Right - diameter, rectangle.Bottom - diameter, diameter, diameter, 0, 90); //правый нижний угол
                    path.AddArc(rectangle.Left, rectangle.Bottom - diameter, diameter, diameter, 90, 90); //левый нижний угол
                    path.CloseFigure();

                    pen.LineJoin = LineJoin.Miter;

                    graphics.DrawPath(pen, path);
                }
            }
            else
            {
                pen.LineJoin = LineJoin.Round;

                graphics.DrawRectangle(pen, rectangle);
            }
        }
    }
}
