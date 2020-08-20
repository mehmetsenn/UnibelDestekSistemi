using System;
using System.Collections.Generic;

namespace UnibelDestekSistemi.Models.DBHandler
{
    public partial class Departman
    {
        public Departman()
        {
            Bilet = new HashSet<Bilet>();
            Kullanici = new HashSet<Kullanici>();
        }

        public int DepartmanId { get; set; }
        public string DepartmanAdi { get; set; }
        public string DepartmanTel { get; set; }

        public ICollection<Bilet> Bilet { get; set; }
        public ICollection<Kullanici> Kullanici { get; set; }
    }
}
