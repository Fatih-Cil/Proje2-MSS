using Business.Abstract;
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

        public AdminController(IEmployeeService employeeService, IAuthorityService authorityService)
        {
            _employeeService = employeeService;
            _authorityService = authorityService;

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
       
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Home");
        }
    }
}
