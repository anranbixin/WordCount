using Microsoft.VisualStudio.TestTools.UnitTesting;
using wordCount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace wordCount.Tests
{
    [TestClass()]
    public class portTests
    {
        
        [TestMethod()]
        public void PrepTest()
        {
            port prep = new port();
            string getchara = prep.Prep(@"D:\VS_practice\wordCount\wordCount\bin\Debug\input.txt");
            Assert.IsNotNull(getchara);
        }
        
        [TestMethod()]
        public void GetcharactersTest()
        {
            port prep = new port();
            string getchara = prep.Getcharacters(@"D:\VS_practice\wordCount\wordCount\bin\Debug\input.txt");
            Assert.IsNotNull(getchara);
        }

       
        [TestMethod()]

        public void WithdrawordTest()
        {
            port prep = new port();
            List<string> word = new List<string>();
            string getch = null;
            getch = prep.Getcharacters(@"D:\VS_practice\wordCount\wordCount\bin\Debug\input.txt");
            word = prep.Withdraword();
            Assert.IsNotNull(word);
    }

        [TestMethod()]
        public void TolowerTest()
        {
            port pt = new port();
            string prep = null;
            int text = 0;
            prep = pt.Prep(@"D:\VS_practice\wordCount\wordCount\bin\Debug\input.txt");
            text = pt.Tolower();
            Assert.AreEqual(1,text);
        }

        [TestMethod()]
        public void WordlinenumTest()
        {
            port pt = new port();
            string prep = null;
            int text = 0;
            prep = pt.Prep(@"D:\VS_practice\wordCount\wordCount\bin\Debug\input.txt");
            text = pt.Tolower();
            int line = 0;
            line = pt.Wordlinenum();
            Assert.IsTrue(line > 0);
        }

        [TestMethod()]
        public void CharacternumTest()
        {
            port pt = new port();
            string prep = null;
            int text = 0;
            prep = pt.Prep(@"D:\VS_practice\wordCount\wordCount\bin\Debug\input.txt");
            text = pt.Tolower();
            int line = 0;
            line = pt.Wordlinenum();
            int wordcount = 0;
            wordcount = pt.Characternum();
            Assert.IsTrue(wordcount > 0);
        }

        [TestMethod()]
        public void WordnumTest()
        {
            port pt = new port();
            string prep = null;
            int text = 0;
            prep = pt.Prep(@"D:\VS_practice\wordCount\wordCount\bin\Debug\input.txt");
            text = pt.Tolower();
            int line = 0;
            line = pt.Wordlinenum();
            int wordcount = 0;
            wordcount = pt.Characternum();
            int wordnum = 0;
            wordnum = pt.Wordnum();
            Assert.IsTrue(wordcount > 0);
        }

        [TestMethod()]
        public void WordfrequencyTest()
        {
            port pt = new port();
            string prep = null;
            int text = 0;
            prep = pt.Prep(@"D:\VS_practice\wordCount\wordCount\bin\Debug\input.txt");
            text = pt.Tolower();
            int line = 0;
            line = pt.Wordlinenum();
            int wordcount = 0;
            wordcount = pt.Characternum();
            int wordnum = 0;
            wordnum = pt.Wordnum();
            int wordf = 0;
            wordf = pt.Wordfrequency();
            Assert.IsTrue(wordf > 0);
        }

        [TestMethod()]
        public void GetsortTest()
        {
            Dictionary<string, int> dc = new Dictionary<string, int>();
            port pt = new port();
            string prep = null;
            int text = 0;
            prep = pt.Prep(@"D:\VS_practice\wordCount\wordCount\bin\Debug\input.txt");
            text = pt.Tolower();
            int line = 0;
            line = pt.Wordlinenum();
            int wordcount = 0;
            wordcount = pt.Characternum();
            int wordnum = 0;
            wordnum = pt.Wordnum();
            int wordf = 0;
            wordf = pt.Wordfrequency();
            dc = pt.Getsort();
            Assert.IsNotNull(dc);
        }

        [TestMethod()]
        public void WritetofileTest()
        {
            Dictionary<string, int> dc = new Dictionary<string, int>();
            port pt = new port();
            string prep = null;
            int text = 0;
            prep = pt.Prep(@"D:\VS_practice\wordCount\wordCount\bin\Debug\input.txt");
            text = pt.Tolower();
            int line = 0;
            line = pt.Wordlinenum();
            int wordcount = 0;
            wordcount = pt.Characternum();
            int wordnum = 0;
            wordnum = pt.Wordnum();
            int wordf = 0;
            wordf = pt.Wordfrequency();
            dc = pt.Getsort();
            int wf = 0;
            wf = pt.Writetofile(@"D:\VS_practice\wordCount\wordCount\bin\Debug\input.txt", @"D:\VS_practice\wordCount\wordCount\bin\Debug\output.txt");
            Assert.AreEqual(1,wf);
        }

        [TestMethod()]
        public void WritewordTest()
        {
            int text = 0;
            port pt = new port();
            StreamWriter sw = null;
            sw = new StreamWriter(@"D:\VS_practice\wordCount\wordCount\bin\Debug\output.txt");
            string getchara = pt.Prep(@"D:\VS_practice\wordCount\wordCount\bin\Debug\input.txt");
            text = pt.Writeword(sw,3);
            Assert.AreEqual(1,text);
        }

        [TestMethod()]
        public void WordgrouppTest()
        {
            int text = 0;
            port pt = new port();
            StreamWriter sw = null;
            sw = new StreamWriter(@"D:\VS_practice\wordCount\wordCount\bin\Debug\output.txt");
            string getchara = pt.Prep(@"D:\VS_practice\wordCount\wordCount\bin\Debug\input.txt");
            text = pt.Writeword(sw, 3);
            int text02 = 0;
            text02 = pt.Wordgroupp(sw,2);
            Assert.AreEqual(1, text02);
        }
    }
}