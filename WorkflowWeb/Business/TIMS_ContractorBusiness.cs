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
    public partial class TIMS_ContractorBusiness : BaseBusiness<TIMS_Contractor>
    {
        public TIMS_ContractorBusiness() { }
        public TIMS_ContractorBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_Contractor>> GetList(TIMS_Contractor filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_Contractor>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_Contractor>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_Contractor>>(o);
        }

        public override IQueryable<TIMS_Contractor> GetIQueryable()
        {
            return ((IMSEntities)db).TIMS_Contractor.AsQueryable();
        }

        public IQueryable<TIMS_Contractor> GetIQueryable(TIMS_Contractor filter)
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