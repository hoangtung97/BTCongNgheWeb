using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Controllers.WebsocketManager
{
    public class Manager
    {
        public static Dictionary<int, Models.ChatRoom> mappingRooms = new Dictionary<int, Models.ChatRoom>();
        public static Dictionary<int, ArrayList> roomsManager = new Dictionary<int, ArrayList>();
        public static Dictionary<int, String> displayNamesMapping = new Dictionary<int, String>();

        public static void updateRoomsManager()
        {
            roomsManager.Clear();
            List<Models.ChatRoom> rooms = DbModuls.DbGet.getRoomList();
            foreach (Models.ChatRoom room in rooms)
            {
                roomsManager.Add(room.RoomID,new ArrayList(DbModuls.DbGet.getUserInRoom(room.RoomID)));
            }
        }

        public static void updateMappingRooms()
        {
            mappingRooms.Clear();
            List<Models.ChatRoom> rooms = DbModuls.DbGet.getRoomList();
            foreach (Models.ChatRoom room in rooms)
            {
                mappingRooms.Add(room.RoomID,room);
            }
        }

        public static void updateDisplayNamesMapping()
        {
            displayNamesMapping.Clear();
            List<Models.User> users = DbModuls.DbGet.getUserList();
            foreach (Models.User user in users)
            {
                displayNamesMapping.Add(user.UserID, user.DisplayName);
            }
        }
    }
}