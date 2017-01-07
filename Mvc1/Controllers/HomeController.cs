using Mvc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace Mvc1.Controllers
{
    public class HomeController : Controller
    {
        private Mvc1Context db = new Mvc1Context();


        [Authorize]
        public ActionResult Index()
        {
            var articles = db.Articles.Include(с => с.Category).Include(с => с.UserProfile);
            //ViewBag.Title = "Полный список статей";

            return View(articles.ToList());
        }

        [HttpGet]
        public ActionResult Publication()
        {
            ViewBag.Categories = db.Categories.ToList<Category>();
            ViewBag.UserProfile = db.UserProfile.ToList<UserProfile>();
            return View();
        }

        [HttpPost]
        public ActionResult Publication(Article article)
        {
            Category category = db.Categories.Find(article.CategoryId);
            UserProfile UserProfile = db.UserProfile.Find(article.UserId);

            article.Date = DateTime.Now;
            article.Category = category;
            article.UserProfile = UserProfile;

            db.Articles.Add(article);
            db.SaveChanges();

            return View("Thank");
        }

        public ActionResult Cardiology()
        {
            var articles = db.Articles.Include(p => p.UserProfile).Where(p => (p.CategoryId == 1));
            ViewBag.Title = "Кардиология";


            return View("Index", articles.ToList());
        }

        public ActionResult Surgery()
        {
            var articles = db.Articles.Include(p => p.UserProfile).Where(p => (p.CategoryId == 2));
            ViewBag.Title = "Хирургия";


            return View("Index", articles.ToList());
        }

        public ActionResult Dermatology()
        {
            var articles = db.Articles.Include(p => p.UserProfile).Where(p => (p.CategoryId == 5));
            ViewBag.Title = "Дерматология";


            return View("Index", articles.ToList());
        }

        public ActionResult Stomatology()
        {
            var articles = db.Articles.Include(p => p.UserProfile).Where(p => (p.CategoryId == 4));
            ViewBag.Title = "Стоматология";


            return View("Index", articles.ToList());
        }

        public ActionResult Comment(Article article)
        {
            ViewBag.UserProfile = db.UserProfile.ToList<UserProfile>();
            Comment comment = db.Comments.Find(article.Id);
            var id = article.Id;
            var comments= db.Comments.Where(p => (p.ArticleId == id));
            return View(comments.ToList());
        }

        [HttpGet]
        public ActionResult CreateComment()
        {
            
          
            return View();
        }

        [HttpPost]
        public ActionResult CreateComment(Comment comment)
        {

          
            comment.Date = DateTime.Now;
            //UserProfile UserProfile = db.UserProfile.Find(comment.UserId);
            //comment.UserProfile = UserProfile;
            db.Comments.Add(comment);
            db.SaveChanges();

            return View("CommentAdd");
        }


       




    }
}
