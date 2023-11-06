using System.Collections;

namespace Mi_Labs_2
{
    public sealed class Repository<T> : ICollection<T>
    {
        private readonly List<T> items = new();

        public int Count => items.Count;

        public bool IsReadOnly { get; } = false;

        public delegate bool Criteria(T item);

        public IEnumerable<T> Find(Criteria criteria) => items.Where(item => criteria(item));

        public void Add(T item) => items.Add(item);

        public void Clear() => items.Clear();

        public bool Contains(T item) => items.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => Array.Copy(items.ToArray(), array, array.Length);

        public bool Remove(T item) => items.Remove(item);

        public IEnumerator<T> GetEnumerator() => items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}