using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UnibelDestekSistemi.Models.DBHandler;

namespace UnibelDestekSistemi.Controllers
{
    public class CustomerSendingRequestController : BaseController
    {
        List<Bilet> biletler = new List<Bilet>();


        // isimlendirilirken veri tabanından hangi rotayı izlediğini gösterecek şekil de yapıldı. örn: CalisankullaniciCalisanKullanici 
        public class BiletDataTableModel
        {
            public int BiletId { get; set; }
            public string CalisanKullaniciKullaniciAdi { get; set; }
            public string BiletBasligi { get; set; }
            public DateTime BiletGonderimTarihi { get; set; }
            public DateTime? SonGüncellemeTarihi { get; set; }
            public DateTime? TahminiKapanis { get; set; }
            public string SonCevaplayan { get; set; }
            public string BiletDepartmanDepartmanAdi { get; set; }
            public string BiletTurTipAdi { get; set; }
            public string DurumAdi { get; set; }
            public string OncelikOncelikAdi { get; set; }
        }

        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult SendingRequest()
        {
            string username = User.Identity.Name;

            List<Bilet> list = _db.Bilet.Where(x => !x.FkBiletDurumId.Equals(6) && x.FkBiletGonderen.KullaniciAdi.Equals(username)).ToList();

            List<BiletDataTableModel> liste = new List<BiletDataTableModel>();

            foreach (var item in list)
            {
                // LastOrDefualt last ID 
                var SonCevaplayan = _db.Yanit.LastOrDefault(x => x.FkBiletId.Equals(item.BiletId));

                BiletDataTableModel BiletDataTable = new BiletDataTableModel();

                BiletDataTable.BiletId = item.BiletId;
                BiletDataTable.CalisanKullaniciKullaniciAdi = item.FkCalisanKullanici == null ? "-- unassigned --" : item.FkCalisanKullanici.TamIsim;
                BiletDataTable.BiletBasligi = item.BiletBasligi;
                BiletDataTable.BiletGonderimTarihi = item.BiletGonderimTarihi;
                BiletDataTable.SonGüncellemeTarihi = SonCevaplayan == null ? item.BiletGonderimTarihi: SonCevaplayan.YanitGonderimTarihi;
              //  BiletDataTable.TahminiKapanis = item.BiletTahminiKapanısTarihi; //null dene
                BiletDataTable.SonCevaplayan = SonCevaplayan == null ? item.FkBiletGonderen.TamIsim : SonCevaplayan.FkKullanici.TamIsim; 
                BiletDataTable.BiletDepartmanDepartmanAdi = item.FkBiletDepartman.DepartmanAdi;
                BiletDataTable.BiletTurTipAdi = item.FkBiletTur.TipAdi;
                BiletDataTable.DurumAdi = item.FkBiletDurum.DurumAdi;
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
        }

    }
}