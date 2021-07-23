using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_MVC_CV_Prj.Models.Entity;
using ASP_MVC_CV_Prj.Repositories;

namespace ASP_MVC_CV_Prj.Controllers
{
    //[Authorize]
    public class AboutController : Controller
    {
        // GET: About

        AboutRep repo = new AboutRep();

        [HttpGet]
        public ActionResult Index()
        {
            var dd = repo.List();
            return View(dd);           
        }

        [HttpPost]
        public ActionResult Index(About p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Name = p.Name;
            t.Surname = p.Surname;
            t.I_am_= p.I_am_;
            t.Adress= p.Adress;
            t.Phone= p.Phone;
            t.Mail = p.Mail;
            t.Text = p.Text;
            t.Image = p.Image;
                    
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }
    }
}