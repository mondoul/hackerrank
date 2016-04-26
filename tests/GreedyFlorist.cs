using System;
using challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tests.test_files;

namespace tests
{
    [TestClass]
    public class GreedyFlorist
    {
        [TestMethod]
        public void GreedyFlorist1()
        {
            var input = TestResources.greedyflorist1;
            var res = Challenges.GreedyFlorist(input);
            Assert.AreEqual(13, res);
        }

        [TestMethod]
        public void GreedyFlorist2()
        {
            var input = TestResources.greedyflorist2;
            var res = Challenges.GreedyFlorist(input);
            Assert.AreEqual(15, res);
        }
        
        [TestMethod]
        public void GreedyFlorist3()
        {
            var input = TestResources.greedyflorist3;
            var res = Challenges.GreedyFlorist(input);
            Assert.AreEqual(163578911, res);
        }
    }
}
