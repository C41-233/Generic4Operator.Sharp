using System;

namespace Test.Types
{
    public class MyLong : IEquatable<MyLong>
    {

        private readonly long value;

        public MyLong(long value)
        {
            this.value = value;
        }

        public static MyLong operator ++(MyLong value)
        {
            return new MyLong(value.value + 1);
        }

        public static MyLong operator --(MyLong value)
        {
            return new MyLong(value.value - 1);
        }

        public static implicit operator MyLong(long value)
        {
            return new MyLong(value);
        }

        public static implicit operator Derive(MyLong value)
        {
            return new Derive();
        }

        public bool Equals(MyLong other)
        {
            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            var l = obj as MyLong;
            if (l != null)
            {
                return Equals(l);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

    }

}
