using System;
using SharpTerminal.Tools;
using SharpTabs;

namespace SharpTerminal
{
	public class TerminalDto : ISessionDto
	{
        public TerminalDto()
        {
            Serial = new SerialSettings();
            Name = "New Session";
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public SerialSettings Serial { get; set; }
        public string PortName { get; set; } = "COM1";
        public string ClientHost { get; set; } = "127.0.0.1";
        public int ClientPort { get; set; } = 8000;
        public string ServerIP { get; set; } = "127.0.0.1";
        public int ServerPort { get; set; } = 8000;
        public string SendMode { get; set; } = "Append CR+NL";
        public bool Standard { get; set; }
        public bool Readline { get; set; } = true;
        public string ReadMode { get; set; } = "Break on NL";
        public string Text { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public string Text4 { get; set; }
        public string Text5 { get; set; }
        public string Text6 { get; set; }
        public string Text7 { get; set; }
        public string Text8 { get; set; }
        public string Text9 { get; set; }
        public string Text10 { get; set; }
        public string Text11 { get; set; }
        public string Text12 { get; set; }
        public string Hex { get; set; }
        public string Hex1 { get; set; }
        public string Hex2 { get; set; }
        public string Hex3 { get; set; }
        public string Hex4 { get; set; }
        public string Hex5 { get; set; }
        public string Hex6 { get; set; }
        public string Hex7 { get; set; }
        public string Hex8 { get; set; }
        public string Hex9 { get; set; }
        public string Hex10 { get; set; }
        public string Hex11 { get; set; }
        public string Hex12 { get; set; }
    }
}
