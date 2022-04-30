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
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee, MSSContext>, IEmployeeDal
    {

        //bu method bana IEmployeDal ile zorunlu implement yapmam için geldi.
        public List<EmployeeDetailDTO> GetEmployeeDatails()
        {
            using (MSSContext context = new MSSContext()) //joint atmak için context açıyorum.
            {
                var result = from employee in context.Employees
                             
                             join auth in context.Authorities
                             on employee.AuthorityId equals auth.AuthorityId
                             

                             select new EmployeeDetailDTO
                             {
                                 EmployeeId = employee.EmployeeId,
                                 EmployeeName = employee.EmployeeName,
                                 EmployeeSurname = employee.EmployeeSurname,
                                 AuthorityName=auth.AuthorityName,
                                 Mail=employee.Mail,
                                 Password=employee.Password,
                                 RegisterNumber=employee.RegisterNumber,
                                 RegisterDate=employee.RegisterDate,
                                 Status=employee.Status
                                 
                             };
                return result.Where(p=>p.Status==true).ToList();

            }
        }
    }
}
