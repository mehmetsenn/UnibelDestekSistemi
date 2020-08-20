using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UnibelDestekSistemi.Controllers.Staff
{
    public class AddCustomerController : Controller
    {
        [Route("/AddCustomer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}