using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PanelWork.Models;

namespace PanelWork.Controllers
{
    [FilterUserController]
    public class IstifadecilerController : Controller
    {
        private DB_A3E145_azmanazEntities db = new DB_A3E145_azmanazEntities();

        // GET: Istifadeciler
        public ActionResult Index()
        {
            var istifadecis = db.Istifadecis.Include(i => i.Rol);
            return View(istifadecis.ToList());
        }

        // GET: Istifadeciler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Istifadeci istifadeci = db.Istifadecis.Find(id);
            if (istifadeci == null)
            {
                return HttpNotFound();
            }
            return View(istifadeci);
        }

        // GET: Istifadeciler/Create
        public ActionResult Create()
        {
            ViewBag.user_rol_type = new SelectList(db.Rols, "rol_id", "rol_name");
            return View();
        }

        // POST: Istifadeciler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,user_name,user_surname,user_password,user_salary,user_job_begin,user_email,user_rol_type")] Istifadeci istifadeci, HttpPostedFileBase user_img)
        {
            if (ModelState.IsValid)
            {
                if (Path.GetExtension(user_img.FileName) == ".jpg" || Path.GetExtension(user_img.FileName) == ".jpeg")
                {
                    var file_name = Path.GetFileName(user_img.FileName);
                    var src = Path.Combine(Server.MapPath("/MyUpload"), file_name);
                    user_img.SaveAs(src);
                }
                istifadeci.user_img = Path.GetFileName(user_img.FileName);
                db.Istifadecis.Add(istifadeci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_rol_type = new SelectList(db.Rols, "rol_id", "rol_name", istifadeci.user_rol_type);
            return View(istifadeci);
        }

        // GET: Istifadeciler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Istifadeci istifadeci = db.Istifadecis.Find(id);
            if (istifadeci == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_rol_type = new SelectList(db.Rols, "rol_id", "rol_name", istifadeci.user_rol_type);
            return View(istifadeci);
        }

        // POST: Istifadeciler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,user_name,user_surname,user_password,user_img,user_salary,user_job_begin,user_email,user_rol_type")] Istifadeci istifadeci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(istifadeci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_rol_type = new SelectList(db.Rols, "rol_id", "rol_name", istifadeci.user_rol_type);
            return View(istifadeci);
        }

        // GET: Istifadeciler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Istifadeci istifadeci = db.Istifadecis.Find(id);
            if (istifadeci == null)
            {
                return HttpNotFound();
            }
            return View(istifadeci);
        }

        // POST: Istifadeciler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Istifadeci istifadeci = db.Istifadecis.Find(id);
            db.Istifadecis.Remove(istifadeci);
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
