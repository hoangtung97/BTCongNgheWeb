using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebChat.Controllers
{
    public class SignUpController : Controller
    {
        private static string message = null;
        private static bool isvalid = false;
        // GET: SignUp
        public ActionResult SignUp()
        {
            if( message != null && isvalid )
            {
                message = null;
                return RedirectToAction("LogIn", "LogIn");
            }
            else
            {
                message = null;
                return View();
            }
        }

        [HttpPost]
        public ActionResult SignUp( string username, 
            string displayname, 
            string password, 
            string sex,
            string birthdate )
        {
            if( DbModuls.DbGet.usernameExist(username))
            {
                message = "Sign up successfully";
                isvalid = true;

                Models.User newUser = new Models.User();

                newUser.Username = username;
                newUser.DisplayName = displayname;
                newUser.Sex = sex;
                newUser.DateOfBirth = DateTime.Parse(birthdate);
                newUser.Password_ = password;

                DbModuls.DbAdd.addUser(newUser);
            }
            else
            {
                message = "Username already exists!";
                isvalid = false;
            }
            ViewBag.Message = message;

            return RedirectToAction("SignUp", "SignUp");
            //return View();
        }

        [HttpPost]
        public JsonResult usernameExist( string Username)
        {
            return Json(DbModuls.DbGet.usernameExist(Username));
        }
    }
}