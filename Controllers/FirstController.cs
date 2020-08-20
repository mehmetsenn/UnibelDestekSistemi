using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using UnibelDestekSistemi.Models;
using UnibelDestekSistemi.Models.DBHandler;
using UnibelDestekSistemi.Models.ViewModels;

namespace UnibelDestekSistemi.Controllers
{
    public class FirstController : BaseController
    {
        [HttpGet]
        public IActionResult AddStaff()
        {
            ViewBag.SelectRole = TempData["RoleUyarı"];
            ViewBag.EsDegil = TempData["AynıDegil"];
            ViewBag.SelectDepartment = TempData["DepartmanUyarı"];

            return View();
        }

        [HttpPost]
        public IActionResult AddStaff(AddStaffViewModel KullanıcıViewModel)
        {

            try
            {
                
                int selectRole = 0;
                int selectDepartment = 0;
                if (KullanıcıViewModel.selectRole == 0) 
                {
                   selectRole = 1;
                }
                if (KullanıcıViewModel.selectDepartment == 0)
                {
                    selectDepartment = 1;
                }

                //newPassword = password ++++ ConfirmNewPassword = şifre Tekrarı 
                if (ModelState.IsValid && selectRole == 0 && selectDepartment != 1 && KullanıcıViewModel.newPassword == KullanıcıViewModel.confirmNewPassword)
                {
                    Kullanici user = new Kullanici();

                    var SCollection = new ServiceCollection();
                    SCollection.AddDataProtection();
                    var LockerKey = SCollection.BuildServiceProvider();
                    var locker = ActivatorUtilities.CreateInstance<SecurityController>(LockerKey);
                    string salt = locker.HashCreate();
                    string EncryptKey = locker.HashCreate(KullanıcıViewModel.newPassword, salt);

                    user.TamIsim = KullanıcıViewModel.staffFullName;
                    user.KullaniciAdi = KullanıcıViewModel.staffUsername;
                    
                    user.Sifre = EncryptKey;

                    //user.Sifre = KullanıcıViewModel.Password;
                    user.FkSirketId = 1;
                    user.FkRolId = KullanıcıViewModel.selectRole;
                    user.FkDepartmanId = KullanıcıViewModel.selectDepartment;
                    user.Eposta = KullanıcıViewModel.staffEmail;

                    
                    //destekContext db = new destekContext();
                    _db.Kullanici.Add(user);
                    _db.SaveChanges();

                    ViewBag.KullaniciDurumu = KullanıcıViewModel.staffUsername + " Adlı Kullanıcı Başarıyla Eklendi.";
                    return View("AddStaff");

                }
                else
                {
                    if (selectRole == 1)
                    {
                        TempData["RoleUyarı"] = "Lütfen Role Seçiniz";
                      //  ViewBag.SelectRole = "Lütfen Role Seçiniz";

                    }
                    if (selectDepartment == 1)
                    {
                        TempData["DepartmanUyarı"] = "Lütfen Role Seçiniz";
                       // ViewBag.SelectDepartment = "Lütfen Role Seçiniz";

                    }
                    if (KullanıcıViewModel.newPassword != KullanıcıViewModel.confirmNewPassword)
                    {
                        TempData["AynıDegil"] = "Şifreler aynı değil";
                    }

                    //ViewBag.SelectRole = TempData["RoleUyarı"];
                    //ViewBag.SelectDepartment = TempData["DepartmanUyarı"];

                    return Redirect("/AddStaff");

                }


            }
            catch (Exception IdentityErrorEx)
            {
                var er = IdentityErrorEx.Message;
                ViewBag.KullaniciDurumu = KullanıcıViewModel.staffUsername  + " Adlı Kullanıcı Adı Bulunmaktadır.";
                return Redirect("/AddStaff");
            }


        }


        [HttpGet]
        public IActionResult AddCustomer()
        {

            return View();
        }


        [HttpPost]
        public IActionResult AddCustomer(AddCustomerViewModel KullanıcıViewModel) { 
            try
            {

                //Sirket seçilmediğinde dönen id değeri 0 olduğundan if state yapılmıştır. 
                int selectSirket = 0;

                if (KullanıcıViewModel.selectSirket == 0)
                {
                    selectSirket = 1;
                }

                if (ModelState.IsValid &&  selectSirket != 1)
                {
                    Kullanici user = new Kullanici();

                    var SCollection = new ServiceCollection();
                    SCollection.AddDataProtection();
                    var LockerKey = SCollection.BuildServiceProvider();
                    var locker = ActivatorUtilities.CreateInstance<SecurityController>(LockerKey);
                    string salt = locker.HashCreate();
                    string EncryptKey = locker.HashCreate(KullanıcıViewModel.staffPassword, salt);

                    user.TamIsim = KullanıcıViewModel.staffFullName;
                    user.KullaniciAdi = KullanıcıViewModel.staffUsername;
                    

                    user.Sifre = EncryptKey;
                    //user.Sifre = KullanıcıViewModel.Password;

                    user.FkSirketId = KullanıcıViewModel.selectSirket;
                    user.Eposta = KullanıcıViewModel.staffEmail;

                    
                    //destekContext db = new destekContext();
                    _db.Kullanici.Add(user);
                    _db.SaveChanges();

                    ViewBag.KullaniciDurumu = KullanıcıViewModel.staffUsername + " Adlı Kullanıcı Başarıyla Eklendi.";
                    return View("AddCustomer");

                }
                else
                {
                    if (selectSirket == 1)
                    {
                        ViewBag.SelectDepartment = "Lütfen Role Seçiniz";

                    }

                    return View("AddCustomer");

                }


            }
            catch (Exception IdentityErrorEx)
            {
                var er = IdentityErrorEx.Message;
                ViewBag.KullaniciDurumu = KullanıcıViewModel.staffUsername  + " Adlı Kullanıcı Adı Bulunmaktadır.";
                return View("AddStaff");
            }


        }

        [HttpGet]
        public IActionResult addTicket()
        {

            return View();
        }

        [HttpGet]
        public IActionResult ReturnTickets()
        {

            DenemeAjax ajaxDeneme =new DenemeAjax {
                Id = 1,
                Date = DateTime.Now,
                Subject = "Oylesine",
                Company = "Bim",
                Priority = "High",
                Owner = "Sneijder",
        

            };

            DenemeAjax ajaxDeneme2 = new DenemeAjax
            {
                Id = 2,
                Date = DateTime.Now,
                Subject = "Oylesine",
                Company = "Bim",
                Priority = "High",
                Owner = "Sneijder",

            };

            List<DenemeAjax> liste = new List<DenemeAjax>();
            liste.Add(ajaxDeneme);
            liste.Add(ajaxDeneme2);
            

            return Json(liste);
        }

    }
}