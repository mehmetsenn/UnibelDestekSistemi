using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UnibelDestekSistemi.Models.ViewModels
{
    public class ProfileSettings 
    {

        public string Foto { get; set; }

        public string FullName { get; set; }


        public int Sirket { get; set; }

        public string Unvan { get; set; } 

        public string Phone { get; set; }

        [Required(ErrorMessage = "Lütfen Eposta Adresi Giriniz.")]
        public string Eposta { get; set; }

        
    }
}