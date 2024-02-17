using SimplePaint.Controls;

namespace SimplePaint
{
    internal class LineTool : Tool
    {
        public LineTool(ZoomPictureBox pictureBox) : base(pictureBox)
        {

        }
        protected override void OnMouseUp(Graphics g)
        {
            g.DrawLine(pen, startPoint, newPoint);
        }
        protected override void Paint(Graphics g)
        {
            g.DrawLine(pen, startPoint, newPoint);
        }
    }
}
