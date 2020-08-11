using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkflowWeb.Models;

namespace WorkflowWeb.Controllers
{
    public class T_CommentController : Controller
    {
        private COMMENTSEntities db = new COMMENTSEntities();

        // GET: T_Comment
        public ActionResult Index()
        {
            var t_Comment = db.T_Comment.Include(t => t.T_Comment2).Include(t => t.T_Domain);
            return View(t_Comment.ToList());
        }

        // GET: T_Comment/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Comment t_Comment = db.T_Comment.Find(id);
            if (t_Comment == null)
            {
                return HttpNotFound();
            }
            return View(t_Comment);
        }

        // GET: T_Comment/Create
        public ActionResult Create()
        {
            ViewBag.ParentID = new SelectList(db.T_Comment, "ID", "DomainID");
            ViewBag.DomainID = new SelectList(db.T_Domain, "ID", "Host");
            return View();
        }

        // POST: T_Comment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DomainID,Path,IP,Name,Comment,ParentID,DatePosted,QueryString")] T_Comment t_Comment)
        {
            if (ModelState.IsValid)
            {
                t_Comment.ID = Guid.NewGuid();
                db.T_Comment.Add(t_Comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentID = new SelectList(db.T_Comment, "ID", "DomainID", t_Comment.ParentID);
            ViewBag.DomainID = new SelectList(db.T_Domain, "ID", "Host", t_Comment.DomainID);
            return View(t_Comment);
        }

        // GET: T_Comment/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Comment t_Comment = db.T_Comment.Find(id);
            if (t_Comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentID = new SelectList(db.T_Comment, "ID", "DomainID", t_Comment.ParentID);
            ViewBag.DomainID = new SelectList(db.T_Domain, "ID", "Host", t_Comment.DomainID);
            return View(t_Comment);
        }

        // POST: T_Comment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DomainID,Path,IP,Name,Comment,ParentID,DatePosted,QueryString")] T_Comment t_Comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentID = new SelectList(db.T_Comment, "ID", "DomainID", t_Comment.ParentID);
            ViewBag.DomainID = new SelectList(db.T_Domain, "ID", "Host", t_Comment.DomainID);
            return View(t_Comment);
        }

        // GET: T_Comment/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Comment t_Comment = db.T_Comment.Find(id);
            if (t_Comment == null)
            {
                return HttpNotFound();
            }
            return View(t_Comment);
        }

        // POST: T_Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            T_Comment t_Comment = db.T_Comment.Find(id);
            db.T_Comment.Remove(t_Comment);
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
