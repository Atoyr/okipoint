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
            }

            foreach (KeyValuePair<string, int> kv in dic)
            {
               System.Diagnostics.Trace.WriteLine($"{kv.Key},{kv.Value} ; {kv.Key},{prefixTree[kv.Key]}");
               Assert.AreEqual(kv.Value, prefixTree[kv.Key]);
            }
        }
    }
}
