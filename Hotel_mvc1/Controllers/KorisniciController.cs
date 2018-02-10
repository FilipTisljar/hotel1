using System;
using System.IO;
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
    public class KorisniciController : Controller
    {
        private hotelBazaContext db = new hotelBazaContext();

        // GET: Korisnici
        public ActionResult Index()
        {
            return View(db.korisnik.ToList());
        }

        // GET: Korisnici/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.korisnik.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }
        // create ilitiga register, isto je...
        // GET: Korisnici/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Korisnici/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idkorisnik,ime,prezime,pamtiLozinku,lozinka,email")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.korisnik.Add(korisnik);
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Index","Home");
            }

            return View(korisnik);
        }
        //login 
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Korisnik korisnik)
        {
            //single zeme jedan objekt koji zadovoljava uvjet
           try
           {
                var kor = db.korisnik.SingleOrDefault(m => m.email == korisnik.email && m.lozinka == korisnik.lozinka); 
                if (kor != null)
                {
                    
                    Session["idkorisnik"] = kor.idkorisnik.ToString();
                    Session["ime"] = kor.ime.ToString();
                    Session["id"] = kor.idkorisnik.ToString();
                try
                {
                    Session["uloga"] = kor.uloga.ToString();
                }
                catch { }
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError(" ", "Kriva lozinka ili email");
                }
                return View();
            }

            catch (System.IO.IOException e)
            {
               Console.WriteLine("Error : {0}", e.Message);
                return View();
            }

        }
        [HttpPost]
        public ActionResult Logoff(Korisnik korisnik)
        {
            Session["idkorisnik"] = null;
            Session["ime"] = null;
            Session["uloga"] = null;
            Session["id"] = null;
            return RedirectToAction("Index","Home");
        }
        public ActionResult LoggedIn()
        {
            if (Session["idkorisnik"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


        // GET: Korisnici/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.korisnik.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // POST: Korisnici/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idkorisnik,ime,prezime,pamtiLozinku,lozinka,email")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(korisnik);
        }

        // GET: Korisnici/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.korisnik.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // POST: Korisnici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Korisnik korisnik = db.korisnik.Find(id);
            db.korisnik.Remove(korisnik);
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
