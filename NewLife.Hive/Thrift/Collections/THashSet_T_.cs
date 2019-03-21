using System;
using System.Collections;
using System.Collections.Generic;

namespace Thrift.Collections
{
    public class THashSet<T> : ICollection<T>, IEnumerable<T>, IEnumerable
    {
        private readonly HashSet<T> _set;

        public Int32 Count => _set.Count;

        public Boolean IsReadOnly => false;

        public THashSet()
        {
        }

        public void Add(T item) => _set.Add(item);

        public void Clear() => _set.Clear();

        public Boolean Contains(T item) => _set.Contains(item);

        public void CopyTo(T[] array, Int32 arrayIndex) => _set.CopyTo(array, arrayIndex);

        public IEnumerator GetEnumerator() => _set.GetEnumerator();

        public Boolean Remove(T item) => _set.Remove(item);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => ((IEnumerable<T>)_set).GetEnumerator();
    }
}