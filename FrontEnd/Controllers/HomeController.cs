using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrontEnd.Models;
using Microsoft.Extensions.Options;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppSettingsModel _appSettings;

        public HomeController(IOptions<AppSettingsModel> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public IActionResult Index()
        {
            ViewBag.MerchantKey = _appSettings.MerchantKey;
            ViewBag.WebApi = _appSettings.WebApi;

            return View();
        }
    }
}
