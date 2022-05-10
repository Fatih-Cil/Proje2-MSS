using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAssignService
    {
        List<EmployeeShop> GetAllAssignShift();
        void AddAssignShift(EmployeeShop employeeShop);
        void UpdateAssignShift(EmployeeShop employeeShop);
        void DeleteAssignShift(EmployeeShop employeeShop);
        List<ShopCampaign> GetAllAssignCampaign();
        void AddAssignCampaign(ShopCampaign shopCampaign);
        void UpdateAssignCampaign(ShopCampaign shopCampaign);
        void DeleteAssignCampaign(ShopCampaign shopCampaign);

        List<AssignDetailDTO> GetAssignDetails();
    }
}
