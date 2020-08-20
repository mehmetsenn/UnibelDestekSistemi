using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UnibelDestekSistemi.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;
using UnibelDestekSistemi.Models.DBHandler;


namespace UnibelDestekSistemi.Controllers.Customer
{
    public class CustomerForgotPasswordController : Controller
    {
        [HttpGet]
        public IActionResult CustomerForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CustomerForgotPassword(ForgotPassword user)
        {
            unibeldestekContext _db = new unibeldestekContext();
            string email = user.Email;
 
            var username = _db.Kullanici.Where(c => c.Eposta == email).Select(c => c.KullaniciAdi).SingleOrDefault();
            var user2 = _db.Kullanici.FirstOrDefault(x => x.KullaniciAdi.Equals(username));

            if (ModelState.IsValid)
            {
                try
                {
                    if (username==null)
                    {
                        TempData["mail"] = "Bu e-mail adresine ait hesap bulunamadı.";
                        return Redirect("/CustomerForgotPassword");
                    }

                    else
                    {
                        MailMessage mail = new MailMessage();
                        SmtpClient smtpClient = new SmtpClient();

                        SmtpClient SmtpServer = new SmtpClient();
                        smtpClient.Host = "smtp.yandex.ru";
                        smtpClient.Port = 587;
                        smtpClient.Credentials = new System.Net.NetworkCredential("disi.uaslan@galatasaray.net", "17.05.2000");
                        smtpClient.EnableSsl = true;
                        Guid code = Guid.NewGuid();

                        mail.From = new MailAddress("disi.uaslan@galatasaray.net");
                        mail.To.Add(email);
                        mail.Subject = $"Şifre Sıfırlama";
                        mail.Body = "Şifrenizi yenilemek için lütfen tıklayınız.Link 10 dakikadan sonra erişime kapatılır, sistem sizi anasayfaya yönlendirir.";
                        mail.Body += Environment.NewLine;
                        var Link = code.ToString();
                        string Fulllink = "https://localhost:44334/NewPassword/" + Link;
                        mail.Body += Fulllink;
                        smtpClient.Send(mail);

                        user2.Link = Link;
                        var now = DateTime.UtcNow;
                        var delete_time = now.AddMinutes(10);
                        user2.EpostaSilmeZamani = delete_time;
                        _db.Kullanici.Update(user2);
                        _db.SaveChanges();
                    }    
                }

                catch (Exception)
                {
                    TempData["mail"] = "Bir hata oluştu.";
                    return Redirect("/CustomerForgotPassword");
                }

            }

            return Redirect("/");
        }
    }
}