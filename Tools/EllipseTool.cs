using SimplePaint.Controls;

namespace SimplePaint
{
    internal class EllipseTool : Tool
    {
        public EllipseTool(ZoomPictureBox pictureBox) : base(pictureBox)
        {

        }

        protected override void OnMouseUp(Graphics g)
        {
            g.DrawEllipse(pen, GetRectangle());
        }
        protected override void Paint(Graphics g)
        {
            g.DrawEllipse(pen, GetRectangle());
        }
    }
}
