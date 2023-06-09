namespace LayersIDK
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            try
            {
                base.Dispose(disposing);
            }
            catch { }
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            ListViewItem listViewItem1 = new ListViewItem("Layer one");
            ListViewItem listViewItem2 = new ListViewItem("Layer two");
            splitContainer1 = new SplitContainer();
            zoomPictureBox1 = new Wavelet.ZoomPictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            removeLayer = new Button();
            addImageLayer = new Button();
            addLayer = new Button();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openFileToolStripMenuItem = new ToolStripMenuItem();
            saveFileToolStripMenuItem = new ToolStripMenuItem();
            flowLayoutPanel1 = new FlowLayoutPanel();
            PencilB = new Button();
            EraseB = new Button();
            RectangleB = new Button();
            RectangleWithRoundedEdgesB = new Button();
            EllipseB = new Button();
            LineB = new Button();
            ColorB = new Button();
            Colors = new PictureBox();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Colors).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(55, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(zoomPictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer1.Panel2.Controls.Add(listView1);
            splitContainer1.Size = new Size(1567, 624);
            splitContainer1.SplitterDistance = 1173;
            splitContainer1.TabIndex = 0;
            // 
            // zoomPictureBox1
            // 
            zoomPictureBox1.Dock = DockStyle.Fill;
            zoomPictureBox1.Image = (Bitmap)resources.GetObject("zoomPictureBox1.Image");
            zoomPictureBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            zoomPictureBox1.InterpolationModeZoomOut = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            zoomPictureBox1.Location = new Point(0, 0);
            zoomPictureBox1.Name = "zoomPictureBox1";
            zoomPictureBox1.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            zoomPictureBox1.Size = new Size(1173, 624);
            zoomPictureBox1.TabIndex = 0;
            zoomPictureBox1.VisibleCenter = (PointF)resources.GetObject("zoomPictureBox1.VisibleCenter");
            zoomPictureBox1.Zoom = 150F;
            zoomPictureBox1.Paint += zoomPictureBox1_Paint;
            zoomPictureBox1.MouseDown += zoomPictureBox1_MouseDown;
            zoomPictureBox1.MouseMove += zoomPictureBox1_MouseMove;
            zoomPictureBox1.MouseUp += zoomPictureBox1_MouseUp;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(removeLayer, 3, 0);
            tableLayoutPanel1.Controls.Add(addImageLayer, 1, 0);
            tableLayoutPanel1.Controls.Add(addLayer, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 308);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(390, 53);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // removeLayer
            // 
            removeLayer.Dock = DockStyle.Fill;
            removeLayer.Location = new Point(311, 4);
            removeLayer.Margin = new Padding(4);
            removeLayer.Name = "removeLayer";
            removeLayer.Size = new Size(75, 45);
            removeLayer.TabIndex = 1;
            removeLayer.Text = "-";
            removeLayer.UseVisualStyleBackColor = true;
            removeLayer.Click += removeLayer_Click;
            // 
            // addImageLayer
            // 
            addImageLayer.Dock = DockStyle.Fill;
            addImageLayer.Location = new Point(130, 4);
            addImageLayer.Margin = new Padding(4);
            addImageLayer.Name = "addImageLayer";
            addImageLayer.Size = new Size(90, 45);
            addImageLayer.TabIndex = 3;
            addImageLayer.Text = "Добавить изображение";
            addImageLayer.UseVisualStyleBackColor = true;
            addImageLayer.Click += addImageLayer_Click;
            // 
            // addLayer
            // 
            addLayer.Dock = DockStyle.Fill;
            addLayer.Location = new Point(228, 4);
            addLayer.Margin = new Padding(4);
            addLayer.Name = "addLayer";
            addLayer.Size = new Size(75, 45);
            addLayer.TabIndex = 0;
            addLayer.Text = "+";
            addLayer.UseVisualStyleBackColor = true;
            addLayer.Click += addLayer_Click;
            // 
            // listView1
            // 
            listView1.AllowDrop = true;
            listView1.AutoArrange = false;
            listView1.CheckBoxes = true;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listView1.Dock = DockStyle.Bottom;
            listView1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            listView1.HeaderStyle = ColumnHeaderStyle.None;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            listView1.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2 });
            listView1.LabelEdit = true;
            listView1.LabelWrap = false;
            listView1.Location = new Point(0, 361);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(390, 263);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.AfterLabelEdit += listView1_AfterLabelEdit;
            listView1.ItemActivate += listView1_ItemActivate;
            listView1.ItemCheck += listView1_ItemCheck;
            // 
            // columnHeader1
            // 
            columnHeader1.Width = 384;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1622, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openFileToolStripMenuItem, saveFileToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(48, 20);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // openFileToolStripMenuItem
            // 
            openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            openFileToolStripMenuItem.Size = new Size(133, 22);
            openFileToolStripMenuItem.Text = "Открыть";
            openFileToolStripMenuItem.Click += openFileToolStripMenuItem_Click;
            // 
            // saveFileToolStripMenuItem
            // 
            saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            saveFileToolStripMenuItem.Size = new Size(133, 22);
            saveFileToolStripMenuItem.Text = "Сохранить";
            saveFileToolStripMenuItem.Click += saveFileToolStripMenuItem_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(PencilB);
            flowLayoutPanel1.Controls.Add(EraseB);
            flowLayoutPanel1.Controls.Add(RectangleB);
            flowLayoutPanel1.Controls.Add(RectangleWithRoundedEdgesB);
            flowLayoutPanel1.Controls.Add(EllipseB);
            flowLayoutPanel1.Controls.Add(LineB);
            flowLayoutPanel1.Controls.Add(ColorB);
            flowLayoutPanel1.Controls.Add(Colors);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 24);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(55, 624);
            flowLayoutPanel1.TabIndex = 5;
            flowLayoutPanel1.WrapContents = false;
            // 
            // PencilB
            // 
            PencilB.AutoSize = true;
            PencilB.Location = new Point(3, 3);
            PencilB.Name = "PencilB";
            PencilB.Size = new Size(49, 45);
            PencilB.TabIndex = 5;
            PencilB.Text = "✏️";
            toolTip1.SetToolTip(PencilB, "Карандаш");
            PencilB.UseVisualStyleBackColor = true;
            PencilB.Click += PencilB_Click;
            // 
            // EraseB
            // 
            EraseB.AutoSize = true;
            EraseB.Location = new Point(3, 54);
            EraseB.Name = "EraseB";
            EraseB.Size = new Size(49, 45);
            EraseB.TabIndex = 12;
            EraseB.Text = "❒";
            toolTip1.SetToolTip(EraseB, "Ластик");
            EraseB.UseVisualStyleBackColor = true;
            EraseB.Click += EraseB_Click;
            // 
            // RectangleB
            // 
            RectangleB.AutoSize = true;
            RectangleB.Location = new Point(3, 105);
            RectangleB.Name = "RectangleB";
            RectangleB.Size = new Size(49, 45);
            RectangleB.TabIndex = 6;
            RectangleB.Text = "□";
            toolTip1.SetToolTip(RectangleB, "Прямоугольник");
            RectangleB.UseVisualStyleBackColor = true;
            RectangleB.Click += RectangleB_Click;
            // 
            // RectangleWithRoundedEdgesB
            // 
            RectangleWithRoundedEdgesB.AutoSize = true;
            RectangleWithRoundedEdgesB.Location = new Point(3, 156);
            RectangleWithRoundedEdgesB.Name = "RectangleWithRoundedEdgesB";
            RectangleWithRoundedEdgesB.Size = new Size(49, 45);
            RectangleWithRoundedEdgesB.TabIndex = 7;
            RectangleWithRoundedEdgesB.Text = "▢";
            toolTip1.SetToolTip(RectangleWithRoundedEdgesB, "Закругленный прямоугольник");
            RectangleWithRoundedEdgesB.UseVisualStyleBackColor = true;
            RectangleWithRoundedEdgesB.Click += RectangleWithRoundedEdgesB_Click;
            // 
            // EllipseB
            // 
            EllipseB.AutoSize = true;
            EllipseB.Location = new Point(3, 207);
            EllipseB.Name = "EllipseB";
            EllipseB.Size = new Size(49, 45);
            EllipseB.TabIndex = 8;
            EllipseB.Text = "⬭";
            toolTip1.SetToolTip(EllipseB, "Эллипс");
            EllipseB.UseVisualStyleBackColor = true;
            EllipseB.Click += EllipseB_Click;
            // 
            // LineB
            // 
            LineB.AutoSize = true;
            LineB.Location = new Point(3, 258);
            LineB.Name = "LineB";
            LineB.Size = new Size(49, 45);
            LineB.TabIndex = 9;
            LineB.Text = "\\";
            toolTip1.SetToolTip(LineB, "Линия");
            LineB.UseVisualStyleBackColor = true;
            LineB.Click += LineB_Click;
            // 
            // ColorB
            // 
            ColorB.AutoSize = true;
            ColorB.Location = new Point(3, 309);
            ColorB.Name = "ColorB";
            ColorB.Size = new Size(49, 45);
            ColorB.TabIndex = 10;
            ColorB.Text = "Цвет";
            toolTip1.SetToolTip(ColorB, "Палитра цветов");
            ColorB.UseVisualStyleBackColor = true;
            ColorB.Click += ColorB_Click;
            // 
            // Colors
            // 
            Colors.Location = new Point(3, 359);
            Colors.Margin = new Padding(3, 2, 3, 2);
            Colors.Name = "Colors";
            Colors.Size = new Size(49, 40);
            Colors.TabIndex = 11;
            Colors.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1622, 648);
            Controls.Add(splitContainer1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Paint += Form1_Paint;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Colors).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splitContainer1;
        private Wavelet.ZoomPictureBox zoomPictureBox1;
        private Button addImageLayer;
        private ListView listView1;
        private Button removeLayer;
        private Button addLayer;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openFileToolStripMenuItem;
        private ToolStripMenuItem saveFileToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private ColumnHeader columnHeader1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button PencilB;
        private Button RectangleB;
        private Button RectangleWithRoundedEdgesB;
        private Button EllipseB;
        private Button LineB;
        private Button ColorB;
        private PictureBox Colors;
        private Button EraseB;
        private ToolTip toolTip1;
    }
}