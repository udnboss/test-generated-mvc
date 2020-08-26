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
    public partial class TIMS_ProjectCommentBusiness : BaseBusiness<TIMS_ProjectComment>
    {
        public TIMS_ProjectCommentBusiness() { }
        public TIMS_ProjectCommentBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_ProjectComment>> GetList(TIMS_ProjectComment filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_ProjectComment>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_ProjectComment>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_ProjectComment>>(o);
        }

        public override IQueryable<TIMS_ProjectComment> GetIQueryable()
        {
            return ((IMSEntities)db).TIMS_ProjectComment.Include(x => x.TIMS_ProjectInterfacePointWorkflow)
				.Include(x => x.TIMS_ProjectInterfaceAgreementWorkflow)
				.Include(x => x.TIMS_ProjectActionItemWorkflow)
				.Include(x => x.TIMS_User)
				.Include(x => x.TIMS_Project).AsQueryable();
        }

        public IQueryable<TIMS_ProjectComment> GetIQueryable(TIMS_ProjectComment filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ID == filter.ID);
					if (filter.Comment != null && filter.Comment.ToString() != default(Guid).ToString()) data = data.Where(x => x.Comment == filter.Comment);
					if (filter.ProjectInterfacePointWorkflowID != null && filter.ProjectInterfacePointWorkflowID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ProjectInterfacePointWorkflowID == filter.ProjectInterfacePointWorkflowID);
					if (filter.ProjectInterfaceAgreementWorkflowID != null && filter.ProjectInterfaceAgreementWorkflowID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ProjectInterfaceAgreementWorkflowID == filter.ProjectInterfaceAgreementWorkflowID);
					if (filter.ProjectActionItemWorkflowID != null && filter.ProjectActionItemWorkflowID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ProjectActionItemWorkflowID == filter.ProjectActionItemWorkflowID);
					if (filter.UserID != null && filter.UserID.ToString() != default(Guid).ToString()) data = data.Where(x => x.UserID == filter.UserID);
					if (filter.DateAdded != null && filter.DateAdded.ToString() != default(Guid).ToString()) data = data.Where(x => x.DateAdded == filter.DateAdded);
					if (filter.Name != null && filter.Name.ToString() != default(Guid).ToString()) data = data.Where(x => x.Name == filter.Name);
					if (filter.ProjectID != null && filter.ProjectID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ProjectID == filter.ProjectID);
            }

            return data;
        }
    }

}