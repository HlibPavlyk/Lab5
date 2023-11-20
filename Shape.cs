using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public abstract class Shape
    {
        public abstract void SetPosition(Point startPoint, Point? endPoint = null);
        public abstract Point StartPoint{ get; }
        public abstract Point? EndPoint { get; }
        public abstract Color Color { get; set; }
        public abstract Shape CreateCopy();
        public abstract void Show(Graphics graphics);
    }

    


    
}


