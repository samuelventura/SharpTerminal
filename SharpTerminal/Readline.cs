﻿using System;
using System.Collections.Generic;

namespace SharpTerminal
{
    public class Readline
    {
        private readonly Action<byte[]> handler;
        private readonly List<byte> line = new List<byte>();
        private byte separator = 0x0a;
        private bool enabled;

        public Readline(Action<byte[]> handler)
        {
            this.handler = handler;
        }

        public void Setup(bool enabled, byte separator)
        {
            this.separator = separator;
            this.enabled = enabled;
            //flush on every change
            if (line.Count > 0) {
                handler(line.ToArray());
                line.Clear();
            }
        }

        public void Append(byte[] bytes)
        {
            if (!enabled)
            {
                if (bytes.Length > 0)
                {
                    foreach (var b in bytes)
                    {
                        line.Add(b);
                    }
                }
                else if (line.Count > 0)
                {
                    handler(line.ToArray());
                    line.Clear();
                }
            }
            else
            {
                foreach (var b in bytes)
                {
                    line.Add(b);
                    if (b == separator)
                    {
                        handler(line.ToArray());
                        line.Clear();
                    }
                }
            }
        }

        public byte[] Tail()
        {
            var tail = line.ToArray();
            line.Clear();
            return tail;
        }
	}
}
