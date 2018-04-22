using System;
using System.Threading;

namespace SharpTerminal
{
	public class NopManager: IoManager
	{
		public NopManager()
		{
		}
		
		public void Dispose()
		{
			
		}
        public string Name
        {
            get { return string.Empty; }
        }

        public byte[] Read()
		{
            Thread.Sleep(100);
            return null;
		}
		
		public void Write(byte[] bytes)
		{
			
		}
	}
}
