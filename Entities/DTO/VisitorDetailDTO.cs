using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class VisitorDetailDTO
    {
        public int VisitorId { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public string Pozition { get; set; }
        public string ShopName { get; set; }
        public string Locasion { get; set; }
    }
}
