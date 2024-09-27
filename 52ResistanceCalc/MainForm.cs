using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Media;
using System.Windows.Forms;






namespace _52ResistanceCalc

{
    public partial class MainForm : Form
    {
        //未选定色环色卡提示的消息字符串
        const string msg_title_NoCirle = "数据不全";
        const string msg_text_NoCirle = "请选择色环再指定色卡颜色！";

        //单选框状态码，用于指定现在要进行什么计算操作
        int radstcode;
        //计算模式状态码，用于在分享的时候告诉当前计算的是几色环电阻
        int modecode;

        /// <summary>
        /// 实例化当前窗体
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// &lt;文本型&gt; 换算电阻阻值
        /// <param name="resistance">(双精度小数形 欲换算的数值)</param>
        /// <returns><para>成功返回阻值结果，失败返回"InvalidRequest"。</para></returns>
        /// </summary>
        private string ConvertResistanceValue(double resistance)
        {
            // 阻值换算
            try
            {
                //把单位符号列成一个文本型数组
                String[] units = new String[] { "Ω", "KΩ", "MΩ", "GΩ", "TΩ", "PΩ" };
                //进制为千位
                double mod = 1000.0;
                //开始换算
                int i = 0;
                while (resistance >= mod)
                {
                    resistance /= mod;
                    i++;
                }
                //换算完成，返回结果。
                return Math.Round(resistance, 3) + units[i];
            }
            catch
            {
                //容错处理
                return "InvalidRequest";
            }
        }

        /// <summary>
        /// 电阻阻值的数位操作
        /// </summary>
        public void CircleNUM()
        {
            //置数位1色环颜色选择框可用性。
            radio_black.Enabled = true;
            radio_brown.Enabled = true;
            radio_red.Enabled = true;
            radio_orange.Enabled = true;
            radio_yellow.Enabled = true;
            radio_green.Enabled = true;
            radio_blue.Enabled = true;
            radio_purple.Enabled = true;
            radio_gray.Enabled = true;
            radio_white.Enabled = true;

            //电阻数位没有金、银、及无色色环，出于容错考虑，依然要禁用。
            radio_gold.Enabled = false;
            radio_silver.Enabled = false;
            radio_none.Enabled = false;

            //置色卡数组提示标签数值
            label_black.Text = "0";
            label_brown.Text = "1";
            label_red.Text = "2";
            label_orange.Text = "3";
            label_yellow.Text = "4";
            label_green.Text = "5";
            label_blue.Text = "6";
            label_purple.Text = "7";
            label_gray.Text = "8";
            label_white.Text = "9";
            label_gold.Text = "";
            label_silver.Text = "";
            label_none.Text = "";

            //置色卡单选框选中为假
            radio_black.Checked = false;
            radio_brown.Checked = false;
            radio_red.Checked = false;
            radio_orange.Checked = false;
            radio_yellow.Checked = false;
            radio_green.Checked = false;
            radio_blue.Checked = false;
            radio_purple.Checked = false;
            radio_gray.Checked = false;
            radio_white.Checked = false;
            radio_gold.Checked = false;
            radio_silver.Checked = false;
            radio_none.Checked = false;
        }

        /// <summary>
        /// 电阻阻值的次幂操作
        /// </summary>
        public void CrclePower()
        {
            //置N次幂色环颜色选择框可用性。
            radio_black.Enabled = true;
            radio_brown.Enabled = true;
            radio_red.Enabled = true;
            radio_orange.Enabled = true;
            radio_yellow.Enabled = true;
            radio_green.Enabled = true;
            radio_blue.Enabled = true;
            radio_purple.Enabled = true;
            radio_gray.Enabled = true;
            radio_white.Enabled = true;
            radio_gold.Enabled = true;
            radio_silver.Enabled = true;

            //电阻N次幂没有无色色环，出于容错考虑，依然要禁用。
            radio_none.Enabled = false;

            //置色卡数组提示标签数值
            label_black.Text = "1";
            label_brown.Text = "10^1";
            label_red.Text = "10^2";
            label_orange.Text = "10^3";
            label_yellow.Text = "10^4";
            label_green.Text = "10^5";
            label_blue.Text = "10^6";
            label_purple.Text = "10^7";
            label_gray.Text = "10^8";
            label_white.Text = "10^9";
            label_gold.Text = "10^-1";
            label_silver.Text = "10^-2";
            label_none.Text = "";

            //置色卡单选框选中为假
            radio_black.Checked = false;
            radio_brown.Checked = false;
            radio_red.Checked = false;
            radio_orange.Checked = false;
            radio_yellow.Checked = false;
            radio_green.Checked = false;
            radio_blue.Checked = false;
            radio_purple.Checked = false;
            radio_gray.Checked = false;
            radio_white.Checked = false;
            radio_gold.Checked = false;
            radio_silver.Checked = false;
            radio_none.Checked = false;
        }

        /// <summary>
        /// 电阻误差值操作
        /// </summary>
        public void CircleTolerance()
        {
            //置误差值色环颜色选择框可用性。
            radio_black.Enabled = false;
            radio_brown.Enabled = true;
            radio_red.Enabled = true;
            radio_orange.Enabled = false;
            radio_yellow.Enabled = false;
            radio_green.Enabled = true;
            radio_blue.Enabled = true;
            radio_purple.Enabled = true;
            radio_gray.Enabled = true;
            radio_white.Enabled = false;
            radio_gold.Enabled = true;
            radio_silver.Enabled = true;
            radio_none.Enabled = true;

            //置色卡数组提示标签数值
            label_black.Text = "";
            label_brown.Text = "1%";
            label_red.Text = "2%";
            label_orange.Text = "";
            label_yellow.Text = "";
            label_green.Text = "0.5%";
            label_blue.Text = "0.25%";
            label_purple.Text = "0.1%";
            label_gray.Text = "0.05%";
            label_white.Text = "";
            label_gold.Text = "5%";
            label_silver.Text = "10%";
            label_none.Text = "20%";

            //置色卡单选框选中为假
            radio_black.Checked = false;
            radio_brown.Checked = false;
            radio_red.Checked = false;
            radio_orange.Checked = false;
            radio_yellow.Checked = false;
            radio_green.Checked = false;
            radio_blue.Checked = false;
            radio_purple.Checked = false;
            radio_gray.Checked = false;
            radio_white.Checked = false;
            radio_gold.Checked = false;
            radio_silver.Checked = false;
            radio_none.Checked = false;
        }

        /// <summary>
        /// 电阻温度系数操作
        /// </summary>
        public void CircleTemperature()
        {
            radio_black.Enabled = false;
            radio_brown.Enabled = true;
            radio_red.Enabled = true;
            radio_orange.Enabled = true;
            radio_yellow.Enabled = true;
            radio_green.Enabled = false;
            radio_blue.Enabled = true;
            radio_purple.Enabled = true;
            radio_gray.Enabled = false;
            radio_white.Enabled = true;
            radio_gold.Enabled = false;
            radio_silver.Enabled = false;
            radio_none.Enabled = false;

            //置色卡数组提示标签数值
            label_black.Text = "";
            label_brown.Text = "100ppm";
            label_red.Text = "50ppm";
            label_orange.Text = "15ppm";
            label_yellow.Text = "25ppm";
            label_green.Text = "";
            label_blue.Text = "10ppm";
            label_purple.Text = "5ppm";
            label_gray.Text = "";
            label_white.Text = "1ppm";
            label_gold.Text = "";
            label_silver.Text = "";
            label_none.Text = "";

            //置色卡单选框选中为假
            radio_black.Checked = false;
            radio_brown.Checked = false;
            radio_red.Checked = false;
            radio_orange.Checked = false;
            radio_yellow.Checked = false;
            radio_green.Checked = false;
            radio_blue.Checked = false;
            radio_purple.Checked = false;
            radio_gray.Checked = false;
            radio_white.Checked = false;
            radio_gold.Checked = false;
            radio_silver.Checked = false;
            radio_none.Checked = false;
        }

