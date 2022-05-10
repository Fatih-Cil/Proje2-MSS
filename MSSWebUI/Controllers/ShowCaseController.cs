using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSSWebUI.Models.DTO;
using Newtonsoft.Json;
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

            AddShowCaseShopDTO addShowCaseShopDTO = new AddShowCaseShopDTO();
            addShowCaseShopDTO.ShowCaseDetails= _showCaseService.GetShowCaseDetails();
            addShowCaseShopDTO.ShopList = _shopService.GetByActiveAll(true);
            return View(addShowCaseShopDTO);
            
        }
        public IActionResult AddShowCase()
        {
            if (!SessionKontrol())
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }

            AddShowCaseShopDTO addShowCaseShopDTO = new AddShowCaseShopDTO();
            addShowCaseShopDTO.ShowCaseDetails = _showCaseService.GetShowCaseDetails();
            addShowCaseShopDTO.ShopList = _shopService.GetByActiveAll(true);
            return View(addShowCaseShopDTO);

        }
        
        public IActionResult AddImage(int id)
        {
            if (!SessionKontrol())
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            AddShowCaseShopDTO addShowCaseShopDTO = new AddShowCaseShopDTO();
            addShowCaseShopDTO.Shop= _shopService.GetByShopId(id);            
            return View(addShowCaseShopDTO);

        }

        [HttpPost]
        public async Task<IActionResult> Upload(int id, IFormFile file)

        {
            if (!SessionKontrol())
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }

            var FileDic = "Upload\\ShowCase\\"+id+"\\"+DateTime.Now.ToShortDateString();

            string FilePath = Path.Combine(_environment.WebRootPath, FileDic);

            if (!Directory.Exists(FilePath))

                Directory.CreateDirectory(FilePath);

            var fileName =  file.FileName;
            fileName = fileName.Replace(" ","");
            var filePath = Path.Combine(FilePath, fileName);

            

            using (FileStream fs = System.IO.File.Create(filePath))

            {
                ShowCase showCase = new ShowCase();
                showCase.ShopId = id;
                showCase.StartDate = DateTime.Now;
                showCase.EndDate = DateTime.Now.AddDays(7);
                showCase.Url = FileDic+"\\"+fileName;
                _showCaseService.Add(showCase);

                file.CopyTo(fs);
                

            }

            return RedirectToAction("index", "ShowCase");

        }

        [HttpPost]
        public IActionResult DeleteShowCase(ShowCase showCase)
        {
            if (!SessionKontrol())
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }


            string FilePath = Path.Combine(_environment.WebRootPath, showCase.Url);

            try
            {
               
                if (System.IO.File.Exists(FilePath))
                {
                    // If file found, delete it    
                    System.IO.File.Delete(FilePath);
                    
                }

                _showCaseService.Delete(showCase);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index", "ShowCase");
        }

        [HttpPost]
        public IActionResult UpdateShowCase(AddShowCaseShopDTO addShowCaseShopDTO)
        {

            if (!SessionKontrol())
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }

            addShowCaseShopDTO.ShowCase.ShopId = addShowCaseShopDTO.Shop.ShopId;


            try
            {
                _showCaseService.Update(addShowCaseShopDTO.ShowCase);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index", "ShowCase");
        }
    }
}
