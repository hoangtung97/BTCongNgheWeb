using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Controllers.DbModuls
{
    public class DbGet
    {
        public static Models.ChatWebsiteEntities database = new Models.ChatWebsiteEntities();

        //tra ve danh sach tat ca cac phong trong server
        public static List<Models.ChatRoom> getRoomList()
        {
            var room = from r in database.ChatRooms
                       select new { roomID = r.RoomID, roomName = r.RoomName };

            List<Models.ChatRoom> roomList = new List<Models.ChatRoom>();

            foreach (var item in room)
            {
                roomList.Add(new Models.ChatRoom { RoomID = item.roomID, RoomName = item.roomName });
            }

            return roomList;
        }

        public static List<Models.User> getUserList()
        {
            var user = from u in database.Users
                       select u;

            List<Models.User> userList = new List<Models.User>();

            foreach( var item in user)
            {
                userList.Add(item);
            }
            return userList;
        }

        //tra ve danh sach phong nguoi dung dang tham gia 
        public static List<Models.ChatRoom> getUserRoomList ( int userID ){
            
            var room_user = from a in database.Room_Users
                                  join b in database.ChatRooms
                                    on a.RoomID equals b.RoomID
                                  where a.UserID == userID
                                  select new { roomID = b.RoomID, roomName = b.RoomName };

            //var conversation = from r_u in room_user
            //                   join conv in database.Conversations
            //                   on 

            List < Models.ChatRoom > roomList = new List<Models.ChatRoom>();

            foreach (var item in room_user)
            {
                roomList.Add( new Models.ChatRoom { RoomID = item.roomID , RoomName = item.roomName } );
            }

            return roomList;
        }

        //tra ve danh sach tin nhan trong phong
        public static List<Models.CustomModel.CustomConversations> getUserConversations( int roomID)
        {
            var convlist = from room in database.ChatRooms
                           join conv in (from userconv in database.Conversations
                                         join user in database.Users
                                         on userconv.UserID equals user.UserID
                                         select new
                                         {
                                             RoomID = userconv.RoomID,
                                             UserID = userconv.UserID,
                                             UserDisplayName = user.DisplayName,
                                             Content = userconv.Content,
                                             Time = userconv.C_Time
                                         })
                           on room.RoomID equals conv.RoomID
                           where room.RoomID == roomID
                           select new
                           {
                               UserID = conv.UserID,
                               UserDisplayName = conv.UserDisplayName,
                               Content = conv.Content,
                               Time = conv.Time
                           };

            List<Models.CustomModel.CustomConversations> conversationList = new List<Models.CustomModel.CustomConversations>();

            foreach( var item in convlist)
            {
                conversationList.Add( new Models.CustomModel.CustomConversations ( item.Content, item.Time, item.UserID, item.UserDisplayName));
            }

            return conversationList;
        }

        //tra ve danh sach nguoi dung trong phong
        public static List< Models.User > getUserInRoom( int roomID )
        {
            var userlist = from room in database.Room_Users
                           join user in database.Users
                           on room.UserID equals user.UserID
                           where room.RoomID == roomID
                           select new { UserID = user.UserID, UserDisplayName = user.DisplayName,
                           };

            List<Models.User> usersList = new List<Models.User>();

            foreach( var item in userlist)
            {
                usersList.Add(new Models.User { UserID = item.UserID, DisplayName = item.UserDisplayName });
            }

            return usersList;
        }

        public static Models.User getSpecificUser( int userID)
        {
            var user = from u in database.Users
                       where u.UserID == userID
                       select u;

            return user.First();
        }
        
    }
}