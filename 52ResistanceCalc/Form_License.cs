using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;


namespace _52ResistanceCalc
{

    public partial class Form_License : Form
    {
        /// <summary>
        /// 实例化当前窗体
        /// </summary>
        public Form_License()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体创建完毕响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_License_Load(object sender, EventArgs e)
        {
            //载入许可协议RTF文本
            richText_License.LoadFile(new MemoryStream(Properties.Resources.license), RichTextBoxStreamType.RichText);

            //“同意协议”复选框未选中时，“确定”按钮标题为“退出“
            if (check_agree.Checked == false)
            {
                btn_OK.Text = "退出";
                //隐藏“撤销同意协议”标签
                label_licencedisagree.Visible = false;
            }

            //遍历已打开窗口，如果是在“关于”窗体打开的则表示无需同意
            foreach (Form frm in Application.OpenForms)
            {
                //遍历到“关于”窗体，隐藏“同意协议”复选框，显示“撤销同意协议”标签，“确定”按钮标题为“确定“
                if (frm is Form_About)
                {
                    check_agree.Visible = false;
                    label_licencedisagree.Visible = true;
                    btn_OK.Text = "确定";
                }
            }
        }

        /// <summary>
        /// “同意协议”复选框选中状态改变时的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Check_agree_CheckedChanged(object sender, EventArgs e)
        {
            if (check_agree.Checked == true)
            {
                btn_OK.Text = "开始使用";
            }
            else
            {
                btn_OK.Text = "退出";
            }
        }

        /// <summary>
        /// 点击“确定”按钮响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_OK_Click(object sender, EventArgs e)
        {
            //遍历已打开窗口，如果是在“关于”窗体打开的则表示无需同意，直接关闭窗体。
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is Form_About)
                {
                    this.Close();
                }
            }

            //置许可协议注册表项
            RegistryKey key1 = Registry.CurrentUser;
            RegistryKey software1 = key1.OpenSubKey("SOFTWARE\\52pojie\\ResistanceClac\\Main");

            //当“同意协议”复选框选中时，将接受协议标记写入注册表项，并显示主窗口，否则退出
            if (check_agree.Checked == true)
            {
                RegistryKey key = Registry.CurrentUser;
                RegistryKey software = key.CreateSubKey("SOFTWARE\\52pojie\\ResistanceClac\\Main\\");
                key.OpenSubKey("SOFTWARE\\52pojie\\ResistanceClac\\Main\\", true);
                software.SetValue("License", 0);
                this.Hide();
                MainForm MainForm = new MainForm();
                MainForm.Show();
            }
            else if (software1 == null)
            {
                DialogResult exit = MessageBox.Show("警告，你必须仔细阅读并无条件接受《许可协议》才可以继续使用，如果不接受《许可协议》则会导致软件退出，现在要退出软件吗？", "即将退出", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (exit == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// 点击“撤销同意协议”标签的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_licencedisagree_Click(object sender, EventArgs e)
        {
            //询问是否撤回同意许可协议，如果撤回，则删除相关注册表项，并退出
            DialogResult q = MessageBox.Show("撤回对本软件许可协议的同意，本软件将终止服务，不能使用，是否要撤回同意吗？", "撤回许可协议同意", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (q == DialogResult.OK)
            {
                RegistryKey key = Registry.CurrentUser;
                key.DeleteSubKey("SOFTWARE\\52pojie\\ResistanceClac\\Main", true);
                key.Close();
                MessageBox.Show("已撤回同意软件许可协议！点击<确定>按钮终止运行", "终止服务", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
        }
    }
}
