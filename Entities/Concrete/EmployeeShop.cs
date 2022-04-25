using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EmployeeShop:IEntity
    {
        public int EmployeeId { get; set; }
        public int ShopId { get; set; }
        public int ShiftId { get; set; }
        public DateTime Date { get; set; }

        
        public virtual Employee Employee { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
