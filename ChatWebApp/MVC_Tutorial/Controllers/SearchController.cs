using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Tutorial.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        
        //{controller}/{search content}

        public string Result()
        {
            return "This is search page";
        }

        [ActionName("Search")]
        public ActionResult Searching( string name )
        {
            var input = Server.HtmlEncode(name);
            return Content(input);
        }
    }
}