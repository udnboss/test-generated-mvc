
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
    public class TIMS_ProjectActionItemWorkflowController : BaseController
    {
        public List<TIMS_ProjectActionItemWorkflowViewModel> GetList()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.TIMS_ProjectActionItemWorkflow.Include(x => x.TIMS_WorkflowType)
				.Include(x => x.TIMS_ProjectActionItem)
				.Include(x => x.TIMS_User).AsQueryable();

            var ui_route_filter = (RouteData.Values["ui_route_filter"] ?? Request.QueryString["ui_route_filter"]) as string;
            if (!string.IsNullOrEmpty(ui_route_filter))
            {
                try
                {
                    var bytes = Convert.FromBase64String(ui_route_filter);
                    ui_route_filter = System.Text.Encoding.ASCII.GetString(bytes);

                    var filter = JsonConvert.DeserializeObject<TIMS_ProjectActionItemWorkflowViewModel>(ui_route_filter).ToModel();

                    if (filter.ID != null && filter.ID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ID == filter.ID);
					if (filter.WorkflowTypeID != null && filter.WorkflowTypeID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.WorkflowTypeID == filter.WorkflowTypeID);
					if (filter.ActionItemID != null && filter.ActionItemID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ActionItemID == filter.ActionItemID);
					if (filter.DateInitiated != null && filter.DateInitiated.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.DateInitiated == filter.DateInitiated);
					if (filter.LeadStateID != null && filter.LeadStateID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.LeadStateID == filter.LeadStateID);
					if (filter.InterfaceStateID != null && filter.InterfaceStateID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.InterfaceStateID == filter.InterfaceStateID);
					if (filter.UserID != null && filter.UserID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.UserID == filter.UserID);
					if (filter.IsDraft != null && filter.IsDraft.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.IsDraft == filter.IsDraft);                        
                }
                catch
                {

                }
            }

            return data.ToList().Select(x => new TIMS_ProjectActionItemWorkflowViewModel(x, true)).ToList();
        }

        public TIMS_ProjectActionItemWorkflow Get(Guid id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.TIMS_ProjectActionItemWorkflow.Include(x => x.TIMS_WorkflowType)
				.Include(x => x.TIMS_ProjectActionItem)
				.Include(x => x.TIMS_User).FirstOrDefault(x=> x.ID == id);
        }

        public Dictionary<string, object> GetLookups()
        {
            return new Dictionary<string, object> {
                {"ActionItemID", db.TIMS_ProjectActionItem.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) },
				{"UserID", db.TIMS_User.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) },
				{"WorkflowTypeID", db.TIMS_WorkflowType.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) }
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

            var vm = new TIMS_ProjectActionItemWorkflowViewModel(m, true);

            return PartialView(vm);
        }

        public ActionResult New()
        {
            var vm = new TIMS_ProjectActionItemWorkflowViewModel() {  };
                       
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

            var vm = new TIMS_ProjectActionItemWorkflowViewModel(m);
            ViewBag.Lookups = GetLookups();

            return PartialView(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TIMS_ProjectActionItemWorkflowViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var m = vm.ToModel();
                m.ID = Guid.NewGuid(); 
                db.TIMS_ProjectActionItemWorkflow.Add(m);
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
        public ActionResult Update(TIMS_ProjectActionItemWorkflowViewModel vm)
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
        public ActionResult Delete(TIMS_ProjectActionItemWorkflowViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var em = Get(vm.ID);
                if (em == null)
                {
                    Response.StatusCode = HttpStatusCode.NotFound.GetHashCode();
                    return Json(new string[] { "Item not found." });
                }

                db.TIMS_ProjectActionItemWorkflow.Remove(em);
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
