
using System;
using System.Net;
using System.Net.Sockets;
using SharpTools;

namespace SharpTerminal
{
	public class ListenManager: IoManager
	{
		private readonly TcpListener listener;
		private readonly Readline readline;
		private readonly IRunner runner;
		private readonly IRunner catcher;
		private TcpClient socket;
		
		public ListenManager(string ip, int port, Readline readline, IRunner runner)
		{
			this.readline = readline;
			this.runner = runner;
			this.catcher = new WrapRunner((ex) => NullSocket());
			this.listener = new TcpListener(IPAddress.Parse(ip), port);
			this.listener.Start();
			//exception below would leake listener
			//wont catch since there is no way to test it
			this.listener.BeginAcceptTcpClient(AcceptCallback, null);
		}
		
		public void Dispose()
		{
			Disposer.Close(listener);
			NullSocket();
		}
		
		public void Read()
		{
			if (socket != null) {
				catcher.Run(() => {
					var stream = socket.GetStream();
					if (socket.Available > 0) {
						var bytes = new byte[socket.Available];
						stream.Read(bytes, 0, bytes.Length);
						readline.Append(bytes);
					}
				});
			}
		}
		
		public void Write(byte[] bytes)
		{
			if (socket != null) {
				catcher.Run(() => {
					var stream = socket.GetStream();
					stream.Write(bytes, 0, bytes.Length);
				});
			}
		}
		
		private void NullSocket()
		{
			Disposer.Dispose(socket);
			socket = null;
		}
		
		private void AcceptCallback(IAsyncResult result)
		{
			runner.Run(() => {
				NullSocket();
				if (listener.Server.IsBound) {
					//exception below would leake listener
					//wont catch since there is no way to test it
					socket = listener.EndAcceptTcpClient(result);
					listener.BeginAcceptTcpClient(AcceptCallback, null);
				}
			});
		}
	}
}
