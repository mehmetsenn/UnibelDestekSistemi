using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnibelDestekSistemi.Controllers;
using UnibelDestekSistemi.Models.DBHandler;

namespace UnibelDestekSistemi.Models
{
    public class ShowTicketModel : BaseController
    {

        public int BiletId { get; set; }
        public string BiletGonderenSirketAdi { get; set; }
        public string BiletGonderenAdi { get; set; }
        public string BiletCalisanAdi { get; set; }
        public string BiletDepartmanAdi { get; set; }
        public string BiletTurAdi { get; set; }
        public string BiletDurumAdi { get; set; }
        public string BiletOncelikAdi { get; set; }
        public string BiletBasligi { get; set; }
        public string BiletDosyasiAdi { get; set; }
        public string BiletIcerik { get; set; }
        public bool? AktifMi { get; set; }
        public DateTime BiletGonderimTarihi { get; set; }
        public string BiletUrunAdi { get; set; }
        public DateTime? BiletKapanisTarihi { get; set; }

        unibeldestekContext _db = new unibeldestekContext();


        public ShowTicketModel(Bilet bilet)
        {

            this.BiletId = bilet.BiletId;
            this.BiletGonderenAdi = _db.Kullanici.SingleOrDefault(x => x.KullaniciId.Equals(bilet.FkBiletGonderenId)).KullaniciAdi;
            this.BiletGonderenSirketAdi = _db.Sirketler.SingleOrDefault(x => x.SirketId.Equals(_db.Kullanici.SingleOrDefault(y => y.KullaniciId.Equals(bilet.FkBiletGonderenId)).FkSirketId)).SirketAdi;
            this.BiletCalisanAdi = _db.Kullanici.SingleOrDefault(x => x.KullaniciId.Equals(bilet.FkCalisanKullaniciId)).KullaniciAdi;
            this.BiletDepartmanAdi = _db.Departman.SingleOrDefault(x => x.DepartmanId.Equals(bilet.FkBiletDepartmanId)).DepartmanAdi;
            this.BiletTurAdi = _db.Tip.SingleOrDefault(x => x.TipId.Equals(bilet.FkBiletTurId)).TipAdi;
            this.BiletDurumAdi = _db.Durum.SingleOrDefault(x => x.DurumId.Equals(bilet.FkBiletDurumId)).DurumAdi;
            this.BiletOncelikAdi = _db.Oncelik.SingleOrDefault(x => x.OncelikId.Equals(bilet.FkOncelikId)).OncelikAdi;
            this.BiletDosyasiAdi = "Bilet Dosya Eki Adı...";
            this.BiletIcerik = bilet.BiletIcerik;
            this.AktifMi = bilet.AktifMi;
            this.BiletGonderimTarihi = bilet.BiletGonderimTarihi;
            this.BiletKapanisTarihi = bilet.BiletKapanisTarihi;

        }
    }
}
