using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ShopCampaign:IEntity
    {
        public int ShopCampaignId { get; set; }
        public int ShopId { get; set; }
        public int CampaignId { get; set; }
    }
}
