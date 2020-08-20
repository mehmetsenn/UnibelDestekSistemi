using System;
using System.Collections.Generic;

namespace UnibelDestekSistemi.Models.DBHandler
{
    public partial class Duyuru
    {
        public int DuyuruId { get; set; }
        public int KullaniciId { get; set; }
        public string DuyuruBasligi { get; set; }
        public string DuyuruIcerigi { get; set; }

        public Kullanici Kullanici { get; set; }
    }
}
