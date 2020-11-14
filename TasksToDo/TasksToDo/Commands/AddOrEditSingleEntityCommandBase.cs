using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksToDo.Commands
{
    public abstract class AddOrEditSingleEntityCommandBase : SingleEntityCommandBase
    {
        public bool IsAdding => Id == 0;
    }
}
