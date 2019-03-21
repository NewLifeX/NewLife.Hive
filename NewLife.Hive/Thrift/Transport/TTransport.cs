using System;

namespace Thrift.Transport
{
	public abstract class TTransport : IDisposable
	{
		public abstract bool IsOpen
		{
			get;
		}

		protected TTransport()
		{
		}

		public virtual IAsyncResult BeginFlush(AsyncCallback callback, object state)
		{
			return null;
		}

		public abstract void Close();

		protected abstract void Dispose(bool disposing);

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public virtual void EndFlush(IAsyncResult asyncResult)
		{
		}

		public virtual void Flush()
		{
		}

		public abstract void Open();

		public bool Peek()
		{
			return IsOpen;
		}

		public abstract int Read(byte[] buf, int off, int len);

		public int ReadAll(byte[] buf, int off, int len)
		{
			int num = 0;
			int num1 = 0;
			while (num < len)
			{
				num1 = Read(buf, off + num, len - num);
				if (num1 <= 0)
				{
					throw new TTransportException(TTransportException.ExceptionType.EndOfFile, "Cannot read, Remote side has closed");
				}
				num = num + num1;
			}
			return num;
		}

		public virtual void Write(byte[] buf)
		{
			Write(buf, 0, (int)buf.Length);
		}

		public abstract void Write(byte[] buf, int off, int len);
	}
}