using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace WebChat.Controllers
{
    public class LogInController : Controller
    {
        private static MD5 md5Hash = MD5.Create();
        static private string GetMd5Hash(string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        private int? Validate( string username, string password )
        {
            string new_pass = GetMd5Hash(password);
            using( WebChat.Models.ChatWebsiteEntities database = new Models.ChatWebsiteEntities())
            {
                var validate = (from user in database.Users
                                where user.Username == username && user.Password_ == new_pass
                                select user).FirstOrDefault();

                if( validate == null)
                {
                    return -1;
                }
                else
                {
                    return validate.UserID;
                }
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

                        userIDCookie.Expires.AddDays(10);
                        HttpContext.Response.SetCookie(displayNameCookie);
                        HttpContext.Response.SetCookie(userIDCookie);


                        //Session["UserCredential"] = new UserCredential( validate );
                        return RedirectToAction("Main", "Main");
                    }
            }

            ViewBag.Message = message;
            return View();
        }

    }
}