using Business.Abstract;
using Business.FluentValidation;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSSWebUI.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSSWebUI.Controllers
{
    public class AdminController : Controller
    {
        Employee _employee;
        IEmployeeService _employeeService;
        IAuthorityService _authorityService;
        IShopService _shopService;
        ICampaignService _campaignService;
        IVisitorEventService _visitorEventService;
        

        public AdminController(IEmployeeService employeeService, IAuthorityService authorityService, IShopService shopService,ICampaignService campaignService, IVisitorEventService visitorEventService)
        {
            _employeeService = employeeService;
            _authorityService = authorityService;
            _shopService = shopService;
            _campaignService = campaignService;
            _visitorEventService = visitorEventService;
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

            
            var authorty = _authorityService.GetByAuthortiyId(_employee.AuthorityId);
            var shoplist = _shopService.GetByActiveAll(true);
            var employeelist = _employeeService.GetByActiveAll(true);
            var visitorlist = _visitorEventService.GetAll();
            var campaignactive = _campaignService.GetByActiveAll(true);
            
            EmployeeAuthDTO employeeAuthDTO = new EmployeeAuthDTO();
            employeeAuthDTO.Authority = authorty;
            employeeAuthDTO.Employee = _employee;
            employeeAuthDTO.ShopList = shoplist;
            employeeAuthDTO.EmployeeList = employeelist;
            employeeAuthDTO.VisitorEventList = visitorlist;
            employeeAuthDTO.CampaignActiveList = campaignactive;

            return View(employeeAuthDTO);
        }

       

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index","home");
        }
    }
}
