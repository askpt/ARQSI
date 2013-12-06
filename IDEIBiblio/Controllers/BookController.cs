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
    public class BookController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Books/
        [Authorize(Roles = "ManagerRole,CostumerRole")]
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Editor);
            books = db.Books.Include(b => b.Category);
            return View(books.ToList());
        }

        [Authorize(Roles = "ManagerRole,CostumerRole")]
        // GET: /Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [Authorize(Roles = "ManagerRole")]
        // GET: /Books/Create
        public ActionResult Create()
        {
            ViewBag.EditorID = new SelectList(db.Editors, "EditorID", "Name");
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");

            return View();
        }

        // POST: /Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ManagerRole")]
        public ActionResult Create([Bind(Include = "Category,EditorID,AuthorID,CategoryID,Editor,Author,Category,Price,Title,Year,ISBN")] Book book)
        {
            if (ModelState.IsValid)
            {

                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EditorID = new SelectList(db.Editors, "EditorID", "Name", book.EditorID);
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", book.CategoryID);

            return View(book);
        }

        // GET: /Books/Edit/5
        [Authorize(Roles = "ManagerRole")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.EditorID = new SelectList(db.Editors, "EditorID", "Name", book.EditorID);
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", book.CategoryID);
            return View(book);
        }

        // POST: /Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ManagerRole")]
        public ActionResult Edit([Bind(Include = "BookID,Category,EditorID,AuthorID,CategoryID,Price,Title,Year,ISBN")] Book book)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EditorID = new SelectList(db.Editors, "EditorID", "Name", book.EditorID);
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Name", book.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", book.CategoryID);
            return View(book);
        }

        // GET: /Books/Delete/5
        [Authorize(Roles = "ManagerRole")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: /Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ManagerRole")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
