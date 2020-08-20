using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UnibelDestekSistemi.Controllers
{
    public class PageNotFoundController : Controller
    {
        [Route("/pagenotfound")]
        public IActionResult Index()
        {
            return View();
        }
    }
}