using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel_mvc1.Models;

namespace Hotel_mvc1.Controllers
{
    public class RezervacijeController : Controller
    {
        private hotelBazaContext db = new hotelBazaContext();

        // GET: Rezervacije
        public ActionResult Index()
        {
            return View(db.rezervacija.ToList());
        }

        // GET: Rezervacije/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervacija rezervacija = db.rezervacija.Find(id);
            if (rezervacija == null)
            {
                return HttpNotFound();
            }
            return View(rezervacija);
        }

        // GET: Rezervacije/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rezervacije/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idrezervacija,id_korisnik,id_soba,cijena,datumRezervacije,rezerviranoOd,rezerviranoDo")] Rezervacija rezervacija)
        {
            if (ModelState.IsValid)
            {
                db.rezervacija.Add(rezervacija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rezervacija);
        }

        // GET: Rezervacije/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervacija rezervacija = db.rezervacija.Find(id);
            if (rezervacija == null)
            {
                return HttpNotFound();
            }
            return View(rezervacija);
        }

        // POST: Rezervacije/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idrezervacija,id_korisnik,id_soba,cijena,datumRezervacije,rezerviranoOd,rezerviranoDo")] Rezervacija rezervacija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezervacija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rezervacija);
        }

        // GET: Rezervacije/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervacija rezervacija = db.rezervacija.Find(id);
            if (rezervacija == null)
            {
                return HttpNotFound();
            }
            return View(rezervacija);
        }

        // POST: Rezervacije/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rezervacija rezervacija = db.rezervacija.Find(id);
            db.rezervacija.Remove(rezervacija);
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
