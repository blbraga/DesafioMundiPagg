using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.MerchantKey = ConfigurationManager.AppSettings["MerchantKey"];
            ViewBag.WebApi = ConfigurationManager.AppSettings["WebApi"];

            return View();
        }
    }
}