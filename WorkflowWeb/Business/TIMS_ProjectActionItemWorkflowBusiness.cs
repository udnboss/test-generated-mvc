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
    public partial class TIMS_ProjectActionItemWorkflowBusiness : BaseBusiness<TIMS_ProjectActionItemWorkflow>
    {
        public TIMS_ProjectActionItemWorkflowBusiness() { }
        public TIMS_ProjectActionItemWorkflowBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_ProjectActionItemWorkflow>> GetList(TIMS_ProjectActionItemWorkflow filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_ProjectActionItemWorkflow>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_ProjectActionItemWorkflow>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_ProjectActionItemWorkflow>>(o);
        }

        public override IQueryable<TIMS_ProjectActionItemWorkflow> GetIQueryable()
        {
            return ((IMSEntities)db).TIMS_ProjectActionItemWorkflow.Include(x => x.TIMS_WorkflowType)
				.Include(x => x.TIMS_ProjectActionItem)
				.Include(x => x.TIMS_User).AsQueryable();
        }

        public IQueryable<TIMS_ProjectActionItemWorkflow> GetIQueryable(TIMS_ProjectActionItemWorkflow filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ID == filter.ID);
					if (filter.WorkflowTypeID != null && filter.WorkflowTypeID.ToString() != default(Guid).ToString()) data = data.Where(x => x.WorkflowTypeID == filter.WorkflowTypeID);
					if (filter.ActionItemID != null && filter.ActionItemID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ActionItemID == filter.ActionItemID);
					if (filter.DateInitiated != null && filter.DateInitiated.ToString() != default(Guid).ToString()) data = data.Where(x => x.DateInitiated == filter.DateInitiated);
					if (filter.LeadStateID != null && filter.LeadStateID.ToString() != default(Guid).ToString()) data = data.Where(x => x.LeadStateID == filter.LeadStateID);
					if (filter.InterfaceStateID != null && filter.InterfaceStateID.ToString() != default(Guid).ToString()) data = data.Where(x => x.InterfaceStateID == filter.InterfaceStateID);
					if (filter.UserID != null && filter.UserID.ToString() != default(Guid).ToString()) data = data.Where(x => x.UserID == filter.UserID);
					if (filter.IsDraft != null && filter.IsDraft.ToString() != default(Guid).ToString()) data = data.Where(x => x.IsDraft == filter.IsDraft);
            }

            return data;
        }
    }

}