        /// <summary>
        /// 绘制计算结果分享图
        /// </summary>
        private void DrawImage()
        {
            // 创建一个新的位图对象，宽度为800像素，高度为300像素
            using (Bitmap bmp = new Bitmap(800, 600))
            {
                // 使用Graphics对象来绘制
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    //绘制文字标题
                    Font font_title = new Font("SimHei", 48);
                    Brush brush_title = Brushes.Black;
                    Font font_resistance = new Font("宋体", 10, FontStyle.Bold);
                    Brush brush_resistance = Brushes.Black;
                    g.DrawString("电阻色环图解", font_title, brush_title, new PointF(200, 25));

                    //绘制色环下方数字注释
                    Font font_num = new Font("SimHei", 20, FontStyle.Bold);
                    Brush brush_num = Brushes.Black;
                    Font font_numEx = new Font("SimHei", 14, FontStyle.Bold);
                    Brush brush_numEx = Brushes.Black;

                    //绘制电阻图形本体
                    g.DrawImage(Properties.Resources.Resistance, 150, 100, 500, 214);

                    // 创建画刷
                    Brush blackBrush = new SolidBrush((colorboard_black.BackColor));//黑
                    Brush brownBrush = new SolidBrush((colorboard_brown.BackColor));//棕
                    Brush redBrush = new SolidBrush((colorboard_red.BackColor));//红
                    Brush orangeBrush = new SolidBrush((colorboard_orange.BackColor));//橙
                    Brush yellowBrush = new SolidBrush((colorboard_yellow.BackColor));//黄
                    Brush greenBrush = new SolidBrush((colorboard_green.BackColor));//绿
                    Brush blueBrush = new SolidBrush((colorboard_blue.BackColor));//蓝
                    Brush purpleBrush = new SolidBrush((colorboard_purple.BackColor));//紫
                    Brush grayBrush = new SolidBrush((colorboard_gray.BackColor));//灰
                    Brush whiteBrush = new SolidBrush((colorboard_white.BackColor));//白
                    Brush goldBrush = new SolidBrush((colorboard_gold.BackColor));//金
                    Brush silverBrush = new SolidBrush((colorboard_silver.BackColor));//银
                    Brush noneBrush = new SolidBrush((colorboard_none.BackColor));//银

                    //色环颜色画刷
                    Brush Circle1Color;
                    Brush Circle2Color;
                    Brush Circle3Color;
                    Brush Circle4Color;
                    Brush Circle5Color;
                    Brush Circle6Color;

                    //定义显示数位色环的数组
                    Brush[] NUM1stBrushArray = { blackBrush, brownBrush, redBrush, orangeBrush, yellowBrush, greenBrush, blueBrush, purpleBrush, grayBrush, whiteBrush };
                    Brush[] NUM2ndBrushArray = { blackBrush, brownBrush, redBrush, orangeBrush, yellowBrush, greenBrush, blueBrush, purpleBrush, grayBrush, whiteBrush };
                    Brush[] NUM3rdBrushArray = { blackBrush, brownBrush, redBrush, orangeBrush, yellowBrush, greenBrush, blueBrush, purpleBrush, grayBrush, whiteBrush };

                    //定义显示指数色环的数组
                    Brush[] NUMExponentBrushArray = { blackBrush, brownBrush, redBrush, orangeBrush, yellowBrush, greenBrush, blueBrush, purpleBrush, grayBrush, whiteBrush, goldBrush, silverBrush };

                    //定义显示误差值色环的数组
                    Brush[] ToleranceBrushArray = { brownBrush, redBrush, greenBrush, blueBrush, purpleBrush, grayBrush, goldBrush, silverBrush, noneBrush };

                    //定义显示温度系数色环的数组
                    Brush[] TemperatureBrushArray = { brownBrush, redBrush, orangeBrush, yellowBrush, blueBrush, purpleBrush, whiteBrush };

                    //四色环模式下绘图操作
                    if (FourCircleResistance.Checked == true)
                    {
                        //根据置数位、数位2色环画刷，根据数位变量值决定
                        Circle1Color = NUM1stBrushArray[GlobalVar.clac_Circle_NUM_1st];
                        Circle2Color = NUM2ndBrushArray[GlobalVar.clac_Circle_NUM_2nd];
                        //当基数和指数均为1时，色环画刷置黑色；当基数为10，指数为1时，色环画刷置黑色；其他情况根据指数变量值来置画刷颜色
                        if (GlobalVar.clac_Circle_NUM_Base == 1 & GlobalVar.clac_Circle_NUM_Exponent == 1)
                        {
                            Circle3Color = NUMExponentBrushArray[0];
                        }
                        else if (GlobalVar.clac_Circle_NUM_Base == 10 & GlobalVar.clac_Circle_NUM_Exponent == 1)
                        {
                            Circle3Color = NUMExponentBrushArray[1];
                        }
                        else if (GlobalVar.clac_Circle_NUM_Exponent == -1)
                        {
                            Circle3Color = NUMExponentBrushArray[10];
                        }
                        else if (GlobalVar.clac_Circle_NUM_Exponent == -2)
                        {
                            Circle3Color = NUMExponentBrushArray[11];
                        }
                        else
                        {
                            Circle3Color = NUMExponentBrushArray[Convert.ToInt32(GlobalVar.clac_Circle_NUM_Exponent)];
                        }
                        //根据特定字符串置误差值色环特定画刷颜色
                        if (GlobalVar.clac_Circle_Tolerance == "1")
                        {
                            Circle6Color = ToleranceBrushArray[0];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "2")
                        {
                            Circle6Color = ToleranceBrushArray[1];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "0.5")
                        {
                            Circle6Color = ToleranceBrushArray[2];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "0.25")
                        {
                            Circle6Color = ToleranceBrushArray[3];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "0.1")
                        {
                            Circle6Color = ToleranceBrushArray[4];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "0.05")
                        {
                            Circle6Color = ToleranceBrushArray[5];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "5")
                        {
                            Circle6Color = ToleranceBrushArray[6];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "10")
                        {
                            Circle6Color = ToleranceBrushArray[7];
                        }
                        else
                        {
                            Circle6Color = ToleranceBrushArray[8];
                            //无色色环要绘制一个空心矩形，并绘制“无色”二字。
                            g.DrawRectangle(new Pen(Color.Black, 1), 500, 129, 20, 84);
                            g.DrawString("无\n\n色", font_resistance, brush_resistance, new PointF(501, 145));
                        }

                        //绘制色环及相对应的注释文字
                        g.FillRectangle(Circle1Color, 280, 129, 20, 84);
                        g.DrawString(GlobalVar.clac_Circle_NUM_1st.ToString(), font_num, brush_num, new PointF(280, 240));
                        g.FillRectangle(Circle2Color, 310, 129, 20, 84);
                        g.DrawString(GlobalVar.clac_Circle_NUM_2nd.ToString(), font_num, brush_num, new PointF(310, 240));
                        g.FillRectangle(Circle3Color, 340, 129, 20, 84);
                        g.DrawString(GlobalVar.clac_Circle_NUM_Base.ToString(), font_num, brush_num, new PointF(340, 240));
                        g.DrawString(GlobalVar.clac_Circle_NUM_Exponent.ToString(), font_numEx, brush_numEx, new PointF(370, 225));
                        g.FillRectangle(Circle6Color, 500, 129, 20, 84);
                        g.DrawString("±" + GlobalVar.clac_Circle_Tolerance + "%", font_num, brush_num, new PointF(500, 240));

                    }
                    else if (FiveCircleResistance.Checked == true)
                    {
                        //根据置数位、数位2色环画刷，根据数位变量值决定
                        Circle1Color = NUM1stBrushArray[GlobalVar.clac_Circle_NUM_1st];
                        Circle2Color = NUM2ndBrushArray[GlobalVar.clac_Circle_NUM_2nd];
                        Circle3Color = NUM3rdBrushArray[GlobalVar.clac_Circle_NUM_3rd];
                        //当基数和指数均为1时，色环画刷置黑色；当基数为10，指数为1时，色环画刷置黑色；其他情况根据指数变量值来置画刷颜色
                        if (GlobalVar.clac_Circle_NUM_Base == 1 & GlobalVar.clac_Circle_NUM_Exponent == 1)
                        {
                            Circle4Color = NUMExponentBrushArray[0];
                        }
                        else if (GlobalVar.clac_Circle_NUM_Base == 10 & GlobalVar.clac_Circle_NUM_Exponent == 1)
                        {
                            Circle4Color = NUMExponentBrushArray[1];
                        }
                        else if (GlobalVar.clac_Circle_NUM_Exponent == -1)
                        {
                            Circle4Color = NUMExponentBrushArray[10];
                        }
                        else if (GlobalVar.clac_Circle_NUM_Exponent == -2)
                        {
                            Circle4Color = NUMExponentBrushArray[11];
                        }
                        else
                        {
                            Circle4Color = NUMExponentBrushArray[Convert.ToInt32(GlobalVar.clac_Circle_NUM_Exponent)];
                        }
                        //根据特定字符串置误差值色环特定画刷颜色
                        if (GlobalVar.clac_Circle_Tolerance == "1")
                        {
                            Circle6Color = ToleranceBrushArray[0];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "2")
                        {
                            Circle6Color = ToleranceBrushArray[1];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "0.5")
                        {
                            Circle6Color = ToleranceBrushArray[2];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "0.25")
                        {
                            Circle6Color = ToleranceBrushArray[3];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "0.1")
                        {
                            Circle6Color = ToleranceBrushArray[4];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "0.05")
                        {
                            Circle6Color = ToleranceBrushArray[5];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "5")
                        {
                            Circle6Color = ToleranceBrushArray[6];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "10")
                        {
                            Circle6Color = ToleranceBrushArray[7];
                        }
                        else
                        {
                            Circle6Color = ToleranceBrushArray[8];
                            //无色色环要绘制一个空心矩形，并绘制“无色”二字。
                            g.DrawRectangle(new Pen(Color.Black, 1), 500, 129, 20, 84);
                            g.DrawString("无\n\n色", font_resistance, brush_resistance, new PointF(501, 145));
                        }

                        //绘制色环及相对应的注释文字
                        g.FillRectangle(Circle1Color, 280, 129, 20, 84);
                        g.DrawString(GlobalVar.clac_Circle_NUM_1st.ToString(), font_num, brush_num, new PointF(280, 240));

                        g.FillRectangle(Circle2Color, 310, 129, 20, 84);
                        g.DrawString(GlobalVar.clac_Circle_NUM_2nd.ToString(), font_num, brush_num, new PointF(310, 240));

                        g.FillRectangle(Circle3Color, 340, 129, 20, 84);
                        g.DrawString(GlobalVar.clac_Circle_NUM_3rd.ToString(), font_num, brush_num, new PointF(340, 240));

                        g.FillRectangle(Circle4Color, 370, 129, 20, 84);
                        g.DrawString(GlobalVar.clac_Circle_NUM_Base.ToString(), font_num, brush_num, new PointF(370, 240));
                        g.DrawString(GlobalVar.clac_Circle_NUM_Exponent.ToString(), font_numEx, brush_numEx, new PointF(400, 230));


                        g.FillRectangle(Circle6Color, 500, 129, 20, 84);
                        g.DrawString("±" + GlobalVar.clac_Circle_Tolerance + "%", font_num, brush_num, new PointF(500, 240));
                    }
                    else if (SixCircleResistance.Checked == true)
                    {
                        //根据置数位、数位2色环画刷，根据数位变量值决定
                        Circle1Color = NUM1stBrushArray[GlobalVar.clac_Circle_NUM_1st];
                        Circle2Color = NUM2ndBrushArray[GlobalVar.clac_Circle_NUM_2nd];
                        Circle3Color = NUM3rdBrushArray[GlobalVar.clac_Circle_NUM_3rd];
                        //当基数和指数均为1时，色环画刷置黑色；当基数为10，指数为1时，色环画刷置黑色；其他情况根据指数变量值来置画刷颜色
                        if (GlobalVar.clac_Circle_NUM_Base == 1 & GlobalVar.clac_Circle_NUM_Exponent == 1)
                        {
                            Circle4Color = NUMExponentBrushArray[0];
                        }
                        else if (GlobalVar.clac_Circle_NUM_Base == 10 & GlobalVar.clac_Circle_NUM_Exponent == 1)
                        {
                            Circle4Color = NUMExponentBrushArray[1];
                        }
                        else if (GlobalVar.clac_Circle_NUM_Exponent == -1)
                        {
                            Circle4Color = NUMExponentBrushArray[10];
                        }
                        else if (GlobalVar.clac_Circle_NUM_Exponent == -2)
                        {
                            Circle4Color = NUMExponentBrushArray[11];
                        }
                        else
                        {
                            Circle4Color = NUMExponentBrushArray[Convert.ToInt32(GlobalVar.clac_Circle_NUM_Exponent)];
                        }
                        //根据特定字符串置误差值色环特定画刷颜色
                        if (GlobalVar.clac_Circle_Tolerance == "1")
                        {
                            Circle5Color = ToleranceBrushArray[0];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "2")
                        {
                            Circle5Color = ToleranceBrushArray[1];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "0.5")
                        {
                            Circle5Color = ToleranceBrushArray[2];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "0.25")
                        {
                            Circle5Color = ToleranceBrushArray[3];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "0.1")
                        {
                            Circle5Color = ToleranceBrushArray[4];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "0.05")
                        {
                            Circle5Color = ToleranceBrushArray[5];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "5")
                        {
                            Circle5Color = ToleranceBrushArray[6];
                        }
                        else if (GlobalVar.clac_Circle_Tolerance == "10")
                        {
                            Circle5Color = ToleranceBrushArray[7];
                        }
                        else
                        {
                            Circle5Color = ToleranceBrushArray[8];
                            //无色色环要绘制一个空心矩形，并绘制“无色”二字。
                            g.DrawRectangle(new Pen(Color.Black, 1), 470, 129, 20, 84);
                            g.DrawString("无\n\n色", font_resistance, brush_resistance, new PointF(471, 145));
                        }

                        //根据特定字符串置温度系数色环特定画刷颜色
                        if (GlobalVar.clac_Circle_Temperature == "100")
                        {
                            Circle6Color = TemperatureBrushArray[0];
                        }
                        else if (GlobalVar.clac_Circle_Temperature == "50")
                        {
                            Circle6Color = TemperatureBrushArray[1];
                        }
                        else if (GlobalVar.clac_Circle_Temperature == "15")
                        {
                            Circle6Color = TemperatureBrushArray[2];
                        }
                        else if (GlobalVar.clac_Circle_Temperature == "25")
                        {
                            Circle6Color = TemperatureBrushArray[3];
                        }
                        else if (GlobalVar.clac_Circle_Temperature == "10")
                        {
                            Circle6Color = TemperatureBrushArray[4];
                        }
                        else if (GlobalVar.clac_Circle_Temperature == "5")
                        {
                            Circle6Color = TemperatureBrushArray[5];
                        }
                        else
                        {
                            Circle6Color = TemperatureBrushArray[6];
                        }


                        //绘制色环及相对应的注释文字
                        g.FillRectangle(Circle1Color, 280, 129, 20, 84);
                        g.DrawString(GlobalVar.clac_Circle_NUM_1st.ToString(), font_num, brush_num, new PointF(280, 250));

                        g.FillRectangle(Circle2Color, 310, 129, 20, 84);
                        g.DrawString(GlobalVar.clac_Circle_NUM_2nd.ToString(), font_num, brush_num, new PointF(310, 250));

                        g.FillRectangle(Circle3Color, 340, 129, 20, 84);
                        g.DrawString(GlobalVar.clac_Circle_NUM_3rd.ToString(), font_num, brush_num, new PointF(340, 250));

                        g.FillRectangle(Circle4Color, 370, 129, 20, 84);
                        g.DrawString(GlobalVar.clac_Circle_NUM_Base.ToString(), font_num, brush_num, new PointF(370, 250));
                        g.DrawString(GlobalVar.clac_Circle_NUM_Exponent.ToString(), font_numEx, brush_numEx, new PointF(400, 230));

                        g.FillRectangle(Circle5Color, 470, 129, 20, 84);
                        g.DrawString("±" + GlobalVar.clac_Circle_Tolerance + "%", font_num, brush_num, new PointF(420, 250));

                        g.FillRectangle(Circle6Color, 500, 129, 20, 84);
                        //解决文字覆盖问题
                        double a = Convert.ToDouble(GlobalVar.clac_Circle_Tolerance);
                        if (a < 1.0)
                        {
                            g.DrawLine(new Pen(Color.Black, 2), 510, 215, 510, 240);
                            g.DrawLine(new Pen(Color.Black, 2), 510, 240, 560, 240);
                            g.DrawLine(new Pen(Color.Black, 2), 560, 240, 560, 250);
                            g.DrawString(GlobalVar.clac_Circle_Temperature + "PPM", font_num, brush_num, new PointF(550, 250));
                        }
                        else
                        {
                            g.DrawString(GlobalVar.clac_Circle_Temperature + "PPM", font_num, brush_num, new PointF(500, 250));
                        }
                    }
                    //绘制信息框
                    Brush resultdialog = new SolidBrush(Color.Plum);
                    Brush resultdialogborder = new SolidBrush(Color.MediumOrchid);
                    g.FillRectangle(resultdialog, 210, 290, 380, 150);
                    Pen dashedPen = new Pen(resultdialogborder, 3);
                    dashedPen.DashStyle = DashStyle.Dash;
                    g.DrawRectangle(dashedPen, 210, 290, 380, 150);
                    //绘制结果文本
                    Font font_resulttext = new Font("宋体", 16);
                    Brush brush_resulttext = Brushes.Black;
                    if (FourCircleResistance.Checked == true)
                    {
                        g.DrawString("上图是一个四色环电阻，他的参数为：\n电阻阻值：" + ConvertResistanceValue(GlobalVar.clacresult) + "\n误差值：±" + GlobalVar.clac_Circle_Tolerance + "%\n关于色环的含义请扫右下角第一个二\n维码查看。", font_resulttext, brush_resulttext, new PointF(215, 295));

                    }
                    else if (FiveCircleResistance.Checked == true)
                    {
                        g.DrawString("上图是一个五色环电阻，他的参数为：\n电阻阻值：" + ConvertResistanceValue(GlobalVar.clacresult) + "\n误差值：±" + GlobalVar.clac_Circle_Tolerance + "%\n关于色环的含义请扫右下角第一个二维\n码查看。", font_resulttext, brush_resulttext, new PointF(215, 295));
                    }
                    else
                    {
                        g.DrawString("上图是一个六色环电阻，他的参数为：\n电阻阻值：" + ConvertResistanceValue(GlobalVar.clacresult) + "\n误差值：±" + GlobalVar.clac_Circle_Tolerance + "%\n温度系数：" + GlobalVar.clac_Circle_Temperature + "PPM\n关于色环的含义请扫右下角第一个二维\n码查看。", font_resulttext, brush_resulttext, new PointF(215, 295));
                    }
                    //绘制提示信息文本
                    Font font_description = new Font("SimHei", 12);
                    Brush brush_description = Brushes.Black;
                    g.DrawString("本图片由《" + PublicFunction.GetAPPInformation(1) + "》软件生成，电阻计算结果\r\n仅供参考，实际阻值请以万用表测量结果为准。", font_description, brush_description, new PointF(5, 560));
                    Font font_qrcode = new Font("SimHei", 8);
                    Brush brush_qrcode = Brushes.Black;
                    g.DrawImage(Properties.Resources.qrcode_Knowledge, 460, 450, 100, 100);
                    g.DrawImage(Properties.Resources.qrcode_AndroidAPP, 570, 450, 100, 100);
                    g.DrawImage(Properties.Resources.qrcode_wx, 680, 450, 100, 100);
                    g.DrawString("扫码浏览电阻\r\n  相关知识", font_description, brush_description, new PointF(460, 560));
                    g.DrawString("扫码下载同名\r\nAndroid应用", font_description, brush_description, new PointF(570, 560));
                    g.DrawString("吾爱破解\r\n官方微信", font_description, brush_description, new PointF(695, 560));
                }

                // 保存图片到文件
                string img;
                img = Path.GetTempPath() + "\\tempimg.png";
                GlobalVar.shareImgPath = img;
                if (File.Exists(img) == true)
                {
                    File.Delete(img);
                }
                else
                {
                    bmp.Save(img);
                    GlobalVar.shareImgPath = img;
                }
                bmp.Save(img);
                GlobalVar.shareImgPath = img;
            }
        }

