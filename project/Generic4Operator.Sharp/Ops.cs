using Generic4Operator.Operator;

namespace Generic4Operator
{
    public static class Ops
    {

        public static R Add<T1, T2, R>(T1 left, T2 right) 
            => Addition<T1, T2, R>.Invoke(left, right);

        public static T Add<T>(T left, T right) 
            => Add<T, T, T>(left, right);

        public static R Subtract<T1, T2, R>(T1 left, T2 right)
            => Subtraction<T1, T2, R>.Invoke(left, right);

        public static T Subtract<T>(T left, T right)
            => Subtract<T, T, T>(left, right);

    }
}
