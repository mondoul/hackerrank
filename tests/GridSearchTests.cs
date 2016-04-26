using System;
using challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tests.test_files;

namespace tests
{
    [TestClass]
    public class GridSearchTests
    {
        [TestMethod]
        public void GridSearchTest_1()
        {
            var input = TestResources.gridsearch_1;
            var res = Challenges.GridSearch(input);
            Assert.AreEqual("YES NO", res.Trim());
        }

        [TestMethod]
        public void GridSearchTest_2()
        {
            var input = TestResources.gridsearch_2;
            var res = Challenges.GridSearch(input);
            Assert.AreEqual("YES YES NO", res.Trim());
        }

        [TestMethod]
        public void GridSearchTest_3()
        {
            var input = TestResources.gridsearch_3;
            var res = Challenges.GridSearch(input);
            Assert.AreEqual("YES", res.Trim());
        }

        [TestMethod]
        public void GridSearchTest_4()
        {
            var input = TestResources.gridsearch_4;
            var res = Challenges.GridSearch(input);
            Assert.AreEqual("YES", res.Trim());
        }

        [TestMethod]
        public void GridSearchTest_5()
        {
            var input = TestResources.gridsearch_5;
            var res = Challenges.GridSearch(input);
            Assert.AreEqual("YES", res.Trim());
        }
    }
}
