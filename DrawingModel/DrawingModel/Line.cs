using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Line : Shape
    {
        public double _valueX2;
        public double _valueY2;
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(_valueX, _valueY, _valueX2, _valueY2);
        }
    }
}
