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
    public partial class TIMS_ProjectDisciplineInterfaceTypeBusiness : BaseBusiness<TIMS_ProjectDisciplineInterfaceType>
    {
        public TIMS_ProjectDisciplineInterfaceTypeBusiness() { }
        public TIMS_ProjectDisciplineInterfaceTypeBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_ProjectDisciplineInterfaceType>> GetList(TIMS_ProjectDisciplineInterfaceType filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_ProjectDisciplineInterfaceType>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_ProjectDisciplineInterfaceType>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_ProjectDisciplineInterfaceType>>(o);
        }

        public override IQueryable<TIMS_ProjectDisciplineInterfaceType> GetIQueryable()
        {
            return ((IMSEntities)db).TIMS_ProjectDisciplineInterfaceType.Include(x => x.TIMS_ProjectDiscipline).AsQueryable();
        }

        public IQueryable<TIMS_ProjectDisciplineInterfaceType> GetIQueryable(TIMS_ProjectDisciplineInterfaceType filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ID == filter.ID);
					if (filter.Name != null && filter.Name.ToString() != default(Guid).ToString()) data = data.Where(x => x.Name == filter.Name);
					if (filter.ProjectIDisciplineID != null && filter.ProjectIDisciplineID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ProjectIDisciplineID == filter.ProjectIDisciplineID);
            }

            return data;
        }
    }

}