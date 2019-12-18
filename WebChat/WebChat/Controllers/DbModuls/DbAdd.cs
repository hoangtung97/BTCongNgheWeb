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

        //Tao phong
        public static void addRoom( string roomName, int adminID, string roomPW )
        {
            var idnum = from last_id in database.Room_Users
                        select last_id;

            Models.ChatRoom room = new Models.ChatRoom();

            int id = idnum.Max( m => m.RoomID ) + 1;

            room.RoomID = id;
            room.RoomName = roomName;
            room.RoomPW = roomPW;

            database.ChatRooms.Add(room);
            database.SaveChanges();

            //khi them phong tuc la admin cung la mot thanh vien cua phong do
            addUserToRoom(adminID, id, true);

        }

        //Them nguoi dung
        public static void addUser( Models.User newUser )
        {
            var idnum = from last_id in database.Users
                        select last_id;

            //Models.User user = new Models.User();

            newUser.UserID = idnum.Max( m => m.UserID ) + 1;

            //user.UserID = id;
            //user.Username = username;
            //user.DisplayName = displayname;
            //user.Password_ = password;

            database.Users.Add( newUser );
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
        public static void addUserToRoom( int userID, int roomID, bool adminRight)
        {
            Models.Room_Users room_Users = new Models.Room_Users();

            room_Users.RoomID = roomID;
            room_Users.UserID = userID;
            room_Users.AdminRight = adminRight;

            database.Room_Users.Add(room_Users);
            database.SaveChanges();
        }

        //yeu cau vao phong
        public static bool requestJoinRoom( int userID, int roomID, string enteredPw )
        {
            var auth = (from a in database.ChatRooms
                        where a.RoomID == roomID && a.RoomPW == enteredPw
                        select a).Count();

            if( auth == 0)
            {
                return false;
            }
            else
            {
                addUserToRoom(userID, roomID, false);
                return true;
            }
        }


    }
}