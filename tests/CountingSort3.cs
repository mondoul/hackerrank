using System;
using System.Collections.Generic;
using challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tests.test_files;

namespace tests
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/countingsort3
    /// </summary>
    [TestClass]
    public class CountingSort3
    {
        [TestMethod]
        public void TestCountingSort3_0()
        {
            var input = new[]
            {
                "10",
                "4 that",
                "3 be",
                "0 to",
                "1 be",
                "5 question",
                "1 or",
                "2 not",
                "4 is",
                "2 to",
                "4 the"
            };
            var res = Challenges.CountSort3(new List<string>(input));
            Assert.AreEqual("1 3 5 6 9 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10 10", res);
        }

        [TestMethod]
        public void TestCountingSort3_1()
        {
            var input = TestResources.countsort3_file1.Split(new [] { "\r\n" }, StringSplitOptions.None);
            var res = Challenges.CountSort3(new List<string>(input));
            Assert.AreEqual("14 23 37 43 58 66 79 93 100 107 115 130 140 150 154 167 178 189 200 208 216 222 232 240 252 263 271 282 290 305 317 328 336 350 360 370 378 387 394 403 416 430 440 450 459 471 486 493 503 510 516 520 530 543 558 563 572 587 595 607 617 629 643 652 659 666 672 680 686 706 714 722 731 745 758 772 781 791 801 806 820 827 834 841 850 863 869 880 892 904 914 932 946 955 961 971 975 983 990 1000", res);
        }
    }
}
