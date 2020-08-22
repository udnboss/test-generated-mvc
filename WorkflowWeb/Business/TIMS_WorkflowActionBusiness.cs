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
    public partial class TIMS_WorkflowActionBusiness : BaseBusiness<TIMS_WorkflowAction>
    {
        public TIMS_WorkflowActionBusiness() { }
        public TIMS_WorkflowActionBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_WorkflowAction>> GetList(TIMS_WorkflowAction filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_WorkflowAction>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_WorkflowAction>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_WorkflowAction>>(o);
        }

        public override IQueryable<TIMS_WorkflowAction> GetIQueryable()
        {
            return db.TIMS_WorkflowAction.AsQueryable();
        }

        public IQueryable<TIMS_WorkflowAction> GetIQueryable(TIMS_WorkflowAction filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ID == filter.ID);
					if (filter.Name != null && filter.Name.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.Name == filter.Name);
            }

            return data;
        }
    }

}