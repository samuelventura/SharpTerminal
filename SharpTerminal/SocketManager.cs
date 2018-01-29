using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using SharpTerminal.Tools;

namespace SharpTerminal
{
	public class SocketManager: IoManager
	{
		private readonly ConcurrentQueue<byte[]> queue;
		private readonly TcpClient socket;
		private readonly Readline readline;
        private readonly EndPoint endpoint;
        private readonly Task reader;
		
		public SocketManager(string host, int port, Readline readline)
		{
			this.readline = readline;
			
			queue = new ConcurrentQueue<byte[]>();
			//standalone app may be closed anytime so long timeout
			socket = Sockets.ConnectWithTimeout(host, port, 1000);
            endpoint = socket.Client.RemoteEndPoint;
            socket.SendTimeout = 1000;
			
			reader = Task.Factory.StartNew(ReadLoop, TaskCreationOptions.LongRunning);
		}
		
		public void Dispose()
		{
			Disposer.Dispose(socket);
        }

        public string Name
        {
            get { return endpoint.ToString(); }
        }

        public void Read()
		{
			if (!socket.Connected) throw new Exception("Closed");
			if (queue.TryDequeue(out var data)) {
				readline.Append(data);
			}
		}
		
		public void Write(byte[] bytes)
		{
			var stream = socket.GetStream();
			stream.Write(bytes, 0, bytes.Length);
		}
		
		private void ReadLoop()
		{
			using (socket)
			{
				var bytes = new byte[4096];
				while(true)
				{
					//read/write timeout would break blocking access
					var count = socket.GetStream().Read(bytes, 0, bytes.Length);
					if (count <= 0) return;
					var data = new byte[count];
					Array.Copy(bytes, data, count);
					queue.Enqueue(data);
				}			
			}
		}
	}
}
