using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class ShowCaseDetailDTO
    {
        public int ShowCaseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Url { get; set; }


        public string ShopName { get; set; }
        public string Locasion { get; set; }
    }
}
