using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Models
{
    public class ChatBox
    {
        public Models.ChatRoom ChatRoom { get; set; }
        public Models.Conversation Conversation { get; set; }
    }
}