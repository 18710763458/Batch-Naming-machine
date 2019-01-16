using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace GenerateTheFileAndWrite
{
    public partial class Form1 : Form
    {
        string[] xing = {
            "赵","钱","孙","李","周","吴","郑","王","冯","陈","褚","卫","蒋","沈","韩","杨","朱","秦","尤","许",
            "何","吕","施","张","孔","曹","严","华","金","魏","陶","姜","戚","谢","邹","喻","柏","水","窦","章",
            "云","苏","潘","葛","奚","范","彭","郎","鲁","韦","昌","马","苗","凤","花","方","俞","任","袁","柳",
            "酆","鲍","史","唐","费","廉","岑","薛","雷","贺","倪","汤","滕","殷","罗","毕","郝","邬","安","常",
            "乐","于","时","傅","皮","卞","齐","康","伍","余","元","卜","顾","孟","平","黄","和","穆","萧","尹",
            "姚","邵","湛","汪","祁","毛","禹","狄","米","贝","明","臧","计","伏","成","戴","谈","宋","茅","庞",
            "熊","纪","舒","屈","项","祝","董","粱","杜","阮","蓝","闵","席","季","麻","强","贾","路","娄","危",
            "江","童","颜","郭","梅","盛","林","刁","钟","徐","邱","骆","高","夏","蔡","田","樊","胡","凌","霍",
            "虞","万","支","柯","昝","管","卢","莫","经","房","裘","缪","干","解","应","宗","丁","宣","贲","邓",
            "郁","单","杭","洪","包","诸","左","石","崔","吉","钮","龚","程","嵇","邢","滑","裴","陆","荣","翁",
            "荀","羊","於","惠","甄","麴","家","封","芮","羿","储","靳","汲","邴","糜","松","井","段","富","巫",
            "乌","焦","巴","弓","牧","隗","山","谷","车","侯","宓","蓬","全","郗","班","仰","秋","仲","伊","宫",
            "宁","仇","栾","暴","甘","钭","厉","戎","祖","武","符","刘","景","詹","束","龙","叶","幸","司","韶",
            "郜","黎","蓟","薄","印","宿","白","怀","蒲","邰","从","鄂","索","咸","籍","赖","卓","蔺","屠","蒙",
            "池","乔","阴","欎","胥","能","苍","双","闻","莘","党","翟","谭","贡","劳","逄","姬","申","扶","堵",
            "冉","宰","郦","雍","舄","璩","桑","桂","濮","牛","寿","通","边","扈","燕","冀","郏","浦","尚","农",
            "温","别","庄","晏","柴","瞿","阎","充","慕","连","茹","习","宦","艾","鱼","容","向","古","易","慎",
            "戈","廖","庾","终","暨","居","衡","步","都","耿","满","弘","匡","国","文","寇","广","禄","阙","东",
            "殴","殳","沃","利","蔚","越","夔","隆","师","巩","厍","聂","晁","勾","敖","融","冷","訾","辛","阚",
            "那","简","饶","空","曾","毋","沙","乜","养","鞠","须","丰","巢","关","蒯","相","查","後","荆","红",
            "游","竺","权","逯","盖","益","桓","公","万俟","司马","上官","欧阳","夏侯","诸葛",
            "闻人","东方","赫连","皇甫","尉迟","公羊","澹台","公冶","宗政","濮阳",
            "淳于","单于","太叔","申屠","公孙","仲孙","轩辕","令狐","钟离","宇文",
            "长孙","慕容","鲜于","闾丘","司徒","司空","亓官","司寇","仉","督","子车",
            "颛孙","端木","巫马","公西","漆雕","乐正","壤驷","公良","拓跋","夹谷",
            "宰父","谷梁","晋","楚","闫","法","汝","鄢","涂","钦","段干","百里","东郭","南门",
            "呼延","归","海","羊舌","微生","岳","帅","缑","亢","况","后","有","琴","梁丘","左丘",
            "东门","西门","商","牟","佘","佴","伯","赏","南宫","墨","哈","谯","笪","年","爱","阳","佟",
            "第五","言","福","百","家","姓","终"
        };
        string[] ming = {
            "彦龙", "浩鹏","天一", "铁刚","君昊","国艳","恩德","文雅","文轩","文博","文璇","文萱","文渲","美红","雨洁","诗蕊","泊萱","可昕","章洪","亚萍","智博","子宸","鸿娜","玉锁","宏娜","金煜","艾玲","绿峰","子昊","慧","娜","建中","亚蒙","亚梦","中山","汉煜","越泽","维哲","逸","乾","赟","淩","祺","昊","卫","昱烔","鸿崧","玮","凌咺","雨桐","霖","沁鈺","啸林","易","晨","梣","麟","煜","酉晨","子辰","子晨","亦晨","洁","弈晨","胤帖","缁坐","法民","法敏","川","国尧","咏颐","惠山","思宇","小宝","恒世","毛儿","世恒","毛小","嘉浩","恒","李恒","岳宁","恒龙","恒贵","贵恒","洋","佳霖","佳欣","杰","曜岩","臻","文恒","雨函","昕","星泽","星睿","恒文","奕","玉","晨轩","李文","文婍","艾静","昂然","晨晨","佳晨","小龙","定轩","姗","浩宇","昕阳","昊宇","舒飞","亚骏","泊显","漠煜","辉","凌薇","佳雪","景浩","昱霖","昱娴","金禹","明泽","泽晓","锦泽","梦洁","倩雪","鸿毅","雨泽","钰熙","吉洋","晨欣","雨涵","晨濡","茉","佳阳","婉儿","菀儿","宛儿","诗琪","瑾萱","硕","家熠","颢","嘉城","优漩","奕漩","懿轩","清明","忆彤","奕澄","乐姗","优璇","昀蹊","征洋","扬","春霞","承樨","承叡","承檄"
        };
        string scdsjxm = "生成的随机姓名";
        string scdzdxsdxm = "生成的姓氏指定的姓名";
        List<string> distinct = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            label1.ForeColor = System.Drawing.Color.Red;
            
            //this.FormBorderStyle = FormBorderStyle.None;//无边框
            //this.WindowState = FormWindowState.Maximized;//窗体最大化
        }
        //private void IsFileExist(string FileName)//判断文件是否存在，如果不存在则生成
        //{
        //    if (!File.Exists(@"C:\Users\Administrator\Desktop\" + FileName + ".txt"))
        //    {
        //        FileStream fs = new FileStream(@"C:\Users\Administrator\Desktop\" + FileName + ".txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);//创建文件
        //        fs.Flush();
        //        fs.Close();
        //    }
        //}
        private List<string> readFile(string fileName)//读取文件
        {
            StreamReader sr = new StreamReader(@"C:\Users\Administrator\Desktop\" + fileName + ".txt", Encoding.Default);
            while (!sr.EndOfStream)//如果读取到流末尾则停止
            {
                distinct.Add(sr.ReadLine());
            }
            for (int i = 0; i < distinct.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(distinct[i]))
                {
                    distinct.RemoveAt(i);
                }
            }
            sr.Close();
            return distinct;
        }
        private void streamWrite(int num,string fileName,string familyName="")//给姓名文件写入内容
        {
            Random rd = new Random();//随机数
            if (fileName == scdsjxm)
            {
                if (File.Exists(@"C:\Users\Administrator\Desktop\" + scdsjxm + ".txt"))
                {
                   distinct = readFile(scdsjxm);
                }
              
                StreamWriter sw = new StreamWriter(@"C:\Users\Administrator\Desktop\" + fileName + ".txt", true);//给文件写入内容,如果文件不存在则创建文件
                for (int i = 0; i < num; i++)
                {
                    string newName = xing[rd.Next(0, xing.Length - 1)] + ming[rd.Next(0, ming.Length - 1)] ;
                    if (distinct.Contains(newName))
                    {
                        i--;
                    }
                    else
                    {
                        distinct.Add(newName);
                    }
                    sw.WriteLine(distinct.Count + "、" + newName + "\r\n");//【\r】回车【\n】换行
                }
                
                sw.Flush();//清除缓存
                sw.Close();//关闭流
            }
            else if (fileName == scdzdxsdxm)
            {
                if (File.Exists(@"C:\Users\Administrator\Desktop\" + scdzdxsdxm + ".txt"))
                {
                    distinct = readFile(scdzdxsdxm);
                }
                StreamWriter sw = new StreamWriter(@"C:\Users\Administrator\Desktop\" + fileName + ".txt", true);//给文件写入内容,如果文件不存在则创建文件
                for (int i = 0; i < num; i++)
                {
                    string newName = familyName + ming[rd.Next(0, ming.Length - 1)];
                    if (distinct.Contains(newName))
                    {
                        i--;
                    }
                    else
                    {
                        distinct.Add(newName);
                    }
                    sw.WriteLine(distinct.Count + "、" + newName + "\r\n");//【\r】回车【\n】换行

                }
                sw.Flush();//清除缓存
                sw.Close();//关闭流
            }
            distinct.Clear();
        }
        private void button1_Click(object sender, EventArgs e)//姓名全部随机
        {
            int num = Convert.ToInt32(numericUpDown1.Value);//生成随机姓名数
            streamWrite(num, scdsjxm);//给文件写入内容
            label1.Text = "随机姓名生成成功，请在桌面查看";
        }

        private void button2_Click(object sender, EventArgs e)//姓指定，名随机
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text.Trim())&& textBox1.Text.Trim() != "请输入姓氏")
            {
                Regex rx = new Regex("^[\u4e00-\u9fa5]+");
                bool a = rx.IsMatch(textBox1.Text);
                if (!rx.IsMatch(textBox1.Text))//只能显示中文
                {
                    label1.Text = "姓氏只能输入中文!";
                    return;
                }
                string familyName = textBox1.Text.Trim();//生成何种姓氏的姓名
                int num = Convert.ToInt32(numericUpDown1.Value);//生成随机姓名数量
                streamWrite(num, scdzdxsdxm, familyName);
                label1.Text = "姓氏指定的姓名生成成功，请在桌面查看!";
            }
            else
            {
                label1.Text = "必须输入姓氏";
                return;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "请输入姓氏";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "请输入姓氏")
            {
                textBox1.Text = "";
            }
           
        }
    }
}
