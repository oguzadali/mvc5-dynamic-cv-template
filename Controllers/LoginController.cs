using ASP_MVC_CV_Prj.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ASP_MVC_CV_Prj.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            ASPCVProjectEntities1 db = new ASPCVProjectEntities1();
            var dt = db.Admin.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (dt != null)
            {
                FormsAuthentication.SetAuthCookie(dt.UserName, false);
                Session["Username"] = dt.UserName.ToString();
                return RedirectToAction("Index", "About");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            //return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}