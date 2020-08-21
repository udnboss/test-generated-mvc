
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
    public class TIMS_ProjectInterfacePointWorkflowController : BaseController
    {
        private TIMS_ProjectInterfacePointWorkflow _routeFilter;
        public TIMS_ProjectInterfacePointWorkflow RouteFilter
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

                        var filter = JsonConvert.DeserializeObject<TIMS_ProjectInterfacePointWorkflowViewModel>(ui_route_filter).ToModel();

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

        public List<TIMS_ProjectInterfacePointWorkflowViewModel> GetList()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.TIMS_ProjectInterfacePointWorkflow.Include(x => x.TIMS_WorkflowType)
				.Include(x => x.TIMS_WorkflowState)
				.Include(x => x.TIMS_WorkflowState1)
				.Include(x => x.TIMS_WorkflowState2)
				.Include(x => x.TIMS_ProjectArea)
				.Include(x => x.TIMS_ProjectPhysicalArea)
				.Include(x => x.TIMS_Phase)
				.Include(x => x.TIMS_ProjectDisciplineInterfaceType)
				.Include(x => x.TIMS_User).AsQueryable();

            var ui_route_filter = (RouteData.Values["ui_route_filter"] ?? Request.QueryString["ui_route_filter"]) as string;
            var filter = RouteFilter;

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ID == filter.ID);
					if (filter.WorkflowTypeID != null && filter.WorkflowTypeID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.WorkflowTypeID == filter.WorkflowTypeID);
					if (filter.InterfacePointID != null && filter.InterfacePointID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.InterfacePointID == filter.InterfacePointID);
					if (filter.DateInitiated != null && filter.DateInitiated.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.DateInitiated == filter.DateInitiated);
					if (filter.LeadStateID != null && filter.LeadStateID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.LeadStateID == filter.LeadStateID);
					if (filter.InterfaceStateID != null && filter.InterfaceStateID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.InterfaceStateID == filter.InterfaceStateID);
					if (filter.SupportStateID != null && filter.SupportStateID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.SupportStateID == filter.SupportStateID);
					if (filter.ProjectAreaID != null && filter.ProjectAreaID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ProjectAreaID == filter.ProjectAreaID);
					if (filter.ProjectPhysicalAreaID != null && filter.ProjectPhysicalAreaID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ProjectPhysicalAreaID == filter.ProjectPhysicalAreaID);
					if (filter.PhaseID != null && filter.PhaseID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.PhaseID == filter.PhaseID);
					if (filter.InterfaceTypeID != null && filter.InterfaceTypeID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.InterfaceTypeID == filter.InterfaceTypeID);
					if (filter.UserID != null && filter.UserID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.UserID == filter.UserID);
					if (filter.IsDraft != null && filter.IsDraft.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.IsDraft == filter.IsDraft);                        
            }

            var results = data.ToList().Select(x => new TIMS_ProjectInterfacePointWorkflowViewModel(x, true)).ToList();

            return results;
        }

        public TIMS_ProjectInterfacePointWorkflow Get(Guid id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.TIMS_ProjectInterfacePointWorkflow.Include(x => x.TIMS_WorkflowType)
				.Include(x => x.TIMS_WorkflowState)
				.Include(x => x.TIMS_WorkflowState1)
				.Include(x => x.TIMS_WorkflowState2)
				.Include(x => x.TIMS_ProjectArea)
				.Include(x => x.TIMS_ProjectPhysicalArea)
				.Include(x => x.TIMS_Phase)
				.Include(x => x.TIMS_ProjectDisciplineInterfaceType)
				.Include(x => x.TIMS_User).FirstOrDefault(x=> x.ID == id);
        }

        public Dictionary<string, object> GetLookups()
        {
            return new Dictionary<string, object> {
                {"PhaseID", db.TIMS_Phase.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) },
				{"ProjectAreaID", db.TIMS_ProjectArea.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) },
				{"InterfaceTypeID", db.TIMS_ProjectDisciplineInterfaceType.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) },
				{"ProjectPhysicalAreaID", db.TIMS_ProjectPhysicalArea.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) },
				{"UserID", db.TIMS_User.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) },
				{"LeadStateID", db.TIMS_WorkflowState.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) },
				{"InterfaceStateID", db.TIMS_WorkflowState.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) },
				{"SupportStateID", db.TIMS_WorkflowState.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) },
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

            var vm = new TIMS_ProjectInterfacePointWorkflowViewModel(m, true);

            return PartialView(vm);
        }

        public ActionResult New()
        {
            var vm = RouteFilter != null ? new TIMS_ProjectInterfacePointWorkflowViewModel(RouteFilter) : new TIMS_ProjectInterfacePointWorkflowViewModel() {  };
                       
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

            var vm = new TIMS_ProjectInterfacePointWorkflowViewModel(m);
            ViewBag.Lookups = GetLookups();

            return PartialView(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TIMS_ProjectInterfacePointWorkflowViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var m = vm.ToModel();
                m.ID = Guid.NewGuid(); 
                db.TIMS_ProjectInterfacePointWorkflow.Add(m);
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
        public ActionResult Update(TIMS_ProjectInterfacePointWorkflowViewModel vm)
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
        public ActionResult Delete(TIMS_ProjectInterfacePointWorkflowViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var em = Get(vm.ID);
                if (em == null)
                {
                    Response.StatusCode = HttpStatusCode.NotFound.GetHashCode();
                    return Json(new string[] { "Item not found." });
                }

                db.TIMS_ProjectInterfacePointWorkflow.Remove(em);
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
