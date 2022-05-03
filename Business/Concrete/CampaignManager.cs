using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CampaignManager : ICampaignService
    {
        ICampaignDal _campaignDal;

        public CampaignManager(ICampaignDal campaignDal)
        {
            _campaignDal = campaignDal;
        }

        public void Add(Campaign campaign)
        {
            _campaignDal.Add(campaign);
        }

        public void Delete(Campaign campaign)
        {
            _campaignDal.Delete(campaign);
        }

        public List<Campaign> GetAll()
        {
            return _campaignDal.GetAll();
        }

        public List<Campaign> GetByActiveAll(bool status)
        {
            return _campaignDal.GetAll(x=>x.Status==status);
        }

        public Campaign GetByCampaignId(int campaignId)
        {
            return _campaignDal.Get(x=>x.CampaignId==campaignId);
        }

        public void Update(Campaign campaign)
        {
            _campaignDal.Update(campaign);
        }
    }
}
