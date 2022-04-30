using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class EmployeeDetailDTO
    {
        public int EmployeeId { get; set; }
        public string AuthorityName { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string RegisterNumber { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Status { get; set; }
    }
}
