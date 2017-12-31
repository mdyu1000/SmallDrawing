﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Line : Shape
    {

        //Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(GetValueX(), GetValueY(), GetValueX2(), GetValueY2());

            if (IsSelected())
                graphics.DrawLineSelected(GetValueX(), GetValueY(), GetValueX2(), GetValueY2());
        }

        //GetShapeFlag
        public override int GetShapeFlag()
        {
            return 1;
        }
    }
}
