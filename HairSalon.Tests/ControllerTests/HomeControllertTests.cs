using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class HomeControllerTest
    {

    [TestMethod]
    public void Create_ReturnsCorrectActionType_RedirectToActionResult()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            IActionResult view = controller.Index();

            //Assert
            Assert.IsInstanceOfType(view, typeof(ActionResult));
        }
    }
}