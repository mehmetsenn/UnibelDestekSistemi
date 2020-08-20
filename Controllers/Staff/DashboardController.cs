using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using UnibelDestekSistemi.Models.DBHandler;
using UnibelDestekSistemi.Models.ViewModels;

namespace UnibelDestekSistemi.Controllers.Staff
{
    public class DashboardController : BaseController
    {
        
        public IActionResult Index()
        {
            string identity = User.Identity.Name;
            DashboardModels dashboardViewModel = new DashboardModels();
            dashboardViewModel.DashboardViewModel = new DashboardViewModel(identity);
            
            //ViewBag.loginedUser = _db.Kullanici.SingleOrDefault(x => x.KullaniciAdi.Equals(User.Identity.Name));
            ViewBag.pageHeader = "DASHBOARD";

            return View(dashboardViewModel);
        }
    }
}