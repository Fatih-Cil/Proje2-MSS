using Business.Abstract;
using Business.FluentValidation;
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
    public class ShopController : Controller
    {
        Employee _employee;
        IShopService _shopService;

        public ShopController(IShopService shopService)
        {
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
            else if (_employee.AuthorityId > 1)
            {
                return RedirectToAction("ErrorPage", "Admin");
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
                return Redirect("Index");
            }
            _shopService.Add(shop);
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult DeleteShop(Shop shop)
        {
            var value = _shopService.GetByShopId(shop.ShopId);
            value.Status = false;
            try
            {
                _shopService.Update(value);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index", "Shop");
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
            return RedirectToAction("Index", "Shop");
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index", "home");
        }
    }
}

