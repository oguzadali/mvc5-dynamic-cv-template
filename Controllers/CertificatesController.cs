using ASP_MVC_CV_Prj.Models.Entity;
using ASP_MVC_CV_Prj.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_MVC_CV_Prj.Controllers
{
    public class CertificatesController : Controller
    {
      
        // GET: Certificates
        CertificateRep repo = new CertificateRep();
        public ActionResult Index()
        {
            var dd = repo.List();
            return View(dd);
        }

        [HttpGet]
        public ActionResult AddCert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCert(Certificates p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCert(int id)
        {
            Certificates t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetCert(int id)
        {
            Certificates t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult GetCert(Certificates p)
        {
            Certificates t = repo.Find(x => x.ID == p.ID);
            t.Certificate = p.Certificate;
            t.Details = p.Details;
           
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }

    }
}