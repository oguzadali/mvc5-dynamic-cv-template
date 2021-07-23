using ASP_MVC_CV_Prj.Models.Entity;
using ASP_MVC_CV_Prj.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_MVC_CV_Prj.Controllers
{


    public class EducationController : Controller
    {
        GenericRepository<Education> repo = new GenericRepository<Education>();
        // GET: Education
        public ActionResult Index()
        {
            var educations = repo.List();
            return View(educations);
        }

        [HttpGet]
        public ActionResult AddEdu()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddEdu(Education p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEdu(int id)
        {
            var skill = repo.Find(x => x.ID == id);

            repo.TDelete(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetEdu(int id)
        {
            Education t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult GetEdu(Education p)
        {
            Education t = repo.Find(x => x.ID == p.ID);
           
            t.Header = p.Header;
            t.SubHeader1= p.SubHeader1;
            t.SubHeader2 = p.SubHeader2;
            t.Date=p.Date;
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }





    }
}