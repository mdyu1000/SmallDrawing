using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Shape
    {
        protected double _valueX;
        protected double _valueY;
        protected double _valueX2;
        protected double _valueY2;
        protected double _valueX3;
        protected double _valueY3;
        protected double _valueX4;
        protected double _valueY4;
        protected double _width;
        protected double _height;
        protected bool _isSelected;
        protected List<double> _originalValueX = new List<double>();
        protected List<double> _originalValueY = new List<double>();
        protected List<double> _ReserveOriginalValueX = new List<double>();
        protected List<double> _ReserveOriginalValueY = new List<double>();

        protected double _movePointX;
        protected double _movePointY;

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
                else
                    this._isSelected = false;
            }
            else if ((GetShapeFlag() == 2 || GetShapeFlag() == 3) && pointX > this._valueX && pointX < this._valueX + _width && pointY > this._valueY && pointY < this._valueY + _width)
                this._isSelected = true;
            else
                this._isSelected = false;
        }

        //MoveSelected
        public virtual void MoveSelected(double pointX, double pointY)
        {
            this._valueX = pointX;
            this._valueY = pointY;
        }

        //SaveValue
        public void SaveValue()
        {
            this._originalValueX.Add(this._valueX);
            this._originalValueY.Add(this._valueY);
        }

        //SaveDynamicValue
        public void SaveDynamicValue(double pointX, double pointY)
        {
            this._movePointX = pointX;
            this._movePointY = pointY;
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

        //SetLineSide
        public void SetLineSide()
        {
            if (GetShapeFlag() == 1 || GetShapeFlag() == 4)
            {
                this._width = Math.Abs(this._valueX2 - this._valueX);
                this._height = Math.Abs(this._valueY2 - this._valueY);
            }
        }

        //SetValueThree
        public void SetValueThree()
        {
            double _theta = Math.Atan2(GetValueY2() - GetValueY(), GetValueX2() - GetValueX());
            double _sin = Math.Sin(_theta);
            double _cos = Math.Cos(_theta);
            this._valueX3 = GetValueX2() - (15 * _cos - 15 * _sin);
            this._valueY3 = GetValueY2() - (15 * _sin + 15 * _cos);
            this._valueX4 = GetValueX2() - (15 * _cos + 15 * _sin);
            this._valueY4 = GetValueY2() + (15 * _cos - 15 * _sin);
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

        //SetCancleSelected
        public void SetCancleSelected()
        {
            this._isSelected = false;
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

        //UndoMoveShape
        public void UndoMoveShape()
        {
            _ReserveOriginalValueX.Add(this._originalValueX.Last());
            _ReserveOriginalValueY.Add(this._originalValueY.Last());
            this._originalValueX.RemoveAt(this._originalValueX.Count - 1);
            this._originalValueY.RemoveAt(this._originalValueY.Count - 1);
        }

        //RedoMoveShape
        public void RedoMoveShape()
        {
            if (this._ReserveOriginalValueX.Count != 0)
            {
                _originalValueX.Add(this._ReserveOriginalValueX.Last());
                _originalValueY.Add(this._ReserveOriginalValueY.Last());
                this._ReserveOriginalValueX.RemoveAt(this._ReserveOriginalValueX.Count - 1);
                this._ReserveOriginalValueY.RemoveAt(this._ReserveOriginalValueY.Count - 1);
            }
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
