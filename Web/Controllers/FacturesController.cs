using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
//
using Data.Repositories;
using Data.Infrastructure;
using Domain.Entities;
using Service;


namespace Web.Controllers
{
    public class FacturesController : Controller
    {
        //private MyFinanceContext db = new MyFinanceContext();

        private ServiceFacture servfct;

        public FacturesController()
        {
            this.servfct = new ServiceFacture();
        }

        // GET: Factures
        public ActionResult Index(string prix)
        {
            var factures = servfct.GetAll();

            if (!String.IsNullOrEmpty(prix))
            {
                factures = servfct.GetFactureByPrice(prix).ToList();
            }
            return View(factures);
        }

        // GET: Factures/Details/5
        public ActionResult Details(int Productid, int ClientId, DateTime Dateachat)
        {
            if (Productid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = servfct.GetFactureById(Productid, ClientId, Dateachat);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // GET: Factures/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(servfct.unitofwork.DataContext.Client, "Cin", "Prenom");
            ViewBag.Productid = new SelectList(servfct.unitofwork.DataContext.Products, "ProductId", "Name");
            return View();
        }

        // POST: Factures/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DateAchat,Productid,ClientId,Prix")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                servfct.Create(facture);
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(servfct.unitofwork.DataContext.Client, "Cin", "Prenom", facture.ClientId);
            ViewBag.Productid = new SelectList(servfct.unitofwork.DataContext.Products, "ProductId", "Name", facture.Productid);
            return View(facture);
        }

        // GET: Factures/Edit/5
        public ActionResult Edit(int Productid, int ClientId, DateTime Dateachat)
        {
            if ((Productid == 0) || (ClientId == 0))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = servfct.GetFactureById(Productid, ClientId, Dateachat);

            if (facture == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = servfct.unitofwork.DataContext.Client.Where(a => a.Cin == ClientId).FirstOrDefault().Prenom;
            ViewBag.Productid = servfct.unitofwork.DataContext.Products.Where(a => a.ProductId == Productid).FirstOrDefault().Name;
            return View(facture);
        }

        // POST: Factures/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DateAchat,Productid,ClientId,Prix")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                servfct.Update(facture);
                return RedirectToAction("Index");
            }

            return View(facture);
        }

        // GET: Factures/Delete/5
        public ActionResult Delete(int Productid, int ClientId, DateTime Dateachat)
        {
            if ((Productid == 0) || (ClientId == 0))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = servfct.GetFactureById(Productid, ClientId, Dateachat);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // POST: Factures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Productid, int ClientId, DateTime Dateachat)
        {
            Facture facture = servfct.GetFactureById(Productid, ClientId, Dateachat);
            servfct.Delete(facture);
            return RedirectToAction("Index");
        }


    }
}
