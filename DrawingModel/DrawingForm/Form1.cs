using GoogleDriveUploader.GoogleDrive;
using GoogleDriveUploader.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DrawingForm
{
    public partial class Form1 : Form
    {
        DrawingModel.Model _model;
        PresentationModel.PresentationModel _presentationModel;
        GoogleDriveExample _google = new GoogleDriveExample();
        const int BUTTON_SIZE = 4;
        bool[] _isButtonPressed = new bool[BUTTON_SIZE];

        public Form1()
        {
            InitializeComponent();
            //
            // prepare presentation model and model
            //
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model);
            _model._modelChanged += HandleModelChanged;
        }

        // Start Draw Rectangle
        private void ClickButtonRectangle(object sender, EventArgs e)
        {
            _presentationModel.ClickButtonRectangle();
            RefreshState();
        }

        // Start Draw Line
        private void ClickButtonLine(object sender, EventArgs e)
        {
            _presentationModel.ClickButtonLine();
            RefreshState();
        }

        // Start Draw Ellipse
        private void ClickButtonEllipse(object sender, EventArgs e)
        {
            _presentationModel.ClickButtonEllipse();
            RefreshState();
        }

        // Start Draw Arrow
        private void ClickButtonArrow(object sender, EventArgs e)
        {
            _presentationModel.ClickButtonArrow();
            RefreshState();
        }

        //HandleClearButtonClick
        public void HandleClearButtonClick(object sender, EventArgs e)
        {
            _model.Clear();
            RefreshState();
        }

        private void ClickButtonSelect(object sender, EventArgs e)
        {
            _presentationModel.ClickButtonSelect();
            RefreshState();
        }

        //HandleCanvasPressed
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            const int TWO = 2;
            const int THREE = 3;
            _isButtonPressed[0] = _presentationModel.IsButtonLinePressed();
            _isButtonPressed[1] = _presentationModel.IsButtonRectanglePressed();
            _isButtonPressed[TWO] = _presentationModel.IsButtonEllipsePressed();
            _isButtonPressed[THREE] = _presentationModel.IsButtonArrowPressed();
            _presentationModel.DrawCanvas();
            _model.PressPointer(e.X, e.Y, _isButtonPressed);
            _model.PressSelected(e.X, e.Y, _presentationModel.IsButtonSelectPressed());
            RefreshState();
        }

        //HandleCanvasMoved
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.MovePointer(e.X, e.Y);
        }

        //HandleCanvasReleased
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _presentationModel.ReleaseCanvas();
            _model.ReleasePointer(e.X, e.Y);
            RefreshState();
        }

        //HandleCanvasPaint
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        //HandleModelChanged
        public void HandleModelChanged()
        {
            Invalidate(true);
        }

        //ClickButtonRedo
        private void ClickButtonRedo(object sender, EventArgs e)
        {
            _presentationModel.ClickButtonRedo();
            RefreshState();
        }

        //ClickButtonUndo
        private void ClickButtonUndo(object sender, EventArgs e)
        {
            _presentationModel.ClickButtonUndo();
            RefreshState();
        }

        //ClickButtonDelete
        private void ClickButtonDelete(object sender, EventArgs e)
        {
            _presentationModel.ClickButtonDelete();
            RefreshState();
        }

        //ClickButtonUpload
        private void ClickButtonUpload(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(this._canvas.Width, this._canvas.Height);
            this._canvas.DrawToBitmap(bitmap, new Rectangle(0, 0, this._canvas.Width, this._canvas.Height));
            bitmap.Save(@"img.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            this._google.UploadFile(@"img.jpg");
        }

        //RefreshState
        public void RefreshState()
        {
            _buttonRectangle.Enabled = _presentationModel.IsButtonShapeEnabled();
            _buttonLine.Enabled = _presentationModel.IsButtonShapeEnabled();
            _buttonEllipse.Enabled = _presentationModel.IsButtonShapeEnabled();
            _buttonArrow.Enabled = _presentationModel.IsButtonShapeEnabled();
            _buttonClear.Enabled = _presentationModel.IsButtonShapeEnabled();
            _buttonRedo.Enabled = _presentationModel.IsButtonRedoEnabled();
            _buttonUndo.Enabled = _presentationModel.IsButtonUndoEnabled();
            _buttonDelete.Enabled = _presentationModel.IsButtonShapeEnabled();
            Invalidate();
        }

    }
}