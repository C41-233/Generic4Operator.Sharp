
using Generic4Operator.Operator;

namespace Generic4Operator
{
    public static class Ops
    {

        public static R Add<T1, T2, R>(T1 left, T2 right) => Addition<T1, T2, R>.Invoke(left, right);

        public static T Add<T>(T left, T right) => Add<T, T, T>(left, right);

    }
}
