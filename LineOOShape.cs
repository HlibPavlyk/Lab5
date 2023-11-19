using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class LineOOShape : Shape
    {
        private Point startPoint;
        private Point endPoint;

        List<Shape> lineOOComponents = new List<Shape>();
        private int radius;

        private Color borderColor;
        private Color fillColor;
        private DashStyle penStyle;


        public LineOOShape(Point startPoint, Point endPoint, int radius = 10, Color? borderColor = null,
            Color? fillColor = null, DashStyle penStyle = DashStyle.Solid)
        {
            this.borderColor = borderColor ?? Color.Black;
            this.fillColor = fillColor ?? Color.FromArgb(0, Color.White);
            this.penStyle = penStyle;
            this.radius = radius;
            SetPosition(startPoint, endPoint);
        }

        public LineOOShape(LineOOShape other)
        {
            this.startPoint = other.startPoint;
            this.endPoint = other.endPoint;
            this.lineOOComponents = new List<Shape>(other.lineOOComponents);
            this.radius = other.radius;
            this.borderColor = other.borderColor;
            this.fillColor = other.fillColor;
            this.penStyle = other.penStyle;
        }

        public override void SetPosition(Point startPoint, Point? endPoint = null)
        {
            endPoint = endPoint ?? Point.Empty;
            lineOOComponents.Clear();

            int directionX = endPoint.Value.X - startPoint.X;
            int directionY = endPoint.Value.Y - startPoint.Y;
            double length = Math.Sqrt(directionX * directionX + directionY * directionY);
            double normalizedDirectionX = directionX / length;
            double normalizedDirectionY = directionY / length;

            Point pointStartLine = new Point((int)(startPoint.X + radius * normalizedDirectionX),
                (int)(startPoint.Y + radius * normalizedDirectionY));
            Point pointEndLine = new Point((int)(endPoint.Value.X - radius * normalizedDirectionX),
                (int)(endPoint.Value.Y - radius * normalizedDirectionY));

            Point pointEndFirstEllipse = new Point(startPoint.X + radius, startPoint.Y + radius);
            Point pointEndSecondEllipse = new Point(endPoint.Value.X + radius, endPoint.Value.Y + radius);

            lineOOComponents.Add(new EllipseShape(startPoint, pointEndFirstEllipse, borderColor,
                fillColor, penStyle));
            lineOOComponents.Add(new EllipseShape(endPoint.Value, pointEndSecondEllipse, borderColor,
                fillColor, penStyle));
            lineOOComponents.Add(new LineShape(pointStartLine, pointEndLine, borderColor, penStyle));
        }

        public override Shape CreateCopy()
        {
            return new LineOOShape(this);
        }

        public override void Show(Graphics graphics)
        {
            foreach (Shape shape in lineOOComponents)
            {
                shape.Show(graphics);
            }
        }
    }
}
