using System;

namespace Generic4Primitive
{

    internal class Ops<T>
    {

        static Ops()
        {
            Default = (Ops<T>) OpsFactory.CreateDefault(typeof(T));
        }

        public static Ops<T> Default { get; private set; }

        public Ops()
        {
            IncreaseAndGet = (ref T a) =>
            {
                a = Increase(a);
                return a;
            };
            IncreaseAndGetOriginal = (ref T a) =>
            {
                var tmp = a;
                a = Increase(a);
                return tmp;
            };

            DecreaseAndGet = (ref T a) =>
            {
                a = Decrease(a);
                return a;
            };
            DecreaseAndGetOriginal = (ref T a) =>
            {
                var tmp = a;
                a = Decrease(a);
                return tmp;
            };

            AddToInt = (a, b) => ToInt(Add(a, b));
            SubtractToInt = (a, b) => ToInt(Subtract(a, b));
        }

        public Func<T, T, T> Add = Throw.Value<T, T, T>;

        public Func<T, T, int> AddToInt;

        public Func<T, T, T> Subtract = Throw.Value<T, T, T>;

        public Func<T, T, int> SubtractToInt;

        public Func<T, T> Increase = Throw.Value<T, T>;

        public ChangeDelegate<T> IncreaseAndGet;

        public ChangeDelegate<T> IncreaseAndGetOriginal;

        public Func<T, T> Decrease = Throw.Value<T, T>;

        public ChangeDelegate<T> DecreaseAndGet;

        public ChangeDelegate<T> DecreaseAndGetOriginal;

        public Func<T, int> ToInt = Throw.Value<T, int>;

    }

    internal delegate T ChangeDelegate<T>(ref T value);

}
