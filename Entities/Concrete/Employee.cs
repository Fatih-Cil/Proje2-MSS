using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Employee : IEntity
    {
        [Key]
        public int EmployeeId { get; set; }
        public int AuthorityId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string RegisterNumber { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Status { get; set; }


        public virtual Authority Authorities { get; set; }
        public ICollection<EmployeeShop> EmployeeShops { get; set; }
    }
}
