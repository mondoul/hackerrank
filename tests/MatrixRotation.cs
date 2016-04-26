using System;
using challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tests.test_files;

namespace tests
{
    [TestClass]
    public class MatrixRotation
    {
        [TestMethod]
        public void MatrixRotation1()
        {
            var input = TestResources.matrixrotation_1;
            var matrix = Challenges.RotateMatrix(input);
            Assert.AreEqual(TestResources.matrixrotation_11, matrix);
        }

        [TestMethod]
        public void MatrixRotation2()
        {
            var input = TestResources.matrixrotation_2;
            var matrix = Challenges.RotateMatrix(input);
            Assert.AreEqual(TestResources.matrixrotation_21, matrix);
        }

        [TestMethod]
        public void MatrixRotation3()
        {
            var input = TestResources.matrixrotation_3;
            var matrix = Challenges.RotateMatrix(input);
            Assert.AreEqual(TestResources.matrixrotation_31, matrix);
        }
    }
}
