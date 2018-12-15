using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet("/stylist/show/{id}")]
        public ActionResult Index(int id)
        {   
            Stylist foundStylist = Stylist.FindById(id);
            Dictionary<string, object> model = new Dictionary<string, object> ();
            List<Client> allClients = Client.FindByStylistId(id);  
            model.Add("stylist", foundStylist);
            model.Add("clients", allClients);
            return View(model);
        }  

        // [HttpGet("/clients/new")]
        // public ActionResult New()
        // {
        //  List<Stylist> allStylists = Stylist.GetAll();   
        //  return View(allStylists);   
        // }

        [HttpPost("/stylists/{stylistId}/clients/new/")]
         public ActionResult Show(string clientName, int stylistId) 
        {
            Client newClient = new Client(clientName, stylistId);
            newClient.Save();
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist myStylist = Stylist.FindById(stylistId);
            List<Client> myClient = Client.FindByStylistId(stylistId);
            model.Add("stylist", myStylist);
            model.Add("client", myClient);
            
            return View("Index", model);
        }
    }
}    