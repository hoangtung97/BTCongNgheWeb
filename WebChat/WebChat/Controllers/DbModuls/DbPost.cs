using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace WebChat.Controllers.DbModuls
{
    public class DbPost
    {
        public static Models.ChatWebsiteEntities database = new Models.ChatWebsiteEntities();

        //Them phong
        public static void addGroup( string roomName, int adminID, string roomPW )
        {
            Models.ChatRoom room = new Models.ChatRoom();

            int id = Controllers.SystemStatus.SystemStatus.TotalRoomNumber++;

            room.RoomID = id;
            room.RoomName = roomName;
            room.RoomAdmin = adminID;
            room.RoomPW = roomPW;

            database.ChatRooms.Add(room);
            database.SaveChanges();
        }

        //Them nguoi dung
        public static void addUser( string username, string displayname, string password)
        {
            Models.User user = new Models.User();

            int id = Controllers.SystemStatus.SystemStatus.TotalUserNumber++;

            user.UserID = id;
            user.Username = username;
            user.DisplayName = displayname;
            user.Password_ = password;

            database.Users.Add(user);
            database.SaveChanges();
        }
    }
}