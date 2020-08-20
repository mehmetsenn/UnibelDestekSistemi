using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UnibelDestekSistemi.Controllers.Staff
{

    public class ShowTicketController : Controller
    {
        [Route("/showTicket")]
        public IActionResult Index()
        {
            ViewBag.ticket();
            return View();
        }

        
    }
}