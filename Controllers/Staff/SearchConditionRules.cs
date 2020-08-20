using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnibelDestekSistemi.Controllers.Staff
{
    public class SearchConditionRules
    {
        public string selectIndex { get; set; }
        public List<ActualValue> actualValue { get; set; }
        public string condition { get; set; }
    }
    public class ActualValue {
        public string searchValue { get; set; }
        public DateTime? endDate { get; set; }
        public DateTime? startDate { get; set; }

    } 
}
