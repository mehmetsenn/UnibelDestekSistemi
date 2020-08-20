using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UnibelDestekSistemi.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;
using UnibelDestekSistemi.Models.DBHandler;

namespace UnibelDestekSistemi.Controllers.Customer
{
    public class CustomerChangeEmailController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Redirect("/Dashboard");
        }

        [HttpPost]
        public IActionResult CustomerChangeEmail(CustomerChangeEmail user)
        {
            string userName = User.Identity.Name;
            var email = _db.Kullanici.Where(c => c.KullaniciAdi == userName).Select(c => c.Eposta).SingleOrDefault();

            var eskimail = user.Email;
            var yenimail = user.newEmail;

            var control_db = _db.Kullanici.FirstOrDefault(x => x.Eposta.Equals(yenimail));

            try
            {
                if (ModelState.IsValid)
                {
                    if (email != eskimail)
                    {
                        TempData["eposta"] = "" + "Şimdiki e-postanız hatalı";
                        return Redirect("/Dashboard");
                    }

                    if (yenimail == eskimail)
                    {
                        TempData["eposta"] = "" + "Yeni e-postanız güncel e-postanızla aynı.";
                        return Redirect("/Dashboard");
                    }

                    if (control_db != null)
                    {
                        TempData["eposta"] = "" + "Yeni e-postanıza kayıtlı bir hesap zaten var.";
                        return Redirect("/Dashboard");
                    }

                    var user2 = _db.Kullanici.FirstOrDefault(x => x.KullaniciAdi.Equals(userName));
                    user2.Eposta = yenimail;
                    _db.Kullanici.Update(user2);
                    _db.SaveChanges();
                    return Redirect("/Dashboard");
                }

                else
                {
                    TempData["eposta"] = "" + "Lütfen şimdiki e-postanızı ve yeni e-postanızı düzgün bir şekilde girin.";
                    return Redirect("/Dashboard");
                }
            }

            catch(Exception)
            {
                return Redirect("/Dashboard");
            }
        }
    }

    

}