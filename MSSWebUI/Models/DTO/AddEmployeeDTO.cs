using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSSWebUI.Models.DTO
{
     public class AddEmployeeDTO
    {
        public List<EmployeeDetailDTO> EmployeeDetail { get; set; }
        public List<Authority> AuthorityList { get; set; }
        public Employee Employee { get; set; }
        public Authority Authority { get; set; }
        public int AuthorityId { get; set; }
    }
}
