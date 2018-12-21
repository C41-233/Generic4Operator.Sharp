namespace Generic4Operator
{
    public struct Var<E>
    {

        public E Value { get; }

        public Var(E value)
        {
            Value = value;
        }

        public static implicit operator E(Var<E> val)
        {
            return val.Value;
        }

        public static implicit operator Var<E>(E val)
        {
            return new Var<E>(val);
        }

        public R Index<I, R>(I index)
        {
            return Ops.Index<E, I, R>(Value, index);
        }

        public static Var<E> operator ++(Var<E> val)
        {
            return Ops.Increase(val.Value);
        }

        public static Var<E> operator --(Var<E> val)
        {
            return Ops.Decrease(val.Value);
        }

        public static Var<E> operator +(Var<E> val)
        {
            return Ops.Positive(val.Value);
        }

        public static Var<E> operator +(Var<E> left, Var<E> right)
        {
            return Ops.Add(left.Value, right.Value);
        }

        public static Var<E> operator -(Var<E> value)
        {
            return Ops.Negative(value.Value);
        }

        public static Var<E> operator -(Var<E> left, Var<E> right)
        {
            return Ops.Subtract(left.Value, right.Value);
        }

        public static E Zero => Ops.ZeroValue<E>();

    }
}
