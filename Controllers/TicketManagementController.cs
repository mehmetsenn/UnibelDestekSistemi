using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnibelDestekSistemi.Models.DBHandler;

namespace UnibelDestekSistemi.Controllers
{
    public class TicketManagementController : BaseController
    {

        unibeldestekContext _db = new unibeldestekContext();
        Bilet bilet = new Bilet();
        Models.ShowTicketModel showTicketModel;

        [HttpPost]
        [Route("/addTicket")]
        public IActionResult addTicket(Bilet bilet)
        {
            var username = User.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
            var BiletGonderenId = _db.Kullanici.FirstOrDefault(x => x.KullaniciAdi.Equals(username)).KullaniciId;
            bilet.FkBiletGonderenId = BiletGonderenId;
            bilet.BiletGonderimTarihi = DateTime.Now;
            try
            {
                _db.Bilet.Add(bilet);
                _db.SaveChanges();
            }
            catch(Exception e)
            {
                var hata = e.Message;
            }
            return Redirect("/Dashboard");
        }





        [HttpGet]
        public IActionResult showTicket(int ticketId)
        {
            
            bilet = _db.Bilet.FirstOrDefault(x => x.BiletId.Equals(ticketId));
            ViewBag.pageHeader = "TICKET ID : " + bilet.BiletId;
            showTicketModel = new Models.ShowTicketModel(bilet);

            
            ViewBag.Ticket = showTicketModel;
            ViewBag.Yanit = _db.Yanit.Where(x => x.FkBiletId.Equals(bilet.BiletId)).ToList() ;
            return View();
        }



        [HttpPost]
        public IActionResult showTicket(Yanit yanit,int ticketId)
        {
            var username = User.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
            var YanitGonderenId = _db.Kullanici.FirstOrDefault(x => x.KullaniciAdi.Equals(username)).KullaniciId;
            yanit.FkKullaniciId = YanitGonderenId;
            yanit.FkBiletId = ticketId;
            yanit.YanitGonderimTarihi = DateTime.Now;
            try
            {
                _db.Yanit.Add(yanit);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                var hata = e.Message;
            }
            return showTicket(ticketId);
        }
        
        public IActionResult ownTicket(int ticketId)
        {
            var username = User.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
            var biletAtananId = _db.Kullanici.FirstOrDefault(x => x.KullaniciAdi.Equals(username)).KullaniciId;
            var Bilet = _db.Bilet.FirstOrDefault(x => x.BiletId.Equals(ticketId));
            Bilet.FkCalisanKullaniciId = biletAtananId;
            try
            {
                _db.Bilet.Update(Bilet);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                var hata = e.Message;
            }
            var dep = _db.Departman.Where(x => x.DepartmanId.Equals(Bilet.FkBiletDepartmanId)).SingleOrDefault();
            return Redirect("~/showTicket/" + ticketId);
        }


        [Route("/sa")]
        [HttpGet]
        public IActionResult Jsres(int depid)
        {
            var dep = _db.Departman.Where(x => x.DepartmanId.Equals(2)).SingleOrDefault();
            //string json1 = JsonConvert.SerializeObject(dep);
            var asas = Json(dep);
            return Json(dep);
        }


    }
}