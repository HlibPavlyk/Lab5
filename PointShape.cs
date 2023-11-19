using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class PointShape : Shape
    {
        private Point point;
        private Color color;

        
        public PointShape(Point point, Color? color = null)
        {
            SetPosition(point);
            this.color = color ?? Color.Black;
        }

        public PointShape(PointShape other)
        {
            this.point = other.point;
            this.color = other.color;
        }

        public override Shape CreateCopy()
        {
            return new PointShape(this);
        }

        public override void SetPosition(Point startPoint, Point? endPoint = null)
        {
            point = startPoint;
        }

        public override void Show(Graphics graphics)
        {
            using (SolidBrush brush = new SolidBrush(this.color))
            {
                graphics.FillEllipse(brush, point.X, point.Y, 5, 5);
            }

        }

    }
}
