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
    public partial class TIMS_ProjectInterfacePointWorkflowBusiness : BaseBusiness<TIMS_ProjectInterfacePointWorkflow>
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

        public override IQueryable<TIMS_ProjectInterfacePointWorkflow> GetIQueryable()
        {
            return ((IMSEntities)db).TIMS_ProjectInterfacePointWorkflow.Include(x => x.TIMS_WorkflowType)
				.Include(x => x.TIMS_WorkflowState)
				.Include(x => x.TIMS_WorkflowState1)
				.Include(x => x.TIMS_WorkflowState2)
				.Include(x => x.TIMS_ProjectArea)
				.Include(x => x.TIMS_ProjectPhysicalArea)
				.Include(x => x.TIMS_Phase)
				.Include(x => x.TIMS_ProjectDisciplineInterfaceType)
				.Include(x => x.TIMS_User).AsQueryable();
        }

        public IQueryable<TIMS_ProjectInterfacePointWorkflow> GetIQueryable(TIMS_ProjectInterfacePointWorkflow filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID != default(Guid)) data = data.Where(x => x.ID == filter.ID);
					if (filter.WorkflowTypeID != null) data = data.Where(x => x.WorkflowTypeID == filter.WorkflowTypeID);
					if (filter.InterfacePointID != null && filter.InterfacePointID != default(Guid)) data = data.Where(x => x.InterfacePointID == filter.InterfacePointID);
					if (filter.DateInitiated != null && filter.DateInitiated != default(DateTime)) data = data.Where(x => x.DateInitiated == filter.DateInitiated);
					if (filter.LeadStateID != null) data = data.Where(x => x.LeadStateID == filter.LeadStateID);
					if (filter.InterfaceStateID != null) data = data.Where(x => x.InterfaceStateID == filter.InterfaceStateID);
					if (filter.SupportStateID != null) data = data.Where(x => x.SupportStateID == filter.SupportStateID);
					if (filter.ProjectAreaID != null && filter.ProjectAreaID != default(Guid)) data = data.Where(x => x.ProjectAreaID == filter.ProjectAreaID);
					if (filter.ProjectPhysicalAreaID != null && filter.ProjectPhysicalAreaID != default(Guid)) data = data.Where(x => x.ProjectPhysicalAreaID == filter.ProjectPhysicalAreaID);
					if (filter.PhaseID != null) data = data.Where(x => x.PhaseID == filter.PhaseID);
					if (filter.InterfaceTypeID != null && filter.InterfaceTypeID != default(Guid)) data = data.Where(x => x.InterfaceTypeID == filter.InterfaceTypeID);
					if (filter.UserID != null && filter.UserID != default(Guid)) data = data.Where(x => x.UserID == filter.UserID);
					if (filter.IsDraft != null) data = data.Where(x => x.IsDraft == filter.IsDraft);
            }

            return data;
        }
    }

}