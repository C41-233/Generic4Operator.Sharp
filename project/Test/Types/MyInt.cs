using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Local
namespace Test.Types
{

    public struct MyInt : IEquatable<MyInt>
    {

        private readonly int value;

        public MyInt(int value)
        {
            this.value = value;
        }

        public bool Equals(MyInt other)
        {
            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (obj is MyInt)
            {
                return Equals((MyInt) obj);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return value;
        }

        public static bool operator ==(MyInt left, MyInt right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MyInt left, MyInt right)
        {
            return !left.Equals(right);
        }

        public static MyInt operator +(MyInt left, MyInt right)
        {
            return new MyInt(left.value + right.value);
        }

        public static MyInt operator -(MyInt left, MyInt right)
        {
            return new MyInt(left.value - right.value);
        }

        public static MyInt operator ++(MyInt val)
        {
            return new MyInt(val.value + 1);
        }

        public static MyInt operator --(MyInt val)
        {
            return new MyInt(val.value - 1);
        }

        public static int operator +(MyInt val)
        {
            return val.value;
        }

        public static string operator -(MyInt val)
        {
            return "-" + val.value;
        }

        private int this[int offset] => value + offset;

        public long this[int offset1, long offset2] => value + offset1 + offset2;

        public static int operator +(MyInt left, List<int> right)
        {
            var sum = left.value;
            foreach (var v in right)
            {
                sum += v;
            }
            return sum;
        }
    }

}
