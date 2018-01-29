using System;

namespace SharpTerminal
{
	public interface IoManager: IDisposable
	{
		void Read();
		void Write(byte[] bytes);

        string Name { get; }
	}
}
