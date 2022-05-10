using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfShopCampaignDal : EfEntityRepositoryBase<ShopCampaign, MSSContext>, IShopCampaignDal
    {
        public List<ShopCampaignDTO> GetShopCampaignDatails()
        {
            using (MSSContext context = new MSSContext()) //joint atmak için context açıyorum.
            {
                var result = from shopcampaign in context.ShopCampaigns

                             join shop in context.Shops
                             on shopcampaign.ShopId equals shop.ShopId
                             join campaign in context.Campaigns
                             on shopcampaign.CampaignId equals campaign.CampaignId


                             select new ShopCampaignDTO
                             {
                                 ShopCampaignId = shopcampaign.ShopCampaignId,
                                 ShopId = shop.ShopId,
                                 ShopName = shop.ShopName,
                                 Locasion = shop.Locasion,
                                 CampaignName = campaign.CampaignName,
                                 CampaignId = campaign.CampaignId,
                                 StartDate=campaign.StartDate,
                                 EndDate=campaign.EndDate
                                 

                             };
                return result.ToList();

            }
        }
    }
}
