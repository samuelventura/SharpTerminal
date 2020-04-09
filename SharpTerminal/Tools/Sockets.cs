using System.Net.Sockets;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace SharpTerminal.Tools
{
    public static class Sockets
    {
        public class Uri
        {
            public string Protocol;
            public string HostOrIp;

            public Uri(string uri)
            {
                if (!uri.Contains(":")) uri = $"tcp:{uri}";
                var parts = uri.Split(new char[] { ':' }, 2);
                Protocol = parts[0];
                HostOrIp = parts[1];
                if (Protocol != "tcp" && Protocol != "ssl") throw Thrower.Make("Invalid protocol {0}", Protocol);
            }
        }

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

        public static SslStream SslWithTimeout(TcpClient client, int timeout)
        {
            var endpoint = client.Client.RemoteEndPoint;
            var stream = new SslStream(client.GetStream(), false, AcceptAnyCertificate);
            var result = stream.BeginAuthenticateAsClient(string.Empty, null, null);
            if (!result.AsyncWaitHandle.WaitOne(timeout, true))
            {
                Disposer.Dispose(stream);
                Disposer.Dispose(client);
                Thrower.Throw("Timeout authenticating to {0}", endpoint);
            }
            return stream;
        }

        public static bool AcceptAnyCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
