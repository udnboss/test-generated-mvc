using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkflowWeb.Models;

namespace WorkflowWeb.Controllers
{
    public class UploadController : BaseController
    {
        private COMMENTSEntities db = new COMMENTSEntities();

        public List<T_Upload> GetList()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.T_Upload.ToList();
            return data;
        }

        public T_Upload Get(Guid? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.T_Upload.Find(id);
        }

        public bool Del(Guid? id)
        {
            var m = Get(id);
            if(m == null)
            {
                return false;
            }

            var UploadPath = Server.MapPath("~/uploads");
            var path = Path.Combine(UploadPath, m.Path);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            db.T_Upload.Remove(m);
            db.SaveChanges();

            return true;
        }

        public ActionResult Index()
        {
            return JsonOut(GetList());            
        }

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

        public ActionResult New()
        {
            var vm = new { 
                data = new T_Upload()
            };

            return JsonOut(vm);
        }

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
                data = m
            };

            return JsonOut(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(T_Upload m)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return JsonOut(ModelState);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(T_Upload m)
        {
            if(Del(m.ID))
            {
                return RedirectToAction("Index");
            }

            return JsonOut(new { status = false });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload()
        {
            var fileName = Request.Form["name"];
            var part = int.Parse(Request.Form["part"]);
            var parts = int.Parse(Request.Form["parts"]);
            var size = int.Parse(Request.Form["size"]);

            var FileDataContent = Request.Files[0];
            if (FileDataContent != null && FileDataContent.ContentLength > 0)
            {
                var stream = FileDataContent.InputStream;
                var UploadPath = Server.MapPath("~/uploads");
                Directory.CreateDirectory(UploadPath);
                var path = Path.Combine(UploadPath, fileName);
                try
                {
                    using (var fileStream = new FileStream(path, FileMode.Append, FileAccess.Write))
                    {
                        stream.CopyTo(fileStream);
                    }
                   
                    //last part?
                    if(part + 1 >= parts)
                    {
                        var newid = Guid.NewGuid();
                        var newName = newid.ToString() + "_" + fileName;
                        var newPath = Path.Combine(UploadPath, newName);
                        
                        System.IO.File.Move(path, newPath); //rename

                        var n = new T_Upload
                        {
                            ID = newid,
                            Name = fileName, //display name
                            Path = newName, //physical name
                            Size = size,
                            UploadDate = DateTime.Now
                        };
                                                
                        db.T_Upload.Add(n);
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                }
                catch (IOException ex)
                {
                    // handle  
                    Response.StatusCode = 500;
                    return Json(new { status = "fail", error = ex.Message });
                }
            }

            return Json(new { status = "success" });
        }

        public ActionResult Download(Guid? id)
        {
            var u = db.T_Upload.Find(id);
            var UploadPath = Server.MapPath("~/uploads");
            var path = Path.Combine(UploadPath, u.Path);

            return File(path, MimeMapping.GetMimeMapping(path), u.Name);
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
