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

        public void Read()
		{
			
		}
		
		public void Write(byte[] bytes)
		{
			
		}
	}
}
