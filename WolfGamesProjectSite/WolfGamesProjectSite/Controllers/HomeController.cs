using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WolfGamesProjectSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Wolf Games.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "We love to hear from you.";

            return View();
        }

        public ActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
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