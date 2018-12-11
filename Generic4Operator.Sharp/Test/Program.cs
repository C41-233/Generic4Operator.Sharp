using System;
using System.Numerics;
using Generic4Operator;

namespace Test
{

    public struct MyInt
    {
        private readonly int value;

        public MyInt(int value)
        {
            this.value = value;
        }

        public static MyInt operator +(MyInt a)
        {
            return new MyInt(a.value-1);
        }

        public static bool operator !(MyInt a)
        {
            return a.value > 0;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }

    class Program
    {

        private static Func<int, int, int> func1 = Do;
        private static Func<int, int, int> func2;

        private static int Do(int a, int b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(Ops.Add(new MyInt(1), new MyInt(2)));
            var a = new BigInteger(1);
            Console.WriteLine(Ops.Positive(new MyInt(1)));
        }
    }
}
