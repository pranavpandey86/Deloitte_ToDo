using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksToDo.Queries
{
    public class TasksDeleteViewModelQuery : IRequest<TasksDeleteViewModel>
    {
        public int Id { get; set; }
    }
}
