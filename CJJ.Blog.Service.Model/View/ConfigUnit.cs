using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FastDev.Common.Code;

namespace CJJ.Blog.Service.Model.View
{
    public class ConfigUnit
    {
        public static int ExpirationTimeOut = GetConfigInt("ExpirationTimeOut");

        public static int GetConfigInt(string key)
        {
            try
            {
                var obj = System.Configuration.ConfigurationManager.AppSettings[key];
                if (obj != null || obj != "")
                {
                    return Convert.ToInt32(obj);
                }
                else
                {
                    return int.MinValue;
                }
            }
            catch
            {
                return int.MinValue;
            }
            
        }
    }
}