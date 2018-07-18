using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PanelWork.Models;

namespace PanelWork.Controllers
{
    [FilterUserController]
    public class SifarislerController : Controller
    {
        private DB_A3E145_azmanazEntities db = new DB_A3E145_azmanazEntities();

        // GET: Sifarisler
        public ActionResult Index()
        {
            var sifaris = db.Sifaris.Include(s => s.Istifadeci).Include(s => s.Mehsul).Include(s => s.SifarisNovu);
            return View(sifaris.ToList());
        }

        // GET: Sifarisler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sifari sifari = db.Sifaris.Find(id);
            if (sifari == null)
            {
                return HttpNotFound();
            }
            return View(sifari);
        }

        // GET: Sifarisler/Create
        public ActionResult Create()
        {
            ViewBag.sifaris_goturen_id = new SelectList(db.Istifadecis, "user_id", "user_name");
            ViewBag.sifarisci_mehsulun_id = new SelectList(db.Mehsuls, "mehsul_id", "mehsulun_adi");
            ViewBag.sifaris_novu_id = new SelectList(db.SifarisNovus, "sifaris_type_id", "sifaris_type");
            return View();
        }

        // POST: Sifarisler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sifaris_id,sifarisci_ad_soyad,sifarisci_telefon,sifarisci_mehsulun_id,sifarisci_unvani,sifaris_tarixi,sifaris_sayi,sifaris_novu_id,sifaris_erteleme_tarix,sifaris_goturen_id,sifaris_mehsul_adi")] Sifari sifari)
        {
            if (ModelState.IsValid)
            {
                var tarix = DateTime.Now;
                sifari.sifaris_tarixi = tarix;
                db.Sifaris.Add(sifari);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sifaris_goturen_id = new SelectList(db.Istifadecis, "user_id", "user_name", sifari.sifaris_goturen_id);
            ViewBag.sifarisci_mehsulun_id = new SelectList(db.Mehsuls, "mehsul_id", "mehsulun_adi", sifari.sifarisci_mehsulun_id);
            ViewBag.sifaris_novu_id = new SelectList(db.SifarisNovus, "sifaris_type_id", "sifaris_type", sifari.sifaris_novu_id);
            return View(sifari);
        }

        // GET: Sifarisler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sifari sifari = db.Sifaris.Find(id);
            if (sifari == null)
            {
                return HttpNotFound();
            }
            ViewBag.sifaris_goturen_id = new SelectList(db.Istifadecis, "user_id", "user_name", sifari.sifaris_goturen_id);
            ViewBag.sifarisci_mehsulun_id = new SelectList(db.Mehsuls, "mehsul_id", "mehsulun_adi", sifari.sifarisci_mehsulun_id);
            ViewBag.sifaris_novu_id = new SelectList(db.SifarisNovus, "sifaris_type_id", "sifaris_type", sifari.sifaris_novu_id);
            return View(sifari);
        }

        // POST: Sifarisler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sifaris_id,sifarisci_ad_soyad,sifarisci_telefon,sifarisci_mehsulun_id,sifarisci_unvani,sifaris_tarixi,sifaris_sayi,sifaris_novu_id,sifaris_erteleme_tarix,sifaris_goturen_id,sifaris_mehsul_adi")] Sifari sifari)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sifari).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sifaris_goturen_id = new SelectList(db.Istifadecis, "user_id", "user_name", sifari.sifaris_goturen_id);
            ViewBag.sifarisci_mehsulun_id = new SelectList(db.Mehsuls, "mehsul_id", "mehsulun_adi", sifari.sifarisci_mehsulun_id);
            ViewBag.sifaris_novu_id = new SelectList(db.SifarisNovus, "sifaris_type_id", "sifaris_type", sifari.sifaris_novu_id);
            return View(sifari);
        }

        // GET: Sifarisler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sifari sifari = db.Sifaris.Find(id);
            if (sifari == null)
            {
                return HttpNotFound();
            }
            return View(sifari);
        }

        // POST: Sifarisler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sifari sifari = db.Sifaris.Find(id);
            db.Sifaris.Remove(sifari);
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
