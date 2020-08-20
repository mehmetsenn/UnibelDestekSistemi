using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnibelDestekSistemi.Controllers.Staff;
using UnibelDestekSistemi.Models.DBHandler;

namespace UnibelDestekSistemi.Models.ViewModels
{
    public class DashboardViewModel : Controller
    {
        unibeldestekContext _db = new unibeldestekContext();
        public LoginedUser LoginedUser { get; set; }
        public int UnassignedTicketsCount { get; set; }
        public int OverdueTicketsCount { get; set; }
        public int HighPriorityTicketsCount { get; set; }
        public int TodaysTicketsCount { get; set; }

        public DashboardViewModel(string username)
        {
            
            LoginedUser = new LoginedUser();
            LoginedUser.UserId = _db.Kullanici.SingleOrDefault(x => x.KullaniciAdi.Equals(username)).KullaniciId;

            LoginedUser.UserId = _db.Kullanici.SingleOrDefault(x => x.KullaniciAdi.Equals(username)).KullaniciId;

            LoginedUser.UserName = _db.Kullanici.SingleOrDefault(x => x.KullaniciId.Equals(LoginedUser.UserId)).TamIsim;
            LoginedUser.DepartmentName = _db.Departman.SingleOrDefault(x => x.DepartmanId.Equals(_db.Kullanici.SingleOrDefault(y => y.KullaniciAdi.Equals(username)).FkDepartmanId)).DepartmanAdi;
            LoginedUser.OwnedTicketCount = _db.Bilet.Where(x => x.FkCalisanKullaniciId.Equals(LoginedUser.UserId)).Count();
            LoginedUser.UsersDepartmentTicketCount = _db.Bilet.Where(x => x.FkBiletDepartmanId.Equals(_db.Kullanici.SingleOrDefault(y => y.KullaniciId.Equals(LoginedUser.UserId)).FkDepartmanId)).Count();
            LoginedUser.UserEmail = _db.Kullanici.SingleOrDefault(x => x.KullaniciId.Equals(LoginedUser.UserId)).Eposta;
            this.HighPriorityTicketsCount = _db.Bilet.Where(x => x.FkOncelikId.Equals(4) || x.FkOncelikId.Equals(5) || x.FkOncelikId.Equals(6)).Count();
            this.TodaysTicketsCount = _db.Bilet.Where(x => x.BiletGonderimTarihi.Day.Equals(DateTime.Now.Day)).Count();

            //Unassigned Tickets Count Sayısı Buarada belirlenecek
            //Overdue Tickets Count Sayısı Buarada belirlenecek

        }




    }
    public class LoginedUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string DepartmentName { get; set; }
        public int OwnedTicketCount { get; set; }
        public int UsersDepartmentTicketCount { get; set; }
    }
}
