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
        [Authorize]
        public ActionResult LogIn( string username, string password, bool rememberMe )
        {
            Models.ChatWebsiteEntities chatWebsiteEntities = new Models.ChatWebsiteEntities();

            //string username = Request.Form["username"];
            //string password = Request.Form["pass"];

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
                        //HttpCookie userIDCookie = new HttpCookie("userID", validate.ToString());
                        //HttpCookie displayNameCookie = new HttpCookie("displayName", DbModuls.DbGet.getSpecificUser( validate.Value ).DisplayName.ToString());
                        //HttpCookie logged = new HttpCookie("Logged", Boolean.TrueString);

                        //set expire date
                        var expireDate = rememberMe ? DateTime.Now.AddYears(1) : DateTime.Now.AddMinutes(20);

                        //create an authenticate ticket
                        var ticket = new FormsAuthenticationTicket(
                            1,
                            validate.Value.ToString(),
                            DateTime.Now,
                            expireDate,
                            rememberMe,
                            DbModuls.DbGet.getSpecificUser(validate.Value).DisplayName.ToString());

                        //encrypt the cookie
                        var encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);

                        //set cookie expiration time equal the ticket expiration time
                        if( ticket.IsPersistent)
                        {
                            cookie.Expires = ticket.Expiration;
                        }

                        //add cookie to the list for outgoing response
                        System.Web.HttpContext.Current.Response.Cookies.Add(cookie);

                        //userIDCookie.Expires.AddDays(10);
                        //HttpContext.Response.SetCookie(displayNameCookie);
                        //HttpContext.Response.SetCookie(userIDCookie);

                        
                        //Session["UserCredential"] = new UserCredential( validate );
                        return RedirectToAction("Main", "Main");
                    }
            }

            ViewBag.Message = message;
            return View();
        }

    }
}