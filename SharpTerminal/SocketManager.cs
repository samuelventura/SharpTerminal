using System;
using System.IO;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using SharpTerminal.Tools;

namespace SharpTerminal
{
	public class SocketManager: IoManager
	{
		private readonly ConcurrentQueue<byte[]> input;
        private readonly TcpClient socket;
        private readonly EndPoint endpoint;
		private readonly Sockets.Uri uri;
		private readonly Stream stream;
		private readonly Task reader;

		public SocketManager(string uris, int port)
		{
			uri = new Sockets.Uri(uris);
			input = new ConcurrentQueue<byte[]>();
			//standalone app may be closed anytime so long timeout
			socket = Sockets.ConnectWithTimeout(uri.HostOrIp, port, 1000);
			if ("tcp" == uri.Protocol) stream = socket.GetStream();
			if ("ssl" == uri.Protocol) stream = Sockets.SslWithTimeout(socket, 1000);
			endpoint = socket.Client.RemoteEndPoint;
            socket.SendTimeout = 1000;
			
			reader = Task.Factory.StartNew(ReadLoop, TaskCreationOptions.LongRunning);
		}
		
		public void Dispose()
		{
			Disposer.Dispose(socket);
			Disposer.Dispose(stream);
			Disposer.Dispose(reader);
        }

        public string Name
        {
            get { return endpoint.ToString(); }
        }

        public byte[] Read()
        {
            if (input.TryDequeue(out byte[] data))
            {
                if (data.Length == 0) Thrower.Throw("Socket EOF");
                return data;
            }
            return null;
        }

        public void Write(byte[] bytes)
		{
			stream.Write(bytes, 0, bytes.Length);
		}
		
		private void ReadLoop()
		{
            using (var disposer = new Disposer())
            {
                disposer.Add(socket);
                disposer.Add(() => { input.Enqueue(new byte[] { }); });

                var bytes = new byte[4096];

				while(true)
				{
					var count = stream.Read(bytes, 0, bytes.Length);
                    if (count <= 0) return;
					var data = new byte[count];
					Array.Copy(bytes, data, count);
					input.Enqueue(data);
				}			
			}
		}
	}
}
