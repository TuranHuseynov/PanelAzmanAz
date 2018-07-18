using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PanelWork.Models;
using System.Web.Mvc;

namespace PanelWork.Controllers
{
    public class UserLoginController : Controller
    {
        DB_A3E145_azmanazEntities db = new DB_A3E145_azmanazEntities();
        public static Istifadeci loguser;
        // GET: UserLogin
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult UserLog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLog(Istifadeci usr)
        {
            loguser = db.Istifadecis.Where(e => e.user_email == usr.user_email).FirstOrDefault();
            Session["usr_password"] = usr.user_password;




            if (loguser != null)
            {
                if (loguser.user_password == usr.user_password)
                {
                    Session["usr_email"] = loguser.user_email;
                    Session["id"] = loguser.user_id.ToString();
                    Session["logined_img"] = loguser.user_img;
                    Session["user_name"] = loguser.user_name;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            else
            {
                return RedirectToAction("Index");
            }

        }


        public ActionResult Logout()
        {
            Session["id"] = null;
            return RedirectToAction("Index", "Home");
        }



    }
}