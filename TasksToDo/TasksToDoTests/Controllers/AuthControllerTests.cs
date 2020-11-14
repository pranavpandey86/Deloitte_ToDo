using Microsoft.VisualStudio.TestTools.UnitTesting;
using TasksToDo.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using TasksToDo.Services;
using TasksToDo.Models;
using TasksToDo.ViewModels.Login;
using Microsoft.AspNetCore.Http;

namespace TasksToDo.Controllers.Tests
{
    [TestClass()]
    public class AuthControllerTests
    {
        [TestMethod()]
        public void LoginTest()
        {
            //Arrange -->
            var User = new Users { UserId = 1, Pwd = "1234" };
            var distanceServiceMock = new Mock<IUserService>();


            distanceServiceMock.Setup(p => p.ValidateUserCredentialsAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((true, User));

            AuthController auth = new AuthController(distanceServiceMock.Object);
            LoginViewModel loginVM = new LoginViewModel();

            auth.ControllerContext.HttpContext = new DefaultHttpContext();

            var test = auth.Login(loginVM);

            Assert.IsNotNull(test);
        }


        [TestMethod()]
        public void Logout_Test()
        {
            //Arrange -->
            var User = new Users { UserId = 1, Pwd = "1234" };
            var distanceServiceMock = new Mock<IUserService>();
            distanceServiceMock.Setup(p => p.ValidateUserCredentialsAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((true, User));
            AuthController auth = new AuthController(distanceServiceMock.Object);
            LoginViewModel loginVM = new LoginViewModel();

            auth.ControllerContext.HttpContext = new DefaultHttpContext();

            //ACT
            var test = auth.Logout(loginVM);

            //ASSERT
            Assert.IsNotNull(test);
        }

        [TestMethod()]
        public void LoginURL_Test()
        {
            //Arrange -->
            var User = new Users { UserId = 1, Pwd = "1234" };
            var distanceServiceMock = new Mock<IUserService>();


            distanceServiceMock.Setup(p => p.ValidateUserCredentialsAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((true, User));

            AuthController auth = new AuthController(distanceServiceMock.Object);
            LoginViewModel loginVM = new LoginViewModel();

            auth.ControllerContext.HttpContext = new DefaultHttpContext();

            var test = auth.Login("");

            Assert.IsNotNull(test);
        }
    }
}