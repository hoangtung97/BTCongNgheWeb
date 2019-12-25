using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Models
{
    public class ViewModel
    {
        public IEnumerable<WebChat.Models.User> Users { get; set; }
        public IEnumerable<WebChat.Models.ChatRoom> ChatRoom { get; set; }
        public IEnumerable<WebChat.Models.Room_Users> Room_Users { get; set; }
    }
}