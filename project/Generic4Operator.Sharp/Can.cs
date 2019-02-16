using Generic4Operator.Operator;

namespace Generic4Operator
{

    public static class Can<T>
    {
        public static bool Add => Addition<T, T, T>.Supported;
        public static bool Divide => Division<T, T, T>.Supported;
        public static bool Decrease => Decrement<T, T>.Supported;

    }

    public static class Can<T, R>
    {
        public static bool Decrease => Decrement<T, R>.Supported;
        public static bool Cast => Cast<T, R>.Supported;
        public static bool ImplicitCast => ImplicitCast<T, R>.Supported;

    }

    public static class Can<T1, T2, R>
    {

        public static bool Add => Addition<T1, T2, R>.Supported;
        public static bool Divide => Division<T1, T2, R>.Supported;

    }
}
