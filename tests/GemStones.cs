using System;
using challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tests.test_files;

namespace tests
{
    [TestClass]
    public class GemStones
    {
        [TestMethod]
        public void Gemstones1()
        {
            var input = TestResources.gemstones1;
            var res = Challenges.GemStones(input);
            Assert.AreEqual(2, res);
        }
    }
}
