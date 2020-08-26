
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
using WorkflowWeb.Business;
using WorkflowWeb.ViewModels;

namespace WorkflowWeb.Controllers
{
    public partial class TIMS_ProjectDisciplineController : BaseController<TIMS_ProjectDiscipline, TIMS_ProjectDisciplineBusiness, TIMS_ProjectDisciplineViewModel>
    {
        public TIMS_ProjectDisciplineController()
        {
            business = new TIMS_ProjectDisciplineBusiness(db, user);
            this.GetLookups = DefaultGetLookups;
        }

        public Func<Dictionary<string, object>> GetLookups { get; set; }

        public Dictionary<string, object> DefaultGetLookups()
        {
            var db = (IMSEntities)this.db;
            var routeFilter = GetRouteFilter();

            return new Dictionary<string, object> {
                {"DisciplineID", db.TIMS_Discipline.Where(x => routeFilter.DisciplineID == null || x.ID == routeFilter.DisciplineID).Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) },
				{"ProjectID", db.TIMS_Project.Where(x => routeFilter.ProjectID == null || x.ID == routeFilter.ProjectID).Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) }
            };
        }

        public ActionResult Index(Guid? id = null)
        {
            return View((object)id);
        }

        public ActionResult List(Guid? id = null, string ui_list_view = null, bool json = false)
        {
            ViewBag.CurrentID = id;
            var uiListView = ui_list_view ?? (RouteData.Values["ui_list_view"] ?? Request.QueryString["ui_list_view"]) as string;

            if (uiListView != null && uiListView != "ListDetail" && uiListView != "ListTable") //invalid
            {
                return HttpNotFound();
            }

            var routeFilter = GetRouteFilter();
            var results = business.GetList(routeFilter);

            var message = results.Message;

            var responseCode = GetResponseCode(results);
            Response.StatusCode = (int)responseCode;

            if (responseCode == HttpStatusCode.OK)
            {
                var data = results.Data.Select(x => new TIMS_ProjectDisciplineViewModel(x, true)).ToList();
                if (json) { return JsonOut(data); }

                ViewBag.CanEdit = business.CanNew(routeFilter).Status == State.Success;

                return PartialView(uiListView ?? "ListTable", data);
            }

            return Json(new string[] { message });
        }

        public ActionResult DetailsWithBar(Guid id, bool partial = true)
        {
            return Details(id, partial);
        }

        public ActionResult DetailsWithTabs(Guid id, bool partial = true)
        {
            return Details(id, partial);

        }
        
        public ActionResult Details(Guid id, bool partial = true, bool json = false)
        {
            string message;

            if (id == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                message = "Bad Request: missing identifier";
            }
            else
            {
                var r = business.Get(id);
                message = r.Message;

                var responseCode = GetResponseCode(r);
                Response.StatusCode = (int)responseCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    var m = r.Data;
                    var vm = new TIMS_ProjectDisciplineViewModel(m, true);
                    if (json) { return JsonOut(vm); }

                    ViewBag.CanEdit = business.CanEdit(id).Status == State.Success;
                    ViewBag.CanDelete = business.CanDelete(m).Status == State.Success;

                    return partial ? PartialView(vm) as ActionResult : View(vm);
                }
            }

            return Json(new string[] { message });
        }

        public ActionResult Delete(Guid id, bool json = false)
        {
            string message;

            if (id == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                message = "Bad Request: missing identifier";
            }
            else
            {
                var r = business.Get(id);
                message = r.Message;

                var responseCode = GetResponseCode(r);
                Response.StatusCode = (int)responseCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    var m = r.Data;

                    var dr = business.CanDelete(m);
                    message = dr.Message;

                    responseCode = GetResponseCode(dr);
                    Response.StatusCode = (int)responseCode;

                    m = dr.Data;

                    var vm = new TIMS_ProjectDisciplineViewModel(m, true);
                    if (json) { return JsonOut(vm); }

                    return PartialView(vm);
                }
            }

            return Json(new string[] { message });
        }

        public ActionResult New(bool json = false)
        {
            var routeFilter = GetRouteFilter();
            var vm = routeFilter != null ? new TIMS_ProjectDisciplineViewModel(routeFilter) : new TIMS_ProjectDisciplineViewModel() { };
            var r = business.CanNew(routeFilter);
            var message = r.Message;

            var responseCode = GetResponseCode(r);
            Response.StatusCode = (int)responseCode;

            if (responseCode == HttpStatusCode.OK)
            {
                if (json) { return JsonOut(new { data = vm, lookups = GetLookups() }); }

                ViewBag.Lookups = GetLookups();                
                return PartialView(vm);
            }

            return Json(new string[] { message });
        }

        public ActionResult Edit(Guid id, bool json = false)
        {
            string message;

            if (id == null)
            {
                Response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();
                message = "Bad Request: missing identifier";
            }
            else
            {
                var r = business.CanEdit(id);
                message = r.Message;

                var responseCode = GetResponseCode(r);
                Response.StatusCode = (int)responseCode;
                if (responseCode == HttpStatusCode.OK)
                {
                    var m = r.Data;
                    var vm = new TIMS_ProjectDisciplineViewModel(m, true);
                                        
                    if (json) { return JsonOut(new { data = vm, lookups = GetLookups() }); }
                    ViewBag.Lookups = GetLookups();
                    return PartialView(vm);
                }
            }

            return Json(new string[] { message });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TIMS_ProjectDisciplineViewModel vm, bool json = false)
        {
            string message;

            if (ModelState.IsValid)
            {
                var m = vm.ToModel();
                m.ID = Guid.NewGuid(); 
                var r = business.Create(m);
                message = r.Message;

                var responseCode = GetResponseCode(r);
                Response.StatusCode = (int)responseCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    return List(m.ID, null, json);
                }

                return Json(new string[] { message });
            }

            var errors = ModelState.SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage)
                .ToList();

            Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return Json(errors);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(TIMS_ProjectDisciplineViewModel vm, bool json = false)
        {
            string message;

            if (ModelState.IsValid)
            {
                var m = vm.ToModel();
                var r = business.Update(m);
                message = r.Message;

                var responseCode = GetResponseCode(r);
                Response.StatusCode = (int)responseCode;
                if (responseCode == HttpStatusCode.OK)
                {
                    return List(m.ID, null, json);
                }

                return Json(new string[] { message });
            }

            var errors = ModelState.SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage)
                .ToList();

            Response.StatusCode = (int)HttpStatusCode.BadRequest;

            return Json(errors);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TIMS_ProjectDisciplineViewModel vm, bool json = false)
        {
            string message;

            var m = vm.ToModel();
            var r = business.Delete(m);

            message = r.Message;
            var responseCode = GetResponseCode(r);
            Response.StatusCode = (int)responseCode;
            if (responseCode == HttpStatusCode.OK)
            {
                return List(null, null, json);
            }

            return Json(new string[] { message });
        }
    }
}
