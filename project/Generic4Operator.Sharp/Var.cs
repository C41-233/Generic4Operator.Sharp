namespace Generic4Operator
{
    public struct Var<E>
    {

        public E Value { get; }

        public Var(E value)
        {
            Value = value;
        }

        public static implicit operator E(Var<E> val) => val.Value;

        public static implicit operator Var<E>(E val) => new Var<E>(val);

        public R Index<I, R>(I index) => Ops.Index<E, I, R>(Value, index);

        public static Var<E> operator ++(Var<E> val) => Ops.Increase(val.Value);

        public static Var<E> operator --(Var<E> val) => Ops.Decrease(val.Value);

        public static Var<E> operator +(Var<E> val) => Ops.Positive(val.Value);

        public static Var<E> operator +(Var<E> left, Var<E> right) => Ops.Add(left.Value, right.Value);

        public static Var<E> operator -(Var<E> value) => Ops.Negative(value.Value);

        public static Var<E> operator -(Var<E> left, Var<E> right) => Ops.Subtract(left.Value, right.Value);

        public static Var<E> operator *(Var<E> left, Var<E> right) => Ops.Multiply(left.Value, right.Value);

        public static Var<E> operator /(Var<E> left, Var<E> right) => Ops.Divide(left.Value, right.Value);

        public static Var<E> operator !(Var<E> value) => Ops.LogicalNot(value.Value);

        public static Var<E> operator ~(Var<E> value) => Ops.Complement(value.Value);

        public Var<T> Cast<T>() => Ops.Cast<E, T>(Value);

        public static E Zero => Ops.ZeroValue<E>();

    }
}
