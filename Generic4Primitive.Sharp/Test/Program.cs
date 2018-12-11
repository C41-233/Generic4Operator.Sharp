using System;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using Generic4Primitive;

namespace Test
{

    public struct MyInt
    {
        private readonly int value;

        public MyInt(int value)
        {
            this.value = value;
        }

        public static MyInt operator +(MyInt a, MyInt b)
        {
            return new MyInt(a.value + b.value);
        }

        private static MyInt op_Add(MyInt a, MyInt b)
        {
            return new MyInt(a.value + b.value);
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
            Console.WriteLine(Ops.IncreaseAndGetOriginal(ref a));
            var x = "123";
            var y = "321";
            Console.WriteLine(x + y);
            Console.WriteLine(Ops.Add("123", "321"));
        }
    }
}
