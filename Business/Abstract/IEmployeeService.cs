using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        List<Employee> GetByActiveAll(bool status);
        Employee GetByEmployeeId(int employeeId);
        Employee GetByEmployeeMail(string mail);
        List<Employee> GetAllByEmployeeAuthId(int authorityId);
        Employee GetByEmployeeRegisterNumber(string registerNumber);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);

        //bu method ile  join yaptığım sonucun bilgilerini getiriyorum.
        List<EmployeeDetailDTO> GetEmployeeDetails();

    }
}
