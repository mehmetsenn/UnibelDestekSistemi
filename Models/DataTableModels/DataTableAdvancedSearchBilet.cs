using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnibelDestekSistemi.Models.DataTableModels
{
    public class DataTableAdvancedSearchBilet
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string Priority { get; set; }
        public string Owner { get; set; }
        public string Due { get; set; }
    }
}
