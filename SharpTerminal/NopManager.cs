using System;

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
            return null;
		}
		
		public void Write(byte[] bytes)
		{
			
		}
	}
}
