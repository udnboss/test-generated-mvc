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
    public partial class TIMS_ProjectAttachmentBusiness : BaseBusiness<TIMS_ProjectAttachment>
    {
        public TIMS_ProjectAttachmentBusiness() { }
        public TIMS_ProjectAttachmentBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_ProjectAttachment>> GetList(TIMS_ProjectAttachment filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_ProjectAttachment>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_ProjectAttachment>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_ProjectAttachment>>(o);
        }

        public override IQueryable<TIMS_ProjectAttachment> GetIQueryable()
        {
            return db.TIMS_ProjectAttachment.Include(x => x.TIMS_ProjectInterfacePointWorkflow)
				.Include(x => x.TIMS_ProjectInterfaceAgreementWorkflow)
				.Include(x => x.TIMS_ProjectActionItemWorkflow)
				.Include(x => x.TIMS_ProjectPackage)
				.Include(x => x.TIMS_User).AsQueryable();
        }

        public IQueryable<TIMS_ProjectAttachment> GetIQueryable(TIMS_ProjectAttachment filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ID == filter.ID);
					if (filter.Name != null && filter.Name.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.Name == filter.Name);
					if (filter.ProjectInterfacePointWorkflowID != null && filter.ProjectInterfacePointWorkflowID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ProjectInterfacePointWorkflowID == filter.ProjectInterfacePointWorkflowID);
					if (filter.ProjectInterfaceAgreementWorkflowID != null && filter.ProjectInterfaceAgreementWorkflowID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ProjectInterfaceAgreementWorkflowID == filter.ProjectInterfaceAgreementWorkflowID);
					if (filter.ProjectActionItemWorkflowID != null && filter.ProjectActionItemWorkflowID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ProjectActionItemWorkflowID == filter.ProjectActionItemWorkflowID);
					if (filter.PackageID != null && filter.PackageID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.PackageID == filter.PackageID);
					if (filter.Filename != null && filter.Filename.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.Filename == filter.Filename);
					if (filter.DateUploaded != null && filter.DateUploaded.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.DateUploaded == filter.DateUploaded);
					if (filter.UserID != null && filter.UserID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.UserID == filter.UserID);
            }

            return data;
        }
    }

}