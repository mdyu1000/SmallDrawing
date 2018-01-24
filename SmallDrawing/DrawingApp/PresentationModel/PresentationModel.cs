using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using DrawingModel;
namespace DrawingApp.PresentationModel
{
    class PresentationModel
    {
        Model _model;
        IGraphics _graphic;
        bool _isButtonShapeEnabled;
        bool _isButtonClearEnabled;
        bool _isButtonLinePressed;
        bool _isButtonEllipsePressed;
        bool _isButtonRectanglePressed;
        bool _isButtonArrowPressed;
        bool _isButtonSelectPressed;

        public PresentationModel(Model model, Canvas canvas)
        {
            this._model = model;
            _graphic = new WindowsStoreGraphicsAdaptor(canvas);
        }

        //Draw
        public void Draw()
        {
            // 重複使用igraphics物件
            _model.Draw(_graphic);
        }

        // Start Draw Line
        public void DrawCanvas()
        {
            if (_isButtonLinePressed || _isButtonRectanglePressed)
            {
                _isButtonShapeEnabled = false;
                _isButtonClearEnabled = false;
            }
        }

        // Finish Drawing
        public void ReleaseCanvas()
        {
            _isButtonShapeEnabled = true;
            _isButtonClearEnabled = true;
        }

        //ClickButtonRectangle
        public void ClickButtonRectangle()
        {
            _isButtonRectanglePressed = true;
            _isButtonLinePressed = false;
            _isButtonEllipsePressed = false;
            _isButtonArrowPressed = false;
            _isButtonSelectPressed = false;
        }

        //ClickButtonLine
        public void ClickButtonLine()
        {
            _isButtonLinePressed = true;
            _isButtonRectanglePressed = false;
            _isButtonEllipsePressed = false;
            _isButtonArrowPressed = false;
            _isButtonSelectPressed = false;
        }

        //ClickButtonLine
        public void ClickButtonEllipse()
        {
            _isButtonEllipsePressed = true;
            _isButtonRectanglePressed = false;
            _isButtonLinePressed = false;
            _isButtonArrowPressed = false;
            _isButtonSelectPressed = false;
        }

        //ClickButtonArrow
        public void ClickButtonArrow()
        {
            _isButtonArrowPressed = true;
            _isButtonEllipsePressed = false;
            _isButtonRectanglePressed = false;
            _isButtonLinePressed = false;
            _isButtonSelectPressed = false;
        }

        //ClickButtonSelect
        public void ClickButtonSelect()
        {
            _isButtonSelectPressed = true;
            _isButtonArrowPressed = false;
            _isButtonEllipsePressed = false;
            _isButtonRectanglePressed = false;
            _isButtonLinePressed = false;
        }

        //ClickButtonRedo
        public void ClickButtonRedo()
        {
            _model.Redo();
        }

        //ClickButtonUndo
        public void ClickButtonUndo()
        {
            _model.Undo();
        }

        //ClickButtonDelete
        public void ClickButtonDelete()
        {
            _model.DeleteCommand();
        }

        //IsButtonRectanglePressed
        public bool IsButtonArrowPressed()
        {
            return _isButtonArrowPressed;
        }

        //IsButtonRectanglePressed
        public bool IsButtonEllipsePressed()
        {
            return _isButtonEllipsePressed;
        }

        //IsButtonRectanglePressed
        public bool IsButtonRectanglePressed()
        {
            return _isButtonRectanglePressed;
        }

        //IsButtonLinePressed
        public bool IsButtonLinePressed()
        {
            return _isButtonLinePressed;
        }

        //Button Rectangle and Line State
        public bool IsButtonShapeEnabled()
        {
            return _isButtonShapeEnabled;
        }

        //Button Clear State
        public bool IsButtonClearEnabled()
        {
            return _isButtonClearEnabled;
        }

        //Button Redo State
        public bool IsButtonRedoEnabled()
        {
            return _model.IsRedoEnabled;
        }

        //Button Undo State
        public bool IsButtonUndoEnabled()
        {
            return _model.IsUndoEnabled;
        }

        //Button Delete State
        public bool IsButtonDeleteEnabled()
        {
            return _isButtonClearEnabled;
        }

        //IsButtonSelectPressed
        public bool IsButtonSelectPressed()
        {
            return _isButtonSelectPressed;
        }
    }
}