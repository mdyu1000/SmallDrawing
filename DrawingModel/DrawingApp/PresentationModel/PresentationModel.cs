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
        bool _isButtonRectanglePressed;
        bool _isButtonEllipsePressed;
        bool _isButtonLinePressed = true;

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
        }

        //ClickButtonLine
        public void ClickButtonLine()
        {
            _isButtonLinePressed = true;
            _isButtonRectanglePressed = false;
            _isButtonEllipsePressed = false;
        }

        //ClickButtonLine
        public void ClickButtonEllipse()
        {
            _isButtonEllipsePressed = true;
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
    }
}