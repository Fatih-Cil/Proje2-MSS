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
    public class Shop:IEntity
    {
        [Key]
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string Locasion { get; set; }
        public TimeSpan Opening { get; set; }
        public TimeSpan Closing { get; set; }

       
        public bool Status { get; set; }

        public ICollection<EmployeeShop> EmployeeShops { get; set; }
        public ICollection<ShowCase> ShowCases { get; set; }
        public ICollection<ShopCampaign> ShopCampaigns { get; set; }
        public ICollection<Finance> Finances { get; set; }
        public ICollection<VisitorEvent> VisitorEvents { get; set; }
    }
}
