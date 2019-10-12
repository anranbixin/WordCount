using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace wordCount
{
    public class port
    {
        //接收文件内容
        string account_chara = null;
        //记录行数
        int account_line = 0;
        //记录单词
        List<string> word = new List<string>();
        //Dictionary创建单词到频率的新映射,它将有效统计每个单词在一段给定文本中出现的频率
        //记录单词频数(排序之后)
        Dictionary<string, int> word_num = new Dictionary<string, int>();
        
        public void Prep(string path)
        {
            Getcharacters(path);
            Withdraword();
            Tolower();
            Wordfrequency();

        }
        //打开文件
        //FileInfo file = new FileInfo(path);
        //定义读取内容
        //StreamReader content = file.OpenText();
        //读取文件，string account_chara用于存储字符
        public void Getcharacters(string path)
        {
            try
            {
                path.Contains(".txt");
            }
            catch
            {
                Console.WriteLine("输入的路径不含有txt文件！");
            }
            StreamReader content = new StreamReader(path);
            //定义字符临时变量
            string temp = content.ReadLine();
            //读取
            while (temp != null)
            {
                account_chara = account_chara + temp;
                account_line++;
                temp = content.ReadLine();
            }            
        }
        //正则表达式匹配英文单词
        public void Withdraword()
        {
            //以字母开头，数字结尾,单词至少4个字符
            MatchCollection mc_word = Regex.Matches(account_chara, @"([a-zA-Z]{4}\w*)");
            //临时变量
            int i = 0;
            while (i < mc_word.Count)
            {
                //存储单词
                word.Add(Convert.ToString(mc_word[i]));
                i++;
            }
        }
        //将wordlistde单词转化位小写
        public void Tolower()
        {
            foreach (string element in word)
            {
                element.ToLower();
            }
        }
        //获取行数
        public int Wordlinenum()
        {
            return account_line;
        }
        //字符总数
        public int Characternum()
        {
            //区分是否为中文，中文是@"[\u4e00-\u9fa5]"     \u4E00-\u9FA5
            MatchCollection mc_chara = Regex.Matches(account_chara, @"[^\u4e00-\u9fa5]*");
            string temp = null;
            int i = 0;
            while (i < mc_chara.Count)
            {
                temp = temp + Convert.ToString(mc_chara[i]);
                i++;
            }
            return temp.Length;
        }
        //单词总数
        public int Wordnum()
        {
            return word.Count;
        }
        //单词频数（dictionary,sort）
        public void Wordfrequency()
        {
            //排序之前，将单词存入dictionary
            Dictionary<string, int> d_word = new Dictionary<string, int>();
            int i = 0;
            while (i < word.Count)
            {
                //ContainsKey判断是否存在
                if (d_word.ContainsKey(word[i]))
                {
                    d_word[word[i]]++;
                }
                else
                {
                    d_word[word[i]] = 1;
                }
                i++;
            }
            //通过dictionary的key和value进行排序
            word_num = d_word.OrderByDescending(p => p.Value).ToDictionary(p => p.Key, o => o.Value);
        }
        public Dictionary<string, int> Getsort()
        {
            return word_num;
        }
        //写入文件
        public void Writetofile(string path,string outpath)
        {
            //准备（读入文档，单词提取，以及词频的排序）
            //Prep(path);
            FileInfo file = null;
            if (outpath == null)
            {
                file = new FileInfo(@"D:\VS_practice\wordCount\wordCount\bin\Debug\output.txt");
            }
            else
            {
                file = new FileInfo(outpath);
            }
            StreamWriter sw = file.AppendText();
            sw.WriteLine("字符数：" + Characternum());
            sw.WriteLine("单词数：" + Wordnum());
            sw.WriteLine("行数：" + Wordlinenum());
            Console.WriteLine("字符数为：" + Characternum());
            Console.WriteLine("单词数为：" + Wordnum());
            Console.WriteLine("行数为：" + Wordlinenum());
            //统计前10个高频单词
            Writeword(sw,10);
            //关闭文件
            sw.Close();
            Console.WriteLine("结果文件保存于: \n D:\\VS_practice\\wordCount\\wordCount\\bin\\Debug\\output.txt");
        }

        //筛选出前10个高频单词
        public void Writeword(StreamWriter sw,int n)
        {
            int flag = 0;
            foreach (KeyValuePair<string, int> element in word_num)
            {
                string key = element.Key;
                int value = element.Value;
                //写入前10个高频单词，以及其频数
                if (flag < n)
                {
                    Console.WriteLine("单词 : {0}\t 频数是 : {1}", key, value);
                    sw.WriteLine("单词 :{0}\t 频数是 : {1}", key, value);
                    flag++;
                }

            }
        }
        //输出指定数量的单词数，并写入文件
        public void Wordgroupp(StreamWriter sw, int m)
        {
            Dictionary<string, int> dc = new Dictionary<string, int>();
            string list = null;
            int i, j;
            for (i = 0; i <= word.Count - m; i++)
            {
                list = word[i];
                for (j = 1; j < m ; j++)
                {
                    list += " " + word[i + j];
                }
                if (dc.ContainsKey(list))
                {
                    dc[list]++;
                }
                else
                {
                    dc[list] = 1;
                }
            }
            //排序
            Dictionary<string, int> tt = dc.OrderByDescending(p => p.Value).ThenBy(o => o.Key).ToDictionary(p => p.Key, o => o.Value);
            //遍历输出
            foreach (KeyValuePair<string, int> element in tt)
            {
                Console.WriteLine("单词组为:{0}\t频数是：{1}", element.Key, element.Value);
                sw.WriteLine("单词组为:{0}\t频数是：{1}", element.Key, element.Value);
            }
        }
        /*
         //测试代码prep
        public string Prep(string path)
        {
            string text01 = null;
            List<string> text02 = new List<string>();
            int text03 = 0;
            int text04 = 0;
            text01 = Getcharacters(path);
            text02 = Withdraword();
            text03 = Tolower();
            text04 = Wordfrequency();
            return account_chara;

        }
        public string Getcharacters(string path)
        {
            StreamReader content = new StreamReader(path);
            //定义字符临时变量
            string temp = content.ReadLine();
            //读取
            while (temp != null)
            {
                account_chara = account_chara + temp;
                account_line++;
                temp = content.ReadLine();
            }

            //最后一行读入无效，将其删去
            account_line -= 1;
            return account_chara;
        }
        public List<string> Withdraword()
        {
            //以字母开头，数字结尾,单词至少4个字符
            MatchCollection mc_word = Regex.Matches(account_chara, @"([a-zA-Z]{4}\w*)");
            //临时变量
            int i = 0;
            while (i < mc_word.Count)
            {
                //存储单词
                word.Add(Convert.ToString(mc_word[i]));
                i++;
            }
            return word;
        }
        public int Tolower()
        {
            foreach (string element in word)
            {
                element.ToLower();
            }
            return 1;
        }
        public int Wordlinenum()
        {
            return account_line;
        }
        //字符总数
        public int Characternum()
        {
            //区分是否为中文，中文是@"[\u4e00-\u9fa5]"     \u4E00-\u9FA5
            MatchCollection mc_chara = Regex.Matches(account_chara, @"[^\u4e00-\u9fa5]*");
            string temp = null;
            int i = 0;
            while (i < mc_chara.Count)
            {
                temp = temp + Convert.ToString(mc_chara[i]);
                i++;
            }
            return temp.Length;
        }
        //单词总数
        public int Wordnum()
        {
            return word.Count;
        }
        //单词频数（dictionary,sort）
        public int Wordfrequency()
        {
            //排序之前，将单词存入dictionary
            Dictionary<string, int> d_word = new Dictionary<string, int>();
            int i = 0;
            while (i < word.Count)
            {
                //ContainsKey判断是否存在
                if (d_word.ContainsKey(word[i]))
                {
                    d_word[word[i]]++;
                }
                else
                {
                    d_word[word[i]] = 1;
                }
                i++;
            }
            //通过dictionary的key和value进行排序
            word_num = d_word.OrderByDescending(p => p.Value).ToDictionary(p => p.Key, o => o.Value);
            return 1;
        }
        public Dictionary<string, int> Getsort()
        {
            return word_num;
        }
        //写入文件
        public int Writetofile(string path, string outpath)
        {
            //准备（读入文档，单词提取，以及词频的排序）
            Prep(path);
            FileInfo file = null;
            if (outpath == null)
            {
                file = new FileInfo(@"D:\VS_practice\wordCount\wordCount\bin\Debug\output.txt");
            }
            else
            {
                file = new FileInfo(outpath);
            }
            StreamWriter sw = file.AppendText();
            sw.WriteLine("字符数：" + Characternum());
            sw.WriteLine("单词数：" + Wordnum());
            sw.WriteLine("行数：" + Wordlinenum());
            Console.WriteLine("字符数为：" + Characternum());
            Console.WriteLine("单词数为：" + Wordnum());
            Console.WriteLine("行数为：" + Wordlinenum());
            //统计前10个高频单词
            Writeword(sw, 10);
            //关闭文件
            sw.Close();
            Console.WriteLine("结果文件保存于: \n D:\\VS_practice\\wordCount\\wordCount\\bin\\Debug\\output.txt");
            return 1;
        }

        //筛选出前10个高频单词
        public int Writeword(StreamWriter sw, int n)
        {
            int flag = 0;
            foreach (KeyValuePair<string, int> element in word_num)
            {
                string key = element.Key;
                int value = element.Value;
                //写入前10个高频单词，以及其频数
                if (flag < n)
                {
                    Console.WriteLine("单词 : {0}\t 频数是 : {1}", key, value);
                    sw.WriteLine("单词 :{0}\t 频数是 : {1}", key, value);
                    flag++;
                }

            }
            return 1;
        }
        //输出指定数量的单词数，并写入文件
        public int Wordgroupp(StreamWriter sw, int m)
        {
            Dictionary<string, int> dc = new Dictionary<string, int>();
            string list = null;
            int i, j;
            for (i = 0; i <= word.Count - m; i++)
            {
                list = word[i];
                for (j = 1; j < m; j++)
                {
                    list += " " + word[i + j];
                }
                if (dc.ContainsKey(list))
                {
                    dc[list]++;
                }
                else
                {
                    dc[list] = 1;
                }
            }
            //排序
            Dictionary<string, int> tt = dc.OrderByDescending(p => p.Value).ThenBy(o => o.Key).ToDictionary(p => p.Key, o => o.Value);
            //遍历输出
            foreach (KeyValuePair<string, int> element in tt)
            {
                Console.WriteLine("单词组为:{0}\t频数是：{1}", element.Key, element.Value);
                sw.WriteLine("单词组为:{0}\t频数是：{1}", element.Key, element.Value);
            }
            return 1;
        }

         */
    }
}
