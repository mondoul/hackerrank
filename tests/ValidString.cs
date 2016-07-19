using System;
using challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tests.test_files;

namespace tests
{
    [TestClass]
    public class ValidString
    {
        [TestMethod]
        public void ValidString0()
        {
            var res = Challenges.ValidString("aabbcd");
            Assert.AreEqual("NO", res);
        }

        [TestMethod]
        public void ValidString1()
        {
            var input = TestResources.validstring1;
            var res = Challenges.ValidString(input);
            Assert.AreEqual("YES", res);
        }

        [TestMethod]
        public void ValidString2()
        {
            var input = TestResources.validstring2;
            var res = Challenges.ValidString(input);
            Assert.AreEqual("YES", res);
        }
    }
}
