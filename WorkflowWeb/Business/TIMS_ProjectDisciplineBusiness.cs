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
    public class TIMS_ProjectDisciplineBusiness : BaseBusiness<TIMS_ProjectDiscipline>
    {
        public TIMS_ProjectDisciplineBusiness() { }
        public TIMS_ProjectDisciplineBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_ProjectDiscipline>> GetList(TIMS_ProjectDiscipline filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_ProjectDiscipline>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_ProjectDiscipline>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_ProjectDiscipline>>(o);
        }

        private IQueryable<TIMS_ProjectDiscipline> GetIQueryable(TIMS_ProjectDiscipline filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ID == filter.ID);
					if (filter.Name != null && filter.Name.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.Name == filter.Name);
					if (filter.ProjectID != null && filter.ProjectID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ProjectID == filter.ProjectID);
					if (filter.DisciplineID != null && filter.DisciplineID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.DisciplineID == filter.DisciplineID);
            }

            return data;
        }
    }

}