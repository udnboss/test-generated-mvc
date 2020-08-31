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
using WorkflowWeb.ViewModels;

namespace WorkflowWeb.Business
{
    public partial class T_CommentBusiness : BaseBusiness<T_Comment>
    {
        public T_CommentBusiness() { }
        public T_CommentBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<T_Comment>> GetList(T_Comment filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<T_Comment>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<T_Comment>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<T_Comment>>(o);
        }

        public override IQueryable<T_Comment> GetIQueryable()
        {
            return ((COMMENTSEntities)db).T_Comment.Include(x => x.T_Domain)
                .Include(x => x.T_Comment1).AsQueryable();
        }

        public IQueryable<T_Comment> GetIQueryable(T_Comment filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID != default(Guid)) data = data.Where(x => x.ID == filter.ID);
                if (filter.DomainID != null) data = data.Where(x => x.DomainID == filter.DomainID);
                if (filter.Path != null) data = data.Where(x => x.Path == filter.Path);
                if (filter.IP != null) data = data.Where(x => x.IP == filter.IP);
                if (filter.Name != null) data = data.Where(x => x.Name == filter.Name);
                if (filter.Comment != null) data = data.Where(x => x.Comment == filter.Comment);
                if (filter.ParentID != null && filter.ParentID != default(Guid)) data = data.Where(x => x.ParentID == filter.ParentID);
                if (filter.DatePosted != null && filter.DatePosted != default(DateTime)) data = data.Where(x => x.DatePosted == filter.DatePosted);
                if (filter.QueryString != null) data = data.Where(x => x.QueryString == filter.QueryString);
            }

            return data;
        }

        public Table GetSchema()
        {
            var t = new Table
            {
                Columns = new Dictionary<string, Column>
                {
                    {"ID", new Column { Name = "ID", DisplayName = "ID", Type = "Guid", Component = "v-form-input-hidden" } },
                    {"DomainID", new Column { Name = "DomainID", DisplayName = "Domain", Type = "String", Component = "v-form-select" } },
                    {"Path", new Column { Name = "Path", DisplayName = "Path", Type = "String", Component = "v-form-input" } },
                    {"IP", new Column { Name = "IP", DisplayName = "IP", Type = "String", Component = "v-form-input" } },
                    {"Name", new Column { Name = "Name", DisplayName = "Name", Type = "String", Component = "v-form-input" } },
                    {"Comment", new Column { Name = "Comment", DisplayName = "Comment", Type = "String", Component = "v-form-textarea" } },
                    {"DatePosted", new Column { Name = "DatePosted", DisplayName = "Date Posted", Type = "Date", Component = "v-form-input-date" } },
                    {"QueryString", new Column { Name = "QueryString", DisplayName = "Query String", Type = "String", Component = "v-form-input" } }
                }
            };

            return t;
        }
    }

}