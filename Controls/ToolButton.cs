using System.ComponentModel;

namespace SimplePaint.Controls
{
    public class ToolButton : PictureBox
    {
        private static ToolButton activeTool;

        [DefaultValue(ToolType.None)]
        public ToolType ToolType { get; set; }

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
            MainForm.Instance.SetTool(ToolType);
        }
    }
}
