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
    public class EditorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Editor/
        public ActionResult Index()
        {
            return View(db.Editors.ToList());
        }

        // GET: /Editor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editor editor = db.Editors.Find(id);
            if (editor == null)
            {
                return HttpNotFound();
            }
            return View(editor);
        }

        // GET: /Editor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Editor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EditorID,Address,Email,Name,Phone")] Editor editor)
        {
            if (ModelState.IsValid)
            {
                db.Editors.Add(editor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(editor);
        }

        // GET: /Editor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editor editor = db.Editors.Find(id);
            if (editor == null)
            {
                return HttpNotFound();
            }
            return View(editor);
        }

        // POST: /Editor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EditorID,Address,Email,Name,Phone")] Editor editor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editor);
        }

        // GET: /Editor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editor editor = db.Editors.Find(id);
            if (editor == null)
            {
                return HttpNotFound();
            }
            return View(editor);
        }

        // POST: /Editor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Editor editor = db.Editors.Find(id);
            db.Editors.Remove(editor);
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
