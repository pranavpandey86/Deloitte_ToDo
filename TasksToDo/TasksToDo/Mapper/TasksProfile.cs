using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksToDo.Commands.Tasks;
using TasksToDo.Models;
using TasksToDo.ViewModels;
using static TasksToDo.ViewModels.Tasks.TasksIndexViewModel;

namespace TasksToDo.Mapper
{
    public class TasksProfile : Profile
    {
        public TasksProfile()
        {
            CreateMap<TaskToDo, TaskListEntry>();
            CreateMap<TaskToDo, TasksEditViewModel>();
            //CreateMap<Task, TasksDeleteViewModel>();

            CreateMap<TasksEditViewModel, TaskAddOrEditCommand>();
            //CreateMap<TasksDeleteViewModel, TaskDeleteCommand>();
        }
    }
}
