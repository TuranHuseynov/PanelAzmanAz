using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PanelWork.Models;
using PanelWork.ViewModel;

namespace PanelWork.Controllers
{

    [FilterUserController]
    public class ProfileController : Controller
    {
        DB_A3E145_azmanazEntities db = new DB_A3E145_azmanazEntities();
        Mymodel vm = new Mymodel();
        // GET: Profile
        public ActionResult Index()
        {
            int a = Convert.ToInt32(Session["id"]);
            vm._sifarisler = db.Sifaris.Where(t => t.sifaris_id == a).ToList();
            vm._istifadeciler = db.Istifadecis.Where(i => i.user_id == a).ToList();

            return View(vm);
        }
    }
}