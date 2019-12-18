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

        //sua thong tin cua nguoi dung
        public static void editUser( Models.User newUser )
        {
            Models.User user = new Models.User();

            user = database.Users.Single(u => u.UserID == newUser.UserID);
            user.DisplayName = newUser.DisplayName;
            user.DateOfBirth = newUser.DateOfBirth;
            user.Sex = newUser.Sex;
            user.Avatar = newUser.Avatar;
            
            database.SaveChanges();
        }

        //sua thong tin phong
        //neu khong thay doi phan nao thi de tham so null
        public static void editRoom( int roomID, string newRoomName, string newPW )
        {
            Models.ChatRoom room = new Models.ChatRoom();

            room = database.ChatRooms.Single(r => r.RoomID == roomID);
            if( newRoomName != null)
            {
                room.RoomName = newRoomName;
            }

            if( newPW != null)
            {
                room.RoomPW = newPW;
            }
            
            database.SaveChanges();
        }
    }
}