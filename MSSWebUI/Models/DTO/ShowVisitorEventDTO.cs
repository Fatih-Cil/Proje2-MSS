using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSSWebUI.Models.DTO
{
    public class ShowVisitorEventDTO
    {
        public List<VisitorDetailDTO> VisitorDetails { get; set; }
        public List<Shop> ShopList { get; set; }
        public VisitorEvent VisitorEvent { get; set; }
        public Shop Shop { get; set; }
       

    }
}
