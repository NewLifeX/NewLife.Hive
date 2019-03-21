using System;
using System.Collections;

namespace Thrift.Collections
{
    public class TCollections
    {
        public TCollections()
        {
        }

        public static Boolean Equals(IEnumerable first, IEnumerable second)
        {
            Boolean i;
            if (first == null && second == null)
            {
                return true;
            }
            if (first == null || second == null)
            {
                return false;
            }
            var enumerator = first.GetEnumerator();
            var enumerator1 = second.GetEnumerator();
            var flag = enumerator.MoveNext();
            for (i = enumerator1.MoveNext(); flag && i; i = enumerator1.MoveNext())
            {
                var current = enumerator.Current as IEnumerable;
                var enumerable = enumerator1.Current as IEnumerable;
                if (current == null || enumerable == null)
                {
                    if (current == null ^ enumerable == null)
                    {
                        return false;
                    }
                    if (!Object.Equals(enumerator.Current, enumerator1.Current))
                    {
                        return false;
                    }
                }
                else if (!TCollections.Equals(current, enumerable))
                {
                    return false;
                }
                flag = enumerator.MoveNext();
            }
            return flag == i;
        }

        public static Int32 GetHashCode(IEnumerable enumerable)
        {
            if (enumerable == null)
            {
                return 0;
            }
            var num = 0;
            foreach (var obj in enumerable)
            {
                var enumerable1 = obj as IEnumerable;
                num = num * 397 ^ (enumerable1 == null ? obj.GetHashCode() : TCollections.GetHashCode(enumerable1));
            }
            return num;
        }
    }
}