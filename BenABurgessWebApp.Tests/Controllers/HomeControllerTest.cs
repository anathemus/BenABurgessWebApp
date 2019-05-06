using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BenABurgessWebApp.Controllers;

namespace BenABurgessWebApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Skills()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Skills() as ViewResult;

            // Assert
            Assert.AreEqual("Benjamin's Skills", result.ViewBag.Message);
        }

        [TestMethod]
        public void Projects()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Projects() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
