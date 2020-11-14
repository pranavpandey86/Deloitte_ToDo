using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksToDo.Commands.Tasks
{
    public class TaskAddOrEditCommand : AddOrEditSingleEntityCommandBase, IRequest<CommandResult<int>>
    {
        public string Description { get; set; }

        public int UserId { get; set; }

        public string LastUpdatedDateTime { get; set; }
    }
}
