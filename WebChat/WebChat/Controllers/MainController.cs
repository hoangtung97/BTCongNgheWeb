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
            HttpCookie cookie = Request.Cookies["userID"];
            if( cookie == null)
            {
                return RedirectToAction("LogIn", "LogIn");
            }
            
            UserCredential currentUser = new UserCredential(Int32.Parse(cookie.Value));


            WebsocketManager.Manager.updateRoomsManager();
            WebsocketManager.Manager.updateDisplayNamesMapping();
            WebsocketManager.Manager.updateMappingRooms();

            //return View( Controllers.DbModuls.DbGet.getUserRoomList( currentUser.userID ));
            //get all user in all room
            var Room_Users = Controllers.DbModuls.DbGet.GetRoom_Users();
            //get chat room user currently joined
            var ChatRoom = Controllers.DbModuls.DbGet.getUserRoomList(currentUser.userID);
            //get list of user join each room
            var AllUser = Controllers.DbModuls.DbGet.getUserList();

            ViewModel ViewModel1 = new ViewModel {ChatRoom = ChatRoom, Users = AllUser, Room_Users = Room_Users };

            return View(ViewModel1);
        }

        public ActionResult LogOut()
        {
            HttpCookie userID = Request.Cookies["userID"];
            HttpCookie displayName = Request.Cookies["displayName"];

            if( userID != null || displayName != null)
            {
                userID.Expires = DateTime.Now.AddDays(-1);
                displayName.Expires = DateTime.Now.AddDays(-1);

                Response.Cookies.Add(userID);
                Response.Cookies.Add(displayName);
            }

            return RedirectToAction("LogIn", "LogIn");
        }

        public string GetCookie(string name)
        {
            string cookie = this.GetCookie(name);
            return cookie;
        }

        public JsonResult GetConversations(int room)
        {
            List<Models.CustomModel.CustomConversations> getUserConversations = DbModuls.DbGet.getUserConversations(room);
            return Json(getUserConversations, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteUserInRoom(int userid, int roomid)
        {
            DbModuls.DbDelete.deleteUserFromRoom(userid, roomid);
            return RedirectToAction("Main");
        }

    }
}