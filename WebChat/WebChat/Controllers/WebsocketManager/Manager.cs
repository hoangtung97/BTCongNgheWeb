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
        public static Dictionary<Models.ChatRoom, ArrayList> roomsManager = new Dictionary<Models.ChatRoom, ArrayList>();
        

        public static void updateRoomsManager()
        {
            roomsManager.Clear();
            List<Models.ChatRoom> rooms = DbModuls.DbGet.getRoomList();
            foreach (Models.ChatRoom room in rooms)
            {
                roomsManager.Add(room,new ArrayList(DbModuls.DbGet.getUserInRoom(room.RoomID)));
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
    }
}