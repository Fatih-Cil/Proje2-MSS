using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MSSWebUI.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSSWebUI.Controllers
{
    public class ChartController : Controller
    {
        IVisitorEventService _visitorEventService;
        IShopService _shopService;

        public ChartController(IVisitorEventService visitorEventService, IShopService shopService)
        {
            _visitorEventService = visitorEventService;
            _shopService = shopService;
        }

        public IActionResult Index(int id)
        {

            var visitorEvent = _visitorEventService.GetVisitorDetails();

            var shop = _shopService.GetByShopId(id);

            List<DataPoint> dataPoints1 = new List<DataPoint>();
            List<DataPoint> dataPoints2 = new List<DataPoint>();
            List<DataPoint> dataPoints3 = new List<DataPoint>();
            for (double i = -7; i <= 0; i++)
            {

                var visitdate = DateTime.Now.AddDays(i);
                var girdi = visitorEvent.Where(x => x.Pozition.Contains("GIRDI") && x.EventDate.ToShortDateString() == visitdate.ToShortDateString() && x.ShopName == shop.ShopName && x.Locasion == shop.Locasion).Count();
                var giris = visitorEvent.Where(x => x.Pozition.Contains("GIRIS") && x.EventDate.ToShortDateString() == visitdate.ToShortDateString() && x.ShopName == shop.ShopName && x.Locasion == shop.Locasion).Count();
                var toplamMusteri = girdi - giris;

                dataPoints1.Add(new DataPoint(visitdate.ToString("dd MMM"), toplamMusteri));
            }

            for (double i = -30; i <= 0; i++)
            {

                var visitdate = DateTime.Now.AddDays(i);
                var girdi = visitorEvent.Where(x => x.Pozition.Contains("GIRDI") && x.EventDate.ToShortDateString() == visitdate.ToShortDateString() && x.ShopName == shop.ShopName && x.Locasion == shop.Locasion).Count();
                var giris = visitorEvent.Where(x => x.Pozition.Contains("GIRIS") && x.EventDate.ToShortDateString() == visitdate.ToShortDateString() && x.ShopName == shop.ShopName && x.Locasion == shop.Locasion).Count();
                var toplamMusteri = girdi - giris;

                dataPoints2.Add(new DataPoint(visitdate.ToString("dd MMM"), toplamMusteri));
            }

            for (double i = -180; i <= 0; i++)
            {

                var visitdate = DateTime.Now.AddDays(i);
                var girdi = visitorEvent.Where(x => x.Pozition.Contains("GIRDI") && x.EventDate.ToShortDateString() == visitdate.ToShortDateString() && x.ShopName == shop.ShopName && x.Locasion == shop.Locasion).Count();
                var giris = visitorEvent.Where(x => x.Pozition.Contains("GIRIS") && x.EventDate.ToShortDateString() == visitdate.ToShortDateString() && x.ShopName == shop.ShopName && x.Locasion == shop.Locasion).Count();
                var toplamMusteri = girdi - giris;

                dataPoints3.Add(new DataPoint(visitdate.ToString("dd MMM"), toplamMusteri));
            }
            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);

            ViewBag.DataPoints2 = JsonConvert.SerializeObject(dataPoints2);

            ViewBag.DataPoints3 = JsonConvert.SerializeObject(dataPoints3);



            return View(shop);

        }

      
    }
}
