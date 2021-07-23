
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_MVC_CV_Prj.Helpers;
using ASP_MVC_CV_Prj.Models.Entity;
using ASP_MVC_CV_Prj.Models.Skill;

namespace ASP_MVC_CV_Prj.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        ASPCVProjectEntities1 db = new ASPCVProjectEntities1();
       

        public ActionResult Index()
        {

            var about = db.About.ToList();

            return View(about);
        }

        public PartialViewResult Experience()
        {
            var experiences = db.Experiences.ToList();
            return PartialView(experiences);
        }

        public PartialViewResult Portfolio()
        {
            var portfolio = db.Portfolio.ToList();
            return PartialView(portfolio);
        }


        public PartialViewResult SocialMediaLink()
        {
            var socialMedia = db.SocialMediaLinks.ToList();
            return PartialView(socialMedia);
        }

        public PartialViewResult Skill()
        {                        
            var md = new ToolAndSkill
            {
                MAbilities = db.Abilities.ToList(),
                MTools = db.Tools.OrderByDescending(a => a.Star).ToList()
            };

            return PartialView(md);
        }

        public PartialViewResult Interest()
        {
            var interests = db.Interests.ToList();
            return PartialView(interests);
        }
        public PartialViewResult Certificates()
        {
            var certificates = db.Certificates.ToList();
            return PartialView(certificates);
        }
        public PartialViewResult Education()
        {
            var education = db.Education.ToList();
            return PartialView(education);
        }

        [HttpGet]
         public PartialViewResult Contact()
        {         
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateGoogleCaptcha]
        public PartialViewResult Contact(Contact t)
        {        
            
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Contact.Add(t);
            db.SaveChanges();
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateGoogleCaptcha]
        public ActionResult ContactF(Contact t)
        {

            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Contact.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}