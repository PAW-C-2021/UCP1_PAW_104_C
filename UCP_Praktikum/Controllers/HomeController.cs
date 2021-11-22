using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UCP_Praktikum.Models;

namespace UCP_Praktikum.Controllers
{
    public class HomeController : Controller
    {
        db dbop = new db();
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Index([Bind] Ad_login ad)
        {
            int res = dbop.LoginCheck(ad);
            if (res == 1)
            {
                TempData["msg"] = "Selamat datang BOOS :)";
                Response.Redirect("Borrows/Index");
            }
            else
            {
                TempData["msg"] = "Maaf anda Bukan BOOS :(";

            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
