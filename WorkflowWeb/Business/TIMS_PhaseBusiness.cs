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
    public partial class TIMS_PhaseBusiness : BaseBusiness<TIMS_Phase>
    {
        public TIMS_PhaseBusiness() { }
        public TIMS_PhaseBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_Phase>> GetList(TIMS_Phase filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_Phase>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_Phase>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_Phase>>(o);
        }

        public override IQueryable<TIMS_Phase> GetIQueryable()
        {
            return ((IMSEntities)db).TIMS_Phase.AsQueryable();
        }

        public IQueryable<TIMS_Phase> GetIQueryable(TIMS_Phase filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ID == filter.ID);
					if (filter.Name != null && filter.Name.ToString() != default(Guid).ToString()) data = data.Where(x => x.Name == filter.Name);
            }

            return data;
        }
    }

}