using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UnibelDestekSistemi.Models;
using Microsoft.Extensions.DependencyInjection;

namespace UnibelDestekSistemi.Controllers
{
    public class CustomerChangePasswordController : BaseController
    {
        [Route("/CustomerChangePassword")]
        [HttpGet]
        public IActionResult CustomerChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CustomerChangePassword(SifreDegistirme user)
        {
            string userName = User.Identity.Name;
            var password = _db.Kullanici.Where(c => c.KullaniciAdi == userName).Select(c => c.Sifre).SingleOrDefault();

            var eskisifre = user.password;
            var yenisifre1 = user.newpassword;
            var yenisifre2 = user.confirmNewPassword;

            var SCollection = new ServiceCollection();
            SCollection.AddDataProtection();
            var LockerKey = SCollection.BuildServiceProvider();
            var locker = ActivatorUtilities.CreateInstance<SecurityController>(LockerKey);

            string Tpassword;
            string Tpassword1;

            try
            {
                string getEncryptkey = password.Split('æ')[0];
                string getSalt = password.Split('æ')[1];
                Tpassword = locker.ValidateHash(eskisifre, getSalt, getEncryptkey).ToString();
                //eski şifre olarak girilenle database'den çekilen şifreler karşılaştırılır, true dönmesi demek eski şifre= database'den çekilen şifre
                Tpassword1 = locker.ValidateHash(yenisifre1, getSalt, getEncryptkey).ToString();
                //yeni şifreyi database'den çekilen şifreyle karşılaştırır, true dönmesi demek güncel şifre=yeni şifre (hata)
            }
            catch (Exception)
            {
                Tpassword = "False";
                Tpassword1 = "True";
            }

            try
            {
                if (ModelState.IsValid)
                {
                    if (Tpassword == "False")
                    {
                        TempData["sifre"] = "Şimdiki şifreniz hatalı";
                        return Redirect("/CustomerChangePassword");
                    }

                    if (yenisifre1 != yenisifre2)
                    {
                        TempData["sifre"] = "Yeni şifreler uyuşmuyor";
                        return Redirect("/CustomerChangePassword");
                    }

                    if (Tpassword1 == "True")
                    {
                        TempData["sifre"] = "Yeni şifreniz eskisiyle aynı";
                        return Redirect("/CustomerChangePassword");
                    }

                    var user2 = _db.Kullanici.FirstOrDefault(x => x.KullaniciAdi.Equals(userName));

                    try
                    {
                        var salt = locker.HashCreate();
                        user2.Sifre = locker.HashCreate(yenisifre1, salt);
                    }
                    catch (Exception)
                    {
                        TempData["sifre"] = "Bir hata oluştu, tekrar deneyin.";
                    }

                    _db.Kullanici.Update(user2);
                    _db.SaveChanges();
                }
                else
                {
                    TempData["sifre" ] = "Lütfen şifrenizi 8-16 karakter aralığında seçin.";
                    return Redirect("/CustomerChangePassword");
                }
            }

            catch (Exception)
            {
                return Redirect("/CustomerChangePassword");
            }
            return Redirect("/Logout");
        }
        
    }
}

