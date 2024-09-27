using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace _52ResistanceCalc
{
    public partial class Form_ImgSave : Form
    {
        /// <summary>
        /// 实例化当前窗体
        /// </summary>
        public Form_ImgSave()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体创建完毕响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_imgsave_Load(object sender, EventArgs e)
        {
            //加载并播放一个相机快门的音效
            SoundPlayer player = new SoundPlayer();
            player.Stream = Properties.Resources.ResourceManager.GetStream("snd_imgout"); ;
            player.Load();
            player.Play();

            //创建一个文件流
            System.IO.FileStream fs = new System.IO.FileStream(GlobalVar.shareImgPath, FileMode.Open, FileAccess.Read);

            //置文件流长度
            int byteLength = (int)fs.Length;
            byte[] fileBytes = new byte[byteLength];

            //读入文件流，并锁定
            fs.Read(fileBytes, 0, byteLength);

            //关闭文件流,文件解除锁定
            fs.Close();

            MemoryStream mStream = new MemoryStream(fileBytes);
            img_ShareView.Image = System.Drawing.Image.FromStream(mStream);
        }

        /// <summary>
        /// “保存图片”按钮响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SaveAs_Click(object sender, EventArgs e)
        {
            //创建一个“另存为”对话框
            SaveFileDialog savedialog = new SaveFileDialog();

            //对话框标题
            savedialog.Title = "请选择需要保存的位置：";

            //对话框文件过滤器(提供JPG、PMG、BMP、GIF四种格式的图片保存功能)
            savedialog.Filter = "JPEG 图像|*.jpg|可移植网络图像|*.png|Windows位图|*.bmp|GIF 格式图片|*.gif";

            //文件过滤器默认选中0
            savedialog.FilterIndex = 0;

            //保存对话框是否记忆上次打开的目录
            savedialog.RestoreDirectory = true;

            //检查目录
            savedialog.CheckPathExists = false;

            //默认保存路径为我的文档的图片文件夹
            savedialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            //默认文件名为软件英文名称+日期
            savedialog.FileName = "52ResistanceCalc" + "_" + System.DateTime.Now.ToString("yyyy") + "_" + System.DateTime.Now.ToString("MM") + "_" + System.DateTime.Now.ToString("dd") + "_" + System.DateTime.Now.ToString("HH") + "_" + System.DateTime.Now.ToString("mm") + "_" + System.DateTime.Now.ToString("ss"); ;//设置默认文件名


            //根据文件过滤器选定项目来决定文件格式
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                if (savedialog.FilterIndex == 1)
                {
                    img_ShareView.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else if (savedialog.FilterIndex == 2)
                {
                    img_ShareView.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                else if (savedialog.FilterIndex == 3)
                {
                    img_ShareView.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                }
                else if (savedialog.FilterIndex == 4)
                {
                    img_ShareView.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                }

                //保存成功提示
                MessageBox.Show("图片保存成功！点击<确定>按钮后显示保存图片所在文件夹。", "保存完成", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //用Windows浏览器定位所保存的文件
                System.Diagnostics.Process.Start("Explorer", "/select," + savedialog.FileName);
            }
        }

        /// <summary>
        /// 点击“取消”按钮的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
