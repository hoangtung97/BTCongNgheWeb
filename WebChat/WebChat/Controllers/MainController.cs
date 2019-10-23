using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public List<Models.Room_Users> room = new List< Models.Room_Users >();

        // GET: Main
        public ActionResult Main()
        {
            UserCredential currentUser = (UserCredential)Session["UserCredential"];


            return View();
        }
    }
}