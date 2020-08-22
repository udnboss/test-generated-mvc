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
    public class TIMS_ProjectInterfacePointWorkflowBusiness : BaseBusiness<TIMS_ProjectInterfacePointWorkflow>
    {
        public TIMS_ProjectInterfacePointWorkflowBusiness() { }
        public TIMS_ProjectInterfacePointWorkflowBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_ProjectInterfacePointWorkflow>> GetList(TIMS_ProjectInterfacePointWorkflow filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_ProjectInterfacePointWorkflow>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_ProjectInterfacePointWorkflow>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_ProjectInterfacePointWorkflow>>(o);
        }

        private IQueryable<TIMS_ProjectInterfacePointWorkflow> GetIQueryable(TIMS_ProjectInterfacePointWorkflow filter)
        {
            var data = GetIQueryable();

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

            return data;
        }
    }

}