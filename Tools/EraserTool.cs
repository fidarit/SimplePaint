using SimplePaint.Controls;
using System.Drawing.Drawing2D;

namespace SimplePaint.Tools
{
    public class EraserTool : Tool
    {
        public EraserTool(ZoomPictureBox pictureBox) : base(pictureBox)
        {
            pen = new Pen(Color.Transparent, 10)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };
        }

        protected override bool CanUse(MouseEventArgs e)
        {
            return e.Button == MouseButtons.Right || base.CanUse(e);
        }

        private void Erase(Graphics g, Point from, Point to)
        {
            var mode = g.CompositingMode;
            g.CompositingMode = CompositingMode.SourceCopy;

            g.DrawLine(pen, from, to);
            g.CompositingMode = mode;
        }

        protected override void OnMouseMove(Graphics g)
        {
            Erase(g, prevPoint, newPoint);
            MainForm.Instance.Redraw();
        }

        protected override void Paint(Graphics g)
        {
            float ringDiameter = pen.Width;
            float ringRadius = pen.Width / 2;

            g.DrawEllipse(Pens.Black, newPoint.X - ringRadius, newPoint.Y - ringRadius, ringDiameter, ringDiameter);
        }
    }
}

