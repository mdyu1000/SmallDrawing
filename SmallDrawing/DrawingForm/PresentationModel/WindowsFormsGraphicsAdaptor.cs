﻿using System.Drawing;
using DrawingModel;
namespace DrawingForm.PresentationModel
{
    class WindowsFormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        private const int PEN_THICK = 5;
        Pen _redPen = new Pen(Color.Red, PEN_THICK);

        //WindowsFormsGraphicsAdaptor
        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        //ClearAll
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        //DrawLine
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //DrawRectangle
        public void DrawRectangle(double valueX, double valueY, double width, double height)
        {
            _graphics.FillRectangle(Brushes.Gold, (float)valueX, (float)valueY, (float)width, (float)height);
            _graphics.DrawRectangle(Pens.Black, (float)valueX, (float)valueY, (float)width, (float)height);
        }

        //DrawEllipse
        public void DrawEllipse(double valueX, double valueY, double width, double height)
        {
            _graphics.FillEllipse(Brushes.Gold, (float)valueX, (float)valueY, (float)width, (float)height);
            _graphics.DrawEllipse(Pens.Black, (float)valueX, (float)valueY, (float)width, (float)height);
        }

        //DrawArrow
        public void DrawArrow(double x1, double y1, double x2, double y2)
        {
            Pen pen = new Pen(Color.Blue, PEN_THICK);
            _graphics.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //DrawLineSelected
        public void DrawLineSelected(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(_redPen, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //DrawRectangleSelected
        public void DrawRectangleSelected(double valueX, double valueY, double width, double height)
        {
            _graphics.DrawRectangle(_redPen, (float)valueX, (float)valueY, (float)width, (float)height);
        }

        //DrawEllipseSelected
        public void DrawEllipseSelected(double valueX, double valueY, double width, double height)
        {
            _graphics.DrawEllipse(_redPen, (float)valueX, (float)valueY, (float)width, (float)height);
        }

        //DrawArrowSelected
        public void DrawArrowSelected(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(_redPen, (float)x1, (float)y1, (float)x2, (float)y2);
        }
    }
}