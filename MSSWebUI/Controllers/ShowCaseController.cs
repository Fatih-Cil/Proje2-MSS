using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSSWebUI.Controllers
{
    public class ShowCaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
