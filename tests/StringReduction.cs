using System;
using challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tests.test_files;

namespace tests
{
    [TestClass]
    public class StringReduction
    {
        [TestMethod]
        public void StringReduction1()
        {
            var input = TestResources.stringreduction1;
            var res = Challenges.StringReduction(input);
            Assert.AreEqual(TestResources.stringreduction11, res);
        }

        [TestMethod]
        public void StringReduction2()
        {
            var input = TestResources.stringreduction2;
            var res = Challenges.StringReduction(input);
            Assert.AreEqual(TestResources.stringreduction22, res);
        }
    }
}
