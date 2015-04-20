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
        public void SendEmail()
        {
            // Arrange
            MailModels e = new MailModels();
            string returnUrl = string.Empty;
            HomeController controller = new HomeController();
            e.Email = "ThomasTNF@live.com";
            e.emailPass = "beLndt123";
            e.SmtpHost = "smtp.live.com";
            e.Name = "Thomas";
            e.Message = "Test message";

            // Act
            ActionResult result = controller.SendEmail(e, returnUrl) as ActionResult;
            
            // Assert
            Assert.AreEqual(false, e.IsErr);

            //ActionResult res = result.RunSynchronously();
            
        }

        [TestMethod]
        public void Stress()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Stress() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
