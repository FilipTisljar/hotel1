using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel_mvc1.Models;
using System.Data.SqlClient;
using System.Windows;

namespace Hotel_mvc1.Controllers
{
   
    public class RezervacijeController : Controller
    {
        private hotelBazaContext db = new hotelBazaContext();

        // GET: Rezervacije
        public ActionResult Index()
        {
            
            Session["MaxIDSoba"]= db.soba.Count();
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
        public ActionResult Slobodni()
        {
            return View();
        }
        public ActionResult SlobodneSobe()
        {
            return View();
        }

        public ActionResult JeRezervirano(int idSoba, DateTime rezervacijaOd, DateTime rezervacijaDo)
        {
            string obavijest = "<p style='color: green;'><strong>Rezervacija slobodna.</strong></p>";
            List<Rezervacija> rezervacije = db.rezervacija.ToList();
            List<Soba> sobe = db.soba.ToList();
            Soba so = sobe.Find(x => x.idsoba == idSoba);
            int id = so.idsoba;

            foreach (Rezervacija rez in rezervacije)
            {
                //  
                if (rez.id_soba == id)
                {
                    if ((rez.rezerviranoDo < rezervacijaOd && rez.rezerviranoDo < rezervacijaDo) ||
                        (rez.rezerviranoOd > rezervacijaDo && rez.rezerviranoOd > rezervacijaOd))
                    {
                        continue;
                    }
                    else
                    {
                        obavijest = "<p style='color: red;'><strong>Rezervacija već postoji!</strong></p>";
                        break;
                    }
                }
                continue;
            }

            if (obavijest.Contains("slobodna"))
            {
                TimeSpan rasponRezervacije = (rezervacijaDo - rezervacijaOd);
                double brojdana = rasponRezervacije.TotalDays;
                

                Soba s = sobe.Find(x => x.idsoba == idSoba);

                if (s != null)
                {
                    double cijena = brojdana * s.cijenaSobe;

                    obavijest += "<br><p style='color: green;'>Cijena rezervacije: " + cijena.ToString() + " kn</p>";
                }
                else
                {
                    obavijest = "<br><p style='color: red'>Soba pod odabranim brojem ne postoji!</p>";
                }
            }

            return Json(obavijest, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Slobodni([Bind(Include = "rezerviranoOd,rezerviranoDo")] Rezervacija rezervacija)
        {

            Session["rezOd"] = rezervacija.rezerviranoOd.ToString();
            Session["rezDo"] = rezervacija.rezerviranoDo.ToString();

            List<Rezervacija> rezervacije = new List<Rezervacija>();
            List<Soba> sl_sobe = new List<Soba>();
            sl_sobe = db.soba.ToList();
            rezervacije = db.rezervacija.ToList();
            foreach(Rezervacija a in rezervacije)
            {
               
                if ((rezervacija.rezerviranoOd < a.rezerviranoOd && rezervacija.rezerviranoDo < a.rezerviranoOd) ||
                    (rezervacija.rezerviranoOd > a.rezerviranoDo && rezervacija.rezerviranoDo > a.rezerviranoDo))   //&& rezervacija.rezerviranoDo < a.rezerviranoOd?
                {
                      
                }
                else
                {    banana:
                    foreach(Soba b in sl_sobe)
                    {
                        if (b.idsoba == a.id_soba)
                        {
                            sl_sobe.RemoveAt(sl_sobe.IndexOf(b));
                            goto banana; 
                        }
                    }
                //sl_sobe.RemoveAt(a.id_soba);
                //sl_sobe.IndexOf(); 
                    
                }  
            }
            return View("SlobodneSobe",sl_sobe);
        }

           
        
        // GET: Rezervacije/Create
        public ActionResult Create(int? id)
        {
            if (id != null)
            {
                Session["sobaID"] = id;
                return View();
            }
            else
            return View();
        }

        // POST: Rezervacije/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idrezervacija,id_korisnik,id_soba,rezerviranoOd,rezerviranoDo")] Rezervacija rezervacija)
        {
           DateTime d1= rezervacija.rezerviranoOd;
            DateTime d2=rezervacija.rezerviranoDo;
            
            TimeSpan d3 =(d2 - d1);
            double brojdana = d3.TotalDays;
            List<Soba> sobe = new List<Soba>();
            sobe = db.soba.ToList();
            Soba s = sobe.Find(x => x.idsoba == rezervacija.id_soba);
            double cijena = brojdana * s.cijenaSobe;
            rezervacija.cijena = cijena.ToString()+" kn";
            rezervacija.datumRezervacije = DateTime.Now;
            rezervacija.id_korisnik = Convert.ToInt32(Session["idkorisnik"]);
          //  
            List<Rezervacija> rezervacije = new List<Rezervacija>();
         //   List<DateTime> datumi = new List<DateTime>();
            rezervacije = db.rezervacija.ToList();
           // 
           // 
          //  rezervacija.cijena=a.cijenaSobe * Convert.ToInt32(vrijemeNocenja);
            bool vecRez = false;
            int check = 0;

            if (rezervacija.rezerviranoOd > rezervacija.rezerviranoDo)
                return View(rezervacija);
            if (rezervacija.rezerviranoOd < DateTime.Now || rezervacija.rezerviranoOd < DateTime.Now)
                return View(rezervacija);

            if (ModelState.IsValid)
            {
                //  var rezervirano = db.rezervacija.Where(r => r.id_soba == rezervacija.id_soba);//.Where(r => r.rezerviranoOd > rezervacija.rezerviranoDo)||.Where(r => r.rezerviranoDo < rezervacija.rezerviranoOd);


                foreach (Rezervacija a in rezervacije)
                {

                    if (rezervacija.id_soba == a.id_soba)
                    {
                            if ((rezervacija.rezerviranoOd < a.rezerviranoOd && rezervacija.rezerviranoDo < a.rezerviranoOd) ||
                                (rezervacija.rezerviranoOd > a.rezerviranoDo && rezervacija.rezerviranoDo > a.rezerviranoDo ))//&& rezervacija.rezerviranoDo < a.rezerviranoOd?
                        {
                                check++;
                            }
                            else
                            {
                                vecRez = true;
                                break;
                            }
                        }
                    }
                    if (vecRez == true)
                    {
                        return View(rezervacija);
                    }
                    else {
                        db.rezervacija.Add(rezervacija);
                        db.SaveChanges();
                    Session["sobaID"] = null;
                //??
                        return RedirectToAction("Index");
                    }
               // return View(rezervacija);
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
