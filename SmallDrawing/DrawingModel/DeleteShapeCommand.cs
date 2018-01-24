using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class DeleteShapeCommand : ICommand
    {
        Model _model;
        Shape _shape;
        //add line
        public DeleteShapeCommand(Model model, Shape shape)
        {
            _model = model;
            _shape = shape;
        }

        //Execute
        public void Execute()
        {
            _model.DeleteSpecifyShape();
        }

        //UndoExecute
        public void UndoExecute()
        {
            _model.DrawShape(_shape);
        }

    }
}
