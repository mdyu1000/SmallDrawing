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
        private const int UNSELECTED = -1;

        Rectangle _rectangleSelected = new Rectangle();
        //public Rectangle HintRect => _rectangleSelected;

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

                if (this.DetectSelectedIndex() != UNSELECTED)
                {
                    this._shape[DetectSelectedIndex()].MoveSelected(valueX, valueY);
                }

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

                if (_isButtonLinePressed)
                    ReleasePointerLine(valueX, valueY);

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
            graphics.ClearAll();

            foreach (Shape DisplayShape in _shape)
            {
                DisplayShape.Draw(graphics);

                if (DisplayShape.IsSelected())
                {
                    DisplayShape.DrawSelected(graphics);
                }
            }

            if (_isPressed)
            {
                if (_isButtonLinePressed)
                    _hint.Draw(graphics);
                else if (_isButtonRectanglePressed)
                    _hintRectangle.Draw(graphics);
                else if (_isButtonEllipsePressed)
                    _hintEllipse.Draw(graphics);
                else if (_isButtonArrowPressed)
                    _hintArrow.Draw(graphics);
            }
        }

        //DrawShape
        public void DrawShape(Shape shape)
        {
            _shape.Add(shape);
        }

        //DeleteShape
        public void DeleteLastShape()
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

        //Delete
        public void DeleteCommand()
        {
            int index = 0;

            if (this.DetectSelectedIndex() != UNSELECTED)
                _commandManager.Execute(new DeleteShapeCommand(this, _shape[index]));

            NotifyModelChanged();
        }

        //DeleteSpecifyShape
        public void DeleteSpecifyShape()
        {
            if (this.DetectSelectedIndex() != UNSELECTED)
                this._shape.RemoveAt(DetectSelectedIndex());
        }

        //PressSelected
        public void PressSelected(double valueX, double valueY, bool isButtonSelectPressed)
        {
            Console.WriteLine("isButtonSelectPressed={0}", isButtonSelectPressed);

            if (isButtonSelectPressed)
                for (int i = _shape.Count - 1; i >= 0; i--)
                {
                    _shape[i].SetSelected(valueX, valueY);

                    if (_shape[i].IsSelected())
                        break;
                }
            else
                for (int i = _shape.Count - 1; i >= 0; i--)
                    if (_shape[i].IsSelected())
                        _shape[i].SetCancleSelected();
        }

        //MoveCommand
        public void MoveCommand(double valueX, double valueY)
        {
            if (this.DetectSelectedIndex() != UNSELECTED)
            {
                NotifyModelChanged();
            }

            //_commandManager.Execute(new MoveShapeCommand(this, _shape[0]));
        }

        // Return which shape is selected?
        public int DetectSelectedIndex()
        {
            for (int i = 0; i < this._shape.Count; i++)
                if (_shape[i].IsSelected())
                    return i;

            return UNSELECTED;
        }
    }
}