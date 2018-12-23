using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class SpecialtyController : Controller
    {
        [HttpGet("/specialties")] 
        public ActionResult Index()
        {
        List <Specialty> allSpecialties = Specialty.GetAll();  
        return View(allSpecialties);  
        }  

        [HttpGet("/specialties/new")]
        public ActionResult New()
        {
            return View();   
        }  

        [HttpPost("/specialties")]
         public ActionResult Create(string specialtyName) 
        {
            Specialty mySpecialty = new Specialty(specialtyName);
            mySpecialty.Save();
            List<Specialty> allSpecialtys = Specialty.GetAll();
            return View("Index", allSpecialtys);
        }

        [HttpGet("/specialties/show/{id}")]
        public ActionResult Show(int id)
        {   
            Dictionary <string, object> model = new Dictionary <string, object> {};
            Specialty foundSpecialty = Specialty.FindById(id);
            List<Stylist> allStylists = Stylist.GetAll();
            List<Stylist> specialtyStylists = foundSpecialty.GetStylists();
            model.Add("specialty", foundSpecialty);
            model.Add("stylists", allStylists);
            model.Add("specialtyStylists", specialtyStylists);
            return View(model);
        }  

        [HttpPost("/specialties/show/{id}/addstylist")]
        public ActionResult AddStylist(int id, int stylistId)
        {
          Specialty foundSpecialty = Specialty.FindById(id);
          Stylist foundStylist = Stylist.FindById(stylistId);
          foundSpecialty.AddStylist(foundStylist);
          return RedirectToAction("Show", id);  
        }
    }
}