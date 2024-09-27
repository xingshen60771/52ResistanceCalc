using System;
using System.Windows.Forms;

namespace _52ResistanceCalc
{
    public partial class Form_ChangeLog : Form
    {
        /// <summary>
        /// 实例化当前窗体
        /// </summary>
        public Form_ChangeLog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体创建完毕响应函数
        /// </summary>
        private void Form_ChangeLog_Load(object sender, EventArgs e)
        {
            //设置更新日志文本框大小，并从resource中载入文本
            text_ChangeLog.Size = new System.Drawing.Size(this.Width - 30, this.Height - 80);
            text_ChangeLog.Text = Properties.Resources.text_changelog;
        }

        /// <summary>
        /// 点击“确定”按钮响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
