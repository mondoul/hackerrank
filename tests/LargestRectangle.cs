using System;
using challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tests.test_files;

namespace tests
{
    [TestClass]
    public class LargestRectangle
    {
        [TestMethod]
        public void LargestRest0()
        {
            var res = Challenges.LargestRectangle(TestResources.lrect0);
            Assert.AreEqual(8, res);
        }

        [TestMethod]
        public void LargestRest1()
        {
            var res = Challenges.LargestRectangle(TestResources.lrect1);
            Assert.AreEqual(26152, res);
        }

        [TestMethod]
        public void LargestRest2()
        {
            var res = Challenges.LargestRectangle(TestResources.lrect2);
            Assert.AreEqual(10414422, res);
        }

    }
}
