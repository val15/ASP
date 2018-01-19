using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home



        public ActionResult Index(string id)
        {
           
            if (string.IsNullOrWhiteSpace(id))
                return View("Error");
            else
              ViewData["Nom"] = id;//passage du valeur vers la vue
                return View();// par defaut si il n'y a pas de parametre, ceci va appeler la view qui a le meme nom que la méthode

        }


        public ActionResult ListeClients()
        {
            Clients clients = new Clients();
            ViewData["Clients"] = clients.ObtenirListeClients();//on lie la liste
            return View();
        }

        public ActionResult ChercheClient(string id)
        {
            ViewData["Nom"] = id;
            Clients clients = new Clients();
            Client client = clients.ObtenirListeClients().FirstOrDefault(c => c.Nom == id);
            if (client != null)
            {
                ViewData["Age"] = client.Age;
                return View("Trouve");
            }
            return View("NonTrouve");
        }
        //public string Index2()
        //{
        //    return "Hello les contrôleurs";
        //}
        //public string Index(string id)//? signifie que le parametre est facultatif
        //{
        //    return @"
        //    <html>
        //        <head>
        //            <title>Hello World</title>
        //        </head>
        //        <body>
        //            <p>Hello <span style=""color:red"">" + id + @"</span></p>
        //        </body>
        //    </html>";
        //}



    }
}