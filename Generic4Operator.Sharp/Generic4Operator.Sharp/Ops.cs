namespace Generic4Operator
{
    public static class Ops
    {

        public static T Positive<T>(T value) => Ops<T>.Instance.Positive(value);

        public static T Negative<T>(T value) => Ops<T>.Instance.Negative(value);

        public static T Add<T>(T a, T b) => Ops<T>.Instance.Add(a, b);

        public static T Subtract<T>(T a, T b) => Ops<T>.Instance.Subtract(a, b);

        public static T Increase<T>(T value) => Ops<T>.Instance.Increase(value);

        public static T IncreaseAndGet<T>(ref T value) => Ops<T>.Instance.IncreaseAndGet(ref value);

        public static T IncreaseAndGetOriginal<T>(ref T value) => Ops<T>.Instance.IncreaseAndGetOriginal(ref value);

        public static T Decrease<T>(T value) => Ops<T>.Instance.Decrease(value);

        public static T DecreaseAndGet<T>(ref T value) => Ops<T>.Instance.DecreaseAndGet(ref value);

        public static T DecreaseAndGetOriginal<T>(ref T value) => Ops<T>.Instance.DecreaseAndGetOriginal(ref value);

        public static T Not<T>(T value) => Ops<T>.Instance.Not(value);

        public static int ToInt<T>(T value) => Ops<T>.Instance.ToInt(value);

        public static T Default<T>() => Ops<T>.Instance.Default;

    }
}
