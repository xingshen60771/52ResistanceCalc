using Ionic.Zip;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _52ResistanceCalc
{
    public partial class Form_Help : Form
    {
        /// <summary>
        /// 实例化当前窗体
        /// </summary>
        public Form_Help()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 帮助文件解包百分比
        /// </summary>
        double progress;

        /// <summary>
        /// 目录树节点选中响应函数
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="nodeText"></param>

        private void SelectNode(TreeNode parentNode, string nodeText)
        {
            if (parentNode.Name == nodeText)
            {
                tree_Help.SelectedNode = parentNode;
                return;
            }
            foreach (TreeNode childNode in parentNode.Nodes)
            {
                SelectNode(childNode, nodeText);
            }
        }

        /// <summary>
        /// 帮助文档解包操作函数
        /// </summary>
        private async void UnPack()
        {
            //使用DotNetZip的ZipFile.Read方法读取ZIP文件
            //ZIP文件打包可使用WinRar、7-Zip等常用压缩文件管理软件打包。
            using (var zip = ZipFile.Read(new MemoryStream(Properties.Resources.helpDocument)))
            {
                //置压缩文件解压密码
                //如果ZIP有解压密码，需要在这里输入正确的解压密码，否则无法解压，如果没有解压密码，请将其注释掉，这里我们假设解压密码为“52pojie”
                zip.Password = "52pojie";

                //创建帮助文档文件夹
                if (!Directory.Exists(GlobalVar.helpDocumentsPath))
                {
                    Directory.CreateDirectory(GlobalVar.helpDocumentsPath);
                }
                //设置文件夹为隐藏
                DirectoryInfo dirInfo = new DirectoryInfo(GlobalVar.helpDocumentsPath);
                try
                {
                    //设置文件夹为隐藏
                    dirInfo.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    throw new SystemException("Error:" + ex.Message);
                }
                Directory.CreateDirectory(GlobalVar.helpDocumentsPath + "HelpDocument\\");

                // 指定解压路径
                string extractionPath = GlobalVar.helpDocumentsPath + "HelpDocument\\";

                //处理解压进度百分比
                //这里不知道为什么progress变量出了很多负值，所有这个地方不得不加判断，求大佬解答
                zip.ExtractProgress += (sender, e) =>
                {
                    //百分比计算公式为：已处理文件数÷总文件数×100
                    progress = (double)e.EntriesExtracted / e.EntriesTotal * 100;

                    //调试输出
                    Console.WriteLine("解压缩进度：" + (int)Math.Round(progress, 0));

                    //将进度值反馈到进度条
                    //这里不知道为什么progress变量出了很多负值，所有这个地方不得不加判断，求大佬解答
                    if (progress >= 0 && progress <= 100)
                    {
                        progressBar_UnPack.Value = (int)Math.Round(progress, 0);
                    }
                };

                // 解压文件
                zip.ExtractAll(extractionPath, ExtractExistingFileAction.OverwriteSilently);

                //进度条跑满后隐藏
                if (progressBar_UnPack.Value == 100)
                {
                    //延迟半秒钟，否则会出现进度条没跑满就显示帮助界面了
                    await Task.Delay(500);

                    //显示可分割容器，同时隐藏帮助文件解包进度条和提示标签
                    splitContainer.Visible = true;
                    label_UnPack.Visible = false;
                    progressBar_UnPack.Visible = false;
                }
            }
        }

        /// <summary>
        /// 窗体创建完毕响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Form_Help_Load(object sender, EventArgs e)
        {
            //配置帮助文件解包提示标签的文本、大小、位置
            label_UnPack.Text = "正在解包帮助文档文件，请等待…";
            label_UnPack.Size = new System.Drawing.Size(this.Width, 100);
            label_UnPack.Location = new System.Drawing.Point(0, this.Height / 4 + 30);

            //配置帮助文件解包进度条的大小、位置
            progressBar_UnPack.Width = label_UnPack.Width / 4;
            progressBar_UnPack.Location = new System.Drawing.Point(this.Width / 2 - progressBar_UnPack.Width / 2, label_UnPack.Location.Y + label_UnPack.Height + 50);

            //延迟半秒钟，要不然看不到进度条显示
            await Task.Delay(500);

            //解包帮助文件
            UnPack();

            //判断是否从主窗体的“如何识别电阻色环？”标签点进来的，如果接收到了主窗体设置的逻辑值为真，那么就直接跳转到相应的页面，否则按支持流程打开
            if (GlobalVar.howToIdentifyFlag == true)
            {
                tree_Help.SelectedNode = tree_Help.Nodes[0].Nodes[2].Nodes[1];
                tree_Help.Nodes[0].Nodes[2].Expand();
            }
            else
            {
                tree_Help.SelectedNode = tree_Help.Nodes[0];
            }

            //默认展开一级节点
            tree_Help.Nodes[0].Expand();
        }


        /// <summary>
        /// 帮助文档目录树选择项发生改变时的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void tree_Help_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //选择项为目录树所选项
            TreeNode selectedNode = tree_Help.SelectedNode;

            //选中不同名称的节点跳转到不同网页
            if (selectedNode.Name == "MainHelp")
            {
                web_HelpView.Navigate(GlobalVar.helpDocumentsPath + "HelpDocument\\index.html");
            }
            if (selectedNode.Name == "softinfo")
            {
                web_HelpView.Navigate(GlobalVar.helpDocumentsPath + "HelpDocument\\ReadMe.html");
            }
            if (selectedNode.Name == "HowToUse")
            {
                web_HelpView.Navigate(GlobalVar.helpDocumentsPath + "HelpDocument\\HowToUse.html");
            }
            if (selectedNode.Name == "HowToUse01")
            {
                web_HelpView.Navigate(GlobalVar.helpDocumentsPath + "HelpDocument\\HowToUse.html#01");
            }
            if (selectedNode.Name == "HowToUse02")
            {
                web_HelpView.Navigate(GlobalVar.helpDocumentsPath + "HelpDocument\\HowToUse.html#02");
            }
            if (selectedNode.Name == "HowToUse03")
            {
                web_HelpView.Navigate(GlobalVar.helpDocumentsPath + "HelpDocument\\HowToUse.html#03");
            }
            if (selectedNode.Name == "Knowledge")
            {
                web_HelpView.Navigate(GlobalVar.helpDocumentsPath + "HelpDocument\\Knowledge.html");
            }
            if (selectedNode.Name == "Knowledge01")
            {
                web_HelpView.Navigate(GlobalVar.helpDocumentsPath + "HelpDocument\\Knowledge.html#01");
            }
            if (selectedNode.Name == "Knowledge02")
            {
                web_HelpView.Navigate(GlobalVar.helpDocumentsPath + "HelpDocument\\Knowledge.html#02");
            }
            if (selectedNode.Name == "FAQ")
            {
                web_HelpView.Navigate(GlobalVar.helpDocumentsPath + "HelpDocument\\FAQ.html");
            }
            if (selectedNode.Name == "attention")
            {
                web_HelpView.Navigate(GlobalVar.helpDocumentsPath + "HelpDocument\\Attention.html");
            }
            if (selectedNode.Name == "about")
            {
                web_HelpView.Navigate(GlobalVar.helpDocumentsPath + "HelpDocument\\About.html");
            }
        }


        /// <summary>
        /// 窗体大小发生改变响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Help_SizeChanged(object sender, EventArgs e)
        {
            //调整解包完成前提示标签和进度条的大小和位置
            //可分割容器splitContainer默认是隐藏的，只有在解包完成后才会显示，所以可以把splitContainer是否可视作为判断依据，如果是隐藏状态才会执行此操作
            if (splitContainer.Visible == false)
            {
                label_UnPack.Location = new System.Drawing.Point(0, this.Height / 4);
                label_UnPack.Width = this.Width;
                progressBar_UnPack.Width = label_UnPack.Width / 4;
                progressBar_UnPack.Location = new System.Drawing.Point(this.Width / 2 - progressBar_UnPack.Width / 2, label_UnPack.Location.Y + label_UnPack.Height + 50);
            }

            //当窗体最大化、还原时，高度同步变更
            if (this.WindowState == FormWindowState.Maximized)
            {
                tree_Help.Height = this.Height;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                tree_Help.Height = this.Height;
            }
        }

        /// <summary>
        /// 窗体关闭响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Help_FormClosed(object sender, FormClosedEventArgs e)
        {
            //“如何识别电阻色环？”标记位恢复到默认值
            GlobalVar.howToIdentifyFlag = false;

            try
            {
                // 检查路径是否存在
                if (Directory.Exists(GlobalVar.helpDocumentsPath))
                {
                    // 删除整个文件夹结构，包括其中的所有文件和子目录
                    Directory.Delete(GlobalVar.helpDocumentsPath, true); // 第二个参数设为 true 表示删除包括子文件夹的内容
                }
                else
                {
                    Console.WriteLine($"文件夹 '{GlobalVar.helpDocumentsPath}' 不存在");
                }
            }
            catch (IOException ex)
            {
                //容错处理
                // 捕获并处理删除过程中可能发生的异常
                Console.WriteLine($"Error:{ex.Message}");
                throw new SystemException($"Error:{ex.Message}");
            }
        }

        /// <summary>
        /// 窗体被激活时的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Help_Activated(object sender, EventArgs e)
        {
            //此函数只针对帮助窗口已打开，又从主窗体的“如何识别电阻色环？”标签点击进来的时候触发
            //如果“如何识别电阻色环？”标记位为真、可分割容器splitContainer为显示状态的时候，展开相关页面，并最大化窗体
            if (GlobalVar.howToIdentifyFlag == true && splitContainer.Visible == true)
            {
                tree_Help.SelectedNode = tree_Help.Nodes[0].Nodes[2].Nodes[1];
                GlobalVar.howToIdentifyFlag = false;
                this.WindowState = FormWindowState.Maximized;
            }
        }
    }
}
