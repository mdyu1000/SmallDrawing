using DrawingModel;
using System.Windows.Forms;
using System.Drawing;
namespace DrawingForm.PresentationModel
{
    class PresentationModel
    {
        Model _model;
        bool _isButtonShapeEnabled;
        bool _isButtonClearEnabled;
        bool _isButtonEllipsePressed;
        bool _isButtonRectanglePressed;
        //Button Line預設值
        bool _isButtonLinePressed = true;


        public PresentationModel(Model model, Control canvas)
        {
            this._model = model;
        }

        //Draw
        public void Draw(System.Drawing.Graphics graphics)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作
            // 因此，Adaptor不能重複使用，每次都要重新new
            _model.Draw(new WindowsFormsGraphicsAdaptor(graphics));
        }

        // Start Draw Line
        public void DrawCanvas()
        {
            if (_isButtonLinePressed || _isButtonRectanglePressed || _isButtonEllipsePressed)
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

        //ClickButtonEllipse
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
