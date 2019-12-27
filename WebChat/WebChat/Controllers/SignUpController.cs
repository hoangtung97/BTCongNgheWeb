using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace WebChat.Controllers
{
    public class SignUpController : Controller
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
                newUser.Password_ = GetMd5Hash(password);
                newUser.Avatar = "/Content/img/avatars/default_icon.png";

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