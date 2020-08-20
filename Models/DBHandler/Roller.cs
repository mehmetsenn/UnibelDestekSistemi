using System;
using System.Collections.Generic;

namespace UnibelDestekSistemi.Models.DBHandler
{
    public partial class Roller
    {
        public Roller()
        {
            Haklar = new HashSet<Haklar>();
            Kullanici = new HashSet<Kullanici>();
        }

        public int RolId { get; set; }
        public string RolAdi { get; set; }

        public ICollection<Haklar> Haklar { get; set; }
        public ICollection<Kullanici> Kullanici { get; set; }
    }
}
