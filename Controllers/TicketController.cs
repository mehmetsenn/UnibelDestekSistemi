using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UnibelDestekSistemi.Controllers
{
    public class StaffTicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}