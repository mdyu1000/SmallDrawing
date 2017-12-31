using System;
using System.Collections.Generic;

namespace DrawingModel
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        double _firstPointX;
        double _firstPointY;
        bool _isPressed = false;
        Line _hint = new Line();
        Rectangle _hintRectangle = new Rectangle();
        Ellipse _hintEllipse = new Ellipse();
        Arrow _hintArrow = new Arrow();
        bool _isButtonLinePressed;
        bool _isButtonRectanglePressed;
        bool _isButtonEllipsePressed;
        bool _isButtonArrowPressed;
        List<Shape> _shape = new List<Shape>();
        private CommandManager _commandManager = new CommandManager();
        IGraphics _graphic;
        bool _isSelected;

        //PointerPressed
        public void PressPointer(double valueX, double valueY, bool[] isButtonPressed)
        {
            const int TWO = 2;
            const int THREE = 3;

            if (valueX > 0 && valueY > 0)
            {
                _isButtonLinePressed = isButtonPressed[0];
                _isButtonRectanglePressed = isButtonPressed[1];
                _isButtonEllipsePressed = isButtonPressed[TWO];
                _isButtonArrowPressed = isButtonPressed[THREE];
                _firstPointX = valueX;
                _firstPointY = valueY;
                PressPointerPlus();
                _isPressed = true;
            }
        }

        //PressPointerPlus
        public void PressPointerPlus()
        {
            //Line 的 _hint
            if (_isButtonLinePressed)
                PressPointerLine();

            //Rectangle 的 _hintRectangle
            if (_isButtonRectanglePressed)
                PressPointerRectangle();

            //Ellipse 的 _hintEllipse
            if (_isButtonEllipsePressed)
                PressPointerEllipse();

            if (_isButtonArrowPressed)
                PressPointerArrow();
        }

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

        //PointerMoved
        public void MovePointer(double valueX, double valueY)
        {
            if (_isPressed)
            {
                if (_isButtonLinePressed)
                    MovePointerLine(valueX, valueY);
                else if (_isButtonRectanglePressed)
                    MovePointerRectangle(valueX, valueY);
                else if (_isButtonEllipsePressed)
                    MovePointerEllipse(valueX, valueY);
                else if (_isButtonArrowPressed)
                    MovePointerArrow(valueX, valueY);

                NotifyModelChanged();
            }
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

        //PointerMoved Ellipse
        public void MovePointerEllipse(double valueX, double valueY)
        {
            _hintEllipse.SetValueSide(Math.Abs(valueX - _hintEllipse.GetValueX()), Math.Abs(valueY - _hintEllipse.GetValueY()));
            _hintEllipse.SetValue((valueX < _hintEllipse.GetValueX()) ? valueX : _firstPointX, (valueY < _hintEllipse.GetValueY()) ? valueY : _firstPointY);
        }

        //PointerMoved Arrow
        public void MovePointerArrow(double valueX, double valueY)
        {
            _hintArrow.SetValueTwo(valueX, valueY);
            _hintArrow.SetValueThree();
        }

        //PointerReleased
        public void ReleasePointer(double valueX, double valueY)
        {
            if (_isPressed)
            {
                _isPressed = false;

                //Line 的 _hint
                if (_isButtonLinePressed)
                    ReleasePointerLine(valueX, valueY);

                //Rectangle 的 _hintRectangle
                if (_isButtonRectanglePressed)
                    ReleasePointerRectangle(valueX, valueY);

                if (_isButtonEllipsePressed)
                    ReleasePointerEllipse(valueX, valueY);

                if (_isButtonArrowPressed)
                    ReleasePointerArrow(valueX, valueY);

                NotifyModelChanged();
            }
        }

        //PointerReleased Line
        public void ReleasePointerLine(double valueX, double valueY)
        {
            Line hint = new Line();
            hint.SetValue(_firstPointX, _firstPointY);
            hint.SetValueTwo(valueX, valueY);
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
        public void Clear()
        {
            _isPressed = false;
            _shape.Clear();
            this._commandManager.ClearStack();
            NotifyModelChanged();
        }

        //Draw
        public void Draw(IGraphics graphics)
        {
            this._graphic = graphics;
            _graphic.ClearAll();

            foreach (Shape DisplayShape in _shape)
                DisplayShape.Draw(_graphic);

            if (_isPressed)
            {
                if (_isButtonLinePressed)
                    _hint.Draw(_graphic);
                else if (_isButtonRectanglePressed)
                    _hintRectangle.Draw(_graphic);
                else if (_isButtonEllipsePressed)
                    _hintEllipse.Draw(_graphic);
                else if (_isButtonArrowPressed)
                    _hintArrow.Draw(_graphic);
            }
        }

        //DrawShape
        public void DrawShape(Shape shape)
        {
            _shape.Add(shape);
        }

        //DeleteShape
        public void DeleteShape()
        {
            _shape.RemoveAt(_shape.Count - 1);
        }

        //NotifyModelChanged
        public void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
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
        //---------------
        //Delete
        public void Delete()
        {
            _commandManager.Execute(new DeleteShapeCommand(this, _shape[_shape.Count - 1]));
            NotifyModelChanged();
        }

        //PressSelected
        public void PressSelected(double valueX, double valueY)
        {
            if (!_isButtonArrowPressed && !_isButtonEllipsePressed && !_isButtonLinePressed && !_isButtonRectanglePressed)
            {
                for (int i = _shape.Count - 1; i >= 0; i--)
                {
                    //若坐落在線段or箭頭的範圍內
                    if (valueX > _shape[i].GetValueX() && valueX < _shape[i].GetValueX2() &&
                            valueY > _shape[i].GetValueY() && valueY < _shape[i].GetValueY2() &&
                            (_shape[i].GetShapeFlag() == 1 || _shape[i].GetShapeFlag() == 4))
                    {
                        _shape[i].SetSelected(true);
                    }
                    //若坐落在橢圓or長方形的範圍內
                    else if (valueX > _shape[i].GetValueX() && valueX < _shape[i].GetValueX() + _shape[i].GetWidth() &&
                             valueY > _shape[i].GetValueY() && valueX < _shape[i].GetValueY() + _shape[i].GetHeight() &&
                             (_shape[i].GetShapeFlag() == 2 || _shape[i].GetShapeFlag() == 3))
                    {
                        _shape[i].SetSelected(true);
                    }

                    //簡化判斷式
                }
            }
        }
    }
}
