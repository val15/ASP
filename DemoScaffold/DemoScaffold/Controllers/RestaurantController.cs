using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TPFilRougeChoixResto.Models;

namespace DemoScaffold.Controllers
{
    public class RestaurantController : Controller
    {
        private BddContext db = new BddContext();

        // GET: Restaurant
        public ActionResult Index()
        {
            return View(db.Restos.ToList());
        }

        // GET: Restaurant/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resto resto = db.Restos.Find(id);
            if (resto == null)
            {
                return HttpNotFound();
            }
            return View(resto);
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Telephone,Email")] Resto resto)
        {
            if (ModelState.IsValid)
            {
                db.Restos.Add(resto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resto);
        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resto resto = db.Restos.Find(id);
            if (resto == null)
            {
                return HttpNotFound();
            }
            return View(resto);
        }

        // POST: Restaurant/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Telephone,Email")] Resto resto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resto);
        }

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resto resto = db.Restos.Find(id);
            if (resto == null)
            {
                return HttpNotFound();
            }
            return View(resto);
        }

        // POST: Restaurant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resto resto = db.Restos.Find(id);
            db.Restos.Remove(resto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
