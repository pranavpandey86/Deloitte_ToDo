using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TasksToDo.Infrastructure;

namespace TasksToDo.ViewModels.Tasks
{
    public class TasksEditViewModelQueryHandler : SingleTaskQueryHandlerBase, IRequestHandler<TasksEditViewModelQuery, TasksEditViewModel>
    {
        public TasksEditViewModelQueryHandler(DataContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<TasksEditViewModel> Handle(TasksEditViewModelQuery query)
        {
            var model = new TasksEditViewModel();
            if (query.Id > 0)
            {
                var task = await GetTask(query.Id);
                Mapper.Map(task, model);
            }

           

            return model;
        }

        public async Task<TasksEditViewModel> Handle(TasksEditViewModelQuery request, CancellationToken cancellationToken)
        {
            var model = new TasksEditViewModel();
            model.Id = 1;
          /*  if (request.Id > 0)
            {
                var task = await GetTask(request.Id);
                Mapper.Map(task, model);
            } */



            return model;
        }
    }
}
