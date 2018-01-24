using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    partial class Model
    {
        //此區存放 Press的四種圖形 Move的四種圖形 Release的四種圖形 ButtonClear的狀態(含Redo Undo)  整個Redo Undo的狀態與判斷
        //PointerPressed Line
        public void PressPointerLine()
        {
            _hint.SetValue(_firstPointX, _firstPointY);
        }

        //PointerPressed Rectangle
        public void PressPointerRectangle()
        {
            _hintRectangle.SetValue(_firstPointX, _firstPointY);
        }

        //PointerPressed Ellipse
        public void PressPointerEllipse()
        {
            _hintEllipse.SetValue(_firstPointX, _firstPointY);
        }

        //PointerPressed Arrow
        public void PressPointerArrow()
        {
            _hintArrow.SetValue(_firstPointX, _firstPointY);
        }

        //PointerMoved Line
        public void MovePointerLine(double valueX, double valueY)
        {
            _hint.SetValueTwo(valueX, valueY);
        }

        //PointerMoved Rectangle
        public void MovePointerRectangle(double valueX, double valueY)
        {
            _hintRectangle.SetValueSide(Math.Abs(valueX - _hintRectangle.GetValueX()), Math.Abs(valueY - _hintRectangle.GetValueY()));
            _hintRectangle.SetValue((valueX < _hintRectangle.GetValueX()) ? valueX : _firstPointX, (valueY < _hintRectangle.GetValueY()) ? valueY : _firstPointY);
        }

        //PointerMoved Arrow
        public void MovePointerArrow(double valueX, double valueY)
        {
            _hintArrow.SetValueTwo(valueX, valueY);
            _hintArrow.SetValueThree();
        }

        //PointerMoved Ellipse
        public void MovePointerEllipse(double valueX, double valueY)
        {
            _hintEllipse.SetValueSide(Math.Abs(valueX - _hintEllipse.GetValueX()), Math.Abs(valueY - _hintEllipse.GetValueY()));
            _hintEllipse.SetValue((valueX < _hintEllipse.GetValueX()) ? valueX : _firstPointX, (valueY < _hintEllipse.GetValueY()) ? valueY : _firstPointY);
        }

        //PointerReleased Line
        public void ReleasePointerLine(double valueX, double valueY)
        {
            Line hint = new Line();
            hint.SetValue(valueX, valueY);
            hint.SetValueTwo(_firstPointX, _firstPointY);
            this._commandManager.Execute(new AddShapeCommand(this, hint));
        }

        //PointerReleased Rectangle
        public void ReleasePointerRectangle(double valueX, double valueY)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.SetValue((valueX < _firstPointX) ? valueX : _firstPointX, (valueY < _firstPointY) ? valueY : _firstPointY);
            rectangle.SetValueSide(Math.Abs(valueX - _firstPointX), Math.Abs(valueY - _firstPointY));
            _commandManager.Execute(new AddShapeCommand(this, rectangle));
        }

        //PointerReleased Rectangle
        public void ReleasePointerEllipse(double valueX, double valueY)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.SetValue((valueX < _firstPointX) ? valueX : _firstPointX, (valueY < _firstPointY) ? valueY : _firstPointY);
            ellipse.SetValueSide(Math.Abs(valueX - _firstPointX), Math.Abs(valueY - _firstPointY));
            _commandManager.Execute(new AddShapeCommand(this, ellipse));
        }

        //PointerReleased Arrow
        public void ReleasePointerArrow(double valueX, double valueY)
        {
            Arrow arrow = new Arrow();
            arrow.SetValue(_firstPointX, _firstPointY);
            arrow.SetValueTwo(valueX, valueY);
            arrow.SetValueThree();
            this._commandManager.Execute(new AddShapeCommand(this, arrow));
        }

        //Clear
        public void ClearCommand()
        {
            _isPressed = false;
            this._commandManager.Execute(new ClearShapeCommand(this, _shape));
            NotifyModelChanged();
        }

        //UndoClear
        public void UndoClear()
        {
            this._reserveShape = this._shape.ToList();
            this._shape.Clear();
        }

        //RedoClear
        public void RedoClear()
        {
            if (_reserveShape.Count != 0)
            {
                this._shape = this._reserveShape.ToList();
                this._reserveShape.Clear();
            }

            NotifyModelChanged();
        }

        //Undo
        public void Undo()
        {
            this._commandManager.Undo();
            NotifyModelChanged();
        }

        //Redo
        public void Redo()
        {
            this._commandManager.Redo();
            NotifyModelChanged();
        }

        //IsRedoEnabled
        public bool IsRedoEnabled
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
        }

        //IsUndoEnabled
        public bool IsUndoEnabled
        {
            get
            {
                return _commandManager.IsUndoEnabled;
            }
        }
    }
}
