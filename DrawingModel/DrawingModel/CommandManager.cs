using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class CommandManager
    {
        private Stack<ICommand> _commandUndoStack = new Stack<ICommand>();
        private Stack<ICommand> _commandRedoStack = new Stack<ICommand>();

        //Execute
        public void Execute(ICommand command)
        {
            command.Execute();
            _commandUndoStack.Push(command);
            _commandRedoStack.Clear();
        }

        //Undo
        public void Undo()
        {
            const string TEXT = "Cannot Undo exception\n";

            if (_commandUndoStack.Count <= 0)
                throw new Exception(TEXT);

            ICommand temp = _commandUndoStack.Pop();
            _commandRedoStack.Push(temp);
            temp.UndoExecute();
        }

        //Redo
        public void Redo()
        {
            const string TEXT = "Cannot Redo exception\n";

            if (_commandRedoStack.Count <= 0)
                throw new Exception(TEXT);

            ICommand temp = _commandRedoStack.Pop();
            _commandUndoStack.Push(temp);
            temp.Execute();
        }

        //IsRedoEnabled
        public bool IsRedoEnabled
        {
            get
            {
                return _commandRedoStack.Count != 0;
            }
        }

        //IsUndoEnabled
        public bool IsUndoEnabled
        {
            get
            {
                return _commandUndoStack.Count != 0;
            }
        }

        //ClearStack
        public void ClearStack()
        {
            this._commandUndoStack.Clear();
            this._commandRedoStack.Clear();
        }
    }
}
