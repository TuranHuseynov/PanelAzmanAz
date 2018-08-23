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

        //YENILER
        public ActionResult Index()
        {
            var sifaris = db.Sifaris.Include(s => s.Istifadeci).Include(s => s.Mehsul).Include(s => s.SifarisNovu);
            return View(sifaris.Where(s=>s.sifaris_novu_id==9 || s.sifaris_erteleme_tarix == DateTime.Now).ToList());
        }
        [HttpPost]
        public ActionResult IndexDelete(FormCollection formcol)
        {
            string[] ids = formcol["productId"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var product = this.db.Sifaris.Find(int.Parse(id));
                this.db.Sifaris.Remove(product);
                this.db.SaveChanges();
            }

            return Content("Silindi");
        }


        //ŞİKAYƏY OLUNAN

        public ActionResult IndexErr()
        {
            var sifaris = db.Sifaris.Include(s => s.Istifadeci).Include(s => s.Mehsul).Include(s => s.SifarisNovu);
            return View(sifaris.Where(s => s.sifaris_novu_id == 2).ToList());
        }

        [HttpPost]
        public ActionResult IndexErrDelete(FormCollection formcol)
        {
            string[] ids = formcol["productId"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var product = this.db.Sifaris.Find(int.Parse(id));
                this.db.Sifaris.Remove(product);
                this.db.SaveChanges();
            }

            return RedirectToAction("IndexErr");
        }











        //TƏCİLİ

        public ActionResult IndexTecili()
        {
            var sifaris = db.Sifaris.Include(s => s.Istifadeci).Include(s => s.Mehsul).Include(s => s.SifarisNovu);
            return View(sifaris.Where(s => s.sifaris_novu_id == 8).ToList());
        }

        [HttpPost]
        public ActionResult IndexTeciliDelete(FormCollection formcol)
        {
            string[] ids = formcol["productId"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var product = this.db.Sifaris.Find(int.Parse(id));
                this.db.Sifaris.Remove(product);
                this.db.SaveChanges();
            }

            return RedirectToAction("IndexTecili");
        }





        //CAVAB VERILMEYEN


        public ActionResult IndexCavabverilmeyen()
        {
            var sifaris = db.Sifaris.Include(s => s.Istifadeci).Include(s => s.Mehsul).Include(s => s.SifarisNovu);
            return View(sifaris.Where(s => s.sifaris_novu_id == 10).ToList());

        }
        [HttpPost]
        public ActionResult IndexCavabverilmeyenDelete(FormCollection formcol)
        {
            string[] ids = formcol["productId"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var product = this.db.Sifaris.Find(int.Parse(id));
                this.db.Sifaris.Remove(product);
                this.db.SaveChanges();
            }

            return RedirectToAction("IndexCavabverilmeyen");

        }



        //İMTİNA EDİLƏN
        public ActionResult IndexImtina()
        {
           
            var sifaris = db.Sifaris.Include(s => s.Istifadeci).Include(s => s.Mehsul).Include(s => s.SifarisNovu);
            return View(sifaris.Where(s => s.sifaris_novu_id == 1).ToList());

        }

        [HttpPost]
        public ActionResult IndexImtinaDelete(FormCollection formcol)
        {
            string[] ids = formcol["productId"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var product = this.db.Sifaris.Find(int.Parse(id));
                this.db.Sifaris.Remove(product);
                this.db.SaveChanges();
            }

            return RedirectToAction("IndexImtina");
        }



        //SONRAYA SAXLANILAN

        public ActionResult IndexSonraya()
        {
            var sifaris = db.Sifaris.Include(s => s.Istifadeci).Include(s => s.Mehsul).Include(s => s.SifarisNovu);

            return View(sifaris.Where(s => s.sifaris_novu_id == 3).ToList());

        }

        [HttpPost]
        public ActionResult IndexSonrayaDelete(FormCollection formcol)
        {
            string[] ids = formcol["productId"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var product = this.db.Sifaris.Find(int.Parse(id));
                this.db.Sifaris.Remove(product);
                this.db.SaveChanges();
            }
            return RedirectToAction("IndexSonraya");
        }





        //FAKE

        public ActionResult IndexFake()
        {
            var sifaris = db.Sifaris.Include(s => s.Istifadeci).Include(s => s.Mehsul).Include(s => s.SifarisNovu);
            return View(sifaris.Where(s => s.sifaris_novu_id == 5).ToList());

        }

        [HttpPost]
        public ActionResult IndexFakeDelete(FormCollection formcol)
        {
            string[] ids = formcol["productId"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var product = this.db.Sifaris.Find(int.Parse(id));
                this.db.Sifaris.Remove(product);
                this.db.SaveChanges();
            }


            return RedirectToAction("IndexFake");

        }


        //TƏSTİQ
        public ActionResult IndexTestiq()
        {
            var sifaris = db.Sifaris.Include(s => s.Istifadeci).Include(s => s.Mehsul).Include(s => s.SifarisNovu);
            return View(sifaris.Where(s => s.sifaris_novu_id == 4).ToList());

            

        }

        [HttpPost]
        public ActionResult IndexTestiqDelete(FormCollection formcol)
        {
            string[] ids = formcol["productId"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var product = this.db.Sifaris.Find(int.Parse(id));
                this.db.Sifaris.Remove(product);
                this.db.SaveChanges();
            }

            return RedirectToAction("IndexTestiq");



        }




        //TEKRAR

        public ActionResult IndexTekrar()
        {
            
            var sifaris = db.Sifaris.Include(s => s.Istifadeci).Include(s => s.Mehsul).Include(s => s.SifarisNovu);
            return View(sifaris.Where(s => s.sifaris_novu_id == 6).ToList());

        }

        [HttpPost]
        public ActionResult IndexTekrarDelete(FormCollection formcol)
        {
            string[] ids = formcol["productId"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var product = this.db.Sifaris.Find(int.Parse(id));
                this.db.Sifaris.Remove(product);
                this.db.SaveChanges();
            }

            return RedirectToAction("IndexTekrar");

        }




        //SiLiNəN

        public ActionResult IndexSilinen()
        {
            var sifaris = db.Sifaris.Include(s => s.Istifadeci).Include(s => s.Mehsul).Include(s => s.SifarisNovu);
            return View(sifaris.Where(s => s.sifaris_novu_id == 7).ToList());

        }

        [HttpPost]
        public ActionResult IndexSilinenDelete(FormCollection formcol)
        {
            string[] ids = formcol["productId"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var product = this.db.Sifaris.Find(int.Parse(id));
                this.db.Sifaris.Remove(product);
                this.db.SaveChanges();
            }

            return RedirectToAction("IndexSilinen");

        }









        // GET: Sifarisler/Details/
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
        public ActionResult Create([Bind(Include = "sifaris_id,sifarisci_ad_soyad,sifarisci_telefon,sifarisci_mehsulun_id,sifarisci_unvani,sifaris_tarixi,sifaris_sayi,sifaris_novu_id,sifaris_erteleme_tarix,sifaris_goturen_id,sifaris_mehsul_adi,sifaris_qeyd")] Sifari sifari)
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
        public ActionResult Edit([Bind(Include = "sifaris_id,sifarisci_ad_soyad,sifarisci_telefon,sifarisci_mehsulun_id,sifarisci_unvani,sifaris_tarixi,sifaris_sayi,sifaris_novu_id,sifaris_erteleme_tarix,sifaris_goturen_id,sifaris_mehsul_adi,sifaris_qeyd")] Sifari sifari)
        {
            if (ModelState.IsValid)
            {
                var tarix = DateTime.Now;
                sifari.sifaris_tarixi = tarix;
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
