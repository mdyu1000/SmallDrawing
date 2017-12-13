using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public Form1()
        {
            InitializeComponent();
            //
            // prepare presentation model and model
            //
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
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

        //HandleClearButtonClick
        public void HandleClearButtonClick(object sender, EventArgs e)
        {
            _model.Clear();
        }

        //HandleCanvasPressed
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _presentationModel.DrawCanvas();
            _model.PressPointer(e.X, e.Y, _presentationModel.IsButtonLinePressed(), _presentationModel.IsButtonRectanglePressed(), _presentationModel.IsButtonEllipsePressed());
            RefreshState();
        }

        //HandleCanvasReleased
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _presentationModel.ReleaseCanvas();
            _model.ReleasePointer(e.X, e.Y);
            RefreshState();
        }

        //HandleCanvasMoved
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.MovePointer(e.X, e.Y);
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

        //RefreshState
        public void RefreshState()
        {
            _buttonRectangle.Enabled = _presentationModel.IsButtonShapeEnabled();
            _buttonLine.Enabled = _presentationModel.IsButtonShapeEnabled();
            _buttonEllipse.Enabled = _presentationModel.IsButtonShapeEnabled();
            _buttonClear.Enabled = _presentationModel.IsButtonShapeEnabled();
            _buttonRedo.Enabled = _presentationModel.IsButtonRedoEnabled();
            _buttonUndo.Enabled = _presentationModel.IsButtonUndoEnabled();
            Invalidate();
        }

        private void _buttonUpload_Click(object sender, EventArgs e)
        {
        }
    }
}