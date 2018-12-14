using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientControllerTest
    {

    [TestMethod]
    public void Create_ReturnsCorrectActionType_RedirectToActionResult()
        {
            //Arrange
            ClientController controller = new ClientController();

            //Act
            IActionResult view = controller.Index(1);

            //Assert
            Assert.IsInstanceOfType(view, typeof(ActionResult));
        }
    }
}