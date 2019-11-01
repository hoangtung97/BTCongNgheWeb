using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;

namespace WebApplication1
{
    public class WsHandler : WebSocketHandler
    {
        //private static WebSocketCollection _procClients = new WebSocketCollection();
        private static Dictionary<int, WsHandler> mapSession = new Dictionary<int, WsHandler>();

        public String userid { get; set; }
        public WsHandler()
        {

        }

        public override void OnOpen()
        {
            System.Diagnostics.Debug.WriteLine("Open");
            base.OnOpen();
        }
        public override void OnClose()
        {
            System.Diagnostics.Debug.WriteLine("Close");
            base.OnClose();
        }

        public override void OnMessage(string message)
        {
            // parse to json
            var jsonMess = Newtonsoft.Json.Linq.JObject.Parse(message);
            
            String action = (String)jsonMess["action"];

            //switch - case -> process with per action
            if(action == "ADD_U")
            {
                int id = (int)jsonMess["id"];
                if (mapSession.ContainsKey(id))
                {
                    mapSession[id] = this;
                }
                else
                {
                    mapSession.Add(id, this);
                }
            }
            

            //base.OnMessage(message);
        }
    }
}