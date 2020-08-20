using System;
using System.Collections.Generic;

namespace UnibelDestekSistemi.Models.DBHandler
{
    public partial class Urun
    {
        public Urun()
        {
            Bilet = new HashSet<Bilet>();
        }

        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string SeriNo { get; set; }
        public string Demirbas { get; set; }
        public string ArizaTanimi { get; set; }

        public ICollection<Bilet> Bilet { get; set; }
    }
}
