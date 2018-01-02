﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Rectangle : Shape
    {

        private const int FLAG_RECTANGLE = 2;
        //Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(GetValueX(), GetValueY(), _width, _height);
        }

        //DrawSelected
        public override void DrawSelected(IGraphics graphics)
        {
            if (IsSelected())
                graphics.DrawRectangleSelected(GetValueX(), GetValueY(), _width, _height);
        }

        //GetShapeFlag
        public override int GetShapeFlag()
        {
            return FLAG_RECTANGLE;
        }

    }
}
