using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using MTN_Software_MVC.Models;
using System.Text;
using System.Net.Mail;

namespace MTN_Software_MVC.Controllers
{
    
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us.";

            return View();
        }

        public ActionResult Email()
        {
            ViewBag.Message = "Your email page.";

            return View();
        }

        public ActionResult Project()
        {
            ViewBag.Message = "Your project page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendEmail(MailModels e, string returnUrl)
        {
            /*if (ModelState.IsValid)
            {
                if (Request.IsAuthenticated)
                {
                    IdentityMessage ident = new IdentityMessage();
                    
                    ident.Subject = model.Email;
                    ident.Body = "test send";
                    ident.Destination = "thomas@mtnsoftware.net";
                    var username = Request.LogonUserIdentity.GetUserName();
                    var user = UserManager.EmailService;
                    await user.SendAsync(ident);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }*/
            if (ModelState.IsValid)
            {
                try
                {
                    StringBuilder message = new StringBuilder();
                    MailAddress from = new MailAddress(e.Email.ToString());
                    message.Append("Name: " + e.Name + "\n");
                    message.Append("Email: " + e.Email + "\n\n");
                    message.Append(e.Message);

                    MailMessage mail = new MailMessage();

                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = e.SmtpHost; //"imap.ox.registrar-servers.com"; //smtp.mail.privateemail.com
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential(e.Email, e.emailPass);
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                    mail.From = from;
                    mail.To.Add("thomas@mtnsoftware.net");
                    mail.Subject = "Test enquiry from " + e.Email;
                    mail.Body = message.ToString();
                    mail.Priority = MailPriority.Normal;

                    smtp.Send(mail);
                    smtp.Dispose();
                    e.IsErr = false;
                }
                catch (Exception ex )
                {

                    ModelState.AddModelError("Err", "Sorry! This service is currently unavailable...");
                    e.IsErr = true;
                }
                
            }
            return View("Email");
        }

        public ActionResult Stress()
        {
            return View();
        }
    }
}