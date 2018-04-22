using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using SharpTerminal.Tools;

namespace SharpTerminal
{
	public class ListenManager: IoManager
	{
		private readonly ConcurrentQueue<byte[]> input;
		private readonly ConcurrentQueue<byte[]> output;
        private readonly EndPoint endpoint;
        private readonly Task accepter;

        private TcpListener listener;
		
		public ListenManager(string ip, int port, IRunner runner)
		{
			input = new ConcurrentQueue<byte[]>();
			output = new ConcurrentQueue<byte[]>();
			listener = new TcpListener(IPAddress.Parse(ip), port);
			listener.Start();
            endpoint = listener.LocalEndpoint;

            accepter = Task.Factory.StartNew(AcceptLoop, TaskCreationOptions.LongRunning);
		}
		
		public void Dispose()
		{
			Disposer.Close(listener);
            Disposer.Dispose(accepter);
        }

        public string Name
        {
            get { return endpoint.ToString(); }
        }

        public byte[] Read()
        {
            if (input.TryDequeue(out byte[] data))
            {
                if (data.Length == 0) Thrower.Throw("Listener EOF");
                return data;
            }
            return null;
        }

        public void Write(byte[] bytes)
		{
			output.Enqueue(bytes);
		}
		
		private void AcceptLoop()
		{
			TcpClient current = null;
			Task reader = null;
			Task writer = null;
			
			var disposer = new Disposer();
			//newer versions have the Active property
			disposer.Add(()=> { input.Enqueue(new byte[] { }); });
			disposer.Add(listener.Stop);
			disposer.Add(() => Disposer.Dispose(reader));
			disposer.Add(() => Disposer.Dispose(writer));
			disposer.Add(() => Disposer.Dispose(current));
			
			using (disposer)
			{
				while(true)
				{
					var client = listener.AcceptTcpClient();
					Disposer.Dispose(current);
					Disposer.Dispose(reader);
					Disposer.Dispose(writer);
					current = client;
					ClearOutput();
					reader = Task.Factory.StartNew(()=>ReadLoop(client), TaskCreationOptions.LongRunning);
					writer = Task.Factory.StartNew(()=>WriteLoop(client), TaskCreationOptions.LongRunning);
				}
			}
		}
		
		private void WriteLoop(TcpClient socket)
		{
			using(socket)
			{
				while(socket.Connected)
				{
                    if (output.TryDequeue(out byte[] bytes))
                    {
                        var stream = socket.GetStream();
                        stream.Write(bytes, 0, bytes.Length);
                    }
                    else Thread.Sleep(10);
                }
			}
		}
		
		private void ReadLoop(TcpClient socket)
		{
			using (socket)
			{
				var bytes = new byte[4096];

				while(true)
				{
					var count = socket.GetStream().Read(bytes, 0, bytes.Length);
					if (count <= 0) return;
					var data = new byte[count];
					Array.Copy(bytes, data, count);
					input.Enqueue(data);
				}			
			}
		}
		
		private void ClearOutput()
		{
            while (output.TryDequeue(out byte[] bytes)) ;
        }
	}
}
