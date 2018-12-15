using System;
using System.Collections.Generic;
using Generic4Operator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Types;

namespace Test
{
    [TestClass]
    public class TestIndex
    {

        [TestMethod]
        public void TestIndexGet()
        {
            Assert.AreEqual(2, Ops.Index<List<int>, int, int>(new List<int> { 1, 2 }, 1));
            Assert.AreEqual(3, Ops.Index<MyInt, int, int>(new MyInt(1), 2));
            Assert.AreEqual(1 + 2 + 3, Ops.Index<MyInt, int, long, long>(new MyInt(1), 2, 3));
        }

        [TestMethod]
        public void TestIndexGetArray()
        {
            Assert.AreEqual(2, Ops.Index<int[], int, int>(new int[] { 1, 2 }, 1));
            Assert.AreEqual(10, Ops.Index<int[,], int, int, int>(new int[,] { {00, 01}, {10, 11} }, 1, 0));
        }

        [TestMethod]
        public void TestIndexSet1()
        {
            var list = new List<int>{1, 2, 3, 4};
            Ops.Index(list, 2, 2);
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(2, list[2]);

            Assert.ThrowsException<NotSupportedException>(() =>
            {
                Ops.Index(list, "1", "2", "3");
            });
        }

        [TestMethod]
        public void TestIndexSetArray1()
        {
            var list = new int[] { 1, 2, 3, 4 };
            Ops.Index(list, 2, 2);
            Assert.AreEqual(4, list.Length);
            Assert.AreEqual(2, list[2]);

            Assert.ThrowsException<NotSupportedException>(() =>
            {
                Ops.Index(list, "1", "2", "3");
            });
        }

        [TestMethod]
        public void TestIndexSetArray2()
        {
            var list = new int[,] { {00, 01}, {10, 11} };
            Ops.Index(list, 1, 0, 55);
            Assert.AreEqual(55, list[1, 0]);
        }

    }
}
