using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class FinanceDetailDTO
    {

        public int FinanceId { get; set; }
        public decimal DailySalesEarning { get; set; }
        public int DailySalesAmount { get; set; }
        public DateTime SalesDate { get; set; }

        public string ShopName { get; set; }
        public string Locasion { get; set; }
    }
}
