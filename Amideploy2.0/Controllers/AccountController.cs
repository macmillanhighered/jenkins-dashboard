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
        // GET: Account
        public ActionResult Index()
        {
            Session.Clear();
            return View();
            
        }

        [HttpPost]
        public ActionResult Index(LoginModel LM)
        {
            try
            {
                DBHandler LDB = new DBHandler();
                DataTable dt = LDB.Login(LM);

                if (dt.Rows[0]["MSG"].ToString().ToUpper().Equals("SUCCESS"))
                {
                    Session["UserName"] = dt.Rows[0]["UserName"].ToString();
                    Session["Role"] = dt.Rows[0]["Role"].ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = dt.Rows[0]["MSG"].ToString();
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

    }
}