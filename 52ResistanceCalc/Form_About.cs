using System;
using System.Windows.Forms;

namespace _52ResistanceCalc
{
    public partial class Form_About : Form
    {

        /// <summary>
        /// 实例化当前窗体
        /// </summary>
        public Form_About()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体创建完毕响应函数
        /// </summary>
        private void Form_About_Load(object sender, EventArgs e)
        {
            //写入软件标题、版本信息、作者
            label_About_title.Text = PublicFunction.GetAPPInformation(1) + "\r\n" + PublicFunction.GetAPPInformation(2) + "\r\n\r\nBy：" + PublicFunction.GetAPPInformation(3);

            //载入resource中的软件图标，说明标签的文本留空
            IMG_icon.Image = Properties.Resources.icon;
            label_IconCaption.Text = string.Empty;
        }

        /// <summary>
        /// 点击左侧软件图标的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IMG_icon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("本logo为作者亲自手绘的图！不存在侵权行为，未经本人允许，任何人也不可以拿这张图进行商业盈利活动！", "这张图不侵权！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 点击“许可协议”标签响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_licence_Click(object sender, EventArgs e)
        {
            Form_License Form_License = new Form_License();
            Form_License.ShowDialog();
        }

        /// <summary>
        /// 点击“更新日志”响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_changelog_Click(object sender, EventArgs e)
        {
            Form_ChangeLog Form_ChangeLog = new Form_ChangeLog();
            Form_ChangeLog.ShowDialog();
        }

        /// <summary>
        /// 鼠标进入“官方微信公众号”标签的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_WX_MouseEnter(object sender, EventArgs e)
        {
            //载入resource中的微信公众号二维码图片，说明标签的文本写入提示信息
            IMG_icon.Image = Properties.Resources.qrcode_wx;
            label_IconCaption.Text = "更多精彩，敬请关注吾爱破解官方微信公众号！";
        }

        /// <summary>
        /// 鼠标离开“官方微信公众号”标签的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_WX_MouseLeave(object sender, EventArgs e)
        {
            //载入resource中的软件图标，说明标签的文本留空
            IMG_icon.Image = Properties.Resources.icon;
            label_IconCaption.Text = string.Empty;
        }

        /// <summary>
        /// 鼠标进入“官方B站主页”标签的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_bilibili_MouseEnter(object sender, EventArgs e)
        {
            //载入resource中的吾爱破解的B站主页二维码图片，说明标签的文本写入提示信息
            IMG_icon.Image = Properties.Resources.qrcode_bilibili;
            label_IconCaption.Text = "欢迎关注吾爱破解官方哔哩哔哩账号！";
        }

        /// <summary>
        /// 鼠标离开“官方B站主页”标签的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_bilibili_MouseLeave(object sender, EventArgs e)
        {
            //载入resource中的软件图标，说明标签的文本留空
            IMG_icon.Image = Properties.Resources.icon;
            label_IconCaption.Text = string.Empty;
        }

        /// <summary>
        /// 点击“官方B站主页”标签的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_bilibili_Click(object sender, EventArgs e)
        {
            //打开吾爱破解B站主页
            System.Diagnostics.Process.Start("https://https://space.bilibili.com/544451485/");
        }

        /// <summary>
        /// 鼠标进入“下载手机版”标签的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelAndroidAPP_MouseEnter(object sender, EventArgs e)
        {
            //载入resource中的手机版下载链接二维码图片，说明标签的文本写入提示信息
            IMG_icon.Image = Properties.Resources.qrcode_AndroidAPP;
            label_IconCaption.Text = "扫一扫下载本软件Android版。";
        }

        /// <summary>
        /// 鼠标离开“下载手机版”标签的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelAndroidAPP_MouseLeave(object sender, EventArgs e)
        {
            //载入resource中的软件图标，说明标签的文本留空
            IMG_icon.Image = Properties.Resources.icon;
            label_IconCaption.Text = string.Empty;
        }

        /// <summary>
        /// 点击“下载手机版”标签响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelAndroidAPP_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.52pojie.cn/thread-1829580-1-1.html");
        }

        /// <summary>
        /// 点击“吾爱破解网址”响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_WebsiteURL_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://" + label_WebsiteURL.Text + "/?fromuid=368698");
        }

        /// <summary>
        /// 点击“访问源代码”标签的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_ViedSource_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/xingshen60771/52ResistanceCalc");
        }

        /// <summary>
        /// 点击“吾爱破解Logo”响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Img_logo_Click(object sender, EventArgs e)
        {
            //执行点击“吾爱破解网址”响应函数
            Label_WebsiteURL_Click(sender, e);
        }

        /// <summary>
        /// 点击“与我联系”按钮响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ContactMe_Click(object sender, EventArgs e)
        {
            //询问是否打开作者主页
            DialogResult contactmeOK = MessageBox.Show("联系我需要登录吾爱破解论坛账号，然后给我发站内信。\r\n发送站内信的时候请遵守论坛版规，禁止留QQ、微信等联系方式，对利用私信留联系方式的行为将从重处罚！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (contactmeOK == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://www.52pojie.cn/home.php?mod=space&uid=368698");
            }
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
