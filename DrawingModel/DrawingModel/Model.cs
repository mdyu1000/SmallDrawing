using System;
using System.Collections.Generic;
using System.Linq;

namespace DrawingModel
{
    public partial class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        private double _firstPointX;
        private double _firstPointY;
        private bool _isPressed = false;
        private Line _hint = new Line();
        private Rectangle _hintRectangle = new Rectangle();
        private Ellipse _hintEllipse = new Ellipse();
        private Arrow _hintArrow = new Arrow();
        private bool _isButtonLinePressed;
        private bool _isButtonRectanglePressed;
        private bool _isButtonEllipsePressed;
        private bool _isButtonArrowPressed;
        private List<Shape> _shape = new List<Shape>();
        private List<Shape> _reserveShape = new List<Shape>();
        private CommandManager _commandManager = new CommandManager();
        private const int NO_SELECT = -1;

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

                if (this.DetectSelectedIndex() != NO_SELECT)
                    this._shape[DetectSelectedIndex()].MoveSelected(valueX, valueY);

                NotifyModelChanged();
            }
        }

        //PointerReleased
        public void ReleasePointer(double valueX, double valueY)
        {
            if (_isPressed)
            {
                _isPressed = false;

                if (_isButtonLinePressed)
                    ReleasePointerLine(valueX, valueY);
                else if (_isButtonRectanglePressed)
                    ReleasePointerRectangle(valueX, valueY);
                else if (_isButtonEllipsePressed)
                    ReleasePointerEllipse(valueX, valueY);
                else if (_isButtonArrowPressed)
                    ReleasePointerArrow(valueX, valueY);

                ReleasePointerTwo(valueX, valueY);
                NotifyModelChanged();
            }
        }

        //ReleasePointerTwo
        public void ReleasePointerTwo(double valueX, double valueY)
        {
            if (this.DetectSelectedIndex() != NO_SELECT && IsMove())
            {
                this._shape[DetectSelectedIndex()].SaveDynamicValue(valueX, valueY);
                _commandManager.Execute(new MoveShapeCommand(this, _shape[DetectSelectedIndex()]));
            }
        }

        //DetectMovedIndex
        public bool IsMove()
        {
            if (_shape[DetectSelectedIndex()].GetValueX() != _shape[DetectSelectedIndex()].GetOriginalValueX())
                return true;

            return false;
        }

        //Draw
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();

            foreach (Shape DisplayShape in _shape)
            {
                DisplayShape.Draw(graphics);

                if (DisplayShape.IsSelected())
                    DisplayShape.DrawSelected(graphics);

                DrawTwo(graphics);
            }
        }

        //DrawTwo
        public void DrawTwo(IGraphics graphics)
        {
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

        //Delete
        public void DeleteCommand()
        {
            int index = 0;

            if (this.DetectSelectedIndex() != NO_SELECT)
                _commandManager.Execute(new DeleteShapeCommand(this, _shape[index]));

            NotifyModelChanged();
        }

        //DeleteSpecifyShape
        public void DeleteSpecifyShape()
        {
            if (this.DetectSelectedIndex() != NO_SELECT)
                this._shape.RemoveAt(DetectSelectedIndex());
        }

        //PressSelected
        public void PressSelected(double valueX, double valueY, bool isButtonSelectPressed)
        {
            SetCancelSelected();

            if (isButtonSelectPressed)
            {
                for (int i = _shape.Count - 1; i >= 0; i--)
                {
                    _shape[i].SetSelected(valueX, valueY); //判斷是否有點在shape內

                    if (_shape[i].IsSelected())
                    {
                        _shape[i].SaveValue(); //先儲存好移動前的原點座標
                        break;
                    }
                }
            }
            else
                SetCancelSelected();
        }

        //SetCancelSelected
        public void SetCancelSelected()
        {
            for (int i = _shape.Count - 1; i >= 0; i--)
                _shape[i].SetCancelSelected();
        }

        // Return which shape is selected?
        public int DetectSelectedIndex()
        {
            for (int i = 0; i < this._shape.Count; i++)
                if (_shape[i].IsSelected())
                    return i;

            return NO_SELECT;
        }
    }
}