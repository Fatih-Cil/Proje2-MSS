using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSSWebUI.Controllers
{
    public class CampaignController : Controller
    {
        Employee _employee;
        ICampaignService _campaignService;

        public CampaignController(ICampaignService campaignService)
        {
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
            else if (_employee.AuthorityId > 1)
            {
                return RedirectToAction("ErrorPage", "Admin");
            }
            var campaign = _campaignService.GetByActiveAll(true);

            return View(campaign);
        }

        [HttpPost]
        public IActionResult AddCampaign(Campaign campaign)
        {
            //ShopValidator validationRules = new ShopValidator();
            //var result = validationRules.Validate(shop);
            //if (!result.IsValid)
            //{
            //    foreach (var error in result.Errors)
            //    {
            //        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //    }
            //    return Redirect("Index");
            //}
            _campaignService.Add(campaign);
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult DeleteCampaign(Campaign campaign)
        {
            var value = _campaignService.GetByCampaignId(campaign.CampaignId);
            value.Status = false;
            try
            {
                _campaignService.Update(value);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index", "Campaign");
        }

        [HttpPost]
        public IActionResult UpdateCampaign(Campaign campaign)
        {

            try
            {
                _campaignService.Update(campaign);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index", "Campaign");
        }
    }
}
