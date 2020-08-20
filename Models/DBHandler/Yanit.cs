using System;
using System.Collections.Generic;

namespace UnibelDestekSistemi.Models.DBHandler
{
    public partial class Yanit
    {
        public int YanıtId { get; set; }
        public int FkBiletId { get; set; }
        public DateTime? YanitGonderimTarihi { get; set; }
        public int? FkKullaniciId { get; set; }
        public string YanıtIcerigi { get; set; }

        public Bilet FkBilet { get; set; }
        public Kullanici FkKullanici { get; set; }
    }
}
