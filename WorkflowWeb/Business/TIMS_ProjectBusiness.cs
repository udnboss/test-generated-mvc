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
    public partial class TIMS_ProjectBusiness : BaseBusiness<TIMS_Project>
    {
        public TIMS_ProjectBusiness() { }
        public TIMS_ProjectBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_Project>> GetList(TIMS_Project filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_Project>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_Project>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_Project>>(o);
        }

        public override IQueryable<TIMS_Project> GetIQueryable()
        {
            return ((IMSEntities)db).TIMS_Project.AsQueryable();
        }

        public IQueryable<TIMS_Project> GetIQueryable(TIMS_Project filter)
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