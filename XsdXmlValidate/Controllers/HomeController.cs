using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XsdXmlValidate.Helper;

namespace XsdXmlValidate.Controllers
{
    public class HomeController : Controller
    {
        Helper.Validations val = new Validations();
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = file.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads"), fileName.ToString());
                file.SaveAs(path);

                //localidad el archivo xsd
                string xsd = Server.MapPath("~/Xsd/input.xsd");
                ViewBag.Mensaje =  val.ValidateXmlUsingXSD(xsd, Server.MapPath("~/uploads/" + file.FileName));


                
            }

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
    }
}