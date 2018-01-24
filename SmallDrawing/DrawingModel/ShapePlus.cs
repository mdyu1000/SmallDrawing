using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    partial class Shape
    {
        //此區存放 原點x,y,x2,y2  紀錄move點的list  move的點x,y
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

        //_originalValueX
        public double GetOriginalValueX()
        {
            return this._originalValueX.Last();
        }

        //_originalValueY
        public double GetOriginalValueY()
        {
            return this._originalValueY.Last();
        }

        //_movePointX
        public double GetMovePointX()
        {
            return this._movePointX;
        }

        //GetMovePointY
        public double GetMovePointY()
        {
            return this._movePointY;
        }

    }
}
