using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UnibelDestekSistemi.Models.DBHandler;

namespace UnibelDestekSistemi.Controllers
{
    public class CustomerCancelledRequestController : BaseController
    {
        List<Bilet> biletler = new List<Bilet>();

        public class BiletDataTableModel
        {
            public int BiletId { get; set; }
            public string BiletBasligi { get; set; }
            public DateTime BiletGonderimTarihi { get; set; }
            public DateTime? BiletKapanisTarihi { get; set; }
            public string CalisanKullaniciKullaniciAdi { get; set; }
            public string BiletDepartmanDepartmanAdi { get; set; }
            public string SirketSirketAdi { get; set; }
            public string BiletTurTipAdi { get; set; }
            public string OncelikOncelikAdi { get; set; }
        }

        [HttpGet]
        public IActionResult Index()
        {


            return View();
        }


        [HttpPost]
        public IActionResult Den()
        {
            string username = User.Identity.Name;
            //Durum iptal = 6


            
            List<Bilet> list = _db.Bilet.Where(x => x.FkBiletDurumId.Equals(6) && x.FkBiletGonderen.KullaniciAdi.Equals(username)).ToList();

            List<BiletDataTableModel> liste = new List<BiletDataTableModel>();

            foreach (var item in list)
            {
                BiletDataTableModel BiletDataTable = new BiletDataTableModel();

                BiletDataTable.BiletId = item.BiletId;
                BiletDataTable.CalisanKullaniciKullaniciAdi = item.FkCalisanKullanici == null ? "-- unassigned --" : item.FkCalisanKullanici.TamIsim;
                BiletDataTable.BiletBasligi = item.BiletBasligi;
                BiletDataTable.BiletGonderimTarihi = item.BiletGonderimTarihi;
                BiletDataTable.BiletKapanisTarihi = item.BiletKapanisTarihi;
                BiletDataTable.BiletDepartmanDepartmanAdi = item.FkBiletDepartman.DepartmanAdi;
                BiletDataTable.SirketSirketAdi = item.FkBiletGonderen.FkSirket.SirketAdi;
                BiletDataTable.BiletTurTipAdi = item.FkBiletTur.TipAdi;
                BiletDataTable.OncelikOncelikAdi = item.FkOncelik.OncelikAdi;
                liste.Add(BiletDataTable);

            }

            return Json(liste, new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                TypeNameHandling = TypeNameHandling.None,
            });
            //foreach (var item in list)
            //{
            //    Bilet tempBilet = new Bilet();

            //    tempBilet.BiletId = item.BiletId;
            //    tempBilet.BiletBasligi = item.BiletBasligi;
            //    tempBilet.BiletGonderimTarihi = item.BiletGonderimTarihi;
            //    tempBilet.BiletKapanisTarihi = item.BiletKapanisTarihi;

            //    tempBilet.FkCalisanKullanici = item.FkCalisanKullanici;
            //    tempBilet.FkCalisanKullanici.KullaniciAdi = item.FkCalisanKullanici == null ? "unassigned" : item.FkCalisanKullanici.KullaniciAdi;

            //    tempBilet.FkBiletDepartman = item.FkBiletDepartman;
            //    tempBilet.FkBiletDepartman.DepartmanAdi = item.FkBiletDepartman.DepartmanAdi;

            //    tempBilet.FkSirket = item.FkSirket;
            //    tempBilet.FkSirket.SirketAdi = item.FkSirket.SirketAdi;

            //    tempBilet.FkBiletTur = item.FkBiletTur;
            //    tempBilet.FkBiletTur.TipAdi = item.FkBiletTur.TipAdi;

            //    tempBilet.FkOncelik = item.FkOncelik;
            //    tempBilet.FkOncelik.OncelikAdi = item.FkOncelik.OncelikAdi;

            //    biletler.Add(tempBilet);
            //}
            //return Json(biletler, new JsonSerializerSettings
            //{
            //    Formatting = Formatting.None,
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            //    PreserveReferencesHandling = PreserveReferencesHandling.None,
            //    TypeNameHandling = TypeNameHandling.None,
            //});




        }






        [Route("/List")]
        public IActionResult ListShow()
        {
            string username = User.Identity.Name;
            //Durum iptal = 6

            List<Bilet> list = _db.Bilet.Where(x => !x.FkBiletDurumId.Equals(6) && x.FkBiletGonderen.KullaniciAdi.Equals(username)).ToList();

            //foreach (var item in list)
            //{
            //    Bilet tempBilet = new Bilet();

            //    tempBilet.BiletId = item.BiletId;
            //    tempBilet.BiletBasligi = item.BiletBasligi;
            //    tempBilet.BiletGonderimTarihi = item.BiletGonderimTarihi;
            //    tempBilet.BiletKapanisTarihi = item.BiletKapanisTarihi;

            //    tempBilet.FkCalisanKullanici = item.FkCalisanKullanici;
            //    tempBilet.FkCalisanKullanici.KullaniciAdi = item.FkCalisanKullanici == null ? "unassigned" : item.FkCalisanKullanici.KullaniciAdi;

            //    tempBilet.FkBiletDepartman = item.FkBiletDepartman;
            //    tempBilet.FkBiletDepartman.DepartmanAdi = item.FkBiletDepartman.DepartmanAdi;

            //    tempBilet.FkSirket = item.FkSirket;
            //    tempBilet.FkSirket.SirketAdi = item.FkSirket.SirketAdi;

            //    tempBilet.FkBiletTur = item.FkBiletTur;
            //    tempBilet.FkBiletTur.TipAdi = item.FkBiletTur.TipAdi;

            //    tempBilet.FkOncelik = item.FkOncelik;
            //    tempBilet.FkOncelik.OncelikAdi = item.FkOncelik.OncelikAdi;

            //    biletler.Add(tempBilet);
            //}
            return Json(list);

        }

    }
}