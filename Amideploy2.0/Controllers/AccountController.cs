using Amideploy2._0.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Amideploy2._0.Controllers
{
    public class AccountController : Controller
    {
        private string _className = "AccountController";
        public LoggingHelper loggingHelper = new LoggingHelper();
        // GET: Account
        public ActionResult Index()
        {
            Session.Clear();
            return View();
            
        }

        [HttpPost]
        public ActionResult Index(LoginModel LM)
        {
            loggingHelper.Log(LoggingLevels.Info, "Class: " + _className + " :: Index - begin");
            try
            {
                DBHandler LDB = new DBHandler();
                DataTable dt = LDB.Login(LM);

                if (dt.Rows[0]["MSG"].ToString().ToUpper().Equals("SUCCESS"))
                {
                    Session["UserName"] = dt.Rows[0]["UserName"].ToString();
                    Session["Role"] = dt.Rows[0]["Role"].ToString();
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.Message = dt.Rows[0]["MSG"].ToString();
                    return View();
                }
            }
            catch(Exception ex)
            {
                loggingHelper.Log(LoggingLevels.Error, "Class: " + _className + " :: Index - Error - " + ex.Message);
            }
            loggingHelper.Log(LoggingLevels.Info, "Class: " + _className + " :: Index - begin");
            return View();
        }

    }
}