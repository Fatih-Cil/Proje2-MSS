﻿using Business.Abstract;
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
    public class FinanceController : Controller
    {
        Employee _employee;
        IFinanceService _financeService;
        IShopService _shopService;

        public FinanceController(IFinanceService financeService, IShopService shopService)
        {
            _financeService = financeService;
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

            AddFinanceShopDTO addFinanceShopDTO = new AddFinanceShopDTO();
            addFinanceShopDTO.FinanceDetails = _financeService.GetFinanceDetails();
            addFinanceShopDTO.ShopList= _shopService.GetByActiveAll(true);
            return View(addFinanceShopDTO);
        }

        [HttpPost]
        public IActionResult AddFinance(AddFinanceShopDTO addFinanceShopDTO)
        {
            
            if (addFinanceShopDTO.Shop.ShopId< 1)
            {

                ModelState.AddModelError("ShopId", "Şube seçilmediği için kayıt yapılamadı.");
                return Redirect("Index");
            }
            addFinanceShopDTO.Finance.ShopId= addFinanceShopDTO.Shop.ShopId;

            _financeService.Add(addFinanceShopDTO.Finance);
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult DeleteFinance(Finance finance)
        {
            
            try
            {
                _financeService.Delete(finance);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index", "Finance");
        }

        [HttpPost]
        public IActionResult UpdateFinance(AddFinanceShopDTO addFinanceShopDTO)
        {
            
            addFinanceShopDTO.Finance.ShopId= addFinanceShopDTO.Shop.ShopId;

            try
            {
                _financeService.Update(addFinanceShopDTO.Finance);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index", "Finance");
        }

    }
}
