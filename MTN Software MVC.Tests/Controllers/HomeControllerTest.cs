using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTN_Software_MVC;
using MTN_Software_MVC.Controllers;
using MTN_Software_MVC.Models;
using System.Threading.Tasks;

namespace MTN_Software_MVC.Tests.Controllers
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
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Email()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Email() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        [TestMethod]
        public async Task<ActionResult> Support(MailModels e, string returnUrl)
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            Task<ActionResult> result = controller.Support(e, returnUrl) as Task<ActionResult>;
            ActionResult res = await result;
            // Assert
            Assert.IsNotNull(res);
            //Assert.IsNull(res);

            //ActionResult res = result.RunSynchronously();
            return result.Result;
        }
    }
}
