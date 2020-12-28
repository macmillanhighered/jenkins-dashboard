using Businesslayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amideploy2._0.Models
{
    public class dblayer
    {
        public List<Releasetickets> Getreleasetickets()
        {
            BusinessFn bl = new BusinessFn();
            DataTable dt = new DataTable();
            dt = bl.Getuielements("Alltickets");
            if (dt.Rows.Count > 0)
            {
                List<Releasetickets> _UserList = new List<Releasetickets>();

                foreach (DataRow row in dt.Rows)
                {
                    _UserList.Add(new Releasetickets()
                    {
                        releaseno = row["releaseno"].ToString(),
                        createddate = Convert.ToDateTime(row["createddate"].ToString()),
                        createdby = row["createdby"].ToString(),
                        isactive = bool.Parse(row["isactive"].ToString())

                    });
                }

                return _UserList;

            }
            else
            {
                return null;
            }
        }

        public List<Releasedetails> Getreleasedetails(string Releaseno)
        {
            BusinessFn bl = new BusinessFn();
            DataTable dt = new DataTable();
            dt = bl.Getreleasedetails(Releaseno);
            if (dt.Rows.Count > 0)
            {
                List<Releasedetails> _UserList = new List<Releasedetails>();

                foreach (DataRow row in dt.Rows)
                {
                    _UserList.Add(new Releasedetails()
                    {
                        Releaseno = row["releaseno"].ToString(),
                        ComponentName = row["ComponentName"].ToString(),
                        Version = row["Version"].ToString()
                        

                    });
                }

                return _UserList;

            }
            else
            {
                return null;
            }
        }

        public List<Deployementdata> GetDeployementdata()
        {
            BusinessFn bl = new BusinessFn();
            DataTable dt = new DataTable();
            dt = bl.Getdeployementdata("ALL");
            if (dt.Rows.Count > 0)
            {
                List<Deployementdata> _Depdata = new List<Deployementdata>();

                foreach (DataRow row in dt.Rows)
                {
                    _Depdata.Add(new Deployementdata()
                    {
                        ComponentName = row["ComponentName"].ToString(),
                        DEV = row["DEV"].ToString(),
                        LT = row["LT"].ToString(),
                        QA = row["QA"].ToString(),
                        PROD = row["PROD"].ToString()


                    });
                }

                return _Depdata;

            }
            else
            {
                return null;
            }
        }

        public List<Releasecomponent> Getcomponentformap(string Relno)
        {
            BusinessFn bl = new BusinessFn();
            DataTable dt = new DataTable();
            dt = bl.Getcomponentformap(Relno);
            if (dt.Rows.Count > 0)
            {
                List<Releasecomponent> _Reldata = new List<Releasecomponent>();

                foreach (DataRow row in dt.Rows)
                {
                    _Reldata.Add(new Releasecomponent()
                    {
                        ComponentName = row["ComponentName"].ToString(),
                        Application = row["Application"].ToString(),
                        Action = row["Action"].ToString()


                    });
                }

                return _Reldata;

            }
            else
            {
                return null;
            }
        }

        public List<SelectListItem> GetReleaseDropdownList(string Criteria)
        {
            BusinessFn bl = new BusinessFn();
            DataTable dt = new DataTable();
            dt = bl.Getuielements(Criteria);
            if (dt.Rows.Count > 0)
            {
                List<SelectListItem> items = new List<SelectListItem>();

                foreach (DataRow row in dt.Rows)
                {
                    items.Add(new SelectListItem()
                    {
                        Text = row["NAME"].ToString(),
                        Value = row["CODE"].ToString()
                    });
                }

                return items;

            }
            else
            {
                return null;
            }
        }

        public List<SelectListItem> GetbuildversionDropdownList(string Criteria)
        {
            BusinessFn bl = new BusinessFn();
            DataTable dt = new DataTable();
            dt = bl.Getbuildversion(Criteria);
            if (dt.Rows.Count > 0)
            {
                List<SelectListItem> items = new List<SelectListItem>();

                foreach (DataRow row in dt.Rows)
                {
                    items.Add(new SelectListItem()
                    {
                        Text = row["version"].ToString(),
                        Value = row["code"].ToString()
                    });
                }

                return items;

            }
            else
            {
                return null;
            }
        }

    }
}