        /// <summary>
        /// 复位色环色卡控件
        /// </summary>
        public void BoardrRset()
        {
            //置色环顺序单选框选中为假
            circle1.Checked = false;
            circle2.Checked = false;
            circle3.Checked = false;
            circle4.Checked = false;
            circle5.Checked = false;
            circle6.Checked = false;

            //置色卡单选框选中为假
            radio_black.Checked = false;
            radio_brown.Checked = false;
            radio_red.Checked = false;
            radio_orange.Checked = false;
            radio_yellow.Checked = false;
            radio_green.Checked = false;
            radio_blue.Checked = false;
            radio_purple.Checked = false;
            radio_gray.Checked = false;
            radio_white.Checked = false;
            radio_gold.Checked = false;
            radio_silver.Checked = false;
            radio_none.Checked = false;

            //置色卡单选框可用为假
            radio_black.Enabled = false;
            radio_brown.Enabled = false;
            radio_red.Enabled = false;
            radio_orange.Enabled = false;
            radio_yellow.Enabled = false;
            radio_green.Enabled = false;
            radio_blue.Enabled = false;
            radio_purple.Enabled = false;
            radio_gray.Enabled = false;
            radio_white.Enabled = false;
            radio_gold.Enabled = false;
            radio_silver.Enabled = false;
            radio_none.Enabled = false;

            //清空色卡数字含义标签文本
            label_black.Text = "";
            label_brown.Text = "";
            label_red.Text = "";
            label_orange.Text = "";
            label_yellow.Text = "";
            label_green.Text = "";
            label_blue.Text = "";
            label_purple.Text = "";
            label_gray.Text = "";
            label_white.Text = "";
            label_gold.Text = "";
            label_silver.Text = "";
            label_none.Text = "";

            //置色环颜色为透明
            colorshow_01.BackColor = Color.Transparent;
            colorshow_02.BackColor = Color.Transparent;
            colorshow_03.BackColor = Color.Transparent;
            colorshow_04.BackColor = Color.Transparent;
            colorshow_05.BackColor = Color.Transparent;
            colorshow_06.BackColor = Color.Transparent;
            colorshow_05.BorderStyle = BorderStyle.None;
            colorshow_06.BorderStyle = BorderStyle.None;

            //清空电阻图形下方的数字含义标签文本
            label_textshow01.Text = "";
            label_textshow02.Text = "";
            label_textshow03.Text = "";
            label_textshow04.Text = "";
            label_textshow05.Text = "";
            label_textshow06.Text = "";

            //置电阻图形下方的置N次幂标签坐标及文本内容
            label_textshowExponent.Location = new Point(240, 120);
            label_textshowExponent.Text = "";
        }

        /// <summary>
        /// 置单选框组合方式状态码
        /// </summary>      
        public void StatCall()
        //以下是置单选框组合方式状态码的函数
        //众所周知，电阻色环在不同情况、不同颜色下的含义是不一样的，状态码就是用来告诉当
        //前这种单选框组合方式时要进行什么计算。
        {
            //列举一切单选框组合
            //列举四色环模式下的四种组合
            if (FourCircleResistance.Checked == true && circle1.Checked == true)
            {
                radstcode = 41;
            }
            else if (FourCircleResistance.Checked == true && circle2.Checked == true)
            {
                radstcode = 42;
            }
            else if (FourCircleResistance.Checked == true && circle3.Checked == true)
            {
                radstcode = 43;
            }
            else if (FourCircleResistance.Checked == true && circle4.Checked == true)
            {
                radstcode = 44;
            }
            else if (FiveCircleResistance.Checked == true && circle1.Checked == true)
            {
                radstcode = 51;
            }
            else if (FiveCircleResistance.Checked == true && circle2.Checked == true)
            {
                radstcode = 52;
            }
            else if (FiveCircleResistance.Checked == true && circle3.Checked == true)
            {
                radstcode = 53;
            }
            else if (FiveCircleResistance.Checked == true && circle4.Checked == true)
            {
                radstcode = 54;
            }
            else if (FiveCircleResistance.Checked == true && circle5.Checked == true)
            {
                radstcode = 55;
            }
            else if (SixCircleResistance.Checked == true && circle1.Checked == true)
            {
                radstcode = 61;
            }
            else if (SixCircleResistance.Checked == true && circle2.Checked == true)
            {
                radstcode = 62;
            }
            else if (SixCircleResistance.Checked == true && circle3.Checked == true)
            {
                radstcode = 63;
            }
            else if (SixCircleResistance.Checked == true && circle4.Checked == true)
            {
                radstcode = 64;
            }
            else if (SixCircleResistance.Checked == true && circle5.Checked == true)
            {
                radstcode = 65;
            }
            else if (SixCircleResistance.Checked == true && circle6.Checked == true)
            {
                radstcode = 66;
            }
            Console.WriteLine("当前状态码为： " + radstcode.ToString());
        }

        /// <summary>
        /// 检查当前计算模式
        /// </summary>
        public void ModeCheck()
        //计算模式检查
        //此函数用于指定当前计算的是几色环电阻，以便在分享的时候准确显示。
        {
            if (FourCircleResistance.Checked == true)
            {
                modecode = 40;
            }
            else if (FiveCircleResistance.Checked == true)
            {
                modecode = 50;
            }
            else if (SixCircleResistance.Checked == true)
            {
                modecode = 60;
            }
        }

        /// <summary>
        /// 窗体创建完毕响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //显示软件闪屏（即启动画面）
            Form_Splash Form_Spalsh = new Form_Splash(this);
            Form_Spalsh.Show();
            this.Hide();

            //置窗口标题为软件名称+版本+软件原名称
            this.Text = PublicFunction.GetAPPInformation(1) + "  " + PublicFunction.GetAPPInformation(2).Substring(0, 9) + "（原《多功能电阻色环计算工具》）";

            //复位电阻色环、数值提示标签的样式
            colorshow_01.BorderStyle = BorderStyle.None;
            colorshow_02.BorderStyle = BorderStyle.None;
            colorshow_03.BorderStyle = BorderStyle.None;
            colorshow_04.BorderStyle = BorderStyle.None;
            colorshow_05.BorderStyle = BorderStyle.None;
            colorshow_06.BorderStyle = BorderStyle.None;
            label_textshow01.BorderStyle = BorderStyle.None;
            label_textshow02.BorderStyle = BorderStyle.None;
            label_textshow03.BorderStyle = BorderStyle.None;
            label_textshow04.BorderStyle = BorderStyle.None;
            label_textshow05.BorderStyle = BorderStyle.None;
            label_textshow06.BorderStyle = BorderStyle.None;
            label_textshowExponent.BorderStyle = BorderStyle.None;

            //默认选中四色环电阻
            FourCircleResistance.Checked = true;

