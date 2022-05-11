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
    public class EfEmployeeShopDal : EfEntityRepositoryBase<EmployeeShop, MSSContext>, IEmployeeShopDal
    {
        public List<AssignDetailDTO> GetAssignDatails()
        {
            using (MSSContext context = new MSSContext()) //joint atmak için context açıyorum.
            {
                var result = from assign in context.EmployeeShops

                             join employee in context.Employees
                             on assign.EmployeeId equals employee.EmployeeId
                             join shop in context.Shops
                             on assign.ShopId equals shop.ShopId
                             


                             select new AssignDetailDTO
                             {
                                 EmployeeShopId=assign.EmployeShopId,
                                EmployeeId=employee.EmployeeId,
                                 EmployeeName = employee.EmployeeName,
                                 EmployeeSurname = employee.EmployeeSurname,
                                 ShopName=shop.ShopName,
                                 Locasion=shop.Locasion,
                                 CheckIn=assign.CheckIn,
                                 CheckOut=assign.CheckOut,
                                 WorkDate=assign.Date

                             };
                return result.ToList();

            }
        }
    }
}
