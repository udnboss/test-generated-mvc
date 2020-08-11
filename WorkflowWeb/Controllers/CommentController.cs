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
    public class CommentController : BaseController
    {
        private COMMENTSEntities db = new COMMENTSEntities();

        public List<T_Comment> GetList()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.T_Comment.ToList();
            return data;
        }

        public T_Comment Get(Guid? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.T_Comment.Find(id);
        }

        public bool Del(Guid? id)
        {
            var m = Get(id);
            if(m == null)
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
                    {"parent_id", GetList().Select(x => new { id = x.ID, text = x.Name }).ToList() },
                    {"domain_id", db.T_Domain.Select(x => new { id = x.ID, text = x.Host }).ToList() }
                };
        }

        // GET: Comment
        public ActionResult Index()
        {
            return JsonOut(GetList());            
        }

        // GET: Comment/Details/5
        public ActionResult Details(Guid? id)
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

            return JsonOut(m);
        }

        // GET: Comment/Create
        public ActionResult New()
        {
            var vm = new { 
                data = new T_Comment(), 
                lookups = GetLookups()
            };

            return JsonOut(vm);
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(T_Comment m)
        {
            if (ModelState.IsValid)
            {
                m.ID = Guid.NewGuid();
                db.T_Comment.Add(m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return JsonOut(ModelState);
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(Guid? id)
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

            var vm = new
            {
                data = m,
                lookups = GetLookups()
            };

            return JsonOut(vm);
        }

        // POST: Comment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(T_Comment m)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return JsonOut(ModelState);
        }


        // POST: Comment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(T_Comment m)
        {
            return JsonOut(new { status = Del(m.ID) });
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
