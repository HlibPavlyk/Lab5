using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class EllipseShape : Shape
    {
        private Point startPoint;
        private int hight;
        private int width;
        private Color borderColor;
        private Color fillColor;
        private DashStyle penStyle;

        public override Point StartPoint
        {
            get { return new Point((startPoint.X + width/2), (startPoint.Y + hight/2)); }
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
        public EllipseShape(Point centertPoint, Point endPoint, Color? borderColor = null,
            Color? fillColor = null, DashStyle penStyle = DashStyle.Solid)
        {
            this.borderColor = borderColor ?? Color.Black; ;
            this.fillColor = fillColor ?? Color.FromArgb(0, Color.White);
            this.penStyle = penStyle;
            SetPosition(centertPoint, endPoint);
        }

        public EllipseShape(EllipseShape other)
        {
            this.startPoint = other.startPoint;
            this.hight = other.hight;
            this.width = other.width;
            this.borderColor = other.borderColor;
            this.fillColor = other.fillColor;
            this.penStyle = other.penStyle;
        }

        public override void SetPosition(Point centerPoint, Point? endPoint = null)
        {
            endPoint = endPoint ?? Point.Empty;
            hight = Math.Abs(endPoint.Value.Y - centerPoint.Y);
            width = Math.Abs(endPoint.Value.X - centerPoint.X);

            startPoint = new Point(centerPoint.X - width, centerPoint.Y - hight);

            hight *= 2;
            width *= 2;
        }

        public override Shape CreateCopy()
        {
            return new EllipseShape(this);
        }

        public override void Show(Graphics graphics)
        {
            using (Pen pen = new Pen(this.borderColor))
            using (SolidBrush brush = new SolidBrush(this.fillColor))
            {
                pen.Width = 2;
                pen.DashStyle = penStyle;
                graphics.FillEllipse(brush, startPoint.X, startPoint.Y, width, hight);
                graphics.DrawEllipse(pen, startPoint.X, startPoint.Y, width, hight);

            }
        }
    }
}
