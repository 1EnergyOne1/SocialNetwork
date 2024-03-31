using Microsoft.AspNetCore.Mvc;
using WebClientMVC.Controllers;
using Xunit;

namespace SocialHub.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexViewDataMessage()
        {
            //Начальная инициализация контекста теста
            HomeController controller = new HomeController();

            //Действие теста
            ViewResult result = controller.Index() as ViewResult;

            //Проверка результата
            Assert.Equal("Hello, World!", result?.ViewData["Index"]);
        }

        [Fact]
        public void IndexViewResultNotNull()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void IndexViewNameEqualIndex()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.Equal("Index", result?.ViewName);
        }
    }
}