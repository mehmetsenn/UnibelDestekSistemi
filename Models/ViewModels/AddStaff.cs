using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UnibelDestekSistemi.Models.ViewModels
{
    //Staff ViewModeli
    public partial class AddStaffViewModel
 {
        [Display(Name = "staffFullName")]
        public string staffFullName { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adı giriniz.")]
        [StringLength(16, MinimumLength = 3)]
        [Display(Name = "staffUsername")]
        public string staffUsername { get; set; }


        [Required(ErrorMessage = "Lütfen şifre giriniz.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 8)]
        public string newPassword { get; set; }

        [Required(ErrorMessage = "Lütfen şifre giriniz.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 8)]
        public string confirmNewPassword { get; set; }

        [Required(ErrorMessage = "Lütfen E-mail adresi giriniz.")]
        [Display(Name = "staffEmail")]
        [DataType(DataType.EmailAddress)]
        public string staffEmail { get; set; }

        [Required(ErrorMessage = "Lütfen bir departman seçiniz.")]
        [Display(Name = "SelectDepartment")]
        public int selectDepartment { get; set; }


        [Required(ErrorMessage = "Lütfen bir role seçiniz")]
        [Display(Name = "SelectRole")]
        public int selectRole { get; set; }

    }
}
