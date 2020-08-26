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
    public partial class TIMS_ProjectAreaBusiness : BaseBusiness<TIMS_ProjectArea>
    {
        public TIMS_ProjectAreaBusiness() { }
        public TIMS_ProjectAreaBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_ProjectArea>> GetList(TIMS_ProjectArea filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_ProjectArea>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_ProjectArea>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_ProjectArea>>(o);
        }

        public override IQueryable<TIMS_ProjectArea> GetIQueryable()
        {
            return ((IMSEntities)db).TIMS_ProjectArea.Include(x => x.TIMS_Project).AsQueryable();
        }

        public IQueryable<TIMS_ProjectArea> GetIQueryable(TIMS_ProjectArea filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ID == filter.ID);
					if (filter.Name != null && filter.Name.ToString() != default(Guid).ToString()) data = data.Where(x => x.Name == filter.Name);
					if (filter.ProjectID != null && filter.ProjectID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ProjectID == filter.ProjectID);
            }

            return data;
        }
    }

}