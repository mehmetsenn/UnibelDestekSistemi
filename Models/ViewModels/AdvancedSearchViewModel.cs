using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnibelDestekSistemi.Models.DBHandler;

namespace UnibelDestekSistemi.Models.ViewModels
{
    public class AdvancedSearchViewModel
    {

        public List<Bilet> allTickets = new List<Bilet>();
        public List<string> searchConditions = new List<string>();

        public List<Bilet> getAllTickets() {
            return allTickets;
        }

        public void addTicketToList(Bilet bilet) {
            allTickets.Add(bilet);
        }

        public void clearTicketList() {
            allTickets.Clear();
        }

        public void addSearchCondition(string condition)
        {
            searchConditions.Add(condition);
        }

        public List<string> getAllSearchConditions() {
            return searchConditions;
        }

       


    }
}
