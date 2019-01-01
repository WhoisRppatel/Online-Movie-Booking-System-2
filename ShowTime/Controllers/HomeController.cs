using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShowTime.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Session["username"]==null)
                return Redirect("/Login/Login");
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

    }
}