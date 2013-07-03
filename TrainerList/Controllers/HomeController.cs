using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Xml;
using System.Collections.Specialized;
using TrainerList.Functions;

namespace TrainerList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Think about something to put in here";

            return View();
        }

        public ActionResult About()
        {
            
            try
            {
                 
              //  ServerComunication Server = new ServerComunication();
              //  String Response = Server.DoGet("/trainer/a36dfec1f123670e36885e88eb0009e8");
                Console.WriteLine(Response);
            }
            catch (System.Net.WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (System.ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
