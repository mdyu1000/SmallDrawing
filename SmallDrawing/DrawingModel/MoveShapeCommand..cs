using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class MoveShapeCommand : ICommand
    {
        Model _model;
        Shape _shape;
        //add line
        public MoveShapeCommand(Model model, Shape shape)
        {
            _model = model;
            _shape = shape;
        }

        //Execute
        public void Execute()
        {
            this._shape.MoveSelected(_shape.GetMovePointX(), _shape.GetMovePointY());
            this._shape.RedoMoveShape();
        }

        //UndoExecute
        public void UndoExecute()
        {
            this._shape.MoveSelected(_shape.GetOriginalValueX(), _shape.GetOriginalValueY());
            this._shape.UndoMoveShape();
        }

    }
}
