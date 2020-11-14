using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksToDo.ViewModels.Tasks
{
    public class TasksEditViewModelQuery : IRequest<TasksEditViewModel>
    {
        public int Id { get; set; }
    }
}
