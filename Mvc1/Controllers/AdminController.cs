using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc1.Models;

namespace Mvc1.Controllers
{
    public class AdminController : Controller
    {
        
        private UsersContext db = new UsersContext();

        //
        // GET: /Admin/

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            
            return View(db.UserProfiles.ToList());
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id = 0)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                db.UserProfiles.Add(userprofile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userprofile);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userprofile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userprofile);
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            db.UserProfiles.Remove(userprofile);
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