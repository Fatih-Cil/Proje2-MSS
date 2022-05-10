using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IShopCampaignService
    {
        List<ShopCampaign> GetAllAssignCampaign();
        void AddAssignCampaign(ShopCampaign shopCampaign);
        void UpdateAssignCampaign(ShopCampaign shopCampaign);
        void DeleteAssignCampaign(ShopCampaign shopCampaign);

        List<ShopCampaignDTO> GetShopCampaignDetails();
    }
}
