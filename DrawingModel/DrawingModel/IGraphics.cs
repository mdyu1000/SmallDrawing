using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public interface IGraphics
    {
        //ClearAll
        void ClearAll();

        //DrawLine
        void DrawLine(double x1, double y1, double x2, double y2);

        //DrawRectangle
        void DrawRectangle(double valueX, double valueY, double width, double height);

        //DrawEllipse
        void DrawEllipse(double valueX, double valueY, double width, double height);

        //DrawArrow
        void DrawArrow(double x1, double y1, double x2, double y2);
    }
}
