using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_MVC_CV_Prj.Models.Entity;
using ASP_MVC_CV_Prj.Repositories;

namespace ASP_MVC_CV_Prj.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill


        GenericRepository<Abilities> repo = new GenericRepository<Abilities>();

        public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        } 
        
        [HttpGet]
        public ActionResult AddSkill()
        {
            
            return View();
        } 
        [HttpPost]
        public ActionResult AddSkill(Abilities p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
         public ActionResult DeleteSkill(int id)
        {
            var skill = repo.Find(x => x.ID == id);

            repo.TDelete(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetSkill(int id)
        {
            Abilities t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult GetSkill(Abilities p)
        {
            Abilities t = repo.Find(x => x.ID == p.ID);
            t.Ability = p.Ability;
            t.Progress = p.Progress;
          
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }



    }
}