            //将色环纳入电阻图形控件的父级控件
            img_resistance.Controls.Add(colorshow_01);
            img_resistance.Controls.Add(colorshow_02);
            img_resistance.Controls.Add(colorshow_03);
            img_resistance.Controls.Add(colorshow_04);
            img_resistance.Controls.Add(colorshow_05);
            img_resistance.Controls.Add(colorshow_06);
            img_resistance.Controls.Add(label_textshow01);
            img_resistance.Controls.Add(label_textshow02);
            img_resistance.Controls.Add(label_textshow03);
            img_resistance.Controls.Add(label_textshow04);
            img_resistance.Controls.Add(label_textshow05);
            img_resistance.Controls.Add(label_textshow06);
            img_resistance.Controls.Add(label_textshowExponent);
        }

        /// <summary>
        /// 四色环计算模式的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FourCircleResistance_CheckedChanged(object sender, EventArgs e)
        {
            //设置色环数单选框文本及显示状态
            circle1.Visible = true;
            circle1.Text = "第一色环（数位1）";
            circle2.Visible = true;
            circle2.Text = "第二色环（数位2）";
            circle3.Visible = true;
            circle3.Text = "第三色环（10的N次幂）";
            circle4.Visible = true;
            circle4.Text = "第四色环（误差值）";
            circle5.Visible = false;
            circle5.Text = "none";
            circle6.Visible = false;
            circle6.Text = "none";
            //复位色环色卡
            BoardrRset();
        }

        /// <summary>
        /// 五色环计算模式的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FiveCircleResistance_CheckedChanged(object sender, EventArgs e)
        {
            //设置色环数单选框文本及显示状态
            circle1.Visible = true;
            circle1.Text = "第一色环（数位1）";
            circle2.Visible = true;
            circle2.Text = "第二色环（数位2）";
            circle3.Visible = true;
            circle3.Text = "第三色环（数位3）";
            circle4.Visible = true;
            circle4.Text = "第四色环（10的N次幂）";
            circle5.Visible = true;
            circle5.Text = "第五色环（误差值）";
            circle6.Visible = false;
            circle6.Text = "none";
            //复位色环色卡
            BoardrRset();
        }

        /// <summary>
        /// 六色环计算模式的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SixCircleResistance_CheckedChanged(object sender, EventArgs e)
        {
            //设置色环数单选框文本及显示状态
            circle1.Visible = true;
            circle1.Text = "第一色环（数位1）";
            circle2.Visible = true;
            circle2.Text = "第二色环（数位2）";
            circle3.Visible = true;
            circle3.Text = "第三色环（数位3）";
            circle4.Visible = true;
            circle4.Text = "第四色环（10的N次幂）";
            circle5.Visible = true;
            circle5.Text = "第五色环（误差值）";
            circle6.Visible = true;
            circle6.Text = "第六色环（温度系数）";
            //复位色环色卡
            BoardrRset();
        }


        /// <summary>
        /// 第一色环复选框选中响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Circle1_CheckedChanged(object sender, EventArgs e)
        {
            radio_black.Checked = false;
            CircleNUM();
            StatCall();
        }

        /// <summary>
        /// 第二色环复选框选中响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Circle2_CheckedChanged(object sender, EventArgs e)
        {
            radio_black.Checked = false;
            CircleNUM();
            StatCall();
        }

        /// <summary>
        /// 第三色环复选框选中响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Circle3_CheckedChanged(object sender, EventArgs e)
        {
            //分两种情况，如果是四色环电阻，此选项为选择N次幂色环，否则就是选择数位3色环。
            if (FourCircleResistance.Checked == true)
            {
                CrclePower();
            }
            else
            {
                CircleNUM();
            }
            StatCall();
        }

        /// <summary>
        /// 第四色环复选框选中响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Circle4_CheckedChanged(object sender, EventArgs e)
        {
            //分两种情况，如果是四色环电阻，此选项为选择误差值，否则就是选择N次幂色环色环。
            if (FourCircleResistance.Checked == true)
            {
                CircleTolerance();
            }
            else
            {
                CrclePower();
            }
            StatCall();
        }

        /// <summary>
        /// 第五色环复选框选中响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Circle5_CheckedChanged(object sender, EventArgs e)
        {
            CircleTolerance();
            StatCall();
        }

        /// <summary>
        /// 第六色环复选框选中响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Circle6_CheckedChanged(object sender, EventArgs e)
        {
            //只有六色环才会有温度系数。
            CircleTemperature();
            StatCall();
        }

        /// <summary>
        /// 黑色色环复选框选中响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Radio_black_CheckedChanged(object sender, EventArgs e)
        {
            switch (radstcode)
            {
                //列举出四色环模式下黑色色环可能出现的结果。
                //四色环数位1
                case 41:
                    GlobalVar.clac_Circle_NUM_1st = 0;
                    colorshow_01.BackColor = colorboard_black.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //四色环数位2
                case 42:
                    GlobalVar.clac_Circle_NUM_2nd = 0;
                    colorshow_02.BackColor = colorboard_black.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //四色环N次幂
                case 43:
                    GlobalVar.clac_Circle_NUM_Base = 1;
                    GlobalVar.clac_Circle_NUM_Exponent = 1;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_03.BackColor = colorboard_black.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_Power.ToString();
                    //移动电阻图形下方数字含义标签的N次幂控件
                    label_textshowExponent.Location = new Point(212, 120);
                    label_textshowExponent.Text = "";
                    break;
                //没有用黑色表示的误差值和温度系数的色环，故状态码45、46不存在

                //列举出五色环模式下黑色色环可能出现的结果。
                //五色环数位1
                case 51:
                    GlobalVar.clac_Circle_NUM_1st = 0;
                    colorshow_01.BackColor = colorboard_black.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //五色环数位2
                case 52:
                    GlobalVar.clac_Circle_NUM_2nd = 0;
                    colorshow_02.BackColor = colorboard_black.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //五色环数位3
                case 53:
                    GlobalVar.clac_Circle_NUM_3rd = 0;
                    colorshow_03.BackColor = colorboard_black.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //五色环N次幂
                case 54:
                    GlobalVar.clac_Circle_NUM_Base = 1;
                    GlobalVar.clac_Circle_NUM_Exponent = 1;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_04.BackColor = colorboard_black.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Power.ToString();
                    label_textshowExponent.Text = "";
                    break;
                //没有用黑色表示的误差值和温度系数的色环，故状态码545、56不存在

                //列举出六色环模式下黑色色环可能出现的结果。
                //六色环数位1
                case 61:
                    GlobalVar.clac_Circle_NUM_1st = 0;
                    colorshow_01.BackColor = colorboard_black.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //六色环数位2
                case 62:
                    GlobalVar.clac_Circle_NUM_2nd = 0;
                    colorshow_02.BackColor = colorboard_black.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //六色环数位3
                case 63:
                    GlobalVar.clac_Circle_NUM_3rd = 0;
                    colorshow_03.BackColor = colorboard_black.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //六色环N次幂
                case 64:
                    GlobalVar.clac_Circle_NUM_Base = 1;
                    GlobalVar.clac_Circle_NUM_Exponent = 1;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_04.BackColor = colorboard_black.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Power.ToString();
                    label_textshowExponent.Text = "";
                    break;
                    //没有用黑色表示的误差值和温度系数的色环，故状态码65、66不存在
            }
            //只有在误差值不为20%时才触发去除色环边框事件
            if (GlobalVar.clac_Circle_Tolerance != "20")
            {
                colorshow_05.BorderStyle = BorderStyle.None;
                colorshow_06.BorderStyle = BorderStyle.None;
            }

            //调试输出色环数值以检查Switch操作是否正确
            Console.WriteLine("---------------------------调试输出色环数值---------------------------" + "\n" +
                "第一色环为：" + GlobalVar.clac_Circle_NUM_1st.ToString() + "\n" +
                "第二色环为：" + GlobalVar.clac_Circle_NUM_2nd.ToString() + "\n" +
                "第三色环为：" + GlobalVar.clac_Circle_NUM_3rd.ToString() + "\n" +
                "N次幂色环为：" + GlobalVar.clac_Circle_NUM_Power.ToString() + "\n" +
                "误差值色环为：" + GlobalVar.clac_Circle_Tolerance.ToString() + "\n" +
                "温度系数色环为：" + GlobalVar.clac_Circle_Temperature.ToString() + "\n" +
                "---------------------------调试输出到此结束---------------------------");
        }

        /// <summary>
        /// 棕色色环复选框选中响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Radio_brown_CheckedChanged(object sender, EventArgs e)
        {
            switch (radstcode)
            {
                //列举出四色环模式下棕色色环可能出现的结果。
                //四色环数位1
                case 41:
                    GlobalVar.clac_Circle_NUM_1st = 1;
                    colorshow_01.BackColor = colorboard_brown.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //四色环数位2
                case 42:
                    GlobalVar.clac_Circle_NUM_2nd = 1;
                    colorshow_02.BackColor = colorboard_brown.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //四色环N次幂
                case 43:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 1;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_03.BackColor = colorboard_brown.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //移动电阻图形下方数字含义标签的N次幂控件并显示N次幂数值
                    label_textshowExponent.Location = new Point(212, 120);
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString();
                    break;
                //四色环误差值
                case 44:
                    GlobalVar.clac_Circle_Tolerance = "1";
                    colorshow_06.BackColor = colorboard_brown.BackColor;
                    label_textshow06.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;

                //列举出五色环模式下棕色色环可能出现的结果。
                //五色环数位1
                case 51:
                    GlobalVar.clac_Circle_NUM_1st = 1;
                    colorshow_01.BackColor = colorboard_brown.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //五色环数位2
                case 52:
                    GlobalVar.clac_Circle_NUM_2nd = 1;
                    colorshow_02.BackColor = colorboard_brown.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //五色环数位3
                case 53:
                    GlobalVar.clac_Circle_NUM_3rd = 1;
                    colorshow_03.BackColor = colorboard_brown.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //五色环N次幂
                case 54:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 1;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_04.BackColor = colorboard_brown.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //五色环误差值
                case 55:
                    GlobalVar.clac_Circle_Tolerance = "1";
                    colorshow_06.BackColor = colorboard_brown.BackColor;
                    label_textshow06.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;

                //列举出六色环模式下棕色色环可能出现的结果。
                //六色环数位1
                case 61:
                    GlobalVar.clac_Circle_NUM_1st = 1;
                    colorshow_01.BackColor = colorboard_brown.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //六色环数位2
                case 62:
                    GlobalVar.clac_Circle_NUM_2nd = 1;
                    colorshow_02.BackColor = colorboard_brown.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //六色环数位3
                case 63:
                    GlobalVar.clac_Circle_NUM_3rd = 1;
                    colorshow_03.BackColor = colorboard_brown.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //六色环N次幂
                case 64:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 1;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent)); ;
                    colorshow_04.BackColor = colorboard_brown.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //六色环误差值
                case 65:
                    GlobalVar.clac_Circle_Tolerance = "1";
                    colorshow_05.BackColor = colorboard_brown.BackColor;
                    label_textshow05.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;
                //六色环温度系数
                case 66:
                    GlobalVar.clac_Circle_Temperature = "100";
                    colorshow_06.BackColor = colorboard_brown.BackColor;
                    label_textshow06.Text = GlobalVar.clac_Circle_Temperature + "PPM";
                    break;
            }
            //只有在误差值不为20%时才触发去除色环边框事件
            if (GlobalVar.clac_Circle_Tolerance != "20")
            {
                colorshow_05.BorderStyle = BorderStyle.None;
                colorshow_06.BorderStyle = BorderStyle.None;
            }
            //调试输出色环数值以检查Switch操作是否正确
            Console.WriteLine("---------------------------调试输出色环数值---------------------------" + "\n" +
                "第一色环为：" + GlobalVar.clac_Circle_NUM_1st.ToString() + "\n" +
                "第二色环为：" + GlobalVar.clac_Circle_NUM_2nd.ToString() + "\n" +
                "第三色环为：" + GlobalVar.clac_Circle_NUM_3rd.ToString() + "\n" +
                "N次幂色环为：" + GlobalVar.clac_Circle_NUM_Power.ToString() + "\n" +
                "误差值色环为：" + GlobalVar.clac_Circle_Tolerance.ToString() + "\n" +
                "温度系数色环为：" + GlobalVar.clac_Circle_Temperature.ToString() + "\n" +
                "---------------------------调试输出到此结束---------------------------");
        }

        /// <summary>
        /// 红色色环复选框选中响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Radio_red_CheckedChanged(object sender, EventArgs e)
        {
            switch (radstcode)
            {
                //列举出四色环模式下红色色环可能出现的结果。
                //四色环数位1
                case 41:
                    GlobalVar.clac_Circle_NUM_1st = 2;
                    colorshow_01.BackColor = colorboard_red.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //四色环数位2
                case 42:
                    GlobalVar.clac_Circle_NUM_2nd = 2;
                    colorshow_02.BackColor = colorboard_red.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //四色环N次幂
                case 43:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 2;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_03.BackColor = colorboard_red.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //移动电阻图形下方数字含义标签的N次幂控件并显示N次幂数值
                    label_textshowExponent.Location = new Point(212, 120);
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString();
                    break;
                //四色环误差值
                case 44:
                    GlobalVar.clac_Circle_Tolerance = "2";
                    colorshow_06.BackColor = colorboard_red.BackColor;
                    label_textshow06.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;

                //列举出五色环模式下红色色环可能出现的结果。
                //五色环数位1
                case 51:
                    GlobalVar.clac_Circle_NUM_1st = 2;
                    colorshow_01.BackColor = colorboard_red.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //五色环数位2
                case 52:
                    GlobalVar.clac_Circle_NUM_2nd = 2;
                    colorshow_02.BackColor = colorboard_red.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //五色环数位3
                case 53:
                    GlobalVar.clac_Circle_NUM_3rd = 2;
                    colorshow_03.BackColor = colorboard_red.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //五色环N次幂
                case 54:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 2;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_04.BackColor = colorboard_red.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //五色环误差值
                case 55:
                    GlobalVar.clac_Circle_Tolerance = "2";
                    colorshow_06.BackColor = colorboard_red.BackColor;
                    label_textshow06.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;

                //列举出六色环模式下红色色环可能出现的结果。
                //六色环数位1
                case 61:
                    GlobalVar.clac_Circle_NUM_1st = 2;
                    colorshow_01.BackColor = colorboard_red.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //六色环数位2
                case 62:
                    GlobalVar.clac_Circle_NUM_2nd = 2;
                    colorshow_02.BackColor = colorboard_red.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //六色环数位3
                case 63:
                    GlobalVar.clac_Circle_NUM_3rd = 2;
                    colorshow_03.BackColor = colorboard_red.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //六色环N次幂
                case 64:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 2;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent)); ;
                    colorshow_04.BackColor = colorboard_red.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //六色环误差值
                case 65:
                    GlobalVar.clac_Circle_Tolerance = "2";
                    colorshow_05.BackColor = colorboard_red.BackColor;
                    label_textshow05.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;
                //六色环温度系数
                case 66:
                    GlobalVar.clac_Circle_Temperature = "50";
                    colorshow_06.BackColor = colorboard_red.BackColor;
                    label_textshow06.Text = GlobalVar.clac_Circle_Temperature + "PPM";
                    break;
            }
            //只有在误差值不为20%时才触发去除色环边框事件
            if (GlobalVar.clac_Circle_Tolerance != "20")
            {
                colorshow_05.BorderStyle = BorderStyle.None;
                colorshow_06.BorderStyle = BorderStyle.None;
            }
            //调试输出色环数值以检查Switch操作是否正确
            Console.WriteLine("---------------------------调试输出色环数值---------------------------" + "\n" +
                "第一色环为：" + GlobalVar.clac_Circle_NUM_1st.ToString() + "\n" +
                "第二色环为：" + GlobalVar.clac_Circle_NUM_2nd.ToString() + "\n" +
                "第三色环为：" + GlobalVar.clac_Circle_NUM_3rd.ToString() + "\n" +
                "N次幂色环为：" + GlobalVar.clac_Circle_NUM_Power.ToString() + "\n" +
                "误差值色环为：" + GlobalVar.clac_Circle_Tolerance.ToString() + "\n" +
                "温度系数色环为：" + GlobalVar.clac_Circle_Temperature.ToString() + "\n" +
                "---------------------------调试输出到此结束---------------------------");
        }

        /// <summary>
        /// 橙色色环复选框选中响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Radio_orange_CheckedChanged(object sender, EventArgs e)
        {
            switch (radstcode)
            {
                //列举出四色环模式下橙色色环可能出现的结果。
                //四色环数位1
                case 41:
                    GlobalVar.clac_Circle_NUM_1st = 3;
                    colorshow_01.BackColor = colorboard_orange.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //四色环数位2
                case 42:
                    GlobalVar.clac_Circle_NUM_2nd = 3;
                    colorshow_02.BackColor = colorboard_orange.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //四色环N次幂
                case 43:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 3;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_03.BackColor = colorboard_orange.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //移动电阻图形下方数字含义标签的N次幂控件并显示N次幂数值
                    label_textshowExponent.Location = new Point(212, 120);
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString();
                    break;
                //没有用橙色表示的误差值的色环，故状态码45不存在


                //列举出五色环模式下橙色色环可能出现的结果。
                //五色环数位1
                case 51:
                    GlobalVar.clac_Circle_NUM_1st = 3;
                    colorshow_01.BackColor = colorboard_orange.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //五色环数位2
                case 52:
                    GlobalVar.clac_Circle_NUM_2nd = 3;
                    colorshow_02.BackColor = colorboard_orange.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //五色环数位3
                case 53:
                    GlobalVar.clac_Circle_NUM_3rd = 3;
                    colorshow_03.BackColor = colorboard_orange.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //五色环N次幂
                case 54:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 3;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_04.BackColor = colorboard_orange.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //没有用橙色表示的误差值的色环，故状态码55不存在

                //列举出六色环模式下橙色色环可能出现的结果。
                //六色环数位1
                case 61:
                    GlobalVar.clac_Circle_NUM_1st = 3;
                    colorshow_01.BackColor = colorboard_orange.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //六色环数位2
                case 62:
                    GlobalVar.clac_Circle_NUM_2nd = 3;
                    colorshow_02.BackColor = colorboard_orange.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //六色环数位3
                case 63:
                    GlobalVar.clac_Circle_NUM_3rd = 3;
                    colorshow_03.BackColor = colorboard_orange.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //六色环N次幂
                case 64:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 3;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent)); ;
                    colorshow_04.BackColor = colorboard_orange.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //没有用橙色表示的误差值的色环，故状态码45不存在

                //六色环温度系数
                case 66:
                    GlobalVar.clac_Circle_Temperature = "15";
                    colorshow_06.BackColor = colorboard_orange.BackColor;
                    label_textshow06.Text = GlobalVar.clac_Circle_Temperature + "PPM";
                    break;
            }
            //只有在误差值不为20%时才触发去除色环边框事件
            if (GlobalVar.clac_Circle_Tolerance != "20")
            {
                colorshow_05.BorderStyle = BorderStyle.None;
                colorshow_06.BorderStyle = BorderStyle.None;
            }
            //调试输出色环数值以检查Switch操作是否正确
            Console.WriteLine("---------------------------调试输出色环数值---------------------------" + "\n" +
                "第一色环为：" + GlobalVar.clac_Circle_NUM_1st.ToString() + "\n" +
                "第二色环为：" + GlobalVar.clac_Circle_NUM_2nd.ToString() + "\n" +
                "第三色环为：" + GlobalVar.clac_Circle_NUM_3rd.ToString() + "\n" +
                "N次幂色环为：" + GlobalVar.clac_Circle_NUM_Power.ToString() + "\n" +
                "误差值色环为：" + GlobalVar.clac_Circle_Tolerance.ToString() + "\n" +
                "温度系数色环为：" + GlobalVar.clac_Circle_Temperature.ToString() + "\n" +
                "---------------------------调试输出到此结束---------------------------");
        }

        /// <summary>
        /// 黄色色环复选框选中响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Radio_yellow_CheckedChanged(object sender, EventArgs e)
        {
            switch (radstcode)
            {
                //列举出四色环模式下黄色色环可能出现的结果。
                //四色环数位1
                case 41:
                    GlobalVar.clac_Circle_NUM_1st = 4;
                    colorshow_01.BackColor = colorboard_yellow.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //四色环数位2
                case 42:
                    GlobalVar.clac_Circle_NUM_2nd = 4;
                    colorshow_02.BackColor = colorboard_yellow.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //四色环N次幂
                case 43:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 4;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_03.BackColor = colorboard_yellow.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //移动电阻图形下方数字含义标签的N次幂控件并显示N次幂数值
                    label_textshowExponent.Location = new Point(212, 120);
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString();
                    break;
                //没有用黄色表示的误差值的色环，故状态码45不存在


                //列举出五色环模式下黄色色环可能出现的结果。
                //五色环数位1
                case 51:
                    GlobalVar.clac_Circle_NUM_1st = 4;
                    colorshow_01.BackColor = colorboard_yellow.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //五色环数位2
                case 52:
                    GlobalVar.clac_Circle_NUM_2nd = 4;
                    colorshow_02.BackColor = colorboard_yellow.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //五色环数位3
                case 53:
                    GlobalVar.clac_Circle_NUM_3rd = 4;
                    colorshow_03.BackColor = colorboard_yellow.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //五色环N次幂
                case 54:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 4;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_04.BackColor = colorboard_yellow.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //没有用黄色表示的误差值的色环，故状态码55不存在

                //列举出六色环模式下黄色色环可能出现的结果。
                //六色环数位1
                case 61:
                    GlobalVar.clac_Circle_NUM_1st = 4;
                    colorshow_01.BackColor = colorboard_yellow.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //六色环数位2
                case 62:
                    GlobalVar.clac_Circle_NUM_2nd = 4;
                    colorshow_02.BackColor = colorboard_yellow.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //六色环数位3
                case 63:
                    GlobalVar.clac_Circle_NUM_3rd = 4;
                    colorshow_03.BackColor = colorboard_yellow.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //六色环N次幂
                case 64:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 4;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent)); ;
                    colorshow_04.BackColor = colorboard_yellow.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //没有用黄色表示的误差值的色环，故状态码45不存在

                //六色环温度系数
                case 66:
                    GlobalVar.clac_Circle_Temperature = "25";
                    colorshow_06.BackColor = colorboard_yellow.BackColor;
                    label_textshow06.Text = GlobalVar.clac_Circle_Temperature + "PPM";
                    break;
            }
            //只有在误差值不为20%时才触发去除色环边框事件
            if (GlobalVar.clac_Circle_Tolerance != "20")
            {
                colorshow_05.BorderStyle = BorderStyle.None;
                colorshow_06.BorderStyle = BorderStyle.None;
            }
            //调试输出色环数值以检查Switch操作是否正确
            Console.WriteLine("---------------------------调试输出色环数值---------------------------" + "\n" +
                "第一色环为：" + GlobalVar.clac_Circle_NUM_1st.ToString() + "\n" +
                "第二色环为：" + GlobalVar.clac_Circle_NUM_2nd.ToString() + "\n" +
                "第三色环为：" + GlobalVar.clac_Circle_NUM_3rd.ToString() + "\n" +
                "N次幂色环为：" + GlobalVar.clac_Circle_NUM_Power.ToString() + "\n" +
                "误差值色环为：" + GlobalVar.clac_Circle_Tolerance.ToString() + "\n" +
                "温度系数色环为：" + GlobalVar.clac_Circle_Temperature.ToString() + "\n" +
                "---------------------------调试输出到此结束---------------------------");
        }

        /// <summary>
        /// 绿色色环复选框选中响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Radio_green_CheckedChanged(object sender, EventArgs e)
        {
            switch (radstcode)
            {
                //列举出四色环模式下绿色色环可能出现的结果。
                //四色环数位1
                case 41:
                    GlobalVar.clac_Circle_NUM_1st = 5;
                    colorshow_01.BackColor = colorboard_green.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //四色环数位2
                case 42:
                    GlobalVar.clac_Circle_NUM_2nd = 5;
                    colorshow_02.BackColor = colorboard_green.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //四色环N次幂
                case 43:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 5;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_03.BackColor = colorboard_green.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //移动电阻图形下方数字含义标签的N次幂控件并显示N次幂数值
                    label_textshowExponent.Location = new Point(212, 120);
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString();
                    break;
                //四色环误差值
                case 44:
                    GlobalVar.clac_Circle_Tolerance = "0.5";
                    colorshow_06.BackColor = colorboard_green.BackColor;
                    label_textshow06.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;

                //列举出五色环模式下绿色色环可能出现的结果。
                //五色环数位1
                case 51:
                    GlobalVar.clac_Circle_NUM_1st = 5;
                    colorshow_01.BackColor = colorboard_green.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //五色环数位2
                case 52:
                    GlobalVar.clac_Circle_NUM_2nd = 5;
                    colorshow_02.BackColor = colorboard_green.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //五色环数位3
                case 53:
                    GlobalVar.clac_Circle_NUM_3rd = 5;
                    colorshow_03.BackColor = colorboard_green.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //五色环N次幂
                case 54:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 5;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_04.BackColor = colorboard_green.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //五色环误差值
                case 55:
                    GlobalVar.clac_Circle_Tolerance = "0.5";
                    colorshow_06.BackColor = colorboard_green.BackColor;
                    label_textshow06.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;

                //列举出六色环模式下绿色色环可能出现的结果。
                //六色环数位1
                case 61:
                    GlobalVar.clac_Circle_NUM_1st = 5;
                    colorshow_01.BackColor = colorboard_green.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //六色环数位2
                case 62:
                    GlobalVar.clac_Circle_NUM_2nd = 5;
                    colorshow_02.BackColor = colorboard_green.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //六色环数位3
                case 63:
                    GlobalVar.clac_Circle_NUM_3rd = 5;
                    colorshow_03.BackColor = colorboard_green.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //六色环N次幂
                case 64:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 5;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent)); ;
                    colorshow_04.BackColor = colorboard_green.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //六色环误差值
                case 65:
                    GlobalVar.clac_Circle_Tolerance = "0.5";
                    colorshow_05.BackColor = colorboard_green.BackColor;
                    label_textshow05.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;
                    //没有用绿色表示的温度系数的色环，故状态码66不存在
            }
            //只有在误差值不为20%时才触发去除色环边框事件
            if (GlobalVar.clac_Circle_Tolerance != "20")
            {
                colorshow_05.BorderStyle = BorderStyle.None;
                colorshow_06.BorderStyle = BorderStyle.None;
            }
            //调试输出色环数值以检查Switch操作是否正确
            Console.WriteLine("---------------------------调试输出色环数值---------------------------" + "\n" +
                "第一色环为：" + GlobalVar.clac_Circle_NUM_1st.ToString() + "\n" +
                "第二色环为：" + GlobalVar.clac_Circle_NUM_2nd.ToString() + "\n" +
                "第三色环为：" + GlobalVar.clac_Circle_NUM_3rd.ToString() + "\n" +
                "N次幂色环为：" + GlobalVar.clac_Circle_NUM_Power.ToString() + "\n" +
                "误差值色环为：" + GlobalVar.clac_Circle_Tolerance.ToString() + "\n" +
                "温度系数色环为：" + GlobalVar.clac_Circle_Temperature.ToString() + "\n" +
                "---------------------------调试输出到此结束---------------------------");
        }

        /// <summary>
        /// 蓝色色环复选框选中响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Radio_blue_CheckedChanged(object sender, EventArgs e)
        {
            switch (radstcode)
            {
                //列举出四色环模式下蓝色色环可能出现的结果。
                //四色环数位1
                case 41:
                    GlobalVar.clac_Circle_NUM_1st = 6;
                    colorshow_01.BackColor = colorboard_blue.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //四色环数位2
                case 42:
                    GlobalVar.clac_Circle_NUM_2nd = 6;
                    colorshow_02.BackColor = colorboard_blue.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //四色环N次幂
                case 43:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 6;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_03.BackColor = colorboard_blue.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //移动电阻图形下方数字含义标签的N次幂控件并显示N次幂数值
                    label_textshowExponent.Location = new Point(212, 120);
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString();
                    break;
                //四色环误差值
                case 44:
                    GlobalVar.clac_Circle_Tolerance = "0.25";
                    colorshow_06.BackColor = colorboard_blue.BackColor;
                    label_textshow06.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;

                //列举出五色环模式下蓝色色环可能出现的结果。
                //五色环数位1
                case 51:
                    GlobalVar.clac_Circle_NUM_1st = 6;
                    colorshow_01.BackColor = colorboard_blue.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //五色环数位2
                case 52:
                    GlobalVar.clac_Circle_NUM_2nd = 6;
                    colorshow_02.BackColor = colorboard_blue.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //五色环数位3
                case 53:
                    GlobalVar.clac_Circle_NUM_3rd = 6;
                    colorshow_03.BackColor = colorboard_blue.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //五色环N次幂
                case 54:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 6;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_04.BackColor = colorboard_blue.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //五色环误差值
                case 55:
                    GlobalVar.clac_Circle_Tolerance = "0.25";
                    colorshow_06.BackColor = colorboard_blue.BackColor;
                    label_textshow06.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;

                //列举出六色环模式下蓝色色环可能出现的结果。
                //六色环数位1
                case 61:
                    GlobalVar.clac_Circle_NUM_1st = 6;
                    colorshow_01.BackColor = colorboard_blue.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //六色环数位2
                case 62:
                    GlobalVar.clac_Circle_NUM_2nd = 6;
                    colorshow_02.BackColor = colorboard_blue.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //六色环数位3
                case 63:
                    GlobalVar.clac_Circle_NUM_3rd = 6;
                    colorshow_03.BackColor = colorboard_blue.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //六色环N次幂
                case 64:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 6;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent)); ;
                    colorshow_04.BackColor = colorboard_blue.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //六色环误差值
                case 65:
                    GlobalVar.clac_Circle_Tolerance = "0.25";
                    colorshow_05.BackColor = colorboard_blue.BackColor;
                    label_textshow05.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;
                //六色环温度系数
                case 66:
                    GlobalVar.clac_Circle_Temperature = "10";
                    colorshow_06.BackColor = colorboard_blue.BackColor;
                    label_textshow06.Text = GlobalVar.clac_Circle_Temperature + "PPM";
                    break;
            }
            //只有在误差值不为20%时才触发去除色环边框事件
            if (GlobalVar.clac_Circle_Tolerance != "20")
            {
                colorshow_05.BorderStyle = BorderStyle.None;
                colorshow_06.BorderStyle = BorderStyle.None;
            }
            //调试输出色环数值以检查Switch操作是否正确
            Console.WriteLine("---------------------------调试输出色环数值---------------------------" + "\n" +
                "第一色环为：" + GlobalVar.clac_Circle_NUM_1st.ToString() + "\n" +
                "第二色环为：" + GlobalVar.clac_Circle_NUM_2nd.ToString() + "\n" +
                "第三色环为：" + GlobalVar.clac_Circle_NUM_3rd.ToString() + "\n" +
                "N次幂色环为：" + GlobalVar.clac_Circle_NUM_Power.ToString() + "\n" +
                "误差值色环为：" + GlobalVar.clac_Circle_Tolerance.ToString() + "\n" +
                "温度系数色环为：" + GlobalVar.clac_Circle_Temperature.ToString() + "\n" +
                "---------------------------调试输出到此结束---------------------------");
        }

        /// <summary>
        /// 紫色色环复选框选中响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Radio_purple_CheckedChanged(object sender, EventArgs e)
        {
            switch (radstcode)
            {
                //列举出四色环模式下紫色色环可能出现的结果。
                //四色环数位1
                case 41:
                    GlobalVar.clac_Circle_NUM_1st = 7;
                    colorshow_01.BackColor = colorboard_purple.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //四色环数位2
                case 42:
                    GlobalVar.clac_Circle_NUM_2nd = 7;
                    colorshow_02.BackColor = colorboard_purple.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //四色环N次幂
                case 43:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 7;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_03.BackColor = colorboard_purple.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //移动电阻图形下方数字含义标签的N次幂控件并显示N次幂数值
                    label_textshowExponent.Location = new Point(212, 120);
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString();
                    break;
                //四色环误差值
                case 44:
                    GlobalVar.clac_Circle_Tolerance = "0.1";
                    colorshow_06.BackColor = colorboard_purple.BackColor;
                    label_textshow06.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;

                //列举出五色环模式下紫色色环可能出现的结果。
                //五色环数位1
                case 51:
                    GlobalVar.clac_Circle_NUM_1st = 7;
                    colorshow_01.BackColor = colorboard_purple.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //五色环数位2
                case 52:
                    GlobalVar.clac_Circle_NUM_2nd = 7;
                    colorshow_02.BackColor = colorboard_purple.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //五色环数位3
                case 53:
                    GlobalVar.clac_Circle_NUM_3rd = 7;
                    colorshow_03.BackColor = colorboard_purple.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //五色环N次幂
                case 54:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 7;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_04.BackColor = colorboard_purple.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //五色环误差值
                case 55:
                    GlobalVar.clac_Circle_Tolerance = "0.1";
                    colorshow_06.BackColor = colorboard_purple.BackColor;
                    label_textshow06.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;

                //列举出六色环模式下紫色色环可能出现的结果。
                //六色环数位1
                case 61:
                    GlobalVar.clac_Circle_NUM_1st = 7;
                    colorshow_01.BackColor = colorboard_purple.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //六色环数位2
                case 62:
                    GlobalVar.clac_Circle_NUM_2nd = 7;
                    colorshow_02.BackColor = colorboard_purple.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //六色环数位3
                case 63:
                    GlobalVar.clac_Circle_NUM_3rd = 7;
                    colorshow_03.BackColor = colorboard_purple.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //六色环N次幂
                case 64:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 7;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent)); ;
                    colorshow_04.BackColor = colorboard_purple.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //六色环误差值
                case 65:
                    GlobalVar.clac_Circle_Tolerance = "0.1";
                    colorshow_05.BackColor = colorboard_purple.BackColor;
                    label_textshow05.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;
                //六色环温度系数
                case 66:
                    GlobalVar.clac_Circle_Temperature = "5";
                    colorshow_06.BackColor = colorboard_purple.BackColor;
                    label_textshow06.Text = GlobalVar.clac_Circle_Temperature + "PPM";
                    break;
            }
            //只有在误差值不为20%时才触发去除色环边框事件
            if (GlobalVar.clac_Circle_Tolerance != "20")
            {
                colorshow_05.BorderStyle = BorderStyle.None;
                colorshow_06.BorderStyle = BorderStyle.None;
            }
            //调试输出色环数值以检查Switch操作是否正确
            Console.WriteLine("---------------------------调试输出色环数值---------------------------" + "\n" +
                "第一色环为：" + GlobalVar.clac_Circle_NUM_1st.ToString() + "\n" +
                "第二色环为：" + GlobalVar.clac_Circle_NUM_2nd.ToString() + "\n" +
                "第三色环为：" + GlobalVar.clac_Circle_NUM_3rd.ToString() + "\n" +
                "N次幂色环为：" + GlobalVar.clac_Circle_NUM_Power.ToString() + "\n" +
                "误差值色环为：" + GlobalVar.clac_Circle_Tolerance.ToString() + "\n" +
                "温度系数色环为：" + GlobalVar.clac_Circle_Temperature.ToString() + "\n" +
                "---------------------------调试输出到此结束---------------------------");
        }

        /// <summary>
        /// 灰色色环复选框选中响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Radio_gray_CheckedChanged(object sender, EventArgs e)
        {
            switch (radstcode)
            {
                //列举出四色环模式下灰色色环可能出现的结果。
                //四色环数位1
                case 41:
                    GlobalVar.clac_Circle_NUM_1st = 8;
                    colorshow_01.BackColor = colorboard_gray.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //四色环数位2
                case 42:
                    GlobalVar.clac_Circle_NUM_2nd = 8;
                    colorshow_02.BackColor = colorboard_gray.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //四色环N次幂
                case 43:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 8;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_03.BackColor = colorboard_gray.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //移动电阻图形下方数字含义标签的N次幂控件并显示N次幂数值
                    label_textshowExponent.Location = new Point(212, 120);
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString();
                    break;
                //四色环误差值
                case 44:
                    GlobalVar.clac_Circle_Tolerance = "0.05";
                    colorshow_06.BackColor = colorboard_gray.BackColor;
                    label_textshow06.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;

                //列举出五色环模式下灰色色环可能出现的结果。
                //五色环数位1
                case 51:
                    GlobalVar.clac_Circle_NUM_1st = 8;
                    colorshow_01.BackColor = colorboard_gray.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //五色环数位2
                case 52:
                    GlobalVar.clac_Circle_NUM_2nd = 8;
                    colorshow_02.BackColor = colorboard_gray.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //五色环数位3
                case 53:
                    GlobalVar.clac_Circle_NUM_3rd = 8;
                    colorshow_03.BackColor = colorboard_gray.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //五色环N次幂
                case 54:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 8;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_04.BackColor = colorboard_gray.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //五色环误差值
                case 55:
                    GlobalVar.clac_Circle_Tolerance = "0.05";
                    colorshow_06.BackColor = colorboard_gray.BackColor;
                    label_textshow06.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;

                //列举出六色环模式下灰色色环可能出现的结果。
                //六色环数位1
                case 61:
                    GlobalVar.clac_Circle_NUM_1st = 8;
                    colorshow_01.BackColor = colorboard_gray.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //六色环数位2
                case 62:
                    GlobalVar.clac_Circle_NUM_2nd = 8;
                    colorshow_02.BackColor = colorboard_gray.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //六色环数位3
                case 63:
                    GlobalVar.clac_Circle_NUM_3rd = 8;
                    colorshow_03.BackColor = colorboard_gray.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //六色环N次幂
                case 64:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 8;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent)); ;
                    colorshow_04.BackColor = colorboard_gray.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //六色环误差值
                case 65:
                    GlobalVar.clac_Circle_Tolerance = "0.05";
                    colorshow_05.BackColor = colorboard_gray.BackColor;
                    label_textshow05.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;
                    //没有用灰色表示的温度系数的色环，故状态码66不存在
            }
            //只有在误差值不为20%时才触发去除色环边框事件
            if (GlobalVar.clac_Circle_Tolerance != "20")
            {
                colorshow_05.BorderStyle = BorderStyle.None;
                colorshow_06.BorderStyle = BorderStyle.None;
            }
            //调试输出色环数值以检查Switch操作是否正确
            Console.WriteLine("---------------------------调试输出色环数值---------------------------" + "\n" +
                "第一色环为：" + GlobalVar.clac_Circle_NUM_1st.ToString() + "\n" +
                "第二色环为：" + GlobalVar.clac_Circle_NUM_2nd.ToString() + "\n" +
                "第三色环为：" + GlobalVar.clac_Circle_NUM_3rd.ToString() + "\n" +
                "N次幂色环为：" + GlobalVar.clac_Circle_NUM_Power.ToString() + "\n" +
                "误差值色环为：" + GlobalVar.clac_Circle_Tolerance.ToString() + "\n" +
                "温度系数色环为：" + GlobalVar.clac_Circle_Temperature.ToString() + "\n" +
                "---------------------------调试输出到此结束---------------------------");
        }

        /// <summary>
        /// 白色色环复选框选中响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Radio_white_CheckedChanged(object sender, EventArgs e)
        {
            switch (radstcode)
            {
                //列举出四色环模式下白色色环可能出现的结果。
                //四色环数位1
                case 41:
                    GlobalVar.clac_Circle_NUM_1st = 9;
                    colorshow_01.BackColor = colorboard_white.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //四色环数位2
                case 42:
                    GlobalVar.clac_Circle_NUM_2nd = 9;
                    colorshow_02.BackColor = colorboard_white.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //四色环N次幂
                case 43:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 9;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_03.BackColor = colorboard_white.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //移动电阻图形下方数字含义标签的N次幂控件并显示N次幂数值
                    label_textshowExponent.Location = new Point(212, 120);
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString();
                    break;
                //没有用白色表示的误差值的色环，故状态码45不存在


                //列举出五色环模式下白色色环可能出现的结果。
                //五色环数位1
                case 51:
                    GlobalVar.clac_Circle_NUM_1st = 9;
                    colorshow_01.BackColor = colorboard_white.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //五色环数位2
                case 52:
                    GlobalVar.clac_Circle_NUM_2nd = 9;
                    colorshow_02.BackColor = colorboard_white.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //五色环数位3
                case 53:
                    GlobalVar.clac_Circle_NUM_3rd = 9;
                    colorshow_03.BackColor = colorboard_white.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //五色环N次幂
                case 54:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 9;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_04.BackColor = colorboard_white.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //没有用白色表示的误差值的色环，故状态码55不存在

                //列举出六色环模式下白色色环可能出现的结果。
                //六色环数位1
                case 61:
                    GlobalVar.clac_Circle_NUM_1st = 9;
                    colorshow_01.BackColor = colorboard_white.BackColor;
                    label_textshow01.Text = GlobalVar.clac_Circle_NUM_1st.ToString();
                    break;
                //六色环数位2
                case 62:
                    GlobalVar.clac_Circle_NUM_2nd = 9;
                    colorshow_02.BackColor = colorboard_white.BackColor;
                    label_textshow02.Text = GlobalVar.clac_Circle_NUM_2nd.ToString();
                    break;
                //六色环数位3
                case 63:
                    GlobalVar.clac_Circle_NUM_3rd = 9;
                    colorshow_03.BackColor = colorboard_white.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_3rd.ToString();
                    break;
                //六色环N次幂
                case 64:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 9;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToInt64(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent)); ;
                    colorshow_04.BackColor = colorboard_white.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //没有用白色表示的误差值的色环，故状态码45不存在

                //六色环温度系数
                case 66:
                    GlobalVar.clac_Circle_Temperature = "1";
                    colorshow_06.BackColor = colorboard_white.BackColor;
                    label_textshow06.Text = GlobalVar.clac_Circle_Temperature + "PPM";
                    break;
            }
            //只有在误差值不为20%时才触发去除色环边框事件
            if (GlobalVar.clac_Circle_Tolerance != "20")
            {
                colorshow_05.BorderStyle = BorderStyle.None;
                colorshow_06.BorderStyle = BorderStyle.None;
            }
            //调试输出色环数值以检查Switch操作是否正确
            Console.WriteLine("---------------------------调试输出色环数值---------------------------" + "\n" +
                "第一色环为：" + GlobalVar.clac_Circle_NUM_1st.ToString() + "\n" +
                "第二色环为：" + GlobalVar.clac_Circle_NUM_2nd.ToString() + "\n" +
                "第三色环为：" + GlobalVar.clac_Circle_NUM_3rd.ToString() + "\n" +
                "N次幂色环为：" + GlobalVar.clac_Circle_NUM_Power.ToString() + "\n" +
                "误差值色环为：" + GlobalVar.clac_Circle_Tolerance.ToString() + "\n" +
                "温度系数色环为：" + GlobalVar.clac_Circle_Temperature.ToString() + "\n" +
                "---------------------------调试输出到此结束---------------------------");
        }

        /// <summary>
        /// 金色色环复选框选中响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Radio_gold_CheckedChanged(object sender, EventArgs e)
        {
            switch (radstcode)
            {
                //列举出四色环模式下金色色环可能出现的结果。
                //没有用金色表示的数位的色环，故状态码41、42不存在
                //四色环N次幂
                case 43:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = -1;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToDouble(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_03.BackColor = colorboard_gold.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //移动电阻图形下方数字含义标签的N次幂控件并显示N次幂数值
                    label_textshowExponent.Location = new Point(212, 120);
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString();
                    break;
                //四色环误差值
                case 44:
                    GlobalVar.clac_Circle_Tolerance = "5";
                    colorshow_06.BackColor = colorboard_gold.BackColor;
                    label_textshow06.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;

                //列举出五色环模式下金色色环可能出现的结果。
                //没有用金色表示的数位的色环，故状态码51、52、53不存在
                //五色环N次幂
                case 54:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = -1;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToDouble(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_04.BackColor = colorboard_gold.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString();
                    break;
                //五色环误差值
                case 55:
                    GlobalVar.clac_Circle_Tolerance = "5";
                    colorshow_06.BackColor = colorboard_gold.BackColor;
                    label_textshow06.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;

                //列举出六色环模式下金色色环可能出现的结果。
                //六色环数位1
                //没有用金色表示的数位的色环和温度系数，故状态码61、62、63、66不存在
                //六色环N次幂
                case 64:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = 2;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToDouble(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent)); ;
                    colorshow_04.BackColor = colorboard_gold.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //六色环误差值
                case 65:
                    GlobalVar.clac_Circle_Tolerance = "5";
                    colorshow_05.BackColor = colorboard_gold.BackColor;
                    label_textshow05.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;
            }
            //只有在误差值不为20%时才触发去除色环边框事件
            if (GlobalVar.clac_Circle_Tolerance != "20")
            {
                colorshow_05.BorderStyle = BorderStyle.None;
                colorshow_06.BorderStyle = BorderStyle.None;
            }
            //调试输出色环数值以检查Switch操作是否正确
            Console.WriteLine("---------------------------调试输出色环数值---------------------------" + "\n" +
                "第一色环为：" + GlobalVar.clac_Circle_NUM_1st.ToString() + "\n" +
                "第二色环为：" + GlobalVar.clac_Circle_NUM_2nd.ToString() + "\n" +
                "第三色环为：" + GlobalVar.clac_Circle_NUM_3rd.ToString() + "\n" +
                "N次幂色环为：" + GlobalVar.clac_Circle_NUM_Power.ToString() + "\n" +
                "误差值色环为：" + GlobalVar.clac_Circle_Tolerance.ToString() + "\n" +
                "温度系数色环为：" + GlobalVar.clac_Circle_Temperature.ToString() + "\n" +
                "---------------------------调试输出到此结束---------------------------");
        }

        /// <summary>
        /// 银色色环复选框选中响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Radio_silver_CheckedChanged(object sender, EventArgs e)
        {
            switch (radstcode)
            {
                //列举出四色环模式下银色色环可能出现的结果。
                //没有用银色表示的数位的色环，故状态码41、42不存在
                //四色环N次幂
                case 43:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = -2;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToDouble(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_03.BackColor = colorboard_silver.BackColor;
                    label_textshow03.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //移动电阻图形下方数字含义标签的N次幂控件并显示N次幂数值
                    label_textshowExponent.Location = new Point(212, 120);
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString();
                    break;
                //四色环误差值
                case 44:
                    GlobalVar.clac_Circle_Tolerance = "10";
                    colorshow_06.BackColor = colorboard_silver.BackColor;
                    label_textshow06.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;

                //列举出五色环模式下银色色环可能出现的结果。
                //没有用银色表示的数位的色环，故状态码51、52、53不存在
                //五色环N次幂
                case 54:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = -2;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToDouble(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent));
                    colorshow_04.BackColor = colorboard_silver.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //五色环误差值
                case 55:
                    GlobalVar.clac_Circle_Tolerance = "10";
                    colorshow_06.BackColor = colorboard_silver.BackColor;
                    label_textshow06.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;

                //列举出六色环模式下银色色环可能出现的结果。
                //六色环数位1
                //没有用银色表示的数位的色环和温度系数，故状态码61、62、63、66不存在
                //六色环N次幂
                case 64:
                    GlobalVar.clac_Circle_NUM_Base = 10;
                    GlobalVar.clac_Circle_NUM_Exponent = -2;
                    GlobalVar.clac_Circle_NUM_Power = Convert.ToDouble(Math.Pow(GlobalVar.clac_Circle_NUM_Base, GlobalVar.clac_Circle_NUM_Exponent)); ;
                    colorshow_04.BackColor = colorboard_silver.BackColor;
                    label_textshow04.Text = GlobalVar.clac_Circle_NUM_Base.ToString();
                    //显示N次幂数值                    
                    label_textshowExponent.Text = GlobalVar.clac_Circle_NUM_Exponent.ToString(); ;
                    break;
                //六色环误差值
                case 65:
                    GlobalVar.clac_Circle_Tolerance = "10";
                    colorshow_05.BackColor = colorboard_silver.BackColor;
                    label_textshow05.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;
            }
            //只有在误差值不为20%时才触发去除色环边框事件
            if (GlobalVar.clac_Circle_Tolerance != "20")
            {
                colorshow_05.BorderStyle = BorderStyle.None;
                colorshow_06.BorderStyle = BorderStyle.None;
            }
            //调试输出色环数值以检查Switch操作是否正确
            Console.WriteLine("---------------------------调试输出色环数值---------------------------" + "\n" +
                "第一色环为：" + GlobalVar.clac_Circle_NUM_1st.ToString() + "\n" +
                "第二色环为：" + GlobalVar.clac_Circle_NUM_2nd.ToString() + "\n" +
                "第三色环为：" + GlobalVar.clac_Circle_NUM_3rd.ToString() + "\n" +
                "N次幂色环为：" + GlobalVar.clac_Circle_NUM_Power.ToString() + "\n" +
                "误差值色环为：" + GlobalVar.clac_Circle_Tolerance.ToString() + "\n" +
                "温度系数色环为：" + GlobalVar.clac_Circle_Temperature.ToString() + "\n" +
                "---------------------------调试输出到此结束---------------------------");
        }

        /// <summary>
        /// 无色色环复选框选中响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Radio_none_CheckedChanged(object sender, EventArgs e)
        {
            switch (radstcode)
            {
                //列举出四色环模式下银色色环可能出现的结果。
                //四色环误差值
                case 44:
                    GlobalVar.clac_Circle_Tolerance = "20";
                    colorshow_06.BorderStyle = BorderStyle.FixedSingle;
                    colorshow_06.BackColor = colorboard_none.BackColor;
                    label_textshow06.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;
                //五色环误差值
                case 55:
                    GlobalVar.clac_Circle_Tolerance = "20";
                    colorshow_06.BorderStyle = BorderStyle.FixedSingle;
                    colorshow_06.BackColor = colorboard_none.BackColor;
                    label_textshow06.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;
                //六色环误差值
                case 65:
                    GlobalVar.clac_Circle_Tolerance = "20";
                    colorshow_05.BorderStyle = BorderStyle.FixedSingle;
                    colorshow_05.BackColor = colorboard_none.BackColor;
                    label_textshow05.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
                    break;
            }
            //调试输出色环数值以检查Switch操作是否正确
            Console.WriteLine("---------------------------调试输出色环数值---------------------------" + "\n" +
                "第一色环为：" + GlobalVar.clac_Circle_NUM_1st.ToString() + "\n" +
                "第二色环为：" + GlobalVar.clac_Circle_NUM_2nd.ToString() + "\n" +
                "第三色环为：" + GlobalVar.clac_Circle_NUM_3rd.ToString() + "\n" +
                "N次幂色环为：" + GlobalVar.clac_Circle_NUM_Power.ToString() + "\n" +
                "误差值色环为：" + GlobalVar.clac_Circle_Tolerance.ToString() + "\n" +
                "温度系数色环为：" + GlobalVar.clac_Circle_Temperature.ToString() + "\n" +
                "---------------------------调试输出到此结束---------------------------");
        }

        /// <summary>
        /// 点击“计算”按钮响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Clac_Click(object sender, EventArgs e)
        {
            //检查当前计算模式
            ModeCheck();

            //检查色环颜色选中情况（根据变量赋值来判定）
            if (GlobalVar.clac_Circle_NUM_1st == -1)
            {
                MessageBox.Show("请指定第一色环颜色！", msg_title_NoCirle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (GlobalVar.clac_Circle_NUM_2nd == -1)
            {
                MessageBox.Show("请指定第二色环颜色！", msg_title_NoCirle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (GlobalVar.clac_Circle_NUM_Power == -1 & FourCircleResistance.Checked == true)
            {
                MessageBox.Show("请指定第三色环颜色！", msg_title_NoCirle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (GlobalVar.clac_Circle_NUM_3rd == -1 & (FiveCircleResistance.Checked == true | SixCircleResistance.Checked == true))
            {
                MessageBox.Show("请指定第三色环颜色！", msg_title_NoCirle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (GlobalVar.clac_Circle_NUM_Power == -1 & (FiveCircleResistance.Checked == true | SixCircleResistance.Checked == true))
            {
                MessageBox.Show("请指定第四色环颜色！", msg_title_NoCirle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (GlobalVar.clac_Circle_Tolerance == "NULL" & FourCircleResistance.Checked == true)
            {
                MessageBox.Show("请指定第四色环颜色！", msg_title_NoCirle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (GlobalVar.clac_Circle_Tolerance == "NULL" & (FiveCircleResistance.Checked == true | SixCircleResistance.Checked == true))
            {
                MessageBox.Show("请指定第五色环颜色！", msg_title_NoCirle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (GlobalVar.clac_Circle_Temperature == "NULL" & SixCircleResistance.Checked == true)
            {
                MessageBox.Show("请指定第六色环颜色！", msg_title_NoCirle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //确认当前计算的是几色环电阻
            switch (modecode)
            {
                case 40:
                    GlobalVar.clacresult = (GlobalVar.clac_Circle_NUM_1st * 10 + GlobalVar.clac_Circle_NUM_2nd * 1) * GlobalVar.clac_Circle_NUM_Power;
                    Console.WriteLine(GlobalVar.clac_Circle_NUM_Power);
                    break;
                case 50:
                    GlobalVar.clacresult = (GlobalVar.clac_Circle_NUM_1st * 100 + GlobalVar.clac_Circle_NUM_2nd * 10 + GlobalVar.clac_Circle_NUM_3rd * 1) * GlobalVar.clac_Circle_NUM_Power;
                    break;
                case 60:
                    GlobalVar.clacresult = (GlobalVar.clac_Circle_NUM_1st * 100 + GlobalVar.clac_Circle_NUM_2nd * 10 + GlobalVar.clac_Circle_NUM_3rd * 1) * GlobalVar.clac_Circle_NUM_Power;
                    break;
            }


            //禁用控件
            FourCircleResistance.Enabled = false;
            FiveCircleResistance.Enabled = false;
            SixCircleResistance.Enabled = false;
            circle1.Enabled = false;
            circle2.Enabled = false;
            circle3.Enabled = false;
            circle4.Enabled = false;
            circle5.Enabled = false;
            circle6.Enabled = false;
            radio_black.Enabled = false;
            radio_brown.Enabled = false;
            radio_red.Enabled = false;
            radio_orange.Enabled = false;
            radio_yellow.Enabled = false;
            radio_green.Enabled = false;
            radio_blue.Enabled = false;
            radio_purple.Enabled = false;
            radio_gray.Enabled = false;
            radio_white.Enabled = false;
            radio_gold.Enabled = false;
            radio_silver.Enabled = false;
            radio_none.Enabled = false;

            //调试输出
            Console.WriteLine(ConvertResistanceValue(GlobalVar.clacresult) + "\n" + GlobalVar.clacresult);

            //显示复位、复制、保存结果按钮
            ResultBox.Visible = true;
            btn_ResultCopy.Visible = true;
            btn_SaveImg.Visible = true;

            //输出阻值和误差到指定标签
            textBox_resistanceresult.Text = ConvertResistanceValue(GlobalVar.clacresult);
            textBox_Tolerance.Text = "±" + GlobalVar.clac_Circle_Tolerance + "%";
            //“计算”按钮禁用
            btn_clac.Enabled = false;

            //根据不同色环的电阻输出不同的计算结果文本
            if (modecode == 60)
            {
                GlobalVar.resultText = "这是一个四色环电阻。\n电阻阻值为：" + ConvertResistanceValue(GlobalVar.clacresult) + "\n" + "误差值为：±" + GlobalVar.clac_Circle_Tolerance + "%\n" + "温度系数为：" + GlobalVar.clac_Circle_Temperature + "PPM";
                textBox_Temperature.Text = GlobalVar.clac_Circle_Temperature + "PPM";
                label_Temperature.Visible = true;
                textBox_Temperature.Visible = true;
            }
            else if (modecode == 50)
            {
                GlobalVar.resultText = "这是一个五色环电阻。\n电阻阻值为：" + ConvertResistanceValue(GlobalVar.clacresult) + "\n" + "误差值为：±" + GlobalVar.clac_Circle_Tolerance + "%";
            }
            else
            {
                GlobalVar.resultText = "这是一个四色环电阻。\n电阻阻值为：" + ConvertResistanceValue(GlobalVar.clacresult) + "\n" + "误差值为：±" + GlobalVar.clac_Circle_Tolerance + "%";

            }

            //将双精小数型的阻值赋值给文本型阻值
            GlobalVar.clacresultA = ConvertResistanceValue(GlobalVar.clacresult);

            //弹出计算结果对话框
            Form_ClacResult Form_ClacResult = new Form_ClacResult();
            Form_ClacResult.ShowDialog();
        }

        /// <summary>
        /// 点击“复位”按钮响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_reset_Click(object sender, EventArgs e)
        {
            //隐藏计算结果显示框、复位按钮、图片保存按钮，并激活计算按钮
            ResultBox.Visible = false;
            label_Temperature.Visible = false;
            textBox_Temperature.Visible = false;
            btn_ResultCopy.Visible = false;
            btn_SaveImg.Visible = false;
            btn_clac.Enabled = true;


            //复位数值
            GlobalVar.clac_Circle_NUM_1st = -1;                       //数位1
            GlobalVar.clac_Circle_NUM_2nd = -1;                       //数位2
            GlobalVar.clac_Circle_NUM_3rd = -1;                       //数位3
            GlobalVar.clac_Circle_NUM_Power = -1;                     //N次幂
            GlobalVar.clac_Circle_NUM_Base = -1;                   //次方底数
            GlobalVar.clac_Circle_NUM_Exponent = -1;               //次方指数
            GlobalVar.clac_Circle_Tolerance = "NULL";              //误差值
            GlobalVar.clac_Circle_Temperature = "NULL";            //温度系数
            BoardrRset();                                           //复位色卡

            //复位色环单选框
            circle1.Checked = false;
            circle2.Checked = false;
            circle3.Checked = false;
            circle4.Checked = false;
            circle5.Checked = false;
            circle6.Checked = false;
            FourCircleResistance.Enabled = true;
            FiveCircleResistance.Enabled = true;
            SixCircleResistance.Enabled = true;
            circle1.Enabled = true;
            circle2.Enabled = true;
            circle3.Enabled = true;
            circle4.Enabled = true;
            circle5.Enabled = true;
            circle6.Enabled = true;
            FourCircleResistance.Checked = true;
            FiveCircleResistance.Checked = false;
            SixCircleResistance.Checked = false;

            //清空计算结果文本框
            textBox_resistanceresult.Text = "";
            textBox_Tolerance.Text = "";
            textBox_Temperature.Text = "";
        }

        /// <summary>
        /// 点击“生成分享图”按钮响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SaveImg_Click_1(object sender, EventArgs e)
        {
            DrawImage();
            Form_ImgSave Form_ImgSave = new Form_ImgSave();
            Form_ImgSave.ShowDialog();
        }

        /// <summary>
        /// 点击“复制结果”按钮的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ResultCopy_Click(object sender, EventArgs e)
        {
            string ClipText = GloConst.cutBoard_01 + GlobalVar.resultText + GloConst.cutBoard_02;
            string ClipTextA;
            Clipboard.SetText(ClipText);
            ClipTextA = Clipboard.GetText();
            if (ClipTextA == ClipText)
            {
                MessageBox.Show("计算结果已成功复制到您的剪切板上！快去粘贴分享给好友吧。", "复制成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("发生未知错误！复制失败！\r\n请检查是否被杀毒软件、电脑管家等软件限制访问剪切板。", "复制错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        /// <summary>
        /// 点击“如何识别电阻色环”标签的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_HowToIdentify_Click(object sender, EventArgs e)
        {
            //窗体不得重复打开，先检查帮助窗口是否已经打开过
            Form _hlpfrm = Application.OpenForms["Form_Help"];

            //置“如何识别电阻色环？”标记位为真，告诉帮助窗口要跳转到相关页面                  
            GlobalVar.howToIdentifyFlag = true;

            //如果没有打开过
            if ((_hlpfrm == null) || (_hlpfrm.IsDisposed))
            {

                //将相关DLL解包到运行目录
                PublicFunction.UnPackPlugin();

                //打开帮助窗口
                Form_Help Form_Help = new Form_Help();
                Form_Help.Owner = this;
                Form_Help.Show(); ;
            }
            else
            {
                //如果帮助窗口打开了，弹出提示框，然后跳转到相关页面
                MessageBox.Show("当前帮助窗口已打开！\r\n点击<确定>按钮将跳转到帮助文档相关章节。", "即将跳转", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _hlpfrm.Activate();
            }
        }

        /// <summary>
        /// 第一色环颜色改变时的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Colorshow_01_BackColorChanged(object sender, EventArgs e)
        {
            //第一色环的颜色为非透明的时候播放Windows默认提示音
            if (colorshow_01.BackColor != Color.Transparent)
            {
                SystemSounds.Beep.Play();
            }
        }
        /// <summary>
        /// 第二色环颜色改变时的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Colorshow_02_BackColorChanged(object sender, EventArgs e)
        {
            //第二色环的颜色为非透明的时候播放Windows默认提示音
            if (colorshow_02.BackColor != Color.Transparent)
            {
                SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        ///  第三色环颜色改变时的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Colorshow_03_BackColorChanged(object sender, EventArgs e)
        {
            //第三色环的颜色为非透明的时候播放Windows默认提示音
            if (colorshow_03.BackColor != Color.Transparent)
            {
                SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// 第四色环颜色改变时的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Colorshow_04_BackColorChanged(object sender, EventArgs e)
        {
            //第四色环的颜色为非透明的时候播放Windows默认提示音
            if (colorshow_04.BackColor != Color.Transparent)
            {
                SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// 第五色环颜色改变时的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Colorshow_05_BackColorChanged(object sender, EventArgs e)
        {
            //第五色环的颜色为非透明的时候播放Windows默认提示音，色环加边框时表示为无色色环，依然播放提示音
            if (colorshow_05.BackColor != Color.Transparent)
            {
                SystemSounds.Beep.Play();
            }
            else if (colorshow_05.BorderStyle == BorderStyle.FixedSingle)
            {
                SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// 第五色环颜色改变时的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Colorshow_06_BackColorChanged(object sender, EventArgs e)
        {
            //第六色环的颜色为非透明的时候播放Windows默认提示音，色环加边框时表示为无色色环，依然播放提示音
            if (colorshow_06.BackColor != Color.Transparent)
            {
                SystemSounds.Beep.Play();
            }
            else if (colorshow_06.BorderStyle == BorderStyle.FixedSingle)
            {
                SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// 窗体关闭时候的响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //退出时进行询问
            DialogResult r = MessageBox.Show("确定要退出吗？", "退出确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (r == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                e.Cancel = false;
            }
        }

        /// <summary>
        ///点击菜单项“文件——退出”响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 点击菜单项“帮助——使用说明”响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Help_Click(object sender, EventArgs e)
        {
            //窗体不得重复打开，先检查帮助窗口是否已经打开过
            Form _hlpfrm = Application.OpenForms["Form_Help"];

            //如果没有打开过
            if ((_hlpfrm == null) || (_hlpfrm.IsDisposed))
            {

                //将相关DLL解包到运行目录
                PublicFunction.UnPackPlugin();

                //打开帮助窗口
                Form_Help Form_Help = new Form_Help();
                Form_Help.Owner = this;
                Form_Help.Show(); ;
            }
            else
            {
                //打开过则弹出提示框提醒，然后跳转，并最大化
                MessageBox.Show("抱歉！已经打开过帮助窗口，不允许重复打开！\r\n点击<确定>按钮回到帮助文档。", "不好意思", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _hlpfrm.Activate();
                _hlpfrm.WindowState = FormWindowState.Maximized;
            }
        }


        /// <summary>
        /// 点击菜单项“帮助——检查更新”响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Update_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(GloConst.softwareWebsite);
        }

        /// <summary>
        /// 点击菜单项“帮助——关于”响应函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_About_Click(object sender, EventArgs e)
        {
            Form_About Form_About = new Form_About();
            Form_About.ShowDialog();
        }
    }
}