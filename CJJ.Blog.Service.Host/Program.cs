using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using CJJ.Blog.Service.Logic;
using CJJ.Blog.Service.Service;
using FastDev.Console;

namespace CJJ.Blog.Service.Host
{
    class Program
    {
        private static string ProFullname = "CJJ博客WCF服务";
        #region 设置控制台标题 禁用关闭按钮

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]
        extern static IntPtr GetSystemMenu(IntPtr hWnd, IntPtr bRevert);
        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]
        extern static IntPtr RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);

        /// <summary>
        /// Disbles the closebtn.
        /// </summary>
        static void DisbleClosebtn()
        {
            IntPtr windowHandle = FindWindow(null, ProFullname);
            IntPtr closeMenu = GetSystemMenu(windowHandle, IntPtr.Zero);
            uint SC_CLOSE = 0xF060;
            RemoveMenu(closeMenu, SC_CLOSE, 0x0);
        }
        protected static void CloseConsole(object sender, ConsoleCancelEventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion


        static void Main(string[] args)
        {
            Console.Title = ProFullname;

            //Console.WindowWidth = 62;
            //Console.WindowHeight = 45;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ConsoleHelper.OutNoBugMsg();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Out.WriteLine("");
            Console.WriteLine("                    当前版本号：" + AppDomain.CurrentDomain.BaseDirectory.Split(new char[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries).Last());
            Console.Out.WriteLine("");
            StartService();
            Console.WriteLine("        " + ConsoleHelper.OutProcessRunPort());
            Console.Out.WriteLine("        ***************************************");
            Console.Out.WriteLine("        **                                   **");
            Console.Out.WriteLine("        **            CJJ 博客服务            **");
            Console.Out.WriteLine("        **                                   **");
            Console.Out.WriteLine("        **             WCF已启动          **");
            Console.Out.WriteLine("        **                                   **");
            Console.Out.WriteLine("        ***************************************");
            Console.Out.WriteLine("");
            Console.Out.WriteLine("");
            Console.WriteLine("         启动时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.Out.WriteLine("");
            Console.WriteLine("         若需退出请输入 exit 按回车退出...\r\n");

           // Test();


            string userCommand = string.Empty;
            while (userCommand != "exit")
            {
                if (string.IsNullOrEmpty(userCommand) == false)
                    Console.WriteLine("                非退出指令,自动忽略...");
                userCommand = Console.ReadLine();
            }
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        private static void StartService()
        {
            ServiceHost outTicketSystemManageServiceHost = new ServiceHost(typeof(BlogService));
            if (outTicketSystemManageServiceHost.State != CommunicationState.Opening)
            {
                outTicketSystemManageServiceHost.Open();
            }
        }

        public static void Test()
        {
            var a = CategoryLogic.GetAllList();
        }
    }
}
