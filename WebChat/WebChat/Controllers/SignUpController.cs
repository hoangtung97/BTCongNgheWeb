using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebChat.Controllers
{
    public class SignUpController : Controller
    {

        // GET: SignUp
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp( string username, string displayname, string password, string checkpw)
        {

            return RedirectToAction("Main", "Main");
        }
    }
}