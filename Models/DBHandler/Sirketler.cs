using System;
using System.Collections.Generic;

namespace UnibelDestekSistemi.Models.DBHandler
{
    public partial class Sirketler
    {
        public Sirketler()
        {
            Bilet = new HashSet<Bilet>();
            Kullanici = new HashSet<Kullanici>();
        }

        public int SirketId { get; set; }
        public string SirketAdi { get; set; }
        public string SirketTel { get; set; }

        public ICollection<Bilet> Bilet { get; set; }
        public ICollection<Kullanici> Kullanici { get; set; }
    }
}
