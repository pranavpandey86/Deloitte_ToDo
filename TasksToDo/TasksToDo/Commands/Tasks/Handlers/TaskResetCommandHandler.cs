using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TasksToDo.Infrastructure;

namespace TasksToDo.Commands.Tasks.Handlers
{
    public class TaskResetCommandHandler : SingleTaskCommandHandlerBase, IRequestHandler<TaskResetCommand, CommandResult>
    {
        public TaskResetCommandHandler(DataContext context)
            : base(context)
        {
        }

       

        public async Task<CommandResult> Handle(TaskResetCommand command, CancellationToken cancellationToken)
        {
            var task = await GetTask(command.Id);
            task.MarkIncomplete();
            task.LastUpdatedDateTime = DateTime.Now.ToString();
            await Context.SaveChangesAsync();
            return CommandResult.SuccessResult();
        }
    }
}
