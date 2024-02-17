using SimplePaint.Controls;
using SimplePaint.Models.Layers;

namespace SimplePaint.Tools
{
    public enum ToolType
    {
        None,
        Pen,
        Erase,
        Rect,
        RoundedRect,
        Ellipse,
        Line,
        Fill,
        Pipette
    }

    public abstract class Tool
    {
        public static Tool Instance { get; protected set; }
        public static int Size { get; set; } = 10;

        public bool IsActive { get; protected set; } = false;
        public bool IsPainting { get; protected set; } = false;

        protected ZoomPictureBox pictureBox;
        protected Point newPoint, startPoint, prevPoint; //координаты карандаша, ластика
        protected Pen pen = new Pen(Color.Black, 1);//карандаш

        protected static Bitmap TargetImage { get; private set; }

        private static Graphics g;

        public Tool(ZoomPictureBox pictureBox)
        {
            this.pictureBox = pictureBox;

            Activate();
        }

        public void Activate()
        {
            if (Instance != this && Instance != null && !(Instance is EraserTool))
                Instance.Deactivate();

            Instance = this;

            if (IsActive)
                return;

            pictureBox.MouseDown += OnMouseDown;
            pictureBox.MouseUp += OnMouseUp;
            pictureBox.MouseMove += OnMouseMove;
            pictureBox.Paint += Paint;

            IsActive = true;
        }

        public void Deactivate()
        {
            if (!IsActive)
                return;

            pictureBox.MouseDown -= OnMouseDown;
            pictureBox.MouseUp -= OnMouseUp;
            pictureBox.MouseMove -= OnMouseMove;
            pictureBox.Paint -= Paint;

            Instance = null;
            IsActive = false;
        }

        protected virtual bool CanUse(MouseEventArgs e)
        {
            return e.Button == MouseButtons.Left && Instance == this;
        }

        protected void InitGraphics()
        {
            var layer = MainForm.Instance.Canvas.GetLayerToDraw();
            if (layer == null)
                return;

            if (TargetImage != layer.SourceImage)
            {
                TargetImage = (Bitmap)layer.SourceImage;
                g?.Dispose();
                g = Graphics.FromImage(layer.SourceImage);

                if (layer is ImageLayer imageLayer)
                {
                    g.ScaleTransform(1f / imageLayer.Zoom, 1f / imageLayer.Zoom);
                    g.SetClip(imageLayer.Rectangle);
                }
            }
        }

        protected Rectangle GetRectangle()
        {
            int width = Math.Abs(newPoint.X - startPoint.X);
            int height = Math.Abs(newPoint.Y - startPoint.Y);

            int x = Math.Min(newPoint.X, startPoint.X);
            int y = Math.Min(newPoint.Y, startPoint.Y);

            return new Rectangle(x, y, width, height);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                pictureBox.AllowUserDrag = true;

            else
            {
                startPoint = pictureBox.ClientToImagePoint(e.Location);
                newPoint = startPoint;
                prevPoint = startPoint;

                if (CanUse(e))
                {
                    pictureBox.FastMode = true;
                    pictureBox.AllowUserDrag = false;
                    IsPainting = true;

                    if (!(this is EraserTool))
                    {
                        pen.Color = MainForm.Instance.ActiveColor;
                    }

                    pen.Width = Size;

                    InitGraphics();
                    OnMouseDown(g);

                    OnMouseMove(sender, e);
                }
            }
        }
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                pictureBox.AllowUserDrag = false;
            else
                pictureBox.AllowUserDrag = true;


            if (IsPainting)
            {
                IsPainting = false;
                newPoint = pictureBox.ClientToImagePoint(e.Location);
                pictureBox.FastMode = false;
                OnMouseUp(g);

                MainForm.Instance.Redraw();
            }
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            prevPoint = newPoint;
            newPoint = pictureBox.ClientToImagePoint(e.Location);

            if (IsPainting && prevPoint != newPoint)
            {
                OnMouseMove(g);
                pictureBox.Invalidate();
            }
        }
        private void Paint(object sender, PaintEventArgs e)
        {
            if (IsPainting)
            {
                Paint(e.Graphics);
            }
        }
        protected virtual void OnMouseDown(Graphics g) { }
        protected virtual void OnMouseUp(Graphics g) { }
        protected virtual void OnMouseMove(Graphics g) { }
        protected virtual void Paint(Graphics g) { }
    }
}
