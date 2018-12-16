using System.Numerics;
using Generic4Operator;

namespace TestMain
{
    public static class Measure
    {

        public static int Test_int(int a, int b, int c)
        {
            return a + b - c;
        }

        public static BigInteger Test_BigInteger(BigInteger a, BigInteger b, BigInteger c)
        {
            return a + b - c;
        }

        public static T Test_dynamic<T>(T value1, T value2, T value3)
        {
            dynamic a = value1;
            dynamic b = value2;
            dynamic c = value3;
            return a + b - c;
        }

        public static T Test_Ops<T>(T a, T b, T c)
        {
            return Ops.Subtract(Ops.Add(a, b), c);
        }

        public static T Test_Var<T>(T value1, T value2, T value3)
        {
            Var<T> a = value1;
            Var<T> b = value2;
            Var<T> c = value3;
            return a + b - c;
        }

    }

}
