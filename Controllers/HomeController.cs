using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

using UnibelDestekSistemi.Models.ViewModels;

//namespace UnibelDestekSistemi.Controllers
//{
//    public class HomeController : BaseController
//    {


//        public IActionResult SignUp()
//        {
//            return View();
//        }

//       /* public IActionResult Index2()
//        {
//            return View();
//        }*/

//        [HttpPost]
//        public IActionResult SignUp(SignUpViewModel KullanıcıViewModel)
//        {
//           try 
//            {
//                if (ModelState.IsValid)
//                {
//                    Kullanici user = new Kullanici();
//                    user.KullaniciAdi = KullanıcıViewModel.KullaniciAdi;
//                    user.Sifre = KullanıcıViewModel.Password;
//                    user.FkRolId = 1;
//                    user.FkDepartmanId = 1;
                    
//                    //destekContext db = new destekContext();
//                    _db.Kullanici.Add(user);
//                    _db.SaveChanges();

//                    return RedirectToAction("Login", "LoginPage");

//                }
//                else
//                {
//                    if (KullanıcıViewModel.KullaniciAdi == null)
//                    {
//                        ViewBag.KullaniciAdi = "" + "Kullanıcı adı Boş olamaz";
//                    }
//                    if (KullanıcıViewModel.Password == null)
//                    {
//                        ViewBag.Password = "" + "Password Boş olamaz";
//                    }
//                    return View("SignUp");

//                }
                

//            }
//            catch (Exception IdentityErrorEx)
//            {
//                var er = IdentityErrorEx.Message;
//                ViewBag.KullaniciAdi = "" + "Böyle bir Kullanıcı adı bulunmaktadır.";
//                return View("SignUp");
//            }

//        }

//      /*  public IActionResult LoginP(string KullaniciAdi, string Sifre)
//        {
//            destekContext db = new destekContext();
//            var result = db.Kullanici.FirstOrDefault(x => x.KullaniciAdi.Equals(KullaniciAdi) && x.Sifre.Equals(Sifre));
//            if (result != null)
//            {
//                // HttpContext.Session.SetString("userName", result.KullaniciAdi);
//                return Redirect("/Dashboard/Index");

//            }
//            return Redirect("/");
//        }*/





//    }


//}