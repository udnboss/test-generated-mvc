
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
    public class TIMS_UserWatchlistItemController : BaseController
    {
        public List<TIMS_UserWatchlistItemViewModel> GetList()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.TIMS_UserWatchlistItem.Include(x => x.TIMS_User)
				.Include(x => x.TIMS_ProjectInterfacePoint)
				.Include(x => x.TIMS_ProjectInterfaceAgreement)
				.Include(x => x.TIMS_ProjectActionItem).AsQueryable();

            var ui_route_filter = (RouteData.Values["ui_route_filter"] ?? Request.QueryString["ui_route_filter"]) as string;
            if (!string.IsNullOrEmpty(ui_route_filter))
            {
                try
                {
                    var bytes = Convert.FromBase64String(ui_route_filter);
                    ui_route_filter = System.Text.Encoding.ASCII.GetString(bytes);

                    var filter = JsonConvert.DeserializeObject<TIMS_UserWatchlistItemViewModel>(ui_route_filter).ToModel();

                    if (filter.ID != null && filter.ID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ID == filter.ID);
					if (filter.UserID != null && filter.UserID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.UserID == filter.UserID);
					if (filter.ProjectInterfacePointID != null && filter.ProjectInterfacePointID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ProjectInterfacePointID == filter.ProjectInterfacePointID);
					if (filter.ProjectInterfaceAgreementID != null && filter.ProjectInterfaceAgreementID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ProjectInterfaceAgreementID == filter.ProjectInterfaceAgreementID);
					if (filter.ProjectActionItemID != null && filter.ProjectActionItemID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ProjectActionItemID == filter.ProjectActionItemID);                        
                }
                catch
                {

                }
            }

            return data.ToList().Select(x => new TIMS_UserWatchlistItemViewModel(x, true)).ToList();
        }

        public TIMS_UserWatchlistItem Get(Guid id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.TIMS_UserWatchlistItem.Include(x => x.TIMS_User)
				.Include(x => x.TIMS_ProjectInterfacePoint)
				.Include(x => x.TIMS_ProjectInterfaceAgreement)
				.Include(x => x.TIMS_ProjectActionItem).FirstOrDefault(x=> x.ID == id);
        }

        public Dictionary<string, object> GetLookups()
        {
            return new Dictionary<string, object> {
                {"ProjectActionItemID", db.TIMS_ProjectActionItem.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) },
				{"ProjectInterfaceAgreementID", db.TIMS_ProjectInterfaceAgreement.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) },
				{"ProjectInterfacePointID", db.TIMS_ProjectInterfacePoint.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.ID.ToString() }) },
				{"UserID", db.TIMS_User.Select(x => new  SelectListItem { Value = x.ID.ToString(), Text = x.Name.ToString() }) }
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

            var vm = new TIMS_UserWatchlistItemViewModel(m, true);

            return PartialView(vm);
        }

        public ActionResult New()
        {
            var vm = new TIMS_UserWatchlistItemViewModel() {  };
                       
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

            var vm = new TIMS_UserWatchlistItemViewModel(m);
            ViewBag.Lookups = GetLookups();

            return PartialView(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TIMS_UserWatchlistItemViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var m = vm.ToModel();
                m.ID = Guid.NewGuid(); 
                db.TIMS_UserWatchlistItem.Add(m);
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
        public ActionResult Update(TIMS_UserWatchlistItemViewModel vm)
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
        public ActionResult Delete(TIMS_UserWatchlistItemViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var em = Get(vm.ID);
                if (em == null)
                {
                    Response.StatusCode = HttpStatusCode.NotFound.GetHashCode();
                    return Json(new string[] { "Item not found." });
                }

                db.TIMS_UserWatchlistItem.Remove(em);
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
