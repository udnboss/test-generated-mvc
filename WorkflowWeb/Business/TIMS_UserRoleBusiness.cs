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
    public partial class TIMS_UserRoleBusiness : BaseBusiness<TIMS_UserRole>
    {
        public TIMS_UserRoleBusiness() { }
        public TIMS_UserRoleBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_UserRole>> GetList(TIMS_UserRole filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_UserRole>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_UserRole>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_UserRole>>(o);
        }

        public override IQueryable<TIMS_UserRole> GetIQueryable()
        {
            return ((IMSEntities)db).TIMS_UserRole.Include(x => x.TIMS_User)
				.Include(x => x.TIMS_Project)
				.Include(x => x.TIMS_ProjectPackage)
				.Include(x => x.TIMS_Role).AsQueryable();
        }

        public IQueryable<TIMS_UserRole> GetIQueryable(TIMS_UserRole filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ID == filter.ID);
					if (filter.UserID != null && filter.UserID.ToString() != default(Guid).ToString()) data = data.Where(x => x.UserID == filter.UserID);
					if (filter.ProjectID != null && filter.ProjectID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ProjectID == filter.ProjectID);
					if (filter.ProjectPackageID != null && filter.ProjectPackageID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ProjectPackageID == filter.ProjectPackageID);
					if (filter.RoleID != null && filter.RoleID.ToString() != default(Guid).ToString()) data = data.Where(x => x.RoleID == filter.RoleID);
            }

            return data;
        }
    }

}