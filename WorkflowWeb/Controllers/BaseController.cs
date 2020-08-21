using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkflowWeb.Business;
using WorkflowWeb.Models;

namespace WorkflowWeb.Controllers
{
    public class BaseController : Controller
    {
        protected IMSEntities db = new IMSEntities();

        protected ContentResult JsonOut(object data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            return Content(json, "application/json");
        }

        protected HttpStatusCode GetResponseCode<T>(BusinessResult<T> result)
        {
            switch (result.Status)
            {
                case State.AccessDenied:
                    return HttpStatusCode.Forbidden;
                case State.Error:
                    return HttpStatusCode.InternalServerError;
                case State.NoRecordFound:
                case State.NoRecordsAffected:
                    return HttpStatusCode.NotFound;
                case State.Success:
                    return HttpStatusCode.OK;
                default:
                    return HttpStatusCode.Conflict;                    
            }
        }
    }
}