using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksToDo.ViewModels;

namespace TasksToDo.Queries
{
    public class TasksDeleteViewModel : SingleEntityViewModelBase
    {
        public string Description { get; set; }
    }
}
