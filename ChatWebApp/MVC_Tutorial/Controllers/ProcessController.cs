using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Tutorial.Controllers
{
    public class ProcessController : Controller
    {
        // GET: Process
        //public ActionResult Index()
        //{
        //    return View();
        //}
        
        //basic custom routing
        //Process/List
        public string List()
        {
            return "Process Page";
        }
    }
}