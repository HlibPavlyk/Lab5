using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class LineShape : Shape
    {
        private Point startPoint;
        private Point endPoint;
        private Color color;
        private DashStyle penStyle;

       
        public LineShape(Point startPoint, Point endPoint, Color? color = null,
            DashStyle penStyle = DashStyle.Solid)
        {
            SetPosition(startPoint, endPoint);
            this.penStyle = penStyle;
            this.color = color ?? Color.Black;
        }

        public LineShape(LineShape other)
        {
            this.startPoint = other.startPoint;
            this.endPoint = other.endPoint;
            this.color = other.color;
            this.penStyle = other.penStyle;
        }

        public override Shape CreateCopy()
        {
            return new LineShape(this);
        }

        public override void SetPosition(Point startPoint, Point? endPoint = null)
        {
            this.startPoint = new Point(startPoint.X - 1, startPoint.Y);
            this.endPoint = endPoint == null ? Point.Empty :
                new Point(endPoint.Value.X - 1, endPoint.Value.Y);

        }

        public override void Show(Graphics graphics)
        {
            using (Pen pen = new Pen(this.color))
            {
                pen.Width = 2;
                pen.DashStyle = penStyle;
                graphics.DrawLine(pen, startPoint, endPoint);
            }
        }
    }
}
