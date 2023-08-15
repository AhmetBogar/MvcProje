using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager abm = new AboutManager();
        public ActionResult Index()
        {
            var aboutcontent = abm.GetAll();
            return View(aboutcontent);
        }
        public PartialViewResult Footer()
        {

            var aboutContentList=abm.GetAll();
            return PartialView(aboutContentList);
        }
        public PartialViewResult MeetTheTeam()
        {
            AuthorManager autman= new AuthorManager();
            var authorList=autman.GetAll();
            return PartialView(authorList);
        }
        public ActionResult UpdateAboutList()
        {
            var aboutlist=abm.GetAll();
            return View(aboutlist);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            abm.UpdateAboutBM(p);
            return RedirectToAction("UpdateAboutList");
        }
    }
}