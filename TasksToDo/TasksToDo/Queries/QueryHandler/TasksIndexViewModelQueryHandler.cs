using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TasksToDo.Infrastructure;
using TasksToDo.Infrastructure.MediatR;

namespace TasksToDo.ViewModels.Tasks
{
    public class TasksIndexViewModelQueryHandler : QueryHandlerBase, IRequestHandler<TasksIndexViewModelQuery, TasksIndexViewModel>
    {
        private readonly IHttpContextAccessor _accessor;
        public TasksIndexViewModelQueryHandler(DataContext context, IMapper mapper , IHttpContextAccessor httpContext)
            : base(context, mapper)
        {
            _accessor = httpContext;
        }
        public async Task<TasksIndexViewModel> Handle(TasksIndexViewModelQuery request, CancellationToken cancellationToken)
        {
            var loggedUser = _accessor.HttpContext.Session.GetString("LoggedUser");

            var model = new TasksIndexViewModel
            {

                Items = await Context.Tasks


                     .OrderBy(x => x.Description).Where(x=> x.UserId == Convert.ToInt32(loggedUser))
                     .ProjectTo<TasksIndexViewModel.TaskListEntry>(Mapper.ConfigurationProvider)
                     .ToListAsync()
            };

            return model;
        }
    }
}
