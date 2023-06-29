using System;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace SimplePaint
{
    enum Tools
    {
        None,
        Pen,
        Erase,
        Rect,
        RoundedRect,
        Ellipse,
        Line
    }

    public partial class Form1 : Form
    {
        public Canvas Canvas { get; set; }

        Bitmap gTarget;
        Graphics g;
        bool paint = false; //событие рисования
        Point newPoint, oldPoint; //координаты карандаша, ластика
        Pen pen = new Pen(Color.Black, 1); //карандаш
        Pen erase = new Pen(Color.Transparent, 10); //ластик
        Tools tools = Tools.None;

        public Form1()
        {
            InitializeComponent();

            Canvas = new Canvas(1024, 768);
            Canvas.SelectedLayerChanged += layerIndex =>
            {
                RedrawIcons();
                listView1.SelectedIndices.Clear();

                if (layerIndex >= 0)
                    listView1.SelectedIndices.Add(layerIndex);
            };
        }

        private void Erase(Point from, Point to)
        {
            var mode = g.CompositingMode;
            g.CompositingMode = CompositingMode.SourceCopy;

            DrawPoint(erase, from);
            DrawPoint(erase, to);
            g.DrawLine(erase, from, to);

            g.CompositingMode = mode;
        }

        private void DrawLine(Pen pen, Point from, Point to)
        {
            if (pen.Width > 2)
            {
                DrawPoint(pen, from);
                DrawPoint(pen, to);
            }
            g.DrawLine(pen, from, to);
        }

        private void DrawPoint(Pen pen, Point point)
        {
            using (Brush brush = new SolidBrush(pen.Color))
            {
                int radius = (int)(pen.Width / 2);
                int size = radius * 2;
                int x = point.X - radius;
                int y = point.Y - radius;
                g.FillEllipse(brush, x, y, size, size);
            }
        }

        public void Redraw()
        {
            zoomPictureBox1.Image = Canvas.Render(true);
        }

        public void RedrawIcons()
        {
            int width = 64;
            int height = width * Canvas.Height / Canvas.Width;
            var imageList = new ImageList
            {
                ColorDepth = ColorDepth.Depth32Bit,
                ImageSize = new Size(width, height)
            };
            foreach (var layer in Canvas.Layers)
                imageList.Images.Add(layer.ResultImage);

            listView1.SmallImageList?.Dispose();
            listView1.SmallImageList = imageList;
            listView1.Items.Clear();
            for (int i = 0; i < Canvas.Layers.Count; i++)
            {
                var layer = Canvas.Layers[i];
                var item = new ListViewItem(layer.Name, i);
                item.Checked = layer.IsEnabled;

                listView1.Items.Add(item);
            }
        }

        private void addImageLayer_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы изображений|*.jpg;*.jpeg;*.png;*.gif;*.bmp|" +
                                    "Файлы JPEG|*.jpg;*.jpeg|" +
                                    "Файлы PNG|*.png|" +
                                    "Файлы GIF|*.gif|" +
                                    "Файлы BMP|*.bmp|" +
                                    "Все файлы|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var image = Image.FromFile(openFileDialog.FileName);
                var layer = new ImageLayer(Canvas, image);
                layer.Name = openFileDialog.SafeFileName;
                Redraw();
            }
        }

        private void addLayer_Click(object sender, EventArgs e)
        {
            _ = new Layer(Canvas);
        }

        private void removeLayer_Click(object sender, EventArgs e)
        {
            int index = Canvas.Layers.Count - 1;

            if (listView1.SelectedItems.Count > 0)
                index = listView1.SelectedItems[0].Index;

            if (Canvas.Layers.Count > 0 && index < Canvas.Layers.Count && index >= 0)
            {
                Canvas.RemoveLayer(index);
                Redraw();
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы изображений|*.jpg;*.jpeg;*.png;*.gif;*.bmp|" +
                                    "Файлы JPEG|*.jpg;*.jpeg|" +
                                    "Файлы PNG|*.png|" +
                                    "Файлы GIF|*.gif|" +
                                    "Файлы BMP|*.bmp|" +
                                    "Все файлы|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var image = Image.FromFile(openFileDialog.FileName);
                Canvas = new Canvas(image.Width, image.Height);
                _ = new ImageLayer(Canvas, image);

                Redraw();
                RedrawIcons();
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Файлы JPEG|*.jpg;*.jpeg|" +
                                    "Файлы PNG|*.png|" +
                                    "Файлы GIF|*.gif|" +
                                    "Файлы BMP|*.bmp|" +
                                    "Все файлы|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(saveFileDialog.FileName).ToLower();
                if (extension == ".jpg" || extension == ".jpeg")
                    Canvas.FinalRender().Save(saveFileDialog.FileName, ImageFormat.Jpeg);

                else
                    Canvas.FinalRender().Save(saveFileDialog.FileName);
            }
        }

        private void PencilB_Click(object sender, EventArgs e)
        {
            tools = Tools.Pen;
        }

        private void EraseB_Click(object sender, EventArgs e)
        {
            tools = Tools.Erase;
        }

        private void RectangleB_Click(object sender, EventArgs e)
        {
            tools = Tools.Rect;
        }

        private void RectangleWithRoundedEdgesB_Click(object sender, EventArgs e)
        {
            tools = Tools.RoundedRect;
        }

        private void EllipseB_Click(object sender, EventArgs e)
        {
            tools = Tools.Ellipse;
        }

        private void LineB_Click(object sender, EventArgs e)
        {
            tools = Tools.Line;
        }

        private void ColorB_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Colors.BackColor = colorDialog.Color;
                pen.Color = colorDialog.Color;
            }
        }

        private void zoomPictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (!paint)
                return;

            Redraw();

            if (gTarget != Canvas.ResultImage)
            {
                g?.Dispose();
                g = Graphics.FromImage(Canvas.ResultImage);
            }

            int width = Math.Abs(newPoint.X - oldPoint.X);
            int height = Math.Abs(newPoint.Y - oldPoint.Y);

            int x = Math.Min(newPoint.X, oldPoint.X);
            int y = Math.Min(newPoint.Y, oldPoint.Y);

            if (tools == Tools.Ellipse)
                g.DrawEllipse(pen, x, y, width, height);

            else if (tools == Tools.Rect)
                g.DrawRectangle(pen, x, y, width, height);

            else if (tools == Tools.RoundedRect)
                g.DrawRectangle(pen, x, y, width, height);

            else if (tools == Tools.Line)
                DrawLine(pen, oldPoint, newPoint);
        }

        private void zoomPictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                zoomPictureBox1.AllowUserDrag = true;

            else
            {
                oldPoint = zoomPictureBox1.ClientToImagePoint(e.Location);

                if (tools != Tools.None)
                {
                    zoomPictureBox1.AllowUserDrag = false;
                    paint = true;
                }

                zoomPictureBox1_MouseMove(sender, e);
            }
        }

        private void zoomPictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right)
                return;

            var layer = Canvas.GetLayerToDraw();
            if (layer == null)
                return;

            if (gTarget != layer.ResultImage)
            {
                g?.Dispose();
                g = Graphics.FromImage(layer.ResultImage);
            }

            newPoint = zoomPictureBox1.ClientToImagePoint(e.Location);
            bool changed = false;

            if (e.Button == MouseButtons.Left && paint)
            {
                if (tools == Tools.Pen)
                {
                    DrawLine(pen, newPoint, oldPoint);
                    oldPoint = newPoint;
                    changed = true;
                }
                else if (tools == Tools.Erase)
                {
                    Erase(newPoint, oldPoint);
                    oldPoint = newPoint;
                    changed = true;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                Erase(newPoint, oldPoint);
                oldPoint = newPoint;
                changed = true;
            }

            if (changed)
                Redraw();
        }

        private void zoomPictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle && paint)
                zoomPictureBox1.AllowUserDrag = false;
            else
                zoomPictureBox1.AllowUserDrag = true;

            paint = false;

            int width = Math.Abs(newPoint.X - oldPoint.X);
            int height = Math.Abs(newPoint.Y - oldPoint.Y);

            int x = Math.Min(newPoint.X, oldPoint.X);
            int y = Math.Min(newPoint.Y, oldPoint.Y);

            if (tools == Tools.Ellipse)
                g.DrawEllipse(pen, x, y, width, height);

            else if (tools == Tools.Rect)
                g.DrawRectangle(pen, x, y, width, height);

            else if (tools == Tools.RoundedRect)
                g.DrawRectangle(pen, x, y, width, height);

            else if (tools == Tools.Line)
                DrawLine(pen, oldPoint, newPoint);

            Redraw();
            RedrawIcons();
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                Canvas.SelectLayer(listView1.SelectedItems[0].Index);
            else
                Canvas.SelectLayer(-1);
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == e.NewValue)
                return;

            int index = e.Index;
            bool isEnabled = e.NewValue == CheckState.Checked;
            if (Canvas.Layers[index].IsEnabled != isEnabled)
            {
                Canvas.Layers[index].IsEnabled = isEnabled;
                Redraw();
            }
        }

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                Canvas.Layers[e.Item].Name = e.Label;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}