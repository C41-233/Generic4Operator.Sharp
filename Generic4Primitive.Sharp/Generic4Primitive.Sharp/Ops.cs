namespace Generic4Primitive
{
    public static class Ops
    {

        public static T Add<T>(T a, T b) => Ops<T>.Default.Add(a, b);

        public static int AddToInt<T>(T a, T b) => Ops<T>.Default.AddToInt(a, b);

        public static T Subtract<T>(T a, T b) => Ops<T>.Default.Subtract(a, b);

        public static int SubtractToInt<T>(T a, T b) => Ops<T>.Default.SubtractToInt(a, b);

        public static T Increase<T>(T value) => Ops<T>.Default.Increase(value);

        public static T IncreaseAndGet<T>(ref T value) => Ops<T>.Default.IncreaseAndGet(ref value);

        public static T IncreaseAndGetOriginal<T>(ref T value) => Ops<T>.Default.IncreaseAndGetOriginal(ref value);

        public static int ToInt<T>(T value) => Ops<T>.Default.ToInt(value);

    }
}
