using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksToDo.Commands.Tasks;
using TasksToDo.Commands.Tasks.Handlers;
using TasksToDo.ViewModels;
using TasksToDo.ViewModels.Tasks;

namespace TasksToDo.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        private const string NotificationMessageKey = "NotificationMessage";

        public TasksController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(TasksIndexViewModelQuery query)
        {
            var model = await _mediator.Send(query);
            model.NotificationMessage = TempData[NotificationMessageKey] as string;
            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            var model = await _mediator.Send(new TasksEditViewModelQuery());
            return View("Edit", model);
        }


        public async Task<IActionResult> Edit(TasksEditViewModelQuery query)
        {
            var model = await _mediator.Send(query);
            if (model.Id == 0)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TasksEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new TaskAddOrEditCommand();
                _mapper.Map(model, command);
                var result = await _mediator.Send(command);
                if (result.Success)
                {
                    TempData[NotificationMessageKey] = $"Task {(model.IsAdding ? "created" : "updated")}";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, result.ErrorMessage);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, bool completed, int? categoryId)
        {
            if (completed)
            {
                var command = new TaskCompleteCommand
                {
                    Id = id,
                };
                await _mediator.Send(command);
                TempData[NotificationMessageKey] = $"Task marked as completed";
            }
            else
            {
                var command = new TaskResetCommand
                {
                    Id = id,
                };
                await _mediator.Send(command);
                TempData[NotificationMessageKey] = $"Task reset";
            }
           

            return RedirectToAction("Index", categoryId.HasValue ? new { CategoryId = categoryId.Value } : null);
        }
    }
}
