using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TasksToDo.Infrastructure;
using TasksToDo.Models;

namespace TasksToDo.Commands.Tasks.Handlers
{
    public class TaskAddOrEditCommandHandler : SingleTaskCommandHandlerBase, IRequestHandler<TaskAddOrEditCommand, CommandResult<int>>
    {
        private readonly IHttpContextAccessor _accessor;
        public TaskAddOrEditCommandHandler(DataContext context, IHttpContextAccessor httpContext)
            : base(context)
        {
            _accessor = httpContext;
        }

    

        public async Task<CommandResult<int>> Handle(TaskAddOrEditCommand request, CancellationToken cancellationToken)
        {
            
            Models.TaskToDo task;
            if (request.IsAdding)
            {
                int taskUserId = 0;
                var loggedUser = _accessor.HttpContext.Session.GetString("LoggedUser");
                if(loggedUser != null)
                {
                     taskUserId = Convert.ToInt32(loggedUser);
                }
                task = new Models.TaskToDo(request.Description, taskUserId);
                task.LastUpdatedDateTime = DateTime.Now.ToString();
                Context.Tasks.Add(task);
            }
            else
            {
                var user = await GetTasks(request.Id);
                task = await GetTask(request.Id);
                task.LastUpdatedDateTime = DateTime.Now.ToString();
                task.SetDetails(request.Description, user.UserId);
            }

            await Context.SaveChangesAsync();

            return CommandResult<int>.SuccessResult(task.Id);
        }

        private async Task<TaskToDo> GetTasks(int id)
        {
            var task = await Context.Tasks
                .SingleOrDefaultAsync(x => x.Id == id);
            if (task == null)
            {
                throw new NullReferenceException($"Task with id: {id} not found.");
            }

            return task;
        }
       
    }
}
