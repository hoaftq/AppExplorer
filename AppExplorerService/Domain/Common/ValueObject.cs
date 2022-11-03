namespace Domain.Common
{
    public abstract class ValueObject<T>
        where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            if (obj is not T t)
            {
                return false;
            }

            return ValueEquals(t);
        }

        public override int GetHashCode() => GetValueHashCode();

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b) => a.Equals(b);

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b) => !(a == b);

        public abstract int GetValueHashCode();

        public abstract bool ValueEquals(T t);
    }
}
