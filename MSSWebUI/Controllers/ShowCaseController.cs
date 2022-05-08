using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSSWebUI.Models.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MSSWebUI.Controllers
{
    public class ShowCaseController : Controller
    {
        Employee _employee;
        IShowCaseService _showCaseService;
        IShopService _shopService;
        private IHostingEnvironment _environment;
        public ShowCaseController(IShowCaseService showCaseService, IShopService shopService, IHostingEnvironment environment)
        {
            _showCaseService = showCaseService;
            _shopService = shopService;
            _environment = environment;

        }

        public IActionResult Index()
        {


            AddShowCaseShopDTO addShowCaseShopDTO = new AddShowCaseShopDTO();
            addShowCaseShopDTO.ShowCaseDetails= _showCaseService.GetShowCaseDetails();
            addShowCaseShopDTO.ShopList = _shopService.GetByActiveAll(true);
            return View(addShowCaseShopDTO);
            
        }
        public IActionResult AddShowCase()
        {


            AddShowCaseShopDTO addShowCaseShopDTO = new AddShowCaseShopDTO();
            addShowCaseShopDTO.ShowCaseDetails = _showCaseService.GetShowCaseDetails();
            addShowCaseShopDTO.ShopList = _shopService.GetByActiveAll(true);
            return View(addShowCaseShopDTO);

        }
        
        public IActionResult AddImage(int id)
        {
            AddShowCaseShopDTO addShowCaseShopDTO = new AddShowCaseShopDTO();
            addShowCaseShopDTO.Shop= _shopService.GetByShopId(id);            
            return View(addShowCaseShopDTO);

        }

        [HttpPost]
        public async Task<IActionResult> Upload(int id, IFormFile file)

        {
            

            var FileDic = "Upload\\ShowCase\\"+id+"\\"+DateTime.Now.ToShortDateString();

            string FilePath = Path.Combine(_environment.WebRootPath, FileDic);

            if (!Directory.Exists(FilePath))

                Directory.CreateDirectory(FilePath);

            var fileName = file.FileName;

            var filePath = Path.Combine(FilePath, fileName);

            using (FileStream fs = System.IO.File.Create(filePath))

            {
                ShowCase showCase = new ShowCase();
                showCase.ShopId = id;
                showCase.StartDate = DateTime.Now;
                showCase.EndDate = DateTime.Now.AddDays(7);
                showCase.Url = filePath;
                _showCaseService.Add(showCase);

                file.CopyTo(fs);


            }

            return RedirectToAction("index", "ShowCase");

        }


    }
}
