﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Ellipse : Shape
    {
        public double _width;
        public double _height;

        //Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(_valueX, _valueY, _width, _height);
        }
    }
}
