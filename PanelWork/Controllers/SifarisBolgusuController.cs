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
   
    public class SifarisBolgusuController : Controller
    {
        DB_A3E145_azmanazEntities db = new DB_A3E145_azmanazEntities();
        Mymodel vm = new Mymodel();

      [HttpGet]
        public ActionResult IndexErr()
        {
            vm._sifarisler = db.Sifaris.Where(s => s.sifaris_novu_id == 2).ToList();
           


            return View(vm);
           
        }

        [HttpGet]
        public ActionResult IndexCavabVer()
        {

            vm._sifarisler = db.Sifaris.Where(s => s.sifaris_novu_id == 10).ToList();
            
            return View(vm);

        }


        [HttpGet]
        public ActionResult Indexİmt()
        {
            vm._sifarisler = db.Sifaris.Where(s => s.sifaris_novu_id == 1).ToList();
           
            return View(vm);

        }


        [HttpGet]
        public ActionResult IndexErtele()
        {
            vm._sifarisler = db.Sifaris.Where(s => s.sifaris_novu_id == 3).ToList();
           

            return View(vm);

        }

        [HttpGet]
        public ActionResult IndexTestiq()
        {
            vm._sifarisler = db.Sifaris.Where(s => s.sifaris_novu_id == 4).ToList();
          
            return View(vm);

        }

        [HttpGet]
        public ActionResult IndexFake()
        {
            vm._sifarisler = db.Sifaris.Where(s => s.sifaris_novu_id == 5).ToList();
          

            return View(vm);

        }

        [HttpGet]
        public ActionResult IndexTekrar()
        {
            vm._sifarisler = db.Sifaris.Where(s => s.sifaris_novu_id == 6).ToList();
           

            return View(vm);

        }

        [HttpGet]
        public ActionResult IndexSilindi()
        {
            vm._sifarisler = db.Sifaris.Where(s => s.sifaris_novu_id == 7).ToList();
           
            return View(vm);

        }



        [HttpGet]
        public ActionResult IndexTecili()
        {
            vm._sifarisler = db.Sifaris.Where(s => s.sifaris_novu_id == 8).ToList();
           
            return View(vm);

        }


        [HttpGet]
        public ActionResult IndexYeni()
        {
            vm._sifarisler = db.Sifaris.Where(s => s.sifaris_novu_id == 9).ToList();
            vm._sifarisler = (from s in db.Sifaris
                              orderby s.sifaris_id descending
                              select s).ToList();

            return View(vm);

        }



        public ActionResult Exprt()
        {
            vm._sifarisler = db.Sifaris.Where(s => s.sifaris_novu_id == 4).ToList();




            return new ActionAsPdf("IndexTestiq")
            {
                FileName = Server.MapPath("~/Export/testiqlenenlist.pdf")
            };

        }

    }
}