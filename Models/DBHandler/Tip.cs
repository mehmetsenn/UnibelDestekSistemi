using System;
using System.Collections.Generic;

namespace UnibelDestekSistemi.Models.DBHandler
{
    public partial class Tip
    {
        public Tip()
        {
            Bilet = new HashSet<Bilet>();
        }

        public int TipId { get; set; }
        public string TipAdi { get; set; }

        public ICollection<Bilet> Bilet { get; set; }
    }
}
