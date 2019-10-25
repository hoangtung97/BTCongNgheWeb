using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Models.CustomModel
{
    public class CustomConversations
    {
        public string Content { get; set; }
        public DateTime Time { get; set; }
        public int UserID { get; set; }
        public string UserDisplayName { get; set; }

        public CustomConversations( string content, DateTime time, int userID, string userDisplayName )
        {
            this.Content = content;
            this.Time = time;
            this.UserID = userID;
            this.UserDisplayName = userDisplayName;
        }
    }
}