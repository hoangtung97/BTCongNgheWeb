using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WebApplication1.Controllers
{
    [RoutePrefix("api/APIWS")]
    public class APIWSController : ApiController
    {
        public string Get(int id)
        {
            return "test";
        }

        public HttpResponseMessage Get()
        {
            if (System.Web.HttpContext.Current.IsWebSocketRequest)
            {
                System.Web.HttpContext.Current.AcceptWebSocketRequest(new WsHandler());
                return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
