using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IDEIBiblio.Models;
using IDEIBiblio.DAL;

namespace IDEIBiblio.Controllers
{
    public class MagazineController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Magazine/
        [AllowAnonymous]
        public ActionResult Index()
        {
            var magazines = db.Magazines.Include(m => m.Author).Include(m => m.Category).Include(m => m.Editor).Include(m => m.Periodicy);
            return View(magazines.ToList());
        }

        // GET: /Magazine/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Magazine magazine = db.Magazines.Find(id);
            if (magazine == null)
            {
                return HttpNotFound();
            }
            return View(magazine);
        }

        // GET: /Magazine/Create
        [Authorize(Roles = "ManagerRole")]
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.EditorID = new SelectList(db.Editors, "EditorID", "Name");
            ViewBag.PeriodicityID = new SelectList(db.Periodicities, "PeriodicityID", "Name");
            return View();
        }

        // POST: /Magazine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ManagerRole")]
        public ActionResult Create([Bind(Include="MagazineID,AuthorID,CategoryID,EditorID,Price,Title,Publish,Issue,Number,PeriodicityID")] Magazine magazine)
        {
            if (ModelState.IsValid)
            {
                db.Magazines.Add(magazine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name", magazine.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", magazine.CategoryID);
            ViewBag.EditorID = new SelectList(db.Editors, "EditorID", "Name", magazine.EditorID);
            ViewBag.PeriodicityID = new SelectList(db.Periodicities, "PeriodicityID", "Name", magazine.PeriodicityID);
            return View(magazine);
        }

        // GET: /Magazine/Edit/5
        [Authorize(Roles = "ManagerRole")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Magazine magazine = db.Magazines.Find(id);
            if (magazine == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name", magazine.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", magazine.CategoryID);
            ViewBag.EditorID = new SelectList(db.Editors, "EditorID", "Name", magazine.EditorID);
            ViewBag.PeriodicityID = new SelectList(db.Periodicities, "PeriodicityID", "Name", magazine.PeriodicityID);
            return View(magazine);
        }

        // POST: /Magazine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ManagerRole")]
        public ActionResult Edit([Bind(Include="MagazineID,AuthorID,CategoryID,EditorID,Price,Title,Publish,Issue,Number,PeriodicityID")] Magazine magazine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(magazine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name", magazine.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", magazine.CategoryID);
            ViewBag.EditorID = new SelectList(db.Editors, "EditorID", "Name", magazine.EditorID);
            ViewBag.PeriodicityID = new SelectList(db.Periodicities, "PeriodicityID", "Name", magazine.PeriodicityID);
            return View(magazine);
        }

        // GET: /Magazine/Delete/5
        [Authorize(Roles = "ManagerRole")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Magazine magazine = db.Magazines.Find(id);
            if (magazine == null)
            {
                return HttpNotFound();
            }
            return View(magazine);
        }

        // POST: /Magazine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ManagerRole")]
        public ActionResult DeleteConfirmed(int id)
        {
            Magazine magazine = db.Magazines.Find(id);
            db.Magazines.Remove(magazine);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
