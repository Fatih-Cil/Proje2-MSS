using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSSWebUI.Models;
using MSSWebUI.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MSSWebUI.Controllers
{
    
    public class VisitorController : Controller
    {
        Employee _employee;
        IVisitorEventService _visitorEventService;
        IShopService _shopService;

        public VisitorController(IVisitorEventService visitorEventService, IShopService shopService)
        {
            _visitorEventService = visitorEventService;
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
            ShowVisitorEventDTO showVisitorEventDTO = new ShowVisitorEventDTO();
            showVisitorEventDTO.VisitorDetails = _visitorEventService.GetVisitorDetails();
            //showVisitorEventDTO.ShopList = _shopService.GetAll();

            return View(showVisitorEventDTO);
        }

        [HttpPost]
        public IActionResult Chart()
        {
            return View();
        }

    }
}
