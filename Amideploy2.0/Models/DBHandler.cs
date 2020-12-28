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
        public DataTable Login(LoginModel LM)
        {
            try
            {
                BusinessFn OGL = new BusinessFn();
                DataTable dt = new DataTable();
                dt = OGL.GetUserinfo(LM.UserName, LM.Password);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["MSG"].ToString().ToUpper().Equals("SUCCESS"))
                    {
                        return dt;
                    }
                    else
                    {
                        return dt;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}