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
    public class TIMS_ProjectActionItemBusiness : BaseBusiness<TIMS_ProjectActionItem>
    {
        public TIMS_ProjectActionItemBusiness() { }
        public TIMS_ProjectActionItemBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_ProjectActionItem>> GetList(TIMS_ProjectActionItem filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_ProjectActionItem>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_ProjectActionItem>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_ProjectActionItem>>(o);
        }

        private IQueryable<TIMS_ProjectActionItem> GetIQueryable(TIMS_ProjectActionItem filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ID == filter.ID);
					if (filter.Name != null && filter.Name.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.Name == filter.Name);
					if (filter.ProjectID != null && filter.ProjectID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ProjectID == filter.ProjectID);
					if (filter.InterfaceAgreementID != null && filter.InterfaceAgreementID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.InterfaceAgreementID == filter.InterfaceAgreementID);
            }

            return data;
        }
    }

}