﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;
using WorkflowWeb.Models;

namespace WorkflowWeb.Business
{
    public partial class TIMS_ProjectBusiness : BaseBusiness<TIMS_Project>
    {
        public TIMS_ProjectBusiness(IMSEntities db) : base(db)
        {

        }
        public BusinessResult<List<TIMS_Project>> GetList(TIMS_Project filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<TIMS_Project>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<TIMS_Project>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<TIMS_Project>>(o);
        }

        private IQueryable<TIMS_Project> GetIQueryable(TIMS_Project filter)
        {            
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.ID == filter.ID);
                if (filter.Name != null && filter.Name.ToString() != "00000000-0000-0000-0000-000000000000") data = data.Where(x => x.Name == filter.Name);
            }

            return data;           
        }
    }
}