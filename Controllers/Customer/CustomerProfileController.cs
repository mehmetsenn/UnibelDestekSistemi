using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnibelDestekSistemi.Models.DBHandler;
using UnibelDestekSistemi.Models.ViewModels;

namespace UnibelDestekSistemi.Controllers.Customer
{
    public class CustomerProfileController : BaseController
    {

        
        [HttpGet]
        public IActionResult CustomerProfileSettings()
        {
            ProfileSettings ps = new ProfileSettings();
            var username = User.Identity.Name;
            var Kullanici = _db.Kullanici.FirstOrDefault(x => x.KullaniciAdi.Equals(username));
            ViewBag.SirketID = Kullanici.FkSirketId;
            ps.FullName = Kullanici.TamIsim;
            ps.Unvan = Kullanici.Unvan;
            ps.Eposta = Kullanici.Eposta;
            ps.Phone = Kullanici.KullaniciTel;
            ViewBag.NowSirket = Kullanici.FkSirket.SirketAdi;
            return View(ps);

        }


        [HttpPost]
        [AllowAnonymous]
        public  IActionResult CustomerProfileSettings(ProfileSettings user)
        {

			ProfileSettings ps = new ProfileSettings();
            var username = User.Identity.Name;
            var Kullanici = _db.Kullanici.FirstOrDefault(x => x.KullaniciAdi.Equals(username));
            if (ModelState.IsValid)
            {
                Kullanici.Unvan = user.Unvan;
                Kullanici.TamIsim = user.FullName;
                Kullanici.KullaniciTel = user.Phone;
                Kullanici.Eposta = user.Eposta;
                _db.Kullanici.Update(Kullanici);
                _db.SaveChanges();

            return Redirect("/CustomerProfile");

            }
            return Redirect("/CustomerProfile");
        }

    }
}