using Amideploy2._0.Models;
using Businesslayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amideploy2._0.Controllers
{
    public class DashboardController : Controller
    {
        private string _className = "DashboardController";
        public LoggingHelper loggingHelper = new LoggingHelper();
        BusinessFn bl = new BusinessFn();
        // GET: Dashboard
        public ActionResult Index()
        {
            loggingHelper.Log(LoggingLevels.Info, "Class: " + _className + " :: Index - begin");
            try
            {
                List<string> lstComponents = Convert.ToString(ConfigurationManager.AppSettings["componentlist"]).Split(',').ToList();
                var list = lstComponents
                       .Select(p =>
                                 new SelectListItem
                                 {
                                     Value = p,
                                     Text = p
                                 });

                SelectList lstobj = new SelectList(list, "Value", "Text");
                ViewBag.Components = lstobj;
            }
            catch(Exception ex)
            {
                loggingHelper.Log(LoggingLevels.Error, "Class: " + _className + " :: Index - Error - " + ex.Message);
                throw ex;
            }
            loggingHelper.Log(LoggingLevels.Info, "Class: " + _className + " :: Index - end");
            return View();
        }

        [HttpPost]
        public ActionResult Getdeployementdata(List<string> selectedComponents)
        {
            loggingHelper.Log(LoggingLevels.Info, "Class: " + _className + " :: Getdeployementdata - begin");
            BusinessFn bdata = new BusinessFn();
            List<Deployementdata> ddatalist = null;
            try
            {
                if (Session["UserName"] != null)
                {
                    ddatalist = bdata.GetDeployVersionData(selectedComponents);
                }
                else
                {
                    return RedirectToAction("Index", "Account");
                }
            }
            catch (Exception ex)
            {
                loggingHelper.Log(LoggingLevels.Error, "Class: " + _className + " :: Getdeployementdata - Error - " + ex.Message);
                throw ex;
            }
            loggingHelper.Log(LoggingLevels.Info, "Class: " + _className + " :: Getdeployementdata - end");
            return Json(new { data = ddatalist }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Getbuildlog(string env, string component, string version)
        {
            string env1 = Request.QueryString["env"];
            string component1 = Request.QueryString["component"];
            string version1 = Request.QueryString["version"];
            return Redirect("http://10.10.12.185:8080/job/test-build/8/");
        }

    }
}