using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;
using Newtonsoft.Json;
using WebChat.Controllers.WebsocketManager;

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
            else if(action == "SEND_MESS")
            {
                //get and create data
                int idRoom = (int)jsonMess["id_room"];
                string mess = (string)jsonMess["messenge"];
                int idUser = (int)jsonMess["id"];
                var jsondata = new
                {
                    id = idUser,
                    messenge = mess,
                    id_room = idRoom
                };
                string data = JsonConvert.SerializeObject(jsondata).ToString();

                //get session of users and send data to its
                ArrayList userInRoom = Manager.roomsManager[Manager.mappingRooms[idRoom]];
                foreach (WebChat.Models.User user in userInRoom)
                {
                    try
                    {
                        mapSession[user.UserID].Send(data);
                    }
                    catch (Exception ex) {}
                }
            }
            

            //base.OnMessage(message);
        }
    }
}