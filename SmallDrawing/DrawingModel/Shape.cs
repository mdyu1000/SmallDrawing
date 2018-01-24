using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public partial class Shape
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
        protected List<double> _reserveOriginalValueX = new List<double>();
        protected List<double> _reserveOriginalValueY = new List<double>();
        protected double _movePointX;
        protected double _movePointY;
        private const int FLAG_LINE = 1;
        private const int FLAG_RECTANGLE = 2;
        private const int FLAG_ELLIPSE = 3;
        private const int FLAG_ARROW = 4;
        private const int LENGTH = 15;

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
            if (GetShapeFlag() == FLAG_LINE || GetShapeFlag() == FLAG_ARROW)
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
            else if ((GetShapeFlag() == FLAG_RECTANGLE || GetShapeFlag() == FLAG_ELLIPSE) && pointX > this._valueX && pointX < this._valueX + _width && pointY > this._valueY && pointY < this._valueY + _width)
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

        //MoveSelectedLine
        public void MoveSelectedLine(double pointX, double pointY)
        {
            if (GetValueX2() > GetValueX() && GetValueY2() > GetValueY())
            {
                this._valueX2 = this._valueX + _width;
                this._valueY2 = this._valueY + _height;
            }
            else if (GetValueX2() > GetValueX() && GetValueY2() < GetValueY())
            {
                this._valueX2 = this._valueX + _width;
                this._valueY2 = this._valueY - _height;
            }

            MoveSelectedLineTwo(pointX, pointY);
        }

        //MoveSelectedLineTwo
        public void MoveSelectedLineTwo(double pointX, double pointY)
        {
            if (GetValueX2() < GetValueX() && GetValueY2() < GetValueY())
            {
                this._valueX2 = this._valueX - _width;
                this._valueY2 = this._valueY - _height;
            }
            else if (GetValueX2() < GetValueX() && GetValueY2() > GetValueY())
            {
                this._valueX2 = this._valueX - _width;
                this._valueY2 = this._valueY + _height;
            }
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
            if (GetShapeFlag() == FLAG_LINE || GetShapeFlag() == FLAG_ARROW)
            {
                this._width = Math.Abs(this._valueX2 - this._valueX);
                this._height = Math.Abs(this._valueY2 - this._valueY);
            }
        }

        //SetValueThree
        public void SetValueThree()
        {
            double angle = Math.Atan2(GetValueY2() - GetValueY(), GetValueX2() - GetValueX());
            double sine = Math.Sin(angle);
            double cosine = Math.Cos(angle);
            this._valueX3 = GetValueX2() - (LENGTH * cosine - LENGTH * sine);
            this._valueY3 = GetValueY2() - (LENGTH * sine + LENGTH * cosine);
            this._valueX4 = GetValueX2() - (LENGTH * cosine + LENGTH * sine);
            this._valueY4 = GetValueY2() + (LENGTH * cosine - LENGTH * sine);
        }

        //SetCancleSelected
        public void SetCancelSelected()
        {
            this._isSelected = false;
        }

        //UndoMoveShape
        public void UndoMoveShape()
        {
            _reserveOriginalValueX.Add(this._originalValueX.Last());
            _reserveOriginalValueY.Add(this._originalValueY.Last());
            this._originalValueX.RemoveAt(this._originalValueX.Count - 1);
            this._originalValueY.RemoveAt(this._originalValueY.Count - 1);
        }

        //RedoMoveShape
        public void RedoMoveShape()
        {
            if (this._reserveOriginalValueX.Count != 0)
            {
                _originalValueX.Add(this._reserveOriginalValueX.Last());
                _originalValueY.Add(this._reserveOriginalValueY.Last());
                this._reserveOriginalValueX.RemoveAt(this._reserveOriginalValueX.Count - 1);
                this._reserveOriginalValueY.RemoveAt(this._reserveOriginalValueY.Count - 1);
            }
        }

        //IsInitialEqualEnd
        public bool IsInitialEqualEnd()
        {
            if (_valueX != _valueX2 && _valueY != _valueY2)
                return false;
            else
                return true;
        }

    }
}
