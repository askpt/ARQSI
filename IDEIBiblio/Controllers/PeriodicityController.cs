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
    public class PeriodicityController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Periodicity/
        [Authorize(Roles = "ManagerRole")]
        public ActionResult Index()
        {
            return View(db.Periodicities.ToList());
        }

        // GET: /Periodicity/Details/5
        [Authorize(Roles = "ManagerRole")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodicity periodicity = db.Periodicities.Find(id);
            if (periodicity == null)
            {
                return HttpNotFound();
            }
            return View(periodicity);
        }

        // GET: /Periodicity/Create
        [Authorize(Roles = "ManagerRole")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Periodicity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ManagerRole")]
        public ActionResult Create([Bind(Include = "PeriodicityID,Name,NumberofDays")] Periodicity periodicity)
        {
            if (ModelState.IsValid)
            {
                db.Periodicities.Add(periodicity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(periodicity);
        }

        // GET: /Periodicity/Edit/5
        [Authorize(Roles = "ManagerRole")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodicity periodicity = db.Periodicities.Find(id);
            if (periodicity == null)
            {
                return HttpNotFound();
            }
            return View(periodicity);
        }

        // POST: /Periodicity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ManagerRole")]
        public ActionResult Edit([Bind(Include = "PeriodicityID,Name,NumberofDays")] Periodicity periodicity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periodicity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(periodicity);
        }

        // GET: /Periodicity/Delete/5
        [Authorize(Roles = "ManagerRole")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodicity periodicity = db.Periodicities.Find(id);
            if (periodicity == null)
            {
                return HttpNotFound();
            }
            return View(periodicity);
        }

        // POST: /Periodicity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ManagerRole")]
        public ActionResult DeleteConfirmed(int id)
        {
            Periodicity periodicity = db.Periodicities.Find(id);
            db.Periodicities.Remove(periodicity);
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
