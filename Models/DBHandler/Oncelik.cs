using System;
using System.Collections.Generic;

namespace UnibelDestekSistemi.Models.DBHandler
{
    public partial class Oncelik
    {
        public Oncelik()
        {
            Bilet = new HashSet<Bilet>();
        }

        public int OncelikId { get; set; }
        public string OncelikAdi { get; set; }

        public ICollection<Bilet> Bilet { get; set; }
    }
}
