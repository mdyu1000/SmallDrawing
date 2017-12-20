using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Line : Shape
    {
        private double _valueX2;
        private double _valueY2;

        //Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(GetValueX(), GetValueY(), _valueX2, _valueY2);
        }

        //SetValueTwo
        public void SetValueTwo(double valueX2, double valueY2)
        {
            this._valueX2 = valueX2;
            this._valueY2 = valueY2;
        }

        //GetValueX2
        public double GetValueX2()
        {
            return this._valueX2;
        }

        //GetValueY2
        public double GetValueY2()
        {
            return this._valueY2;
        }
    }
}
