using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public void Add(Employee employee)
        {
            _employeeDal.Add(employee);
        }

        public void Delete(Employee employee)
        {
            _employeeDal.Delete(employee);
        }

        public List<Employee> GetAll()
        {
            return _employeeDal.GetAll();
        }

        public Employee GetByEmployeeRegisterNumber(string registerNumber)
        {
            return _employeeDal.Get(p => p.RegisterNumber == registerNumber);
        }

        public List<Employee> GetAllByEmployeeAuthId(int authorityId)
        {
            return _employeeDal.GetAll(p => p.AuthorityId == authorityId);
        }

        public Employee GetByEmployeeId(int employeeId)
        {
            return _employeeDal.Get(p => p.EmployeeId == employeeId);
        }

        public Employee GetByEmployeeMail(string mail)
        {
            return _employeeDal.Get(p => p.Mail == mail);
        }

        public void Update(Employee employee)
        {
            _employeeDal.Update(employee);
        }
    }
}
