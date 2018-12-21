using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet("/clients")]
        public ActionResult Index()
        {   
            List <Client> allClients = Client.GetAll();
            
            return View(allClients);
        }

        [HttpGet("/clients/removeall")]
        public ActionResult RemoveAll()  
        {  
          Client.ClearAll();  
          return RedirectToAction("Index");
        }

        [HttpGet("/clients/{id}/show")]
        public ActionResult Show(int id)
        {
           Client foundClient = Client.FindById(id);
           return View(foundClient);
        }

        [HttpGet("/clients/{id}/remove")]
        public ActionResult Remove(int id)
        {
         Client.DeleteClientById(id);
         return RedirectToAction("Index");
        }

        [HttpPost("client/{id}/edit")]
        public ActionResult EditName(int id, string clientName)
        { 
          Client foundClient = Client.FindById(id);  
          foundClient.EditName(clientName);
          return RedirectToAction("Show"); 
        }
    }    
}    