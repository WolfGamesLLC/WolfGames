using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WolfGamesSite.Controllers
{
    public class HomeControllerMessages
    {
        private string message;

        public string Message
        {
            get
            {
                return message;
            }
        }

        public HomeControllerMessages(string message)
        {
            this.message = message;
        }

        public static string About()
        {
            return new HomeControllerMessages("About Wolf Games.").Message;
        }

        public static string Contact()
        {
            return new HomeControllerMessages("We love to hear from you.").Message;
        }

        public static string Error()
        {
            return new HomeControllerMessages("~/Views/Shared/Error.cshtml").Message;
        }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = HomeControllerMessages.About();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = HomeControllerMessages.Contact();

            return View();
        }

        public ActionResult Error()
        {
            return View(HomeControllerMessages.Error());
        }

        public ActionResult ThankYou()
        {
            ViewBag.Message = "Thank you from all of us at Wolf Games.";

            return View();
        }

        public ActionResult DevCorner()
        {
            ViewBag.Message = "Welcome to Wolf Games' dev corner.";

            return View();
        }
    }
}