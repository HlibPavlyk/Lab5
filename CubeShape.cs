using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class CubeShape : Shape
    {
        private Point startPointFront;
        private Point startPointBack;

        private int width;
        private List<Shape> cubeComponents = new List<Shape>();

        private Color borderColor;
        private DashStyle penStyle;

        public CubeShape(Point centerPoint, Point endPoint, Color? borderColor = null, 
            DashStyle penStyle = DashStyle.Solid)
        {
            this.borderColor = borderColor ?? Color.Black;
            this.penStyle = penStyle;
            SetPosition(centerPoint, endPoint);
        }

        public CubeShape(CubeShape other)
        {
            this.startPointFront = other.startPointFront;
            this.startPointBack = other.startPointBack;
            this.width = other.width;
            this.cubeComponents = new List<Shape>(other.cubeComponents);
            this.borderColor = borderColor;
            this.penStyle = penStyle;
        }

        public override void SetPosition(Point centerPoint, Point? endPoint = null)
        {
            endPoint = endPoint ?? Point.Empty;
            cubeComponents.Clear();

            int widthX = Math.Abs(endPoint.Value.X - centerPoint.X);
            int widthY = Math.Abs(endPoint.Value.Y - centerPoint.Y);
            this.width = (widthX >= widthY) ? widthX : widthY;

            this.startPointFront = new Point(centerPoint.X - width, centerPoint.Y - width); ;
            this.width *= 2;
            int deltaWidth = (int)(width / 2.8);
            this.startPointBack = new Point(startPointFront.X + deltaWidth, startPointFront.Y - deltaWidth);

            Point endPointFront = new Point(startPointFront.X + width, startPointFront.Y + width);
            Point endPointBack = new Point(startPointBack.X + width, startPointBack.Y + width);
            cubeComponents.Add(new RectShape(startPointFront, endPointFront, borderColor,
                Color.FromArgb(0, Color.White), penStyle));
            cubeComponents.Add(new RectShape(startPointBack, endPointBack, borderColor,
                Color.FromArgb(0, Color.White), penStyle));

            cubeComponents.Add(new LineShape(startPointFront, startPointBack, borderColor, penStyle));
            cubeComponents.Add(new LineShape(endPointFront, endPointBack, borderColor, penStyle));

            Point pointFrontUpRight = new Point(startPointFront.X + width, startPointFront.Y);
            Point pointBackUpRight = new Point(startPointBack.X + width, startPointBack.Y);
            cubeComponents.Add(new LineShape(pointFrontUpRight, pointBackUpRight, borderColor, penStyle));

            Point pointFrontDownLeft = new Point(startPointFront.X, startPointFront.Y + width);
            Point pointBackDownLeft = new Point(startPointBack.X, startPointBack.Y + width);
            cubeComponents.Add(new LineShape(pointFrontDownLeft, pointBackDownLeft, borderColor, penStyle));
        }
        public override Shape CreateCopy()
        {
            return new CubeShape(this);
        }

        public override void Show(Graphics graphics)
        {
            foreach (Shape shape in cubeComponents)
            {
                shape.Show(graphics);
            }

        }
    }
}
