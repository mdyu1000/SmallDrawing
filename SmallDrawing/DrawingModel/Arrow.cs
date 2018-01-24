using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Arrow : Line
    {
        private double _missX;
        private double _missY;
        private const int FLAG_LINE = 4;

        //Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawArrow(GetValueX(), GetValueY(), GetValueX2(), GetValueY2());
            SetLineSide();
            this._missX = _width;
            this._missY = _height;

            if (!IsInitialEqualEnd())
            {
                graphics.DrawArrow(GetValueX2(), GetValueY2(), _valueX3, _valueY3);
                graphics.DrawArrow(GetValueX2(), GetValueY2(), _valueX4, _valueY4);
            }
        }

        //DrawSelected
        public override void DrawSelected(IGraphics graphics)
        {
            if (IsSelected())
            {
                graphics.DrawArrowSelected(GetValueX(), GetValueY(), GetValueX2(), GetValueY2());
                graphics.DrawArrowSelected(GetValueX2(), GetValueY2(), _valueX3, _valueY3);
                graphics.DrawArrowSelected(GetValueX2(), GetValueY2(), _valueX4, _valueY4);
            }
        }

        //GetShapeFlag
        public override int GetShapeFlag()
        {
            return FLAG_LINE;
        }

        //MoveSelected
        public override void MoveSelected(double pointX, double pointY)
        {
            SetLineSide();
            this._valueX = pointX;
            this._valueY = pointY;
            MoveSelectedLine(pointX, pointY);
            SetValueThree();
        }
    }
}
