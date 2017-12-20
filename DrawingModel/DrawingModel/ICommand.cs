﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    interface ICommand
    {
        //Execute
        void Execute();

        //UndoExecute
        void UndoExecute();
    }
}
