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
    public class MehsullarController : Controller
    {
        private DB_A3E145_azmanazEntities db = new DB_A3E145_azmanazEntities();

        // GET: Mehsullar
        public ActionResult Index()
        {
            return View(db.Mehsuls.ToList());
        }

        // GET: Mehsullar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mehsul mehsul = db.Mehsuls.Find(id);
            if (mehsul == null)
            {
                return HttpNotFound();
            }
            return View(mehsul);
        }

        // GET: Mehsullar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mehsullar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mehsul_id,mehsulun_adi,mehsulun_linki,mehsul_qiymeti")] Mehsul mehsul, HttpPostedFileBase mehsulun_sekli)
        {
            if (ModelState.IsValid)
            {

                if (Path.GetExtension(mehsulun_sekli.FileName) == ".jpg" || Path.GetExtension(mehsulun_sekli.FileName) == ".jpeg" || Path.GetExtension(mehsulun_sekli.FileName) == ".png")
                {
                    var file_name = Path.GetFileName(mehsulun_sekli.FileName);
                    var src = Path.Combine(Server.MapPath("/MyUpload"), file_name);
                    mehsulun_sekli.SaveAs(src);
                }
                mehsul.mehsulun_sekli = Path.GetFileName(mehsulun_sekli.FileName);
                db.Mehsuls.Add(mehsul);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mehsul);
        }

        // GET: Mehsullar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mehsul mehsul = db.Mehsuls.Find(id);
            if (mehsul == null)
            {
                return HttpNotFound();
            }
            return View(mehsul);
        }

        // POST: Mehsullar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mehsul_id,mehsulun_adi,mehsulun_linki,mehsulun_sekli,mehsul_qiymeti")] Mehsul mehsul)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mehsul).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mehsul);
        }

        // GET: Mehsullar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mehsul mehsul = db.Mehsuls.Find(id);
            if (mehsul == null)
            {
                return HttpNotFound();
            }
            return View(mehsul);
        }

        // POST: Mehsullar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mehsul mehsul = db.Mehsuls.Find(id);
            db.Mehsuls.Remove(mehsul);
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
