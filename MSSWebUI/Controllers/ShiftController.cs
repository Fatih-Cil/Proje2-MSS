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
    public class ShiftController : Controller
    {
        Employee _employee;
        IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
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
            var shift = _shiftService.GetByActiveAll(true);
            
            return View(shift);
        }

        [HttpPost]
        public IActionResult AddShift(Shift shift)
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
            _shiftService.Add(shift);
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult DeleteShift(Shift shift)
        {
            var value = _shiftService.GetByShiftId(shift.ShiftId);
            value.Status = false;
            try
            {
                _shiftService.Update(value);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index", "Shift");
        }

        [HttpPost]
        public IActionResult UpdateShift(Shift shift)
        {

            try
            {
                _shiftService.Update(shift);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index", "Shift");
        }
    }
}
