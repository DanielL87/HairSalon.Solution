using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {
       [HttpGet("/stylists/index")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);   
        }    

        [HttpGet("/stylists/new")]
        public ActionResult New()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);   
        }  

        [HttpPost("/stylists/show")]
         public ActionResult Show(string stylistName) 
        {
            Stylist myStylist = new Stylist(stylistName);
            myStylist.Save();
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);
        }

    }
}
