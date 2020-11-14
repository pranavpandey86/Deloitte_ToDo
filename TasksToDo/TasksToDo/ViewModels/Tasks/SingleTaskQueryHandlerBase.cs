using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksToDo.Infrastructure;
using TasksToDo.Infrastructure.MediatR;

namespace TasksToDo.ViewModels.Tasks
{
    public abstract class SingleTaskQueryHandlerBase : QueryHandlerBase
    {
        protected SingleTaskQueryHandlerBase(DataContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        protected async Task<Models.TaskToDo> GetTask(int id)
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
