using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_MVC_CV_Prj.Models.Entity;
using ASP_MVC_CV_Prj.Repositories;

namespace ASP_MVC_CV_Prj.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        SocialMediaRep repo = new SocialMediaRep();
        public ActionResult Index()
        {
            var dd = repo.List();
            return View(dd);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(SocialMediaLinks p)
        {           
            repo.TAdd(p);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult GetSocial(int id)
        {
            SocialMediaLinks t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult GetSocial(SocialMediaLinks p)
        {
            SocialMediaLinks t = repo.Find(x => x.ID == p.ID);
            t.Name = p.Name;
            t.Link = p.Link;
            t.Show = p.Show;
            t.Icon= p.Icon;
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }
    }
}