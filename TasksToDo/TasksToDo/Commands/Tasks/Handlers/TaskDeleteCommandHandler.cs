using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TasksToDo.Infrastructure;

namespace TasksToDo.Commands.Tasks.Handlers
{
    public class TaskDeleteCommandHandler : SingleTaskCommandHandlerBase, IRequestHandler<TaskDeleteCommand, CommandResult>
    {
        public TaskDeleteCommandHandler(DataContext context)
            : base(context)
        {
        }

       

        public async Task<CommandResult> Handle(TaskDeleteCommand command, CancellationToken cancellationToken)
        {
            var task = await GetTask(command.Id);
            Context.Tasks.Remove(task);
            await Context.SaveChangesAsync();
            return CommandResult.SuccessResult();
        }
    }
}
