using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_MVC_CV_Prj.Models.Entity;
using ASP_MVC_CV_Prj.Repositories;

namespace ASP_MVC_CV_Prj.Controllers
{
    public class ToolController : Controller
    {

        GenericRepository<Tools> repo = new GenericRepository<Tools>();

        public ActionResult Index()
        {
            var tools = repo.List();
            return View(tools);
        }

        [HttpGet]
        public ActionResult AddTool()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddTool(Tools p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTool(int id)
        {
            var skill = repo.Find(x => x.ID == id);

            repo.TDelete(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetTool(int id)
        {
            Tools t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult GetTool(Tools p)
        {
            Tools t = repo.Find(x => x.ID == p.ID);
            t.Details = p.Details;
            t.Star = p.Star;
          

            repo.TUpdate(t);

            return RedirectToAction("Index");
        }

    }
}