
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
using WorkflowWeb.Business;

namespace WorkflowWeb.Controllers
{
    public class TIMS_ProjectController : BaseController
    {
        private TIMS_ProjectBusiness business;

        public TIMS_ProjectController()
        {
            business = new TIMS_ProjectBusiness(db);
        }

        private TIMS_Project _routeFilter;
        public TIMS_Project RouteFilter
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

                        var filter = JsonConvert.DeserializeObject<TIMS_ProjectViewModel>(ui_route_filter).ToModel();

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

        public Dictionary<string, object> GetLookups()
        {
            return new Dictionary<string, object> {
                
            };
        }

        public ActionResult Index(Guid? id = null)
        {
            return View(id);
        }

        public ActionResult List(Guid? id = null, string ui_list_view = null)
        {
            ViewBag.CurrentID = id;
            var uiListView = ui_list_view ?? (RouteData.Values["ui_list_view"] ?? Request.QueryString["ui_list_view"]) as string;

            if(uiListView != null && uiListView != "ListDetail" && uiListView != "ListTable") //invalid
            {
                return HttpNotFound();
            }

            var results = business.GetList(RouteFilter);
            
            var message = results.Message;

            var responseCode = GetResponseCode(results);
            Response.StatusCode = (int)responseCode;

            if (responseCode == HttpStatusCode.OK)
            {
                var data = results.Data.Select(x => new TIMS_ProjectViewModel(x, true)).ToList();
                return PartialView(uiListView ?? "ListTable", data);
            }

            return Json(new string[] { message });
        }

        public ActionResult Details(Guid id)
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
                    var vm = new TIMS_ProjectViewModel(m, true);
                    return PartialView(vm);
                }               
            }

            return Json(new string[] { message });
        }

        public ActionResult New()
        {
            var vm = RouteFilter != null ? new TIMS_ProjectViewModel(RouteFilter) : new TIMS_ProjectViewModel() {  };
            var r = business.New(RouteFilter);
            var message = r.Message;

            var responseCode = GetResponseCode(r);
            Response.StatusCode = (int)responseCode;

            if (responseCode == HttpStatusCode.OK)
            {
                ViewBag.Lookups = GetLookups();
                return PartialView(vm);
            }

            return Json(new string[] { message });
        }

        public ActionResult Edit(Guid id)
        {
            string message;

            if (id == null)
            {
                Response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();
                message = "Bad Request: missing identifier";
            }
            else
            {
                var r = business.Edit(id);
                message = r.Message;

                var responseCode = GetResponseCode(r);
                Response.StatusCode = (int)responseCode;
                if (responseCode == HttpStatusCode.OK)
                {
                    var m = r.Data;
                    var vm = new TIMS_ProjectViewModel(m, true);
                    ViewBag.Lookups = GetLookups();
                    return PartialView(vm);
                }                
            }

            return Json(new string[] { message });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TIMS_ProjectViewModel vm)
        {
            string message;

            if (ModelState.IsValid)
            {
                var m = vm.ToModel();
                m.ID = Guid.NewGuid();
                var r = business.Insert(m);
                message = r.Message;

                var responseCode = GetResponseCode(r);
                Response.StatusCode = (int)responseCode;

                if (responseCode == HttpStatusCode.OK)
                {
                    return List(m.ID);
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
        public ActionResult Update(TIMS_ProjectViewModel vm)
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
                    return List(m.ID);
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
        public ActionResult Delete(TIMS_ProjectViewModel vm)
        {
            string message;
            
            var m = vm.ToModel();               
            var r = business.Delete(m);

            message = r.Message;
            var responseCode = GetResponseCode(r);
            Response.StatusCode = (int)responseCode;
            if (responseCode == HttpStatusCode.OK)
            {
                return List(null);
            }

            return Json(new string[] { message });            
        }
    }
}
