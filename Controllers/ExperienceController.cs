using ASP_MVC_CV_Prj.Models.Entity;
using ASP_MVC_CV_Prj.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_MVC_CV_Prj.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRep repo = new ExperienceRep();
        public ActionResult Index()
        {
            var dd = repo.List();
            return View(dd);
        }

        [HttpGet]
        public ActionResult AddExp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExp(Experiences p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExp(int id)
        {
            Experiences t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetExp(int id)
        {
            Experiences t = repo.Find(x => x.ID == id);            
            return View(t);
        }

           [HttpPost]
        public ActionResult GetExp(Experiences p)
        {
            Experiences t = repo.Find(x => x.ID  == p.ID);
            t.Header = p.Header;
            t.SubHeader = p.SubHeader;
            t.Date = p.Date;
            t.Text = p.Text;
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }




    }
}