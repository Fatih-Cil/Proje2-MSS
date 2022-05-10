using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ShopCampaign:IEntity
    {

        [Key]
        public int ShopCampaignId { get; set; }
        public int ShopId { get; set; }
        public int CampaignId { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual Campaign Campaign { get; set; }
    }
}
