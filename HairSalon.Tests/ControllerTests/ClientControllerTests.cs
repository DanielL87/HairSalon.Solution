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
        public void Client_ReturnsCorrect_View()
        {
            ClientController testController = new ClientController();

            ActionResult indexView = testController.Index();

            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }
    }
}