namespace _52ResistanceCalc
{
    //本文档为软件全局变量、常量

    /// <summary>
    /// 全局变量
    /// </summary>
    public class GlobalVar
    {
        /// <summary>
        /// 色环数位1
        /// </summary>
        public static long clac_Circle_NUM_1st = -1;                       //数位1

        /// <summary>
        /// 色环数位2
        /// </summary>
        public static long clac_Circle_NUM_2nd = -1;                       //数位2

        /// <summary>
        /// 色环数位3
        /// </summary>
        public static long clac_Circle_NUM_3rd = -1;                       //数位3

        /// <summary>
        /// 色环N次幂
        /// </summary>
        public static double clac_Circle_NUM_Power = -1;                   //N次幂

        /// <summary>
        /// 色环次方底数
        /// </summary>
        public static double clac_Circle_NUM_Base = -1;                   //次方底数

        /// <summary>
        /// 色环次方指数
        /// </summary>
        public static double clac_Circle_NUM_Exponent = -1;               //次方指数

        /// <summary>
        /// 色环误差值(默认为NILL)
        /// </summary>
        public static string clac_Circle_Tolerance = "NULL";              //误差值

        /// <summary>
        /// 色环温度系数(默认为NILL)
        /// </summary>
        public static string clac_Circle_Temperature = "NULL";            //温度系数

        /// <summary>
        /// 计算结果显示文本(默认为空)
        /// </summary>
        public static string resultText = string.Empty;

        /// <summary>
        /// 参与数学计算的电阻阻值
        /// </summary>
        public static double clacresult;                                   //阻值

        /// <summary>
        /// 反馈计算结果的电阻阻值
        /// </summary>
        public static string clacresultA;                                  //阻值

        /// <summary>
        /// 图片保存目录
        /// </summary>
        public static string shareImgPath;                                 //图片保存目录

        /// <summary>
        /// “如何识别电阻色环？”标记位(默认为假)
        /// </summary>
        public static bool howToIdentifyFlag = false;

        /// <summary>
        /// 帮助文档解包路径
        /// </summary>
        public static readonly string helpDocumentsPath = @"C:\" + PublicFunction.GetAPPInformation(4) + "\\";
    }

    /// <summary>
    /// 全局常量
    /// </summary>
    public class GloConst
    {
        /// <summary>
        /// 分享结果文本常量1
        /// </summary>
        public const string cutBoard_01 = "本计算结果由\"吾爱算电阻\"生成！\r\n————————————————————————————————\r\n";

        /// <summary>
        /// 分享结果文本常量2
        /// </summary>
        public const string cutBoard_02 = "\r\n————————————————————————————————\r\n更多精彩，敬请关注吾爱破解论坛微信公众号：pojie_52！\r\n↓↓也可复制下方链接至您的浏览器访问我们的论坛！↓↓\r\n\r\nhttps://www.52pojie.cn/";

        /// <summary>
        /// 软件发布网站常量
        /// </summary>
        public const string softwareWebsite = "https://www.52pojie.cn/thread-1965826-1-1.html";
    }
}
