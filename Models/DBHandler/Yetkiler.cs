using System;
using System.Collections.Generic;

namespace UnibelDestekSistemi.Models.DBHandler
{
    public partial class Yetkiler
    {
        public Yetkiler()
        {
            Haklar = new HashSet<Haklar>();
        }

        public int YetkiId { get; set; }
        public string YetkiAdi { get; set; }

        public ICollection<Haklar> Haklar { get; set; }
    }
}
