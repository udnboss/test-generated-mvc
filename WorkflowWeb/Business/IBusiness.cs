using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WorkflowWeb.Models;

namespace WorkflowWeb.Business
{
    public interface IBusiness<T>
    {
        bool CheckAuthorization(object m, Operation o);

        IQueryable<T> GetIQueryable();

        IQueryable<T> GetIQueryable(Func<T, bool> where);

        BusinessResult<T> Get(Guid id);

        BusinessResult<T> Insert(T m);

        BusinessResult<T> Update(T m);

        BusinessResult<T> Delete(T m);

        BusinessResult<T> Commit();

        BusinessResult<T> AccessDenied(Operation o);
    }
}