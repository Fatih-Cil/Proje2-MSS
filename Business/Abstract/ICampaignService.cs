using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICampaignService
    {
        List<Campaign> GetAll();
        List<Campaign> GetByActiveAll(bool status);
        Campaign GetByCampaignId(int campaignId);
        void Add(Campaign campaign);
        void Delete(Campaign campaign);
        void Update(Campaign campaign);
    }
}
