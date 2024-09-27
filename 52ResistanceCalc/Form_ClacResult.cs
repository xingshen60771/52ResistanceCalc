using System;
using System.Windows.Forms;

namespace _52ResistanceCalc
{
    public partial class Form_ClacResult : Form
    {
        /// <summary>
        /// 实例化当前窗体
        /// </summary>
        public Form_ClacResult()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体创建完毕响应函数
        /// </summary>
        private void Form_ClacResult_Load(object sender, EventArgs e)
        {
            //载入计算结果文本
            label_Result.Text = "计算结果：\r\n\r\n" + GlobalVar.resultText;
        }

        /// <summary>
        /// 点击“知道了”按钮响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ClacResult_OK_Chick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
