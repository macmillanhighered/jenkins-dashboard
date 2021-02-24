using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Web.Hosting;
using System.IO;
using Newtonsoft.Json;
using Amideploy2._0.Models;
using System.Configuration;

namespace Businesslayer
{
    public class BusinessFn
    {
        DBHelper helper;
        private string _className = "BusinessFn";
        public LoggingHelper loggingHelper = new LoggingHelper();
        public BusinessFn()
        {
            //string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECTION_STRING"].ToString();
            //conn = new SqlConnection(_ConnString);
            helper = new DBHelper();

        }

        public DataTable GetUserinfo(string username,string password)
        {
            DataTable Result = new DataTable();
            try
            {

                System.Collections.Specialized.HybridDictionary Parameters = new System.Collections.Specialized.HybridDictionary();
                Parameters.Add("user", username);
                Parameters.Add("pwd", password);
                Result = helper.ReturnDataTable("sp_getuserinfo", Parameters);
            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }

        public DataTable Getuielements(string Type)
        {
            DataTable Result = new DataTable();
            try
            {

                System.Collections.Specialized.HybridDictionary Parameters = new System.Collections.Specialized.HybridDictionary();
                Parameters.Add("typename", Type);

                Result = helper.ReturnDataTable("sp_getuielements", Parameters);
            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }

        public DataTable Getreleasedetails(string releaseno)
        {
            DataTable Result = new DataTable();
            try
            {

                System.Collections.Specialized.HybridDictionary Parameters = new System.Collections.Specialized.HybridDictionary();
                Parameters.Add("releasename", releaseno);

                Result = helper.ReturnDataTable("sp_getreleasedetails", Parameters);
            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }


        public DataTable Getbuildversion(string component)
        {
            DataTable Result = new DataTable();
            try
            {

                System.Collections.Specialized.HybridDictionary Parameters = new System.Collections.Specialized.HybridDictionary();
                Parameters.Add("componentname", component);

                Result = helper.ReturnDataTable("sp_getbuildversionformapping", Parameters);
            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }

        public DataTable Getdeployementdata(string Type)
        {
            DataTable Result = new DataTable();
            try
            {                
                System.Collections.Specialized.HybridDictionary Parameters = new System.Collections.Specialized.HybridDictionary();
                Parameters.Add("typename", Type);

                Result = helper.ReturnDataTable("sp_getdeployementdetails", Parameters);
            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }       

        public List<Deployementdata> GetDeployVersionData(List<string> selectedComponents)
        {
            loggingHelper.Log(LoggingLevels.Info, "Class: " + _className + " :: GetDeployVersionData - begin - ");

            List<Deployementdata> lstdeployementdata = null;
            try
            {
                List<string> lstEnv = Convert.ToString(ConfigurationManager.AppSettings["envlist"]).Split(',').ToList();
                List<string> lstComponents = selectedComponents;

                string filepath = HostingEnvironment.MapPath("~/StatusEndpoint.json");
                JObject jsondata = JObject.Parse(File.ReadAllText(filepath));
                lstdeployementdata = new List<Deployementdata>();
                foreach (string component in lstComponents)
                {
                    Deployementdata deployementdata = new Deployementdata();
                    deployementdata.ComponentName = component;
                    foreach (string env in lstEnv)
                    {
                        string endpointurl = Convert.ToString(jsondata["endpoints"][env][component]);
                        using (WebClient webClient = new WebClient())
                        {
                            try
                            {
                                var json = webClient.DownloadString(endpointurl);
                                var details = JObject.Parse(json.ToString());
                                string versionNumber = Convert.ToString(details["Summary"]["version"]);
                                string date = Convert.ToDateTime(details["Summary"]["installDateTime"]).ToString("dd MMMM yyyy");
                                string ipAdress = Convert.ToString(details["Summary"]["ipAdress"]);
                                string status = Convert.ToString(details["Summary"]["reason"]);
                                switch (env)
                                {
                                    case "dev":
                                        deployementdata.DEV = versionNumber + "," + date + "," + ipAdress + "," + status;
                                        break;
                                    case "lt":
                                        deployementdata.LT = versionNumber + "," + date + "," + ipAdress + "," + status;
                                        break;
                                    case "qa":
                                        deployementdata.QA = versionNumber + "," + date + "," + ipAdress + "," + status;
                                        break;
                                    case "prod":
                                        deployementdata.PROD = versionNumber + "," + date + "," + ipAdress + "," + status;
                                        break;
                                }
                            }
                            catch(Exception ex1)
                            {
                                loggingHelper.Log(LoggingLevels.Error, "Class: " + _className + " :: GetDeployVersionData - foreach loop - Error - " + ex1.Message);
                            }
                        }
                    }
                    lstdeployementdata.Add(deployementdata);
                }
            }
            catch (Exception ex)
            {
                loggingHelper.Log(LoggingLevels.Error, "Class: " + _className + " :: GetDeployVersionData - Error - " + ex.Message);
                throw ex;
            }
            loggingHelper.Log(LoggingLevels.Info, "Class: " + _className + " :: GetDeployVersionData - end - ");
            return lstdeployementdata;
        }
        public DataTable Getcomponentformap(string releaseno)
        {
            DataTable Result = new DataTable();
            try
            {

                System.Collections.Specialized.HybridDictionary Parameters = new System.Collections.Specialized.HybridDictionary();
                Parameters.Add("releasen", releaseno);

                Result = helper.ReturnDataTable("sp_getcomponentsformapping", Parameters);
            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }

        public DataTable Getbuildlogurl(string Type,string environment,string component,string version)
        {
            DataTable Result = new DataTable();
            try
            {

                System.Collections.Specialized.HybridDictionary Parameters = new System.Collections.Specialized.HybridDictionary();
                Parameters.Add("typename", Type);
                Parameters.Add("environmentname", environment);
                Parameters.Add("componentname", component);
                Parameters.Add("versionname", version);

                Result = helper.ReturnDataTable("sp_getdeployementdetails", Parameters);
            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }

        public int Addrelease(string releaseticketno, string username)
        {
            int Result = -1;

            try
            {
                System.Collections.Specialized.HybridDictionary Parameters = new System.Collections.Specialized.HybridDictionary();
                Parameters.Add("releaseticketno", releaseticketno);
                Parameters.Add("username", username);

                Result = helper.ExecuteNonQuery("sp_addreleaseticket", Parameters);
            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }

        public int Addcomponentversion(string releaseticketno,string componentname,string versionname, string username)
        {
            int Result = -1;

            try
            {
                System.Collections.Specialized.HybridDictionary Parameters = new System.Collections.Specialized.HybridDictionary();
                Parameters.Add("releaseticketno", releaseticketno);
                Parameters.Add("componentname", componentname);
                Parameters.Add("versionname", versionname);
                Parameters.Add("username", username);
                Result = helper.ExecuteNonQuery("sp_addreleasecomponent", Parameters);
            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }



    }
}
