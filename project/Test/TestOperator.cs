using System;
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
        public void TestMultiply()
        {
            Assert.AreEqual(1u * 2u, Ops.Multiply(1u, 2u));
            Assert.AreEqual(1 * 2, Ops.Multiply(1, 2));
            Assert.AreEqual(1f * 2f, Ops.Multiply(1f, 2f));
            Assert.AreEqual(1d * 2d, Ops.Multiply(1d, 2d));
            Assert.AreEqual(1 * (decimal)2, Ops.Multiply(1, (decimal)2));
            Assert.AreEqual("11", Ops.Multiply<string, int, string>("1", 2));

            Assert.AreEqual(new BigInteger(2), Ops.Multiply(new BigInteger(1), new BigInteger(2)));

            Assert.AreEqual(new MyInt(2), Ops.Multiply(new MyInt(1), new MyInt(2)));

            Assert.ThrowsException<NotSupportedException>(() => Ops.Multiply(new List<int>(), new List<int>()));

            Assert.AreEqual(true, Ops.Multiply(true, true));
            Assert.AreEqual(false, Ops.Multiply(true, false));
            Assert.AreEqual(false, Ops.Multiply(false, true));
            Assert.AreEqual(false, Ops.Multiply(false, false));
        }

        [TestMethod]
        public void TestDivide()
        {
            Assert.AreEqual(1u / 2u, Ops.Divide(1u, 2u));
            Assert.AreEqual(5 / 2, Ops.Divide(5, 2));
            Assert.AreEqual(5f / 2f, Ops.Divide<int, int, float>(5, 2));
            Assert.AreEqual(5f / 2f, Ops.Divide<MyInt, MyInt, double>(new MyInt(5), new MyInt(2)));
            Assert.AreEqual(new BigInteger(3), Ops.Divide(new BigInteger(12), new BigInteger(4)));
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

        [TestMethod]
        public void TestIncreaseAndGet()
        {
            {
                var v = 10;
                Assert.AreEqual(11, Ops.IncreaseAndGet(ref v));
                Assert.AreEqual(11, v);
            }
            {
                var v = new BigInteger(100);
                Assert.AreEqual(new BigInteger(101), Ops.IncreaseAndGet(ref v));
                Assert.AreEqual(new BigInteger(101), v);
            }
            {
                var v = false;
                Assert.AreEqual(true, Ops.IncreaseAndGet(ref v));
                Assert.AreEqual(true, v);
            }
            {
                var v = true;
                Assert.AreEqual(true, Ops.IncreaseAndGet(ref v));
                Assert.AreEqual(true, v);
            }
            {
                Assert.ThrowsException<NotSupportedException>(() =>
                {
                    var v = "";
                    Ops.IncreaseAndGet(ref v);
                });
            }
        }

        [TestMethod]
        public void TestIncreaseAndGetOriginal()
        {
            {
                var v = 10;
                Assert.AreEqual(10, Ops.IncreaseAndGetOriginal(ref v));
                Assert.AreEqual(11, v);
            }
            {
                var v = new BigInteger(100);
                Assert.AreEqual(new BigInteger(100), Ops.IncreaseAndGetOriginal(ref v));
                Assert.AreEqual(new BigInteger(101), v);
            }
            {
                var v = false;
                Assert.AreEqual(false, Ops.IncreaseAndGetOriginal(ref v));
                Assert.AreEqual(true, v);
            }
            {
                var v = true;
                Assert.AreEqual(true, Ops.IncreaseAndGetOriginal(ref v));
                Assert.AreEqual(true, v);
            }
            {
                Assert.ThrowsException<NotSupportedException>(() =>
                {
                    var v = "";
                    Ops.IncreaseAndGetOriginal(ref v);
                });
            }
        }

        [TestMethod]
        public void TestDecrease()
        {
            Assert.AreEqual(0u, Ops.Decrease(1u));
            Assert.AreEqual(-1L, Ops.Decrease(0L));
            Assert.AreEqual(uint.MaxValue, Ops.Decrease(0u));

            Assert.AreEqual(0f, Ops.Decrease(1f));

            Assert.AreEqual(new MyInt(-101), Ops.Decrease<MyInt, MyInt>(new MyInt(-100)));

            Assert.AreEqual(new BigInteger(1), Ops.Decrease(new BigInteger(2)));

            Assert.ThrowsException<NotSupportedException>(() => Ops.Decrease(new List<int>()));

            Assert.ThrowsException<NotSupportedException>(() => Ops.Decrease<MyInt, string>(new MyInt(10)));

            Assert.AreEqual(false, Ops.Decrease(true));
            Assert.AreEqual(false, Ops.Decrease(false));
        }

        [TestMethod]
        public void TestDecreaseAndGet()
        {
            {
                var v = 1u;
                Assert.AreEqual(0u, Ops.DecreaseAndGet(ref v));
                Assert.AreEqual(0u, v);
            }
            {
                var v = 0f;
                Assert.AreEqual(-1f, Ops.DecreaseAndGet(ref v));
                Assert.AreEqual(-1f, v);
            }
            {
                var v = new MyInt(-100);
                Assert.AreEqual(new MyInt(-101), Ops.DecreaseAndGet(ref v));
                Assert.AreEqual(new MyInt(-101), v);
            }

            {
                var v = new BigInteger(-100);
                Assert.AreEqual(new BigInteger(-101), Ops.DecreaseAndGet(ref v));
                Assert.AreEqual(new BigInteger(-101), v);
            }
        }

        [TestMethod]
        public void TestDecreaseAndGetOriginal()
        {
            {
                var v = 1u;
                Assert.AreEqual(1u, Ops.DecreaseAndGetOriginal(ref v));
                Assert.AreEqual(0u, v);
            }
            {
                var v = 0f;
                Assert.AreEqual(0f, Ops.DecreaseAndGetOriginal(ref v));
                Assert.AreEqual(-1f, v);
            }
            {
                var v = new MyInt(-100);
                Assert.AreEqual(new MyInt(-100), Ops.DecreaseAndGetOriginal(ref v));
                Assert.AreEqual(new MyInt(-101), v);
            }

            {
                var v = new BigInteger(-100);
                Assert.AreEqual(new BigInteger(-100), Ops.DecreaseAndGetOriginal(ref v));
                Assert.AreEqual(new BigInteger(-101), v);
            }

            {
                var v = new MyLong(-100);
                Assert.AreSame(v, Ops.DecreaseAndGetOriginal(ref v));
                Assert.AreEqual(new MyLong(-101), v);
            }
        }

        [TestMethod]
        public void TestPositive()
        {
            Assert.AreEqual('0', Ops.Positive('0'));
            Assert.AreEqual(15, Ops.Positive(15));
            Assert.AreEqual(false, Ops.Positive(false));
            Assert.AreEqual(1.5f, Ops.Positive(1.5f));
            Assert.AreEqual((decimal)1.5, Ops.Positive((decimal)1.5));
            Assert.AreEqual("123", Ops.Positive("123"));

            {
                var val = new object();
                Assert.AreSame(val, Ops.Positive(val));
            }

            {
                Assert.AreEqual(new MyInt(15), Ops.Positive(new MyInt(15)));
                Assert.AreEqual(15, Ops.Positive<MyInt, int>(new MyInt(15)));
                Assert.ThrowsException<NotSupportedException>(() => Ops.Positive<MyInt, long>(new MyInt(15)));
            }

        }

        [TestMethod]
        public void TestNegative()
        {
            Assert.ThrowsException<NotSupportedException>(() => Ops.Negative("123"));
            Assert.AreEqual(-15, Ops.Negative(15));
            Assert.AreEqual(true, Ops.Negative(false));
            Assert.AreEqual(-1.5f, Ops.Negative(1.5f));
            Assert.AreEqual((decimal)-1.5, Ops.Negative((decimal)1.5));
            Assert.ThrowsException<NotSupportedException>(() => Ops.Negative(new object()));
            Assert.AreEqual("-15", Ops.Negative<MyInt, string>(new MyInt(15)));
            Assert.AreEqual(new BigInteger(-15), Ops.Negative(new BigInteger(15)));
        }

        [TestMethod]
        public void TestNot()
        {
            Assert.AreEqual(-15, Ops.LogicalNot(15));
            Assert.AreEqual(true, Ops.Not(false));
            Assert.AreEqual(false, Ops.Not(true));
            Assert.ThrowsException<NotSupportedException>(() => Ops.Not(new BigInteger(0)));
        }

        [TestMethod]
        public void TestComplement()
        {
            Assert.AreEqual(~15, Ops.Complement(15));
            Assert.AreEqual(true, Ops.Complement(false));
            Assert.AreEqual(false, Ops.Complement(true));
            Assert.AreEqual(~new BigInteger(15), Ops.Complement(new BigInteger(15)));
            Assert.AreEqual(~15, Ops.Complement<MyInt, int>(new MyInt(15)));
        }

        [TestMethod]
        public void TestCast()
        {
            Assert.AreEqual(5, Ops.Cast<int, int>(5));
            Assert.AreEqual(5L, Ops.Cast<int, long>(5));
            Assert.AreEqual(5, Ops.Cast<long, int>(5));
            Assert.AreEqual("abc", Ops.Cast<string, object>("abc"));

            Assert.ThrowsException<NotSupportedException>(() =>
            {
                Ops.Cast<string, long>("5");
            });

            {
                Assert.AreEqual((int)new BigInteger(12), Ops.Cast<BigInteger, int>(new BigInteger(12)));
            }
        }

    }
}
