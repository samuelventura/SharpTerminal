using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Text;

namespace SharpTerminal
{
    /* Cases to handle
     * - In hex mode a flush ir required for packets > 255 bytes
     * - In hex mode a flush ir required if silence for 100ms
     * - In txt mode a flush ir required for packets > 255 bytes
     */

    public class RichTextBuffer
    {
        private const int SILENCE_TO = 100;
        private const int MAX_LENGTH = 256;

        private readonly Queue<Line> lines = new Queue<Line>();
        private Line current;
        private bool readline;
        private byte separator;

        private string ToText(string prefix, byte[] bytes)
        {
            var sb = new StringBuilder();
            sb.Append(prefix);
            foreach (var b in bytes)
            {
                var c = (char)b;
                if (Char.IsControl(c)) sb.Append(string.Format("[{0:X2}]", (int)c));
                else sb.Append(c);
            }
            return sb.ToString();
        }

        private string ToHex(string prefix, byte[] bytes)
        {
            var sb = new StringBuilder();
            sb.Append(prefix);
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
                current.Hex = ToHex("< ", bytes);
                lines.Enqueue(current);
            }

            current = new Line
            {
                Type = "input",
                Readline = readline,
                Separator = separator
            };
        }

        public void Setup(bool readline, byte separator)
        {
            this.readline = readline;
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
                Text = args.Length > 0 ? string.Format(format, args) : format
            };
            lines.Enqueue(line);
        }

        public void Output(byte[] bytes, bool text)
        {
            Flush();
            var line = new Line
            {
                Readline = text,
                Now = DateTime.Now,
                Type = "output",
                Text = ToText("> ", bytes),
                Hex = ToHex("> ", bytes)
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

                var color = Color.White;
                switch (line.Type)
                {
                    case "input":
                        color = Color.DodgerBlue;
                        if (line.Readline) Add(rtb, color, line.Now, line.Text);
                        Add(rtb, line.Readline ? Color.Gray : color, line.Now, line.Hex);
                        break;
                    case "output":
                        color = Color.Salmon;
                        if (line.Readline) Add(rtb, color, line.Now, line.Text);
                        Add(rtb, line.Readline ? Color.Gray : color, line.Now, line.Hex);
                        break;
                    case "success":
                        color = Color.LimeGreen;
                        Add(rtb, color, line.Now, line.Text);
                        break;
                    case "error":
                        color = Color.OrangeRed;
                        Add(rtb, color, line.Now, line.Text);
                        break;
                    case "warn":
                        color = Color.Yellow;
                        Add(rtb, color, line.Now, line.Text);
                        break;
                }
            }
        }

        public void Add(RichTextBox rtb, Color color, DateTime now, string line)
        {
            rtb.SelectionLength = 0; //clear selection
            rtb.SelectionStart = rtb.Text.Length;
            rtb.SelectionColor = Color.Gray;
            rtb.AppendText(now.ToString("HH:mm:ss.fff"));
            rtb.AppendText(" ");
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
        public string Type;
        public string Text;
        public string Hex;
    }
}
