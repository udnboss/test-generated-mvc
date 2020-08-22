using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using WorkflowWeb.Models;

namespace WorkflowWeb.Business
{
    public partial class TIMS_ProjectInterfacePointBusiness : BaseBusiness<TIMS_ProjectInterfacePoint>
    {
        public TIMS_ProjectInterfacePointBusiness() { }
        public TIMS_ProjectInterfacePointBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_ProjectInterfacePoint>> GetList(TIMS_ProjectInterfacePoint filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_ProjectInterfacePoint>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_ProjectInterfacePoint>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_ProjectInterfacePoint>>(o);
        }

        public override IQueryable<TIMS_ProjectInterfacePoint> GetIQueryable()
        {
            return db.TIMS_ProjectInterfacePoint.Include(x => x.TIMS_Project)
				.Include(x => x.TIMS_ProjectPackage)
				.Include(x => x.TIMS_ProjectPackage1)
				.Include(x => x.TIMS_ProjectPackage2).AsQueryable();
        }

        public IQueryable<TIMS_ProjectInterfacePoint> GetIQueryable(TIMS_ProjectInterfacePoint filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ID == filter.ID);
					if (filter.ProjectID != null && filter.ProjectID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ProjectID == filter.ProjectID);
					if (filter.LeadPackageID != null && filter.LeadPackageID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.LeadPackageID == filter.LeadPackageID);
					if (filter.InterfacePackageID != null && filter.InterfacePackageID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.InterfacePackageID == filter.InterfacePackageID);
					if (filter.SupportPackageID != null && filter.SupportPackageID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.SupportPackageID == filter.SupportPackageID);
					if (filter.CreateDate != null && filter.CreateDate.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.CreateDate == filter.CreateDate);
					if (filter.IssueDate != null && filter.IssueDate.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.IssueDate == filter.IssueDate);
					if (filter.FinalizeDate != null && filter.FinalizeDate.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.FinalizeDate == filter.FinalizeDate);
					if (filter.CloseDate != null && filter.CloseDate.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.CloseDate == filter.CloseDate);
            }

            return data;
        }
    }

}