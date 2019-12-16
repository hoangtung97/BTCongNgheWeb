using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Models.ChatBox
{
    public class ChatBox
    {
        public IEnumerable<Models.ChatRoom> ChatRoom { get; set; }
        public IEnumerable<Models.Room_Users> Room_Users { get; set; }
        public IEnumerable<Models.Conversation> Conversation { get; set; }
    }
}