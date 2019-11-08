using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Controllers.DbModuls
{
    public class DbDelete
    {
        Models.ChatWebsiteEntities database = new Models.ChatWebsiteEntities();

        //su dung de xoa mot user ra khoi room khi user thoat khoi room
        public static void deleteUserFromRoom( int userID, int roomID)
        {

        }
    }
}