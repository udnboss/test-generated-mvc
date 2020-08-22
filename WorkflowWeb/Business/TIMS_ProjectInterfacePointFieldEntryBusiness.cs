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
    public partial class TIMS_ProjectInterfacePointFieldEntryBusiness : BaseBusiness<TIMS_ProjectInterfacePointFieldEntry>
    {
        public TIMS_ProjectInterfacePointFieldEntryBusiness() { }
        public TIMS_ProjectInterfacePointFieldEntryBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_ProjectInterfacePointFieldEntry>> GetList(TIMS_ProjectInterfacePointFieldEntry filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_ProjectInterfacePointFieldEntry>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_ProjectInterfacePointFieldEntry>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_ProjectInterfacePointFieldEntry>>(o);
        }

        public override IQueryable<TIMS_ProjectInterfacePointFieldEntry> GetIQueryable()
        {
            return db.TIMS_ProjectInterfacePointFieldEntry.Include(x => x.TIMS_ProjectInterfacePointWorkflow)
				.Include(x => x.TIMS_ProjectDisciplineInterfaceTypeField).AsQueryable();
        }

        public IQueryable<TIMS_ProjectInterfacePointFieldEntry> GetIQueryable(TIMS_ProjectInterfacePointFieldEntry filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ID == filter.ID);
					if (filter.InterfacePointWorkflowID != null && filter.InterfacePointWorkflowID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.InterfacePointWorkflowID == filter.InterfacePointWorkflowID);
					if (filter.InterfaceTypeFieldID != null && filter.InterfaceTypeFieldID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.InterfaceTypeFieldID == filter.InterfaceTypeFieldID);
					if (filter.Value != null && filter.Value.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.Value == filter.Value);
            }

            return data;
        }
    }

}