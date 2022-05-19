using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSSWebUI.Models.ViewModel
{
    public class EmployeeAuthDTO
    {
        public Employee Employee { get; set; }

        public List<EmployeeDetailDTO> EmployeeDetailList { get; set; }
        public List<Employee> EmployeeList { get; set; }
        public List<Authority> AuthorityList { get; set; }
        public Authority Authority { get; set; }
        public string AuthorityName { get; set; }
        public List<Finance> FinanceList { get; set; }
        public Finance Finance { get; set; }
        public List<Shop> ShopList { get; set; }
        public Shop Shop { get; set; }
        public VisitorEvent VisitorEvent { get; set; }
        public List<VisitorEvent> VisitorEventList { get; set; }
        public List<Campaign> CampaignActiveList { get; set; }
    }
}
