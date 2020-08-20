using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using UnibelDestekSistemi.Models.DBHandler;
using UnibelDestekSistemi.Models.ViewModels;

namespace UnibelDestekSistemi.Controllers.Customer
{
    public class LoginPageController : BaseController
    {
        //unibeldestekContext _db = new unibeldestekContext();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(ActiveUser user)
        {
            var SCollection = new ServiceCollection();
            SCollection.AddDataProtection();
            var LockerKey = SCollection.BuildServiceProvider();
            var locker = ActivatorUtilities.CreateInstance<SecurityController>(LockerKey);

            var password = _db.Kullanici.Where(x => x.KullaniciAdi.Equals(user.KullaniciAdi)).Select(y => y.Sifre).SingleOrDefault();
            string Tpassword;
            try
            {
                string getEncryptkey = password.Split('æ')[0];
                string getSalt = password.Split('æ')[1];
                Tpassword = locker.ValidateHash(user.Sifre, getSalt, getEncryptkey).ToString();
            }
            catch (Exception )
            {
                Tpassword = "false";
            }
            var result = _db.Kullanici.FirstOrDefault(x => x.KullaniciAdi.Equals(user.KullaniciAdi) && Tpassword == "True");
            if (result != null)
            {
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name, user.KullaniciAdi),

                };

                var userIdentity = new ClaimsIdentity(claims, "login");
                var userdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                var name = User.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
                await HttpContext.SignInAsync(principal, new AuthenticationProperties { IsPersistent = true });

                //if (BeniHatirla.Checked)

                //Just redirect to our index after logging in. 
                return Redirect("/Dashboard");
            }
            else if (ModelState.IsValid)
            {
                ViewBag.IDSifre = "" + " Kullanıcı Adı ve ya şifre yanlış";
                TempData["uyarı"] = "" + " Kullanıcı Adı ve ya şifre yanlış";
                return View("Login");
            }
            else
            {

                return View();
            }


        }


    }
}