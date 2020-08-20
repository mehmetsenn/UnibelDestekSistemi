using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UnibelDestekSistemi.Controllers.Customer
{
    public class allticketsController : Controller
    {
        [Route("/alltickets")]
        public IActionResult Index()
        {
            return View();
        }
    }
}