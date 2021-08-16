using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Domain.Entities;
//
using Data.Repositories;
using Data.Infrastructure;
using Domain.Entities;
using Service;
//
using Web.Models;

namespace Web.Controllers
{
    public class ClientsController : Controller
    {
        private MyFinanceContext db = new MyFinanceContext();

        private ServiceClient servclt;

        public ClientsController()
        {
            this.servclt = new ServiceClient();
        }

        // GET: Clients
        public ActionResult Index()
        {
            //return View(servclt.GetAll().ToList());
            var listclient = servclt.GetAll().ToList();

            List<ClientModel> listclientmodel = new List<ClientModel>();

            foreach (var client in listclient)
            {
                var clientmodel = new ClientModel(client);
                clientmodel.PrixFactures = servclt.GetTotalFacturePrice(client.Cin);
                listclientmodel.Add(clientmodel);
            }

            return View(listclientmodel);
        }


        // GET: Clients/Details/5
        public ActionResult InfoClient(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = servclt.GetById(id);

            if (client == null)
            {
                return HttpNotFound();
            }
            return PartialView(client);
            
        }


        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = servclt.GetById(id);
            
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cin,Prenom,Nom,Email")] Client client)
        {
            if (ModelState.IsValid)
            {
                servclt.Create(client);
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = servclt.GetById(id);
            
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cin,Prenom,Nom,Email")] Client client)
        {
            if (ModelState.IsValid)
            {
                servclt.Update(client);
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = servclt.GetById(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Client client = servclt.GetById(id);
            servclt.Delete(client);
            return RedirectToAction("Index");
        }

    
    }
}
