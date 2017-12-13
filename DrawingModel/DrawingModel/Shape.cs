using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Shape
    {
        public double _valueX;
        public double _valueY;

        //Draw
        public virtual void Draw(IGraphics graphics)
        {
        }
    }
}
