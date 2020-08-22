
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
    public partial class TIMS_ProjectAttachmentController : BaseController<TIMS_ProjectAttachment, TIMS_ProjectAttachmentBusiness, TIMS_ProjectAttachmentViewModel>
    {
        public TIMS_ProjectAttachmentController()
        {
            business = new TIMS_ProjectAttachmentBusiness(db, user);
        }

        public Dictionary<string, object> GetLookups()
        {
            var routeFilter = GetRouteFilter();

            return new Dictionary<string, object> {
                {"ProjectActionItemWorkflowID", db.TIMS_ProjectActionItemWorkflow.Where(x => routeFilter.ProjectActionItemWorkflowID == null || x.ID == routeFilter.ProjectActionItemWorkflowID).Where(x => routeFilter.UserID == null ||  x.TIMS_User.ID == routeFilter.UserID).Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.ID.ToString() }) },
				{"ProjectInterfaceAgreementWorkflowID", db.TIMS_ProjectInterfaceAgreementWorkflow.Where(x => routeFilter.ProjectInterfaceAgreementWorkflowID == null || x.ID == routeFilter.ProjectInterfaceAgreementWorkflowID).Where(x => routeFilter.UserID == null ||  x.TIMS_User.ID == routeFilter.UserID).Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.ID.ToString() }) },
				{"ProjectInterfacePointWorkflowID", db.TIMS_ProjectInterfacePointWorkflow.Where(x => routeFilter.ProjectInterfacePointWorkflowID == null || x.ID == routeFilter.ProjectInterfacePointWorkflowID).Where(x => routeFilter.UserID == null ||  x.TIMS_User.ID == routeFilter.UserID).Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.ID.ToString() }) },
				{"PackageID", db.TIMS_ProjectPackage.Where(x => routeFilter.PackageID == null || x.ID == routeFilter.PackageID).Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) },
				{"UserID", db.TIMS_User.Where(x => routeFilter.UserID == null || x.ID == routeFilter.UserID).Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) }
            };
        }

        public ActionResult Index(Guid? id = null)
        {
            return View((object)id);
        }

        public ActionResult List(Guid? id = null, string ui_list_view = null)
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
                var data = results.Data.Select(x => new TIMS_ProjectAttachmentViewModel(x, true)).ToList();
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
                    var vm = new TIMS_ProjectAttachmentViewModel(m, true);
                    return PartialView(vm);
                }
            }

            return Json(new string[] { message });
        }

        public ActionResult New()
        {
            var routeFilter = GetRouteFilter();
            var vm = routeFilter != null ? new TIMS_ProjectAttachmentViewModel(routeFilter) : new TIMS_ProjectAttachmentViewModel() { };
            var r = business.New(routeFilter);
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
                    var vm = new TIMS_ProjectAttachmentViewModel(m, true);
                    ViewBag.Lookups = GetLookups();
                    return PartialView(vm);
                }
            }

            return Json(new string[] { message });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TIMS_ProjectAttachmentViewModel vm)
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
        public ActionResult Update(TIMS_ProjectAttachmentViewModel vm)
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
        public ActionResult Delete(TIMS_ProjectAttachmentViewModel vm)
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
