using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnibelDestekSistemi.Models
{



    public class DenemeAjax
    {
        public int Id { get; set; }
        public string Company { get; set; } 
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string Priority { get; set; }
        public string Owner { get; set; }
        public DateTime Due { get; set; }


    }
}
