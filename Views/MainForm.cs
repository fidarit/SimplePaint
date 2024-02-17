using SimplePaint.Controls;
using System.Drawing.Imaging;

namespace SimplePaint
{
    public partial class MainForm : Form
    {
        public static MainForm Instance { get; private set; }
        public Canvas Canvas { get; set; }
        public Color ActiveColor { get; private set; } = Color.Black;

        private Tool activeTool;
        private EraserTool eraser;

        public MainForm()
        {
            InitializeComponent();

            Instance = this;
            eraser = new EraserTool(mainPictureBox);
            Canvas = new Canvas(1024, 768);

            Canvas.SelectedLayerChanged += layerIndex =>
            {
                RedrawIcons();

                if (layerIndex >= 0)
                {
                    if (layersListView.SelectedIndices.Count == 0 || layersListView.SelectedIndices[0] != layerIndex)
                    {
                        layersListView.SelectedIndices.Clear();
                        layersListView.SelectedIndices.Add(layerIndex);
                    }
                }
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Redraw();
        }

        public void SetTool(ToolType tool)
        {
            switch (tool)
            {
                case ToolType.None:
                    eraser.Deactivate();
                    activeTool?.Deactivate();
                    break;
                case ToolType.Pen:
                    activeTool = new PenTool(mainPictureBox);
                    break;
                case ToolType.Erase:
                    eraser.Activate();
                    break;
                case ToolType.Rect:
                    activeTool = new RectangleTool(mainPictureBox);
                    break;
                case ToolType.RoundedRect:
                    activeTool = new RoundedRectangleTool(mainPictureBox);
                    break;
                case ToolType.Ellipse:
                    activeTool = new EllipseTool(mainPictureBox);
                    break;
                case ToolType.Line:
                    activeTool = new LineTool(mainPictureBox);
                    break;
                case ToolType.Fill:
                    activeTool = new FillTool(mainPictureBox);
                    break;
                case ToolType.Pipette:
                    activeTool = new PipetteTool(mainPictureBox);
                    break;
                default:
                    break;
            }
        }

        public void Redraw(bool redrawIcons = true)
        {
            mainPictureBox.Image = Canvas.Render(true);

            if (redrawIcons)
                RedrawIcons();
        }

        public void RedrawIcons()
        {
            int width, height;
            if (Canvas.Height > Canvas.Width)
            {
                height = 64;
                width = height * Canvas.Width / Canvas.Height;
            }
            else
            {
                width = 64;
                height = width * Canvas.Height / Canvas.Width;
            }

            var imageList = new ImageList
            {
                ColorDepth = ColorDepth.Depth32Bit,
                ImageSize = new Size(width, height)
            };
            foreach (var layer in Canvas.Layers)
                imageList.Images.Add(layer.ResultImage);

            layersListView.SmallImageList?.Dispose();
            layersListView.SmallImageList = imageList;
            layersListView.Items.Clear();
            for (int i = 0; i < Canvas.Layers.Count; i++)
            {
                var layer = Canvas.Layers[i];
                var item = new ListViewItem(layer.Name, i);
                item.Checked = layer.IsEnabled;

                layersListView.Items.Add(item);
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

            if (layersListView.SelectedIndices.Count > 0)
                index = layersListView.SelectedIndices[0];

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

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            if (layersListView.SelectedItems.Count > 0)
                Canvas.SelectLayer(layersListView.SelectedItems[0].Index);
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

        public void SetColor(Color color)
        {
            ActiveColor = color;
            colorPalette.SetColor(color);
        }

        private void colorPalette_ColorSelected(object sender, ColorSelectedEventArgs e)
        {
            ActiveColor = e.SelectedColor;
        }
    }
}