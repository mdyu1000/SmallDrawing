using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class ClearShapeCommand : ICommand
    {
        Model _model;
        List<Shape> _shape = new List<Shape>();

        public ClearShapeCommand(Model model, List<Shape> shape)
        {
            _model = model;
            _shape = shape;
        }

        //Execute
        public void Execute()
        {
            _model.UndoClear();
        }

        //UndoExecute
        public void UndoExecute()
        {
            _model.RedoClear();
        }

    }
}
