using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEmployeeShopDal : IEntityRepository<EmployeeShop>
    {
        List<AssignDetailDTO> GetAssignDatails();
    }
}
