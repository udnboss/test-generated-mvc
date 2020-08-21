using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WorkflowWeb.Models;

namespace WorkflowWeb.Business
{
    public enum Operation
    {
        Select, Insert, Update, Delete
    }

    public enum State
    {
        Success,
        AccessDenied,
        NoRecordsAffected,
        NoRecordFound,
        Error
    }

    public class BaseBusiness<T>
    {
        protected IMSEntities db;

        public BaseBusiness()
        {
            db = new IMSEntities();
        }

        public BaseBusiness(IMSEntities db)
        {
            this.db = db;
        }

        public bool CheckAuthorization(object m, Operation o)
        {
            return true;
        }

        public IQueryable<T> GetIQueryable()
        {
            return db.Set(typeof(T)).AsQueryable().Cast<T>();
        }

        public IQueryable<T> GetIQueryable(Func<T, bool> where)
        {
            return GetIQueryable().Where(where).AsQueryable();
        }

        public BusinessResult<T> Get(Guid id)
        {
            var m = (T)db.Set(typeof(T)).Find(id);

            if(m == null)
            {
                return new BusinessResult<T> { Status = State.NoRecordFound, Data = m, RecordsAffected = 0 };
            }

            var o = Operation.Select;
            if (CheckAuthorization(m, o))
            {
                return new BusinessResult<T> { Status = State.Success, Data = m, RecordsAffected = 1 };
            }

            return AccessDenied<T>(o);
        }

        public BusinessResult<T> Edit(Guid id)
        {
            var o = Operation.Update;

            var result = Get(id);
            if (result.Status == State.Success)
            {                
                if (CheckAuthorization(result.Data, o))
                {
                    return result;
                }
            }

            return AccessDenied<T>(o);
        }

        public BusinessResult<T> New(T f)
        {
            var o = Operation.Insert;
            if (CheckAuthorization(f, o))
            {
                return new BusinessResult<T> { Status = State.Success, Data = f, RecordsAffected = 0 };
            }

            return AccessDenied<T>(o);
        }

        public BusinessResult<T> Insert(T m)
        {
            var result = New(m);
            if(result.Status == State.Success)
            {
                db.Set(typeof(T)).Add(m);
                result = Commit();
            }

            return result;
        }

        public BusinessResult<T> Update(T m)
        {
            var o = Operation.Update;
            if (CheckAuthorization(m, o))
            {
                db.Entry(m).State = EntityState.Modified;
                var result = Commit();
                return result;
            }

            return AccessDenied<T>(o);
        }

        public BusinessResult<T> Delete(T m)
        {
            var o = Operation.Delete;
            if (CheckAuthorization(m, o))
            {
                //db.Set(typeof(T)).Remove(m);
                var em = db.Entry(m);
                em.State = EntityState.Deleted;
                var result = Commit();
                return result;
            }

            return AccessDenied<T>(o);
        }

        public BusinessResult<T> Commit()
        {
            try
            {
                var affected = db.SaveChanges();
                var status = affected > 0 ? State.Success : State.NoRecordsAffected;
                return new BusinessResult<T> { Status = status, RecordsAffected = affected, Message = "" };
            }
            catch (Exception e)
            {
                return new BusinessResult<T> { Status = State.Error, RecordsAffected = 0, Message = e.Message + (e.InnerException != null ? "; " + e.InnerException.Message : "") };
            }
        }

        public BusinessResult<X> AccessDenied<X>(Operation o)
        {
            return new BusinessResult<X> { Status = State.AccessDenied, RecordsAffected = 0, Message = string.Format("Unauthorized to perform {0} operation", o) };
        }

    }
}