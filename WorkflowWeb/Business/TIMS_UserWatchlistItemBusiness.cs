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
    public class TIMS_UserWatchlistItemBusiness : BaseBusiness<TIMS_UserWatchlistItem>
    {
        public TIMS_UserWatchlistItemBusiness() { }
        public TIMS_UserWatchlistItemBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_UserWatchlistItem>> GetList(TIMS_UserWatchlistItem filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_UserWatchlistItem>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_UserWatchlistItem>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_UserWatchlistItem>>(o);
        }

        private IQueryable<TIMS_UserWatchlistItem> GetIQueryable(TIMS_UserWatchlistItem filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ID == filter.ID);
					if (filter.UserID != null && filter.UserID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.UserID == filter.UserID);
					if (filter.ProjectInterfacePointID != null && filter.ProjectInterfacePointID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ProjectInterfacePointID == filter.ProjectInterfacePointID);
					if (filter.ProjectInterfaceAgreementID != null && filter.ProjectInterfaceAgreementID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ProjectInterfaceAgreementID == filter.ProjectInterfaceAgreementID);
					if (filter.ProjectActionItemID != null && filter.ProjectActionItemID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ProjectActionItemID == filter.ProjectActionItemID);
            }

            return data;
        }
    }

}