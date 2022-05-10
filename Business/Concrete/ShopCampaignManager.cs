using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ShopCampaignManager : IShopCampaignService
    {
        IShopCampaignDal _shopCampaignDal;

        public ShopCampaignManager(IShopCampaignDal shopCampaignDal)
        {
            _shopCampaignDal = shopCampaignDal;
        }

        public void AddAssignCampaign(ShopCampaign shopCampaign)
        {
            _shopCampaignDal.Add(shopCampaign);
        }

        public void DeleteAssignCampaign(ShopCampaign shopCampaign)
        {
            _shopCampaignDal.Delete(shopCampaign);
        }

        public List<ShopCampaign> GetAllAssignCampaign()
        {
            return _shopCampaignDal.GetAll();
        }

        public List<ShopCampaignDTO> GetShopCampaignDetails()
        {
            return _shopCampaignDal.GetShopCampaignDatails();
        }

        public void UpdateAssignCampaign(ShopCampaign shopCampaign)
        {
            _shopCampaignDal.Update(shopCampaign);
        }
    }
}
