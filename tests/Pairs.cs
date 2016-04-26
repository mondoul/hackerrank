using System;
using challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tests.test_files;

namespace tests
{
    [TestClass]
    public class Pairs
    {
        [TestMethod]
        public void Pairs1()
        {
            var input = TestResources.pairs1;
            var res = Challenges.Pairs(input);
            Assert.AreEqual(3, res);
        }
    }
}
