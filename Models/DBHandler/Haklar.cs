using System;
using System.Collections.Generic;

namespace UnibelDestekSistemi.Models.DBHandler
{
    public partial class Haklar
    {
        public int HakId { get; set; }
        public int RolId { get; set; }
        public int YetkiId { get; set; }

        public Roller Rol { get; set; }
        public Yetkiler Yetki { get; set; }
    }
}
