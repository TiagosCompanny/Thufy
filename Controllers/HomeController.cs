using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Thufy.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("sobre-nos")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Route("institucional/contato")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
                
            return View();
        }
    }
}