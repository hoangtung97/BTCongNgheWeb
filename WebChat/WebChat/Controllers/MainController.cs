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

            var table_room_user = from a in database.Room_Users
                                  join conv in (from b in database.ChatRooms
                                                join c in database.Conversations on b.RoomID equals c.RoomID
                                                select new
                                                {
                                                    RoomID = b.RoomID,
                                                    RoomName = b.RoomName,
                                                    UserID = c.UserID,
                                                    Time = c.C_Time,
                                                    Content = c.Content
                                                })
                                  on a.RoomID equals conv.RoomID
                                  where a.UserID == currentUser.userID

                                  select new { roomID = a.RoomID, roomName = conv.RoomName, };


            List < CustomChatRoom > roomList = new List<CustomChatRoom>();

            foreach (var item in table_room_user)
            {
                roomList.Add( new CustomChatRoom { RoomID = item.roomID , RoomName = item.roomName } );
            }

            
            return View(roomList);
        }
    }
}