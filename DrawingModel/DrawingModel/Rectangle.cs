using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Rectangle : Shape
    {

        //Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(GetValueX(), GetValueY(), GetWidth(), GetHeight());
        }

        //DrawSelected
        public override void DrawSelected(IGraphics graphics)
        {
            if (IsSelected())
                graphics.DrawRectangleSelected(GetValueX(), GetValueY(), GetWidth(), GetHeight());
        }

        //GetShapeFlag
        public override int GetShapeFlag()
        {
            return 2;
        }

    }
}
