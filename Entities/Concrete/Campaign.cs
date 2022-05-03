using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Campaign:IEntity
    {
        [Key]
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [DefaultValue("true")]
        public bool Status { get; set; }

        public ICollection<ShopCampaign> ShopCampaigns { get; set; }

    }
}
