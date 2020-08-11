using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WorkflowWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //see for a tested implementation.
        //https://stackoverflow.com/questions/42919389/uploading-files-in-chunks-with-blueimp-in-asp-net-mvc

        [HttpPost]
        public ActionResult Upload()
        {
            var fileName = Request.Form["name"];
            var FileDataContent = Request.Files[0];
            if (FileDataContent != null && FileDataContent.ContentLength > 0)
            { 
                var stream = FileDataContent.InputStream;
                var UploadPath = Server.MapPath("~/uploads");
                Directory.CreateDirectory(UploadPath);
                string path = Path.Combine(UploadPath, fileName);
                try
                {
                    using (var fileStream = new FileStream(path, FileMode.Append, FileAccess.Write))
                    {
                        stream.CopyTo(fileStream);
                    }
                }
                catch (IOException ex)
                {
                    // handle  
                    return Json(new { status = "fail", error = ex.Message });
                }
            }


            return Json(new { status = "success" });
        }

    }
}