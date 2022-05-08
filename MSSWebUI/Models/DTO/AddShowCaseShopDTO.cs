using Entities.Concrete;
using Entities.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSSWebUI.Models.DTO
{
    public class AddShowCaseShopDTO
    {
        public List<ShowCaseDetailDTO> ShowCaseDetails { get; set; }
        public List<Shop> ShopList { get; set; }
        public ShowCase ShowCase { get; set; }
        public Shop Shop { get; set; }
        public int ShopId { get; set; }
        public IFormFile File{ get; set; }
    }
}
