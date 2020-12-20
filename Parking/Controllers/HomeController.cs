using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parking.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Parking.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

           // ConfigSettings.WriteSetting("ConnectStringTest","Test5555");
            return View();
        }

       
    }
}
