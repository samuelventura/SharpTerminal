using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Text;

namespace SharpTerminal
{
    /* Cases to handle
     * - In hex mode a flush is required for packets > 255 bytes
     * - In hex mode a flush is required if silence for 100ms
     * - In txt mode a flush is required for packets > 255 bytes
     */

    public class RichTextBuffer
    {
        private const int SILENCE_TO = 100;
        private const int MAX_LENGTH = 256;

        private readonly Queue<Line> lines = new Queue<Line>();
        private Line current;
        private bool readline;
        private bool hexmode;
        private bool standard;
        private byte separator;

        private string ToReadable(string prefix, byte[] bytes)
        {
            var sb = new StringBuilder();
            //sb.Append(prefix);
            foreach (var b in bytes)
            {
                var c = (char)b;
                if (Char.IsControl(c)) sb.Append(string.Format("[{0:X2}]", (int)c));
                else sb.Append(c);
            }
            return sb.ToString();
        }

        private string ToText(string prefix, byte[] bytes)
        {
            var sb = new StringBuilder();
            //sb.Append(prefix);
            foreach (var b in bytes)
            {
                var c = (char)b;
                if (Char.IsControl(c)) sb.Append(' ');
                else sb.Append(c);
            }
            return sb.ToString();
        }

        private string ToHexadecimal(string prefix, byte[] bytes)
        {
            var sb = new StringBuilder();
            //sb.Append(prefix);
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("X2"));
                sb.Append(" ");
            }
            return sb.ToString();
        }

        public void CheckSilence()
        {
            if (!current.Readline)
            {
                var ts = DateTime.Now - current.Last;

                if (ts.TotalMilliseconds > SILENCE_TO) Flush();
            }
        }

        public void Flush()
        {
            if (current != null && current.Bytes.Count > 0)
            {
                var bytes = current.Bytes.ToArray();
                current.Now = DateTime.Now;
                current.Text = ToText("< ", bytes);
                current.Readable = ToReadable("< ", bytes);
                current.Hexadecimal = ToHexadecimal("< ", bytes);
                lines.Enqueue(current);
            }

            current = new Line
            {
                Type = "input",
                Readline = readline,
                Standard = standard,
                Hexmode = hexmode,
                Separator = separator,
            };
        }

        public void Setup(bool readline, bool standard, bool hexmode, byte separator)
        {
            this.readline = readline;
            this.standard = standard;
            this.hexmode = hexmode;
            this.separator = separator;
            Flush();
        }

        public void Log(string type, string format, params object[] args)
        {
            Flush();
            var line = new Line
            {
                Now = DateTime.Now,
                Type = type,
                Readable = args.Length > 0 ? string.Format(format, args) : format
            };
            lines.Enqueue(line);
        }

        public void Output(byte[] bytes, bool text)
        {
            Flush();
            var line = new Line
            {
                Readline = text,
                Standard = standard,
                Hexmode = hexmode,
                Now = DateTime.Now,
                Type = "output",
                Text = ToText("> ", bytes),
                Readable = ToReadable("> ", bytes),
                Hexadecimal = ToHexadecimal("> ", bytes)
            };
            lines.Enqueue(line);
        }

        public void Input(byte[] bytes)
        {
            foreach(var b in bytes)
            {
                current.Bytes.Add(b);
                if (current.Readline)
                {
                    if (b == current.Separator) Flush();
                }
                if (current.Bytes.Count >= MAX_LENGTH) Flush();
            }
            current.Last = DateTime.Now;
        }

        public void Update(RichTextBox rtb)
        {
            while(lines.Count > 0)
            {
                var line = lines.Dequeue();
                var text = line.Standard ? line.Text : line.Readable; 
                var now = line.Standard && !line.Hexmode ? null as DateTime?: line.Now;
                var showhex = line.Hexmode || !line.Standard;

                var color = Color.White;
                switch (line.Type)
                {
                    case "input":
                        color = Color.DodgerBlue;
                        if (line.Readline) Add(rtb, color, now, text);
                        if (showhex) Add(rtb, line.Hexmode ? color : Color.Gray, now, line.Hexadecimal);
                        break;
                    case "output":
                        color = Color.Salmon;
                        if (line.Readline) Add(rtb, color, now, text);
                        if (showhex) Add(rtb, line.Hexmode ? color : Color.Gray, now, line.Hexadecimal);
                        break;
                    case "success":
                        color = Color.LimeGreen;
                        Add(rtb, color, now, text);
                        break;
                    case "error":
                        color = Color.OrangeRed;
                        Add(rtb, color, now, text);
                        break;
                    case "warn":
                        color = Color.Yellow;
                        Add(rtb, color, now, text);
                        break;
                }
            }
        }

        public void Add(RichTextBox rtb, Color color, DateTime? now, string line)
        {
            rtb.SelectionLength = 0; //clear selection
            rtb.SelectionStart = rtb.Text.Length;
            if (now.HasValue)
            {
                rtb.SelectionColor = Color.Gray;
                rtb.AppendText(now.Value.ToString("HH:mm:ss.fff"));
                rtb.AppendText(" ");
            }
            rtb.SelectionColor = color;
            rtb.AppendText(line);
            rtb.AppendText("\n");
            rtb.SelectionStart = rtb.Text.Length;
            rtb.ScrollToCaret();
        }
    }

    public class Line
    {
        public List<byte> Bytes = new List<byte>();
        public DateTime Last = DateTime.Now;
        public DateTime Now;
        public byte Separator;
        public bool Readline;
        public bool Standard;
        public bool Hexmode;
        public string Type;
        public string Text;
        public string Readable;
        public string Hexadecimal;
    }
}
