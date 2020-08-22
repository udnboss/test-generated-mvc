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
    public class TIMS_ProjectDisciplineInterfaceTypeFieldBusiness : BaseBusiness<TIMS_ProjectDisciplineInterfaceTypeField>
    {
        public TIMS_ProjectDisciplineInterfaceTypeFieldBusiness() { }
        public TIMS_ProjectDisciplineInterfaceTypeFieldBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_ProjectDisciplineInterfaceTypeField>> GetList(TIMS_ProjectDisciplineInterfaceTypeField filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_ProjectDisciplineInterfaceTypeField>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_ProjectDisciplineInterfaceTypeField>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_ProjectDisciplineInterfaceTypeField>>(o);
        }

        private IQueryable<TIMS_ProjectDisciplineInterfaceTypeField> GetIQueryable(TIMS_ProjectDisciplineInterfaceTypeField filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ID == filter.ID);
					if (filter.Name != null && filter.Name.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.Name == filter.Name);
					if (filter.InterfaceTypeID != null && filter.InterfaceTypeID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.InterfaceTypeID == filter.InterfaceTypeID);
            }

            return data;
        }
    }

}