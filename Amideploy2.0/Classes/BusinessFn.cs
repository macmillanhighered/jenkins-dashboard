using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Businesslayer
{
    public class BusinessFn
    {
        DBHelper helper;
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
