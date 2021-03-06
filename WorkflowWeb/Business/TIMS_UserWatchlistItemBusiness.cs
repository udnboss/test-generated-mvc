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
    public partial class TIMS_UserWatchlistItemBusiness : BaseBusiness<TIMS_UserWatchlistItem>
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

        public override IQueryable<TIMS_UserWatchlistItem> GetIQueryable()
        {
            return ((IMSEntities)db).TIMS_UserWatchlistItem.Include(x => x.TIMS_User)
				.Include(x => x.TIMS_ProjectInterfacePoint)
				.Include(x => x.TIMS_ProjectInterfaceAgreement)
				.Include(x => x.TIMS_ProjectActionItem).AsQueryable();
        }

        public IQueryable<TIMS_UserWatchlistItem> GetIQueryable(TIMS_UserWatchlistItem filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID != default(Guid)) data = data.Where(x => x.ID == filter.ID);
					if (filter.UserID != null && filter.UserID != default(Guid)) data = data.Where(x => x.UserID == filter.UserID);
					if (filter.ProjectInterfacePointID != null && filter.ProjectInterfacePointID != default(Guid)) data = data.Where(x => x.ProjectInterfacePointID == filter.ProjectInterfacePointID);
					if (filter.ProjectInterfaceAgreementID != null && filter.ProjectInterfaceAgreementID != default(Guid)) data = data.Where(x => x.ProjectInterfaceAgreementID == filter.ProjectInterfaceAgreementID);
					if (filter.ProjectActionItemID != null && filter.ProjectActionItemID != default(Guid)) data = data.Where(x => x.ProjectActionItemID == filter.ProjectActionItemID);
            }

            return data;
        }
    }

}