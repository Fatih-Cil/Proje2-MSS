using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EmployeeShop:IEntity
    {
        [Key]
        public int EmployeShopId { get; set; }
        public int EmployeeId { get; set; }
        public int ShopId { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan CheckIn { get; set; }
        public TimeSpan CheckOut { get; set; }


        public virtual Employee Employee { get; set; }
        public virtual Shop Shop { get; set; }

    }
}
