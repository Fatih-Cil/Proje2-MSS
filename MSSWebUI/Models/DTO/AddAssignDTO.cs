using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSSWebUI.Models.DTO
{
    public class AddAssignDTO
    {
        public List<AssignDetailDTO> AssignList { get; set; }
        public EmployeeShop EmployeeShop { get; set; }

        public List<Employee> EmployeeList { get; set; }
        public Employee Employee { get; set; }
        public List<Shop> ShopList { get; set; }
        public Shop Shop { get; set; }
        public List<Shift> ShiftList { get; set; }
        public Shift Shift{ get; set; }
        

        public DateTime WorkDate { get; set; }
        
    }
}
