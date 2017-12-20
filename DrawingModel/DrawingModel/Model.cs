﻿using System;
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
        bool _isButtonLinePressed;
        bool _isButtonRectanglePressed;
        bool _isButtonEllipsePressed;
        List<Shape> _shape = new List<Shape>();
        private CommandManager _commandManager = new CommandManager();
        IGraphics _graphic;

        //PointerPressed
        public void PressPointer(double valueX, double valueY, bool[] isButtonPressed)
        {
            const int TWO = 2;

            if (valueX > 0 && valueY > 0)
            {
                _isButtonLinePressed = isButtonPressed[0];
                _isButtonRectanglePressed = isButtonPressed[1];
                _isButtonEllipsePressed = isButtonPressed[TWO];
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
            _hintRectangle.SetValueTwo(Math.Abs(valueX - _hintRectangle.GetValueX()), Math.Abs(valueY - _hintRectangle.GetValueY()));
            _hintRectangle.SetValue((valueX < _hintRectangle.GetValueX()) ? valueX : _firstPointX, (valueY < _hintRectangle.GetValueY()) ? valueY : _firstPointY);
        }

        //PointerMoved Ellipse
        public void MovePointerEllipse(double valueX, double valueY)
        {
            _hintEllipse.SetValueTwo(Math.Abs(valueX - _hintEllipse.GetValueX()), Math.Abs(valueY - _hintEllipse.GetValueY()));
            _hintEllipse.SetValue((valueX < _hintEllipse.GetValueX()) ? valueX : _firstPointX, (valueY < _hintEllipse.GetValueY()) ? valueY : _firstPointY);
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
            hint.SetValue(_firstPointX, _firstPointY);
            hint.SetValueTwo(valueX, valueY);
            this._commandManager.Execute(new AddShapeCommand(this, hint));
        }

        //PointerReleased Rectangle
        public void ReleasePointerRectangle(double valueX, double valueY)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.SetValue((valueX < _firstPointX) ? valueX : _firstPointX, (valueY < _firstPointY) ? valueY : _firstPointY);
            rectangle.SetValueTwo(Math.Abs(valueX - _firstPointX), Math.Abs(valueY - _firstPointY));
            _commandManager.Execute(new AddShapeCommand(this, rectangle));
        }

        //PointerReleased Rectangle
        public void ReleasePointerEllipse(double valueX, double valueY)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.SetValue((valueX < _firstPointX) ? valueX : _firstPointX, (valueY < _firstPointY) ? valueY : _firstPointY);
            ellipse.SetValueTwo(Math.Abs(valueX - _firstPointX), Math.Abs(valueY - _firstPointY));
            _commandManager.Execute(new AddShapeCommand(this, ellipse));
        }

        //Clear
        public void Clear()
        {
            _isPressed = false;
            _shape.Clear();
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
    }
}
