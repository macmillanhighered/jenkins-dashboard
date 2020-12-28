using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amideploy2._0.Models;
using Businesslayer;


namespace Amideploy2._0.Controllers
{
    public class ReleaseController : Controller
    {
        BusinessFn bl = new BusinessFn();
        // GET: Release
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult viewrelasetickets()
        {
            if (Session["UserName"] != null)
            {
                dblayer UDBHan = new dblayer();
                return View(UDBHan.Getreleasetickets());
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        public ActionResult Getcomponents()
        {
            dblayer UserDB = new dblayer();
            Releaseno DDList = new Releaseno();
            DDList.Releaseticket = UserDB.GetReleaseDropdownList("Releaseticketno").ToList();
            return View(DDList);
        }

        public ActionResult Getbuildversion(string component)
        {
            dblayer UserDB = new dblayer();
            Releaseno DDList = new Releaseno();
            DDList.Buildversion = UserDB.GetbuildversionDropdownList(component).ToList();
            return View(DDList);
        }

        public ActionResult Details(string Releaseno)
        {
            if (Session["UserName"] != null)
            {
                dblayer UDBHan = new dblayer();
                return View(UDBHan.Getreleasedetails(Releaseno));
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }
        public ActionResult Getcomponentformapping(string releaseno)
        {
            if (Session["UserName"] != null)
            {
                dblayer UDBHan = new dblayer();
                var ddatalist = UDBHan.Getcomponentformap(releaseno);
                return Json(new { data = ddatalist }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
        }
      
        [HttpPost]
        public ActionResult Getcomponents(FormCollection frm)
        {

            if (Session["UserName"] != null)
            {
                int add = bl.Addcomponentversion(frm["Releaseticketno"].ToString(), frm["Component"].ToString(), frm["ddlbuildversion"].ToString(), Session["UserName"].ToString());
                return RedirectToAction("viewrelasetickets", "Release");
            }
            else
            {

                return RedirectToAction("Index", "Account");
            }
        }

        [HttpGet]
        public ActionResult Createnewrelease()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Createnewrelease(FormCollection frm)
        {
            if (Session["UserName"] != null)
            {
                int add = bl.Addrelease(frm["Releaseticketno"].ToString(), Session["UserName"].ToString());
                return RedirectToAction("viewrelasetickets", "Release");
            }
            else
            {

                return RedirectToAction("Index", "Account");
            }



        }


    }
}