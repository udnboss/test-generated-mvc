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
    public partial class TIMS_WorkflowTypeBusiness : BaseBusiness<TIMS_WorkflowType>
    {
        public TIMS_WorkflowTypeBusiness() { }
        public TIMS_WorkflowTypeBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_WorkflowType>> GetList(TIMS_WorkflowType filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_WorkflowType>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_WorkflowType>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_WorkflowType>>(o);
        }

        public override IQueryable<TIMS_WorkflowType> GetIQueryable()
        {
            return ((IMSEntities)db).TIMS_WorkflowType.AsQueryable();
        }

        public IQueryable<TIMS_WorkflowType> GetIQueryable(TIMS_WorkflowType filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null) data = data.Where(x => x.ID == filter.ID);
					if (filter.Name != null) data = data.Where(x => x.Name == filter.Name);
            }

            return data;
        }
    }

}