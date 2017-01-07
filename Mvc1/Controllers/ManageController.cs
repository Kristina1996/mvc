using Mvc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;

namespace Mvc1.Controllers
{
    public class ManageController : Controller
    {
        private Mvc1Context db = new Mvc1Context();
        //
        // GET: /Manage/

        [Authorize(Roles = "Manage")]
        public ActionResult Index()
        {
            var articles = db.Articles.Include(a => a.Category).Include(a => a.UserProfile);
            return View(articles.ToList());

        }

        public ActionResult Edit(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", article.CategoryId);
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName", article.UserId);
            return View(article);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", article.CategoryId);
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName", article.UserId);

            return View(article);
        }


        public ActionResult Delete(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }




    }
}
