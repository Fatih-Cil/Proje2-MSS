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
        

        public AdminController(IEmployeeService employeeService, IAuthorityService authorityService, IShopService shopService)
        {
            _employeeService = employeeService;
            _authorityService = authorityService;
            _shopService = shopService;

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

            
            var _authorty = _authorityService.GetByAuthortiyId(_employee.AuthorityId);

            
            EmployeeAuthDTO employeeAuthDTO = new EmployeeAuthDTO();
            employeeAuthDTO.Authority = _authorty;
            employeeAuthDTO.Employee = _employee;

            return View(employeeAuthDTO);
        }

        public IActionResult Shop()
        {
            if (!SessionKontrol())
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            var shop = _shopService.GetByActiveAll(true);
            return View(shop);
        }
        [HttpPost]
        public IActionResult AddShop(Shop shop)
        {
            ShopValidator validationRules = new ShopValidator();
            var result = validationRules.Validate(shop);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return Redirect("Shop");
            }
            _shopService.Add(shop);
            return Redirect("Shop");
        }

        [HttpPost]
        public IActionResult DeleteShop(Shop shop)
        {
           var value= _shopService.GetByShopId(shop.ShopId);
            value.Status = false;
            try
            {
                _shopService.Update(value);
            }
            catch (Exception)
            {
                
            }
            return RedirectToAction("Shop","Admin");
        }

        [HttpPost]
        public IActionResult UpdateShop(Shop shop)
        {
            
            try
            {
                _shopService.Update(shop);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Shop", "Admin");
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index","home");
        }
    }
}
