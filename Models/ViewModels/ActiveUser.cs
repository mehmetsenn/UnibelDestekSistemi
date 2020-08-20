using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnibelDestekSistemi.Models.ViewModels
{
    public class ActiveUser
    {
        [Required(ErrorMessage = "Kullanıcı Adı gereklidir.")]
        [Display(Name = "KullaniciAdi")]
        [StringLength(16, MinimumLength = 4)]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        [Display(Name = "Sifre")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }


    }
}
