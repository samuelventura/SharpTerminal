using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using SharpLogger;

namespace SharpTerminal
{
    public partial class LogView : LogPanel
    {
        private static readonly LogDebug debugger = new LogDebug(typeof(LogView).Name);
        private const int WM_VSCROLL = 0x115;
        private const int WM_HSCROLL = 0x114;
        private const int WM_MOUSEWHEEL = 0x020A;
        private const int WM_LBUTTONDOWN = 0x0201;
        private readonly LinkedList<LogLine> shown = new LinkedList<LogLine>();
        private readonly LinkedList<LogLine> queue = new LinkedList<LogLine>();
        private readonly Timer timer = new Timer();

        private int limit = 1000;
        private bool dirty;
        private bool freeze;

        [Category("Logging")]
        public int LineLimit
        {
            get { return limit; }
            set { limit = value; }
        }
        [Category("Logging")]
        public int PollPeriod
        {
            get { return timer.Interval; }
            set { timer.Interval = value; }
        }

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
            freeze = false;
            shown.Clear();
            SetLines();
        }

        //temporary.. find a better more explicit way
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_VSCROLL:
                case WM_HSCROLL:
                case WM_MOUSEWHEEL:
                case WM_LBUTTONDOWN:
                    freeze = true;
                    break;
            }
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if (e.KeyCode == Keys.Escape)
            {
                freeze = false;
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
            if (dirty && !freeze)
            {
                SetLines(Shown());
                dirty = false;
            }
            timer.Enabled = true;
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

        private LogLine[] Shown()
        {
            var array = new LogLine[shown.Count];
            shown.CopyTo(array, 0);
            return array;
        }
    }
}
