using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WebChat.Models;
using WebChat.Models.CustomModel;

namespace WebChat.Controllers
{

    public class UserCredential
    {
        public int userID;
        public UserCredential( int? id)
        {
            this.userID = Int32.Parse( id.ToString() );
        }
    }

    public class MainController : Controller
    {

        // GET: Main
        public ActionResult Main()
        {
            HttpCookie cookie = Request.Cookies["user"];
            UserCredential currentUser = new UserCredential(Int32.Parse(cookie.Value));

            return View( Controllers.DbModuls.DbGet.getRoomList( currentUser.userID ));
        }
    }
}