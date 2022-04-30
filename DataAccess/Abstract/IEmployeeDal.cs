using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEmployeeDal : IEntityRepository<Employee>
    {
        //dto ile join yapılması sağlanıyor. 
        List<EmployeeDetailDTO> GetEmployeeDatails();
    }
}
