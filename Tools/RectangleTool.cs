using SimplePaint.Controls;

namespace SimplePaint
{
    internal class RectangleTool : Tool
    {
        public RectangleTool(ZoomPictureBox pictureBox) : base(pictureBox)
        {
        }

        protected override void OnMouseUp(Graphics g)
        {
            g.DrawRectangle(pen, GetRectangle());
        }

        protected override void Paint(Graphics g)
        {
            g.DrawRectangle(pen, GetRectangle());
        }
    }
}
