using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BlockChain.Util;

namespace BlockChainTest
{
    [TestClass]
    public class PrefixTreeTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dic = new Dictionary<string,int>();
            PrefixTree<string, int> prefixTree = new PrefixTree<string, int>();
            var r = new Random();

            dic.Add("DOG", r.Next());
            dic.Add("CAT", r.Next());
            dic.Add("DO", r.Next());
            dic.Add("C", r.Next());
            dic.Add("", r.Next());
            dic.Add("OGCAT", r.Next());

            foreach(KeyValuePair<string,int> kv in dic)
            {
                prefixTree.Add(kv.Key, kv.Value);
                System.Diagnostics.Trace.WriteLine($"{kv.Key},{kv.Value} ; {kv.Key},{prefixTree[kv.Key]}");
                foreach(KeyValuePair<string, int> pkv in prefixTree)
                {
                    System.Diagnostics.Trace.WriteLine($"{pkv.Key},{pkv.Value}");
                }
            }

            foreach (KeyValuePair<string, int> kv in dic)
            {
               System.Diagnostics.Trace.WriteLine($"{kv.Key},{kv.Value} ; {kv.Key},{prefixTree[kv.Key]}");
               Assert.AreEqual(kv.Value, prefixTree[kv.Key]);
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            var dic = new Dictionary<string, int>();
            PrefixTree<string, int> prefixTree = new PrefixTree<string, int>();
            var r = new Random();

            for(int i = 0; i < 100000; i++)
            {
                dic.Add(Guid.NewGuid().ToString(), r.Next());
            }

            // 値セット
            foreach (KeyValuePair<string, int> kv in dic)
            {
                prefixTree.Add(kv.Key, kv.Value);
                //System.Diagnostics.Trace.WriteLine($"{kv.Key},{kv.Value} ; {kv.Key},{prefixTree[kv.Key]}");
            }

            // 整合性チェック
            foreach (KeyValuePair<string, int> kv in dic)
            {
                //System.Diagnostics.Trace.WriteLine($"{kv.Key},{kv.Value} ; {kv.Key},{prefixTree[kv.Key]}");
                Assert.AreEqual(kv.Value, prefixTree[kv.Key]);
            }

            // Stopwatchクラス生成
            var sw = new System.Diagnostics.Stopwatch();
            long prefixTime = 0;
            //long dictTime = 0;
            // PrefixTree計測
            sw.Start();
            foreach (KeyValuePair<string, int> pkv in prefixTree)
            {
                System.Diagnostics.Trace.WriteLine($"{pkv.Key},{pkv.Value}");
            }
            sw.Stop();
            prefixTime = sw.ElapsedMilliseconds;
            // Dictionary計測
            //sw.Reset();
            //sw.Start();
            //foreach (KeyValuePair<string, int> kv in dic)
            //{
            //    System.Diagnostics.Trace.WriteLine($"{kv.Key},{kv.Value}");
            //}
            //sw.Stop();
            //dictTime = sw.ElapsedMilliseconds;
            //Assert.AreEqual(kv.Value, prefixTree[kv.Key]);

            System.Diagnostics.Trace.WriteLine($"Prefix　{prefixTime} ミリ秒");
            //System.Diagnostics.Trace.WriteLine($"Dict　{dictTime} ミリ秒");

        }
    }
}
