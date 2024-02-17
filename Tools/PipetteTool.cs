using SimplePaint.Controls;

namespace SimplePaint.Tools
{
    internal class PipetteTool : Tool
    {
        public PipetteTool(ZoomPictureBox pictureBox) : base(pictureBox)
        {

        }

        protected override void OnMouseUp(Graphics g)
        {
            int x = Math.Clamp(newPoint.X, 0, pictureBox.Width);
            int y = Math.Clamp(newPoint.Y, 0, pictureBox.Height);

            Color pickedColor = pictureBox.Image.GetPixel(x, y);
            MainForm.Instance.SetColor(pickedColor);
        }
    }
}
