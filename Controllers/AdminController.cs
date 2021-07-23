using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_MVC_CV_Prj.Models.Entity;
using ASP_MVC_CV_Prj.Repositories;

namespace ASP_MVC_CV_Prj.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        // GET: Certificates
        AdminRep repo = new AdminRep();
        public ActionResult Index()
        {
            var dd = repo.List();
            return View(dd);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            Admin t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetAdmin(int id)
        {
            Admin t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult GetAdmin(Admin p)
        {
            Admin t = repo.Find(x => x.ID == p.ID);
            t.ID = p.ID;
            t.UserName = p.UserName;
            t.Password = p.Password;

            repo.TUpdate(t);

            return RedirectToAction("Index");
        }
    }
}