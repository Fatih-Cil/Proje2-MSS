using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSSWebUI.Models.DTO
{
    public class AddAssignCampaignDTO
    {
        public List<ShopCampaignDTO> AssignCampaignList { get; set; }
        public ShopCampaign ShopCampaign{ get; set; }
        public List<Shop> ShopList { get; set; }
        public Shop Shop { get; set; }
        public List<Campaign> CampaignList { get; set; }
        public Campaign Campaign { get; set; }
    }
}
