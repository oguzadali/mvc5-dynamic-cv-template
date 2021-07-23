using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_MVC_CV_Prj.Models.Entity;
using ASP_MVC_CV_Prj.Repositories;

namespace ASP_MVC_CV_Prj.Controllers
{
    public class InterestController : Controller
    {
        InterestRep repo = new InterestRep();
        // GET: Interest
        public ActionResult Index()
        {
            var dd = repo.List();
            return View(dd);
        }
             
        [HttpGet]
        public ActionResult AddInterest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddInterest(Interests p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteInterest(int id)
        {
            Interests t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetInterest(int id)
        {
            Interests t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult GetInterest(Interests p)
        {
            Interests t = repo.Find(x => x.ID == p.ID);
            t.Hobby = p.Hobby;
            t.Icon = p.Icon;
           
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }



    }
}