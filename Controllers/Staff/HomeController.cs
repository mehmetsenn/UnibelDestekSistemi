using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using UnibelDestekSistemi.Models.DBHandler;
using UnibelDestekSistemi.Models.ViewModels;
using UnibelDestekSistemi.Controllers;
using Microsoft.Extensions.DependencyInjection;

/*namespace UnibelDestekSistemi.Controllers.Staff
{
    public class HomeController : BaseController
    {

        [HttpGet]
        public IActionResult SignUpStaff()
        {
            return View();
        }

        /* public IActionResult Index2()
         {
             return View();
         }


        [HttpPost]
        public IActionResult SignUp(SignUpViewModel KullanıcıViewModel)
        {

           try 
            {
                if (ModelState.IsValid)
                {
                    Kullanici user = new Kullanici();

                    var SCollection = new ServiceCollection();
                    SCollection.AddDataProtection();
                    var LockerKey = SCollection.BuildServiceProvider();
                    var locker = ActivatorUtilities.CreateInstance<SecurityController>(LockerKey);
                    string salt = locker.HashCreate();
                    string EncryptKey = locker.HashCreate(KullanıcıViewModel.staffPassword, salt);
  
                    user.KullaniciAdi = KullanıcıViewModel.staffUsername;
                    user.TamIsim = KullanıcıViewModel.staffFullName;
                    user.Sifre = EncryptKey;
                    //user.Sifre = KullanıcıViewModel.Password;
                    user.RolId = KullanıcıViewModel.selectRole;
                    user.FkDepartmanId = KullanıcıViewModel.SelectDepartment;
                    user.Email = KullanıcıViewModel.staffEmail; 
                    
                    //destekContext db = new destekContext();
                    _db.Kullanici.Add(user);
                    _db.SaveChanges();

                    return Redirect("/Dashboard");

                }
                else
                {
                    
                    TempData["uyarı"] = "" + " Kullanıcı Adı var";
                    return Redirect("/Dashboard");

                }
                

            }
            catch (Exception IdentityErrorEx)
            {
                var er = IdentityErrorEx.Message;
                Console.WriteLine(er);
                ViewBag.KullaniciAdi = "" + "Böyle bir Kullanıcı adı bulunmaktadır.";
                return View("SignUp");
            }

        }

        /*  public IActionResult LoginP(string KullaniciAdi, string Sifre)
          {
              destekContext db = new destekContext();
              var result = db.Kullanici.FirstOrDefault(x => x.KullaniciAdi.Equals(KullaniciAdi) && x.Sifre.Equals(Sifre));
              if (result != null)
              {
                  // HttpContext.Session.SetString("userName", result.KullaniciAdi);
                  return Redirect("/Dashboard/Index");

              }
              return Redirect("/");
          }*/







