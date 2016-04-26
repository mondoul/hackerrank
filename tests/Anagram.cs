using System;
using challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tests.test_files;

namespace tests
{
    [TestClass]
    public class Anagram
    {
        [TestMethod]
        public void Anagram1()
        {
            var input = TestResources.anagram1;
            var res = Challenges.Anagram(input);
            Assert.AreEqual(TestResources.anagram1_res, res);
        }
    }
}
