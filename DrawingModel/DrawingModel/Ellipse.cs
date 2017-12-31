using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Ellipse : Shape
    {

        //Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(GetValueX(), GetValueY(), GetWidth(), GetHeight());

            if (IsSelected())
                graphics.DrawEllipseSelected(GetValueX(), GetValueY(), GetWidth(), GetHeight());
        }

        //GetShapeFlag
        public override int GetShapeFlag()
        {
            return 3;
        }
    }
}
