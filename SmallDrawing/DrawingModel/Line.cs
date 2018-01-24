using System;
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
        }

        //DrawSelected
        public override void DrawSelected(IGraphics graphics)
        {
            if (IsSelected())
                graphics.DrawLineSelected(GetValueX(), GetValueY(), GetValueX2(), GetValueY2());
        }

        //GetShapeFlag
        public override int GetShapeFlag()
        {
            return 1;
        }

        //MoveSelected
        public override void MoveSelected(double pointX, double pointY)
        {
            SetLineSide();
            this._valueX = pointX;
            this._valueY = pointY;
            MoveSelectedLine(pointX, pointY);
        }

    }
}
