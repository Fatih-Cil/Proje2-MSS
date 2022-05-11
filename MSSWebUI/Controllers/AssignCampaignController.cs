using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSSWebUI.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSSWebUI.Controllers
{
    public class AssignCampaignController : Controller
    {
        Employee _employee;
        IShopCampaignService _shopCampaignService;
        IShopService _shopService;
        ICampaignService _campaignService;

        public AssignCampaignController(IShopCampaignService shopCampaignService, IShopService shopService, ICampaignService campaignService)
        {
            _shopCampaignService = shopCampaignService;
            _shopService = shopService;
            _campaignService = campaignService;
        }

        public bool SessionKontrol()
        {
            try
            {
                _employee = JsonConvert.DeserializeObject<Employee>(HttpContext.Session.GetString("SessionUser"));


                bool result = (_employee == null) ? false : true;
                return result;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public IActionResult Index()
        {
            if (!SessionKontrol())
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }

            AddAssignCampaignDTO addAssignCampaignDTO = new AddAssignCampaignDTO();
            addAssignCampaignDTO.ShopList = _shopService.GetByActiveAll(true);
            addAssignCampaignDTO.CampaignList = _campaignService.GetByActiveAll(true);
            addAssignCampaignDTO.AssignCampaignList = _shopCampaignService.GetShopCampaignDetails();
            return View(addAssignCampaignDTO);
        }

        [HttpPost]
        public IActionResult AddAssignCampaign(AddAssignCampaignDTO addAssignCampaignDTO)
        {
            var vardiya = _campaignService.GetByCampaignId(addAssignCampaignDTO.Campaign.CampaignId);

            ShopCampaign shopCampaign = new ShopCampaign();
            shopCampaign.ShopId = addAssignCampaignDTO.Shop.ShopId;
            shopCampaign.CampaignId = addAssignCampaignDTO.Campaign.CampaignId;


           _shopCampaignService.AddAssignCampaign(shopCampaign);
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult DeleteAssignCampaign(AddAssignCampaignDTO addAssignCampaignDTO)
        {


            try
            {
               _shopCampaignService.DeleteAssignCampaign(addAssignCampaignDTO.ShopCampaign);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index", "AssignCampaign");
        }

        [HttpPost]
        public IActionResult UpdateAssignCampaign(AddAssignCampaignDTO addAssignCampaignDTO)
        {
           
            addAssignCampaignDTO.ShopCampaign.ShopId = addAssignCampaignDTO.Shop.ShopId;
            addAssignCampaignDTO.ShopCampaign.CampaignId = addAssignCampaignDTO.Campaign.CampaignId;
            
            try
            {
               _shopCampaignService.UpdateAssignCampaign(addAssignCampaignDTO.ShopCampaign);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index", "AssignCampaign");
        }
    }
}
