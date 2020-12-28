using Amideploy2._0.Models;
using System.Web.Mvc;
using Businesslayer;

namespace Amideploy2._0.Controllers
{
    public class HomeController : Controller
    {
        BusinessFn bl = new BusinessFn();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Showinstances()
        {
            return View();
        }

        public ActionResult Getdeployementdata()
        {
            if (Session["UserName"] != null)
            {
                dblayer UDBHan = new dblayer();
                var ddatalist = UDBHan.GetDeployementdata();
                return Json(new {data=ddatalist},JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        public ActionResult Getbuildlog(string env,string component,string version)
        {

            string env1 = Request.QueryString["env"];
            string component1 = Request.QueryString["component"];
            string version1 = Request.QueryString["version"];
            return Redirect("http://10.10.12.185:8080/job/test-build/8/");
        }

        
    }
}