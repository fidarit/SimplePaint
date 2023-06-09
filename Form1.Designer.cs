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
            RectangleB = new Button();
            RectangleWithRoundedEdgesB = new Button();
            EllipseB = new Button();
            LineB = new Button();
            ColorB = new Button();
            Colors = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(splitContainer1)).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(Colors)).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(62, 30);
            splitContainer1.Margin = new Padding(3, 4, 3, 4);
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
            splitContainer1.Size = new System.Drawing.Size(1809, 1025);
            splitContainer1.SplitterDistance = 1356;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // zoomPictureBox1
            // 
            zoomPictureBox1.Dock = DockStyle.Fill;
            zoomPictureBox1.Image = ((System.Drawing.Bitmap)(resources.GetObject("zoomPictureBox1.Image")));
            zoomPictureBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            zoomPictureBox1.InterpolationModeZoomOut = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            zoomPictureBox1.Location = new System.Drawing.Point(0, 0);
            zoomPictureBox1.Margin = new Padding(3, 4, 3, 4);
            zoomPictureBox1.Name = "zoomPictureBox1";
            zoomPictureBox1.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            zoomPictureBox1.Size = new System.Drawing.Size(1356, 1025);
            zoomPictureBox1.TabIndex = 0;
            zoomPictureBox1.VisibleCenter = ((System.Drawing.PointF)(resources.GetObject("zoomPictureBox1.VisibleCenter")));
            zoomPictureBox1.Zoom = 150F;
            zoomPictureBox1.Paint += new PaintEventHandler(zoomPictureBox1_Paint);
            zoomPictureBox1.MouseDown += new MouseEventHandler(zoomPictureBox1_MouseDown);
            zoomPictureBox1.MouseMove += new MouseEventHandler(zoomPictureBox1_MouseMove);
            zoomPictureBox1.MouseUp += new MouseEventHandler(zoomPictureBox1_MouseUp);
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
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 605);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(448, 71);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // removeLayer
            // 
            removeLayer.Dock = DockStyle.Fill;
            removeLayer.Location = new System.Drawing.Point(357, 5);
            removeLayer.Margin = new Padding(5);
            removeLayer.Name = "removeLayer";
            removeLayer.Size = new System.Drawing.Size(86, 61);
            removeLayer.TabIndex = 1;
            removeLayer.Text = "-";
            removeLayer.UseVisualStyleBackColor = true;
            removeLayer.Click += new System.EventHandler(removeLayer_Click);
            // 
            // addImageLayer
            // 
            addImageLayer.Dock = DockStyle.Fill;
            addImageLayer.Location = new System.Drawing.Point(148, 5);
            addImageLayer.Margin = new Padding(5);
            addImageLayer.Name = "addImageLayer";
            addImageLayer.Size = new System.Drawing.Size(103, 61);
            addImageLayer.TabIndex = 3;
            addImageLayer.Text = "Добавить изображение";
            addImageLayer.UseVisualStyleBackColor = true;
            addImageLayer.Click += new System.EventHandler(addImageLayer_Click);
            // 
            // addLayer
            // 
            addLayer.Dock = DockStyle.Fill;
            addLayer.Location = new System.Drawing.Point(261, 5);
            addLayer.Margin = new Padding(5);
            addLayer.Name = "addLayer";
            addLayer.Size = new System.Drawing.Size(86, 61);
            addLayer.TabIndex = 0;
            addLayer.Text = "+";
            addLayer.UseVisualStyleBackColor = true;
            addLayer.Click += new System.EventHandler(addLayer_Click);
            // 
            // listView1
            // 
            listView1.AllowDrop = true;
            listView1.AutoArrange = false;
            listView1.CheckBoxes = true;
            listView1.Columns.AddRange(new ColumnHeader[] {
            columnHeader1});
            listView1.Dock = DockStyle.Bottom;
            listView1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            listView1.HeaderStyle = ColumnHeaderStyle.None;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            listView1.Items.AddRange(new ListViewItem[] {
            listViewItem1,
            listViewItem2});
            listView1.LabelEdit = true;
            listView1.LabelWrap = false;
            listView1.Location = new System.Drawing.Point(0, 676);
            listView1.Margin = new Padding(3, 4, 3, 4);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(448, 349);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.AfterLabelEdit += new LabelEditEventHandler(listView1_AfterLabelEdit);
            listView1.ItemActivate += new System.EventHandler(listView1_ItemActivate);
            listView1.ItemCheck += new ItemCheckEventHandler(listView1_ItemCheck);
            // 
            // columnHeader1
            // 
            columnHeader1.Width = 384;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] {
            fileToolStripMenuItem});
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new System.Drawing.Size(1871, 30);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            openFileToolStripMenuItem,
            saveFileToolStripMenuItem});
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // openFileToolStripMenuItem
            // 
            openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            openFileToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            openFileToolStripMenuItem.Text = "Открыть";
            openFileToolStripMenuItem.Click += new System.EventHandler(openFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            saveFileToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            saveFileToolStripMenuItem.Text = "Сохранить";
            saveFileToolStripMenuItem.Click += new System.EventHandler(saveFileToolStripMenuItem_Click);
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(PencilB);
            flowLayoutPanel1.Controls.Add(RectangleB);
            flowLayoutPanel1.Controls.Add(RectangleWithRoundedEdgesB);
            flowLayoutPanel1.Controls.Add(EllipseB);
            flowLayoutPanel1.Controls.Add(LineB);
            flowLayoutPanel1.Controls.Add(ColorB);
            flowLayoutPanel1.Controls.Add(Colors);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(62, 1025);
            flowLayoutPanel1.TabIndex = 5;
            flowLayoutPanel1.WrapContents = false;
            // 
            // PencilB
            // 
            PencilB.AutoSize = true;
            PencilB.Location = new System.Drawing.Point(3, 4);
            PencilB.Margin = new Padding(3, 4, 3, 4);
            PencilB.Name = "PencilB";
            PencilB.Size = new System.Drawing.Size(56, 60);
            PencilB.TabIndex = 5;
            PencilB.Text = "Кр";
            PencilB.UseVisualStyleBackColor = true;
            PencilB.Click += new System.EventHandler(PencilB_Click);
            // 
            // RectangleB
            // 
            RectangleB.AutoSize = true;
            RectangleB.Location = new System.Drawing.Point(3, 72);
            RectangleB.Margin = new Padding(3, 4, 3, 4);
            RectangleB.Name = "RectangleB";
            RectangleB.Size = new System.Drawing.Size(56, 60);
            RectangleB.TabIndex = 6;
            RectangleB.Text = "Пр";
            RectangleB.UseVisualStyleBackColor = true;
            RectangleB.Click += new System.EventHandler(RectangleB_Click);
            // 
            // RectangleWithRoundedEdgesB
            // 
            RectangleWithRoundedEdgesB.AutoSize = true;
            RectangleWithRoundedEdgesB.Location = new System.Drawing.Point(3, 140);
            RectangleWithRoundedEdgesB.Margin = new Padding(3, 4, 3, 4);
            RectangleWithRoundedEdgesB.Name = "RectangleWithRoundedEdgesB";
            RectangleWithRoundedEdgesB.Size = new System.Drawing.Size(56, 60);
            RectangleWithRoundedEdgesB.TabIndex = 7;
            RectangleWithRoundedEdgesB.Text = "ПЗК";
            RectangleWithRoundedEdgesB.UseVisualStyleBackColor = true;
            RectangleWithRoundedEdgesB.Click += new System.EventHandler(RectangleWithRoundedEdgesB_Click);
            // 
            // EllipseB
            // 
            EllipseB.AutoSize = true;
            EllipseB.Location = new System.Drawing.Point(3, 208);
            EllipseB.Margin = new Padding(3, 4, 3, 4);
            EllipseB.Name = "EllipseB";
            EllipseB.Size = new System.Drawing.Size(56, 60);
            EllipseB.TabIndex = 8;
            EllipseB.Text = "Элл";
            EllipseB.UseVisualStyleBackColor = true;
            EllipseB.Click += new System.EventHandler(EllipseB_Click);
            // 
            // LineB
            // 
            LineB.AutoSize = true;
            LineB.Location = new System.Drawing.Point(3, 276);
            LineB.Margin = new Padding(3, 4, 3, 4);
            LineB.Name = "LineB";
            LineB.Size = new System.Drawing.Size(56, 60);
            LineB.TabIndex = 9;
            LineB.Text = "Лин";
            LineB.UseVisualStyleBackColor = true;
            LineB.Click += new System.EventHandler(LineB_Click);
            // 
            // ColorB
            // 
            ColorB.AutoSize = true;
            ColorB.Location = new System.Drawing.Point(3, 344);
            ColorB.Margin = new Padding(3, 4, 3, 4);
            ColorB.Name = "ColorB";
            ColorB.Size = new System.Drawing.Size(56, 60);
            ColorB.TabIndex = 10;
            ColorB.Text = "Цвет";
            ColorB.UseVisualStyleBackColor = true;
            ColorB.Click += new System.EventHandler(ColorB_Click);
            // 
            // Colors
            // 
            Colors.Location = new System.Drawing.Point(3, 411);
            Colors.Name = "Colors";
            Colors.Size = new System.Drawing.Size(56, 53);
            Colors.TabIndex = 11;
            Colors.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1871, 1055);
            Controls.Add(splitContainer1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Paint += new PaintEventHandler(Form1_Paint);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splitContainer1)).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(Colors)).EndInit();
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
    }
}