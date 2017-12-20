using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Ellipse : Shape
    {
        private double _width;
        private double _height;

        //Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(GetValueX(), GetValueY(), _width, _height);
        }

        //SetValueTwo
        public void SetValueTwo(double width, double height)
        {
            this._width = width;
            this._height = height;
        }

        //GetWidth
        public double GetWidth()
        {
            return this._width;
        }

        //GetHeight
        public double GetHeight()
        {
            return this._height;
        }

    }
}
