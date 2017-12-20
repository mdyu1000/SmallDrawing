using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Shape
    {
        private double _valueX;
        private double _valueY;

        //Draw
        public virtual void Draw(IGraphics graphics)
        {
        }

        //SetValue
        public void SetValue(double valueX, double valueY)
        {
            this._valueX = valueX;
            this._valueY = valueY;
        }

        //GetValueX
        public double GetValueX()
        {
            return this._valueX;
        }

        //GetValueY
        public double GetValueY()
        {
            return this._valueY;
        }
    }
}
