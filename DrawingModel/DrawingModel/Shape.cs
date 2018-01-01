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
        private double _valueX2;
        private double _valueY2;
        private double _width;
        private double _height;
        protected bool _isSelected;

        //Draw
        public virtual void Draw(IGraphics graphics)
        {
        }

        //Draw
        public virtual void DrawSelected(IGraphics graphics)
        {
        }

        //GetShapeFlag
        public virtual int GetShapeFlag()
        {
            return 0;
        }

        //SetSelected
        public void SetSelected(double pointX, double pointY)
        {
            if (GetShapeFlag() == 1 || GetShapeFlag() == 4)
            {
                if (_valueX2 > _valueX && _valueY2 > _valueY && pointX > this._valueX && pointX < this._valueX2 && pointY > this._valueY && pointY < this._valueY2)
                    this._isSelected = true;
                else if (_valueX2 < _valueX && _valueY2 < _valueY && pointX > this._valueX2 && pointX < this._valueX && pointY > this._valueY2 && pointY < this._valueY)
                    this._isSelected = true;
                else if (_valueX2 > _valueX && _valueY2 < _valueY && pointX > this._valueX && pointX < this._valueX2 && pointY > this._valueY2 && pointY < this._valueY)
                    this._isSelected = true;
                else if (_valueX2 < _valueX && _valueY2 > _valueY && pointX > this._valueX2 && pointX < this._valueX && pointY > this._valueY && pointY < this._valueY2)
                    this._isSelected = true;
            }
            else if ((GetShapeFlag() == 2 || GetShapeFlag() == 3) && pointX > this._valueX && pointX < this._valueX + _width && pointY > this._valueY && pointY < this._valueY + _width)
                this._isSelected = true;
            else
                this._isSelected = false;
        }

        //GetSelected
        public bool IsSelected()
        {
            return this._isSelected;
        }

        //SetValue
        public void SetValue(double valueX, double valueY)
        {
            this._valueX = valueX;
            this._valueY = valueY;
        }

        //SetValueTwo
        public void SetValueTwo(double valueX2, double valueY2)
        {
            this._valueX2 = valueX2;
            this._valueY2 = valueY2;
        }

        //SetValueSide
        public void SetValueSide(double width, double height)
        {
            this._width = width;
            this._height = height;
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
