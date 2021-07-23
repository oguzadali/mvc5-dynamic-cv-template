using ASP_MVC_CV_Prj.Models.Entity;
using ASP_MVC_CV_Prj.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_MVC_CV_Prj.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactRep repo = new ContactRep();
        public ActionResult Index()
        {
            var dd = repo.List();
            return View(dd);
        }

        public ActionResult DeleteMessage(int id)
        {
            Contact t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
    }
}