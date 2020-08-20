using System.Collections.Generic;

namespace UnibelDestekSistemi.Controllers.Staff
{
    public class CustomSearchConditionRules
    {
        public string condition { get; set; }
        public List<CustomConditionValues> conditionValues { get; set; }
        public CustomConditionDates date { get; set; }
        public CustomConditionRange range;
    }

    public class CustomConditionValues
    {
        public string conditionName { get; set; }
        public string searchIdValue { get; set; }
        public string searchText { get; set; }
       // public string searchIdValue { get; set; }
    }

    public class CustomConditionDates
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
    }

    public class CustomConditionRange
    {
        public string min { get; set; }
        public string max { get; set; }
    }

    //Ajax isteğinden gelen örnek bir veri.Buradaki json nesnesi buradaki alanlara bind oluyor.
    
//{"condition":"custom",

//"conditionValues":[{"conditionName":"subject","searchValue":""}
//,{"conditionName":"demirbas","searchValue":""}
//,{"conditionName":"serino","searchValue":""}
//,{"conditionName":"urun","searchValue":""}
//,{"searchValue":"1","conditionName":"status"}
//,{"searchValue":"2","conditionName":"status"}
//,{"searchValue":"2","conditionName":"priority"}
//,{"searchValue":"3","conditionName":"priority"}
//,{"searchValue":"10","conditionName":"company"}
//,{"searchValue":"1","conditionName":"company"}
//,{"searchValue":"1","conditionName":"type"}
//,{"searchValue":"2","conditionName":"type"}
//,{"searchValue":"2","conditionName":"department"}
//,{"searchValue":"1","conditionName":"department"}]

//,"date":{"startDate":"","endDate":""}}




}