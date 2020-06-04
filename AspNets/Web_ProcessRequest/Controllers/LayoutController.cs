using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_ProcessRequest.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout
        public ActionResult Index()
        {
            ViewBag.DateTimeFromBackground = DateTime.Now;
            return View();
        }
    }
}