﻿using SimplePaint.Controls;
using System.Drawing.Drawing2D;

namespace SimplePaint
{
    public class PenTool : Tool
    {
        protected List<Point> points = new List<Point>();

        public PenTool(ZoomPictureBox pictureBox) : base(pictureBox)
        {
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            pen.LineJoin = LineJoin.Round;
        }

        protected override void OnMouseMove(Graphics g)
        {
            points.Add(newPoint);
        }

        protected override void OnMouseUp(Graphics g)
        {
            points.Add(newPoint);

            g.DrawLines(pen, points.ToArray());
            points.Clear();
        }

        protected override void OnMouseDown(Graphics g)
        {
            points.Add(newPoint);
        }

        protected override void Paint(Graphics g)
        {
            if (points.Count > 1)
                g.DrawLines(pen, points.ToArray());
        }
    }
}
