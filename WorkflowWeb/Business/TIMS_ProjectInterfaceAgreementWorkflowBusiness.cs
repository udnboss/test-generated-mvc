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
    public class TIMS_ProjectInterfaceAgreementWorkflowBusiness : BaseBusiness<TIMS_ProjectInterfaceAgreementWorkflow>
    {
        public TIMS_ProjectInterfaceAgreementWorkflowBusiness() { }
        public TIMS_ProjectInterfaceAgreementWorkflowBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_ProjectInterfaceAgreementWorkflow>> GetList(TIMS_ProjectInterfaceAgreementWorkflow filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_ProjectInterfaceAgreementWorkflow>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_ProjectInterfaceAgreementWorkflow>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_ProjectInterfaceAgreementWorkflow>>(o);
        }

        private IQueryable<TIMS_ProjectInterfaceAgreementWorkflow> GetIQueryable(TIMS_ProjectInterfaceAgreementWorkflow filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
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

            return data;
        }
    }

}