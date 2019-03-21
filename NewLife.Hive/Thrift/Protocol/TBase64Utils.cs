using System;

namespace Thrift.Protocol
{
	internal static class TBase64Utils
	{
		internal const string ENCODE_TABLE = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

		private static int[] DECODE_TABLE;

		static TBase64Utils()
		{
			TBase64Utils.DECODE_TABLE = new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 62, -1, -1, -1, 63, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, -1, -1, -1, -1, -1, -1, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, -1, -1, -1, -1, -1, -1, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
		}

		internal static void decode(byte[] src, int srcOff, int len, byte[] dst, int dstOff)
		{
			dst[dstOff] = (byte)(TBase64Utils.DECODE_TABLE[src[srcOff] & 255] << 2 | TBase64Utils.DECODE_TABLE[src[srcOff + 1] & 255] >> 4);
			if (len > 2)
			{
				dst[dstOff + 1] = (byte)(TBase64Utils.DECODE_TABLE[src[srcOff + 1] & 255] << 4 & 240 | TBase64Utils.DECODE_TABLE[src[srcOff + 2] & 255] >> 2);
				if (len > 3)
				{
					dst[dstOff + 2] = (byte)(TBase64Utils.DECODE_TABLE[src[srcOff + 2] & 255] << 6 & 192 | TBase64Utils.DECODE_TABLE[src[srcOff + 3] & 255]);
				}
			}
		}

		internal static void encode(byte[] src, int srcOff, int len, byte[] dst, int dstOff)
		{
			dst[dstOff] = (byte)"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"[src[srcOff] >> 2 & 63];
			if (len != 3)
			{
				if (len != 2)
				{
					dst[dstOff + 1] = (byte)"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"[src[srcOff] << 4 & 48];
					return;
				}
				dst[dstOff + 1] = (byte)"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"[src[srcOff] << 4 & 48 | src[srcOff + 1] >> 4 & 15];
				dst[dstOff + 2] = (byte)"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"[src[srcOff + 1] << 2 & 60];
				return;
			}
			dst[dstOff + 1] = (byte)"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"[src[srcOff] << 4 & 48 | src[srcOff + 1] >> 4 & 15];
			dst[dstOff + 2] = (byte)"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"[src[srcOff + 1] << 2 & 60 | src[srcOff + 2] >> 6 & 3];
			dst[dstOff + 3] = (byte)"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"[src[srcOff + 2] & 63];
		}
	}
}