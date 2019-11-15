using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Security;

namespace WebChat.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult LogIn()
        {
            //check cookie
            HttpCookie validate = Request.Cookies["userID"];

            if( validate == null || validate.Value == "")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Main", "Main");
            }
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

            switch (validate.Value)
            {
                case -1:
                    {
                        message = "Tên đăng nhập hoặc mật khẩu không đúng";
                        break;
                    }
                default:
                    {
                        //create cookies
                        HttpCookie userIDCookie = new HttpCookie("userID", validate.ToString());
                        HttpCookie displayNameCookie = new HttpCookie("displayName", DbModuls.DbGet.getSpecificUser( validate.Value ).DisplayName.ToString());

                        userIDCookie.Expires.AddDays(10);
                        HttpContext.Response.SetCookie(displayNameCookie);
                        HttpContext.Response.SetCookie(userIDCookie);

                        
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