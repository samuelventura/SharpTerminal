using System;

namespace SharpTerminal
{
	public interface IoManager: IDisposable
	{
        byte[] Read();
		void Write(byte[] bytes);
        string Name { get; }
	}
}
