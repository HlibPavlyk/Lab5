using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class RectShape : Shape
    {
        private Point startPoint;
        private int hight;
        private int width;
        private Color borderColor;
        private Color fillColor;
        private DashStyle penStyle;

        public override Point StartPoint
        {
            get { return startPoint; }
        }
        public override Point? EndPoint
        {
            get { return new Point((startPoint.X + width), (startPoint.Y + hight)); }
        }
        public override Color Color
        {
            get { return borderColor; }
            set { borderColor = value; }
        }
        public RectShape(Point startPoint, Point endPoint, Color? borderColor = null,
            Color? fillColor = null, DashStyle penStyle = DashStyle.Solid)
        {
            this.borderColor = borderColor ?? Color.Black; ;
            this.fillColor = fillColor ?? Color.FromArgb(0, Color.White);
            this.penStyle = penStyle;
            SetPosition(startPoint, endPoint);
        }

        public RectShape(RectShape other)
        {
            this.startPoint = other.startPoint;
            this.hight = other.hight;
            this.width = other.width;
            this.borderColor = other.borderColor;
            this.fillColor = other.fillColor;
            this.penStyle = other.penStyle;
        }

        public override void SetPosition(Point startPoint, Point? endPoint = null) 
        {
            endPoint = endPoint ?? Point.Empty;
            hight = Math.Abs(endPoint.Value.Y - startPoint.Y);
            width = Math.Abs(endPoint.Value.X - startPoint.X);

            this.startPoint = new Point((startPoint.X + endPoint.Value.X) / 2 - width / 2, 
                (startPoint.Y + endPoint.Value.Y) / 2 - hight / 2);
        }

        public override Shape CreateCopy()
        {
            return new RectShape(this);
        }

        public override void Show(Graphics graphics)
        {
            using (Pen pen = new Pen(this.borderColor))
            using (SolidBrush brush = new SolidBrush(this.fillColor))
            {
                pen.Width = 2;
                pen.DashStyle = penStyle;
                graphics.FillRectangle(brush, startPoint.X, startPoint.Y, width, hight);
                graphics.DrawRectangle(pen, startPoint.X, startPoint.Y, width, hight);
            }
        }
    }
}
