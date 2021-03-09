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

        

        
    }
}