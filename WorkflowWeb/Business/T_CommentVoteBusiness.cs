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
    public partial class T_CommentVoteBusiness : BaseBusiness<T_CommentVote>
    {
        public T_CommentVoteBusiness() { }
        public T_CommentVoteBusiness(DbContext db, string user) : base(db, user) { }
        public override BusinessResult<List<T_CommentVote>> GetList(T_CommentVote filter)
        {
            var o = Operation.Select;

            if (CheckAuthorization(filter, o, user))
            {
                try
                {
                    var data = GetIQueryable(filter).ToList();
                    return new BusinessResult<List<T_CommentVote>> { Status = State.Success, RecordsAffected = data.Count, Data = data };
                }

                catch (Exception e)
                {
                    return new BusinessResult<List<T_CommentVote>> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
                }
            }

            return AccessDenied<List<T_CommentVote>>(o);
        }

        public override IQueryable<T_CommentVote> GetIQueryable()
        {
            return ((COMMENTSEntities)db).T_CommentVote.Include(x => x.T_Comment).AsQueryable();
        }

        public IQueryable<T_CommentVote> GetIQueryable(T_CommentVote filter)
        {
            var data = GetIQueryable();

            if (filter != null)
            {
                if (filter.ID != null && filter.ID.ToString() != default(Guid).ToString()) data = data.Where(x => x.ID == filter.ID);
					if (filter.Vote != null && filter.Vote.ToString() != default(Guid).ToString()) data = data.Where(x => x.Vote == filter.Vote);
					if (filter.IP != null && filter.IP.ToString() != default(Guid).ToString()) data = data.Where(x => x.IP == filter.IP);
					if (filter.CommentID != null && filter.CommentID.ToString() != default(Guid).ToString()) data = data.Where(x => x.CommentID == filter.CommentID);
            }

            return data;
        }
    }

}