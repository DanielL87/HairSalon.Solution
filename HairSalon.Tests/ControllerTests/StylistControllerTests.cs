using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistControllerTest
    {
        [TestMethod]
        public void Stylist_ReturnsCorrect_View()
        {
            StylistController testController = new StylistController();

            ActionResult indexView = testController.Index();

            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }
    }
}