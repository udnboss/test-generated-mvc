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
    public partial class TIMS_ProjectInterfaceAgreementBusiness : BaseBusiness<TIMS_ProjectInterfaceAgreement>
    {
        public TIMS_ProjectInterfaceAgreementBusiness() { }
        public TIMS_ProjectInterfaceAgreementBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<TIMS_ProjectInterfaceAgreement>> GetList(TIMS_ProjectInterfaceAgreement filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_ProjectInterfaceAgreement>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_ProjectInterfaceAgreement>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_ProjectInterfaceAgreement>>(o);
        }

        public override IQueryable<TIMS_ProjectInterfaceAgreement> GetIQueryable()
        {
            return db.TIMS_ProjectInterfaceAgreement.Include(x => x.TIMS_ProjectInterfacePoint)
				.Include(x => x.TIMS_ProjectPackage)
				.Include(x => x.TIMS_ProjectPackage1).AsQueryable();
        }

        public IQueryable<TIMS_ProjectInterfaceAgreement> GetIQueryable(TIMS_ProjectInterfaceAgreement filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ID == filter.ID);
					if (filter.Name != null && filter.Name.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.Name == filter.Name);
					if (filter.InterfacePointID != null && filter.InterfacePointID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.InterfacePointID == filter.InterfacePointID);
					if (filter.RequestorPackageID != null && filter.RequestorPackageID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.RequestorPackageID == filter.RequestorPackageID);
					if (filter.ResponderPackageID != null && filter.ResponderPackageID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ResponderPackageID == filter.ResponderPackageID);
					if (filter.RequestorUserID != null && filter.RequestorUserID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.RequestorUserID == filter.RequestorUserID);
					if (filter.RequestorTechnicalContactID != null && filter.RequestorTechnicalContactID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.RequestorTechnicalContactID == filter.RequestorTechnicalContactID);
					if (filter.ResponderInterfaceManagerID != null && filter.ResponderInterfaceManagerID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ResponderInterfaceManagerID == filter.ResponderInterfaceManagerID);
					if (filter.ResponderTechnicalContactID != null && filter.ResponderTechnicalContactID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ResponderTechnicalContactID == filter.ResponderTechnicalContactID);
					if (filter.CreateDate != null && filter.CreateDate.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.CreateDate == filter.CreateDate);
					if (filter.NeedDate != null && filter.NeedDate.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.NeedDate == filter.NeedDate);
					if (filter.IssuedDate != null && filter.IssuedDate.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.IssuedDate == filter.IssuedDate);
					if (filter.AcceptedDate != null && filter.AcceptedDate.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.AcceptedDate == filter.AcceptedDate);
					if (filter.ResponseDate != null && filter.ResponseDate.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ResponseDate == filter.ResponseDate);
					if (filter.CloseDate != null && filter.CloseDate.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.CloseDate == filter.CloseDate);
            }

            return data;
        }
    }

}