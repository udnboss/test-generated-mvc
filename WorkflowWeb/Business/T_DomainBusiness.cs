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
    public partial class T_DomainBusiness : BaseBusiness<T_Domain>
    {
        public T_DomainBusiness() { }
        public T_DomainBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<T_Domain>> GetList(T_Domain filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<T_Domain>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<T_Domain>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<T_Domain>>(o);
        }

        public override IQueryable<T_Domain> GetIQueryable()
        {
            return ((COMMENTSEntities)db).T_Domain.AsQueryable();
        }

        public IQueryable<T_Domain> GetIQueryable(T_Domain filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ID == filter.ID);
					if (filter.Host != null && filter.Host.ToString() != default(Guid).ToString()) data = data.Where(x => x.Host == filter.Host);
					if (filter.Port != null && filter.Port.ToString() != default(Guid).ToString()) data = data.Where(x => x.Port == filter.Port);
            }

            return data;
        }
    }

}