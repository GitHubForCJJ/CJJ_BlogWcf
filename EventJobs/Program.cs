using EventJobs.Jobs;
using FastDev.Common.Extension;
using FastDev.Config;
using FastDev.Log;
using FastDev.Qiniu;
using Qiniu.Http;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventJobs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 62;
            Console.WindowHeight = 45;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.ForegroundColor = ConsoleColor.White;
            Console.Out.WriteLine("");

            Console.Out.WriteLine("");
            //Test();

            Thread startquartzservice = new Thread(StartQuartzService);
            startquartzservice.Start();
            Console.Out.WriteLine("        ***************************************");
            Console.Out.WriteLine("        **                                    **");
            Console.Out.WriteLine("        **     mysql自动备份上传七牛已启动    **");
            Console.Out.WriteLine("        **                                    **");
            Console.Out.WriteLine("        **                                    **");
            Console.Out.WriteLine("        **                                    **");
            Console.Out.WriteLine("        ***************************************");
            Console.Out.WriteLine("");
            Console.Out.WriteLine("");
            Console.WriteLine("         启动时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.Out.WriteLine("");
            Console.WriteLine("         若需退出请输入 exit 按回车退出...\r\n");
            string userCommand = string.Empty;
            while (userCommand != "exit")
            {
                if (string.IsNullOrEmpty(userCommand) == false)
                {
                    Console.WriteLine("                非退出指令,自动忽略...");
                }

                userCommand = Console.ReadLine();
            }
        }
        /// <summary>
        /// The scheduler
        /// </summary>
        static IScheduler _scheduler = null;
        /// <summary>
        ///启动任务调度服务
        /// </summary>
        private static async void StartQuartzService()
        {
            ISchedulerFactory sf = new StdSchedulerFactory();
            if (_scheduler == null)
            {
                _scheduler = await sf.GetScheduler();
            }
            await _scheduler.Start();


            //创建任务对象
            IJobDetail job1 = JobBuilder.Create<EveryBackUpJob>().WithIdentity("job1", "group1").Build();
            //创建触发器
            ITrigger trigger1 = TriggerBuilder.Create().WithIdentity("trigger1", "group1").StartNow().WithCronSchedule(ConfigHelper.GetConfigToString("runtime")).Build();
            //创建任务对象
            IJobDetail job2 = JobBuilder.Create<EveryBackUpJob>().WithIdentity("job2", "group2").Build();
            //创建触发器
            ITrigger trigger2 = TriggerBuilder.Create().WithIdentity("trigger2", "group2").StartNow().WithCronSchedule(ConfigHelper.GetConfigToString("runtimeupqiniu")).Build();

            await _scheduler.ScheduleJob(job1, trigger1);
            await _scheduler.ScheduleJob(job2, trigger2);
        }

        private static void Test()
        {
            string qiniuak = ConfigHelper.GetConfigToString("qiniuak");
            string qiniusk = ConfigHelper.GetConfigToString("qiniusk");
            string qiniubk = ConfigHelper.GetConfigToString("qiniubk");
            string a = ConfigHelper.GetConfigToString("backuppath");
            string path = Path.Combine(a, $"blog.sql");
            HttpResult res = QiniuHelper.UpFile(path, qiniuak, qiniusk, qiniubk, "blogdb", 0);
            if (res.Code != 200)
            {
                LogHelper.WriteLog("上传失败" + res.SerializeObject());
            }

        }
    }
}
