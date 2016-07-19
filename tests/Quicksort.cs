using System;
using challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class Quicksort
    {
        [TestMethod]
        public void Quicksort1()
        {
            var input = "7\r\n1 3 9 8 2 7 5";
            var res = Challenges.QuicksortInPlace(input);
            Assert.AreEqual("", res);
        }
    }
}
