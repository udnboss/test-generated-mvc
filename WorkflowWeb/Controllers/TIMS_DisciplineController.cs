
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
using WorkflowWeb.ViewModels;

namespace WorkflowWeb.Controllers
{
    public class TIMS_DisciplineController : BaseController
    {
        private TIMS_Discipline _routeFilter;
        public TIMS_Discipline RouteFilter
        {
            get
            {
                if (_routeFilter != null)
                {
                    return _routeFilter;
                }

                var ui_route_filter = (RouteData.Values["ui_route_filter"] ?? Request.QueryString["ui_route_filter"]) as string;
                if (!string.IsNullOrEmpty(ui_route_filter))
                {
                    try
                    {
                        var bytes = Convert.FromBase64String(ui_route_filter);
                        ui_route_filter = System.Text.Encoding.ASCII.GetString(bytes);

                        var filter = JsonConvert.DeserializeObject<TIMS_DisciplineViewModel>(ui_route_filter).ToModel();

                        _routeFilter = filter;

                        return filter;
                    }
                    catch
                    {
                        return null;
                    }
                }

                return null;
            }
        }

        public List<TIMS_DisciplineViewModel> GetList()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.TIMS_Discipline.AsQueryable();

            var ui_route_filter = (RouteData.Values["ui_route_filter"] ?? Request.QueryString["ui_route_filter"]) as string;
            var filter = RouteFilter;

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ID == filter.ID);
					if (filter.Name != null && filter.Name.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.Name == filter.Name);                        
            }

            var results = data.ToList().Select(x => new TIMS_DisciplineViewModel(x, true)).ToList();

            return results;
        }

        public TIMS_Discipline Get(Guid id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.TIMS_Discipline.FirstOrDefault(x=> x.ID == id);
        }

        public Dictionary<string, object> GetLookups()
        {
            return new Dictionary<string, object> {
                
            };
        }

        public ActionResult Index(Guid? id = null)
        {
            return View(id);
        }

        public ActionResult ListDetail(Guid? id = null)
        {
            ViewBag.CurrentID = id;
            return PartialView(GetList());
        }

        public ActionResult ListTable(Guid? id = null)
        {
            ViewBag.CurrentID = id;
            return PartialView(GetList());
        }

        public ActionResult List(Guid? id = null)
        {
            ViewBag.CurrentID = id;
            var ui_list_view = (RouteData.Values["ui_list_view"] ?? Request.QueryString["ui_list_view"]) as string;

            return PartialView(ui_list_view ?? "ListTableView", GetList());
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
                Response.StatusCode = HttpStatusCode.NotFound.GetHashCode();
                return Json(new string[] { "Item not found." });
            }

            var vm = new TIMS_DisciplineViewModel(m, true);

            return PartialView(vm);
        }

        public ActionResult New()
        {
            var vm = RouteFilter != null ? new TIMS_DisciplineViewModel(RouteFilter) : new TIMS_DisciplineViewModel() {  };
                       
            ViewBag.Lookups = GetLookups();
            return PartialView(vm);
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
                Response.StatusCode = HttpStatusCode.NotFound.GetHashCode();
                return Json(new string[] { "Item not found." });
            }

            var vm = new TIMS_DisciplineViewModel(m);
            ViewBag.Lookups = GetLookups();

            return PartialView(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TIMS_DisciplineViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var m = vm.ToModel();
                m.ID = Guid.NewGuid(); 
                db.TIMS_Discipline.Add(m);
                db.SaveChanges();
                return List(m.ID);
            }

            var errors = ModelState.SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage)
                .ToList();

            Response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();

            return Json(errors);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(TIMS_DisciplineViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var m = vm.ToModel();
                db.Entry(m).State = EntityState.Modified;
                db.SaveChanges();
                return List(m.ID);
            }

            var errors = ModelState.SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage)
                .ToList();

            Response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();

            return Json(errors);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TIMS_DisciplineViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var em = Get(vm.ID);
                if (em == null)
                {
                    Response.StatusCode = HttpStatusCode.NotFound.GetHashCode();
                    return Json(new string[] { "Item not found." });
                }

                db.TIMS_Discipline.Remove(em);
                db.SaveChanges();

                return List(null);
            }

            var errors = ModelState.SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage)
                .ToList();

            Response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();

            return Json(errors);
        }
    }
}
