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
            graphics.DrawEllipse(GetValueX(), GetValueY(), _width, _height);
        }

        //DrawSelected
        public override void DrawSelected(IGraphics graphics)
        {
            if (IsSelected())
                graphics.DrawEllipseSelected(GetValueX(), GetValueY(), _width, _height);
        }


        //GetShapeFlag
        public override int GetShapeFlag()
        {
            return 3;
        }
    }
}
