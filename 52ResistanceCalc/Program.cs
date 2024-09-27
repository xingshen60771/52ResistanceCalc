using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace _52ResistanceCalc
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //实例不得重复运行，开始前检查实例是否重复运行，否则强制退出，创建互斥体的方式判断实例可能会出现误判，因此改用较为可靠的查找进程法。

            //取现行进程
            Process currentProcess = Process.GetCurrentProcess();

            //取现行进程名称
            string processName = currentProcess.ProcessName;

            //调试输出现行进程名称
            Console.WriteLine($"进入主函数成功！当前进程名称为\"{processName}\"。");

            // 检查是否有超过一个进程
            Process[] pro = Process.GetProcessesByName(processName);
            if (pro != null && pro.Length >= 2)
            {
                MessageBox.Show(PublicFunction.GetAPPInformation(1) + "不支持重复运行！本次进程将结束！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            else     //实例不存在，可以继续运行           

            {
                //应用程序可视化
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //检查许可协议是否接受，未接受则弹出许可协议对话框
                string value = "";
                RegistryKey key = Registry.CurrentUser;
                RegistryKey software = key.OpenSubKey("SOFTWARE\\52pojie\\ResistanceClac\\Main");
                Console.WriteLine(value);
                if (software == null)
                {
                    Application.Run(new Form_License());
                }
                else
                {
                    Application.Run(new MainForm());
                    software.Close();
                }
            }
        }
    }
}
