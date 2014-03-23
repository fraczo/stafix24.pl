using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stafix24.pl.Models;
using stafix24.pl.Services;

namespace stafix24.pl.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            var msg = String.Format("Informacja z witryny STAFix24.pl od: {1}{0}Email:{2}{0}Komentarz:{3}{0}",
                Environment.NewLine,
                model.name,
                model.email,
                model.comment);

            var svc = new MailService();
            if (svc.SendMail("noreply@stafix24.pl", "jacek.rawiak@hotmail.com","::Inormacja z witryny Stafix24.pl::", msg))
            {
                 ViewBag.MailSent = true;
            }

            return View(); 
        }

        public ActionResult ProductDetails()
        {
            return View();
        }
    }
}
