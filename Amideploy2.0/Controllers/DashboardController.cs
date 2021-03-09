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
            List<Deployementdata> lstDeploymentdata = null;
            try
            {
                if (Session["UserName"] != null)
                {
                    lstDeploymentdata = bdata.GetDeployVersionData(selectedComponents);
                    if(lstDeploymentdata != null && lstDeploymentdata.Count > 0)
                    {
                        lstDeploymentdata = lstDeploymentdata.OrderByDescending(data => data.ReleaseDate).ToList();
                    }
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
            return Json(new { data = lstDeploymentdata }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Getbuildlog(string env, string component, string version)
        {
            string jenkinsurl = ConfigurationManager.AppSettings["jenkinsurl"];
            string env1 = Request.QueryString["env"];
            string component1 = Request.QueryString["component"];
            string version1 = Request.QueryString["version"];
            return Redirect(jenkinsurl);
        }

    }
}