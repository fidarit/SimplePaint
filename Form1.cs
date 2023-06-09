using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LayersIDK
{
    public partial class Form1 : Form
    {
        public Canvas Canvas { get; set; }

        public Form1()
        {
            InitializeComponent();

            Canvas = new Canvas(1024, 768);
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
            var imageList = new ImageList();
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageSize = new Size(width, height);
            foreach (var layer in Canvas.Layers)
            {
                imageList.Images.Add(layer.ResultImage);
            }

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
            openFileDialog.Filter = "װאיכû טחמבנאזוםטי|*.jpg;*.jpeg;*.png;*.gif;*.bmp|" +
                                    "װאיכû JPEG|*.jpg;*.jpeg|" +
                                    "װאיכû PNG|*.png|" +
                                    "װאיכû GIF|*.gif|" +
                                    "װאיכû BMP|*.bmp|" +
                                    "ֲסו פאיכû|*.*";

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
            openFileDialog.Filter = "װאיכû טחמבנאזוםטי|*.jpg;*.jpeg;*.png;*.gif;*.bmp|" +
                                    "װאיכû JPEG|*.jpg;*.jpeg|" +
                                    "װאיכû PNG|*.png|" +
                                    "װאיכû GIF|*.gif|" +
                                    "װאיכû BMP|*.bmp|" +
                                    "ֲסו פאיכû|*.*";

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
            saveFileDialog.Filter = "װאיכû JPEG|*.jpg;*.jpeg|" +
                                    "װאיכû PNG|*.png|" +
                                    "װאיכû GIF|*.gif|" +
                                    "װאיכû BMP|*.bmp|" +
                                    "ֲסו פאיכû|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Canvas.ResultImage.Save(saveFileDialog.FileName);
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                Canvas.SelectedLayerIndex = selectedItem.Index;
            }
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
    }
}