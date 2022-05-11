using Business.Abstract;
using Business.FluentValidation;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MSSWebUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MSSWebUI.Controllers
{
    public class HomeController : Controller
    {
        IEmployeeService _employeeService;

        public HomeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Employee login)
        {
            LoginValidator validationRules = new LoginValidator();
            var result = validationRules.Validate(login);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();
            }

            //Validation geçen bilgi database için sorguya hazırlanıyor.
            var _user = _employeeService.GetByEmployeeMail(login.Mail);

            if (_user == null)
            {
                ModelState.AddModelError("Mail", "Kullanıcı bulunamadı");
                return View();
            }
            
            else
            {
                if (_user.Mail == login.Mail && _user.Password == login.Password && _user.Status==true)
                {

                    //ModelState.AddModelError("Password", "Giriş başarılı");
                    //return View();
                    HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(_user));
                    return RedirectToAction("index", "Admin");


                }
                else
                {
                    ModelState.AddModelError("Password", "Giriş başarısız");
                    return View();
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
