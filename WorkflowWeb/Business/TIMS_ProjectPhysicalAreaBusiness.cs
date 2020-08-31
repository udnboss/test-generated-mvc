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
    public partial class TIMS_ProjectPhysicalAreaBusiness : BaseBusiness<TIMS_ProjectPhysicalArea>
    {
        public TIMS_ProjectPhysicalAreaBusiness() { }
        public TIMS_ProjectPhysicalAreaBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_ProjectPhysicalArea>> GetList(TIMS_ProjectPhysicalArea filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_ProjectPhysicalArea>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_ProjectPhysicalArea>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_ProjectPhysicalArea>>(o);
        }

        public override IQueryable<TIMS_ProjectPhysicalArea> GetIQueryable()
        {
            return ((IMSEntities)db).TIMS_ProjectPhysicalArea.Include(x => x.TIMS_Project).AsQueryable();
        }

        public IQueryable<TIMS_ProjectPhysicalArea> GetIQueryable(TIMS_ProjectPhysicalArea filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID != default(Guid)) data = data.Where(x => x.ID == filter.ID);
					if (filter.Name != null) data = data.Where(x => x.Name == filter.Name);
					if (filter.ProjectID != null && filter.ProjectID != default(Guid)) data = data.Where(x => x.ProjectID == filter.ProjectID);
            }

            return data;
        }
    }

}