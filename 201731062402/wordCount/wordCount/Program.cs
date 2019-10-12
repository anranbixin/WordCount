using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//文件流的输入输出
using System.IO;
//正则表达式
using System.Text.RegularExpressions;

namespace wordCount
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            port my = new port();
            //AppDomain.CurrentDomain.BaseDirectory+@"201731062402\input.txt"
            //my.Writetofile(@"D:\VS_practice\201731062402\input.txt", @"D:\VS_practice\201731062402\output.txt");
            StreamWriter sw = null;
            //Count count = new DoCount();
            string path = null;//读入文件路径标志
            string outpath = null;//写出文件路径标志
            string n = null;//限制输出个数的值+频数的值
            string m = null;//指定频数的值
            //arg:-i iuput路径 -o output路径 -n  数 -m 数
            //初始化
            path = "input.txt";
            outpath = "output.txt";
            //n = "3";
            //m = "2";
            
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-i":
                        try
                        {
                            args[i+1].Contains(".txt");
                        }
                        catch
                        {
                            Console.WriteLine("输入的路径无效！不含有txt文件！");
                        }
                        path = args[i + 1];//输入路径
                        break;
                    case "-o"://-o输出路径
                        outpath = args[i + 1];
                        break;
                    case "-m"://-m输出几个高频词
                        try
                        {
                            int test = int.Parse(args[i + 1]);
                        }
                        catch
                        {
                            Console.WriteLine("输入的指令无效");
                        }
                        m = args[i + 1];
                        break;
                    case "-n"://-n输出几个单词的个数
                        n = args[i + 1];
                        break;
                    
                }
            }
            //获取当前文件路径
            string filepath = Directory.GetCurrentDirectory();
            path = filepath +"\\"+ path;
            outpath = filepath + "\\"+outpath;
            Console.WriteLine(path);
            my.Prep(path);
            if (path != null)
            {
                if (outpath != null)
                {
                    sw = new StreamWriter(outpath);//在outPath创建写文件流
                }
                if (m != null)//将查找指定频数的结果输出，并写入文件
                {
                    int temp = int.Parse(m);
                    Console.WriteLine("---------自定义输出单词数输出--------------");
                    sw.WriteLine("---------自定义输出单词数输出--------------");
                    sw.WriteLine("单词数为" + m + "的单词如下：");
                    Console.WriteLine("单词数为" + m + "的单词如下：");
                    my.Wordgroupp(sw, temp); 
                }
                if (n != null)//将输出指定数量的单词数，并写入文件
                {
                    int temp = int.Parse(n);
                    Console.WriteLine("---------自定义单词数输出--------------");
                    sw.WriteLine("---------自定义单词数输出--------------");
                    sw.WriteLine("前" + n + "频数的单词如下：");
                    Console.WriteLine("前" + n + "频数的单词如下：");
                    my.Writeword(sw, temp);
                }
            }
            else
            {
                Console.WriteLine("参数错误！");
            }
            //Console.WriteLine("以上均已写入文件！");
            Console.WriteLine("---------基本输出--------------");
            sw.WriteLine("---------基本输出--------------");
            if (sw != null)
            {
                sw.Flush();
                sw.Close();
            }
            my.Writetofile(path,outpath);
            Console.ReadKey();
            
        }
       
        
    }
}
