using Qiniu.Http;
using Qiniu.Storage;
using Qiniu.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDev.Qiniu
{
    /// <summary>
    /// Class QiniuHelper.
    /// </summary>
    public class QiniuHelper
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="upFileFullName">上传文件全路径</param>
        /// <param name="AccessKey">密钥AK</param>
        /// <param name="SecretKey">密钥SK</param>
        /// <param name="bucket">存储空间</param>
        /// <param name="cdnPath">文件前缀</param>
        /// <param name="saveDays">文件保存天数 0 表示永久存储</param>
        /// <param name="zone">Cdn区域 枚举 默认华东</param>
        /// <returns>
        /// HttpResult.
        /// </returns>
        public static HttpResult UpFile(string upFileFullName, string AccessKey, string SecretKey, string bucket, string cdnPath, int saveDays = 0, Zone zone = null)
        {
            Mac mac = new Mac(AccessKey, SecretKey);
            Random rand = new Random();

            if (!cdnPath.EndsWith("/"))
            {
                cdnPath += "/";
            }

            var key = cdnPath + Path.GetFileName(upFileFullName);
            PutPolicy putPolicy = new PutPolicy();
            putPolicy.Scope = bucket + ":" + key;
            putPolicy.SetExpires(3600);
            putPolicy.DeleteAfterDays = saveDays;
            string token = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());
            Config config = new Config();
            config.Zone = (zone == null ? Zone.ZONE_CN_East : zone);
            config.UseHttps = true;
            config.UseCdnDomains = true;
            config.ChunkSize = ChunkUnit.U512K;
            FormUploader target = new FormUploader(config);
            return target.UploadFile(upFileFullName, key, token, null);
        }


        /// <summary>
        /// 获取授权下载文件链接
        /// </summary>
        /// <param name="fileUrl">原始文件路径</param>
        /// <param name="AccessKey">密钥AK</param>
        /// <param name="SecretKey">密钥SK</param>
        /// <param name="expireTime">过期时间 单位分钟 默认2分钟</param>
        /// <returns></returns>
        public static string GetFileUrl(string fileUrl, string AccessKey, string SecretKey, int expireTime = 2)
        {
            fileUrl += "?e=" + UnixTimestamp.ConvertToTimestamp(DateTime.Now.AddMinutes(expireTime));

            Mac mac = new Mac(AccessKey, SecretKey);

            return fileUrl + "&token=" + Auth.CreateDownloadToken(mac, fileUrl);
        }

        /// <summary>
        /// 根据七牛时间戳防盗链方式生成下载地址Url
        /// </summary>
        /// <param name="fileUrl">原始文件Url</param>
        /// <param name="key">密钥Key</param>
        /// <param name="expireTime">过期时间 单位分钟 默认2分钟</param>
        /// <returns></returns>
        public static string GetFileUrlByTimeAuth(string fileUrl, string key, int expireTime = 2)
        {
            try
            {
                var t = Convert.ToInt32(UnixTimestamp.ConvertToTimestamp(DateTime.Now.AddMinutes(expireTime))).ToString("X").ToLower();

                string host, path, file, query;

                UrlHelper.UrlSplit(fileUrl, out host, out path, out file, out query);

                var s = key + path + file + t;

                var sign = Md5.Encrypt32(s).ToLower();

                var returl = fileUrl + (string.IsNullOrEmpty(query) ? "?" : "&") + "sign=" + sign + "&t=" + t;

                return returl;
            }
            catch
            {
                return fileUrl;
            }

        }

        /// <summary>
        /// 删除七牛文件
        /// </summary>
        /// <param name="AccessKey">密钥AK</param>
        /// <param name="SecretKey">密钥SK</param>
        /// <param name="bucket">存储空间</param>
        /// <param name="fileKey">文件名</param>
        /// <param name="zone">Cdn区域 枚举 默认华东</param>
        /// <returns></returns>
        public static HttpResult DelFile(string AccessKey, string SecretKey, string bucket, string fileKey, Zone zone = null)
        {
            Mac mac = new Mac(AccessKey, SecretKey);
            Config config = new Config();
            config.Zone = (zone == null ? Zone.ZONE_CN_East : zone);
            config.UseHttps = true;
            config.UseCdnDomains = true;
            config.ChunkSize = ChunkUnit.U512K;
            BucketManager black = new BucketManager(mac, config);
            return black.Delete(bucket, fileKey);
        }
    }
}
