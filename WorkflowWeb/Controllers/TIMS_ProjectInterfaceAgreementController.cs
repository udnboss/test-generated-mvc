
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
    public class TIMS_ProjectInterfaceAgreementController : BaseController
    {
        private TIMS_ProjectInterfaceAgreement _routeFilter;
        public TIMS_ProjectInterfaceAgreement RouteFilter
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

                        var filter = JsonConvert.DeserializeObject<TIMS_ProjectInterfaceAgreementViewModel>(ui_route_filter).ToModel();

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

        public List<TIMS_ProjectInterfaceAgreementViewModel> GetList()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.TIMS_ProjectInterfaceAgreement.Include(x => x.TIMS_ProjectInterfacePoint)
				.Include(x => x.TIMS_ProjectPackage)
				.Include(x => x.TIMS_ProjectPackage1).AsQueryable();

            var ui_route_filter = (RouteData.Values["ui_route_filter"] ?? Request.QueryString["ui_route_filter"]) as string;
            var filter = RouteFilter;

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ID == filter.ID);
					if (filter.Name != null && filter.Name.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.Name == filter.Name);
					if (filter.InterfacePointID != null && filter.InterfacePointID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.InterfacePointID == filter.InterfacePointID);
					if (filter.RequestorPackageID != null && filter.RequestorPackageID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.RequestorPackageID == filter.RequestorPackageID);
					if (filter.ResponderPackageID != null && filter.ResponderPackageID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ResponderPackageID == filter.ResponderPackageID);
					if (filter.RequestorUserID != null && filter.RequestorUserID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.RequestorUserID == filter.RequestorUserID);
					if (filter.RequestorTechnicalContactID != null && filter.RequestorTechnicalContactID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.RequestorTechnicalContactID == filter.RequestorTechnicalContactID);
					if (filter.ResponderInterfaceManagerID != null && filter.ResponderInterfaceManagerID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ResponderInterfaceManagerID == filter.ResponderInterfaceManagerID);
					if (filter.ResponderTechnicalContactID != null && filter.ResponderTechnicalContactID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ResponderTechnicalContactID == filter.ResponderTechnicalContactID);
					if (filter.CreateDate != null && filter.CreateDate.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.CreateDate == filter.CreateDate);
					if (filter.NeedDate != null && filter.NeedDate.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.NeedDate == filter.NeedDate);
					if (filter.IssuedDate != null && filter.IssuedDate.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.IssuedDate == filter.IssuedDate);
					if (filter.AcceptedDate != null && filter.AcceptedDate.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.AcceptedDate == filter.AcceptedDate);
					if (filter.ResponseDate != null && filter.ResponseDate.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ResponseDate == filter.ResponseDate);
					if (filter.CloseDate != null && filter.CloseDate.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.CloseDate == filter.CloseDate);                        
            }

            var results = data.ToList().Select(x => new TIMS_ProjectInterfaceAgreementViewModel(x, true)).ToList();

            return results;
        }

        public TIMS_ProjectInterfaceAgreement Get(Guid id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.TIMS_ProjectInterfaceAgreement.Include(x => x.TIMS_ProjectInterfacePoint)
				.Include(x => x.TIMS_ProjectPackage)
				.Include(x => x.TIMS_ProjectPackage1).FirstOrDefault(x=> x.ID == id);
        }

        public Dictionary<string, object> GetLookups()
        {
            return new Dictionary<string, object> {
                {"InterfacePointID", db.TIMS_ProjectInterfacePoint.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.ID.ToString() }) },
				{"RequestorPackageID", db.TIMS_ProjectPackage.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) },
				{"ResponderPackageID", db.TIMS_ProjectPackage.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) }
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

            var vm = new TIMS_ProjectInterfaceAgreementViewModel(m, true);

            return PartialView(vm);
        }

        public ActionResult New()
        {
            var vm = RouteFilter != null ? new TIMS_ProjectInterfaceAgreementViewModel(RouteFilter) : new TIMS_ProjectInterfaceAgreementViewModel() {  };
                       
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

            var vm = new TIMS_ProjectInterfaceAgreementViewModel(m);
            ViewBag.Lookups = GetLookups();

            return PartialView(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TIMS_ProjectInterfaceAgreementViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var m = vm.ToModel();
                m.ID = Guid.NewGuid(); 
                db.TIMS_ProjectInterfaceAgreement.Add(m);
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
        public ActionResult Update(TIMS_ProjectInterfaceAgreementViewModel vm)
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
        public ActionResult Delete(TIMS_ProjectInterfaceAgreementViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var em = Get(vm.ID);
                if (em == null)
                {
                    Response.StatusCode = HttpStatusCode.NotFound.GetHashCode();
                    return Json(new string[] { "Item not found." });
                }

                db.TIMS_ProjectInterfaceAgreement.Remove(em);
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
