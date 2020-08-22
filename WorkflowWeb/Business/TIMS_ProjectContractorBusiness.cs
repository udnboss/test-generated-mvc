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
    public partial class TIMS_ProjectContractorBusiness : BaseBusiness<TIMS_ProjectContractor>
    {
        public TIMS_ProjectContractorBusiness() { }
        public TIMS_ProjectContractorBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_ProjectContractor>> GetList(TIMS_ProjectContractor filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_ProjectContractor>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_ProjectContractor>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_ProjectContractor>>(o);
        }

        public override IQueryable<TIMS_ProjectContractor> GetIQueryable()
        {
            return db.TIMS_ProjectContractor.Include(x => x.TIMS_Project)
				.Include(x => x.TIMS_Contractor).AsQueryable();
        }

        public IQueryable<TIMS_ProjectContractor> GetIQueryable(TIMS_ProjectContractor filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ID == filter.ID);
					if (filter.Name != null && filter.Name.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.Name == filter.Name);
					if (filter.ProjectID != null && filter.ProjectID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ProjectID == filter.ProjectID);
					if (filter.ContractorID != null && filter.ContractorID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ContractorID == filter.ContractorID);
            }

            return data;
        }
    }

}