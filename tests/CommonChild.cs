using System;
using challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class CommonChild
    {
        [TestMethod]
        public void CommonChild1()
        {
            var result = Challenges.CommonChild("HARRY\r\nSALLY");
            Assert.AreEqual(2, result);
        }
        
        [TestMethod]
        public void CommonChild2()
        {
            var result = Challenges.CommonChild("AA\r\nBB");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CommonChild3()
        {
            var result = Challenges.CommonChild("SHINCHAN\r\nNOHARAAA");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void CommonChild4()
        {
            var result = Challenges.CommonChild("ABCDEF\r\nFBDAMN");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void CommonChild5()
        {
            var result = Challenges.CommonChild("WEWOUCUIDGCGTRMEZEPXZFEJWISRSBBSYXAYDFEJJDLEBVHHKS\r\nFDAGCXGKCTKWNECHMRXZWMLRYUCOCZHJRRJBOAJOQJZZVUYXIC");
            Assert.AreEqual(15, result);
        }
    }
}
