
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
    public class TIMS_ProjectInterfaceAgreementWorkflowController : BaseController
    {
        public List<TIMS_ProjectInterfaceAgreementWorkflowViewModel> GetList()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.TIMS_ProjectInterfaceAgreementWorkflow.Include(x => x.TIMS_WorkflowType)
				.Include(x => x.TIMS_ProjectInterfaceAgreement)
				.Include(x => x.TIMS_User)
				.Include(x => x.TIMS_ProjectDiscipline)
				.Include(x => x.TIMS_ProjectArea).AsQueryable();

            var ui_route_filter = (RouteData.Values["ui_route_filter"] ?? Request.QueryString["ui_route_filter"]) as string;
            if (!string.IsNullOrEmpty(ui_route_filter))
            {
                try
                {
                    var bytes = Convert.FromBase64String(ui_route_filter);
                    ui_route_filter = System.Text.Encoding.ASCII.GetString(bytes);

                    var filter = JsonConvert.DeserializeObject<TIMS_ProjectInterfaceAgreementWorkflowViewModel>(ui_route_filter).ToModel();

                    if (filter.ID != null && filter.ID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ID == filter.ID);
					if (filter.WorkflowTypeID != null && filter.WorkflowTypeID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.WorkflowTypeID == filter.WorkflowTypeID);
					if (filter.InterfaceAgreementID != null && filter.InterfaceAgreementID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.InterfaceAgreementID == filter.InterfaceAgreementID);
					if (filter.DateInitiated != null && filter.DateInitiated.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.DateInitiated == filter.DateInitiated);
					if (filter.LeadStateID != null && filter.LeadStateID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.LeadStateID == filter.LeadStateID);
					if (filter.InterfaceStateID != null && filter.InterfaceStateID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.InterfaceStateID == filter.InterfaceStateID);
					if (filter.UserID != null && filter.UserID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.UserID == filter.UserID);
					if (filter.IsDraft != null && filter.IsDraft.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.IsDraft == filter.IsDraft);
					if (filter.DisciplineID != null && filter.DisciplineID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.DisciplineID == filter.DisciplineID);
					if (filter.SystemID != null && filter.SystemID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.SystemID == filter.SystemID);
					if (filter.AreaID != null && filter.AreaID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.AreaID == filter.AreaID);
					if (filter.ShortDescription != null && filter.ShortDescription.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ShortDescription == filter.ShortDescription);
					if (filter.DetailedDescription != null && filter.DetailedDescription.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.DetailedDescription == filter.DetailedDescription);                        
                }
                catch
                {

                }
            }

            return data.ToList().Select(x => new TIMS_ProjectInterfaceAgreementWorkflowViewModel(x, true)).ToList();
        }

        public TIMS_ProjectInterfaceAgreementWorkflow Get(Guid id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.TIMS_ProjectInterfaceAgreementWorkflow.Include(x => x.TIMS_WorkflowType)
				.Include(x => x.TIMS_ProjectInterfaceAgreement)
				.Include(x => x.TIMS_User)
				.Include(x => x.TIMS_ProjectDiscipline)
				.Include(x => x.TIMS_ProjectArea).FirstOrDefault(x=> x.ID == id);
        }

        public Dictionary<string, object> GetLookups()
        {
            return new Dictionary<string, object> {
                {"AreaID", db.TIMS_ProjectArea.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) },
				{"DisciplineID", db.TIMS_ProjectDiscipline.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) },
				{"InterfaceAgreementID", db.TIMS_ProjectInterfaceAgreement.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) },
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

            var vm = new TIMS_ProjectInterfaceAgreementWorkflowViewModel(m, true);

            return PartialView(vm);
        }

        public ActionResult New()
        {
            var vm = new TIMS_ProjectInterfaceAgreementWorkflowViewModel() {  };
                       
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

            var vm = new TIMS_ProjectInterfaceAgreementWorkflowViewModel(m);
            ViewBag.Lookups = GetLookups();

            return PartialView(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TIMS_ProjectInterfaceAgreementWorkflowViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var m = vm.ToModel();
                m.ID = Guid.NewGuid(); 
                db.TIMS_ProjectInterfaceAgreementWorkflow.Add(m);
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
        public ActionResult Update(TIMS_ProjectInterfaceAgreementWorkflowViewModel vm)
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
        public ActionResult Delete(TIMS_ProjectInterfaceAgreementWorkflowViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var em = Get(vm.ID);
                if (em == null)
                {
                    Response.StatusCode = HttpStatusCode.NotFound.GetHashCode();
                    return Json(new string[] { "Item not found." });
                }

                db.TIMS_ProjectInterfaceAgreementWorkflow.Remove(em);
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
