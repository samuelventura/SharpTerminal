
using System;
using System.Net.Sockets;
using SharpTools;

namespace SharpTerminal
{
	public class SocketManager: IoManager
	{
		private readonly TcpClient socket;
		private readonly Readline readline;
		
		public SocketManager(string host, int port, Readline readline)
		{
			this.readline = readline;
			//standalone app may be closed anytime so long timeout
			socket = Tcp.ConnectWithTimeout(host, port, 1000);
			socket.SendTimeout = 1000;
		}
		
		public void Dispose()
		{
			Disposer.Dispose(socket);
		}
		
		public void Read()
		{
			var stream = socket.GetStream();
			if (socket.Available > 0) {
				var bytes = new byte[socket.Available];
				stream.Read(bytes, 0, bytes.Length);
				readline.Append(bytes);
			}
		}
		
		public void Write(byte[] bytes)
		{
			var stream = socket.GetStream();
			stream.Write(bytes, 0, bytes.Length);
		}
	}
}
