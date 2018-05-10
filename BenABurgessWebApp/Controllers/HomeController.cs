using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Text;
using System.Threading;
using BenABurgessWebApp.Models;

namespace BenABurgessWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Benjamin's Bio";

            return View();
        }

        public ActionResult Skills()
        {
            ViewBag.Message = "Benjamin's Skills";

            return View();
        }

        public ActionResult Projects()
        {
            ViewBag.Message = "Benjamin's Projects";

            return View();
        }

        public ActionResult Education()
        {
            ViewBag.Message = "Benjamin's Education";

            return View();
        }

        public ActionResult Feedback()
        {
            ViewBag.Message = "Feedback for Benjamin";

            return View();
        }

        [HttpPost]
        public ActionResult Feedback(EmailModel e)
        {
            if (ModelState.IsValid)
            {

                //prepare email
                var toAddress = "benjamin.a.burgess@outlook.com";
                var fromAddress = e.Email.ToString();
                var subject = "Test enquiry from " + e.Name + " Re: " + e.Subject;
                var message = new StringBuilder();
                message.Append("Name: " + e.Name + "\n");
                message.Append("Email: " + e.Email + "\n");
                message.Append("Subject: " + e.Subject + "\n");
                message.Append(e.Message);
                var emailMessage = message.ToString();

                //start email Thread
                var tEmail = new Thread(() =>
                e.SendEmail(toAddress, fromAddress, subject, emailMessage));
                tEmail.Start();
            }
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            ViewBag.Message = "Privacy Policy";

            return View();
        }
    }
}