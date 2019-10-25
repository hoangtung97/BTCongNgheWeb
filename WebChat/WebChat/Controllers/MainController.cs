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
        public UserCredential( int id)
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
            UserCredential currentUser = new UserCredential( Int32.Parse(cookie.Value) )/*(UserCredential)Session["UserCredential"]*/;

            ChatWebsiteEntities database = new ChatWebsiteEntities();

            var room_user = from a in database.Room_Users
                                  join b in database.ChatRooms
                                    on a.RoomID equals b.RoomID
                                  where a.UserID == currentUser.userID
                                  select new { roomID = b.RoomID, roomName = b.RoomName };

            var conversation = from r_u in room_user
                               join conv in database.Conversations
                               on 

            List < CustomChatRoom > roomList = new List<CustomChatRoom>();

            foreach (var item in room_user)
            {
                roomList.Add( new CustomChatRoom { RoomID = item.roomID , RoomName = item.roomName } );
            }

            
            return View(roomList);
        }
    }
}