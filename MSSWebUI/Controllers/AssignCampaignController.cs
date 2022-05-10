using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MSSWebUI.Models.DTO;
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

        public IActionResult Index()
        {

            AddAssignCampaignDTO addAssignCampaignDTO = new AddAssignCampaignDTO();
            addAssignCampaignDTO.ShopList = _shopService.GetAll();
            addAssignCampaignDTO.CampaignList = _campaignService.GetAll();
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
    }
}
