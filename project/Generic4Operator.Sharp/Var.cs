namespace Generic4Operator
{
    public struct Var<E>
    {

        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private E value;

        public Var(E value)
        {
            this.value = value;
        }

        public static implicit operator E(Var<E> val)
        {
            return val.value;
        }

        public static implicit operator Var<E>(E val)
        {
            return new Var<E>(val);
        }

        public static Var<E> operator ++(Var<E> val)
        {
            return Ops.Increase(val.value);
        }

        public static Var<E> operator +(Var<E> left, Var<E> right)
        {
            return Ops.Add(left.value, right.value);
        }

        public static Var<E> operator -(Var<E> left, Var<E> right)
        {
            return Ops.Subtract(left.value, right.value);
        }

    }
}
