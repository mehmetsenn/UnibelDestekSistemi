using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UnibelDestekSistemi.Models;
using UnibelDestekSistemi.Models.ViewModels;
using UnibelDestekSistemi.Models.DBHandler;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace UnibelDestekSistemi.Controllers
{
    public class ProfileController : BaseController
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            return Redirect("/Dashboard");
        }
        
        [HttpPost]
        public IActionResult ChangePassword(SifreDegistirme user)
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
                        TempData["uyarı"] = "" + "Şimdiki şifreniz hatalı";
                        return Redirect("/Dashboard");
                    }

                    if (yenisifre1 != yenisifre2)
                    {
                        TempData["uyarı"] = "" + "Yeni şifreler uyuşmuyor";
                        return Redirect("/Dashboard");
                    }

                    if (Tpassword1 == "True")
                    {
                        TempData["uyarı"] = "" + "Yeni şifreniz eskisiyle aynı";
                        return Redirect("/Dashboard");
                    }

                    var user2 = _db.Kullanici.FirstOrDefault(x => x.KullaniciAdi.Equals(userName));

                    try
                    {
                        var salt = locker.HashCreate();
                        user2.Sifre = locker.HashCreate(yenisifre1, salt);
                    }
                    catch (Exception)
                    {
                        TempData["uyarı"] = "" + "Bir hata oluştu, tekrar deneyin.";
                    }

                    _db.Kullanici.Update(user2);
                    _db.SaveChanges();
                }
                else
                {
                    TempData["uyarı"] = "" + "Lütfen şifrenizi 8-16 karakter aralığında seçin.";
                    return Redirect("/Dashboard");
                }
            }

            catch(Exception)
            {
                return Redirect("/Dashboard");
            }
            return Redirect("/Logout");
        }

    }
}
