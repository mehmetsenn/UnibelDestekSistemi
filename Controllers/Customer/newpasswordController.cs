using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UnibelDestekSistemi.Models;
using Microsoft.Extensions.DependencyInjection;
using UnibelDestekSistemi.Models.DBHandler;

namespace UnibelDestekSistemi.Controllers.Customer
{
    public class NewPasswordController : Controller
    {
        public unibeldestekContext _db = new unibeldestekContext();

        [HttpGet]
        public IActionResult NewPassword(string Link)
        {
            string link = Link;
            var userName = _db.Kullanici.Where(c => c.Link == link).Select(c => c.KullaniciAdi).SingleOrDefault();
            var user2 = _db.Kullanici.FirstOrDefault(x => x.KullaniciAdi.Equals(userName));

            ViewBag.KullaniciAdi = userName;
            var now = DateTime.UtcNow;

            if (user2.EpostaSilmeZamani < now)
            {
                user2.Link = null;
                return Redirect("/");
            }
            return View();
        }

        [HttpPost]
        public IActionResult NewPassword(NewPassword user,string kullaniciAdi)
        {
            ViewBag.KullaniciAdi = kullaniciAdi;
            var SCollection = new ServiceCollection();
            SCollection.AddDataProtection();
            var LockerKey = SCollection.BuildServiceProvider();
            var locker = ActivatorUtilities.CreateInstance<SecurityController>(LockerKey);

            var yenisifre1 = user.newPassword;
            var yenisifre2 = user.confirmNewPassword;
            string Tpassword;

            var user2 = _db.Kullanici.FirstOrDefault(x => x.KullaniciAdi.Equals(kullaniciAdi));

            try
            {
                string getEncryptkey = user2.Sifre.Split('æ')[0];
                string getSalt = user2.Sifre.Split('æ')[1];
                Tpassword = locker.ValidateHash(yenisifre1, getSalt, getEncryptkey).ToString();
                //yeni şifreyi database'den çekilen şifreyle karşılaştırır, true dönmesi demek güncel şifre=yeni şifre (hata)
            }
            catch (Exception)
            {
                TempData["uyarı"] = "" + "Bir hata oluştu, tekrar deneyin.";
                return View();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    if (yenisifre1 != yenisifre2)
                    {
                        TempData["uyarı"] = "" + "Yeni şifreler uyuşmuyor";
                        return View();
                    }

                    else if (Tpassword == "True")
                    {
                        TempData["uyarı"] = "" + "Eski şifrenizle yeni şifreniz aynı olamaz";
                        return View();
                    }

                    else
                    {
                        var salt = locker.HashCreate();
                        user2.Sifre = locker.HashCreate(yenisifre1, salt);
                        user2.Link = null;
                        _db.SaveChanges();

                        return Redirect("/Logout");
                    }
                }
                
                else
                {
                    TempData["uyarı"] = "" + "Lütfen şifrenizi 8-16 karakter aralığında seçin.";
                    return View();
                }
            }

            catch (Exception)
            {
                TempData["uyarı"] = "" + "Bir hata oluştu, tekrar deneyin.";
                return View();
            }

        }




    }
}
