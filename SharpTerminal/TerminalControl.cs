using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using SharpTerminal.Tools;

namespace SharpTerminal
{
    public partial class TerminalControl : UserControl
    {
        private readonly ASCIIEncoding ascii = new ASCIIEncoding();
        private readonly SerialSettings serial = new SerialSettings();
        private IoManager iom = new NopManager();
        private Readline readline;
        private ThreadRunner ior;
        private ControlRunner uir;

        public TerminalControl()
        {
            InitializeComponent();

            Link(buttonSendText, textBoxTextInput);
            Link(buttonSendText1, textBoxTextInput1);
            Link(buttonSendText2, textBoxTextInput2);
            Link(buttonSendText3, textBoxTextInput3);
            Link(buttonSendText4, textBoxTextInput4);
            Link(buttonSendText5, textBoxTextInput5);
            Link(buttonSendText6, textBoxTextInput6);
            Link(buttonSendText7, textBoxTextInput7);
            Link(buttonSendText8, textBoxTextInput8);
            Link(buttonSendText9, textBoxTextInput9);
            Link(buttonSendText10, textBoxTextInput10);
            Link(buttonSendText11, textBoxTextInput11);
            Link(buttonSendText12, textBoxTextInput12);
            Link(buttonSendHex, textBoxHexInput);
            Link(buttonSendHex1, textBoxHexInput1);
            Link(buttonSendHex2, textBoxHexInput2);
            Link(buttonSendHex3, textBoxHexInput3);
            Link(buttonSendHex4, textBoxHexInput4);
            Link(buttonSendHex5, textBoxHexInput5);
            Link(buttonSendHex6, textBoxHexInput6);
            Link(buttonSendHex7, textBoxHexInput7);
            Link(buttonSendHex8, textBoxHexInput8);
            Link(buttonSendHex9, textBoxHexInput9);
            Link(buttonSendHex10, textBoxHexInput10);
            Link(buttonSendHex11, textBoxHexInput11);
            Link(buttonSendHex12, textBoxHexInput12);
        }

        public void Unload()
        {
            ior.Dispose(IoClose);
        }

        public void FromUI(SessionSettings config)
        {
            config.Serial.CopyFrom(serial);
            config.PortName = comboBoxSerial.Text;
            config.ClientHost = textBoxClientHost.Text;
            config.ClientPort = (int)numericUpDownClientPort.Value;
            config.ServerIP = comboBoxServerIP.Text;
            config.ServerPort = (int)numericUpDownServerPort.Value;
            config.Readline = checkBoxReadline.Checked;
            config.ReadMode = comboBoxReadMode.Text;
            config.SendMode = comboBoxSendMode.Text;
            config.Text = textBoxTextInput.Text;
            config.Text1 = textBoxTextInput1.Text;
            config.Text2 = textBoxTextInput2.Text;
            config.Text3 = textBoxTextInput3.Text;
            config.Text4 = textBoxTextInput4.Text;
            config.Text5 = textBoxTextInput5.Text;
            config.Text6 = textBoxTextInput6.Text;
            config.Text7 = textBoxTextInput7.Text;
            config.Text8 = textBoxTextInput8.Text;
            config.Text9 = textBoxTextInput9.Text;
            config.Text10 = textBoxTextInput10.Text;
            config.Text11 = textBoxTextInput11.Text;
            config.Text12 = textBoxTextInput12.Text;
            config.Hex = textBoxHexInput.Text;
            config.Hex1 = textBoxHexInput1.Text;
            config.Hex2 = textBoxHexInput2.Text;
            config.Hex3 = textBoxHexInput3.Text;
            config.Hex4 = textBoxHexInput4.Text;
            config.Hex5 = textBoxHexInput5.Text;
            config.Hex6 = textBoxHexInput6.Text;
            config.Hex7 = textBoxHexInput7.Text;
            config.Hex8 = textBoxHexInput8.Text;
            config.Hex9 = textBoxHexInput9.Text;
            config.Hex10 = textBoxHexInput10.Text;
            config.Hex11 = textBoxHexInput11.Text;
            config.Hex12 = textBoxHexInput12.Text;
        }

