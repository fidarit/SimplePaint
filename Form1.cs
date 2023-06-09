using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LayersIDK
{
    public partial class Form1 : Form
    {
        public Canvas Canvas { get; set; }
        Graphics g;
        bool paint = false; //событие рисования
        Point newPoint, oldPoint; //координаты карандаша, ластика
        Pen p = new Pen(Color.Black, 1); //карандаш
        Pen erase = new Pen(Color.White, 10); //ластик
        int index; //инстурменты
        ColorDialog cd = new ColorDialog();

        public Form1()
        {
            InitializeComponent();

            Canvas = new Canvas(1024, 768);
        }

        private void DrawLine(Pen pen, Point from, Point to)
        {
            DrawPoint(pen, from);
            DrawPoint(pen, to);
            g.DrawLine(pen, from, to);
        }
        private void DrawPoint(Pen pen, Point point)
        {
            Brush brush = new SolidBrush(pen.Color);
            int radius = (int)(pen.Width / 2);
            int size = radius * 2;
            int x = point.X - radius;
            int y = point.Y - radius;
            g.FillEllipse(brush, x, y, size, size);
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Redraw();
        }

        public void Redraw()
        {
            zoomPictureBox1.Image = Canvas.Render(true);

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
            Redraw();
        }

        private void removeLayer_Click(object sender, EventArgs e)
        {
            int index = Canvas.Layers.Count - 1;

            if (listView1.SelectedItems.Count > 0)
                index = listView1.SelectedItems[0].Index;

            if (Canvas.Layers.Count > 0 && index < Canvas.Layers.Count && index >= 0)
            {
                Canvas.Layers.RemoveAt(index);
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
                Canvas.ResultImage.Save(saveFileDialog.FileName);
            }
        }

        private void RectangleB_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void RectangleWithRoundedEdgesB_Click(object sender, EventArgs e)
        {
            index = 3;
        }

        private void EllipseB_Click(object sender, EventArgs e)
        {
            index = 4;
        }

        private void LineB_Click(object sender, EventArgs e)
        {
            index = 5;
        }

        private void ColorB_Click(object sender, EventArgs e)
        {
            cd.ShowDialog();
            Colors.BackColor = cd.Color;
            p.Color = cd.Color;
        }

        private void zoomPictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (paint)
            {
                int width = Math.Abs(newPoint.X - oldPoint.X);
                int height = Math.Abs(newPoint.Y - oldPoint.Y);

                int x = Math.Min(newPoint.X, oldPoint.X);
                int y = Math.Min(newPoint.Y, oldPoint.Y);

                if (index == 2)
                {
                    g.DrawEllipse(p, x, y, width, height);
                }

                else if (index == 3)
                {
                    g.DrawRectangle(p, x, y, width, height);
                }

                else if (index == 4)
                {
                    g.DrawLine(p, oldPoint, newPoint);
                }
            }

        }

        private void zoomPictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            zoomPictureBox1.AllowUserDrag = false;
            paint = true;
            oldPoint = zoomPictureBox1.ClientToImagePoint(e.Location);
        }

        private void zoomPictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            var layer = Canvas.GetLayerToDraw();
            if (layer == null)
                return;

            g?.Dispose();
            g = Graphics.FromImage(layer.ResultImage);
            newPoint = zoomPictureBox1.ClientToImagePoint(e.Location);
            bool changed = true;

            if (e.Button == MouseButtons.Left)
            {
                if (paint)
                {
                    if (index == 1)
                    {
                        g.DrawLine(p, newPoint, oldPoint);
                        oldPoint = newPoint;
                    }

                    if (index == 2)
                    {
                        g.DrawLine(erase, newPoint, oldPoint);
                        oldPoint = newPoint;
                    }
                }
            }

            else if (e.Button == MouseButtons.Right)
            {
                g.DrawLine(erase, newPoint, oldPoint);
                oldPoint = newPoint;
            }
            else
                changed = false;

            if (changed)
                Redraw();
        }

        private void zoomPictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;

            int width = Math.Abs(newPoint.X - oldPoint.X);
            int height = Math.Abs(newPoint.Y - oldPoint.Y);

            int x = Math.Min(newPoint.X, oldPoint.X);
            int y = Math.Min(newPoint.Y, oldPoint.Y);

            if (index == 1)
            {
            }
            if (index == 2)
            {
                g.DrawEllipse(p, x, y, width, height);
            }

            else if (index == 3)
            {
                g.DrawRectangle(p, x, y, width, height);
            }

            else if (index == 4)
            {
                g.DrawLine(p, oldPoint, newPoint);
            }
            zoomPictureBox1.AllowUserDrag = true;
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            int index = -1;
            if (listView1.SelectedItems.Count > 0)
                index = listView1.SelectedItems[0].Index;
            else if (Canvas.Layers.Count > 0)
                index = 0;

            Canvas.SelectedLayerIndex = index;
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

        private void PencilB_Click(object sender, EventArgs e)
        {
            index = 1;
        }
    }
}