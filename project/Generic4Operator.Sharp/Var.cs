using System.Runtime.InteropServices.ComTypes;

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

        public static Var<E> operator +(Var<E> var1, Var<E> var2)
        {
            return Ops.Add(var1.value, var2.value);
        }

        public static Var<E> operator -(Var<E> var1, Var<E> var2)
        {
            return Ops.Subtract(var1.value, var2.value);
        }

        public static implicit operator E(Var<E> value)
        {
            return value.value;
        }

        public static implicit operator Var<E>(E value)
        {
            return new Var<E>(value);
        }

    }
}
