using System.Net.Sockets;

namespace SharpTerminal.Tools
{
    public static class Sockets
    {
        public static TcpClient ConnectWithTimeout(string ip, int port, int timeout)
        {
            var socket = new TcpClient();
            var result = socket.BeginConnect(ip, port, null, null);
            if (!result.AsyncWaitHandle.WaitOne(timeout, true))
            {
                Disposer.Dispose(socket);
                Thrower.Throw("Timeout connecting to {0}:{1}", ip, port);
            }
            socket.EndConnect(result);
            return socket;
        }
    }
}