        public void ToUI(SessionSettings config)
        {
            config.Serial.CopyTo(serial);
            comboBoxSerial.Text = config.PortName;
            numericUpDownClientPort.Value = config.ClientPort;
            numericUpDownServerPort.Value = config.ServerPort;
            if (config.ClientHost != null) textBoxClientHost.Text = config.ClientHost;
            if (config.ServerIP != null) comboBoxServerIP.Text = config.ServerIP;
            if (config.SendMode != null) comboBoxSendMode.Text = config.SendMode;
            if (config.ReadMode != null) comboBoxReadMode.Text = config.ReadMode;
            checkBoxReadline.Checked = config.Readline;
            textBoxTextInput.Text = config.Text;
            textBoxTextInput1.Text = config.Text1;
            textBoxTextInput2.Text = config.Text2;
            textBoxTextInput3.Text = config.Text3;
            textBoxTextInput4.Text = config.Text4;
            textBoxTextInput5.Text = config.Text5;
            textBoxTextInput6.Text = config.Text6;
            textBoxTextInput7.Text = config.Text7;
            textBoxTextInput8.Text = config.Text8;
            textBoxTextInput9.Text = config.Text9;
            textBoxTextInput10.Text = config.Text10;
            textBoxTextInput11.Text = config.Text11;
            textBoxTextInput12.Text = config.Text12;
            textBoxHexInput.Text = config.Hex;
            textBoxHexInput1.Text = config.Hex1;
            textBoxHexInput2.Text = config.Hex2;
            textBoxHexInput3.Text = config.Hex3;
            textBoxHexInput4.Text = config.Hex4;
            textBoxHexInput5.Text = config.Hex5;
            textBoxHexInput6.Text = config.Hex6;
            textBoxHexInput7.Text = config.Hex7;
            textBoxHexInput8.Text = config.Hex8;
            textBoxHexInput9.Text = config.Hex9;
            textBoxHexInput10.Text = config.Hex10;
            textBoxHexInput11.Text = config.Hex11;
            textBoxHexInput12.Text = config.Hex12;
        }

        private void Link(Button button, TextBox textBox)
        {
            textBox.Tag = button;
            button.Tag = textBox;
        }

        private void RefreshSerials()
        {
            var current = comboBoxSerial.Text;
            comboBoxSerial.Items.Clear();
            foreach (var name in SerialPort.GetPortNames())
            {
                comboBoxSerial.Items.Add(name);
            }
            comboBoxSerial.Text = current;
        }

        private void EnableControls(bool closed)
        {
            linkLabelSerial.Enabled = closed;
            comboBoxSerial.Enabled = closed;
            buttonOpenSerial.Enabled = closed;
            buttonSetupSerial.Enabled = closed;
            textBoxClientHost.Enabled = closed;
            numericUpDownClientPort.Enabled = closed;
            buttonOpenSocket.Enabled = closed;
            comboBoxServerIP.Enabled = closed;
            numericUpDownServerPort.Enabled = closed;
            buttonListenSocket.Enabled = closed;
            buttonClose.Enabled = !closed;
            buttonSendText.Enabled = !closed;
            buttonSendText1.Enabled = !closed;
            buttonSendText2.Enabled = !closed;
            buttonSendText3.Enabled = !closed;
            buttonSendText4.Enabled = !closed;
            buttonSendText5.Enabled = !closed;
            buttonSendText6.Enabled = !closed;
            buttonSendText7.Enabled = !closed;
            buttonSendText8.Enabled = !closed;
            buttonSendText9.Enabled = !closed;
            buttonSendText10.Enabled = !closed;
            buttonSendText11.Enabled = !closed;
            buttonSendText12.Enabled = !closed;
            buttonSendHex.Enabled = !closed;
            buttonSendHex1.Enabled = !closed;
            buttonSendHex2.Enabled = !closed;
            buttonSendHex3.Enabled = !closed;
            buttonSendHex4.Enabled = !closed;
            buttonSendHex5.Enabled = !closed;
            buttonSendHex6.Enabled = !closed;
            buttonSendHex7.Enabled = !closed;
            buttonSendHex8.Enabled = !closed;
            buttonSendHex9.Enabled = !closed;
            buttonSendHex10.Enabled = !closed;
            buttonSendHex11.Enabled = !closed;
            buttonSendHex12.Enabled = !closed;
        }

        private void Log(string type, string format, params object[] args)
        {
            if (args.Length > 0)
                format = string.Format(format, args);
            var color = Color.White;
            switch (type)
            {
                case "<":
                    color = Color.DodgerBlue;
                    break;
                case ">":
                    color = Color.Salmon;
                    break;
                case "success":
                    color = Color.LimeGreen;
                    break;
                case "error":
                    color = Color.OrangeRed;
                    break;
                case "warn":
                    color = Color.Yellow;
                    break;
            }
            richTextBoxLog.SelectionLength = 0; //clear selection
            richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
            richTextBoxLog.SelectionColor = Color.Gray;
            richTextBoxLog.AppendText(DateTime.Now.ToString("HH:mm:ss.fff"));
            richTextBoxLog.SelectionColor = color;
            richTextBoxLog.AppendText(" ");
            richTextBoxLog.AppendText(format);
            richTextBoxLog.AppendText("\n");
            richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
            richTextBoxLog.ScrollToCaret();
        }

        private void AppendLineEnding(List<byte> bytes)
        {
            var mode = comboBoxSendMode.Text;
            switch (mode)
            {
                case "Append CR+NL":
                    bytes.Add(0x0D);
                    bytes.Add(0x0A);
                    break;
                case "Append CR":
                    bytes.Add(0x0D);
                    break;
                case "Append NL":
                    bytes.Add(0x0A);
                    break;
            }
        }

