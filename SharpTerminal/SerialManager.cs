using System;
using System.IO.Ports;
using SharpTools;
using SharpToolsUI;

namespace SharpTerminal
{
	public class SerialManager: IoManager
	{
		private readonly SerialPort serialPort;
		private readonly Readline readline;
		
		public SerialManager(string name, SerialSettings settings, Readline readline)
		{
			this.readline = readline;
			serialPort = new SerialPort(name);
			settings.CopyTo(serialPort);
			serialPort.Open();
		}
		
		public void Dispose()
		{
			Disposer.Dispose(serialPort);
		}
		
		public void Read()
		{
			//confirmed that unplugging an usb serial adapter excepts on BytesToRead access
			if (serialPort.BytesToRead > 0) {
				var bytes = new byte[serialPort.BytesToRead];
				serialPort.Read(bytes, 0, bytes.Length);
				readline.Append(bytes);
			}
		}
		
		public void Write(byte[] bytes)
		{
			serialPort.Write(bytes, 0, bytes.Length);
		}
	}
}
