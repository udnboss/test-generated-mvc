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
    public partial class TIMS_RoleBusiness : BaseBusiness<TIMS_Role>
    {
        public TIMS_RoleBusiness() { }
        public TIMS_RoleBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_Role>> GetList(TIMS_Role filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_Role>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_Role>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_Role>>(o);
        }

        public override IQueryable<TIMS_Role> GetIQueryable()
        {
            return ((IMSEntities)db).TIMS_Role.AsQueryable();
        }

        public IQueryable<TIMS_Role> GetIQueryable(TIMS_Role filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID != default(Guid)) data = data.Where(x => x.ID == filter.ID);
					if (filter.Name != null) data = data.Where(x => x.Name == filter.Name);
            }

            return data;
        }
    }

}