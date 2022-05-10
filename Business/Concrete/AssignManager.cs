using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AssignManager : IAssignService
    {
        IEmployeeShopDal _employeeShopDal;



        public AssignManager(IEmployeeShopDal employeeShopDal)
        {
            _employeeShopDal = employeeShopDal;

        }

        public void AddAssignShift(EmployeeShop employeeShop)
        {
            _employeeShopDal.Add(employeeShop);
        }


        public void DeleteAssignShift(EmployeeShop employeeShop)
        {
            _employeeShopDal.Delete(employeeShop);
        }


        public List<EmployeeShop> GetAllAssignShift()
        {
            return _employeeShopDal.GetAll();
        }

        public List<AssignDetailDTO> GetAssignDetails()
        {
            return _employeeShopDal.GetAssignDatails();
        }


        public void UpdateAssignShift(EmployeeShop employeeShop)
        {
            _employeeShopDal.Update(employeeShop);
        }
    }
}
