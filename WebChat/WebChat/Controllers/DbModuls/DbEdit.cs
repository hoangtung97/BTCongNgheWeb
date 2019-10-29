using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace WebChat.Controllers.DbModuls
{
    public class DbEdit
    {
        public static Models.ChatWebsiteEntities database = new Models.ChatWebsiteEntities();

        //sua ten hien thi cua nguoi dung
        public static void editUserDisplayName( int userID, string newDisplayName )
        {
            Models.User user = new Models.User();

            user = database.Users.Single(u => u.UserID == userID);
            user.DisplayName = newDisplayName;

            database.SaveChanges();
        }

        //sua ten phong
        public static void editRoomName( int roomID, string newRoomName)
        {
            Models.ChatRoom room = new Models.ChatRoom();

            room = database.ChatRooms.Single(r => r.RoomID == roomID);
            room.RoomName = newRoomName;

            database.SaveChanges();
        }
    }
}