using Businesslayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Amideploy2._0.Models
{
    public class DBHandler
    {
        private string _className = "DBHandler";
        public LoggingHelper loggingHelper = new LoggingHelper();
        public DataTable Login(LoginModel LM)
        {
            loggingHelper.Log(LoggingLevels.Info, "Class: " + _className + " :: Login - begin");
            bool isSuccess = false;
            DataTable dt = null;
            try
            {
                BusinessFn OGL = new BusinessFn();
                dt = new DataTable();
                dt = OGL.GetUserinfo(LM.UserName, LM.Password);
                if (dt.Rows.Count > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                loggingHelper.Log(LoggingLevels.Error, "Class: " + _className + " :: Login - Error - " + ex.Message);
                isSuccess = false;
            }
            loggingHelper.Log(LoggingLevels.Info, "Class: " + _className + " :: Login - isSuccess-" + isSuccess);
            loggingHelper.Log(LoggingLevels.Info, "Class: " + _className + " :: Login - end");
            return dt;
        }
    }
}