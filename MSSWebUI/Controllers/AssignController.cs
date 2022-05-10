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

        public IActionResult Index()
        {
            

            AddAssignDTO addAssignDTO = new AddAssignDTO();
            addAssignDTO.EmployeeList= _employeeService.GetAll();
            addAssignDTO.ShopList = _shopService.GetAll();
            addAssignDTO.ShiftList = _shiftService.GetAll();
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
    }
}
