using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UnibelDestekSistemi.Controllers
{
    public class notificationController : Controller
    {
        [Route("/notification")]
        public IActionResult Index()
        {
            return View();
        }
    }
}