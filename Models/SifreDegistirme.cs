using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnibelDestekSistemi.Models
{
    public class SifreDegistirme
    {
        [Required]
        [Display(Name = "password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public CustomerChangeEmail customerChangeEmail { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "password")]
        [DataType(DataType.Password)]
        public string newpassword { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "password")]
        [DataType(DataType.Password)]
        public string confirmNewPassword { get; set; }


    }
}