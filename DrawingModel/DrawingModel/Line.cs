﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Line : Shape
    {

        //Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(GetValueX(), GetValueY(), GetValueX2(), GetValueY2());
        }

        //DrawSelected
        public override void DrawSelected(IGraphics graphics)
        {
            if (IsSelected())
                graphics.DrawLineSelected(GetValueX(), GetValueY(), GetValueX2(), GetValueY2());
        }

        //GetShapeFlag
        public override int GetShapeFlag()
        {
            return 1;
        }

        //MoveSelected
        public override void MoveSelected(double pointX, double pointY)
        {
            SetLineSide();

            if (GetValueX2() > GetValueX() && GetValueY2() > GetValueY())
            {
                this._valueX = pointX;
                this._valueY = pointY;
                this._valueX2 = this._valueX + _width;
                this._valueY2 = this._valueY + _height;
            }

            MoveSelectedTwo(pointX, pointY);
            MoveSelectedThree(pointX, pointY);
        }

        //MoveSelectedTwo
        public void MoveSelectedTwo(double pointX, double pointY)
        {
            if (GetValueX2() > GetValueX() && GetValueY2() < GetValueY())
            {
                this._valueX = pointX;
                this._valueY = pointY;
                this._valueX2 = this._valueX + _width;
                this._valueY2 = this._valueY - _height;
            }
        }

        //MoveSelected
        public void MoveSelectedThree(double pointX, double pointY)
        {
            if (GetValueX2() < GetValueX() && GetValueY2() < GetValueY())
            {
                this._valueX = pointX;
                this._valueY = pointY;
                this._valueX2 = this._valueX - _width;
                this._valueY2 = this._valueY - _height;
            }

            if (GetValueX2() < GetValueX() && GetValueY2() > GetValueY())
            {
                this._valueX = pointX;
                this._valueY = pointY;
                this._valueX2 = this._valueX - _width;
                this._valueY2 = this._valueY + _height;
            }
        }
    }
}
