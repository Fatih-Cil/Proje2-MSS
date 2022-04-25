using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Finance:IEntity
    {
        public int FinanceId { get; set; }
        public decimal DailySalesEarning { get; set; }
        public int DailySalesAmount { get; set; }
        public DateTime SalesDate { get; set; }

        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
