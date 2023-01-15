using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hotel.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn([Bind(Exclude ="RuoloDip")]Users u)
        {
            if(Users.Auth(u.UsernameDip, u.PasswordDip))
            {
                FormsAuthentication.SetAuthCookie(u.UsernameDip, false);
                return Redirect(FormsAuthentication.DefaultUrl);
            }
            ViewBag.messaggio = "Username e/o Password errati!";
            return View();
        }
    }
}