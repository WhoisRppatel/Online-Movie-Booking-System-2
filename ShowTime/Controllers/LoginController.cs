using ShowTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShowTime.Controllers
{
    public class LoginController : Controller
    {
        private Moviecontext db = new Moviecontext();
        // GET: Login
        public ActionResult Login()
        {
            if(Session["username"]!=null)
            {
                Session.Clear();
                Session.Abandon();
            }
            return View();
        }

        public ActionResult validateRegister(string unm,string pass , string repass)
        {
            var aa = from p in db.Users select p.username;
            List<string> users = new List<string>();
            foreach(string ab in aa)
            {
                users.Add(ab);
            }
            if (users.Contains(unm))
            {
                return RedirectToAction("Register", "Login", new { problem = "Username already taken try something else" });
            }
            else if(pass!=repass)
            {
                return RedirectToAction("Register", "Login", new { problem = "password not matched with re-enter password" });
            }
            else
            {
                var myuser = new User
                {
                    username = unm,
                    password = pass
                };
                db.Users.Add(myuser);
                db.SaveChanges();
                
            }
            string unm2 = unm;
            string pass2 = pass;
            return RedirectToAction("validatelogin", "Login", new {unm=unm2,pass=pass2 });
        }
        public ActionResult Register(string problem)
        {
            ViewData["prob"] = problem;
            return View();
        }
        public ActionResult validatelogin(string unm,string pass)
        {
            var aa = from p in db.Users where p.username==unm && p.password==pass select p.user_id;
            int c=aa.Count();
            if(c ==0)
                return RedirectToAction("Register", "Login", new { problem = "No User Found" });
            else
            {
                int ab=aa.FirstOrDefault();
                Session["userid"] = ab;
                Session["username"] = unm;
                return Redirect("/Home/Index");
            }
        }
    }
}