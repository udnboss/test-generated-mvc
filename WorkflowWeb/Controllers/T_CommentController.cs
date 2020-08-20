
using Newtonsoft.Json;
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
    public class T_CommentController : BaseController
    {
        new COMMENTSEntities db = new COMMENTSEntities();
        public List<T_Comment> GetList()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.T_Comment.Include(x => x.T_Domain)
                .Include(x => x.T_Comment1).ToList();
            return data;
        }

        public T_Comment Get(Guid id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.T_Comment.Include(x => x.T_Domain)
                .Include(x => x.T_Comment1).FirstOrDefault(x => x.ID == id);
        }

        public bool Del(Guid id)
        {
            var m = Get(id);
            if (m == null)
            {
                return false;
            }

            db.T_Comment.Remove(m);
            db.SaveChanges();
            return true;
        }

        public Dictionary<string, object> GetLookups()
        {
            return new Dictionary<string, object> {
                {"ParentID", db.T_Comment.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.ID.ToString() }) },
                {"DomainID", db.T_Domain.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.ID.ToString() }) }
            };
        }

        public ActionResult Index()
        {
            return PartialView(GetList());
        }

        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var m = Get(id);
            if (m == null)
            {
                return HttpNotFound();
            }

            return PartialView(m);
        }

        public ActionResult New()
        {
            var m = new T_Comment() { DatePosted = DateTime.Now };

            ViewBag.Lookups = GetLookups();
            return PartialView(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(T_Comment m)
        {
            if (ModelState.IsValid)
            {
                m.ID = Guid.NewGuid();
                db.T_Comment.Add(m);
                db.SaveChanges();
                return PartialView("Index", GetList());
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var m = Get(id);
            if (m == null)
            {
                return HttpNotFound();
            }

            ViewBag.Lookups = GetLookups();
            return PartialView(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(T_Comment m)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView("Index", GetList());
            }

            return PartialView(ModelState);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(T_Comment m)
        {
            Del(m.ID);
            return PartialView("Index", GetList());
        }

    }
}
