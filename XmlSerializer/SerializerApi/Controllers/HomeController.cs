using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SerializerApi.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Returns Index page
        /// </summary>
        /// <returns>Index page</returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
