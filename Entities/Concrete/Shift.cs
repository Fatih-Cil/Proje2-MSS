using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Shift:IEntity
    {
        [Key]
        public int ShiftId { get; set; }
        public string ShiftName { get; set; }
        public TimeSpan CheckIn { get; set; }
        public TimeSpan CheckOut { get; set; }

        public ICollection<EmployeeShop> EmployeeShops { get; set; }
    }
}
