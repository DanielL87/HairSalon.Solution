using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {
       [HttpGet("/stylists")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);   
        }    

        [HttpGet("/stylists/new")]
        public ActionResult New()
        {
           
            return View();   
        }  

        [HttpPost("/stylists")]
         public ActionResult Create(string stylistName) 
        {
            Stylist myStylist = new Stylist(stylistName);
            myStylist.Save();
            List<Stylist> allStylists = Stylist.GetAll();
            return View("Index", allStylists);
        }

        [HttpGet("/stylist/show/{id}")]
        public ActionResult Show(int id)
        {   
            Stylist foundStylist = Stylist.FindById(id);
            Dictionary<string, object> model = new Dictionary<string, object> ();
            List<Client> allClients = Client.FindByStylistId(id); 
            List<Specialty> allSpecialties = Specialty.GetAll(); 
            List<Specialty> stylistsSpecialties = foundStylist.GetSpecialties();
            model.Add("stylist", foundStylist);
            model.Add("clients", allClients);
            model.Add("specialties", allSpecialties);
            model.Add("stylistSpecialties", stylistsSpecialties);
            return View(model);
        }  

        [HttpPost("/stylists/{stylistId}/clients/new/")]
         public ActionResult CreateClient(string clientName, int stylistId) 
        {
            Client newClient = new Client(clientName, stylistId);
            newClient.Save();
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist myStylist = Stylist.FindById(stylistId);
            List<Client> myClient = Client.FindByStylistId(stylistId);
           
            model.Add("stylist", myStylist);
            model.Add("clients", myClient);
           
            return View("Show", model);
        }

        [HttpGet("/stylists/{id}/remove")]
        public ActionResult Remove(int id)
        {
         Stylist.DeleteStylistById(id);
         return RedirectToAction("Index");
        }

        [HttpGet("/stylists/removeall")]
        public ActionResult RemoveAll()  
        {  
          Stylist.ClearAll();  
          return RedirectToAction("Index");
        }

        [HttpPost("stylist/{id}/edit")]
        public ActionResult EditName(int id, string stylistName)
        { 
          Stylist foundStylist = Stylist.FindById(id);  
          foundStylist.EditName(stylistName);
          return RedirectToAction("Show"); 
        }

        [HttpPost("/stylist/{id}/addspecialty")]
        public ActionResult AddSpecialty(int id, int specialtyId)
        {
          Specialty foundSpecialty = Specialty.FindById(specialtyId);
          Stylist foundStylist = Stylist.FindById(id);
          foundStylist.AddSpecialty(foundSpecialty);
          return RedirectToAction("Show", id);  
        }
        
    }
}
