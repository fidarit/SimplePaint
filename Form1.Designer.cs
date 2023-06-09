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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
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
            splitContainer1.Size = new Size(1582, 769);
            splitContainer1.SplitterDistance = 1186;
            splitContainer1.TabIndex = 0;
            // 
            // zoomPictureBox1
            // 
            zoomPictureBox1.Dock = DockStyle.Fill;
            zoomPictureBox1.Image = (Bitmap)resources.GetObject("zoomPictureBox1.Image");
            zoomPictureBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            zoomPictureBox1.InterpolationModeZoomOut = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            zoomPictureBox1.Location = new Point(0, 0);
            zoomPictureBox1.Name = "zoomPictureBox1";
            zoomPictureBox1.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            zoomPictureBox1.Size = new Size(1186, 769);
            zoomPictureBox1.TabIndex = 0;
            zoomPictureBox1.VisibleCenter = (PointF)resources.GetObject("zoomPictureBox1.VisibleCenter");
            zoomPictureBox1.Zoom = 150F;
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
            tableLayoutPanel1.Location = new Point(0, 453);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(392, 53);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // removeLayer
            // 
            removeLayer.Dock = DockStyle.Fill;
            removeLayer.Location = new Point(313, 4);
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
            addImageLayer.Location = new Point(132, 4);
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
            addLayer.Location = new Point(230, 4);
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
            listView1.Location = new Point(0, 506);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(392, 263);
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1637, 24);
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
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.Controls.Add(button2);
            flowLayoutPanel1.Controls.Add(button3);
            flowLayoutPanel1.Controls.Add(button4);
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 24);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(55, 769);
            flowLayoutPanel1.TabIndex = 5;
            flowLayoutPanel1.WrapContents = false;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(49, 45);
            button1.TabIndex = 5;
            button1.Text = "*";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.Location = new Point(3, 54);
            button2.Name = "button2";
            button2.Size = new Size(49, 45);
            button2.TabIndex = 6;
            button2.Text = "*";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.AutoSize = true;
            button3.Location = new Point(3, 105);
            button3.Name = "button3";
            button3.Size = new Size(49, 45);
            button3.TabIndex = 7;
            button3.Text = "*";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.AutoSize = true;
            button4.Location = new Point(3, 156);
            button4.Name = "button4";
            button4.Size = new Size(49, 45);
            button4.TabIndex = 8;
            button4.Text = "*";
            button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1637, 793);
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
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}