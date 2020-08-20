using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkflowWeb.Models;

namespace WorkflowWeb.Controllers
{
    public class BaseController : Controller
    {
        protected IMSEntities db = new IMSEntities();
        public ContentResult JsonOut(object data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            return Content(json, "application/json");
        }
    }
}