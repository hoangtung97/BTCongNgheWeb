using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace WebChat.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn( Models.User user)
        {
            Models.ChatWebsiteEntities chatWebsiteEntities = new Models.ChatWebsiteEntities();

            string username = Request.Form["username"];
            string password = Request.Form["pass"];

            int? validate = chatWebsiteEntities.Validate(username, password).FirstOrDefault();

            string message = String.Empty;

            switch (validate)
            {
                case -1:
                    {
                        message = "Tên đăng nhập hoặc mật khẩu không đúng";
                        break;
                    }
                default:
                    {
                        //create cookies
                        HttpCookie userCookie = new HttpCookie("user", validate.ToString() );

                        userCookie.Expires.AddDays(10);

                        HttpContext.Response.SetCookie(userCookie);
                        //Session["UserCredential"] = new UserCredential( validate );
                        return RedirectToAction("Main", "Main");
                    }
            }

            ViewBag.Message = message;
            return View(user);
        }

        [ChildActionOnly]
        public ActionResult SignUp()
        {
            return SignUpRedirect();
        }
            

        //[NonAction]
        public ActionResult SignUpRedirect()
        {
            return RedirectToAction("SignUp", "SignUp");
        }
    }
}