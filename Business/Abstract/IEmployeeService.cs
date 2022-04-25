using Entities.Concrete;
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
        Employee GetByEmployeeId(int employeeId);
        Employee GetByEmployeeMail(string mail);
        List<Employee> GetAllByEmployeeAuthId(int authId);
        Employee GetByEmployeeRegisterNumber(string registerNumber);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);

    }
}
