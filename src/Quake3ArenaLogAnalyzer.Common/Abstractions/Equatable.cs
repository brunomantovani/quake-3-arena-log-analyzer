namespace Quake3ArenaLogAnalyzer.Common.Abstractions
{
    public abstract class Equatable<T>
        : IEquatable<T>
    {
        protected static bool EqualOperator(Equatable<T> left, Equatable<T> right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }
            return ReferenceEquals(left, right) || left!.Equals(right!);
        }

        protected static bool NotEqualOperator(Equatable<T> left, Equatable<T> right)
        {
            return !EqualOperator(left, right);
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (Equatable<T>)obj;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        public bool Equals(T? other)
        {
            return Equals(other as object);
        }

        public static bool operator ==(Equatable<T> one, Equatable<T> two)
        {
            return EqualOperator(one, two);
        }

        public static bool operator !=(Equatable<T> one, Equatable<T> two)
        {
            return NotEqualOperator(one, two);
        }
    }
}
