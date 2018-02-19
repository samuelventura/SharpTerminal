using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.IO.Ports;
using SharpTerminal.Tools;

namespace SharpTerminal
{
	public class SerialManager: IoManager
    {
        private readonly ConcurrentQueue<byte[]> queue;
        private readonly SerialPort serial;
		private readonly Readline readline;
        private readonly Task reader;

        public SerialManager(string name, SerialSettings settings, Readline readline)
		{
			this.readline = readline;

            queue = new ConcurrentQueue<byte[]>();
            serial = new SerialPort(name);
			settings.CopyTo(serial);
			serial.Open();

            reader = Task.Factory.StartNew(ReadLoop, TaskCreationOptions.LongRunning);
        }
		
		public void Dispose()
		{
			Disposer.Dispose(serial);
            Disposer.Dispose(reader);
        }

        public string Name
        {
            get { return string.Format("{0}@{1}", serial.PortName, serial.BaudRate); }
        }

        public void Read()
		{
            //confirmed that unplugging an usb serial adapter excepts on BytesToRead access
            while (queue.TryDequeue(out var data))
            {
                if (data.Length == 0) Thrower.Throw("Port EOF");
                readline.Append(data);
            }
        }

        public void Write(byte[] bytes)
		{
			serial.Write(bytes, 0, bytes.Length);
        }

        private void ReadLoop()
        {
            using (var disposer = new Disposer())
            {
                disposer.Add(serial);
                disposer.Add(()=> { queue.Enqueue(new byte[] { }); });

                var bytes = new byte[4096];

                while (true)
                {
                    var count = serial.Read(bytes, 0, bytes.Length);
                    if (count <= 0) return;
                    var data = new byte[count];
                    Array.Copy(bytes, data, count);
                    queue.Enqueue(data);
                }
            }
        }
    }
}
