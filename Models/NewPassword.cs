using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UnibelDestekSistemi.Models
{
    public class NewPassword
    {
        [Required]
        [StringLength(16, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "password")]
        [DataType(DataType.Password)]
        public string newPassword { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "password")]
        [DataType(DataType.Password)]
        public string confirmNewPassword { get; set; }
    }
}