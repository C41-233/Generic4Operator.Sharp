﻿using System;
using System.Collections.Generic;
using System.Numerics;
using Generic4Operator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Types;

namespace Test
{
    [TestClass]
    public class TestOperator
    {

        [TestMethod]
        public void TestAdd()
        {
            Assert.AreEqual(1u + 2u, Ops.Add(1u, 2u));
            Assert.AreEqual(1 + 2, Ops.Add(1, 2));
            Assert.AreEqual(1f + 2f, Ops.Add(1f, 2f));
            Assert.AreEqual(1d + 2d, Ops.Add(1d, 2d));
            Assert.AreEqual(1 + (decimal)2, Ops.Add(1, (decimal)2));
            Assert.AreEqual("1" + "2", Ops.Add("1", "2"));

            Assert.AreEqual(new BigInteger(3) , Ops.Add(new BigInteger(1), new BigInteger(2)));

            Assert.AreEqual(new MyInt(3), Ops.Add(new MyInt(1), new MyInt(2)));
            Assert.AreEqual(1 + 2 + 3, Ops.Add<MyInt, List<int>, int>(new MyInt(1), new List<int>{2, 3}));

            Assert.ThrowsException<NotSupportedException>(() => Ops.Add(new List<int>(), new List<int>()));

            Assert.AreEqual(true, Ops.Add(true, true));
            Assert.AreEqual(true, Ops.Add(true, false));
            Assert.AreEqual(true, Ops.Add(false, true));
            Assert.AreEqual(false, Ops.Add(false, false));
        }

        [TestMethod]
        public void TestSubtract()
        {
            Assert.AreEqual('2' - '1', Ops.Subtract<char, char, int>('2', '1'));
            Assert.AreEqual(2u - 1u, Ops.Subtract(2u, 1u));
            Assert.AreEqual(1 - 2, Ops.Subtract(1, 2));
            Assert.AreEqual(1f - 2f, Ops.Subtract(1f, 2f));
            Assert.AreEqual(1d - 2d, Ops.Subtract(1d, 2d));
            Assert.AreEqual(1 - (decimal)2, Ops.Subtract(1, (decimal)2));
            Assert.ThrowsException<NotSupportedException>(() => Ops.Subtract("1", "2"));

            Assert.AreEqual(new BigInteger(-1), Ops.Subtract(new BigInteger(1), new BigInteger(2)));

            Assert.AreEqual(new MyInt(-1), Ops.Subtract(new MyInt(1), new MyInt(2)));

            Assert.ThrowsException<NotSupportedException>(() => Ops.Add(new List<int>(), new List<int>()));

            Assert.AreEqual(false, Ops.Subtract(true, true));
            Assert.AreEqual(true, Ops.Subtract(true, false));
            Assert.AreEqual(false, Ops.Subtract(false, true));
            Assert.AreEqual(false, Ops.Subtract(false, false));
        }

        [TestMethod]
        public void TestIncrease()
        {
            Assert.AreEqual(1u + 1u, Ops.Increase(1u));
            Assert.AreEqual(1 + 1, Ops.Increase(1));
            Assert.AreEqual((char)('a' + 1), Ops.Increase('a'));
            Assert.AreEqual(1.0f + 1.0f, Ops.Increase(1.0f));
            Assert.AreEqual((decimal)1 + 1, Ops.Increase((decimal)1));

            Assert.AreEqual(new BigInteger(3), Ops.Increase(new BigInteger(2)));

            Assert.AreEqual(new MyInt(3), Ops.Increase<MyInt, MyInt>(new MyInt(2)));

            Assert.ThrowsException<NotSupportedException>(() => Ops.Increase(new List<int>()));

            Assert.AreEqual(true, Ops.Increase(true));
            Assert.AreEqual(true, Ops.Increase(false));
        }

    }
}
