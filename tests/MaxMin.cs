using System;
using challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tests.test_files;

namespace tests
{
    [TestClass]
    public class MaxMin
    {
        [TestMethod]
        public void MaxMin1()
        {
            var res = Challenges.MaxMin(TestResources.maxmin1);
            Assert.AreEqual(20, res);
        }

        [TestMethod]
        public void MaxMin2()
        {
            var res = Challenges.MaxMin(TestResources.maxmin2);
            Assert.AreEqual(3, res);
        }

        [TestMethod]
        public void MaxMin3()
        {
            var res = Challenges.MaxMin(TestResources.maxmin3);
            Assert.AreEqual(2, res);
        }
        
        [TestMethod]
        public void MaxMin4()
        {
            var res = Challenges.MaxMin(TestResources.maxmin4);
            Assert.AreEqual(9665150, res);
        }
    }
}
