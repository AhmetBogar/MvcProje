using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author

        BlogManager blockmanager= new BlogManager();
        AuthorManager authormanager= new AuthorManager();


        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authorDetail=blockmanager.GetBlogByID(id);
            return PartialView(authorDetail);
        }

        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogauthorid=blockmanager.GetAll().Where(x=>x.BlogID==id).Select(y=>y.AuthorID).FirstOrDefault();

            var authorblogs = blockmanager.GetBlogByAuthor(blogauthorid);
            return PartialView(authorblogs);
        }
        public ActionResult AuthorList()
        {
            var authorlists=authormanager.GetAll();
            return View(authorlists);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
            authormanager.AddAuthorBL(p);
            return RedirectToAction("AuthorList");
        }

        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author=authormanager.FindAuthor(id);
            return View(author);
        }

        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
            authormanager.EditAuthor(p);
            return RedirectToAction("AuthorList");
        }
    }
}