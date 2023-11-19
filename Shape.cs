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
        public abstract Shape CreateCopy();
        public abstract void Show(Graphics graphics);
    }

    


    
}


