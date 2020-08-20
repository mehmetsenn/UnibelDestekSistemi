using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UnibelDestekSistemi.Models.ViewModels
{
    public class DashboardModels 
    {
        public DashboardViewModel DashboardViewModel { get; set; }

        public SifreDegistirme SifreDegistirme { get; set; }
    }
}