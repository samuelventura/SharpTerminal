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
		private readonly Task accepter;
		private readonly Readline readline;
        private readonly EndPoint endpoint;
		
		private TcpListener listener;
		
		public ListenManager(string ip, int port, Readline readline, IRunner runner)
		{
			this.readline = readline;
			
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
		}

        public string Name
        {
            get { return endpoint.ToString(); }
        }
		
		public void Read()
		{
			//newer versions have the Active property
			if (listener == null) throw new Exception("Closed");
            if (input.TryDequeue(out byte[] data))
            {
                readline.Append(data);
            }
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
			disposer.Add(()=> {listener = null;});
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
					//read/write timeout would break blocking access
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
