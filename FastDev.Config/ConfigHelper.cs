using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDev.Config
{
    public class ConfigHelper
    {
        public static string GetConfigToString(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "";
            }
            var obj = GetConfigObject(name);
            try
            {
                if (obj == null)
                {
                    return "";
                }
                return obj.ToString();
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 若不存在或者错误返回int最小值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int GetConfigToInt(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return int.MinValue;
            }
            var obj = GetConfigObject(name);
            try
            {
                if (obj == null)
                {
                    return int.MinValue;
                }
                return Convert.ToInt32(obj);
            }
            catch
            {
                return int.MinValue;
            }
        }
        public static object GetConfigObject(string name)
        {

            return ConfigurationManager.AppSettings[name];

        }
    }
}
