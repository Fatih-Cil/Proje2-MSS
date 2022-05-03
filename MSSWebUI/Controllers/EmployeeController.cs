using Business.Abstract;
using Business.FluentValidation;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSSWebUI.Models.DTO;
using MSSWebUI.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSSWebUI.Controllers
{
    public class EmployeeController : Controller
    {
        Employee _employee;
        IEmployeeService _employeeService;
        IAuthorityService _authorityService;

        public EmployeeController(IEmployeeService employeeService, IAuthorityService authorityService)
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
           
            AddEmployeeDTO addEmployeeDTO = new AddEmployeeDTO();
            addEmployeeDTO.EmployeeDetail = _employeeService.GetEmployeeDetails();
            addEmployeeDTO.AuthorityList= _authorityService.GetAll();
            return View(addEmployeeDTO);
        }

        [HttpPost]
        public IActionResult Addemployee(AddEmployeeDTO addEmployeeDTO)
        {
            EmployeeValidator validationRules = new EmployeeValidator();
            var result = validationRules.Validate(addEmployeeDTO.Employee);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return Redirect("Index");
            }
            else if (addEmployeeDTO.Authority.AuthorityId<1)
            {
                
                ModelState.AddModelError("AuthorityId", "Yetki seçilmediği için kayıt yapılamadı.");
                return Redirect("Index");
            }
            addEmployeeDTO.Employee.AuthorityId = addEmployeeDTO.Authority.AuthorityId;

            _employeeService.Add(addEmployeeDTO.Employee);
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult DeleteEmployee(Employee employee)
        {
            var value = _employeeService.GetByEmployeeId(employee.EmployeeId);
            value.Status = false;
            try
            {
                _employeeService.Update(value);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index", "Employee");
        }

        [HttpPost]
        public IActionResult UpdateEmployee(AddEmployeeDTO addEmployeeDTO)
        {
            EmployeeValidator validationRules = new EmployeeValidator();
            var result = validationRules.Validate(addEmployeeDTO.Employee);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return Redirect("Index");
            }
            else if (addEmployeeDTO.Authority.AuthorityId < 1)
            {

                ModelState.AddModelError("AuthorityId", "Yetki seçilmediği için kayıt yapılamadı.");
                return Redirect("Index");
            }
            addEmployeeDTO.Employee.AuthorityId = addEmployeeDTO.Authority.AuthorityId;

            try
            {
                _employeeService.Update(addEmployeeDTO.Employee);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index", "Employee");
        }

    }
}
