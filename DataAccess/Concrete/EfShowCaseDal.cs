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
    public class EfShowCaseDal : EfEntityRepositoryBase<ShowCase, MSSContext>, IShowCaseDal
    {
        public List<ShowCaseDetailDTO> GetShowCaseDatails()
        {
            using (MSSContext context = new MSSContext()) //joint atmak için context açıyorum.
            {
                var result = from showCase in context.ShowCases

                             join shop in context.Shops
                             on showCase.ShopId equals shop.ShopId


                             select new ShowCaseDetailDTO
                             {
                                 ShowCaseId = showCase.ShowCaseId,
                                 ShopId=shop.ShopId,
                                 ShopName = shop.ShopName,
                                 Locasion = shop.Locasion,
                                 StartDate = showCase.StartDate,
                                 EndDate=showCase.EndDate,
                                 Url = showCase.Url,



                             };
                return result.ToList();

            }
        }
    }
}
