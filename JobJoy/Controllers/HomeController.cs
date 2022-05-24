using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobJoy.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private static string ApiKey = "AIzaSyBjX260O1uOmbOH1lSFObVnzBh0LaWcwvk";
        private static string AuthEmail = "";
        private static string AuthPassword = "";
        private static string Bucket = "https://jobjoyusn-default-rtdb.europe-west1.firebasedatabase.app/";

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
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}