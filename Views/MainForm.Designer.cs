using SimplePaint.Controls;

namespace SimplePaint
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ListViewItem listViewItem3 = new ListViewItem("Layer one");
            ListViewItem listViewItem4 = new ListViewItem("Layer two");
            splitContainer1 = new SplitContainer();
            mainPictureBox = new ZoomPictureBox();
            colorPalette = new ColorPalette();
            tableLayoutPanel1 = new TableLayoutPanel();
            removeLayer = new Button();
            addImageLayer = new Button();
            addLayer = new Button();
            layersListView = new ListView();
            columnHeader1 = new ColumnHeader();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openFileToolStripMenuItem = new ToolStripMenuItem();
            saveFileToolStripMenuItem = new ToolStripMenuItem();
            flowLayoutPanel1 = new FlowLayoutPanel();
            toolNoneButton = new ToolButton();
            toolPenButton = new ToolButton();
            toolEraseButton = new ToolButton();
            toolLineButton = new ToolButton();
            toolRectangleButton = new ToolButton();
            toolRoundedRectangleButton = new ToolButton();
            toolEllipseButton = new ToolButton();
            toolFillButton = new ToolButton();
            toolPipetteButton = new ToolButton();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)toolNoneButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toolPenButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toolEraseButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toolLineButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toolRectangleButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toolRoundedRectangleButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toolEllipseButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toolFillButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)toolPipetteButton).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(mainPictureBox);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(colorPalette);
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer1.Panel2.Controls.Add(layersListView);
            splitContainer1.Size = new Size(1567, 624);
            splitContainer1.SplitterDistance = 1173;
            splitContainer1.TabIndex = 0;
            // 
            // mainPictureBox
            // 
            mainPictureBox.Dock = DockStyle.Fill;
            mainPictureBox.Image = (Bitmap)resources.GetObject("mainPictureBox.Image");
            mainPictureBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            mainPictureBox.InterpolationModeZoomOut = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            mainPictureBox.Location = new Point(0, 0);
            mainPictureBox.Name = "mainPictureBox";
            mainPictureBox.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            mainPictureBox.Size = new Size(1173, 624);
            mainPictureBox.TabIndex = 0;
            mainPictureBox.VisibleCenter = (PointF)resources.GetObject("mainPictureBox.VisibleCenter");
            mainPictureBox.Zoom = 150F;
            // 
            // colorPalette
            // 
            colorPalette.Dock = DockStyle.Top;
            colorPalette.Location = new Point(0, 0);
            colorPalette.Name = "colorPalette";
            colorPalette.Size = new Size(390, 267);
            colorPalette.TabIndex = 5;
            colorPalette.Text = "colorPalette1";
            colorPalette.ColorSelected += colorPalette_ColorSelected;
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
            // layersListView
            // 
            layersListView.AutoArrange = false;
            layersListView.CheckBoxes = true;
            layersListView.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            layersListView.Dock = DockStyle.Bottom;
            layersListView.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            layersListView.HeaderStyle = ColumnHeaderStyle.None;
            listViewItem3.StateImageIndex = 0;
            listViewItem4.StateImageIndex = 0;
            layersListView.Items.AddRange(new ListViewItem[] { listViewItem3, listViewItem4 });
            layersListView.LabelEdit = true;
            layersListView.LabelWrap = false;
            layersListView.Location = new Point(0, 361);
            layersListView.MultiSelect = false;
            layersListView.Name = "layersListView";
            layersListView.Size = new Size(390, 263);
            layersListView.TabIndex = 2;
            layersListView.UseCompatibleStateImageBehavior = false;
            layersListView.View = View.Details;
            layersListView.AfterLabelEdit += listView1_AfterLabelEdit;
            layersListView.ItemActivate += listView1_ItemActivate;
            layersListView.ItemCheck += listView1_ItemCheck;
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
            flowLayoutPanel1.Controls.Add(toolNoneButton);
            flowLayoutPanel1.Controls.Add(toolPenButton);
            flowLayoutPanel1.Controls.Add(toolEraseButton);
            flowLayoutPanel1.Controls.Add(toolLineButton);
            flowLayoutPanel1.Controls.Add(toolRectangleButton);
            flowLayoutPanel1.Controls.Add(toolRoundedRectangleButton);
            flowLayoutPanel1.Controls.Add(toolEllipseButton);
            flowLayoutPanel1.Controls.Add(toolFillButton);
            flowLayoutPanel1.Controls.Add(toolPipetteButton);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 24);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(55, 624);
            flowLayoutPanel1.TabIndex = 5;
            flowLayoutPanel1.WrapContents = false;
            // 
            // toolNoneButton
            // 
            toolNoneButton.ActiveColor = Color.FromArgb(60, 114, 196);
            toolNoneButton.BorderStyle = BorderStyle.FixedSingle;
            toolNoneButton.Cursor = Cursors.Hand;
            toolNoneButton.Image = (Image)resources.GetObject("toolNoneButton.Image");
            toolNoneButton.Location = new Point(2, 2);
            toolNoneButton.Margin = new Padding(2);
            toolNoneButton.Name = "toolNoneButton";
            toolNoneButton.Size = new Size(49, 45);
            toolNoneButton.SizeMode = PictureBoxSizeMode.Zoom;
            toolNoneButton.TabIndex = 2;
            toolNoneButton.TabStop = false;
            toolTip1.SetToolTip(toolNoneButton, "Перемещение");
            // 
            // toolPenButton
            // 
            toolPenButton.ActiveColor = Color.FromArgb(60, 114, 196);
            toolPenButton.BorderStyle = BorderStyle.FixedSingle;
            toolPenButton.Image = (Image)resources.GetObject("toolPenButton.Image");
            toolPenButton.Location = new Point(3, 52);
            toolPenButton.MaximumSize = new Size(49, 45);
            toolPenButton.Name = "toolPenButton";
            toolPenButton.Size = new Size(49, 45);
            toolPenButton.SizeMode = PictureBoxSizeMode.Zoom;
            toolPenButton.TabIndex = 12;
            toolPenButton.TabStop = false;
            toolPenButton.Text = "❒";
            toolTip1.SetToolTip(toolPenButton, "Карандаш");
            toolPenButton.ToolType = ToolType.Pen;
            // 
            // toolEraseButton
            // 
            toolEraseButton.ActiveColor = Color.FromArgb(60, 114, 196);
            toolEraseButton.BorderStyle = BorderStyle.FixedSingle;
            toolEraseButton.Image = (Image)resources.GetObject("toolEraseButton.Image");
            toolEraseButton.Location = new Point(3, 103);
            toolEraseButton.MaximumSize = new Size(49, 45);
            toolEraseButton.Name = "toolEraseButton";
            toolEraseButton.Size = new Size(49, 45);
            toolEraseButton.SizeMode = PictureBoxSizeMode.Zoom;
            toolEraseButton.TabIndex = 6;
            toolEraseButton.TabStop = false;
            toolEraseButton.Text = "□";
            toolTip1.SetToolTip(toolEraseButton, "Ластик");
            toolEraseButton.ToolType = ToolType.Erase;
            // 
            // toolLineButton
            // 
            toolLineButton.ActiveColor = Color.FromArgb(60, 114, 196);
            toolLineButton.BorderStyle = BorderStyle.FixedSingle;
            toolLineButton.Image = (Image)resources.GetObject("toolLineButton.Image");
            toolLineButton.Location = new Point(3, 154);
            toolLineButton.MaximumSize = new Size(49, 45);
            toolLineButton.Name = "toolLineButton";
            toolLineButton.Size = new Size(49, 45);
            toolLineButton.SizeMode = PictureBoxSizeMode.Zoom;
            toolLineButton.TabIndex = 7;
            toolLineButton.TabStop = false;
            toolLineButton.Text = "▢";
            toolTip1.SetToolTip(toolLineButton, "Линия");
            toolLineButton.ToolType = ToolType.Line;
            // 
            // toolRectangleButton
            // 
            toolRectangleButton.ActiveColor = Color.FromArgb(60, 114, 196);
            toolRectangleButton.BorderStyle = BorderStyle.FixedSingle;
            toolRectangleButton.Image = (Image)resources.GetObject("toolRectangleButton.Image");
            toolRectangleButton.Location = new Point(3, 205);
            toolRectangleButton.MaximumSize = new Size(49, 45);
            toolRectangleButton.Name = "toolRectangleButton";
            toolRectangleButton.Size = new Size(49, 45);
            toolRectangleButton.SizeMode = PictureBoxSizeMode.Zoom;
            toolRectangleButton.TabIndex = 8;
            toolRectangleButton.TabStop = false;
            toolRectangleButton.Text = "⬭";
            toolTip1.SetToolTip(toolRectangleButton, "Прямоугольник");
            toolRectangleButton.ToolType = ToolType.Rect;
            // 
            // toolRoundedRectangleButton
            // 
            toolRoundedRectangleButton.ActiveColor = Color.FromArgb(60, 114, 196);
            toolRoundedRectangleButton.BorderStyle = BorderStyle.FixedSingle;
            toolRoundedRectangleButton.Image = (Image)resources.GetObject("toolRoundedRectangleButton.Image");
            toolRoundedRectangleButton.Location = new Point(3, 256);
            toolRoundedRectangleButton.MaximumSize = new Size(49, 45);
            toolRoundedRectangleButton.Name = "toolRoundedRectangleButton";
            toolRoundedRectangleButton.Size = new Size(49, 45);
            toolRoundedRectangleButton.SizeMode = PictureBoxSizeMode.Zoom;
            toolRoundedRectangleButton.TabIndex = 9;
            toolRoundedRectangleButton.TabStop = false;
            toolRoundedRectangleButton.Text = "\\";
            toolTip1.SetToolTip(toolRoundedRectangleButton, "Закругленный прямоугольник");
            toolRoundedRectangleButton.ToolType = ToolType.RoundedRect;
            // 
            // toolEllipseButton
            // 
            toolEllipseButton.ActiveColor = Color.FromArgb(60, 114, 196);
            toolEllipseButton.BorderStyle = BorderStyle.FixedSingle;
            toolEllipseButton.Image = (Image)resources.GetObject("toolEllipseButton.Image");
            toolEllipseButton.Location = new Point(3, 307);
            toolEllipseButton.MaximumSize = new Size(49, 45);
            toolEllipseButton.Name = "toolEllipseButton";
            toolEllipseButton.Size = new Size(49, 45);
            toolEllipseButton.SizeMode = PictureBoxSizeMode.Zoom;
            toolEllipseButton.TabIndex = 10;
            toolEllipseButton.TabStop = false;
            toolEllipseButton.Text = "Цвет";
            toolTip1.SetToolTip(toolEllipseButton, "Эллипс");
            toolEllipseButton.ToolType = ToolType.Ellipse;
            // 
            // toolFillButton
            // 
            toolFillButton.ActiveColor = Color.FromArgb(60, 114, 196);
            toolFillButton.BorderStyle = BorderStyle.FixedSingle;
            toolFillButton.Image = (Image)resources.GetObject("toolFillButton.Image");
            toolFillButton.Location = new Point(3, 358);
            toolFillButton.MaximumSize = new Size(49, 45);
            toolFillButton.Name = "toolFillButton";
            toolFillButton.Size = new Size(49, 45);
            toolFillButton.SizeMode = PictureBoxSizeMode.Zoom;
            toolFillButton.TabIndex = 13;
            toolFillButton.TabStop = false;
            toolFillButton.Text = "Цвет";
            toolTip1.SetToolTip(toolFillButton, "Заливка");
            toolFillButton.ToolType = ToolType.Fill;
            // 
            // toolPipetteButton
            // 
            toolPipetteButton.ActiveColor = Color.FromArgb(60, 114, 196);
            toolPipetteButton.BorderStyle = BorderStyle.FixedSingle;
            toolPipetteButton.Image = (Image)resources.GetObject("toolPipetteButton.Image");
            toolPipetteButton.Location = new Point(3, 409);
            toolPipetteButton.MaximumSize = new Size(49, 45);
            toolPipetteButton.Name = "toolPipetteButton";
            toolPipetteButton.Size = new Size(49, 45);
            toolPipetteButton.SizeMode = PictureBoxSizeMode.Zoom;
            toolPipetteButton.TabIndex = 14;
            toolPipetteButton.TabStop = false;
            toolPipetteButton.Text = "Цвет";
            toolTip1.SetToolTip(toolPipetteButton, "Пипетка");
            toolPipetteButton.ToolType = ToolType.Pipette;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1622, 648);
            Controls.Add(splitContainer1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "SimplePaint";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)toolNoneButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)toolPenButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)toolEraseButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)toolLineButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)toolRectangleButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)toolRoundedRectangleButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)toolEllipseButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)toolFillButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)toolPipetteButton).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splitContainer1;
        private ZoomPictureBox mainPictureBox;
        private Button addImageLayer;
        private ListView layersListView;
        private Button removeLayer;
        private Button addLayer;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openFileToolStripMenuItem;
        private ToolStripMenuItem saveFileToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private ColumnHeader columnHeader1;
        private FlowLayoutPanel flowLayoutPanel1;
        private ToolButton toolNoneButton;
        private ToolButton toolEraseButton;
        private ToolButton toolLineButton;
        private ToolButton toolRectangleButton;
        private ToolButton toolRoundedRectangleButton;
        private ToolButton toolEllipseButton;
        private ToolButton toolPenButton;
        private ToolTip toolTip1;
        private ToolButton toolFillButton;
        private ToolButton toolPipetteButton;
        private ColorPalette colorPalette;
    }
}