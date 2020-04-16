using FastDev.Common.Extension;
using FastDev.Config;
using FastDev.Log;
using FastDev.Qiniu;
using Qiniu.Http;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventJobs.Jobs
{
    public class EventQiniuUpJob : IJob
    {
        /// <summary>
        /// 作业调度定时执行的方法
        /// </summary>
        /// <param name="context">The execution context.</param>
        /// <returns>Task.</returns>
        /// <remarks>The implementation may wish to set a  result object on the
        /// JobExecutionContext before this method exits.  The result itself
        /// is meaningless to Quartz, but may be informative to
        /// <see cref="T:Quartz.IJobListener" />s or
        /// <see cref="T:Quartz.ITriggerListener" />s that are watching the job's
        /// execution.</remarks>
        public virtual Task Execute(IJobExecutionContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                EveryTask();
            });
        }

        /// <summary>
        ///任务实现 直接调用服务或者具体逻辑代码
        /// </summary>
        public void EveryTask()
        {
            try
            {
                UpDbToQiniu();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex, $"备份数据库上传 七牛 失败");
            }
        }
        /// <summary>
        /// 现在是一天 备份一次数据库
        /// </summary>
        public void UpDbToQiniu()
        {
            #region 上传七牛
            string qiniuak = ConfigHelper.GetConfigToString("qiniuak");
            string qiniusk = ConfigHelper.GetConfigToString("qiniusk");
            string qiniubk = ConfigHelper.GetConfigToString("qiniubk");
            string a = ConfigHelper.GetConfigToString("backuppath");
            string path = Path.Combine(a, $"blogdb{DateTime.Now.ToString("yyyymmdd")}.sql");
            HttpResult res = QiniuHelper.UpFile(path, qiniuak, qiniusk, qiniubk, "blogdb", 0);
            if (res.Code != 200)
            {
                LogHelper.WriteLog("上传失败" + res.SerializeObject());
            }

            #endregion
        }
    }
}
