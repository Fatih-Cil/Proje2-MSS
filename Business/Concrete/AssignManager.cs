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
        IShopCampaignDal _shopCampaignDal;
        

        public AssignManager(IEmployeeShopDal employeeShopDal, IShopCampaignDal shopCampaignDal)
        {
            _employeeShopDal = employeeShopDal;
            _shopCampaignDal = shopCampaignDal;
        }

        public void AddAssignCampaign(ShopCampaign shopCampaign)
        {
            _shopCampaignDal.Add(shopCampaign);
        }

        public void AddAssignShift(EmployeeShop employeeShop)
        {
            _employeeShopDal.Add(employeeShop);
        }

        public void DeleteAssignCampaign(ShopCampaign shopCampaign)
        {
            _shopCampaignDal.Delete(shopCampaign);
        }

        public void DeleteAssignShift(EmployeeShop employeeShop)
        {
            _employeeShopDal.Delete(employeeShop);
        }

        public List<ShopCampaign> GetAllAssignCampaign()
        {
            return _shopCampaignDal.GetAll();
        }

        public List<EmployeeShop> GetAllAssignShift()
        {
            return _employeeShopDal.GetAll();
        }

        public List<AssignDetailDTO> GetAssignDetails()
        {
            return _employeeShopDal.GetAssignDatails();
        }

        public void UpdateAssignCampaign(ShopCampaign shopCampaign)
        {
            _shopCampaignDal.Update(shopCampaign);
        }

        public void UpdateAssignShift(EmployeeShop employeeShop)
        {
            _employeeShopDal.Update(employeeShop);
        }
    }
}
