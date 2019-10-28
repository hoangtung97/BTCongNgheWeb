using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Controllers.SystemStatus
{
    public static class SystemStatus
    {
        public static int TotalRoomNumber;
        public static int TotalUserNumber;

        static SystemStatus()
        {
            using( Models.ChatWebsiteEntities database = new Models.ChatWebsiteEntities())
            {
                TotalRoomNumber = (from room in database.ChatRooms select room ).Count();
                TotalUserNumber = (from user in database.Users select user).Count();
            }
        }
    }
}