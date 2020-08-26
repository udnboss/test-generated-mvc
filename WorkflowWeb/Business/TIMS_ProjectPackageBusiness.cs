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
    public partial class TIMS_ProjectPackageBusiness : BaseBusiness<TIMS_ProjectPackage>
    {
        public TIMS_ProjectPackageBusiness() { }
        public TIMS_ProjectPackageBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_ProjectPackage>> GetList(TIMS_ProjectPackage filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_ProjectPackage>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_ProjectPackage>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_ProjectPackage>>(o);
        }

        public override IQueryable<TIMS_ProjectPackage> GetIQueryable()
        {
            return ((IMSEntities)db).TIMS_ProjectPackage.Include(x => x.TIMS_Project)
				.Include(x => x.TIMS_ProjectContractor).AsQueryable();
        }

        public IQueryable<TIMS_ProjectPackage> GetIQueryable(TIMS_ProjectPackage filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ID == filter.ID);
					if (filter.Name != null && filter.Name.ToString() != default(Guid).ToString()) data = data.Where(x => x.Name == filter.Name);
					if (filter.ProjectID != null && filter.ProjectID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ProjectID == filter.ProjectID);
					if (filter.ProjectContractorID != null && filter.ProjectContractorID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ProjectContractorID == filter.ProjectContractorID);
            }

            return data;
        }
    }

}