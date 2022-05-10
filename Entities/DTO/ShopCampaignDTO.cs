using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class ShopCampaignDTO
    {
        public int ShopCampaignId { get; set; }
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string Locasion { get; set; }
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
