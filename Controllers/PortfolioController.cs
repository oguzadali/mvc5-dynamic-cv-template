using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_MVC_CV_Prj.Models.Entity;
using ASP_MVC_CV_Prj.Repositories;

namespace ASP_MVC_CV_Prj.Controllers
{
    public class PortfolioController : Controller
    {
        GenericRepository<Portfolio> repo = new GenericRepository<Portfolio>();
        // GET: Portfolio
        public ActionResult Index()
        {
            var portfolio = repo.List();
            return View(portfolio);
        }

        [HttpGet]
        public ActionResult AddPortfolio()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddPortfolio(Portfolio p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeletePortfolio(int id)
        {
            var portfolio = repo.Find(x => x.ID == id);

            repo.TDelete(portfolio);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetPortfolio(int id)
        {
            Portfolio t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult GetPortfolio(Portfolio p)
        {
            Portfolio t = repo.Find(x => x.ID == p.ID);
            t.ProjectName = p.ProjectName;
            t.ProjectDetails = p.ProjectDetails;
            t.Properties = p.Properties;
            t.Image = p.Image;
            t.LiveVersion = p.LiveVersion;
            t.GithubLink = p.GithubLink;
            
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }

    }
}