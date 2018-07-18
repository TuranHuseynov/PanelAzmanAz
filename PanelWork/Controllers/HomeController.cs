using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using PanelWork.Models;
using PanelWork.ViewModel;

namespace PanelWork.Controllers
{
    public class HomeController : Controller
    {
        DB_A3E145_azmanazEntities db = new DB_A3E145_azmanazEntities();
        Mymodel vm = new Mymodel();


        public ActionResult Index()
        {
            vm._sifarisler = db.Sifaris.ToList();
            vm._sifarisler = (from s in db.Sifaris
                              orderby s.sifaris_id descending
                              select s).ToList();

            vm._mehsul = db.Mehsuls.ToList();
            return View(vm);
        }


        [HttpGet]
        public ActionResult ViewSifaris()
        {

            vm._sifarisler = db.Sifaris.ToList();
            vm._mehsul = db.Mehsuls.ToList();

            return View(vm);

        }

        public ActionResult Join(int? Id)
        {

            var qosulan = Convert.ToInt32(Session["id"]);

            Sifari sifr = db.Sifaris.Find(Id);
            sifr.sifaris_goturen_id = qosulan;
            db.SaveChanges();



            return View("Index");
        }




        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.data = db.Sifaris.Find(id);


            return View();
        }


        [HttpPost]
        public ActionResult Edit(int id, string unvan, string telefon)
        {
            Sifari sfr = db.Sifaris.Find(id);
            sfr.sifaris_mehsul_adi = unvan;
            sfr.sifarisci_telefon = telefon;



            db.SaveChanges();






            return Redirect("/Home/Index");

        }

        public ActionResult Exported()
        {

            vm._sifarisler = db.Sifaris.ToList();




            return new ActionAsPdf("Index")
            {
                FileName = Server.MapPath("~/Export/list.pdf")
            };

        }
    }
}