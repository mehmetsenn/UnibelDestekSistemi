using System;
using System.Collections.Generic;

namespace UnibelDestekSistemi.Models.DBHandler
{
    public partial class Durum
    {
        public Durum()
        {
            Bilet = new HashSet<Bilet>();
        }

        public int DurumId { get; set; }
        public string DurumAdi { get; set; }

        public ICollection<Bilet> Bilet { get; set; }
    }
}
