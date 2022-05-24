using Business.Abstract;
using Business.FluentValidation;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSSWebUI.Models;
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
        IFinanceService _financeService;

        public AdminController(IEmployeeService employeeService, IAuthorityService authorityService, IShopService shopService, ICampaignService campaignService, IVisitorEventService visitorEventService, IFinanceService financeService)
        {
            _employeeService = employeeService;
            _authorityService = authorityService;
            _shopService = shopService;
            _campaignService = campaignService;
            _visitorEventService = visitorEventService;
            _financeService = financeService;
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
            var financeList = _financeService.GetFinanceDetails();
            EmployeeAuthDTO employeeAuthDTO = new EmployeeAuthDTO();
            employeeAuthDTO.Authority = authorty;
            employeeAuthDTO.Employee = _employee;
            employeeAuthDTO.ShopList = shoplist;
            employeeAuthDTO.EmployeeList = employeelist;
            employeeAuthDTO.VisitorEventList = visitorlist;
            employeeAuthDTO.CampaignActiveList = campaignactive;
            employeeAuthDTO.FinanceList = financeList;
            return View(employeeAuthDTO);
        }

      
        //public ContentResult JSON()
        //{
        //    List<DataPoint> list = new List<DataPoint>();
        //    var visitorlist = _visitorEventService.GetAll();
        //    var shoplist = _shopService.GetByActiveAll(true);
        //    foreach (var shop in shoplist)
        //    {
        //        for (int i = 1; i <= 7; i++)
        //        {
        //            var visitdate = DateTime.Now.AddDays(-i);
        //            var girdi = visitorlist.Where(x => x.Pozition.Contains("GIRDI") && x.EventDate.ToShortDateString() == visitdate.ToShortDateString() && x.ShopId == shop.ShopId).Count();
        //            var giris = visitorlist.Where(x => x.Pozition.Contains("GIRIS") && x.EventDate.ToShortDateString() == visitdate.ToShortDateString() && x.ShopId == shop.ShopId).Count();
        //            var toplamMusteri = girdi - giris;
        //            list.Add(new DataPoint(visitdate, toplamMusteri));

        //        }
        //    }
               

           
        //    JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        //    return Content(JsonConvert.SerializeObject(list, _jsonSetting), "application/json");


        //}

        

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index", "home");
        }

        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
