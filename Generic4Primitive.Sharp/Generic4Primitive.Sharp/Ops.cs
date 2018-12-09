namespace Generic4Primitive
{
    public static class Ops
    {

        static Ops()
        {
            Ops<byte>.Add = (a, b) => (byte) (a + b);
            Ops<byte>.AddToInt = (a, b) => a + b;
            Ops<byte>.Subtract = (a, b) => (byte) (a - b);
            Ops<byte>.SubtractToInt = (a, b) => a - b;
            Ops<byte>.Increase = (ref byte a) => ++a;
            Ops<byte>.IncreaseAndGetOriginal = (ref byte a) => a++;

            Ops<sbyte>.Add = (a, b) => (sbyte)(a + b);
            Ops<sbyte>.AddToInt = (a, b) => a + b;
            Ops<sbyte>.Subtract = (a, b) => (sbyte) (a - b);
            Ops<sbyte>.SubtractToInt = (a, b) => a - b;
            Ops<sbyte>.Increase = (ref sbyte a) => ++a;
            Ops<sbyte>.IncreaseAndGetOriginal = (ref sbyte a) => a++;

            Ops<char>.Add = (a, b) => (char) (a + b);
            Ops<char>.AddToInt = (a, b) => a + b;
            Ops<char>.Subtract = (a, b) => (char) (a - b);
            Ops<char>.SubtractToInt = (a, b) => a - b;
            Ops<char>.Increase = (ref char a) => ++a;
            Ops<char>.IncreaseAndGetOriginal = (ref char a) => a++;

            Ops<short>.Add = (a, b) => (short) (a + b);
            Ops<short>.AddToInt = (a, b) => a + b;
            Ops<short>.Subtract = (a, b) => (short) (a - b);
            Ops<short>.SubtractToInt = (a, b) => a - b;
            Ops<short>.Increase = (ref short a) => ++a;
            Ops<short>.IncreaseAndGetOriginal = (ref short a) => a++;

            Ops<ushort>.Add = (a, b) => (ushort) (a + b);
            Ops<ushort>.AddToInt = (a, b) => a + b;
            Ops<ushort>.Subtract = (a, b) => (ushort) (a - b);
            Ops<ushort>.SubtractToInt = (a, b) => a - b;
            Ops<ushort>.Increase = (ref ushort a) => ++a;
            Ops<ushort>.IncreaseAndGetOriginal = (ref ushort a) => a++;

            Ops<int>.Add = (a, b) => a + b;
            Ops<int>.AddToInt = (a, b) => a + b;
            Ops<int>.Subtract = (a, b) => a - b;
            Ops<int>.SubtractToInt = (a, b) => a - b;
            Ops<int>.Increase = (ref int a) => ++a;
            Ops<int>.IncreaseAndGetOriginal = (ref int a) => a++;

            Ops<uint>.Add = (a, b) => a + b;
            Ops<uint>.AddToInt = (a, b) => (int) (a + b);
            Ops<uint>.Subtract = (a, b) => a - b;
            Ops<uint>.SubtractToInt = (a, b) => (int) (a - b);
            Ops<uint>.Increase = (ref uint a) => ++a;
            Ops<uint>.IncreaseAndGetOriginal = (ref uint a) => a++;

            Ops<long>.Add = (a, b) => a + b;
            Ops<long>.AddToInt = (a, b) => (int) (a + b);
            Ops<long>.Subtract = (a, b) => a - b;
            Ops<long>.SubtractToInt = (a, b) => (int) (a - b);
            Ops<long>.Increase = (ref long a) => ++a;
            Ops<long>.IncreaseAndGetOriginal = (ref long a) => a++;

            Ops<ulong>.Add = (a, b) => a + b;
            Ops<ulong>.AddToInt = (a, b) => (int) (a + b);
            Ops<ulong>.Subtract = (a, b) => a - b;
            Ops<ulong>.SubtractToInt = (a, b) => (int) (a - b);
            Ops<ulong>.Increase = (ref ulong a) => ++a;
            Ops<ulong>.IncreaseAndGetOriginal = (ref ulong a) => a++;

            Ops<float>.Add = (a, b) => a + b;
            Ops<float>.AddToInt = (a, b) => (int) (a + b);
            Ops<float>.Subtract = (a, b) => a - b;
            Ops<float>.SubtractToInt = (a, b) => (int) (a - b);
            Ops<float>.Increase = (ref float a) => ++a;
            Ops<float>.IncreaseAndGetOriginal = (ref float a) => a++;

            Ops<double>.Add = (a, b) => a + b;
            Ops<double>.AddToInt = (a, b) => (int) (a + b);
            Ops<double>.Subtract = (a, b) => a - b;
            Ops<double>.SubtractToInt = (a, b) => (int) (a - b);
            Ops<double>.Increase = (ref double a) => ++a;
            Ops<double>.IncreaseAndGetOriginal = (ref double a) => a++;

            Ops<decimal>.Add = (a, b) => a + b;
            Ops<decimal>.AddToInt = (a, b) => (int) (a + b);
            Ops<decimal>.Subtract = (a, b) => a - b;
            Ops<decimal>.SubtractToInt = (a, b) => (int) (a - b);
            Ops<decimal>.Increase = (ref decimal a) => ++a;
            Ops<decimal>.IncreaseAndGetOriginal = (ref decimal a) => a++;
        }

        public static T Add<T>(T a, T b) where T : struct => Ops<T>.Add(a, b);

        public static int AddToInt<T>(T a, T b) where T : struct => Ops<T>.AddToInt(a, b);

        public static T Subtract<T>(T a, T b) where T : struct => Ops<T>.Subtract(a, b);

        public static int SubtractToInt<T>(T a, T b) where T : struct => Ops<T>.SubtractToInt(a, b);

        public static T Increase<T>(ref T value) where T : struct => Ops<T>.Increase(ref value);

    }
}
