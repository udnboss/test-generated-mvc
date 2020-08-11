using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkflowWeb.Attributes;
using WorkflowWeb.Models;

namespace WorkflowWeb.Controllers
{
    [HandleParameters]
    public class Comment1Controller : Controller
    {
        private COMMENTSEntities db = new COMMENTSEntities();

        // GET: Comment1
        public ActionResult Index()
        {
            var t_Comment = db.T_Comment.Include(t => t.T_Comment2).Include(t => t.T_Domain);
            return PartialView(t_Comment.ToList());
        }

        // GET: Comment1/Details/5
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
            return PartialView(t_Comment);
        }

        // GET: Comment1/Create
        public ActionResult Create()
        {
            ViewBag.ParentID = new SelectList(db.T_Comment, "ID", "DomainID");
            ViewBag.DomainID = new SelectList(db.T_Domain, "ID", "Host");
            return PartialView();
        }

        // POST: Comment1/Create
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

            Response.StatusCode = 422;

            ViewBag.ParentID = new SelectList(db.T_Comment, "ID", "DomainID", t_Comment.ParentID);
            ViewBag.DomainID = new SelectList(db.T_Domain, "ID", "Host", t_Comment.DomainID);
            return PartialView(t_Comment);
        }

        // GET: Comment1/Edit/5
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
            return PartialView(t_Comment);
        }

        // POST: Comment1/Edit/5
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
            return PartialView(t_Comment);
        }

        // GET: Comment1/Delete/5
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
            return PartialView(t_Comment);
        }

        // POST: Comment1/Delete/5
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
