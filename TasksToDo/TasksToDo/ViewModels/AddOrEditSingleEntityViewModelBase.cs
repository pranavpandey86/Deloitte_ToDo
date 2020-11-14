using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksToDo.ViewModels
{
    public abstract class AddOrEditSingleEntityViewModelBase : SingleEntityViewModelBase
    {
        public bool IsAdding => Id == 0;
    }
}
