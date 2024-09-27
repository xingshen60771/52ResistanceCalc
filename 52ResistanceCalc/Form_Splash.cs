using System;
//using System.Linq;
using System.Threading;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace _52ResistanceCalc
{
    public partial class Form_Splash : Form
    {

        int delay = 3000;  //闪屏停留毫秒数
        public MainForm mf;

        /// <summary>
        /// 实例化当前窗体
        /// </summary>
        public Form_Splash(MainForm f1)
        {
            InitializeComponent();
            mf = f1;
        }

        /// <summary>
        /// 显示主窗口
        /// </summary>
        void MainFromShow()
        {
            this.Close();
            mf.Show();
        }

        /// <summary>
        /// 窗体创建完毕响应函数
        /// </summary>
        private void FormSpalsh_Load(object sender, EventArgs e)
        {
            //闪屏淡入淡出效果
            for (double d = 0.01; d < 1; d += 0.02)
            {
                System.Threading.Thread.Sleep(1);
                Application.DoEvents();
                this.Opacity = d;
                this.Refresh();
            }
            Thread.Sleep(delay);
            for (double d = 1; d > 0; d -= 0.02)
            {
                System.Threading.Thread.Sleep(1);
                Application.DoEvents();
                this.Opacity = d;
                this.Refresh();
            }
            //淡出结束，显示主窗口
            MainFromShow();
        }
    }
}
