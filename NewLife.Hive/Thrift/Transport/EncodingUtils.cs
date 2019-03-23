using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NewLife.Thrift.Transport
{
    public static class EncodingUtils
    {
        public static void encodeBigEndian(Int32 integer, Byte[] buf)
        {
            encodeBigEndian(integer, buf, 0);
        }

        public static void encodeBigEndian(Int32 integer, Byte[] buf, Int32 offset)
        {
            buf[offset] = (Byte)(0xff & (integer >> 24));
            buf[offset + 1] = (Byte)(0xff & (integer >> 16));
            buf[offset + 2] = (Byte)(0xff & (integer >> 8));
            buf[offset + 3] = (Byte)(0xff & (integer));
        }

        public static Int32 decodeBigEndian(Byte[] buf)
        {
            return decodeBigEndian(buf, 0);
        }

        public static Int32 decodeBigEndian(Byte[] buf, Int32 offset)
        {
            return ((buf[offset] & 0xff) << 24) | ((buf[offset + 1] & 0xff) << 16)
                | ((buf[offset + 2] & 0xff) << 8) | ((buf[offset + 3] & 0xff));
        }

        public static void encodeFrameSize(Int32 frameSize, Byte[] buf)
        {
            buf[0] = (Byte)(0xff & (frameSize >> 24));
            buf[1] = (Byte)(0xff & (frameSize >> 16));
            buf[2] = (Byte)(0xff & (frameSize >> 8));
            buf[3] = (Byte)(0xff & (frameSize));
        }

        public static Int32 decodeFrameSize(Byte[] buf)
        {
            return
              ((buf[0] & 0xff) << 24) |
              ((buf[1] & 0xff) << 16) |
              ((buf[2] & 0xff) << 8) |
              ((buf[3] & 0xff));
        }
    }
}

namespace NewLife.Hive2
{
    public static class Utils
    {
        public static Boolean IsEmpty(this IEnumerable enumerable)
        {
            var enumerator = enumerable != null ? enumerable.GetEnumerator() : null;
            return enumerator == null || !enumerator.MoveNext();
        }

        public static IEnumerable<List<T>> SplitByCount<T>(this IEnumerable<T> list, Int32 count)
        {
            if (list == null || count == 0) throw new ArgumentNullException("list can't be null or count can't be 0");
            var sendCount = 0;
            List<T> result = null;
            while (true)
            {
                result = list.Skip(sendCount).Take(count).ToList();
                if (result.IsEmpty())
                    break;
                sendCount += count;
                yield return result;
            }
        }
    }
}