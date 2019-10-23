using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;

namespace WebApplication1
{
    public class WsHandler : WebSocketHandler
    {
        private static WebSocketCollection _procClients = new WebSocketCollection();
        public String userid { get; set; }
        public WsHandler()
        {

        }

        public override void OnOpen()
        {
            System.Diagnostics.Debug.WriteLine("Open");
            _procClients.Add(this);
            base.OnOpen();
        }
        public override void OnClose()
        {
            System.Diagnostics.Debug.WriteLine("Close");
            _procClients.Remove(this);
            base.OnClose();
        }

        public override void OnMessage(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
            //base.OnMessage(message);
        }
    }
}