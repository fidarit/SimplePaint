using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePaint.Controls
{
    public class ToolButton : PictureBox
    {
        private static ToolButton activeTool;

        [DefaultValue(Tools.None)]
        public Tools ToolType { get; set; }

        public Color ActiveColor { get; set; } = Color.FromArgb(60, 114, 196);

        private Color defaultBackColor;

        public ToolButton() : base()
        {
            defaultBackColor = BackColor;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            BackColor = ActiveColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (activeTool != this)
                BackColor = defaultBackColor;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (activeTool != null)
                activeTool.BackColor = defaultBackColor;

            activeTool = this;
            activeTool.BackColor = ActiveColor;
            Form1.Instance.SetTool(ToolType);
        }
    }
}
