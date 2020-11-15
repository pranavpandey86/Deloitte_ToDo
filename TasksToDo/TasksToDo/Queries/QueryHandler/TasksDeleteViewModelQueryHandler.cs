using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TasksToDo.Infrastructure;
using TasksToDo.ViewModels.Tasks;

namespace TasksToDo.Queries
{
    public class TasksDeleteViewModelQueryHandler : SingleTaskQueryHandlerBase, IRequestHandler<TasksDeleteViewModelQuery, TasksDeleteViewModel>
    {
        public TasksDeleteViewModelQueryHandler(DataContext context, IMapper mapper)
            : base(context, mapper)
        {
        }


        public async Task<TasksDeleteViewModel> Handle(TasksDeleteViewModelQuery query, CancellationToken cancellationToken)
        {
            var model = new TasksDeleteViewModel();
            var task = await GetTask(query.Id);
            Mapper.Map(task, model);
            return model;
        }
    }
}
