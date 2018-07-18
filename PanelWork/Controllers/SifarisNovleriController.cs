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
    public class SifarisNovleriController : Controller
    {
        private DB_A3E145_azmanazEntities db = new DB_A3E145_azmanazEntities();

        // GET: SifarisNovleri
        public ActionResult Index()
        {
            return View(db.SifarisNovus.ToList());
        }

        // GET: SifarisNovleri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SifarisNovu sifarisNovu = db.SifarisNovus.Find(id);
            if (sifarisNovu == null)
            {
                return HttpNotFound();
            }
            return View(sifarisNovu);
        }

        // GET: SifarisNovleri/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SifarisNovleri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sifaris_type_id,sifaris_type")] SifarisNovu sifarisNovu)
        {
            if (ModelState.IsValid)
            {
                db.SifarisNovus.Add(sifarisNovu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sifarisNovu);
        }

        // GET: SifarisNovleri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SifarisNovu sifarisNovu = db.SifarisNovus.Find(id);
            if (sifarisNovu == null)
            {
                return HttpNotFound();
            }
            return View(sifarisNovu);
        }

        // POST: SifarisNovleri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sifaris_type_id,sifaris_type")] SifarisNovu sifarisNovu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sifarisNovu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sifarisNovu);
        }

        // GET: SifarisNovleri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SifarisNovu sifarisNovu = db.SifarisNovus.Find(id);
            if (sifarisNovu == null)
            {
                return HttpNotFound();
            }
            return View(sifarisNovu);
        }

        // POST: SifarisNovleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SifarisNovu sifarisNovu = db.SifarisNovus.Find(id);
            db.SifarisNovus.Remove(sifarisNovu);
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
