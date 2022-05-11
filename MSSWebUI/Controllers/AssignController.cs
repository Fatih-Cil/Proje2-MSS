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
    public class AssignController : Controller
    {
        Employee _employee;
        IAssignService _assignService;
        IEmployeeService _employeeService;
        IShopService _shopService;
        IShiftService _shiftService;

        public AssignController(IAssignService assignService, IEmployeeService employeeService, IShopService shopService, IShiftService shiftService)
        {
            _assignService = assignService;
            _employeeService = employeeService;
            _shopService = shopService;
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

            AddAssignDTO addAssignDTO = new AddAssignDTO();
            addAssignDTO.EmployeeList= _employeeService.GetByActiveAll(true);
            addAssignDTO.ShopList = _shopService.GetByActiveAll(true);
            addAssignDTO.ShiftList = _shiftService.GetByActiveAll(true);
            addAssignDTO.AssignList = _assignService.GetAssignDetails();
            return View(addAssignDTO);
        }

        [HttpPost]
        public IActionResult AddAssignShift(AddAssignDTO addAssignDTO)
        {
            var vardiya=_shiftService.GetByShiftId(addAssignDTO.Shift.ShiftId);

            EmployeeShop employeeShop = new EmployeeShop();
            employeeShop.EmployeeId = addAssignDTO.Employee.EmployeeId;
            employeeShop.ShopId = addAssignDTO.Shop.ShopId;
            employeeShop.Date = addAssignDTO.WorkDate;
            employeeShop.CheckIn = vardiya.CheckIn;
            employeeShop.CheckOut = vardiya.CheckOut;

            _assignService.AddAssignShift(employeeShop);
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult DeleteAssignShift(AddAssignDTO addAssignDTO)
        {


            try
            {
                _assignService.DeleteAssignShift(addAssignDTO.EmployeeShop);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index", "Assign");
        }

        [HttpPost]
        public IActionResult UpdateAssignShift(AddAssignDTO addAssignDTO)
        {
           var shiftValue= _shiftService.GetByShiftId(addAssignDTO.Shift.ShiftId);


            addAssignDTO.EmployeeShop.ShopId = addAssignDTO.Shop.ShopId;
            addAssignDTO.EmployeeShop.EmployeeId = addAssignDTO.Employee.EmployeeId;
            addAssignDTO.EmployeeShop.Date = addAssignDTO.WorkDate;
            addAssignDTO.EmployeeShop.CheckIn = shiftValue.CheckIn;
            addAssignDTO.EmployeeShop.CheckOut = shiftValue.CheckOut;

            try
            {
                _assignService.UpdateAssignShift(addAssignDTO.EmployeeShop);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index", "Assign");
        }
    }
}
