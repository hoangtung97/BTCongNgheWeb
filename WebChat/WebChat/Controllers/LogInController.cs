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
        private int? Validate( string username, string password )
        {
            using( WebChat.Models.ChatWebsiteEntities database = new Models.ChatWebsiteEntities())
            {
                var validate = (from user in database.Users
                                where user.Username == username && user.Password_ == password
                                select user).FirstOrDefault();

                return validate.UserID;
            }
        }
        // GET: LogIn
        public ActionResult LogIn()
        {
            //check cookie
            HttpCookie authenticate = Request.Cookies["userID"];

            if( authenticate == null || authenticate.Value == "")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Main", "Main");
            }
        }

        [HttpPost]
        public ActionResult LogIn( string username, string password, bool rememberMe = false)
        {
            Models.ChatWebsiteEntities chatWebsiteEntities = new Models.ChatWebsiteEntities();

            //string username = Request.Form["username"];
            //string password = Request.Form["pass"];

            int? validate = Validate( username, password );

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
                        HttpCookie displayNameCookie = new HttpCookie("displayName", DbModuls.DbGet.getSpecificUser(validate.Value).DisplayName.ToString());
                        //HttpCookie logged = new HttpCookie("Logged", Boolean.TrueString);

                        //set expire date
                        //var expireDate = rememberMe ? DateTime.Now.AddYears(1) : DateTime.Now.AddMinutes(20);

                        ////create an authenticate ticket
                        //var ticket = new FormsAuthenticationTicket(
                        //    1,
                        //    DbModuls.DbGet.getSpecificUser(validate.Value).DisplayName.ToString(),
                        //    DateTime.Now,
                        //    expireDate,
                        //    rememberMe,
                        //    validate.Value.ToString());

                        ////encrypt the cookie
                        //var encrypted = FormsAuthentication.Encrypt(ticket);
                        //var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);

                        ////set cookie expiration time equal the ticket expiration time
                        //if( ticket.IsPersistent)
                        //{
                        //    cookie.Expires = ticket.Expiration;
                        //}

                        ////add cookie to the list for outgoing response
                        //System.Web.HttpContext.Current.Response.Cookies.Add(cookie);

                        //string tempUserID = UserCredential.getUSerID();

                        //HttpCookie userIDCookie = new HttpCookie("userID", tempUserID);

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