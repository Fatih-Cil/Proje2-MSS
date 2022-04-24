using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Shop:IEntity
    {
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string Locasion { get; set; }
        public DateTime Opening { get; set; }
        public DateTime Closing { get; set; }
    }
}
