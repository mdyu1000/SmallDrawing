using System;
using System.Collections.Generic;

namespace DrawingModel
{
    class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        double _firstPointX;
        double _firstPointY;
        bool _isPressed = false;
        Line _hint = new Line();
        Rectangle _hintRectangle = new Rectangle();
        Ellipse _hintEllipse = new Ellipse();
        bool _isButtonLinePressed;
        bool _isButtonRectanglePressed;
        bool _isButtonEllipsePressed;
        List<Shape> _shape = new List<Shape>();
        private CommandManager _commandManager = new CommandManager();

        //PointerPressed
        public void PressPointer(double valueX, double valueY, bool isButtonLinePressed, bool isButtonRectanglePressed, bool isButtonEllipsePressed)
        {
            if (valueX > 0 && valueY > 0)
            {
                _isButtonLinePressed = isButtonLinePressed;
                _isButtonRectanglePressed = isButtonRectanglePressed;
                _isButtonEllipsePressed = isButtonEllipsePressed;
                _firstPointX = valueX;
                _firstPointY = valueY;

                //Line 的 _hint
                if (_isButtonLinePressed)
                    PressPointerLine();

                //Rectangle 的 _hintRectangle
                if (_isButtonRectanglePressed)
                    PressPointerRectangle();

                //Ellipse 的 _hintEllipse
                if (_isButtonEllipsePressed)
                    PressPointerEllipse();

                _isPressed = true;
            }
        }

        //PointerPressed Line
        public void PressPointerLine()
        {
            _hint._valueX = _firstPointX;
            _hint._valueY = _firstPointY;
        }

        //PointerPressed Rectangle
        public void PressPointerRectangle()
        {
            _hintRectangle._valueX = _firstPointX;
            _hintRectangle._valueY = _firstPointY;
        }

        //PointerPressed Ellipse
        public void PressPointerEllipse()
        {
            _hintEllipse._valueX = _firstPointX;
            _hintEllipse._valueY = _firstPointY;
        }

        //PointerMoved
        public void MovePointer(double valueX, double valueY)
        {
            if (_isPressed)
            {
                //Line 的 _hint
                if (_isButtonLinePressed)
                    MovePointerLine(valueX, valueY);

                //Rectangle 的 _hintRectangle
                if (_isButtonRectanglePressed)
                    MovePointerRectangle(valueX, valueY);

                //Ellipse 的 _hintEllipse
                if (_isButtonEllipsePressed)
                    MovePointerEllipse(valueX, valueY);

                NotifyModelChanged();
            }
        }

        //PointerMoved Line
        public void MovePointerLine(double valueX, double valueY)
        {
            _hint._valueX2 = valueX;
            _hint._valueY2 = valueY;
        }

        //PointerMoved Rectangle
        public void MovePointerRectangle(double valueX, double valueY)
        {
            _hintRectangle._width = Math.Abs(valueX - _hintRectangle._valueX);
            _hintRectangle._height = Math.Abs(valueY - _hintRectangle._valueY);
            _hintRectangle._valueX = (valueX < _hintRectangle._valueX) ? valueX : _firstPointX;
            _hintRectangle._valueY = (valueY < _hintRectangle._valueY) ? valueY : _firstPointY;
        }

        //PointerMoved Ellipse
        public void MovePointerEllipse(double valueX, double valueY)
        {
            _hintEllipse._width = Math.Abs(valueX - _hintEllipse._valueX);
            _hintEllipse._height = Math.Abs(valueY - _hintEllipse._valueY);
            _hintEllipse._valueX = (valueX < _hintEllipse._valueX) ? valueX : _firstPointX;
            _hintEllipse._valueY = (valueY < _hintEllipse._valueY) ? valueY : _firstPointY;
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

                NotifyModelChanged();
            }
        }

        //PointerReleased Line
        public void ReleasePointerLine(double valueX, double valueY)
        {
            Line hint = new Line();
            hint._valueX = _firstPointX;
            hint._valueY = _firstPointY;
            hint._valueX2 = valueX;
            hint._valueY2 = valueY;
            this._commandManager.Execute(new AddShapeCommand(this, hint));
        }

        //PointerReleased Rectangle
        public void ReleasePointerRectangle(double valueX, double valueY)
        {
            Rectangle rectangle = new Rectangle();
            rectangle._valueX = (valueX < _firstPointX) ? valueX : _firstPointX;
            rectangle._valueY = (valueY < _firstPointY) ? valueY : _firstPointY;
            rectangle._width = Math.Abs(valueX - _firstPointX);
            rectangle._height = Math.Abs(valueY - _firstPointY);
            _commandManager.Execute(new AddShapeCommand(this, rectangle));
        }

        //PointerReleased Rectangle
        public void ReleasePointerEllipse(double valueX, double valueY)
        {
            Ellipse ellipse = new Ellipse();
            ellipse._valueX = (valueX < _firstPointX) ? valueX : _firstPointX;
            ellipse._valueY = (valueY < _firstPointY) ? valueY : _firstPointY;
            ellipse._width = Math.Abs(valueX - _firstPointX);
            ellipse._height = Math.Abs(valueY - _firstPointY);
            _commandManager.Execute(new AddShapeCommand(this, ellipse));
        }

        //Clear
        public void Clear()
        {
            _isPressed = false;
            _shape.Clear();
            ResetHintShape();
            NotifyModelChanged();
        }

        //Draw
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();

            foreach (Shape DisplayShape in _shape)
                DisplayShape.Draw(graphics);

            if (_isPressed)
            {
                _hint.Draw(graphics);
                _hintRectangle.Draw(graphics);
                _hintEllipse.Draw(graphics);
            }
        }

        public void DrawShape(Shape shape)
        {
            _shape.Add(shape);
        }

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

        //將Hint全部歸零
        private void ResetHintShape()
        {
            _hint._valueX = 0;
            _hint._valueY = 0;
            _hint._valueX2 = 0;
            _hint._valueY2 = 0;
            _hintRectangle._valueX = 0;
            _hintRectangle._valueY = 0;
            _hintRectangle._width = 0;
            _hintRectangle._height = 0;
            _hintEllipse._valueX = 0;
            _hintEllipse._valueY = 0;
            _hintEllipse._width = 0;
            _hintEllipse._height = 0;
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
