using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SharpLogger;

namespace SharpTerminal
{
    public partial class LogView : LogPanel
    {
        private readonly LinkedList<LogLine> shown = new LinkedList<LogLine>();
        private readonly LinkedList<LogLine> queue = new LinkedList<LogLine>();
        private readonly Timer timer = new Timer();

        private readonly int limit = 10000;
        private bool dirty;

        public LogView()
        {
            timer.Tick += Timer_Tick;
            timer.Interval = 100;
            timer.Enabled = true;
        }

        public void Append(LogLine line)
        {
            lock (queue)
            {
                queue.AddLast(line);
            }
        }

        public void Clear()
        {
            shown.Clear();
            SetLines();
        }

        private LogLine[] Pop()
        {
            lock (queue)
            {
                var array = new LogLine[queue.Count];
                queue.CopyTo(array, 0);
                queue.Clear();
                return array;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            foreach (var line in Pop())
            {
                shown.AddLast(line);
                dirty = true;
            }
            while (shown.Count > limit)
            {
                shown.RemoveFirst();
                dirty = true;
            }
            if (dirty)
            {
                SetLines(Shown());
                dirty = false;
            }
            timer.Enabled = true;
        }

        private LogLine[] Shown()
        {
            var list = new List<LogLine>();
            foreach (var line in shown) list.Add(line);
            return list.ToArray();
        }
    }
}
