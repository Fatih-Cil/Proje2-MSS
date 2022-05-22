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
    public class EfFinanceDal : EfEntityRepositoryBase<Finance, MSSContext>, IFinanceDal
    {
        public List<FinanceDetailDTO> GetFinanceDatails()
        {
            using (MSSContext context = new MSSContext()) //joint atmak için context açıyorum.
            {
                var result = from finance in context.Finances

                             join shop in context.Shops
                             on finance.ShopId equals shop.ShopId


                             select new FinanceDetailDTO
                             {
                                 FinanceId=finance.FinanceId,
                                 ShopId=shop.ShopId,
                                 ShopName=shop.ShopName,
                                 Locasion=shop.Locasion,
                                 DailySalesAmount=finance.DailySalesAmount,
                                 DailySalesEarning=finance.DailySalesEarning,
                                 SalesDate=finance.SalesDate


                             };
                return result.ToList();

            }
        }
    }
}
