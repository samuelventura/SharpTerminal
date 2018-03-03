using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace SharpTerminal.Tools
{
    public class Disposer : IDisposable
    {
        public static void Dispose(object any)
        {
            IgnoreException(() =>
            {
                if (any is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            });
        }

        // SerialPort, Socket, TcpClient, Streams, Writers, Readers, ...
        public static void Dispose(IDisposable disposable)
        {
            IgnoreException(() => { disposable?.Dispose(); });
        }

        // TcpListener
        public static void Close(TcpListener closeable)
        {
            IgnoreException(() => { closeable?.Stop(); });
        }

        public static void IgnoreException(Action action, Action<Exception> catcher = null)
        {
            try { action?.Invoke(); }
            catch (Exception ex)
            {
                if (catcher != null) IgnoreException(() => { catcher(ex); });
            }
        }

        private readonly Stack<Action> actions;

        public Disposer()
        {
            this.actions = new Stack<Action>();
        }

        public void Add(IDisposable disposable)
        {
            actions.Push(() => {
                disposable?.Dispose();
            });
        }

        public void Add(Action action)
        {
            actions.Push(action);
        }

        public void Dispose()
        {
            while (actions.Count > 0)
            {
                IgnoreException(actions.Pop());
            }
        }
    }
}