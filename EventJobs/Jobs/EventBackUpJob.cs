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
    public class EveryBackUpJob : IJob
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
                BackUpDb();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex, $"定时备份数据库失败");
            }
        }

        public void BackUpDb()
        {
            //创建进程对象   
            Process proc = new Process();
            //调用dos窗口
            proc.StartInfo.FileName = "cmd.exe";
            //不显示窗体
            proc.StartInfo.CreateNoWindow = true;
            //设置dos窗口的目录路径，这里就是自己安装mysql的bin目录（我们的mysqldump.exe和mysql.exe所在目录）
            proc.StartInfo.WorkingDirectory = ConfigHelper.GetConfigToString("mysqlbin");//@"C:\Program Files\MySQL\MySQL Server 5.7\bin";
            //允许输入流
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            //执行 
            proc.Start();
            //登陆数据库，这里的内容和我们直接使用dos窗口备份数据库的方式一致，前面是数据库登陆信息，后面是备份路径
            //更详细的教程 https://baijiahao.baidu.com/s?id=1612955427840289665&wfr=spider&for=pc
            string pwd = ConfigHelper.GetConfigToString("mysqlpwd");
            string db = ConfigHelper.GetConfigToString("backdb");
            string backuppath = ConfigHelper.GetConfigToString("backuppath");
            string path = Path.Combine(backuppath, $"blogdb{DateTime.Now.ToString("yyyymmdd")}.sql");
            string lague = $"mysqldump  --skip-add-locks  -hlocalhost -P3306 -uroot -p{pwd} --databases  {db}> {path}";
            proc.StandardInput.WriteLine(lague);
            proc.Close();

            #region 上传七牛
            string qiniuak = ConfigHelper.GetConfigToString("qiniuak");
            string qiniusk = ConfigHelper.GetConfigToString("qiniusk");
            string qiniubk = ConfigHelper.GetConfigToString("qiniubk");
            HttpResult res = QiniuHelper.UpFile(path, qiniuak, qiniusk, qiniubk, "blogdb", 0);
            if (res.Code != 200)
            {
                LogHelper.WriteLog("上传失败" + res.SerializeObject());
            }

            #endregion
        }
    }
}
