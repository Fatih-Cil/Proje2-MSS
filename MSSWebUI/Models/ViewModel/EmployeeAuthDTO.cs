using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSSWebUI.Models.ViewModel
{
    public class EmployeeAuthDTO
    {
        public Employee Employee { get; set; }

        public List<Employee> EmployeeList { get; set; }
        public List<Authority> AuthorityList { get; set; }
        public Authority Authority { get; set; }
        public string AuthorityName { get; set; }
    }
}
