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
    public partial class T_UploadBusiness : BaseBusiness<T_Upload>
    {
        public T_UploadBusiness() { }
        public T_UploadBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<T_Upload>> GetList(T_Upload filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<T_Upload>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<T_Upload>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<T_Upload>>(o);
        }

        public override IQueryable<T_Upload> GetIQueryable()
        {
            return ((COMMENTSEntities)db).T_Upload.AsQueryable();
        }

        public IQueryable<T_Upload> GetIQueryable(T_Upload filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ID == filter.ID);
					if (filter.Name != null && filter.Name.ToString() != default(Guid).ToString()) data = data.Where(x => x.Name == filter.Name);
					if (filter.Path != null && filter.Path.ToString() != default(Guid).ToString()) data = data.Where(x => x.Path == filter.Path);
					if (filter.Size != null && filter.Size.ToString() != default(Guid).ToString()) data = data.Where(x => x.Size == filter.Size);
					if (filter.UploadDate != null && filter.UploadDate.ToString() != default(Guid).ToString()) data = data.Where(x => x.UploadDate == filter.UploadDate);
					if (filter.ParentID != null && filter.ParentID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ParentID == filter.ParentID);
            }

            return data;
        }
    }

}