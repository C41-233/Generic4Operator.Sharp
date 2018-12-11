using System;

namespace Generic4Operator
{

    internal class Ops<T>
    {

        static Ops()
        {
            Instance = (Ops<T>) OpsFactory.CreateDefault(typeof(T));
        }

        public static Ops<T> Instance { get; private set; }

        public Ops()
        {
            Positive = a => a;

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
        }

        public T Default => default(T);

        public Func<T, T> Positive;

        public Func<T, T> Negative = Throw.Value<T, T>;

        public Func<T, T, T> Add = Throw.Value<T, T, T>;

        public Func<T, T, T> Subtract = Throw.Value<T, T, T>;

        public Func<T, T> Increase = Throw.Value<T, T>;

        public ChangeDelegate<T> IncreaseAndGet;

        public ChangeDelegate<T> IncreaseAndGetOriginal;

        public Func<T, T> Decrease = Throw.Value<T, T>;

        public ChangeDelegate<T> DecreaseAndGet;

        public ChangeDelegate<T> DecreaseAndGetOriginal;

        public Func<T, T> Not;

        public Func<T, bool> ToBool = Throw.Value<T, bool>;

        public Func<T, int> ToInt = Throw.Value<T, int>;

    }

    internal delegate T ChangeDelegate<T>(ref T value);

}