        private void Log(char prefix, byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                var c = (char)b;
                if (Char.IsControl(c))
                    sb.Append(string.Format("[{0:X2}]", (int)c));
                else
                    sb.Append(c);
            }
            sb.Append("\n");
            sb.Append(prefix);
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("X2"));
                sb.Append(" ");
            }
            Log(prefix.ToString(), sb.ToString());
        }

        private void UpdateReadline()
        {
            var enable = checkBoxReadline.Checked && comboBoxReadMode.SelectedIndex >= 0 && tabControl.SelectedTab != tabPageHex;
            var separator = 0x00;
            switch (comboBoxReadMode.Text)
            {
                case "Break on NL":
                    separator = 0x0a;
                    break;
                case "Break on CR":
                    separator = 0x0d;
                    break;
            }
            ior.Run(() => readline.Setup(enable, (byte)separator));
        }

        private void Write(byte[] bytes)
        {
            Log('>', bytes);
            ior.Run(() => iom.Write(bytes));
        }

        private void IoClose()
        {
            Disposer.Dispose(iom);
            iom = new NopManager();
            uir.Run(() => EnableControls(true));
        }

        private void IoException(Exception ex)
        {
            IoClose();
            uir.Run(() => Log("error", "Error: {0}", ex.Message));
        }

        private void IoIdle()
        {
            iom.Read();
            Thread.Sleep(10);
        }

        private void IoMonitor(byte[] bytes)
        {
            uir.Run(() => Log('<', bytes));
        }

        private void SendText(string text)
        {
            var bytes = new List<byte>();
            bytes.AddRange(ascii.GetBytes(text));
            AppendLineEnding(bytes);
            Write(bytes.ToArray());
        }

        private void SendHex(TextBox textBox)
        {
            var bytes = Hexadecimal.Parse(textBox.Text);
            textBox.Text = Hexadecimal.ToString(bytes);
            Write(bytes);
        }

        private void TerminalControl_Load(object sender, EventArgs e)
        {
            uir = new ControlRunner(this);
            ior = new ThreadRunner("IO", IoException, IoIdle);
            readline = new Readline(IoMonitor);
            if (comboBoxReadMode.SelectedIndex < 0) comboBoxReadMode.SelectedIndex = 0;
            if (comboBoxSendMode.SelectedIndex < 0) comboBoxSendMode.SelectedIndex = 0;
            if (comboBoxServerIP.SelectedIndex < 0) comboBoxServerIP.SelectedIndex = 0;
            if (string.IsNullOrWhiteSpace(textBoxClientHost.Text)) textBoxClientHost.Text = "127.0.0.1";
            RefreshSerials();
            EnableControls(true);
            UpdateReadline();
        }

        private void LinkLabelSerial_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshSerials();
            comboBoxSerial.DroppedDown = true;
        }

        private void ButtonSetupSerial_Click(object sender, EventArgs e)
        {
            var setup = new SerialSettingsForm(serial);
            setup.ShowDialog();
        }

        private void ButtonOpenSerial_Click(object sender, EventArgs e)
        {
            var name = comboBoxSerial.Text;
            EnableControls(false);
            ior.Run(() => {
                iom = new SerialManager(name, serial, readline);
                uir.Run(() => Log("success", "Serial {0} open", iom.Name));
            });
        }

        private void ButtonOpenSocket_Click(object sender, EventArgs e)
        {
            var host = textBoxClientHost.Text;
            var port = (int)numericUpDownClientPort.Value;
            EnableControls(false);
            ior.Run(() => {
                iom = new SocketManager(host, port, readline);
                uir.Run(() => Log("success", "Socket {0} open", iom.Name));
            });
        }

        private void ButtonListenSocket_Click(object sender, EventArgs e)
        {
            var ip = comboBoxServerIP.Text;
            var port = (int)numericUpDownServerPort.Value;
            EnableControls(false);
            ior.Run(() => {
                iom = new ListenManager(ip, port, readline, ior);
                uir.Run(() => Log("success", "Listener {0} open", iom.Name));
            });
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            ior.Run(IoClose);
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            richTextBoxLog.Clear();
        }

        private void ButtonSendText_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var textbox = (TextBox)button.Tag;
            SendText(textbox.Text);
        }

        private void ButtonSendLines_Click(object sender, EventArgs e)
        {
            foreach (var text in textBoxTextInput.Lines)
            {
                SendText(text);
            }
        }

        private void ButtonSendHex_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var textbox = (TextBox)button.Tag;
            SendHex(textbox);
        }

        private void TextBoxAllInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var textbox = (TextBox)sender;
                var button = (Button)textbox.Tag;
                button.PerformClick();
            }
        }

        private void TextBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == (Keys.Control | Keys.Enter)))
            {
                e.SuppressKeyPress = true;
                var textbox = (TextBox)sender;
                var button = (Button)textbox.Tag;
                button.PerformClick();
            }
        }

        private void CheckBoxReadline_CheckedChanged(object sender, EventArgs e)
        {
            UpdateReadline();
        }

        private void TabControl_Selected(object sender, TabControlEventArgs e)
        {
            UpdateReadline();
        }

        private void ComboBoxReadMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateReadline();
        }
    }
}
