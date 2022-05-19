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
    public class EfVisitorEventDal : EfEntityRepositoryBase<VisitorEvent, MSSContext>, IVisitorEventDal
    {
        public List<VisitorDetailDTO> GetVisitorDetails()
        {
            using (MSSContext context = new MSSContext()) //joint atmak için context açıyorum.
            {
                var result = from visitor in context.VisitorEvents

                             join shop in context.Shops
                             on visitor.ShopId equals shop.ShopId


                             select new VisitorDetailDTO
                             {
                                 VisitorId=visitor.VisitorId,
                                 EventDate=visitor.EventDate,
                                 EventTime=visitor.EventTime,
                                 Pozition=visitor.Pozition,
                                 
                                 ShopName = shop.ShopName,
                                 Locasion = shop.Locasion,
                                 


                             };
                return result.ToList();

            }
        }
    }
}
