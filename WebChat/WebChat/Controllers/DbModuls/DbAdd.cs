using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace WebChat.Controllers.DbModuls
{
    public class DbAdd
    {
        public static Models.ChatWebsiteEntities database = new Models.ChatWebsiteEntities();

        //Them phong
        public static void addRoom( string roomName, int adminID, string roomPW )
        {
            Models.ChatRoom room = new Models.ChatRoom();

            int id = Controllers.SystemStatus.SystemStatus.TotalRoomNumber++;

            room.RoomID = id;
            room.RoomName = roomName;
            room.RoomAdmin = adminID;
            room.RoomPW = roomPW;

            database.ChatRooms.Add(room);
            database.SaveChanges();

            //khi them phong tuc la admin cung la mot thanh vien cua phong do
            Models.Room_Users room_Users = new Models.Room_Users();

            room_Users.RoomID = id;
            room_Users.UserID = adminID;

            database.Room_Users.Add(room_Users);
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

        //Them tin nhan
        public static void addMessage( string content, int userID, int roomID)
        {
            Models.Conversation message = new Models.Conversation();

            message.RoomID = roomID;
            message.UserID = userID;
            message.Content = content;
            message.C_Time = DateTime.Now;

            database.Conversations.Add(message);
            database.SaveChanges();

        }

        //Them nguoi vao phong
        public static void addUserToRoom( int userID, int roomID)
        {
            Models.Room_Users room_Users = new Models.Room_Users();

            room_Users.RoomID = roomID;
            room_Users.UserID = userID;

            database.Room_Users.Add(room_Users);
            database.SaveChanges();
        }
    }
}