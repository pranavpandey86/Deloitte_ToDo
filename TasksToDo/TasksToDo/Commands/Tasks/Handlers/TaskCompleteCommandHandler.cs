using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TasksToDo.Infrastructure;

namespace TasksToDo.Commands.Tasks.Handlers
{
    public class TaskCompleteCommandHandler : SingleTaskCommandHandlerBase, IRequestHandler<TaskCompleteCommand, CommandResult>
    {
        public TaskCompleteCommandHandler(DataContext context)
            : base(context)
        {
        }

        

        public async Task<CommandResult> Handle(TaskCompleteCommand request, CancellationToken cancellationToken)
        {
            var task = await GetTask(request.Id);
            task.LastUpdatedDateTime = DateTime.Now.ToString();
            task.MarkComplete();
            await Context.SaveChangesAsync();
            return CommandResult.SuccessResult();
        }
    }
}
