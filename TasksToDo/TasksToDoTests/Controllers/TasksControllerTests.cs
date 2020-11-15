using Microsoft.VisualStudio.TestTools.UnitTesting;
using TasksToDo.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Moq;
using TasksToDo.ViewModels.Tasks;
using TasksToDo.Queries;
using System.Threading;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using TasksToDo.ViewModels;
using TasksToDo.Commands;
using TasksToDo.Commands.Tasks;

namespace TasksToDo.Controllers.Tests
{
    [TestClass()]
    public class TasksControllerTests
    {
       
        [TestMethod()]
        public void Index_Test()
        {
            //Arrange -
            
            var mediatRMock = new Mock<IMediator>();
            var mapperMock = new Mock<IMapper>();
            TasksIndexViewModel tVM = new TasksIndexViewModel();
            tVM.NotificationMessage = "NotificationMessage";
            TasksIndexViewModelQuery query = new TasksIndexViewModelQuery();
            mediatRMock.Setup(p => p.Send(It.IsAny<TasksIndexViewModelQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(tVM);

            var tasksController = new TasksController(mediatRMock.Object, mapperMock.Object);

            tasksController.ControllerContext.HttpContext = new DefaultHttpContext();
            var httpContext = tasksController.ControllerContext.HttpContext;
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData["NotificationMessage"] = "admin";
            tasksController.TempData = tempData;

            var actionResult= tasksController.Index(query);
            actionResult.Wait();
            var viewResult = actionResult.Result as ViewResult;
            Assert.IsNotNull(viewResult);




            //Assert.Fail();
        }

        [TestMethod()]
        public void TaskController_Add_Test()
        {
            //Arrange -

            var mediatRMock = new Mock<IMediator>();
            var mapperMock = new Mock<IMapper>();
            TasksIndexViewModel tVM = new TasksIndexViewModel();
            TasksIndexViewModelQuery query = new TasksIndexViewModelQuery();
            mediatRMock.Setup(p => p.Send(It.IsAny<TasksIndexViewModelQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(tVM);

            var tasksController = new TasksController(mediatRMock.Object, mapperMock.Object);

           
            var actionResult = tasksController.Add();
            actionResult.Wait();
            var viewResult = actionResult.Result as ViewResult;
            Assert.IsNotNull(viewResult);




            //Assert.Fail();
        }

        [TestMethod()]
        public void Edit_Test()
        {
            //Arrange -

            var mediatRMock = new Mock<IMediator>();
            var mapperMock = new Mock<IMapper>();
            TasksEditViewModel tVM = new TasksEditViewModel();
            tVM.Id = 1;
             TasksEditViewModelQuery query = new TasksEditViewModelQuery();
            
            mediatRMock.Setup(p => p.Send(It.IsAny<TasksEditViewModelQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(tVM);

            var tasksController = new TasksController(mediatRMock.Object, mapperMock.Object);

           // tasksController.ControllerContext.HttpContext = new DefaultHttpContext();
           // var httpContext = tasksController.ControllerContext.HttpContext;
           // var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
           // tempData["NotificationMessage"] = "admin";
           // tasksController.TempData = tempData;

            var actionResult = tasksController.Edit(query);
            actionResult.Wait();
            var viewResult = actionResult.Result as ViewResult;
            Assert.IsNotNull(viewResult);




            //Assert.Fail();
        }

        [TestMethod()]
        public void Edit_Test_VM()
        {
            //Arrange -

            var mediatRMock = new Mock<IMediator>();
            var mapperMock = new Mock<IMapper>();
            TasksEditViewModel tVM = new TasksEditViewModel();
            tVM.Id = 1;
            TasksEditViewModelQuery query = new TasksEditViewModelQuery();
           
            CommandResult<int> cmd = new CommandResult<int>();
            cmd.Success = true;
            mediatRMock.Setup(p => p.Send(It.IsAny<TaskAddOrEditCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(cmd);

            var tasksController = new TasksController(mediatRMock.Object, mapperMock.Object);

             tasksController.ControllerContext.HttpContext = new DefaultHttpContext();
             var httpContext = tasksController.ControllerContext.HttpContext;
             var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
             tempData["NotificationMessage"] = "admin";
             tasksController.TempData = tempData;

            var actionResult = tasksController.Edit(tVM);
            actionResult.Wait();
            var viewResult = actionResult.Result as object;
            Assert.IsNotNull(viewResult);




            //Assert.Fail();
        }
    }
}